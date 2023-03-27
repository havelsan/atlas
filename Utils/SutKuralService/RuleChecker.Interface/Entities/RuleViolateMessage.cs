using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RuleChecker.Interface.Entities
{
    public class RuleViolateMessage
    {
        public RuleViolateMessage()
        {
        }

        public RuleViolateMessage(Guid ruleId, Guid ruleGroupId, string sutKodu, string mesaj, bool blockRequest)
        {
            RuleId = ruleId;
            RuleGroupId = ruleGroupId;
            ProcedureCode = sutKodu;
            Message = string.Format("{0}-{1}", sutKodu, mesaj);
            BlockRequest = blockRequest;
        }

        public RuleViolateMessage(Guid ruleId, Guid ruleGroupId, string procedureCode, string message, List<string> icd10List, bool blockRequest)
        {
            RuleId = ruleId;
            RuleGroupId = ruleGroupId;
            ProcedureCode = procedureCode;
            Message = string.Format("{0}-{1}", procedureCode, message);
            Icd10List = icd10List;
            BlockRequest = blockRequest;
        }

        public Guid RuleId { get; set; }

        public Guid RuleGroupId { get; set; }

        public string ProcedureCode { get; set; }

        public string Message { get; set; }

        public object DetailId1 { get; set; }

        public object DetailId2 { get; set; }

        public bool BlockRequest { get; set; }

        public List<string> Icd10List { get; set; }

    }
}
