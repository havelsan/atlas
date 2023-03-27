using RuleChecker.Interface.Entities;
using System.Collections.Generic;

namespace RuleChecker.Interface
{
    public interface IProcedureRepository
    {
        IList<ProcedureDefinitionDto> ProcedureList(IEnumerable<string> procedureCodes);
    }
}
