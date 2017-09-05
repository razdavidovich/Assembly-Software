using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System;

namespace Lighthouse.Udi.Scripting
{
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WriteValuesResult", Namespace="http://Magma.WCF.Services.OpcService")]
    [System.SerializableAttribute()]
    public partial class WriteValuesResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OpcValue", Namespace="http://Magma.WCF.Services.OpcService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Lighthouse.Udi.Scripting.WriteValuesResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Lighthouse.Udi.Scripting.OpcValue[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<string, string>))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(string[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(short[]))]
    public partial class OpcValue : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string QualityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TagAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeStampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Quality {
            get {
                return this.QualityField;
            }
            set {
                if ((object.ReferenceEquals(this.QualityField, value) != true)) {
                    this.QualityField = value;
                    this.RaisePropertyChanged("Quality");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TagAddress {
            get {
                return this.TagAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.TagAddressField, value) != true)) {
                    this.TagAddressField = value;
                    this.RaisePropertyChanged("TagAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TimeStamp {
            get {
                return this.TimeStampField;
            }
            set {
                if ((this.TimeStampField.Equals(value) != true)) {
                    this.TimeStampField = value;
                    this.RaisePropertyChanged("TimeStamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Magma.WCF.Services.OpcService", ConfigurationName="OpcService.IOpcService")]
    public interface IOpcService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Magma.WCF.Services.OpcService/IOpcService/WriteSingleValue", ReplyAction="http://Magma.WCF.Services.OpcService/IOpcService/WriteSingleValueResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Lighthouse.Udi.Scripting.WriteValuesResult))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Lighthouse.Udi.Scripting.OpcValue))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Lighthouse.Udi.Scripting.OpcValue[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<string, string>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(short[]))]
        bool WriteSingleValue(string tagAddress, object value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Magma.WCF.Services.OpcService/IOpcService/WriteValues", ReplyAction="http://Magma.WCF.Services.OpcService/IOpcService/WriteValuesResponse")]
        Lighthouse.Udi.Scripting.WriteValuesResult WriteValues(System.Collections.Generic.Dictionary<string, string> values);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Magma.WCF.Services.OpcService/IOpcService/ReadSingleValue", ReplyAction="http://Magma.WCF.Services.OpcService/IOpcService/ReadSingleValueResponse")]
        Lighthouse.Udi.Scripting.OpcValue ReadSingleValue(string tagAddress, bool readDevice);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Magma.WCF.Services.OpcService/IOpcService/ReadValues", ReplyAction="http://Magma.WCF.Services.OpcService/IOpcService/ReadValuesResponse")]
        Lighthouse.Udi.Scripting.OpcValue[] ReadValues(string[] tagAddressList, bool readDevice);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOpcServiceChannel : Lighthouse.Udi.Scripting.IOpcService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OpcServiceClient : System.ServiceModel.ClientBase<Lighthouse.Udi.Scripting.IOpcService>, Lighthouse.Udi.Scripting.IOpcService {
        
        public OpcServiceClient() {
        }
        
        public OpcServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OpcServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OpcServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OpcServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool WriteSingleValue(string tagAddress, object value) {
            return base.Channel.WriteSingleValue(tagAddress, value);
        }
        
        public Lighthouse.Udi.Scripting.WriteValuesResult WriteValues(System.Collections.Generic.Dictionary<string, string> values) {
            return base.Channel.WriteValues(values);
        }
        
        public Lighthouse.Udi.Scripting.OpcValue ReadSingleValue(string tagAddress, bool readDevice) {
            return base.Channel.ReadSingleValue(tagAddress, readDevice);
        }
        
        public Lighthouse.Udi.Scripting.OpcValue[] ReadValues(string[] tagAddressList, bool readDevice) {
            return base.Channel.ReadValues(tagAddressList, readDevice);
        }
    }


}
