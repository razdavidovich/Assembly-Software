using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using Magma.WCF.Services.Opc;
using System.Configuration;
using Magma.WCF.Services.Logging;

namespace Magma.WCF.Services.OpcServiceHost
{
    /// <summary>
    /// OpcServiceHost is a Windows Service that hosts the WCF Service OpcService
    /// </summary>
    public partial class OpcServiceHost : ServiceBase
    {
        #region Class properties

        /// <summary>
        /// the OPC WCF service host
        /// </summary>
        public ServiceHost Host { get; private set; }

        #endregion

        #region Class construction

        /// <summary>
        /// creates new instance and initialized components
        /// </summary>
        public OpcServiceHost()
        {
            InitializeComponent();
        }

        #endregion

        #region Class overrides

        /// <summary>
        /// reads the initialization values from the configuration file and initializes the host and the OPC properties of the service
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            string progId = string.Empty;
            string serverNode = string.Empty;
            int retryCount;
            int retryInterval;
            OpcService.SimulateModeTypes simulateMode  = OpcService.SimulateModeTypes.NoSimulate;

            // initialize the logger. Read current severity settings from the config along with the source and log name
            Logger.SeverityTypes currentSeverity = (Logger.SeverityTypes)Enum.Parse(typeof(Logger.SeverityTypes), ConfigurationManager.AppSettings["LogSeverity"], true);
            Logger.InitLog(ConfigurationManager.AppSettings["EventSourceName"], ConfigurationManager.AppSettings["EventLogName"], currentSeverity);

            try
            {
                // kill an existing host - why on earth should there be one?
                if (Host != null)
                {
                    Host.Close();
                }

                // create the host
                Host = new ServiceHost(typeof(OpcService));

                // read values from config
                serverNode  = ConfigurationManager.AppSettings["ServerNode"];
                progId  = ConfigurationManager.AppSettings["ProgID"];
                retryCount = Convert.ToInt32(ConfigurationManager.AppSettings["RetryCount"]);
                retryInterval = Convert.ToInt32(ConfigurationManager.AppSettings["RetryInterval"]);
                simulateMode = (OpcService.SimulateModeTypes)Enum.Parse(typeof(OpcService.SimulateModeTypes), ConfigurationManager.AppSettings["SimulateMode"]);

                // initialize
                OpcService.Initialize(serverNode, progId, retryCount, retryInterval, simulateMode);

                Logger.Write("Connected to OPC. ProgID:" + progId + ". Server Node: " + serverNode + ". SimulateMode: " + ConfigurationManager.AppSettings["SimulateMode"], EventLogEntryType.Information, Logger.SeverityTypes.Information);

                // open host and start listening
                Host.Open();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Stops the host
        /// </summary>
        protected override void OnStop()
        {
            if (Host != null)
            {
                Logger.Write("Disconnected from OPC", EventLogEntryType.Information, Logger.SeverityTypes.Information);

                // close host
                Host.Close();
                Host = null;
            }
        }

        #endregion

    }
}
