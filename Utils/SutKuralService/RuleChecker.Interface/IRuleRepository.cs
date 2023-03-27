using RuleChecker.Interface.Entities;
using System.Collections.Generic;

namespace RuleChecker.Interface
{
    public interface IRuleRepository
    {
        IList<RuleDefDto> RuleList();
        IList<RuleGroupDefDto> RuleGroupList();
    }
}
