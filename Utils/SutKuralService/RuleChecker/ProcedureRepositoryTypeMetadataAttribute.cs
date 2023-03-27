
using RuleChecker.Interface;
using System;
using System.ComponentModel.Composition;
namespace RuleChecker
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ProcedureRepositoryTypeMetadataAttribute : ExportAttribute, IProcedureRepositoryTypeMetadata
    {
        private ProcedureRepositoryType _repositoryType;

        public ProcedureRepositoryTypeMetadataAttribute(ProcedureRepositoryType repositoryType)
        {
            _repositoryType = repositoryType;
        }

        public ProcedureRepositoryType RepositoryType
        {
            get
            {
                return _repositoryType;
            }
        }
    }
}
