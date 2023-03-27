using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RuleChecker.Service.Repositories
{
    public class OracleBranchRepository : IBranchRepository
    {
        private IList<BranchDefinitionDto> _branchList;

        private readonly IRuleCheckerServiceSettings _settings;
        private DateTime? LastUpdate { get; set; } = null;
        public OracleBranchRepository(IRuleCheckerServiceSettings settings)
        {
            _settings = settings;
        }

        private IList<BranchDefinitionDto> GetBranchList()
        {
            DateTime? definitionLastUpdateDate = null;

            var sql = "SELECT UPDATEDATE FROM SOHARULEREPOUPDATE WHERE REPOSITORYTYPE = 2";

            var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, null);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                definitionLastUpdateDate = Convert.ToDateTime(dataRow["UPDATEDATE"]);
            }

            if (_branchList == null || LastUpdate.HasValue == false || (LastUpdate.HasValue && definitionLastUpdateDate > LastUpdate.Value))
            {
                _branchList = LoadBranchList();
                LastUpdate = definitionLastUpdateDate;
            }

            return _branchList;
        }

        private IList<BranchDefinitionDto> LoadBranchList()
        {
            var branchList = new List<BranchDefinitionDto>();

            var sql = "SELECT S.* FROM SPECIALITYDEFINITION S";

            var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, null);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var branchDef = new BranchDefinitionDto
                {
                    Code = Convert.ToString(dataRow["CODE"]),
                    Name = Convert.ToString(dataRow["NAME"]),
                };

                branchList.Add(branchDef);
            }

            return branchList;
        }

        public BranchDefinitionDto BranchInfo(string branchCode)
        {
            var query = from b in GetBranchList()
                        where b.Code == branchCode
                        select b;

            return query.FirstOrDefault();
        }

        public IList<BranchDefinitionDto> BranchList(IEnumerable<string> branchCodes)
        {
            var query = from b in GetBranchList()
                        where branchCodes.Contains(b.Code)
                        select b;

            return query.ToList();
        }

    }
}
