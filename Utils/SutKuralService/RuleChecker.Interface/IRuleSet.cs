using System.Collections.Generic;

namespace RuleChecker.Interface
{
    public interface IRuleSet
    {
        List<object> Rules { get; }
    }
}
