using RuleChecker.Interface.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace SutKuralService
{
    [ServiceContract]
    public interface IRuleCheckerService
    {

        [OperationContract]
        string Echo(string input);

        [OperationContract]
        RuleValidateResultDto ValidateRules(object patientId
            , object episodeId
            , IEnumerable<ProcedureEntryDto> procedureEntries
            , IEnumerable<string> icd10Entries);

        [OperationContract]
        RuleValidateResultDto ValidateRulesForInvoice(object patientId, object episodeId);
    }
  
}
