namespace Magma.WCF.Services.Opc.Tester
{
    partial class Form1
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ReadCacheOrDevice = new System.Windows.Forms.RadioButton();
            this.ReadDeviceOrCache = new System.Windows.Forms.RadioButton();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtValue = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.TextCtrlProgID = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.TextCtrlTagAddress = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnWriteValues = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ErrorLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ResultLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraCheckEditor1 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextCtrlProgID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextCtrlTagAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCheckEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(28, 19);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(196, 28);
            this.ultraLabel1.TabIndex = 4;
            this.ultraLabel1.Text = "Read Device Or Cache";
            // 
            // ReadCacheOrDevice
            // 
            this.ReadCacheOrDevice.AutoSize = true;
            this.ReadCacheOrDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadCacheOrDevice.Location = new System.Drawing.Point(356, 19);
            this.ReadCacheOrDevice.Margin = new System.Windows.Forms.Padding(4);
            this.ReadCacheOrDevice.Name = "ReadCacheOrDevice";
            this.ReadCacheOrDevice.Size = new System.Drawing.Size(71, 21);
            this.ReadCacheOrDevice.TabIndex = 2;
            this.ReadCacheOrDevice.Text = "Cache";
            this.ReadCacheOrDevice.UseVisualStyleBackColor = true;
            // 
            // ReadDeviceOrCache
            // 
            this.ReadDeviceOrCache.AutoSize = true;
            this.ReadDeviceOrCache.Checked = true;
            this.ReadDeviceOrCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadDeviceOrCache.Location = new System.Drawing.Point(258, 19);
            this.ReadDeviceOrCache.Margin = new System.Windows.Forms.Padding(4);
            this.ReadDeviceOrCache.Name = "ReadDeviceOrCache";
            this.ReadDeviceOrCache.Size = new System.Drawing.Size(75, 21);
            this.ReadDeviceOrCache.TabIndex = 3;
            this.ReadDeviceOrCache.TabStop = true;
            this.ReadDeviceOrCache.Text = "Device";
            this.ReadDeviceOrCache.UseVisualStyleBackColor = true;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel6.Location = new System.Drawing.Point(28, 162);
            this.ultraLabel6.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(168, 24);
            this.ultraLabel6.TabIndex = 18;
            this.ultraLabel6.Text = "Value";
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(256, 158);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(350, 28);
            this.txtValue.TabIndex = 17;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(28, 88);
            this.ultraLabel3.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(168, 24);
            this.ultraLabel3.TabIndex = 16;
            this.ultraLabel3.Text = "Parameter Program ID";
            // 
            // TextCtrlProgID
            // 
            this.TextCtrlProgID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextCtrlProgID.Location = new System.Drawing.Point(256, 84);
            this.TextCtrlProgID.Name = "TextCtrlProgID";
            this.TextCtrlProgID.ReadOnly = true;
            this.TextCtrlProgID.Size = new System.Drawing.Size(350, 28);
            this.TextCtrlProgID.TabIndex = 15;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(28, 125);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(168, 24);
            this.ultraLabel2.TabIndex = 14;
            this.ultraLabel2.Text = "Tag Address";
            // 
            // TextCtrlTagAddress
            // 
            this.TextCtrlTagAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextCtrlTagAddress.Location = new System.Drawing.Point(256, 121);
            this.TextCtrlTagAddress.Name = "TextCtrlTagAddress";
            this.TextCtrlTagAddress.Size = new System.Drawing.Size(350, 28);
            this.TextCtrlTagAddress.TabIndex = 13;
            // 
            // btnWriteValues
            // 
            this.btnWriteValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWriteValues.Location = new System.Drawing.Point(318, 225);
            this.btnWriteValues.Name = "btnWriteValues";
            this.btnWriteValues.Size = new System.Drawing.Size(289, 39);
            this.btnWriteValues.TabIndex = 20;
            this.btnWriteValues.Text = "Write OPC Data";
            this.btnWriteValues.Click += new System.EventHandler(this.btnWriteValues_Click);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraButton1.Location = new System.Drawing.Point(23, 225);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(289, 39);
            this.ultraButton1.TabIndex = 19;
            this.ultraButton1.Text = "Read OPC Data";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel5.Location = new System.Drawing.Point(25, 381);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(57, 20);
            this.ultraLabel5.TabIndex = 24;
            this.ultraLabel5.Text = "Error";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel4.Location = new System.Drawing.Point(26, 315);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(57, 20);
            this.ultraLabel4.TabIndex = 23;
            this.ultraLabel4.Text = "Result";
            // 
            // ErrorLabel
            // 
            appearance1.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Appearance = appearance1;
            this.ErrorLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.Location = new System.Drawing.Point(23, 401);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(588, 40);
            this.ErrorLabel.TabIndex = 22;
            // 
            // ResultLabel
            // 
            appearance2.ForeColor = System.Drawing.Color.Green;
            this.ResultLabel.Appearance = appearance2;
            this.ResultLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultLabel.Location = new System.Drawing.Point(23, 337);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(588, 40);
            this.ResultLabel.TabIndex = 21;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel7.Location = new System.Drawing.Point(28, 52);
            this.ultraLabel7.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(168, 24);
            this.ultraLabel7.TabIndex = 25;
            this.ultraLabel7.Text = "Default Program ID";
            // 
            // ultraCheckEditor1
            // 
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.SizeInPoints = 10F;
            this.ultraCheckEditor1.Appearance = appearance3;
            this.ultraCheckEditor1.Checked = true;
            this.ultraCheckEditor1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ultraCheckEditor1.Location = new System.Drawing.Point(258, 44);
            this.ultraCheckEditor1.Name = "ultraCheckEditor1";
            this.ultraCheckEditor1.Size = new System.Drawing.Size(353, 30);
            this.ultraCheckEditor1.TabIndex = 26;
            this.ultraCheckEditor1.Text = "Default ProgID. Uncheck and Insert Custom ProgID.";
            this.ultraCheckEditor1.CheckedChanged += new System.EventHandler(this.ultraCheckEditor1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.ultraCheckEditor1);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.btnWriteValues);
            this.Controls.Add(this.ultraButton1);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.TextCtrlProgID);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.TextCtrlTagAddress);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ReadCacheOrDevice);
            this.Controls.Add(this.ReadDeviceOrCache);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextCtrlProgID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextCtrlTagAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCheckEditor1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private System.Windows.Forms.RadioButton ReadCacheOrDevice;
        private System.Windows.Forms.RadioButton ReadDeviceOrCache;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtValue;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TextCtrlProgID;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TextCtrlTagAddress;
        private Infragistics.Win.Misc.UltraButton btnWriteValues;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ErrorLabel;
        private Infragistics.Win.Misc.UltraLabel ResultLabel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ultraCheckEditor1;
    }
}

