using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using Lighthouse.Udi.Scripting;
using Lighthouse.Udi.Scripting.CodeDom;

namespace Magma.WCF.Services.Bartender.Tester
{
    public partial class Form1 : Form
    {

        // C:\Support\Label\Local.btw
        // \\10.200.17.247\Zebra S4M (203 dpi) - ZPL


        public Form1()
        {
            InitializeComponent();
        }

        public delegate BTPrintResponse PrintLabelDelegate(string jobName, int? to, string labelformat, string printer, Dictionary<string, string> parameters, int copies, int serialzed, MissingParamBehaviour missingParamBehaviour);


        BartenderServiceClient client = null; 
        //BartenderServiceClient client = new BartenderServiceClient(new NetNamedPipeBinding(), new EndpointAddress(@"net.pipe://localhost/Runtime/Magma.WCF.Services.Bartender/BartenderService/"));


        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

         
            int copies = Convert.ToInt32(txtCopies.Text);
            int serialized = Convert.ToInt32(txtSerialized.Text);

            BTPrintResponse r = client.PrintLabel("job", null, txtBTLabel.Text, txtPrinter.Text, parameters, copies, serialized, MissingParamBehaviour.SetEmptyString);


            foreach (string s in r.Messages)
            {
                listBox1.Items.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UdiBartenderSample script = new UdiBartenderSample(new Dictionary<string, string>());


            List<string> initArgs = new List<string>();
            List<string> getDataArgs = new List<string>();
            List<string> terminateArgs = new List<string>();


            getDataArgs.Add(txtBTLabel.Text);
            getDataArgs.Add(txtPrinter.Text);
            getDataArgs.Add(txtCopies.Text);
            getDataArgs.Add(txtSerialized.Text);
           // CodeDomEngine.InitialiseTestScript(script, Convert.ToInt32(2), txtLHAPPConnectionString.Text, txtPlantConnectionString.Text, new UdiEventInfo(3, null, scriptName, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, null, null, null, "path"));

            try
            {
                script.Initalise(initArgs);

                script.GetData(getDataArgs);

                foreach (string s in script.Response.Messages)
                {
                    listBox1.Items.Add(s);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                script.Terminate(terminateArgs);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        PrintLabelDelegate printLabelDelegate;

        private void button4_Click(object sender, EventArgs e)
        {
            client = new BartenderServiceClient(new NetTcpBinding(), new EndpointAddress(txtAddress.Text));

           printLabelDelegate = new PrintLabelDelegate(PrintLabel);

            for (int i = 0; i < Convert.ToInt32( txtThreads.Text); i++)
            {
                printLabelDelegate.BeginInvoke("label" + i.ToString(), null, txtBTLabel.Text, txtPrinter.Text, new Dictionary<string, string>(), 1, 0, MissingParamBehaviour.Ignore, new AsyncCallback(CompletePrint), null);
            }

        }



        protected BTPrintResponse PrintLabel(string jobName, int? to, string labelformat, string printer, Dictionary<string, string> parameters, int copies, int serialzed, MissingParamBehaviour missingParamBehaviour)
        {
            return client.PrintLabel(jobName, null, labelformat, printer, parameters, 1, 1, MissingParamBehaviour.SetEmptyString);
        }

        protected void CompletePrint(IAsyncResult result)
        {
            BTPrintResponse b = printLabelDelegate.EndInvoke(result);

            foreach (string s in b.Messages)
                {

                this.Invoke(new MethodInvoker(delegate()
                {

                    listBox1.Items.Add(s ); 

                       }));
                    
                }

        }

    }
}
