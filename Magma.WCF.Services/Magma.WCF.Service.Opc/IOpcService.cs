using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace Magma.WCF.Services.Opc
{
    /// <summary>
    /// IOpcService is the contract for the OpcService service.
    /// It exposes read and write functionality
    /// </summary>
    [ServiceContract(Namespace = "http://Magma.WCF.Services.OpcService")]
    public interface IOpcService
    {
        /// <summary>
        /// Writes a single value to a tag
        /// </summary>
        /// <param name="tagAddress">The tag address</param>
        /// <param name="value">the value to write</param>
        /// <param name="parameterProgId">prog ID of the OPC server - pass string.Empty or null to use the opc prog ID defined in the service config</param>
        /// <returns></returns>
        [OperationContract]
        bool WriteSingleValue(string tagAddress, object value, string parameterProgId, bool simulate);

        /// <summary>
        /// writes several values to several tags
        /// </summary>
        /// <param name="values">a dictionary of values to write. The keys are the tag address, the values are the values to write</param>
        /// <param name="parameterProgId">prog ID of the OPC server - pass string.Empty or null to use the opc prog ID defined in the service config</param>
        /// <returns></returns>
        [OperationContract]
        bool WriteSingleArrayValue(string tagAddress, string commaSepereatedValues, string parameterProgId, bool simulate);

        /// <summary>
        /// writes several values to several tags
        /// </summary>
        /// <param name="values">a dictionary of values to write. The keys are the tag address, the values are the values to write</param>
        /// <param name="parameterProgId">prog ID of the OPC server - pass string.Empty or null to use the opc prog ID defined in the service config</param>
        /// <returns></returns>
        [OperationContract]
        WriteValuesResult WriteValues(Dictionary<string, object> values, string parameterProgId, bool simulate);

        /// <summary>
        /// reads a single value from a tag
        /// </summary>
        /// <param name="tagAddress">The tag address</param>
        /// <param name="readDevice">read from the PLC - true. Read from the OPC cache - false</param>
        /// <param name="parameterProgId">prog ID of the OPC server - pass string.Empty or null to use the opc prog ID defined in the service config</param>
        /// <returns></returns>
        [OperationContract]
        OpcValue ReadSingleValue(string tagAddress, bool readDevice = false, string parameterProgId = "");




        /// <summary>
        /// read several values from several tags
        /// </summary>
        /// <param name="tagAddressList">a list of tag address to read</param>
        /// <param name="readDevice">read from the PLC - true. Read from the OPC cache - false</param>
        /// <param name="parameterProgId">prog ID of the OPC server - pass string.Empty or null to use the opc prog ID defined in the service config</param>
        /// <returns></returns>
        [OperationContract]
        List<OpcValue> ReadValues(List<string> tagAddressList, bool readDevice = false, string parameterProgId = "");

        /// <summary>
        /// returns the service mode as a string
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string GetServiceMode();

        /// <summary>
        /// returns the tags to exclude on simulate write mode
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<string> GetTagsToExcludeOnSimulateWrite();
    }

    /// <summary>
    /// When writing several values to the OPC server, some may succeeded and some may fail.
    /// So, the return value of WriteValues is WriteValuesResult.
    /// It wraps a dictionary of string=tag address,Exception - if an error has occurred while writing.
    /// 
    /// The WriteStatusType enum may be:
    /// 1. Success - if all write were successful.
    /// 2. Partial Success - if some succeeded and some failed.
    /// 3. Failure - everything failed.
    /// </summary>
    [DataContract(Name = "WriteValuesResult", Namespace = "http://Magma.WCF.Services.OpcService")]
    public class WriteValuesResult
    {
        #region Class Properties - Data Members

        /// <summary>The dictionary of tagAddress-Exception</summary>
        [DataMember]
        public Dictionary<string,Exception> WriteTagsStatusList { get; private set; }

        /// <summary>The result</summary>
        [DataMember]
        public bool Success { get; private set; }

        #endregion

        #region Class construction

        /// <summary>
        /// determines the WriteStatus according to the number of exceptions in the the dictionary
        /// </summary>
        /// <param name="writeTagsStatusList"></param>
        public WriteValuesResult(Dictionary<string,Exception> writeTagsStatusList)
        {
            WriteTagsStatusList = writeTagsStatusList;

            // get the number of values that had exceptions in them
            int exceptionCount = WriteTagsStatusList.Values.Where(v => v != null).Count<Exception>();

            // check how many
            if (exceptionCount == 0)
            {
                // no exception, so Success.
                Success = true;
            }
            else
            {
                Success = false;
            }
        }

        #endregion


    }
    

    /// <summary>
    /// OpcValue encapsulates all the relevant data for a value that was read from the OPC
    /// </summary>
    [DataContract(Name = "OpcValue", Namespace = "http://Magma.WCF.Services.OpcService")]
    public class OpcValue
    {
        /// <summary>The tag address</summary>
        [DataMember]
        public string TagAddress{ get; private set; }

        /// <summary>The value that was read</summary>
        [DataMember]
        public object Value { get; private set; }

        /// <summary>The DT in which the value was read</summary>
        [DataMember]
        public DateTime TimeStamp { get; private set; }

        /// <summary>Quality - This should be "GOOD" on a successful read</summary>
        [DataMember]
        public string Quality { get; private set; }

        /// <summary>
        /// Creates a new instance and saves the props.
        /// </summary>
        /// <param name="tagAddress"></param>
        /// <param name="value"></param>
        /// <param name="timeStamp"></param>
        /// <param name="quality"></param>
        public OpcValue(string tagAddress, object value, DateTime timeStamp, string quality)
        {
            TagAddress = tagAddress;
            Value = value;
            TimeStamp = timeStamp;
            Quality = quality;
        }
    }
    
}
