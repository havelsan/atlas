using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RuleChecker.Service.Repositories
{
    public class OracleRuleRepository : IRuleRepository
    {
        private readonly IRuleCheckerServiceSettings _settings;
        private DateTime? LastUpdate { get; set; } = null;

        public OracleRuleRepository(IRuleCheckerServiceSettings settings)
        {
            _settings = settings;
        }
        private IList<RuleDefDto> GetRules()
        {
            DateTime? definitionLastUpdateDate = null;

            var sql = "SELECT UPDATEDATE FROM SOHARULEREPOUPDATE WHERE REPOSITORYTYPE = 0";

            var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, null);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                definitionLastUpdateDate = Convert.ToDateTime(dataRow["UPDATEDATE"]);
            }

            if (_ruleList == null || LastUpdate.HasValue == false || (LastUpdate.HasValue && definitionLastUpdateDate > LastUpdate.Value))
            {
                _ruleList = LoadRules();
                LastUpdate = definitionLastUpdateDate;
            }

            return _ruleList;
        }

        private IList<RuleDefDto> LoadRules()
        {
            var ruleList = new List<RuleDefDto>();

            var sql = @"SELECT R.* FROM SOHARULE R
            WHERE ACTIVE = '1' AND PERFORMANCE = '0' AND ISDELETED = 0";

            var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, null);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var ruleDef = new RuleDefDto
                {
                    ObjectId = new Guid(Convert.ToString(dataRow["OBJECTID"])),
                    GroupId = Convert.ToString(dataRow["RULEGROUP"]),
                    ProcedureCode = Convert.ToString(dataRow["PROCEDURECODE"]),
                    Content = Convert.ToString(dataRow["CONTENT"]),
                    Active = Convert.ToString(dataRow["ACTIVE"]) == "1",
                    BlockRequest = Convert.ToBoolean(dataRow["BLOCKREQUEST"])
                };

                ruleList.Add(ruleDef);
            }

            return ruleList;
        }

        private IList<RuleGroupDefDto> GetRuleGroups()
        {
            if (_ruleGroupList == null)
                _ruleGroupList = LoadRuleGroups();

            return _ruleGroupList;
        }

        private IList<RuleGroupDefDto> LoadRuleGroups()
        {
            var ruleList = new List<RuleGroupDefDto>();

            var sql = @"SELECT R.* FROM SOHARULEGROUP R";

            var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, null);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var ruleDef = new RuleGroupDefDto
                {
                    ObjectId = new Guid( Convert.ToString(dataRow["OBJECTID"])),
                    Name = Convert.ToString(dataRow["NAME"]),
                    Description = Convert.ToString(dataRow["DESCRIPTION"]),
                    //BlockRequest = Convert.ToString(dataRow["BLOCKREQUEST"]) == "1",
                };

                ruleList.Add(ruleDef);
            }

            return ruleList;
        }

        private IList<RuleDefDto> _ruleList = null;

        private IList<RuleGroupDefDto> _ruleGroupList = null;

        public IList<RuleDefDto> RuleList()
        {
            return GetRules();
        }

        public IList<RuleGroupDefDto> RuleGroupList()
        {
            return GetRuleGroups();
        }

        public void InitRepository()
        {
            _ruleList = LoadRules();
            _ruleGroupList = LoadRuleGroups();
        }
    }
}
