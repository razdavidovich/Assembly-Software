using System;
using System.Text;
using Lighthouse.LHSystem.Collections;
using Lighthouse.LHSystem.Data.AbstractDbFactory;
using System.Collections.Generic;
using Lighthouse.LHSystem.Data;
using System.Globalization;
using Lighthouse.LHSystem;
using System.Threading;
using System.Data;
using System.ServiceModel; // This USING is required!

namespace Lighthouse.Udi.Scripting
{
    /// <summary>
    /// 
    /// </summary>
    [SfolEntityManager("Inventory")]
    public class TaskBartenderSample
        : SfolEntityBase
    {

        /// <summary>Reference to a Bartender WCF service client</summary>
        public BartenderServiceClient Client { get; private set; }

        public List<string> Args { get; private set; }

        /// <summary>BT respose object</summary>
        public BTPrintResponse Response { get; private set; }

        public TaskBartenderSample(List<string> args)
        {
            Args = args;

            // create client instane
            Client = new BartenderServiceClient(new NetNamedPipeBinding(), new EndpointAddress(@"net.pipe://localhost/Runtime/Magma.WCF.Services.Bartender/BartenderService/"));
        }

        /// <summary>
        /// This method will be invoked by SFOL
        /// </summary>
        /// <param name="dbFactory">The db factory.</param>
        [SfolEntityAction("Print")]
        public void ExecuteTask(DbFactory dbFactory)
        {
            Response = Client.PrintLabel("job", null, Args[0], Args[1], new Dictionary<string, string>(), Convert.ToInt32(Args[2]), Convert.ToInt32(Args[3]), MissingParamBehaviour.Ignore);
        }
    }
}
