using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lighthouse.Udi.Scripting
{
    using System.Runtime.Serialization;
    using System;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "MissingParamBehaviour", Namespace = "http://Magma.WCF.Services.Bartender")]
    public enum MissingParamBehaviour : int
    {

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Ignore = 0,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fail = 1,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        SetEmptyString = 2,
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "BTPrintResponse", Namespace = "http://Magma.WCF.Services.Bartender")]
    [System.SerializableAttribute()]
    public partial class BTPrintResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] MessagesField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Lighthouse.Udi.Scripting.Result ResultField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Messages
        {
            get
            {
                return this.MessagesField;
            }
            set
            {
                if ((object.ReferenceEquals(this.MessagesField, value) != true))
                {
                    this.MessagesField = value;
                    this.RaisePropertyChanged("Messages");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public Lighthouse.Udi.Scripting.Result Result
        {
            get
            {
                return this.ResultField;
            }
            set
            {
                if ((this.ResultField.Equals(value) != true))
                {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Result", Namespace = "http://schemas.datacontract.org/2004/07/Seagull.BarTender.Print")]
    public enum Result : int
    {

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 0,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Timeout = 1,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Failure = 2,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://Magma.WCF.Services.Bartender", ConfigurationName = "BartenderService.IBartenderService")]
    public interface IBartenderService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://Magma.WCF.Services.Bartender/IBartenderService/PrintLabel", ReplyAction = "http://Magma.WCF.Services.Bartender/IBartenderService/PrintLabelResponse")]
        Lighthouse.Udi.Scripting.BTPrintResponse PrintLabel(string jobname, System.Nullable<int> waitForCompletionTimeoutInSeconds, string formatName, string printerName, System.Collections.Generic.Dictionary<string, string> parameters, int identicalCopiesOfLabel, int numberSerializedLabels, Lighthouse.Udi.Scripting.MissingParamBehaviour missingParamBehaviour);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBartenderServiceChannel : Lighthouse.Udi.Scripting.IBartenderService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BartenderServiceClient : System.ServiceModel.ClientBase<Lighthouse.Udi.Scripting.IBartenderService>, Lighthouse.Udi.Scripting.IBartenderService
    {

        public BartenderServiceClient()
        {
        }

        public BartenderServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public BartenderServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public BartenderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public BartenderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public Lighthouse.Udi.Scripting.BTPrintResponse PrintLabel(string jobname, System.Nullable<int> waitForCompletionTimeoutInSeconds, string formatName, string printerName, System.Collections.Generic.Dictionary<string, string> parameters, int identicalCopiesOfLabel, int numberSerializedLabels, Lighthouse.Udi.Scripting.MissingParamBehaviour missingParamBehaviour)
        {
            return base.Channel.PrintLabel(jobname, waitForCompletionTimeoutInSeconds, formatName, printerName, parameters, identicalCopiesOfLabel, numberSerializedLabels, missingParamBehaviour);
        }
    }
}

