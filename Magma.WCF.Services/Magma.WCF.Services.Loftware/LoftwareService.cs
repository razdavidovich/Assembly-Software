using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Magma.WCF.Services.Logging;
using Assembly.Software.Loftware;
using System.Reflection;
using System.Diagnostics;
using System.Configuration;

namespace Magma.WCF.Services.Loftware
{
    public class LoftwareService : ILoftwareService 
    {
        #region Class Properties

        private string _strLoftwareServerIPAddress;
        public string LoftwareServerIPAddress
        {
            get {
                return _strLoftwareServerIPAddress = ConfigurationManager.AppSettings["LoftwareServerIPAddress"];
            }
        }

        private int _intLoftwareServerPort;
        public int LoftwareServerPort 
        {
            get
            {
                return _intLoftwareServerPort = Convert.ToInt32(ConfigurationManager.AppSettings["LoftwareServerPort"].ToString());
            }
        }
          
        #endregion


        public List<clsRowPrintStatus> PrintLabelHashtable(int intPrinterID, string strLabelName, int intSerializedLabels, int intNumberOfCopies, Hashtable htlParams)
        {
            //****************************************************************
            // Name : PrintLabelHashtable
            // Description :  Prints labels for a given hash tables 
            // Written By : Sivachandran
            // Date : 17/06/2014
            //****************************************************************
           
            long lngErrorNumber = 0;
            string strErrorDescription = "";

            //Create a loftware wrapper class
            clsPrintLabel objPrintLabel = new clsPrintLabel();
            Logger.Write("Call to " + MethodBase.GetCurrentMethod().Name + " with the following parameters: LPS IP address/Host name = " + LoftwareServerIPAddress +
                     " port number = " + LoftwareServerPort.ToString() + "Printer ID = " + intPrinterID.ToString() + " Label name = " + strLabelName +
                     " serialized copies = " + intSerializedLabels.ToString() + " duplicates = " + intNumberOfCopies.ToString(), EventLogEntryType.Information, Logger.SeverityTypes.Information);

            try
            {
                return objPrintLabel.PrintLabel(LoftwareServerIPAddress, LoftwareServerPort, intPrinterID, strLabelName, intSerializedLabels, intNumberOfCopies, htlParams,ref lngErrorNumber,ref strErrorDescription );
            }
            catch (Exception ex)
            {
                //Log entry to the log procedure
                Logger.Write(ex.ToString(), EventLogEntryType.Error, Logger.SeverityTypes.Error);
                throw ex;
            }

        }

        public List<clsRowPrintStatus> PrintLabelDatatable(int intPrinterID, string strLabelName, int intSerializedLabels, int intNumberOfCopies, System.Data.DataTable dtlParams)
        {
            //****************************************************************
            // Name : PrintLabelDatatable
            // Description :  Prints labels for a given Datatable
            // Written By : Sivachandran
            // Date : 17/06/2014
            //****************************************************************

            long lngErrorNumber = 0;
            string strErrorDescription = "";

            //Create a Loftware wrapper class
            clsPrintLabel objPrintLabel = new clsPrintLabel();

            //Log entry to the log procedure
            Logger.Write("Call to " + MethodBase.GetCurrentMethod().Name + " with the following parameters: LPS IP address/Host name = " + LoftwareServerIPAddress +
                         " port number = " + LoftwareServerPort.ToString() + "Printer ID = " + intPrinterID.ToString() + " Label name = " + strLabelName +
                         " serialized copies = " + intSerializedLabels.ToString() + " duplicates = " + intNumberOfCopies.ToString(), EventLogEntryType.Information, Logger.SeverityTypes.Information);

            try
            {
                return objPrintLabel.PrintLabel(LoftwareServerIPAddress, LoftwareServerPort, intPrinterID, strLabelName, intSerializedLabels, intNumberOfCopies, dtlParams, ref lngErrorNumber, ref strErrorDescription);
            }
            catch (Exception ex)
            {
                //Log entry to the log procedure
                Logger.Write(ex.ToString(), EventLogEntryType.Error, Logger.SeverityTypes.Error);
                throw ex;
            }
        }

        public List<clsRowPrintStatus> PrintLabelDictionary(int intPrinterID, string strLabelName, int intSerializedLabels, int intNumberOfCopies, Dictionary<string, string> dictParams)
        {
            //****************************************************************
            // Name : PrintLabelDictionary
            // Description :  Prints labels for a given Dictionary
            // Written By : Sivachandran
            // Date : 17/06/2014
            //****************************************************************

            long lngErrorNumber = 0;
            string strErrorDescription = "";

            //Create a Loftware wrapper class
            clsPrintLabel objPrintLabel = new clsPrintLabel();

            //Log entry to the log procedure
            Logger.Write("Call to " + MethodBase.GetCurrentMethod().Name + " with the following parameters: LPS IP address/Host name = " + LoftwareServerIPAddress +
                         " port number = " + LoftwareServerPort.ToString() + "Printer ID = " + intPrinterID.ToString() + " Label name = " + strLabelName +
                         " serialized copies = " + intSerializedLabels.ToString() + " duplicates = " + intNumberOfCopies.ToString(), EventLogEntryType.Information, Logger.SeverityTypes.Information);

            try
            {
                return objPrintLabel.PrintLabel(LoftwareServerIPAddress, LoftwareServerPort, intPrinterID, strLabelName, intSerializedLabels, intNumberOfCopies, dictParams, ref lngErrorNumber, ref strErrorDescription);
            }
            catch (Exception ex)
            {
                //Log entry to the log procedure
                Logger.Write(ex.ToString(), EventLogEntryType.Error, Logger.SeverityTypes.Error);
                throw ex;
            }
        }

        public List<clsRowPrintStatus> PrintBatchLabelHashtable(int intPrinterID, string strLabelName, int intSerializedLabels, int intNumberOfCopies, Hashtable htlParams)
        {
            //****************************************************************
            // Name : PrintBatchLabelHashtable
            // Description :  Prints Batch labels for a given hash tables 
            // Written By : Ananda
            // Date : 04/02/2019
            //****************************************************************

            long lngErrorNumber = 0;
            string strErrorDescription = "";

            //Create a loftware wrapper class
            clsPrintBatchLabels  objPrintLabel = new clsPrintBatchLabels();
            Logger.Write("Call to " + MethodBase.GetCurrentMethod().Name + " with the following parameters: LPS IP address/Host name = " + LoftwareServerIPAddress +
                     " port number = " + LoftwareServerPort.ToString() + "Printer ID = " + intPrinterID.ToString() + " Label name = " + strLabelName +
                     " serialized copies = " + intSerializedLabels.ToString() + " duplicates = " + intNumberOfCopies.ToString(), EventLogEntryType.Information, Logger.SeverityTypes.Information);

            try
            {
                return objPrintLabel.PrintLabel(LoftwareServerIPAddress, LoftwareServerPort, intPrinterID, strLabelName, intSerializedLabels, intNumberOfCopies, htlParams, ref lngErrorNumber, ref strErrorDescription);
            }
            catch (Exception ex)
            {
                //Log entry to the log procedure
                Logger.Write(ex.ToString(), EventLogEntryType.Error, Logger.SeverityTypes.Error);
                throw ex;
            }

        }

        public List<clsRowPrintStatus> PrintBatchLabelDatatable(int intPrinterID, string strLabelName, int intSerializedLabels, int intNumberOfCopies, System.Data.DataTable dtlParams)
        {
            //****************************************************************
            // Name : PrintBatchLabelDatatable
            // Description :  Prints Batch of labels for a given Datatable
            // Written By : Ananda
            // Date : 04/02/2019
            //****************************************************************
            long lngErrorNumber = 0;
            string strErrorDescription = "";

            //Create a Loftware wrapper class
            clsPrintBatchLabels  objPrintLabel = new clsPrintBatchLabels();

            //Log entry to the log procedure
            Logger.Write("Call to " + MethodBase.GetCurrentMethod().Name + " with the following parameters: LPS IP address/Host name = " + LoftwareServerIPAddress +
                         " port number = " + LoftwareServerPort.ToString() + "Printer ID = " + intPrinterID.ToString() + " Label name = " + strLabelName +
                         " serialized copies = " + intSerializedLabels.ToString() + " duplicates = " + intNumberOfCopies.ToString(), EventLogEntryType.Information, Logger.SeverityTypes.Information);

            try
            {
                return objPrintLabel.PrintLabel(LoftwareServerIPAddress, LoftwareServerPort, intPrinterID, strLabelName, intSerializedLabels, intNumberOfCopies, dtlParams, ref lngErrorNumber, ref strErrorDescription);
            }
            catch (Exception ex)
            {
                //Log entry to the log procedure
                Logger.Write(ex.ToString(), EventLogEntryType.Error, Logger.SeverityTypes.Error);
                throw ex;
            }
        }

        public List<clsRowPrintStatus> PrintBatchLabelDictionary(int intPrinterID, string strLabelName, int intSerializedLabels, int intNumberOfCopies, Dictionary<string, string> dictParams)
        {
            //****************************************************************
            // Name : PrintBatchLabelDictionary
            // Description :  Prints Batch of labels for a given Dictionary
            // Written By : Ananda
            // Date : 04/02/2019
            //****************************************************************

            long lngErrorNumber = 0;
            string strErrorDescription = "";

            //Create a Loftware wrapper class
            clsPrintBatchLabels  objPrintLabel = new clsPrintBatchLabels();

            //Log entry to the log procedure
            Logger.Write("Call to " + MethodBase.GetCurrentMethod().Name + " with the following parameters: LPS IP address/Host name = " + LoftwareServerIPAddress +
                         " port number = " + LoftwareServerPort.ToString() + "Printer ID = " + intPrinterID.ToString() + " Label name = " + strLabelName +
                         " serialized copies = " + intSerializedLabels.ToString() + " duplicates = " + intNumberOfCopies.ToString(), EventLogEntryType.Information, Logger.SeverityTypes.Information);

            try
            {
                return objPrintLabel.PrintLabel(LoftwareServerIPAddress, LoftwareServerPort, intPrinterID, strLabelName, intSerializedLabels, intNumberOfCopies, dictParams, ref lngErrorNumber, ref strErrorDescription);
            }
            catch (Exception ex)
            {
                //Log entry to the log procedure
                Logger.Write(ex.ToString(), EventLogEntryType.Error, Logger.SeverityTypes.Error);
                throw ex;
            }
        }

        public clsLoftwareServer.ServerStatusType GetServerStatus()
        {
            //****************************************************************
            // Name : GetServerStatus
            // Description : This function will test the server availibility and return its status
            // Written By : Sivachandran
            // Date : 17/06/2014
            //****************************************************************

            //Create a loftware object
            clsLoftwareServer objServer = new clsLoftwareServer();
            //Log entry to the log procedure
            Logger.Write("Call to " + MethodBase.GetCurrentMethod().Name, EventLogEntryType.Information, Logger.SeverityTypes.Information);

            try
            {
                //Check and return the server status
                return objServer.get_ServerStatus(LoftwareServerIPAddress, LoftwareServerPort);
            }
            catch (Exception ex)
            {
                //Log entry to the log procedure
                Logger.Write(ex.ToString(), EventLogEntryType.Error, Logger.SeverityTypes.Error);
                throw ex;
            }
        }


        public List<clsPrinter> GetPrintersList()
        {
            //****************************************************************
            // Name : GetPrintersList
            // Description : Function will return a list of printers from a given Loftware print server
            // Written By : Sivachandran
            // Date : 17/06/2014
            //****************************************************************

            //Create a Loftware print server wrapper object
            clsLoftwareServer objServer = new clsLoftwareServer();

            Logger.Write("Call to " + MethodBase.GetCurrentMethod().Name + " with the following parameters: LPS IP address/Host name = " + LoftwareServerIPAddress +
                         " port number = " + LoftwareServerPort.ToString(), EventLogEntryType.Information, Logger.SeverityTypes.Information);
            try
            {
                //Get and return the printers list
                return objServer.GetPrintersList(LoftwareServerIPAddress, LoftwareServerPort);
            }
            catch (Exception ex)
            {
                //Log entry to the log procedure
                Logger.Write(ex.ToString(), EventLogEntryType.Error, Logger.SeverityTypes.Error);
                throw ex;
            }
        }

        public List<string> GetLabelsList(string strFolderLocation)
        {
            //****************************************************************
            // Name : GetLabelsList
            // Description : Function will return a list of labels located in a given folder location on the given Loftware print server
            // Written By : Sivachandran
            // Date : 17/06/2014
            //****************************************************************

            //Create a Loftware print server wrapper object
            clsLoftwareServer objServer = new clsLoftwareServer();

            Logger.Write("Call to " + MethodBase.GetCurrentMethod().Name + " with the following parameters: LPS IP address/Host name = " + LoftwareServerIPAddress +
                     " port number = " + LoftwareServerPort.ToString() + " Folder Location="+ strFolderLocation, EventLogEntryType.Information, Logger.SeverityTypes.Information);

            try
            {
                //Get and return the printers list
                return objServer.GetLabelsList(LoftwareServerIPAddress, LoftwareServerPort, strFolderLocation);
            }
            catch (Exception ex)
            {
                //Log entry to the log procedure
                Logger.Write(ex.ToString(), EventLogEntryType.Error, Logger.SeverityTypes.Error);
                throw ex;
            }
        }

        public Dictionary<string, int> GetLabelFields(string strFolderName, string strLabelName)
        {
            //****************************************************************
            // Name : GetLabelFields
            // Description : Function will return a list of label fields for a given label name located under the given Loftware print server
            // Written By : Sivachandran
            // Date : 17/06/2014
            //****************************************************************


            //Create a Loftware print server wrapper object
            clsLoftwareServer objServer = new clsLoftwareServer();

            Logger.Write("Call to " + MethodBase.GetCurrentMethod().Name + " with the following parameters: " +
                        "LPS IP address/Host name = " + LoftwareServerIPAddress + " port number = " + LoftwareServerPort.ToString() +
                        "Folder name= " + strFolderName + "Label Name= " + strLabelName, EventLogEntryType.Information, Logger.SeverityTypes.Information);

            try
            {
                //Get and return the printers list
                return objServer.GetLabelFields(LoftwareServerIPAddress, LoftwareServerPort, strFolderName, strLabelName);
            }
            catch (Exception ex)
            {
                //Log entry to the log procedure
                Logger.Write(ex.ToString(), EventLogEntryType.Error, Logger.SeverityTypes.Error);
                throw ex;
            }
        }

    }
}
