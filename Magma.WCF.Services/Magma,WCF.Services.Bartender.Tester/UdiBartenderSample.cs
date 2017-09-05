using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel; // This USING is required!
using System.Text;

namespace Lighthouse.Udi.Scripting
{
    /// <summary>
    /// This class is a sample UDI script that demonstates the use of the Bartenders WCF service.
    /// It is assumed that the file BartenderWcfClient.cs is located next to this one (and defined in the UDI event) as it contains the client class for the WCF service.
    /// </summary>
    public class UdiBartenderSample: UdiScriptBase
    {
        #region Class Properties

        /// <summary>Reference to a Bartender WCF service client</summary>
        public BartenderServiceClient Client { get; private set; }

        /// <summary>dictionary of params to send to the BT service</summary>
        public Dictionary<string, string> Parameters { get; private set; }

        /// <summary>BT respose object</summary>
        public BTPrintResponse Response { get; private set; }

        #endregion

        #region Class construction

        /// <summary>
        /// create a new instnace.
        /// Sets the parameters dictionary and creates an instace of the client with NET TCP binding and the service's TCP address
        /// </summary>
        /// <param name="parameters"></param>
        public UdiBartenderSample(Dictionary<string, string> parameters)
        {
            Parameters = parameters;

            // create client instane
            Client = new BartenderServiceClient(new NetNamedPipeBinding(), new EndpointAddress(@"net.pipe://localhost/Runtime/Magma.WCF.Services.Bartender/BartenderService/"));
        }

        #endregion

        #region Class overrides

        /// <summary>
        /// Do the actual printing.
        /// In this sampe it is assumed to some parameters are sent as ARGS for this method
        /// </summary>
        /// <param name="args"></param>
        public override void GetData(List<string> args)
        {
            Response = Client.PrintLabel("job", null, args[0], args[1], Parameters, Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), MissingParamBehaviour.Ignore);
        }

        #endregion

    }
}
