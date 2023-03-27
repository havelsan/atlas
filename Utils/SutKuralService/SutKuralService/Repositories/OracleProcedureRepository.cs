using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace SutKuralService.Repositories
{
    [Export(typeof(IProcedureRepository))]
    public class OracleProcedureRepository : IProcedureRepository
    {
        private IList<ProcedureDefinitionDto> _procedureList;

        private IList<ProcedureDefinitionDto> GetProcedureList()
        {
            if (_procedureList == null)
                _procedureList = LoadProcedureList();

            return _procedureList;
        }

        private IList<ProcedureDefinitionDto> LoadProcedureList()
        {
            var procedureList = new List<ProcedureDefinitionDto>();

            var sql = "SELECT P.* FROM PROCEDUREDEFINITION P";

            using (var reader = DatabaseManager.ExecuteDataReader(sql, null))
            {
                while (reader.Read())
                {
                    var branchDef = new ProcedureDefinitionDto
                    {
                        Code = Convert.ToString(reader["CODE"]),
                        Name = Convert.ToString(reader["NAME"]),
                    };

                    procedureList.Add(branchDef);
                }
            }

            return procedureList;
        }

        public IList<ProcedureDefinitionDto> ProcedureList(IEnumerable<string> procedureCodes)
        {
            var query = from p in GetProcedureList()
                        where procedureCodes.Contains(p.Code)
                        select p;

            return query.ToList();
        }

    }
}
