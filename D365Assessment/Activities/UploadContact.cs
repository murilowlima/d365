using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D365Assessment.Business;
using D365Assessment.External;
using System.Threading;

namespace D365Assessment.Activities
{
    public class UploadContact : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            // Getting OrganizationService from Context
            var workflowContext = context.GetExtension<IWorkflowContext>();
            var serviceFactory = context.GetExtension<IOrganizationServiceFactory>();
            var orgService = serviceFactory.CreateOrganizationService(workflowContext.UserId);
            var tracingService = context.GetExtension<ITracingService>();


            try
            {
                string url = "https://randomuser.me/api/";
                ContactBusiness contactBusiness = new ContactBusiness(orgService, new APIManager(url));

                contactBusiness.UploadConctactFromAPI();
            }
            catch (Exception ex)
            {
                tracingService.Trace($"Error get new contact: {ex.GetType().Name}. Message: {ex.Message}. Stack: {ex.StackTrace}. Inner stack: {ex.InnerException}");
                throw;
            }

        }
    }
}
