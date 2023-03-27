using System.Collections.Generic;

namespace RuleChecker.Interface.Entities
{
    public class RuleValidateResultDto
    {
        public bool BlockRequest { get; set; }
        public IList<RuleViolateMessage> Messages { get; set; }
    }
}
