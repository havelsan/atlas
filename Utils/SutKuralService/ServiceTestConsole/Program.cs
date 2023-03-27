using Microsoft.Practices.ServiceLocation;
using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using RuleCheckerService;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTestConsole
{

    public interface IRuleCheckerService
    {

        string Echo(string input);
        RuleValidateResultDto ValidateRules(object patientId
            , object episodeId
            , IEnumerable<ProcedureEntryDto> procedureEntries
            , IEnumerable<string> icd10Entries);

        RuleValidateResultDto ValidateRulesForInvoice(object patientId, object episodeId);
    }


    [Export(typeof(IRuleCheckerService))]
    public class RuleCheckerService : IRuleCheckerService
    {
        [Import]
        public IRuleCheckEngine RuleCheckEngine { get; set; }

        public string Echo(string input)
        {
            return input;
        }

        public RuleValidateResultDto ValidateRules(object patientId
            , object episodeId
            , IEnumerable<ProcedureEntryDto> procedureEntries
            , IEnumerable<string> icd10Entries)
        {
            return RuleCheckEngine.ValidateRules(patientId, episodeId, procedureEntries, icd10Entries);
        }

        public RuleValidateResultDto ValidateRulesForInvoice(object patientId
            , object episodeId)
        {
            return RuleCheckEngine.ValidateRulesForInvoice(patientId, episodeId);
        }
    }

    class Program
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static CompositionContainer Container { get; set; }

        static void SetupCompositionContainer()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IRuleCheckEngine).Assembly));
            Container = new CompositionContainer(catalog);

            var mef = new MefServiceLocator(Container);

            ServiceLocator.SetLocatorProvider(() => mef);

        }
        static void CheckRepository()
        {
            /*var repo = new RuleCheckerService.Repositories.OraclePatientProcedureRepository();

            var result = repo.PatientProcedureList("eb6e9c24-b9cd-4932-9c54-85f96d847f28", "615270");
            Console.WriteLine(result.ToString());*/

        }


        static void TestMultiSession(int targetCount)
        {
            var taskList = new List<Task>();

            foreach (var index in Enumerable.Range(1, targetCount))
            {

                var task = Task.Factory.StartNew(() =>
                    {
                        Kural1Kontrol.Kontrol();

                    }, TaskCreationOptions.LongRunning);


                taskList.Add(task);

            }

            Task.WaitAll(taskList.ToArray());

        }

        static void SequentialTest()
        {
            Kural1Kontrol.Kontrol();

            Kural2Kontrol.Kontrol();

            Kural3Kontrol.Kontrol();
        }

        static void Main(string[] args)
        {

            SetupCompositionContainer();

            

            Kural2Kontrol.LocalCheck(Container);


            Console.ReadLine();

        }
    }
}
