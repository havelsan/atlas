using System;
using TTUtils.Entities;

namespace RuleChecker.Interface
{
    public interface IRuleChecker
    {
        void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback);
    }
}
