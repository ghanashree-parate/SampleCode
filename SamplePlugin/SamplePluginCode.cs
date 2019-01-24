using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;
using System.Security.Principal;
using Microsoft.Xrm.Sdk.Client;

namespace SamplePlugin
{
    public class SamplePluginCode : IPlugin
    {
        private ITracingService trace;
        public void Execute(IServiceProvider serviceProvider)
        {           
            try
            {              
                //Extract the tracing service for use in debugging sandboxed plug-ins.
                trace = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
                // Obtain the execution context from the service provider.
                IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

                // Obtain the organization service reference.
                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService
                   (typeof(IOrganizationServiceFactory));

                IOrganizationService service =
                   serviceFactory.CreateOrganizationService(context.UserId);

                trace.Trace("Plugin has been started and collected all necessary object");

                trace.Trace($"plugin depth is {context.Depth.ToString()}");

                using (OrganizationServiceContext orgContext = new OrganizationServiceContext(service))
                {
                    Process(serviceProvider, context, service, orgContext);
                }

                trace.Trace("Plugin execution ends");

            }
            catch (Exception ex)
            {
                trace.Trace($"{this.GetType().Name} FAILED. {ex.Message}");
                throw ex;
            }
        }

        private void Process(IServiceProvider serviceProvider, IPluginExecutionContext context, IOrganizationService service, OrganizationServiceContext orgContext)
        {
            trace.Trace("In Process function");


            trace.Trace("Process function ends");
        }
    }
}
