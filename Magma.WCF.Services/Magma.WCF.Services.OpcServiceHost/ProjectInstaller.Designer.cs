namespace Magma.WCF.Services.OpcServiceHost
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.opcServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.opcServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // opcServiceProcessInstaller
            // 
            this.opcServiceProcessInstaller.Password = null;
            this.opcServiceProcessInstaller.Username = null;
            // 
            // opcServiceInstaller
            // 
            this.opcServiceInstaller.DelayedAutoStart = true;
            this.opcServiceInstaller.Description = "This service use\'s Lighthouse System\'s OPC client DA implemetation to connect, re" +
    "ad and write to an OPC server";
            this.opcServiceInstaller.DisplayName = "Magma\'s OPC WCF Service host";
            this.opcServiceInstaller.ServiceName = "OpcServiceHost";
            this.opcServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.opcServiceProcessInstaller,
            this.opcServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller opcServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller opcServiceInstaller;
    }
}