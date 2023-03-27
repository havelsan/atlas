using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;

namespace SutKuralService.Repositories
{
	[Export(typeof(IPatientProcedureRepository))]
	public class OraclePatientProcedureRepository : IPatientProcedureRepository
	{
		private readonly static string PatientProcedureListSql = @"select s.objectid, PD.CODE, PD.NAME, s.ACTIONDATE, s.AMOUNT, e.objectID, E.OPENINGDATE  from episode e
left join subactionprocedure s on S.EPISODE = e.objectID
left join proceduredefinition pd on PD.OBJECTID = s.procedureobject
where e.patient = :PATIENTID
and not exists ( select * from ttobjectstatedef d
		where D.STATEDEFID = S.CURRENTSTATEDEFID
		and D.STATUS = '4' )";

		public IEnumerable<ProcedureRequestDetailDto> PatientProcedureList(object patientId, string procedureCode)
		{
			var requestDetailList = new List<ProcedureRequestDetailDto>();

			var parameters = new[] { 
				new CommandParameter(":PATIENTID", patientId, DbType.String),
				new CommandParameter(":PROCEDURECODE", procedureCode, DbType.String),
			};

			using (var reader = DatabaseManager.ExecuteDataReader(PatientProcedureListSql, parameters))
			{
				while (reader.Read())
				{
					var procedureRequestDetail = new ProcedureRequestDetailDto();

					procedureRequestDetail.DetailId = Convert.ToString(reader["OBJECTID"]);
					procedureRequestDetail.ProcedureCode = Convert.ToString(reader["CODE"]);
					procedureRequestDetail.ProcedureName = Convert.ToString(reader["NAME"]);
					procedureRequestDetail.Quantity = Convert.ToDecimal(reader["AMOUNT"]);
					procedureRequestDetail.RequestDate = Convert.ToDateTime(reader["ACTIONDATE"]);

					requestDetailList.Add(procedureRequestDetail);
					
				}
			}

			return requestDetailList;
		}

		private readonly static string EpisodeProcedureListSql = @"select s.objectid, pd.code, pd.name, s.actiondate, s.amount from subactionprocedure s
inner join proceduredefinition pd on PD.OBJECTID = s.procedureobject
where S.EPISODE = :EPISODEID
and PD.CODE = :PROCEDURECODE
and not exists ( select * from ttobjectstatedef d
		where D.STATEDEFID = S.CURRENTSTATEDEFID
		and D.STATUS = '4' )";

		private readonly static string EpisodeAllProcedureListSql = @"select s.objectid, pd.code, pd.name, s.actiondate, s.amount from subactionprocedure s
inner join proceduredefinition pd on PD.OBJECTID = s.procedureobject
where S.EPISODE = :EPISODEID
and not exists ( select * from ttobjectstatedef d
		where D.STATEDEFID = S.CURRENTSTATEDEFID
		and D.STATUS = '4' )";

		private readonly static string MedulaProvisionApplicationSql = @"select DISTINCT P.APPLICATIONNO from medulaprovision p where P.EPISODE = :EPISODEID";

		private readonly static string MedulaProvisionEpisodeSql = @"select DISTINCT p.episode from medulaprovision p where P.APPLICATIONNO = :APPLICATIONNO";

		private IList<string> GetEpisodeList(object episodeId)
		{
			var applicationParameters = new[] { 
				new CommandParameter(":EPISODEID", episodeId, DbType.String),
			};

			var hashSet = new HashSet<string>();

			hashSet.Add(episodeId.ToString());

			object result = DatabaseManager.ExecuteScalar(MedulaProvisionApplicationSql, applicationParameters);

			string medulaApplicationNo = Convert.ToString(result);

			if (!string.IsNullOrWhiteSpace(medulaApplicationNo))
			{

				var provisionEpisodeParameters = new[] { 
					new CommandParameter(":EPISODEID", episodeId, DbType.String),
				};

				var reader = DatabaseManager.ExecuteDataReader(MedulaProvisionEpisodeSql, provisionEpisodeParameters);
				while (reader.Read())
				{
					string episodeId2 = Convert.ToString(reader["EPISODE"]);
					if (!hashSet.Contains(episodeId2))
					{
						hashSet.Add(episodeId2);
					}

				}
			}

			return hashSet.ToList();
		}

		public IEnumerable<ProcedureRequestDetailDto> EpisodeProcedureList(object episodeId, string procedureCode)
		{
			var procedureRequestList = new List<ProcedureRequestDetailDto>();

			var episodeList = GetEpisodeList(episodeId);

			foreach (var episodeId2 in episodeList)
			{

				var parameters = new[] { 
					new CommandParameter(":EPISODEID", episodeId, DbType.String),
					new CommandParameter(":PROCEDURECODE", procedureCode, DbType.String),
				};

				using (var reader = DatabaseManager.ExecuteDataReader(EpisodeProcedureListSql, parameters))
				{
					while (reader.Read())
					{
						var procedureRequestDetail = new ProcedureRequestDetailDto();

						procedureRequestDetail.DetailId = Convert.ToString(reader["OBJECTID"]);
						procedureRequestDetail.ProcedureCode = Convert.ToString(reader["CODE"]);
						procedureRequestDetail.ProcedureName = Convert.ToString(reader["NAME"]);
						procedureRequestDetail.Quantity = Convert.ToDecimal(reader["AMOUNT"]);
						procedureRequestDetail.RequestDate = Convert.ToDateTime(reader["ACTIONDATE"]);

						procedureRequestList.Add(procedureRequestDetail);

					}
				}
			}

			return procedureRequestList;
		}


		public IEnumerable<ProcedureRequestDetailDto> EpisodeProcedureList(object episodeId)
		{
			var procedureRequestList = new List<ProcedureRequestDetailDto>();

			var episodeList = GetEpisodeList(episodeId);

			foreach (var episodeId2 in episodeList)
			{

				var parameters = new[] { 
					new CommandParameter(":EPISODEID", episodeId, DbType.String),
				};

				using (var reader = DatabaseManager.ExecuteDataReader(EpisodeAllProcedureListSql, parameters))
				{
					while (reader.Read())
					{
						var procedureRequestDetail = new ProcedureRequestDetailDto();

						procedureRequestDetail.DetailId = Convert.ToString(reader["OBJECTID"]);
						procedureRequestDetail.ProcedureCode = Convert.ToString(reader["CODE"]);
						procedureRequestDetail.ProcedureName = Convert.ToString(reader["NAME"]);
						procedureRequestDetail.Quantity = Convert.ToDecimal(reader["AMOUNT"]);
						procedureRequestDetail.RequestDate = Convert.ToDateTime(reader["ACTIONDATE"]);

						procedureRequestList.Add(procedureRequestDetail);

					}
				}
			}

			return procedureRequestList;
		}
	}
}