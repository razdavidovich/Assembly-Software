﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Magma.WCF.Services.Opc.Tester.OPCTester_Service {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WriteValuesResult", Namespace="http://Magma.WCF.Services.OpcService")]
    [System.SerializableAttribute()]
    public partial class WriteValuesResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Dictionary<string, System.Exception> WriteTagsStatusListField;
        
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
        public bool Success {
            get {
                return this.SuccessField;
            }
            set {
                if ((this.SuccessField.Equals(value) != true)) {
                    this.SuccessField = value;
                    this.RaisePropertyChanged("Success");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Dictionary<string, System.Exception> WriteTagsStatusList {
            get {
                return this.WriteTagsStatusListField;
            }
            set {
                if ((object.ReferenceEquals(this.WriteTagsStatusListField, value) != true)) {
                    this.WriteTagsStatusListField = value;
                    this.RaisePropertyChanged("WriteTagsStatusList");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OpcValue", Namespace="http://Magma.WCF.Services.OpcService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Magma.WCF.Services.Opc.Tester.OPCTester_Service.WriteValuesResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Magma.WCF.Services.Opc.Tester.OPCTester_Service.OpcValue[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<string, object>))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<string, System.Exception>))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(string[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    public partial class OpcValue : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Magma.WCF.Services.OpcService", ConfigurationName="OPCTester_Service.IOpcService")]
    public interface IOpcService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Magma.WCF.Services.OpcService/IOpcService/WriteSingleValue", ReplyAction="http://Magma.WCF.Services.OpcService/IOpcService/WriteSingleValueResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Magma.WCF.Services.Opc.Tester.OPCTester_Service.WriteValuesResult))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Magma.WCF.Services.Opc.Tester.OPCTester_Service.OpcValue))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Magma.WCF.Services.Opc.Tester.OPCTester_Service.OpcValue[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<string, object>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<string, System.Exception>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        bool WriteSingleValue(string tagAddress, object value, string parameterProgId, bool simulate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Magma.WCF.Services.OpcService/IOpcService/WriteValues", ReplyAction="http://Magma.WCF.Services.OpcService/IOpcService/WriteValuesResponse")]
        Magma.WCF.Services.Opc.Tester.OPCTester_Service.WriteValuesResult WriteValues(System.Collections.Generic.Dictionary<string, object> values, string parameterProgId, bool simulate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Magma.WCF.Services.OpcService/IOpcService/ReadSingleValue", ReplyAction="http://Magma.WCF.Services.OpcService/IOpcService/ReadSingleValueResponse")]
        Magma.WCF.Services.Opc.Tester.OPCTester_Service.OpcValue ReadSingleValue(string tagAddress, bool readDevice, string parameterProgId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Magma.WCF.Services.OpcService/IOpcService/ReadValues", ReplyAction="http://Magma.WCF.Services.OpcService/IOpcService/ReadValuesResponse")]
        Magma.WCF.Services.Opc.Tester.OPCTester_Service.OpcValue[] ReadValues(string[] tagAddressList, bool readDevice, string parameterProgId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Magma.WCF.Services.OpcService/IOpcService/GetServiceMode", ReplyAction="http://Magma.WCF.Services.OpcService/IOpcService/GetServiceModeResponse")]
        string GetServiceMode();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Magma.WCF.Services.OpcService/IOpcService/GetTagsToExcludeOnSimulateWrite", ReplyAction="http://Magma.WCF.Services.OpcService/IOpcService/GetTagsToExcludeOnSimulateWriteR" +
            "esponse")]
        string[] GetTagsToExcludeOnSimulateWrite();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOpcServiceChannel : Magma.WCF.Services.Opc.Tester.OPCTester_Service.IOpcService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OpcServiceClient : System.ServiceModel.ClientBase<Magma.WCF.Services.Opc.Tester.OPCTester_Service.IOpcService>, Magma.WCF.Services.Opc.Tester.OPCTester_Service.IOpcService {
        
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
        
        public bool WriteSingleValue(string tagAddress, object value, string parameterProgId, bool simulate) {
            return base.Channel.WriteSingleValue(tagAddress, value, parameterProgId, simulate);
        }
        
        public Magma.WCF.Services.Opc.Tester.OPCTester_Service.WriteValuesResult WriteValues(System.Collections.Generic.Dictionary<string, object> values, string parameterProgId, bool simulate) {
            return base.Channel.WriteValues(values, parameterProgId, simulate);
        }
        
        public Magma.WCF.Services.Opc.Tester.OPCTester_Service.OpcValue ReadSingleValue(string tagAddress, bool readDevice, string parameterProgId) {
            return base.Channel.ReadSingleValue(tagAddress, readDevice, parameterProgId);
        }
        
        public Magma.WCF.Services.Opc.Tester.OPCTester_Service.OpcValue[] ReadValues(string[] tagAddressList, bool readDevice, string parameterProgId) {
            return base.Channel.ReadValues(tagAddressList, readDevice, parameterProgId);
        }
        
        public string GetServiceMode() {
            return base.Channel.GetServiceMode();
        }
        
        public string[] GetTagsToExcludeOnSimulateWrite() {
            return base.Channel.GetTagsToExcludeOnSimulateWrite();
        }
    }
}