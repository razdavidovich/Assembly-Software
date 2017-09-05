namespace Magma.WCF.Services.Loftware.Tester
{
    partial class frmMain
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
            this.btnPrintLabelDictionary = new System.Windows.Forms.Button();
            this.btnPrintLabelDatatable = new System.Windows.Forms.Button();
            this.btnPrintLabelHashTable = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtSerialized = new System.Windows.Forms.TextBox();
            this.txtCopies = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Copies = new System.Windows.Forms.Label();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstResponse = new System.Windows.Forms.ListBox();
            this.btnServerStatus = new System.Windows.Forms.Button();
            this.btnPrintersList = new System.Windows.Forms.Button();
            this.btnLabelList = new System.Windows.Forms.Button();
            this.btnLabelFields = new System.Windows.Forms.Button();
            this.txtFolderLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrintLabelDictionary
            // 
            this.btnPrintLabelDictionary.Location = new System.Drawing.Point(318, 197);
            this.btnPrintLabelDictionary.Name = "btnPrintLabelDictionary";
            this.btnPrintLabelDictionary.Size = new System.Drawing.Size(106, 44);
            this.btnPrintLabelDictionary.TabIndex = 0;
            this.btnPrintLabelDictionary.Text = "Print Label From Dictionary";
            this.btnPrintLabelDictionary.UseVisualStyleBackColor = true;
            this.btnPrintLabelDictionary.Click += new System.EventHandler(this.btnPrintLabelDictionary_Click);
            // 
            // btnPrintLabelDatatable
            // 
            this.btnPrintLabelDatatable.Location = new System.Drawing.Point(170, 197);
            this.btnPrintLabelDatatable.Name = "btnPrintLabelDatatable";
            this.btnPrintLabelDatatable.Size = new System.Drawing.Size(106, 44);
            this.btnPrintLabelDatatable.TabIndex = 1;
            this.btnPrintLabelDatatable.Text = "Print Label From DataTable";
            this.btnPrintLabelDatatable.UseVisualStyleBackColor = true;
            this.btnPrintLabelDatatable.Click += new System.EventHandler(this.btnPrintLabelDatatable_Click);
            // 
            // btnPrintLabelHashTable
            // 
            this.btnPrintLabelHashTable.Location = new System.Drawing.Point(24, 197);
            this.btnPrintLabelHashTable.Name = "btnPrintLabelHashTable";
            this.btnPrintLabelHashTable.Size = new System.Drawing.Size(106, 44);
            this.btnPrintLabelHashTable.TabIndex = 2;
            this.btnPrintLabelHashTable.Text = "Print Label From HashTable";
            this.btnPrintLabelHashTable.UseVisualStyleBackColor = true;
            this.btnPrintLabelHashTable.Click += new System.EventHandler(this.btnPrintLabelHashTable_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(445, 12);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(530, 20);
            this.txtAddress.TabIndex = 23;
            this.txtAddress.Text = "net.tcp://localhost:8724/Runtime/Magma.WCF.Services.Loftware/LoftwareService/";
            // 
            // txtSerialized
            // 
            this.txtSerialized.Location = new System.Drawing.Point(90, 116);
            this.txtSerialized.Name = "txtSerialized";
            this.txtSerialized.Size = new System.Drawing.Size(64, 20);
            this.txtSerialized.TabIndex = 22;
            this.txtSerialized.Text = "2";
            // 
            // txtCopies
            // 
            this.txtCopies.Location = new System.Drawing.Point(90, 80);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(64, 20);
            this.txtCopies.TabIndex = 21;
            this.txtCopies.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Serialized:";
            // 
            // Copies
            // 
            this.Copies.AutoSize = true;
            this.Copies.Location = new System.Drawing.Point(20, 80);
            this.Copies.Name = "Copies";
            this.Copies.Size = new System.Drawing.Size(42, 13);
            this.Copies.TabIndex = 19;
            this.Copies.Text = "Copies:";
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(90, 44);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(286, 20);
            this.txtPrinter.TabIndex = 18;
            this.txtPrinter.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Printer:";
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(90, 12);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(286, 20);
            this.txtLabel.TabIndex = 16;
            this.txtLabel.Text = "SAMPLE_GM.LWL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Label Name";
            // 
            // lstResponse
            // 
            this.lstResponse.FormattingEnabled = true;
            this.lstResponse.Location = new System.Drawing.Point(23, 284);
            this.lstResponse.Name = "lstResponse";
            this.lstResponse.Size = new System.Drawing.Size(952, 264);
            this.lstResponse.TabIndex = 24;
            // 
            // btnServerStatus
            // 
            this.btnServerStatus.Location = new System.Drawing.Point(464, 197);
            this.btnServerStatus.Name = "btnServerStatus";
            this.btnServerStatus.Size = new System.Drawing.Size(106, 44);
            this.btnServerStatus.TabIndex = 25;
            this.btnServerStatus.Text = "Get Server Status";
            this.btnServerStatus.UseVisualStyleBackColor = true;
            this.btnServerStatus.Click += new System.EventHandler(this.btnServerStatus_Click);
            // 
            // btnPrintersList
            // 
            this.btnPrintersList.Location = new System.Drawing.Point(601, 197);
            this.btnPrintersList.Name = "btnPrintersList";
            this.btnPrintersList.Size = new System.Drawing.Size(106, 44);
            this.btnPrintersList.TabIndex = 26;
            this.btnPrintersList.Text = "Printers List";
            this.btnPrintersList.UseVisualStyleBackColor = true;
            this.btnPrintersList.Click += new System.EventHandler(this.btnPrintersList_Click);
            // 
            // btnLabelList
            // 
            this.btnLabelList.Location = new System.Drawing.Point(731, 197);
            this.btnLabelList.Name = "btnLabelList";
            this.btnLabelList.Size = new System.Drawing.Size(106, 44);
            this.btnLabelList.TabIndex = 27;
            this.btnLabelList.Text = "Labels List";
            this.btnLabelList.UseVisualStyleBackColor = true;
            this.btnLabelList.Click += new System.EventHandler(this.btnLabelList_Click);
            // 
            // btnLabelFields
            // 
            this.btnLabelFields.Location = new System.Drawing.Point(869, 197);
            this.btnLabelFields.Name = "btnLabelFields";
            this.btnLabelFields.Size = new System.Drawing.Size(106, 44);
            this.btnLabelFields.TabIndex = 28;
            this.btnLabelFields.Text = "Label Fields";
            this.btnLabelFields.UseVisualStyleBackColor = true;
            this.btnLabelFields.Click += new System.EventHandler(this.btnLabelFields_Click);
            // 
            // txtFolderLocation
            // 
            this.txtFolderLocation.Location = new System.Drawing.Point(90, 151);
            this.txtFolderLocation.Name = "txtFolderLocation";
            this.txtFolderLocation.Size = new System.Drawing.Size(286, 20);
            this.txtFolderLocation.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Label Folder:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 560);
            this.Controls.Add(this.txtFolderLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLabelFields);
            this.Controls.Add(this.btnLabelList);
            this.Controls.Add(this.btnPrintersList);
            this.Controls.Add(this.btnServerStatus);
            this.Controls.Add(this.lstResponse);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtSerialized);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Copies);
            this.Controls.Add(this.txtPrinter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrintLabelHashTable);
            this.Controls.Add(this.btnPrintLabelDatatable);
            this.Controls.Add(this.btnPrintLabelDictionary);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintLabelDictionary;
        private System.Windows.Forms.Button btnPrintLabelDatatable;
        private System.Windows.Forms.Button btnPrintLabelHashTable;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtSerialized;
        private System.Windows.Forms.TextBox txtCopies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Copies;
        private System.Windows.Forms.TextBox txtPrinter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstResponse;
        private System.Windows.Forms.Button btnServerStatus;
        private System.Windows.Forms.Button btnPrintersList;
        private System.Windows.Forms.Button btnLabelList;
        private System.Windows.Forms.Button btnLabelFields;
        private System.Windows.Forms.TextBox txtFolderLocation;
        private System.Windows.Forms.Label label4;
    }
}

