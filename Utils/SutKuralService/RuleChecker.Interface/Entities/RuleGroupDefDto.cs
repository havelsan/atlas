using System;

namespace RuleChecker.Interface.Entities
{
    public class RuleGroupDefDto
    {
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public bool BlockRequest { get; set; }
    }
}
