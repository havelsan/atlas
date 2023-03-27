
using System;
namespace RuleChecker.Interface.Entities
{
    public class RuleDefDto
    {
        public Guid ObjectId { get; set; }
        public object GroupId { get; set; }
        public string ProcedureCode { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }
        public bool BlockRequest { get; set; }
    }
}
