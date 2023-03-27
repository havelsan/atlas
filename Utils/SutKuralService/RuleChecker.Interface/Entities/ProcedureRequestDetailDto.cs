using System;

namespace RuleChecker.Interface.Entities
{
    public class ProcedureRequestDetailDto
    {
        public object LocalId { get; set; }
        public object DetailId { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureName { get; set; }
        public DateTime RequestDate { get; set; }
        public string BranchCode { get; set; }
        public decimal Quantity { get; set; }
    }
}
