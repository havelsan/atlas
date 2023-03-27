using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using TTUtils;
using TTUtils.Entities;

namespace ServiceTestConsole
{
    class Kural1Kontrol
    {
        internal static void Kontrol()
        {

            var sutKuralService = RemotingHelper.GetService();

            var echoResult = sutKuralService.Echo("OK");

            var patientId = ConfigurationManager.AppSettings["patientId"];
            //"eb6e9c24-b9cd-4932-9c54-85f96d847f28";

            var episodeId = ConfigurationManager.AppSettings["episodeId"];
            //"8479b57d-5372-44e4-8ad9-72d89802b854";

            var procedureEntries = new ProcedureEntryDto[] { 
                new ProcedureEntryDto() {
                     EntryDate = DateTime.Now,
                     EntryQuantity = 1,
                     ProcedureCode = "615270",
                },
                new ProcedureEntryDto() {
                     EntryDate = DateTime.Now,
                     EntryQuantity = 1,
                     ProcedureCode = "615280",
                },
            };

            var result = sutKuralService.ValidateRules(patientId, episodeId, procedureEntries, null);

            foreach (var item in result.Messages)
            {
                Console.WriteLine(item.Message);
            }

            Console.WriteLine(result.Messages.Count());

        }

    }
}
