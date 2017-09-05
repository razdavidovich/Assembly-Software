using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Assembly.Software.Loftware;


namespace Magma.WCF.Services.Loftware

{
    [ServiceContract]
    public interface ILoftwareService
    { 
        [OperationContract]
        List<clsRowPrintStatus>  PrintLabelHashtable(int intPrinterID,string strLabelName,int intSerializedLabels,int intNumberOfCopies, Hashtable htlParams );

        [OperationContract]
        List<clsRowPrintStatus>  PrintLabelDatatable(int intPrinterID,string strLabelName,int intSerializedLabels,int intNumberOfCopies, DataTable  dtlParams);

        [OperationContract]
        List<clsRowPrintStatus>  PrintLabelDictionary(int intPrinterID,string strLabelName,int intSerializedLabels,int intNumberOfCopies, Dictionary<string,string>  dictParams);

        [OperationContract]
        clsLoftwareServer.ServerStatusType GetServerStatus();

        [OperationContract]
        List<clsPrinter> GetPrintersList();

        [OperationContract]
        List<string> GetLabelsList(string strFolderLocation);

        [OperationContract]
        Dictionary<string, int> GetLabelFields(string strFolderName, string strLabelName);
    }
}
