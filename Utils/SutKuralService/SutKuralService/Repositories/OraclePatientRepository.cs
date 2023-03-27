using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.ComponentModel.Composition;
using System.Data;

namespace SutKuralService.Repositories
{
	[Export(typeof(IPatientRepository))]
	public class OraclePatientRepository : IPatientRepository
	{

		public PatientInfoDto GetPatientInfo(object patientId)
		{
			var patientInfo = new PatientInfoDto();
			patientInfo.PatientId = patientId;

			var sql = @"SELECT * FROM PERSON P WHERE OBJECTID = :OBJECTID";

			var parameters = new[] { 
				new CommandParameter(":OBJECTID", patientId, DbType.String),
			};

			using (var reader = DatabaseManager.ExecuteDataReader(sql, parameters))
			{
				if (reader.Read())
				{
					var gender = Convert.ToString(reader["SEX"]);

					if ( gender == "1" )
					{
						patientInfo.Gender = "K";
					}
					else if (gender == "0")
					{
						patientInfo.Gender = "E";
					}

					var birthDate = Convert.ToDateTime(reader["BIRTHDATE"]);

					patientInfo.Age = DateExtensions.DateDiff(DateInterval.Year, DateTime.Now, birthDate);

					patientInfo.AgeMonth  = DateExtensions.DateDiff(DateInterval.Month, DateTime.Now, birthDate);
				}
			}


			return patientInfo;
		}

	}
}
