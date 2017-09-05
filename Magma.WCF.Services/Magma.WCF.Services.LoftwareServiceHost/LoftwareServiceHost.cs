using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Magma.WCF.Services.Loftware;
using Magma.WCF.Services.Logging;

namespace Magma.WCF.Services.LoftwareServiceHost
{
    public partial class LoftwareServiceHost : ServiceBase
    {
        #region Class properties

        /// <summary>the service host</summary>
        public ServiceHost serviceHost { get; private set; }

        #endregion

        public LoftwareServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // initialize the logger. Read current severity settings from the config along with the source and log name
            Logger.SeverityTypes currentSeverity = (Logger.SeverityTypes)Enum.Parse(typeof(Logger.SeverityTypes), ConfigurationManager.AppSettings["LogSeverity"], true);
            Logger.InitLog(ConfigurationManager.AppSettings["EventSourceName"], ConfigurationManager.AppSettings["EventLogName"], currentSeverity);

            try
            {
                if (serviceHost != null)
                {
                    serviceHost.Close();
                }

                // Create a ServiceHost for the LoftwareService type and 
                // provide the base address.
                serviceHost = new ServiceHost(typeof(LoftwareService));


                // Open the ServiceHostBase to create listeners and start 
                // listening for messages.
                serviceHost.Open();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                Logger.Write("Service shutting down", EventLogEntryType.Information, Logger.SeverityTypes.Information);
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
