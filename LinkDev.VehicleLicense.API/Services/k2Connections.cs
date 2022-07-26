using LinkDev.VehicleLicense.API.Contracts;
using LinkDev.VehicleLicense.API.Helpers;
using SourceCode.Hosting.Client.BaseAPI;
using SourceCode.SmartObjects.Client;
using SourceCode.Workflow.Client;
using SourceCode.Workflow.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkDev.VehicleLicense.API.Services
{
    public class k2Connections : IK2Connections
    {
        private Connection k2Connecton;

        private WorkflowManagementServer managementserver;

        private SmartObjectClientServer sOserver;


        public Connection K2Connect
        {
            get
            {
                if (k2Connecton != null)
                {
                    return k2Connecton;
                }

                k2Connecton = new Connection();
                return k2Connecton;
            }
        }

        public WorkflowManagementServer ManagementServer
        {
            get
            {
                if (managementserver != null && managementserver.Connection != null)
                {
                    return managementserver;
                }
                else
                {
                    managementserver = GetManagementServer();
                    return managementserver;
                }
            }
        }

        public SmartObjectClientServer SmartObjectServer
        {
            get
            {
                if (sOserver != null)
                {
                    return sOserver;
                }
                else
                {
                    sOserver = GetSmartObjectsServer();
                    return sOserver;
                }
            }
        }

        private string K2server
        {
            get { return K2Settings.K2Server; }
        }

        public bool InitConnection(string impersonatedUser)
        {
            try
            {
                // Create a connection string
                SCConnectionStringBuilder builder = new SCConnectionStringBuilder
                {
                    Host = K2server,
                    Port = (uint)K2Settings.K2ServerPort,
                    Integrated = false,
                    IsPrimaryLogin = true,
                    SecurityLabelName = K2Settings.SecurityLabelDomain,
                    UserID = string.Format(@"{0}\{1}", K2Settings.K2Domain, K2Settings.K2Username),
                    Password = K2Settings.K2Password,
                };
                K2Connect.Open(K2server, builder.ConnectionString);
                K2Connect.ImpersonateUser("K2:" + impersonatedUser);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            if (k2Connecton != null)
            {
                k2Connecton.Close();
                k2Connecton.Dispose();
            }

            if (managementserver != null && managementserver.Connection != null)
            {
                managementserver.Connection.Close();
                managementserver.Connection.Dispose();
            }

            if (sOserver != null && sOserver.Connection != null)
            {
                sOserver.Connection.Close();
                sOserver.Connection.Dispose();
            }
        }

        private WorkflowManagementServer GetManagementServer()
        {
            try
            {
                var connectionStringBuilder =
                                               new SCConnectionStringBuilder
                                               {
                                                   Host = K2server,
                                                   Port = (uint)K2Settings.K2WorkFlowManagementServerPort,
                                                   Integrated = false,
                                                   UserID = string.Format(@"{0}\{1}", K2Settings.K2Domain, K2Settings.K2Username),
                                                   Password = K2Settings.K2Password,
                                                   IsPrimaryLogin = true,
                                                   Authenticate = true,
                                                   EncryptedPassword = false,
                                                   SecurityLabelName = K2Settings.SecurityLabelDomain,
                                                   WindowsDomain = string.Empty,
                                               };

                var manager = new WorkflowManagementServer();
                manager.Open(connectionStringBuilder.ConnectionString);
                return manager;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private SmartObjectClientServer GetSmartObjectsServer()
        {
            try
            {
                var smartObjectServer = new SmartObjectClientServer();
                SCConnectionStringBuilder cb = new SCConnectionStringBuilder
                {
                    Host = K2server,
                    Port = (uint)K2Settings.K2SmartObjectServerPort,
                    Integrated = false,
                    UserID = string.Format(@"{0}\{1}", K2Settings.K2Domain, K2Settings.K2Username),
                    Password = K2Settings.K2Password,
                    IsPrimaryLogin = true,
                    Authenticate = true,
                    EncryptedPassword = false,
                    SecurityLabelName = K2Settings.SecurityLabelDomain,
                    WindowsDomain = string.Empty,
                };

                smartObjectServer.CreateConnection();
                smartObjectServer.Connection.Open(cb.ConnectionString);
                return smartObjectServer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}