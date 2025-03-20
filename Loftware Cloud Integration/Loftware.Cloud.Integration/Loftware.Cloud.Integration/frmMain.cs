using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using IWIN = Infragistics.Win;
using IWUG = Infragistics.Win.UltraWinGrid;

namespace Loftware.Cloud.Integration
{
    public partial class frmTest : Form
    {
        clsCommon clsCommon = new clsCommon();

        DataTable dtuGridInputDetails = new DataTable();

        public frmTest()
        {
            InitializeComponent();
        }

        #region frmTest_Load
        private void FrmTest_Load(object sender, EventArgs e)
        {
            try
            {
                InitLoad();
                GetAppConfigDetails();
                UgInput_Bind();
            }
            catch (Exception ex)
            {
                LogErrorToTextBox(ex);
            }
        }
        #endregion

        #region InitLoad
        private void InitLoad()
        {
            try
            {
                dtuGridInputDetails = new DataTable();
                dtuGridInputDetails.Clear();
                dtuGridInputDetails.Columns.Add("Key", typeof(string));
                dtuGridInputDetails.Columns.Add("Value", typeof(string));
            }
            catch (Exception ex)
            {
                LogErrorToTextBox(ex);
            }
        }
        #endregion

        #region GetAppConfigDetails
        private void GetAppConfigDetails()
        {
            try
            {
                txtIPAddress.Text = clsCommon.ReadSingleConfigValue("Settings", "AppSettings", "strIpAddess");
                txtPort.Text = clsCommon.ReadSingleConfigValue("Settings", "AppSettings", "strPort");
                txtPrinterName.Text = clsCommon.ReadSingleConfigValue("Settings", "AppSettings", "strPrinterName");
                txtLabelName.Text = clsCommon.ReadSingleConfigValue("Settings", "AppSettings", "strLabelName");
                txtNumberOfCopies.Text = clsCommon.ReadSingleConfigValue("Settings", "AppSettings", "strNumberOfCopies");
                txtSerializedLabel.Text = clsCommon.ReadSingleConfigValue("Settings", "AppSettings", "strSerializedLabels");
                if ("1" == clsCommon.ReadSingleConfigValue("Settings", "AppSettings", "strXmlFileFormat"))
                {
                    rdbLoftwareLabel.Checked = true;
                }
                else
                {
                    rdbNiceLabel.Checked = true;
                }

                string[] strLabelInputKeyValue = clsCommon.ReadSingleConfigValue("Settings", "AppSettings", "strLabelInputKeyValue").Split(new string[] { "@@" }, StringSplitOptions.None);

                dtuGridInputDetails.Rows.Clear();
                foreach (string strKeyValue in strLabelInputKeyValue)
                {
                    if (string.IsNullOrEmpty(strKeyValue)) return;
                    string[] strKeyValueSplit = strKeyValue.Split(new string[] { "=" }, StringSplitOptions.None);
                    dtuGridInputDetails.Rows.Add(strKeyValueSplit[0], strKeyValueSplit[1]);
                }
            }
            catch (Exception ex)
            {
                LogErrorToTextBox(ex);
            }
        }
        #endregion

        #region SaveAppConfigDetails
        private void SaveAppConfigDetails()
        {
            try
            {
                clsCommon.SaveConfigSettingsValue("Settings", "AppSettings", "strIpAddess", txtIPAddress.Text);
                clsCommon.SaveConfigSettingsValue("Settings", "AppSettings", "strPort", txtPort.Text);
                clsCommon.SaveConfigSettingsValue("Settings", "AppSettings", "strPrinterName", txtPrinterName.Text);
                clsCommon.SaveConfigSettingsValue("Settings", "AppSettings", "strLabelName", txtLabelName.Text);
                clsCommon.SaveConfigSettingsValue("Settings", "AppSettings", "strNumberOfCopies", txtNumberOfCopies.Text);
                clsCommon.SaveConfigSettingsValue("Settings", "AppSettings", "strSerializedLabels", txtSerializedLabel.Text);
                clsCommon.SaveConfigSettingsValue("Settings", "AppSettings", "strXmlFileFormat", rdbLoftwareLabel.Checked ? "1" : "2");

                string strLabelInputKeyValue = string.Empty;
                foreach (var row in ugInput.Rows)
                {
                    strLabelInputKeyValue = string.Concat(strLabelInputKeyValue, row.Cells[0].Text + "=" + row.Cells[1].Text, "@@");
                }

                strLabelInputKeyValue = strLabelInputKeyValue.TrimEnd(new char[] { '@', '@' });

                clsCommon.SaveConfigSettingsValue("Settings", "AppSettings", "strLabelInputKeyValue", strLabelInputKeyValue);

            }
            catch (Exception ex)
            {
                LogErrorToTextBox(ex);
            }
        }
        #endregion

        #region UgInput_Bind
        private void UgInput_Bind()
        {
            try
            {
                ugInput.DataSource = dtuGridInputDetails;
                ugInput.DisplayLayout.AutoFitStyle = IWUG.AutoFitStyle.ResizeAllColumns;
                ugInput.DisplayLayout.Override.RowSelectors = IWIN.DefaultableBoolean.True;
                ugInput.DisplayLayout.Override.AllowAddNew = IWUG.AllowAddNew.TemplateOnTop;
                ugInput.DisplayLayout.Override.AllowDelete = IWIN.DefaultableBoolean.True;
                ugInput.DisplayLayout.Override.AddRowAppearance.BackColor = Color.White;
                ugInput.DisplayLayout.Override.ActiveAppearancesEnabled = IWIN.DefaultableBoolean.False;
                ugInput.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.Yellow;
                ugInput.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                LogErrorToTextBox(ex);
            }
        }
        #endregion

        #region PrintValidation
        public void PrintValidation()
        {
            try
            {
                if (string.IsNullOrEmpty(txtIPAddress.Text))
                {
                    MessageBox.Show("IP Address should not be empty", "Error");
                    txtIPAddress.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPort.Text))
                {
                    MessageBox.Show("Port should not be empty", "Error");
                    txtPort.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPrinterName.Text))
                {
                    MessageBox.Show("Printer Name should not be empty", "Error");
                    txtPrinterName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtLabelName.Text))
                {
                    MessageBox.Show("Label Name should not be empty", "Error");
                    txtLabelName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtNumberOfCopies.Text))
                {
                    MessageBox.Show("Number Of Copies should not be empty", "Error");
                    txtNumberOfCopies.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtSerializedLabel.Text))
                {
                    MessageBox.Show("Serialized Label should not be empty", "Error");
                    txtSerializedLabel.Focus();
                    return;
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region BtnTestPrint_Click
        private void BtnTestPrint_Click(object sender, EventArgs e)
        {
            try
            {
                rtxtSuccessMsg.Text = "";
                rtxtSuccessMsg.BackColor = Color.White;

                PrintValidation();
                SaveAppConfigDetails();

                clsLoftwareCloudPrint objclsLoftwareCloudPrint = new clsLoftwareCloudPrint(txtIPAddress.Text, Convert.ToInt32(txtPort.Text));

                Dictionary<string, string> dictDictionary = new Dictionary<string, string>();
                foreach (var row in ugInput.Rows)
                {
                    dictDictionary.Add(row.Cells[0].Text, row.Cells[1].Text);
                }

                int intStatus = objclsLoftwareCloudPrint.PrintBatchLabelDictionary(txtPrinterName.Text, txtLabelName.Text, int.Parse(txtSerializedLabel.Text), int.Parse(txtNumberOfCopies.Text), dictDictionary, (clsLoftwareCloudPrint.LPSXmlFileFormat)(rdbLoftwareLabel.Checked ? 1 : 2));

                rtxtSuccessMsg.Text = intStatus.ToString();
                rtxtSuccessMsg.BackColor = 4 == intStatus ? Color.Green : Color.Red;
                rtxtSuccessMsg.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                rtxtSuccessMsg.Text = "2";
                rtxtSuccessMsg.BackColor = Color.Red;
                rtxtSuccessMsg.ForeColor = Color.White;
                LogErrorToTextBox(ex);
            }
        }
        #endregion

        #region ugInput_InitializeLayout
        private void ugInput_InitializeLayout(object sender, IWUG.InitializeLayoutEventArgs e)
        {
            try
            {
                foreach (IWUG.UltraGridColumn col in ugInput.DisplayLayout.Bands[0].Columns)
                {
                    // Here we "turn off" theming for the column header.
                    col.Header.Appearance.ThemedElementAlpha = IWIN.Alpha.Transparent;
                    col.Header.Appearance.BackColor = Color.LightGray;
                    col.Header.Appearance.ForeColor = Color.Black;
                    col.Header.Appearance.FontData.Bold = IWIN.DefaultableBoolean.True;
                }
            }
            catch (Exception ex)
            {
                LogErrorToTextBox(ex);
            }
        }
        #endregion

        #region BtnClearOutput_Click
        private void BtnClearOutput_Click(object sender, EventArgs e)
        {
            rtxtSuccessMsg.Text = "";
            rtxtSuccessMsg.BackColor = Color.White;
        }
        #endregion

        #region BtnClearErrorMsg_Click
        private void BtnClearErrorMsg_Click(object sender, EventArgs e)
        {
            rtxtErrorsMsg.Text = "";
            rtxtErrorsMsg.ScrollBars = (RichTextBoxScrollBars)ScrollBars.None;
        }
        #endregion

        #region BtnClearInput_Click
        private void BtnClearInput_Click(object sender, EventArgs e)
        {
            try
            {
                dtuGridInputDetails.Rows.Clear();
                UgInput_Bind();
            }
            catch (Exception ex)
            {
                LogErrorToTextBox(ex);
            }
        }
        #endregion

        #region TextBoxNumericValidation
        private void TextBoxNumericValidation(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion

        #region LogErrorToTextBox
        private void LogErrorToTextBox(Exception exception)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                stringBuilder.AppendLine("|***** Message Start *****|");
                stringBuilder.AppendLine(exception.ToString());
                stringBuilder.AppendLine("|***** Message End *****|");
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.AppendLine(rtxtErrorsMsg.Text);
                rtxtErrorsMsg.Text = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                stringBuilder.AppendLine("|***** Message Start *****|");
                stringBuilder.AppendLine(ex.ToString());
                stringBuilder.AppendLine("|***** Message End *****|");
                stringBuilder.Append(Environment.NewLine);
                rtxtErrorsMsg.Text = stringBuilder.ToString();
            }
        }
        #endregion
    }
}
