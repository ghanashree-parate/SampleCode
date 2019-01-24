using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApplication
{
    public static class SVC
    {
        private static CrmServiceClient client;

        public static CrmServiceClient instance
        {
            get
            {
                if (client == null)
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    client = new CrmServiceClient(ConfigurationManager.ConnectionStrings["Xrm"].ConnectionString);
                }
                return client;
            }
        }
    }
}
