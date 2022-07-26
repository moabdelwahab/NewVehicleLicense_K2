using SourceCode.SmartObjects.Client;
using SourceCode.Workflow.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.VehicleLicense.API.Contracts
{
    public interface IK2Connections : IDisposable
    {
        SourceCode.Workflow.Client.Connection K2Connect { get;}

        WorkflowManagementServer ManagementServer { get; }

        SmartObjectClientServer SmartObjectServer { get; }

        bool InitConnection(string impersonatedUser);
    }
}
