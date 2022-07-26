using LinkDev.VehicleLicense.API.Helpers;
using LinkDev.VehicleLicense.API.Models;
using SourceCode.Workflow.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkDev.VehicleLicense.API.Services
{
    public class K2Service
    {
        public int StartWorkflow(string userName, Request request)
        {
            ProcessInstance processInstance = null;

            using(k2Connections k2Connections = new k2Connections())
            {
                k2Connections.InitConnection(userName);
                
                processInstance= k2Connections.K2Connect.CreateProcessInstance(k2Constants.ProcessesShortNames.NewVehicleLicenseWorkflow);

                processInstance.Folio = request.RequestNumber;

                k2Connections.K2Connect.StartProcessInstance(processInstance, true);
            }

            return processInstance.ID;
        }
    }
}