using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace RuleChecker.Service.Repositories
{
    public class OracleIcd10Repository : IIcd10Repository
    {
        private readonly IRuleCheckerServiceSettings _settings;
        private DateTime? LastUpdate { get; set; } = null;

        public OracleIcd10Repository(IRuleCheckerServiceSettings settings)
        {
            _settings = settings;
        }


        private IList<Icd10DefinitionDto> _icd10List;

        private IList<Icd10DefinitionDto> GetIcd10List()
        {
            DateTime? definitionLastUpdateDate = null;

            var sql = "SELECT UPDATEDATE FROM SOHARULEREPOUPDATE WHERE REPOSITORYTYPE = 3";

            var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, null);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                definitionLastUpdateDate = Convert.ToDateTime(dataRow["UPDATEDATE"]);
            }

            if (_icd10List == null || LastUpdate.HasValue == false || (LastUpdate.HasValue && definitionLastUpdateDate > LastUpdate.Value))
            {
                _icd10List = LoadIcd10List();
                LastUpdate = definitionLastUpdateDate;
            }

            return _icd10List;
        }

        private IList<Icd10DefinitionDto> LoadIcd10List()
        {
            var icd10List = new List<Icd10DefinitionDto>();

            var sql = "SELECT I.* FROM DIAGNOSISDEFINITION I";

            var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, null);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var branchDef = new Icd10DefinitionDto
                {
                    Code = Convert.ToString(dataRow["CODE"]),
                    Description = Convert.ToString(dataRow["NAME"]),
                };

                icd10List.Add(branchDef);
            }

            return icd10List;
        }


        public IEnumerable<Icd10DefinitionDto> Icd10List()
        {
            return GetIcd10List();
        }

    }
}
