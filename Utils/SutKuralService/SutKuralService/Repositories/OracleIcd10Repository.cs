using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace SutKuralService.Repositories
{
    [Export(typeof(IIcd10Repository))]
    public class OracleIcd10Repository : IIcd10Repository
    {

        private IList<Icd10DefinitionDto> _icd10List;

        private IList<Icd10DefinitionDto> GetIcd10List()
        {
            if (_icd10List == null)
                _icd10List = LoadIcd10List();

            return _icd10List;
        }

        private IList<Icd10DefinitionDto> LoadIcd10List()
        {
            var icd10List = new List<Icd10DefinitionDto>();

            var sql = "SELECT I.* FROM MEDULAICD10 I";

            using (var reader = DatabaseManager.ExecuteDataReader(sql, null))
            {
                while (reader.Read())
                {
                    var branchDef = new Icd10DefinitionDto
                    {
                        Code = Convert.ToString(reader["TANIKODU"]),
                        Description = Convert.ToString(reader["TANIADI"]),
                    };

                    icd10List.Add(branchDef);
                }
            }

            return icd10List;
        }


        public IEnumerable<Icd10DefinitionDto> Icd10List()
        {
            return GetIcd10List();
        }

    }
}
