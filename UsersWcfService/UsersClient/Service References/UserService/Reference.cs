﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UsersClient.UserService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserService.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/FindUsers", ReplyAction="http://tempuri.org/IUserService/FindUsersResponse")]
        System.Collections.Generic.List<SharedModel.User> FindUsers(string searchString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/FindUsers", ReplyAction="http://tempuri.org/IUserService/FindUsersResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SharedModel.User>> FindUsersAsync(string searchString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        SharedModel.User GetUser(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        System.Threading.Tasks.Task<SharedModel.User> GetUserAsync(string login);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : UsersClient.UserService.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<UsersClient.UserService.IUserService>, UsersClient.UserService.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<SharedModel.User> FindUsers(string searchString) {
            return base.Channel.FindUsers(searchString);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SharedModel.User>> FindUsersAsync(string searchString) {
            return base.Channel.FindUsersAsync(searchString);
        }
        
        public SharedModel.User GetUser(string login) {
            return base.Channel.GetUser(login);
        }
        
        public System.Threading.Tasks.Task<SharedModel.User> GetUserAsync(string login) {
            return base.Channel.GetUserAsync(login);
        }
    }
}
