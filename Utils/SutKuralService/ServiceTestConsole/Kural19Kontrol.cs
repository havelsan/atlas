using Microsoft.Practices.ServiceLocation;
using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;

namespace ServiceTestConsole
{
    class Kural19Kontrol
    {
        internal static void Kontrol()
        {


            IRuleCheckEngine ruleCheckEngine = ServiceLocator.Current.GetInstance<IRuleCheckEngine>();

            var patientId = ConfigurationManager.AppSettings["patientId"];
            //"eb6e9c24-b9cd-4932-9c54-85f96d847f28";

            var episodeId = ConfigurationManager.AppSettings["episodeId"];
            //"8479b57d-5372-44e4-8ad9-72d89802b854";

            var procedureEntries = new ProcedureEntryDto[] { 
                new ProcedureEntryDto() {
                     EntryDate = new DateTime(2013,10,1),
                     EntryQuantity = 1,
                     ProcedureCode = "P407350",
                },
                new ProcedureEntryDto() {
                     EntryDate = new DateTime(2013,6,1),
                     EntryQuantity = 1,
                     ProcedureCode = "P407350",
                },
                new ProcedureEntryDto() {
                     EntryDate = new DateTime(2013,1,1),
                     EntryQuantity = 1,
                     ProcedureCode = "P407350",
                },
            };

            var result = ruleCheckEngine.ValidateRules(patientId, episodeId, procedureEntries, null);

            foreach (var item in result.Messages)
            {
                Console.WriteLine(item.Message);
            }

            Console.WriteLine(result.Messages.Count());

        }

    }
}
