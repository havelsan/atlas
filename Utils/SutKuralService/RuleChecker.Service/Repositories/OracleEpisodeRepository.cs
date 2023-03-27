using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RuleChecker.Service.Repositories
{
	public class OracleEpisodeRepository : IEpisodeRepository
	{
		private readonly IRuleCheckerServiceSettings _settings;

		public OracleEpisodeRepository(IRuleCheckerServiceSettings settings)
		{
			_settings = settings;
		}

		public EpisodeInfoDto GetEpisodeInfo(object episodeId)
		{
			var episodeInfoDto = new EpisodeInfoDto();

			var sql = @"SELECT E.OBJECTID, S.CODE
FROM EPISODE E
LEFT JOIN SPECIALITYDEFINITION S ON E.MAINSPECIALITY = S.OBJECTID
WHERE E.OBJECTID = :OBJETCID
";
			var parameters = new[] { 
				new CommandParameter(":OBJECTID", episodeId, DbType.String),
			};

			var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, parameters);

			DataRow dataRow = dataTable.Rows.OfType<DataRow>().FirstOrDefault();

			if (dataRow != null)
			{
				episodeInfoDto.EpisodeId = Convert.ToString(dataRow["OBJECTID"]);
				episodeInfoDto.BranchCode = Convert.ToString(dataRow["CODE"]);
			}

			return episodeInfoDto;
		}

		public System.Collections.Generic.IList<string> GetEpisodeIcd10DiagnosisList(object episodeId)
		{

			var sql = @"SELECT G.DIAGNOSEDATE, DEF.CODE FROM DIAGNOSISGRID G
INNER JOIN DIAGNOSISDEFINITION DEF ON DEF.OBJECTID = G.DIAGNOSE
WHERE G.EPISODE = :EPISODEID";
			var parameters = new[] { 
				new CommandParameter(":EPISODEID", episodeId, DbType.String),
			};

			var icd10List = new List<string>();

			var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, sql, parameters);

			foreach (DataRow dataRow in dataTable.Rows)
			{
				string icd10Code = Convert.ToString(dataRow["CODE"]);
				icd10List.Add(icd10Code);
			}

			return icd10List;

		}

	}
}
