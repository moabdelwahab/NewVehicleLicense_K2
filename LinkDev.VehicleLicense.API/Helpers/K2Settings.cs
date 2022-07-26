using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LinkDev.VehicleLicense.API.Helpers
{
    public static class K2Settings
    {
        public static string K2Server
        {
            get { return ConfigurationManager.AppSettings["K2Server"]; }
        }

        public static string SecurityLabelAspNetIdentity
        {
            get { return "AspNet Identity"; }
        }

        public static string SecurityLabelDomain
        {
            get { return "K2"; }
        }

        public static string K2Domain
        {
            get { return ConfigurationManager.AppSettings["K2Domain"]; }
        }

        public static string K2Username
        {
            get { return ConfigurationManager.AppSettings["K2Username"]; }
        }

        public static string K2Password
        {
            get { return ConfigurationManager.AppSettings["K2Password"]; }
        }

        public static int K2ServerPort
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["K2ServerPort"]); }
        }

        public static int K2WorkFlowManagementServerPort
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["K2WorkFlowManagementServerPort"]); }
        }

        public static int K2SmartObjectServerPort
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["K2SmartObjectServerPort"]); }
        }
    }
}