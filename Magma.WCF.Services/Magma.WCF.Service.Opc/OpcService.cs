using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using Lighthouse.Opc.ClientLibrary;
using Magma.WCF.Services.Logging;
using System.IO;
using System.Reflection;
using Magma.WCF.Service.Opc;

namespace Magma.WCF.Services.Opc
{
    /// <summary>
    /// OpcService is a WCF service that wraps the OpcServerReadWrite object (which is Lighthouse system's implementation for OPC DA and UA).
    /// A single service interacts with a single OPC server.
    /// Server Node and Prog ID are read from the host's config file.
    /// 
    /// It is best if the host and  the OPC server are installed on the same machine - to avoid DCOM.
    /// </summary>
    public class OpcService : IOpcService
    {
        public enum SimulateModeTypes
        {
            NoSimulate,
            SimulateAll,
            SimulateWriteOnly
        }

        protected const string EXCLUDE_SIMULATE_TAGS_FILE = @".exclude";

        #region Class properties

        /// <summary>upon read/write failure - how many times should the service retry before throwing an exception</summary>
        public static int RetryCount { get; private set; }

        /// <summary>upon read/write failure - the time in milliseconds to wait between retries</summary>
        public static int RetryInterval { get; private set; }

        /// <summary>The computer name on which the OPC Server is installed - String.Empty if local</summary>
        public static string ServerNode { get; private set; }

        /// <summary>OPC Server COM Prog ID</summary>
        public static string ConfigProgId { get; private set; }

        /// <summary>true when the reads and writes are simulated</summary>
        public static SimulateModeTypes SimulateMode { get; private set; }

        /// <summary> </summary>
        public static List<string> TagsToExcludeOnSimulateWrite { get; set; }

        #endregion

        #region Class methods


        /// <summary>
        /// Initalize
        /// </summary>
        /// <param name="serverNode">OPC Server node - empty if locak</param>
        /// <param name="progId">OPC server COM prog ID</param>
        /// <param name="retryCount">Read/Write retry count</param>
        /// <param name="retryInterval">wait interval in milisecods between retries</param>
        public static void Initialize(string serverNode, string progId, int retryCount, int retryInterval, SimulateModeTypes simulateMode)
        {
            string tag = string.Empty;
            string excludeFilePathAndName = string.Empty;

            try
            {
                TagsToExcludeOnSimulateWrite = new List<string>();

                RetryCount = retryCount;
                RetryInterval = retryInterval;
                ServerNode = serverNode;
                ConfigProgId = progId;
                SimulateMode = simulateMode;

                // in case of simulate mode, we might want to exclude several tags - that is - for these tags, this is not simulate
                try
                {
                    // so we initialize a list of tags from a file EXCLUDE_SIMULATE_TAGS_FILE
                    excludeFilePathAndName = Assembly.GetEntryAssembly().Location + EXCLUDE_SIMULATE_TAGS_FILE;
                    if (File.Exists(excludeFilePathAndName))
                    {
                        Logger.Debug("Initialize", "reading ", excludeFilePathAndName);

                        using (StreamReader reader = new StreamReader(excludeFilePathAndName))
                        {
                            while ((tag = reader.ReadLine()) != null)
                            {
                                Logger.Debug("Initialize", "Tag to exclude on simulate:", tag);
                                TagsToExcludeOnSimulateWrite.Add(tag);
                            }

                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write(ex);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// gets an OpcServerReadWrite as a parameter and does the acutal writing
        /// </summary>
        /// <param name="tagAddress"></param>
        /// <param name="value"></param>
        /// <param name="opcServer"></param>
        /// <returns></returns>
        protected bool WriteSingleValue(string tagAddress, object value, OpcServerReadWrite opcServer, bool simulate)
        {
            OpcServerReadWriteValue opcWriteValue = null;
            string writeGroup = string.Empty;


            try
            {
                Debug("WriteSingleValue", tagAddress, value.ToString(), "Start", EventLogEntryType.Information);

                // create a value object
                opcWriteValue = new OpcServerReadWriteValue();
                opcWriteValue.Value = value;
                writeGroup = "write" + Guid.NewGuid().ToString();

                // verify that this is not simulate mode (all, write or client) or it is simulate mode but this address is in the exclude list
                if ((SimulateMode == SimulateModeTypes.NoSimulate && !simulate) || TagsToExcludeOnSimulateWrite.Contains(tagAddress))
                {
                    // Write to the OPC server
                    opcServer.Write(writeGroup, tagAddress, opcWriteValue);
                }
                else // this is simulate mode
                {
                    Logger.Write("simulate write. Tag Address: " + tagAddress + ". Value: " + opcWriteValue.Value.ToString(), EventLogEntryType.Warning, Logger.SeverityTypes.Warning);
                }

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// gets an OpcServerReadWrite as a parameter and does the actual reading
        /// </summary>
        /// <param name="opcServer"></param>
        /// <param name="tagAddress"></param>
        /// <param name="readDevice"></param>
        /// <returns></returns>
        protected OpcValue ReadSingleValue(OpcServerReadWrite opcServer, string tagAddress, bool readDevice = false)
        {
            OpcServerReadWriteValue value = null;

            try
            {
                // verify that this is not simulate mode (all, write or client) or it is simulate mode but this address is in the exclude list
                if ((SimulateMode != SimulateModeTypes.SimulateAll) || TagsToExcludeOnSimulateWrite.Contains(tagAddress))
                {
                    // read from OPC
                    value = opcServer.Read("read " + Guid.NewGuid().ToString(), tagAddress, readDevice);

                    if (value.Value.GetType().IsArray)
                    {
                        string strValues = String.Empty;

                        foreach (object obj in (IEnumerable)value.Value)
                        {
                            strValues += obj.ToString() + " ";
                        }

                        value.Value = strValues.Trim().Replace(" ", ",");
                        Debug("ReadSingleValue", tagAddress, readDevice.ToString(), "Converted array: " + value.Value, EventLogEntryType.Information);
                    }

                    // return OpcValue object
                    return new OpcValue(tagAddress, value.Value, value.Timrstanp, value.Quality);
                }
                else // simulate mode
                {
                    Logger.Write("simulate read. Tag Address: " + tagAddress, EventLogEntryType.Warning, Logger.SeverityTypes.Warning);
                    return new OpcValue(tagAddress, 0, DateTime.Now, "Good");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// gets an OpcServerReadWrite as a parameter and does the actual reading
        /// </summary>
        /// <param name="opcServer"></param>
        /// <param name="tagAddress"></param>
        /// <param name="readDevice"></param>
        /// <returns></returns>
        protected List<OpcValue> ReadMultipleValues(OpcServerReadWriteMultipleTags opcServer, List<string> tagAddressList, bool readDevice = false)
        {
            List<OpcValue> readValues = new List<OpcValue>();
            OpcServerReadWriteMultipleValues[] value = null;

            try
            {
               
                value = opcServer.ReadMultipleTags("read " + Guid.NewGuid().ToString(), tagAddressList, readDevice);

                int resultLen = value.Length;

                if (resultLen > 0)
                {
                    for (int i = 0; i < resultLen; i++)
                    {
                        OpcValue OpcValue = new OpcValue(value[i].TagAddress, value[i].Value, value[i].Timrstanp, value[i].Quality);
                        readValues.Add(OpcValue);
                    }
                }
                else
                {
                    Logger.Write("ReadMultipleValues Method Return 0 list ", System.Diagnostics.EventLogEntryType.Error, Logger.SeverityTypes.Warning);
                    OpcValue OpcValue = new OpcValue("Error", 0, DateTime.Now, "Good");
                    readValues.Add(OpcValue);
                }

                return readValues;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Helper method to write debug information to the event log
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="tagAddress"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="eventLogEntryType"></param>
        protected void Debug(string methodName, string tagAddress, string param1, string param2, EventLogEntryType eventLogEntryType)
        {
            string loggingString = "Method: {0}. TagAddress: {1}. Param1: {2}. Param2: {3}";
            try
            {
                loggingString = String.Format(loggingString, methodName, tagAddress, param1, param2);
                Logger.Write(loggingString, eventLogEntryType, Logger.SeverityTypes.Debug);
            }
            catch (Exception)
            { }
        }

        #endregion

        #region Operation Contracts

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetServiceMode()
        {
            return Enum.GetName(typeof(SimulateModeTypes), SimulateMode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetTagsToExcludeOnSimulateWrite()
        {
            return TagsToExcludeOnSimulateWrite;
        }

        /// <summary>
        /// Writes a single value to a single tag in the opc.
        /// This method also implement retries in case of failures.
        /// An OpcServerReadWrite is created here and a connection to the OPC server is established.
        /// </summary>
        /// <param name="tagAddress"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriteSingleValue(string tagAddress, object value, string parameterProgId, bool simulate)
        {
            bool result = false;
            string actualProgId = string.Empty;

            try
            {
                // determine the prog ID to use - if the parameter is empty, get the progID from the app.config file
                actualProgId = String.IsNullOrEmpty(parameterProgId) ? ConfigProgId : parameterProgId;

                // trying to write several times (RetryCount)
                for (int i = 1; i <= RetryCount; i++)
                {
                    try
                    {
                        // create an OpcServerReadWrite object and connect
                        using (OpcServerReadWrite opcServer = new OpcServerReadWrite(ServerNode, actualProgId))
                        {
                            // Write the value
                            result = WriteSingleValue(tagAddress, value, opcServer, simulate);
                            opcServer.Disconnect();
                        }

                        return result;
                    }
                    catch (Exception iterationEx)
                    {
                        // check if this is the last retry
                        if (i == RetryCount)
                        {
                            // if so, throw the exception
                            throw iterationEx;
                        }

                        // still trying...
                        Debug("WriteSingleValue", tagAddress, value.ToString(), "retry: " + i.ToString(), EventLogEntryType.Warning);
                        // sleep for a while
                        Thread.Sleep(RetryInterval);
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);

                return false;
            }
        }

        /// <summary>
        /// Write several values to several OPC tags.
        /// In this case, some writes can succeed and some may fail. See WriteValuesResult for details
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public WriteValuesResult WriteValues(Dictionary<string, object> values, string parameterProgId, bool simulate)
        {
            Dictionary<string, Exception> writeValuesResult = null;
            string actualProgId = string.Empty;

            try
            {
                // determine the prog ID to use - if the parameter is empty, get the progID from the app.config file
                actualProgId = String.IsNullOrEmpty(parameterProgId) ? ConfigProgId : parameterProgId;

                Debug("WriteValues", "MULTIPLE", values.Count.ToString(), actualProgId, EventLogEntryType.Information);

                // create a Dictionary that will be a part of the result object
                writeValuesResult = new Dictionary<string, Exception>(values.Count);

                // create and connect to the OPC Server
                using (OpcServerReadWrite opcServer = new OpcServerReadWrite(ServerNode, actualProgId))
                {
                    // foreach tag-value on the parameter Dictionary
                    foreach (KeyValuePair<string, object> opcWriteValue in values)
                    {
                        try // try to write
                        {
                            WriteSingleValue(opcWriteValue.Key, opcWriteValue.Value, opcServer, simulate);
                            // if the write is successful, add to the result dictionary with no exception
                            writeValuesResult.Add(opcWriteValue.Key, null);
                        }
                        catch (Exception ex)
                        {
                            // in case of an error, add the result with the exception
                            writeValuesResult.Add(opcWriteValue.Key, ex);
                        }
                    }

                    opcServer.Disconnect();
                }

                return new WriteValuesResult(writeValuesResult);
            }
            catch (Exception ex)
            {
                Logger.Write(ex.ToString(), System.Diagnostics.EventLogEntryType.Error, Logger.SeverityTypes.Warning);

                return null;
            }

        }

        /// <summary>
        /// Reads a single value from a single tag address
        /// </summary>
        /// <param name="tagAddress"></param>
        /// <param name="readDevice"></param>
        /// <returns></returns>
        public OpcValue ReadSingleValue(string tagAddress, bool readDevice = false, string parameterProgId = "")
        {
            OpcValue result = null;
            string actualProgId = string.Empty;

            try
            {
                // determine the prog ID to use - if the parameter is empty, get the progID from the app.config file
                actualProgId = String.IsNullOrEmpty(parameterProgId) ? ConfigProgId : parameterProgId;

                Debug("ReadSingleValue", tagAddress, readDevice.ToString(), "actualProgId: " + actualProgId, EventLogEntryType.Information);

               
                // try to read several times (RetryCount)
                for (int i = 1; i <= RetryCount; i++)
                {
                    try
                    {
                        // create and connect to the OPC Server
                        using (OpcServerReadWrite opcServer = new OpcServerReadWrite(ServerNode, actualProgId))
                        {
                            // try to read;
                            result = ReadSingleValue(opcServer, tagAddress, readDevice);
                            opcServer.Disconnect();

                        }

                        Debug("ReadSingleValue", tagAddress, readDevice.ToString(), "Value read: " + result.Value.ToString(), EventLogEntryType.Information);
                        return result;
                    }
                    catch (Exception iterationEx)
                    {
                        // check if this is the last retry
                        if (i == RetryCount)
                        {
                            // if so, throw the exception
                            throw iterationEx;
                        }

                        // still trying...
                        Debug("ReadSingleValue", tagAddress, readDevice.ToString(), "retry: " + i.ToString(), EventLogEntryType.Warning);
                        // sleep for a while
                        Thread.Sleep(RetryInterval);
                    }
                }

                // if we got to this point, there's a failure!
                return null;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        /// <summary>
        /// Reads several values from the OPC. There's no retry here,
        /// </summary>
        /// <param name="tagAddressList"></param>
        /// <param name="readDevice"></param>
        /// <returns></returns>
        public List<OpcValue> ReadValues(List<string> tagAddressList, bool readDevice = false, string parameterProgId = "")
        {
            List<OpcValue> readValues = new List<OpcValue>();
            List<OpcValue> simulatereadValues = new List<OpcValue>();
            string actualProgId = string.Empty;

            List<string> tagAddressListTemp = new List<string>();

            try
            {
                // determine the prog ID to use - if the parameter is empty, get the progID from the app.config file
                actualProgId = String.IsNullOrEmpty(parameterProgId) ? ConfigProgId : parameterProgId;

                Debug("ReadValues", "MULTIPLE", readDevice.ToString(), string.Empty, EventLogEntryType.Information);

                // read values from the OPC and store results in the list
                foreach (string tagAddress in tagAddressList)
                {
                    // verify that this is not simulate mode (all, write or client) or it is simulate mode but this address is in the exclude list
                    if ((SimulateMode != SimulateModeTypes.SimulateAll) || TagsToExcludeOnSimulateWrite.Contains(tagAddress))
                    {
                        tagAddressListTemp.Add(tagAddress);
                    }
                    else // simulate mode
                    {
                        Logger.Write("simulate read. Tag Address: " + tagAddress, EventLogEntryType.Warning, Logger.SeverityTypes.Warning);
                        simulatereadValues.Add(new OpcValue(tagAddress, 0, DateTime.Now, "Good"));
                    }
                }


                using (OpcServerReadWriteMultipleTags opcServer = new OpcServerReadWriteMultipleTags(ServerNode, actualProgId))
                {
                    if (tagAddressListTemp.Count > 0)
                    {
                        readValues = ReadMultipleValues(opcServer, tagAddressListTemp, readDevice);
                    }
                    opcServer.DisconnectOPC();
                }

                if (simulatereadValues.Count > 0)
                {
                    readValues.AddRange(simulatereadValues);
                }

                return readValues;
            }
            catch (Exception ex)
            {
                Logger.Write(ex.ToString(), System.Diagnostics.EventLogEntryType.Error, Logger.SeverityTypes.Warning);
                return null;
            }
        }

        #endregion

    }
}
