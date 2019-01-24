using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWorkflow
{
    public class SampleCode : CodeActivity
    {
        //protected override void Execute(CodeActivityContext executionContext)
        //{
        //    ITracingService tracingService = executionContext.GetExtension<ITracingService>();

        //    tracingService.Trace("Create the context");
        //    IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
        //    IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
        //    IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

        //    try
        //    {
       
        //    }
        //    catch (Exception e)
        //    {
        //        tracingService.Trace(e.Message);
        //        throw e;
        //    }
        //}

        private ITracingService trace;

        protected override void Execute(CodeActivityContext executionContext)
        {
            try
            {
                trace = executionContext.GetExtension<ITracingService>();
                IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
                IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                trace.Trace("Worklfow has been started and collected all necessary object");

                trace.Trace($"Workflow depth is {context.Depth.ToString()}");

                using (OrganizationServiceContext orgContext = new OrganizationServiceContext(service))
                {
                    Process(executionContext, context, service, orgContext);
                }

                trace.Trace("Workflow execution ends");
            }
            catch (Exception ex)
            {
                trace.Trace($"{this.GetType().Name} FAILED. {ex.Message}");
                throw ex;
            }
        }

        private void Process(CodeActivityContext executionContext, IWorkflowContext context, IOrganizationService service, OrganizationServiceContext orgContext)
        {
            trace.Trace("In Process function");


            trace.Trace("Process function ends");
        }
    }
}
