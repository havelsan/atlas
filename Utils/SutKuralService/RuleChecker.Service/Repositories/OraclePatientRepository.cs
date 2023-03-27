using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Data;
using System.Linq;

namespace RuleChecker.Service.Repositories
{
	public class OraclePatientRepository : IPatientRepository
	{

		private readonly IRuleCheckerServiceSettings _settings;

		public OraclePatientRepository(IRuleCheckerServiceSettings settings)
		{
			_settings = settings;
		}

		public PatientInfoDto GetPatientInfo(object patientId)
		{
			var patientInfo = new PatientInfoDto();
			patientInfo.PatientId = patientId;

            var sql = @"SELECT P.OBJECTID, P.BIRTHDATE, S.KODU FROM PERSON P, SKRSCINSIYET_V S WHERE
P.SEX = S.OBJECTID
AND P.OBJECTID = :OBJECTID";

            var parameters = new[] { 
				new CommandParameter(":OBJECTID", patientId, DbType.String),
			};

			var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, parameters);

			var dataRow = dataTable.Rows.OfType<DataRow>().FirstOrDefault();

            if (dataRow != null)
            {
                var gender = Convert.ToString(dataRow["KODU"]);

                if (gender == "1")
                {
                    patientInfo.Gender = "E";
                }
                else if (gender == "2")
                {
                    patientInfo.Gender = "K";
                }

                var birthDate = Convert.ToDateTime(dataRow["BIRTHDATE"]);

                patientInfo.Age = DateExtensions.DateDiff(DateInterval.Year, DateTime.Now, birthDate);

                patientInfo.AgeMonth = DateExtensions.DateDiff(DateInterval.Month, DateTime.Now, birthDate);
            }


            return patientInfo;
		}

	}
}
