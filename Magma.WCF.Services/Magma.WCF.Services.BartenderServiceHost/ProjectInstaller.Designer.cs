namespace Magma.WCF.Services.BartenderServiceHost
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
            this.bartenderServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.bartenderServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // bartenderServiceProcessInstaller
            // 
            this.bartenderServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.bartenderServiceProcessInstaller.Password = null;
            this.bartenderServiceProcessInstaller.Username = null;
            // 
            // bartenderServiceInstaller
            // 
            this.bartenderServiceInstaller.Description = "This service acts as the host service for the WCF wrapper for the Bartender SDK";
            this.bartenderServiceInstaller.DisplayName = "Magma\'s Bartender WCF service host";
            this.bartenderServiceInstaller.ServiceName = "BartenderServiceHost";
            this.bartenderServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.bartenderServiceProcessInstaller,
            this.bartenderServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller bartenderServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller bartenderServiceInstaller;
    }
}