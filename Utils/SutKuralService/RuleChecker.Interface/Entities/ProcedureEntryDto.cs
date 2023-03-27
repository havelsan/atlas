using System;

namespace RuleChecker.Interface.Entities
{
    public class ProcedureEntryDto
    {
        public string ProcedureCode { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal EntryQuantity { get; set; }
        public Guid SubActionProcedureId { get; set; }
    }
}
