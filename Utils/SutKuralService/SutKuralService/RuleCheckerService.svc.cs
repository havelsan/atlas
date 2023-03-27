using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace SutKuralService
{
    [Export(typeof(IRuleCheckerService))]
    [MefBehavior]
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
}
