using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Magma.WCF.Services.Opc.Tester
{
    public partial class Form1 : Form
    {
        private OPCTester_Service.OpcServiceClient OPCTest = new OPCTester_Service.OpcServiceClient("BasicHttpBinding_IOpcService");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ultraButton1.Enabled = false;

                string strProgID = TextCtrlProgID.Text.Trim();
                string strTagAddress = TextCtrlTagAddress.Text.Trim();

                bool blnReadDeviceOrCache = true;

                if (true == ReadDeviceOrCache.Checked)
                {
                    blnReadDeviceOrCache = true;
                }

                if (string.IsNullOrEmpty(strProgID))
                {
                    strProgID = null;
                }

                if (string.IsNullOrEmpty(strTagAddress))
                {
                    strTagAddress = null;
                    MessageBox.Show("Please Enter the Tag Address");
                    TextCtrlTagAddress.Focus();
                    ultraButton1.Enabled = true;
                    return;
                }

                string strResult = OPCTest.ReadSingleValue(strTagAddress, blnReadDeviceOrCache, strProgID).Value.ToString();

                ResultLabel.Text = TextCtrlTagAddress.Text + " <==> " + strResult;
                ErrorLabel.Text = "";

                ultraButton1.Enabled = true;

            }
            catch (Exception ex)
            {
                ResultLabel.Text = "";
                ErrorLabel.Text = ex.Message.ToString();

                ultraButton1.Enabled = true;
            }
        }

        private void btnWriteValues_Click(object sender, EventArgs e)
        {
            try
            {
                btnWriteValues.Enabled = false;

                string strProgID = TextCtrlProgID.Text.Trim();
                string strTagAddress = TextCtrlTagAddress.Text.Trim();


                if (string.IsNullOrEmpty(txtValue.Text))
                {
                    MessageBox.Show("Please Enter the value to write");
                    txtValue.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(strProgID))
                {
                    strProgID = null;
                }

                OPCTest.WriteSingleValue(strTagAddress, txtValue.Text, strProgID, false);

                ResultLabel.Text = "Tag Write Successfully = >" + strTagAddress + " <==> " + txtValue.Text;
                ErrorLabel.Text = "";

                btnWriteValues.Enabled = true;
            }
            catch (Exception ex)
            {
                ResultLabel.Text = "";
                ErrorLabel.Text = ex.Message.ToString();
                btnWriteValues.Enabled = true;
            }

        }

        private void ultraCheckEditor1_CheckedChanged(object sender, EventArgs e)
        {
            if (ultraCheckEditor1.Checked)
            {
                TextCtrlProgID.ReadOnly = true;
            }
            else
            {
                TextCtrlProgID.ReadOnly = false;
            }
        }
    }

}
