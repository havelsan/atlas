using RuleChecker.Interface.Entities;
using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace ServiceTestConsole
{
    class Kural5Kontrol
    {

        internal static void LocalCheck(CompositionContainer Container)
        {

            var sutKuralService = Container.GetExportedValue<IRuleCheckerService>();

            var patientId = "2905e6f4-fc5e-460a-8b70-98daa5061801";
            //"eb6e9c24-b9cd-4932-9c54-85f96d847f28";

            var episodeId = "f74ecf4a-a537-4a6d-9d0f-9c4a237b39dc";
            //"8479b57d-5372-44e4-8ad9-72d89802b854";

            var procedureEntries = new ProcedureEntryDto[] {
                new ProcedureEntryDto() {
                     EntryDate = DateTime.Now,
                     EntryQuantity = 1,
                     ProcedureCode = "530880",
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
            RemotingHelper.RegisterClientChannel();

            var sutKuralService = RemotingHelper.GetService();

            var echoResult = sutKuralService.Echo("OK");

            var patientId = "8a775df6-c471-4838-b272-94a9e82d3ad0";
            //"eb6e9c24-b9cd-4932-9c54-85f96d847f28";

            var episodeId = "fe90e557-c53c-463f-86d4-043144be0a38";
            //"8479b57d-5372-44e4-8ad9-72d89802b854";

            var procedureEntries = new TTUtils.Entities.ProcedureEntryDto[] { 
                new TTUtils.Entities.ProcedureEntryDto() {
                     EntryDate = DateTime.Now,
                     EntryQuantity = 1,
                     ProcedureCode = "530560",
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
