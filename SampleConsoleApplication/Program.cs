using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //  Query using ConditionExpression and FilterExpression  
                ConditionExpression condition1 = new ConditionExpression();
                condition1.AttributeName = "lastname";
                condition1.Operator = ConditionOperator.Equal;
                condition1.Values.Add("Parate");

                FilterExpression filter1 = new FilterExpression();
                filter1.Conditions.Add(condition1);

                QueryExpression query = new QueryExpression("systemuser");
                query.ColumnSet.AddColumns("firstname", "lastname");
                query.Criteria.AddFilter(filter1);

                EntityCollection result1 = SVC.instance.RetrieveMultiple(query);
                Console.WriteLine(); Console.WriteLine("Query using Query Expression with ConditionExpression and FilterExpression");
                Console.WriteLine("---------------------------------------");
                foreach (var a in result1.Entities)
                {
                    Console.WriteLine("Name: " + a["firstname"] + " " + a.Attributes["lastname"]);
                }
                Console.WriteLine("---------------------------------------");





                // Obtain information about the logged on user from the web service.
                Guid userid = ((WhoAmIResponse)SVC.instance.Execute(new WhoAmIRequest())).UserId;

                Entity systemUser = SVC.instance.Retrieve("systemuser", userid,
                    new ColumnSet(new string[] { "firstname", "lastname" }));

                Console.WriteLine("Logged on user is {0} {1}.", systemUser.GetAttributeValue<string>("firstname"), systemUser.GetAttributeValue<string>("lastname"));

                Entity note = new Entity("");
                note["subject"] = "SMSing";
                note["notetext"] = "Welcome!!";
                note["objectid"] = new EntityReference("", new Guid());
                note[""] = new OptionSetValue();
                SVC.instance.Create(note);
                
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
