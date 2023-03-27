using System;

namespace RuleChecker.Interface
{
    public interface IRule
    {
        Guid ObjectId { get; set; }
        Guid GroupId { get; set; }
        string ProcedureCode { get; set; }
        bool BlockRequest { get; set; }
        bool Active { get; set; }
    }
}
