using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RuleChecker.Service.Repositories
{
    public class OracleProcedureRepository : IProcedureRepository
    {
        private IList<ProcedureDefinitionDto> _procedureList;

        private DateTime? LastUpdate { get; set; } = null;

        private readonly IRuleCheckerServiceSettings _settings;

        public OracleProcedureRepository(IRuleCheckerServiceSettings settings)
        {
            _settings = settings;
        }

        private IList<ProcedureDefinitionDto> GetProcedureList()
        {
            //TODO Yeni  tablodan prosedür için tarih çekilecek

            DateTime? definitionLastUpdateDate = null;

            var sql = "SELECT UPDATEDATE FROM SOHARULEREPOUPDATE WHERE REPOSITORYTYPE = 1";

            var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, null);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                definitionLastUpdateDate = Convert.ToDateTime(dataRow["UPDATEDATE"]);
            }

            if (_procedureList == null || LastUpdate.HasValue == false || (LastUpdate.HasValue && definitionLastUpdateDate > LastUpdate.Value))
            {
                _procedureList = LoadProcedureList();
                LastUpdate = definitionLastUpdateDate;
            }

            return _procedureList;
        }

        private IList<ProcedureDefinitionDto> LoadProcedureList()
        {
            var procedureList = new List<ProcedureDefinitionDto>();

            var sql = "SELECT P.* FROM PROCEDUREDEFINITION_V P WHERE ISACTIVE = 1 ORDER BY CODE";

            var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, null);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var branchDef = new ProcedureDefinitionDto
                {
                    SutCode = Convert.ToString(dataRow["SUTCODE"]),
                    Name = Convert.ToString(dataRow["NAME"]),
                };

                procedureList.Add(branchDef);
            }

            return procedureList;
        }

        public IList<ProcedureDefinitionDto> ProcedureList(IEnumerable<string> procedureCodes)
        {
            var query = from p in GetProcedureList()
                        where procedureCodes.Contains(p.SutCode)
                        select p;

            return query.ToList();
        }

    }
}
