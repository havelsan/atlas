using RuleChecker.Interface.Entities;
using System.Collections.Generic;

namespace RuleChecker.Interface
{
    public interface IBranchRepository
    {
        BranchDefinitionDto BranchInfo(string branchCode);
        IList<BranchDefinitionDto> BranchList(IEnumerable<string> branchCodes);
    }

}
