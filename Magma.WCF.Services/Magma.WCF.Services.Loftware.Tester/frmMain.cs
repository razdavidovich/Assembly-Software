using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.ServiceModel;
using Magma.WCF.Services.Logging;
using Magma.WCF.Services.Loftware.Tester.LoftwareService;

namespace Magma.WCF.Services.Loftware.Tester
{
    public partial class frmMain : Form
    {
        LoftwareServiceClient objLoftwareClient;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPrintLabelHashTable_Click(object sender, EventArgs e)
        {
            try
            {
                lstResponse.Items.Add("PrintLabelHashTable Request..");

                objLoftwareClient = new LoftwareServiceClient(new NetTcpBinding(), new EndpointAddress(txtAddress.Text));

                int intPrinterID = Convert.ToInt32(txtPrinter.Text);
                string strLabelName = txtLabel.Text;
                int intSerializedLabels = Convert.ToInt32(txtSerialized.Text) ;
                int intNumberOfCopies = Convert.ToInt32(txtCopies.Text);
                Dictionary<object, object> htlParams = GenerateHashtable();
                List<clsRowPrintStatus> lstReturnedStatus = null;

                lstReturnedStatus = objLoftwareClient.PrintLabelHashtable(intPrinterID, strLabelName,intSerializedLabels, intNumberOfCopies, htlParams).ToList<clsRowPrintStatus>();

                if (lstReturnedStatus.Count > 0)
                {
                    lstResponse.Items.Add("Response: ");
                    foreach (var objResponse in lstReturnedStatus)
                    {
                        string strResponse = "Printed Job Status : " + objResponse.PrintedJobStatus;
                        lstResponse.Items.Add(strResponse);
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }

        private void btnPrintLabelDatatable_Click(object sender, EventArgs e)
        {
            objLoftwareClient = new LoftwareServiceClient(new NetTcpBinding(), new EndpointAddress(txtAddress.Text));

            lstResponse.Items.Add("PrintLabelDatatable Request Send..");

            int intPrinterID = Convert.ToInt32(txtPrinter.Text);
            string strLabelName = txtLabel.Text;
            int intSerializedLabels = Convert.ToInt32(txtSerialized.Text);
            int intNumberOfCopies = Convert.ToInt32(txtCopies.Text);
            DataTable dtlParams = GenerateDataTable();
            List<clsRowPrintStatus> lstReturnedStatus = null;

            lstReturnedStatus = objLoftwareClient.PrintLabelDatatable(intPrinterID, strLabelName,intSerializedLabels, intNumberOfCopies, dtlParams).ToList<clsRowPrintStatus>();
            if (lstReturnedStatus.Count > 0)
            {
                lstResponse.Items.Add("Response: ");
                foreach (var objResponse in lstReturnedStatus)
                {
                    string strResponse = "Printed Job Status : " + objResponse.PrintedJobStatus;
                    lstResponse.Items.Add(strResponse);
                }
            }
        }

        private void btnPrintLabelDictionary_Click(object sender, EventArgs e)
        {
            objLoftwareClient = new LoftwareServiceClient(new NetTcpBinding(), new EndpointAddress(txtAddress.Text));

            lstResponse.Items.Add("PrintLabelDictionary Request Send..");

            int intPrinterID = Convert.ToInt32(txtPrinter.Text);
            string strLabelName = txtLabel.Text;
            int intSerializedLabels = Convert.ToInt32(txtSerialized.Text);
            int intNumberOfCopies = Convert.ToInt32(txtCopies.Text);
            Dictionary<string, string> dictParams = GenerateDictionary();
            List<clsRowPrintStatus> lstReturnedStatus = null;
            
            lstReturnedStatus = objLoftwareClient.PrintLabelDictionary(intPrinterID, strLabelName,intSerializedLabels, intNumberOfCopies, dictParams).ToList<clsRowPrintStatus>();
           
            if (lstReturnedStatus.Count > 0)
            {

                lstResponse.Items.Add("Response: ");

                foreach (var objResponse in lstReturnedStatus)
                {
                    string strResponse = "Printed Job Status : " + objResponse.PrintedJobStatus;
                    lstResponse.Items.Add(strResponse);
                }
            }
        }
       
     
        private void btnServerStatus_Click(object sender, EventArgs e)
        {
            try
            {
                objLoftwareClient = new LoftwareServiceClient(new NetTcpBinding(), new EndpointAddress(txtAddress.Text));

                clsLoftwareServerServerStatusType objServerStatusType;
                lstResponse.Items.Add("GetServerStatus Request Send..");

                objServerStatusType = objLoftwareClient.GetServerStatus();
                lstResponse.Items.Add("Response: ");
                lstResponse.Items.Add(objServerStatusType);

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }
        private void btnPrintersList_Click(object sender, EventArgs e)
        {
            try
            {
                List<clsPrinter> lstPrinters = null;
                objLoftwareClient = new LoftwareServiceClient(new NetTcpBinding(), new EndpointAddress(txtAddress.Text));

                lstResponse.Items.Add("GetPrintersList Request Send..");

                lstPrinters = objLoftwareClient.GetPrintersList().ToList<clsPrinter>();

                if (lstPrinters.Count > 1)
                {
                    lstResponse.Items.Add("Response: ");
                    foreach(var item in lstPrinters)
                    {
                        string strResponse = string.Format("PRINTER NAME : {0}, PRINTER NUMBER : {1}, PRINTER ALIAS : {2} ", item.PrinterName, item.PrinterNumber, item.PrinterAlias);
                        lstResponse.Items.Add(strResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        private void btnLabelList_Click(object sender, EventArgs e)
        {
            try
            {

                string strFolderLocation = txtFolderLocation.Text;
                objLoftwareClient = new LoftwareServiceClient(new NetTcpBinding(), new EndpointAddress(txtAddress.Text));

                lstResponse.Items.Add("GetLabelsList Request Send..");
                List<string> lstString =  objLoftwareClient.GetLabelsList(strFolderLocation).ToList<string>();

                if (lstString.Count > 1)
                {
                    lstResponse.Items.Add("Response: ");
                    foreach (var item in lstString)
                    {
                        string strResponse = string.Format("LABEL NAME : {0}", item);
                        lstResponse.Items.Add(strResponse);
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

        private void btnLabelFields_Click(object sender, EventArgs e)
        {
            try
            {
                string strFolderName = "";
                string strLabelName = txtLabel.Text; //"UnitTestLabel.lwl"
                objLoftwareClient = new LoftwareServiceClient(new NetTcpBinding(), new EndpointAddress(txtAddress.Text));

                lstResponse.Items.Add("GetLabelFields Request Send..");

                Dictionary<string, int> dictLabelFields  =   objLoftwareClient.GetLabelFields(strFolderName, strLabelName);

                if (dictLabelFields.Count > 1)
                {
                    lstResponse.Items.Add("Response: ");
                    foreach(var item in dictLabelFields )
                    {
                        lstResponse.Items.Add("FIELD: " + item.Key + ", VALUE: " + item.Value);
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }
      

        #region private methods

        private Dictionary<string, string> GenerateDictionary()
        {
            Dictionary<string, string> dictDictionary = new Dictionary<string, string>();

            dictDictionary.Add("TO_ADDRESS_1", "Test Address");
            dictDictionary.Add("TO_CITY", "Test City");
            dictDictionary.Add("TO_STATE", "Test State");

            return dictDictionary;
        }

        private Dictionary<object, object> GenerateHashtable()
        {
            Dictionary<object, object> htlHashtable = new Dictionary<object, object>();

            htlHashtable.Add("TO_ADDRESS_1", "Test Address");
            htlHashtable.Add("TO_CITY", "Test City");
            htlHashtable.Add("TO_STATE", "Test State");

            return htlHashtable;
        }

        private DataTable GenerateDataTable()
        {
            // Create new datatable
            DataTable dtlDataTable = new DataTable();

            dtlDataTable.TableName = "Printing Data";

            //Create columns
            dtlDataTable.Columns.Add("TO_ADDRESS_1", Type.GetType("System.String"));
            dtlDataTable.Columns.Add("TO_CITY", Type.GetType("System.String"));
            dtlDataTable.Columns.Add("TO_STATE", Type.GetType("System.String"));

            // Declare row
            DataRow dtrRow;

            // create new row
            dtrRow = dtlDataTable.NewRow();
            dtrRow["TO_ADDRESS_1"] = "Test Address 1";
            dtrRow["TO_CITY"] = "Test City 1";
            dtrRow["TO_STATE"] = "Test State 1";
            dtlDataTable.Rows.Add(dtrRow);

            // create new row
            dtrRow = dtlDataTable.NewRow();
            dtrRow["TO_ADDRESS_1"] = "Test Address 2";
            dtrRow["TO_CITY"] = "Test City 2";
            dtrRow["TO_STATE"] = "Test State 2";
            dtlDataTable.Rows.Add(dtrRow);


            // return the datatable filled with 2 columns and 1 rows
            return dtlDataTable;
        }

        #endregion

       
    }
}
