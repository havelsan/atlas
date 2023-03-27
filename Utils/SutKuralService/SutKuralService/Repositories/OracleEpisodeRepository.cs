using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;

namespace SutKuralService.Repositories
{
    [Export(typeof(IEpisodeRepository))]
	public class OracleEpisodeRepository : IEpisodeRepository
	{
public EpisodeInfoDto GetEpisodeInfo(object episodeId)
		{
			var episodeInfoDto = new EpisodeInfoDto();

			var sql = @"SELECT A.OBJECTID,
COALESCE(C.BRANS, P.BRANS) GSSBRANS
FROM EPISODEACTION A
LEFT JOIN RESCLINIC C ON A.MASTERRESOURCE = C.OBJECTID
LEFT JOIN RESPOLICLINIC P ON A.MASTERRESOURCE = P.OBJECTID
WHERE A.OBJECTID = :OBJETCID
";
			var parameters = new[] { 
				new CommandParameter(":OBJECTID", episodeId, DbType.String),
			};

			using (var reader = DatabaseManager.ExecuteDataReader(sql, parameters))
			{
				if (reader.Read())
				{
					episodeInfoDto.EpisodeId = Convert.ToString(reader["OBJECTID"]);
					episodeInfoDto.BranchCode = Convert.ToString(reader["GSSBRANS"]);
				}
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

			using (var reader = DatabaseManager.ExecuteDataReader(sql, parameters))
			{
				var icd10List = new List<string>();

				while (reader.Read())
				{
					string icd10Code = Convert.ToString(reader["CODE"]);
					icd10List.Add(icd10Code);
				}

				return icd10List;
			}
		}

	}
}
