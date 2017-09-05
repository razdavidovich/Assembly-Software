namespace Magma.WCF.Services.Bartender.Tester
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBTLabel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.Copies = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCopies = new System.Windows.Forms.TextBox();
            this.txtSerialized = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtThreads = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(29, 208);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(1367, 459);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "BT Lbael:";
            // 
            // txtBTLabel
            // 
            this.txtBTLabel.Location = new System.Drawing.Point(85, 17);
            this.txtBTLabel.Name = "txtBTLabel";
            this.txtBTLabel.Size = new System.Drawing.Size(297, 20);
            this.txtBTLabel.TabIndex = 3;
            this.txtBTLabel.Text = "D:\\Temp\\ProdMashkofim.btw";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Printer:";
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(85, 49);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(297, 20);
            this.txtPrinter.TabIndex = 5;
            this.txtPrinter.Text = "PDFCreator";
            // 
            // Copies
            // 
            this.Copies.AutoSize = true;
            this.Copies.Location = new System.Drawing.Point(26, 85);
            this.Copies.Name = "Copies";
            this.Copies.Size = new System.Drawing.Size(42, 13);
            this.Copies.TabIndex = 6;
            this.Copies.Text = "Copies:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Serialized:";
            // 
            // txtCopies
            // 
            this.txtCopies.Location = new System.Drawing.Point(85, 85);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(75, 20);
            this.txtCopies.TabIndex = 8;
            this.txtCopies.Text = "1";
            // 
            // txtSerialized
            // 
            this.txtSerialized.Location = new System.Drawing.Point(87, 121);
            this.txtSerialized.Name = "txtSerialized";
            this.txtSerialized.Size = new System.Drawing.Size(73, 20);
            this.txtSerialized.TabIndex = 9;
            this.txtSerialized.Text = "1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Print UDI";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(291, 165);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Print Task";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(475, 165);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Print Stress";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtThreads
            // 
            this.txtThreads.Location = new System.Drawing.Point(611, 165);
            this.txtThreads.Name = "txtThreads";
            this.txtThreads.Size = new System.Drawing.Size(73, 20);
            this.txtThreads.TabIndex = 13;
            this.txtThreads.Text = "50";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(655, 20);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(710, 20);
            this.txtAddress.TabIndex = 14;
            this.txtAddress.Text = "net.tcp://localhost:8734/Runtime/Magma.WCF.Services.Bartender/BartenderService/";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 679);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtThreads);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSerialized);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Copies);
            this.Controls.Add(this.txtPrinter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBTLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBTLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrinter;
        private System.Windows.Forms.Label Copies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCopies;
        private System.Windows.Forms.TextBox txtSerialized;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtThreads;
        private System.Windows.Forms.TextBox txtAddress;
    }
}

