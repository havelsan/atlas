using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace SutKuralService.Repositories
{
    [Export(typeof(IRuleRepository))]
    public class OracleRuleRepository : IRuleRepository
    {

        private IList<RuleDefDto> GetRules()
        {
            if (_ruleList == null)
                _ruleList = LoadRules();

            return _ruleList;
        }

        private IList<RuleDefDto> LoadRules()
        {
            var ruleList = new List<RuleDefDto>();

            var sql = "SELECT R.* FROM TTSOHARULE R";

            using (var reader = DatabaseManager.ExecuteDataReader(sql, null))
            {
                while (reader.Read())
                {
                    var ruleDef = new RuleDefDto
                    {
                        ObjectId = new Guid( Convert.ToString(reader["OBJECTID"]) ),
                        GroupId = Convert.ToString(reader["GROUPID"]),
                        ProcedureCode = Convert.ToString(reader["PROCEDURECODE"]),
                        Content = Convert.ToString(reader["CONTENT"]),
                        Active = Convert.ToString(reader["ACTIVE"]) == "1",
                    };

                    ruleList.Add(ruleDef);
                }
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

            var sql = @"SELECT R.* FROM TTSOHARULEGROUP R";

            using (var reader = DatabaseManager.ExecuteDataReader(sql, null))
            {
                while (reader.Read())
                {
                    var ruleDef = new RuleGroupDefDto
                    {
                        ObjectId = new Guid( Convert.ToString(reader["OBJECTID"]) ),
                        Name = Convert.ToString(reader["NAME"]),
                        Description = Convert.ToString(reader["DESCRIPTION"]),
                        BlockRequest = Convert.ToString(reader["BLOCKREQUEST"]) == "1",
                    };

                    ruleList.Add(ruleDef);
                }
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
