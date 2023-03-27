using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace SutKuralService.Repositories
{
    [Export(typeof(IBranchRepository))]
    public class OracleBranchRepository : IBranchRepository
    {
        private IList<BranchDefinitionDto> _branchList;

        private IList<BranchDefinitionDto> GetBranchList()
        {
            if (_branchList == null)
                _branchList = LoadBranchList();

            return _branchList;
        }

        private IList<BranchDefinitionDto> LoadBranchList()
        {
            var branchList = new List<BranchDefinitionDto>();

            var sql = "SELECT B.* FROM BRANS B";

            using (var reader = DatabaseManager.ExecuteDataReader(sql, null))
            {
                while (reader.Read())
                {
                    var branchDef = new BranchDefinitionDto
                    {
                        Code = Convert.ToString(reader["BRANSKODU"]),
                        Name = Convert.ToString(reader["BRANSADI"]),
                    };

                    branchList.Add(branchDef);
                }
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
