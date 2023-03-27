using RuleChecker.Interface.Entities;
using System.Collections.Generic;

namespace RuleChecker.Interface
{
    public interface IIcd10Repository
    {
        IEnumerable<Icd10DefinitionDto> Icd10List();
    }
}
