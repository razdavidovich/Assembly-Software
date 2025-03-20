namespace Loftware.Cloud.Integration
{
    partial class frmTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.btnTestPrint = new System.Windows.Forms.Button();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.rtxtErrorsMsg = new System.Windows.Forms.RichTextBox();
            this.rtxtSuccessMsg = new System.Windows.Forms.RichTextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnClearErrorMsg = new System.Windows.Forms.Button();
            this.lblSuccessMsg = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.txtPrinterName = new System.Windows.Forms.TextBox();
            this.txtLabelName = new System.Windows.Forms.TextBox();
            this.lblLabelName = new System.Windows.Forms.Label();
            this.txtNumberOfCopies = new System.Windows.Forms.TextBox();
            this.lblNumberOfCopies = new System.Windows.Forms.Label();
            this.txtSerializedLabel = new System.Windows.Forms.TextBox();
            this.lblSerializedLabels = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.ugInput = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnClearInput = new System.Windows.Forms.Button();
            this.ttForLabelName = new System.Windows.Forms.ToolTip(this.components);
            this.rdbNiceLabel = new System.Windows.Forms.RadioButton();
            this.rdbLoftwareLabel = new System.Windows.Forms.RadioButton();
            this.grpXMLFileTypeRDB = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ugInput)).BeginInit();
            this.grpXMLFileTypeRDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTestPrint
            // 
            this.btnTestPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestPrint.Location = new System.Drawing.Point(313, 319);
            this.btnTestPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestPrint.Name = "btnTestPrint";
            this.btnTestPrint.Size = new System.Drawing.Size(138, 35);
            this.btnTestPrint.TabIndex = 0;
            this.btnTestPrint.Text = "Test Print Command";
            this.btnTestPrint.UseVisualStyleBackColor = true;
            this.btnTestPrint.Click += new System.EventHandler(this.BtnTestPrint_Click);
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(86, 10);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(140, 22);
            this.txtIPAddress.TabIndex = 1;
            this.txtIPAddress.Text = "127.0.0.1";
            // 
            // rtxtErrorsMsg
            // 
            this.rtxtErrorsMsg.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtErrorsMsg.Location = new System.Drawing.Point(8, 435);
            this.rtxtErrorsMsg.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtErrorsMsg.Name = "rtxtErrorsMsg";
            this.rtxtErrorsMsg.ReadOnly = true;
            this.rtxtErrorsMsg.Size = new System.Drawing.Size(765, 215);
            this.rtxtErrorsMsg.TabIndex = 2;
            this.rtxtErrorsMsg.Text = "";
            // 
            // rtxtSuccessMsg
            // 
            this.rtxtSuccessMsg.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtSuccessMsg.Location = new System.Drawing.Point(8, 362);
            this.rtxtSuccessMsg.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtSuccessMsg.Name = "rtxtSuccessMsg";
            this.rtxtSuccessMsg.ReadOnly = true;
            this.rtxtSuccessMsg.Size = new System.Drawing.Size(644, 31);
            this.rtxtSuccessMsg.TabIndex = 3;
            this.rtxtSuccessMsg.Text = "";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(5, 412);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(297, 16);
            this.lblError.TabIndex = 4;
            this.lblError.Text = "Error Message (Start (or) Top message is newer)";
            // 
            // btnClearErrorMsg
            // 
            this.btnClearErrorMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearErrorMsg.Location = new System.Drawing.Point(657, 399);
            this.btnClearErrorMsg.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearErrorMsg.Name = "btnClearErrorMsg";
            this.btnClearErrorMsg.Size = new System.Drawing.Size(116, 35);
            this.btnClearErrorMsg.TabIndex = 5;
            this.btnClearErrorMsg.Text = "Clear Error Msg";
            this.btnClearErrorMsg.UseVisualStyleBackColor = true;
            this.btnClearErrorMsg.Click += new System.EventHandler(this.BtnClearErrorMsg_Click);
            // 
            // lblSuccessMsg
            // 
            this.lblSuccessMsg.AutoSize = true;
            this.lblSuccessMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccessMsg.Location = new System.Drawing.Point(5, 342);
            this.lblSuccessMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuccessMsg.Name = "lblSuccessMsg";
            this.lblSuccessMsg.Size = new System.Drawing.Size(45, 16);
            this.lblSuccessMsg.TabIndex = 6;
            this.lblSuccessMsg.Text = "Output";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(273, 10);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(145, 22);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "2723";
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumericValidation);
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearOutput.Location = new System.Drawing.Point(657, 359);
            this.btnClearOutput.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(116, 35);
            this.btnClearOutput.TabIndex = 8;
            this.btnClearOutput.Text = "Clear Output";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.BtnClearOutput_Click);
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddress.Location = new System.Drawing.Point(5, 13);
            this.lblIpAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(73, 16);
            this.lblIpAddress.TabIndex = 9;
            this.lblIpAddress.Text = "IP Address";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(234, 13);
            this.lblPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(31, 16);
            this.lblPort.TabIndex = 10;
            this.lblPort.Text = "Port";
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.AutoSize = true;
            this.lblPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinterName.Location = new System.Drawing.Point(438, 13);
            this.lblPrinterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.Size = new System.Drawing.Size(85, 16);
            this.lblPrinterName.TabIndex = 11;
            this.lblPrinterName.Text = "Printer Name";
            // 
            // txtPrinterName
            // 
            this.txtPrinterName.Location = new System.Drawing.Point(531, 10);
            this.txtPrinterName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrinterName.Name = "txtPrinterName";
            this.txtPrinterName.Size = new System.Drawing.Size(242, 22);
            this.txtPrinterName.TabIndex = 12;
            this.txtPrinterName.Text = "Printer Name";
            // 
            // txtLabelName
            // 
            this.txtLabelName.Location = new System.Drawing.Point(94, 40);
            this.txtLabelName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLabelName.Name = "txtLabelName";
            this.txtLabelName.Size = new System.Drawing.Size(429, 22);
            this.txtLabelName.TabIndex = 14;
            this.txtLabelName.Text = "Label Name (or) Full Path";
            this.ttForLabelName.SetToolTip(this.txtLabelName, "Label Name (or) Full Path");
            // 
            // lblLabelName
            // 
            this.lblLabelName.AutoSize = true;
            this.lblLabelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelName.Location = new System.Drawing.Point(5, 43);
            this.lblLabelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLabelName.Name = "lblLabelName";
            this.lblLabelName.Size = new System.Drawing.Size(81, 16);
            this.lblLabelName.TabIndex = 13;
            this.lblLabelName.Text = "Label Name";
            this.ttForLabelName.SetToolTip(this.lblLabelName, "Label Name (or) Full Path");
            // 
            // txtNumberOfCopies
            // 
            this.txtNumberOfCopies.Location = new System.Drawing.Point(130, 70);
            this.txtNumberOfCopies.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumberOfCopies.Name = "txtNumberOfCopies";
            this.txtNumberOfCopies.Size = new System.Drawing.Size(45, 22);
            this.txtNumberOfCopies.TabIndex = 16;
            this.txtNumberOfCopies.Text = "0";
            this.txtNumberOfCopies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumericValidation);
            // 
            // lblNumberOfCopies
            // 
            this.lblNumberOfCopies.AutoSize = true;
            this.lblNumberOfCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfCopies.Location = new System.Drawing.Point(5, 73);
            this.lblNumberOfCopies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumberOfCopies.Name = "lblNumberOfCopies";
            this.lblNumberOfCopies.Size = new System.Drawing.Size(117, 16);
            this.lblNumberOfCopies.TabIndex = 15;
            this.lblNumberOfCopies.Text = "Number Of Copies";
            // 
            // txtSerializedLabel
            // 
            this.txtSerializedLabel.Location = new System.Drawing.Point(306, 70);
            this.txtSerializedLabel.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerializedLabel.Name = "txtSerializedLabel";
            this.txtSerializedLabel.Size = new System.Drawing.Size(45, 22);
            this.txtSerializedLabel.TabIndex = 18;
            this.txtSerializedLabel.Text = "0";
            this.txtSerializedLabel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumericValidation);
            // 
            // lblSerializedLabels
            // 
            this.lblSerializedLabels.AutoSize = true;
            this.lblSerializedLabels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerializedLabels.Location = new System.Drawing.Point(187, 73);
            this.lblSerializedLabels.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSerializedLabels.Name = "lblSerializedLabels";
            this.lblSerializedLabels.Size = new System.Drawing.Size(110, 16);
            this.lblSerializedLabels.TabIndex = 17;
            this.lblSerializedLabels.Text = "Duplicate Copies";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.Location = new System.Drawing.Point(5, 98);
            this.lblInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(74, 16);
            this.lblInput.TabIndex = 20;
            this.lblInput.Text = "Input Table";
            // 
            // ugInput
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.ugInput.DisplayLayout.AddNewBox.Appearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.White;
            this.ugInput.DisplayLayout.Appearance = appearance2;
            this.ugInput.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugInput.Location = new System.Drawing.Point(8, 120);
            this.ugInput.Name = "ugInput";
            this.ugInput.Size = new System.Drawing.Size(765, 193);
            this.ugInput.TabIndex = 21;
            this.ugInput.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugInput_InitializeLayout);
            // 
            // btnClearInput
            // 
            this.btnClearInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearInput.Location = new System.Drawing.Point(657, 319);
            this.btnClearInput.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearInput.Name = "btnClearInput";
            this.btnClearInput.Size = new System.Drawing.Size(116, 35);
            this.btnClearInput.TabIndex = 22;
            this.btnClearInput.Text = "Clear Input";
            this.btnClearInput.UseVisualStyleBackColor = true;
            this.btnClearInput.Click += new System.EventHandler(this.BtnClearInput_Click);
            // 
            // rdbNiceLabel
            // 
            this.rdbNiceLabel.AutoSize = true;
            this.rdbNiceLabel.Location = new System.Drawing.Point(102, 17);
            this.rdbNiceLabel.Name = "rdbNiceLabel";
            this.rdbNiceLabel.Size = new System.Drawing.Size(90, 20);
            this.rdbNiceLabel.TabIndex = 23;
            this.rdbNiceLabel.TabStop = true;
            this.rdbNiceLabel.Text = "Nice Label";
            this.rdbNiceLabel.UseVisualStyleBackColor = true;
            // 
            // rdbLoftwareLabel
            // 
            this.rdbLoftwareLabel.AutoSize = true;
            this.rdbLoftwareLabel.Location = new System.Drawing.Point(9, 17);
            this.rdbLoftwareLabel.Name = "rdbLoftwareLabel";
            this.rdbLoftwareLabel.Size = new System.Drawing.Size(75, 20);
            this.rdbLoftwareLabel.TabIndex = 24;
            this.rdbLoftwareLabel.TabStop = true;
            this.rdbLoftwareLabel.Text = "Loftware";
            this.rdbLoftwareLabel.UseVisualStyleBackColor = true;
            // 
            // grpXMLFileTypeRDB
            // 
            this.grpXMLFileTypeRDB.Controls.Add(this.rdbLoftwareLabel);
            this.grpXMLFileTypeRDB.Controls.Add(this.rdbNiceLabel);
            this.grpXMLFileTypeRDB.Location = new System.Drawing.Point(531, 40);
            this.grpXMLFileTypeRDB.Name = "grpXMLFileTypeRDB";
            this.grpXMLFileTypeRDB.Size = new System.Drawing.Size(241, 52);
            this.grpXMLFileTypeRDB.TabIndex = 25;
            this.grpXMLFileTypeRDB.TabStop = false;
            this.grpXMLFileTypeRDB.Text = "XML File Type";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.grpXMLFileTypeRDB);
            this.Controls.Add(this.btnClearInput);
            this.Controls.Add(this.ugInput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtSerializedLabel);
            this.Controls.Add(this.lblSerializedLabels);
            this.Controls.Add(this.txtNumberOfCopies);
            this.Controls.Add(this.lblNumberOfCopies);
            this.Controls.Add(this.txtLabelName);
            this.Controls.Add(this.lblLabelName);
            this.Controls.Add(this.txtPrinterName);
            this.Controls.Add(this.lblPrinterName);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIpAddress);
            this.Controls.Add(this.btnClearOutput);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblSuccessMsg);
            this.Controls.Add(this.btnClearErrorMsg);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.rtxtSuccessMsg);
            this.Controls.Add(this.rtxtErrorsMsg);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.btnTestPrint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmTest";
            this.Text = "Test Printing Form";
            this.Load += new System.EventHandler(this.FrmTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ugInput)).EndInit();
            this.grpXMLFileTypeRDB.ResumeLayout(false);
            this.grpXMLFileTypeRDB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestPrint;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.RichTextBox rtxtErrorsMsg;
        private System.Windows.Forms.RichTextBox rtxtSuccessMsg;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnClearErrorMsg;
        private System.Windows.Forms.Label lblSuccessMsg;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblPrinterName;
        private System.Windows.Forms.TextBox txtPrinterName;
        private System.Windows.Forms.TextBox txtLabelName;
        private System.Windows.Forms.Label lblLabelName;
        private System.Windows.Forms.TextBox txtNumberOfCopies;
        private System.Windows.Forms.Label lblNumberOfCopies;
        private System.Windows.Forms.TextBox txtSerializedLabel;
        private System.Windows.Forms.Label lblSerializedLabels;
        private System.Windows.Forms.Label lblInput;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugInput;
        private System.Windows.Forms.Button btnClearInput;
        private System.Windows.Forms.ToolTip ttForLabelName;
        private System.Windows.Forms.RadioButton rdbNiceLabel;
        private System.Windows.Forms.RadioButton rdbLoftwareLabel;
        private System.Windows.Forms.GroupBox grpXMLFileTypeRDB;
    }
}

