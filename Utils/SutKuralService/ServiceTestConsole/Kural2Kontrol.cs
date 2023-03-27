using RuleChecker.Interface.Entities;
using System;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Linq;


namespace ServiceTestConsole
{
    class Kural2Kontrol
    {
        internal static void LocalCheck(CompositionContainer Container)
        {

            var sutKuralService = Container.GetExportedValue<IRuleCheckerService>();

            var patientId = "bfa8a2a8-34b7-4f23-8a7e-5dd944acdf00";
            //"eb6e9c24-b9cd-4932-9c54-85f96d847f28";

            var episodeId = "52311bc5-2fba-46b4-a641-10b194536c66";
            //"8479b57d-5372-44e4-8ad9-72d89802b854";

            var procedureEntries = new ProcedureEntryDto[] {
                new ProcedureEntryDto() {
                     EntryDate = DateTime.Now,
                     EntryQuantity = 1,
                     ProcedureCode = "701610",
                },
            };

            var result = sutKuralService.ValidateRules(patientId, episodeId, procedureEntries, null);

            foreach (var item in result.Messages)
            {
                Console.WriteLine(item.Message);
            }


            Console.WriteLine(result.Messages.Count());
        }


        internal static void Kontrol()
        {

            var sutKuralService = RemotingHelper.GetService();

            var echoResult = sutKuralService.Echo("OK");

            var patientId = ConfigurationManager.AppSettings["patientId"];
            //"eb6e9c24-b9cd-4932-9c54-85f96d847f28";

            var episodeId = ConfigurationManager.AppSettings["episodeId"];
            //"8479b57d-5372-44e4-8ad9-72d89802b854";

            var procedureEntries = new TTUtils.Entities.ProcedureEntryDto[] { 
                new TTUtils.Entities.ProcedureEntryDto() {
                     EntryDate = DateTime.Now,
                     EntryQuantity = 1,
                     ProcedureCode = "550050",
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
