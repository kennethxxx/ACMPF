﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.18444
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkerRoleController.FileTransfer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FileTransfer.FileTransfer")]
    public interface FileTransfer {
        
        // CODEGEN: 訊息 DownloadRequest 的包裝函式名稱 (DownloadRequest) 與預設值 (DownloadFile) 不符，正在產生訊息合約
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FileTransfer/DownloadFile", ReplyAction="http://tempuri.org/FileTransfer/DownloadFileResponse")]
        WorkerRoleController.FileTransfer.RemoteFileInfo DownloadFile(WorkerRoleController.FileTransfer.DownloadRequest request);
        
        // CODEGEN: 作業 UploadFile 未由 RPC 或文件所包裝，正在產生訊息合約。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FileTransfer/UploadFile", ReplyAction="http://tempuri.org/FileTransfer/UploadFileResponse")]
        WorkerRoleController.FileTransfer.UploadFileResponse UploadFile(WorkerRoleController.FileTransfer.RemoteFileInfo request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DownloadRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DownloadRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string FileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string ForderName;
        
        public DownloadRequest() {
        }
        
        public DownloadRequest(string FileName, string ForderName) {
            this.FileName = FileName;
            this.ForderName = ForderName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RemoteFileInfo", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class RemoteFileInfo {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string FileName;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public long Length;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream FileByteStream;
        
        public RemoteFileInfo() {
        }
        
        public RemoteFileInfo(string FileName, long Length, System.IO.Stream FileByteStream) {
            this.FileName = FileName;
            this.Length = Length;
            this.FileByteStream = FileByteStream;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadFileResponse {
        
        public UploadFileResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FileTransferChannel : WorkerRoleController.FileTransfer.FileTransfer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FileTransferClient : System.ServiceModel.ClientBase<WorkerRoleController.FileTransfer.FileTransfer>, WorkerRoleController.FileTransfer.FileTransfer {
        
        public FileTransferClient() {
        }
        
        public FileTransferClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileTransferClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileTransferClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileTransferClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WorkerRoleController.FileTransfer.RemoteFileInfo WorkerRoleController.FileTransfer.FileTransfer.DownloadFile(WorkerRoleController.FileTransfer.DownloadRequest request) {
            return base.Channel.DownloadFile(request);
        }
        
        public long DownloadFile(ref string FileName, string ForderName, out System.IO.Stream FileByteStream) {
            WorkerRoleController.FileTransfer.DownloadRequest inValue = new WorkerRoleController.FileTransfer.DownloadRequest();
            inValue.FileName = FileName;
            inValue.ForderName = ForderName;
            WorkerRoleController.FileTransfer.RemoteFileInfo retVal = ((WorkerRoleController.FileTransfer.FileTransfer)(this)).DownloadFile(inValue);
            FileName = retVal.FileName;
            FileByteStream = retVal.FileByteStream;
            return retVal.Length;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WorkerRoleController.FileTransfer.UploadFileResponse WorkerRoleController.FileTransfer.FileTransfer.UploadFile(WorkerRoleController.FileTransfer.RemoteFileInfo request) {
            return base.Channel.UploadFile(request);
        }
        
        public void UploadFile(string FileName, long Length, System.IO.Stream FileByteStream) {
            WorkerRoleController.FileTransfer.RemoteFileInfo inValue = new WorkerRoleController.FileTransfer.RemoteFileInfo();
            inValue.FileName = FileName;
            inValue.Length = Length;
            inValue.FileByteStream = FileByteStream;
            WorkerRoleController.FileTransfer.UploadFileResponse retVal = ((WorkerRoleController.FileTransfer.FileTransfer)(this)).UploadFile(inValue);
        }
    }
}
