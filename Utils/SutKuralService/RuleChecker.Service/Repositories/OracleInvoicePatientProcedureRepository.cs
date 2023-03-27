using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RuleChecker.Service.Repositories
{
	public class OracleInvoicePatientProcedureRepository : IInvoicePatientProcedureRepository
	{
        private readonly static string PatientProcedureListSql = @"select t.objectid, pd.sutcode, pd.name, t.transactiondate as actiondate, t.amount, e.objectid, e.openingdate
from episode e
inner join subactionprocedure s on s.episode = e.objectid
inner join proceduredefinition pd on pd.objectid = s.procedureobject
inner join accounttransaction t on t.subactionprocedure = s.objectid
INNER JOIN accountpayablereceivable apr on t.accountpayablereceivable = apr.objectid
where e.patient = :PATIENTID
and pd.sutcode = :PROCEDURECODE
and t.currentstatedefid not in ( '4aa5b60f-96cb-4d02-900a-1195b87e24a2', '33784c3f-d601-49c4-b8da-6fa502f6a9cf' )
and apr.type = '1'
and exists( select 'X' from subepisodeprotocol sep
  inner join PAYERDEFINITION pd on sep.PAYER = pd.OBJECTID
  inner join PAYERTYPEDEFINITION ptd on pd.TYPE = ptd.OBJECTID
  where sep.OBJECTID = t.SUBEPISODEPROTOCOL
  and ptd.PAYERTYPE = 0 )
";
		private readonly IRuleCheckerServiceSettings _settings;

		public OracleInvoicePatientProcedureRepository(IRuleCheckerServiceSettings settings)
		{
			_settings = settings;
		}

		public IEnumerable<ProcedureRequestDetailDto> PatientProcedureList(object patientId, string procedureCode)
		{
			var requestDetailList = new List<ProcedureRequestDetailDto>();

			var parameters = new[] { 
				new CommandParameter(":PATIENTID", patientId, DbType.String),
				new CommandParameter(":PROCEDURECODE", procedureCode, DbType.String),
			};

			var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, PatientProcedureListSql, parameters);

			foreach (DataRow dataRow in dataTable.Rows)
			{
				var procedureRequestDetail = new ProcedureRequestDetailDto();

				procedureRequestDetail.DetailId = Convert.ToString(dataRow["OBJECTID"]);
				procedureRequestDetail.ProcedureCode = Convert.ToString(dataRow["SUTCODE"]);
				procedureRequestDetail.ProcedureName = Convert.ToString(dataRow["NAME"]);
				procedureRequestDetail.Quantity = Convert.ToDecimal(dataRow["AMOUNT"]);
				procedureRequestDetail.RequestDate = Convert.ToDateTime(dataRow["ACTIONDATE"]);

				requestDetailList.Add(procedureRequestDetail);

			}

			return requestDetailList;
		}

		private readonly static string EpisodeProcedureListSql = @"select t.objectid, pd.sutcode, pd.name, t.transactiondate as actiondate, t.amount from subactionprocedure s
inner join proceduredefinition pd on pd.objectid = s.procedureobject
inner join accounttransaction t on t.subactionprocedure = s.objectid
inner join accountpayablereceivable apr on t.accountpayablereceivable = apr.objectid
where s.episode = :EPISODEID
and pd.sutcode = :PROCEDURECODE
and t.currentstatedefid not in ( '4aa5b60f-96cb-4d02-900a-1195b87e24a2', '33784c3f-d601-49c4-b8da-6fa502f6a9cf' )
and apr.type = '1'
";

		private readonly static string EpisodeAllProcedureListSql = @"select t.objectid, pd.sutcode, pd.name, t.transactiondate as actiondate, t.amount from subactionprocedure s
inner join proceduredefinition pd on pd.objectid = s.procedureobject
inner join accounttransaction t on t.subactionprocedure = s.objectid
inner join accountpayablereceivable apr on t.accountpayablereceivable = apr.objectid
where s.episode = :EPISODEID
and t.currentstatedefid not in ( '4aa5b60f-96cb-4d02-900a-1195b87e24a2', '33784c3f-d601-49c4-b8da-6fa502f6a9cf' )
and apr.type = '1'
";

		private readonly static string MedulaProvisionApplicationSql = @"select DISTINCT P.MEDULABASVURUNO from subepisodeprotocol P
INNER JOIN SUBEPISODE SE ON P.SUBEPISODE = SE.OBJECTID
WHERE SE.EPISODE = :EPISODEID
";

		private readonly static string MedulaProvisionEpisodeSql = @"select DISTINCT SE.EPISODE from subepisodeprotocol P
INNER JOIN SUBEPISODE SE ON P.SUBEPISODE = SE.OBJECTID
WHERE P.MEDULABASVURUNO = :APPLICATIONNO";

		private IList<string> GetEpisodeList(object episodeId)
		{
			var applicationParameters = new[] { 
				new CommandParameter(":EPISODEID", episodeId, DbType.String),
			};

			var hashSet = new HashSet<string>();

			hashSet.Add(episodeId.ToString());

			object result = DatabaseManager.ExecuteScalar(_settings.StoreConnectionString, MedulaProvisionApplicationSql, applicationParameters);

			string medulaApplicationNo = Convert.ToString(result);

			if (!string.IsNullOrWhiteSpace(medulaApplicationNo))
			{

				var provisionEpisodeParameters = new[] { 
					new CommandParameter(":EPISODEID", episodeId, DbType.String),
				};

				var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, MedulaProvisionEpisodeSql, provisionEpisodeParameters);

				foreach (DataRow dataRow in dataTable.Rows)
				{
					string episodeId2 = Convert.ToString(dataRow["EPISODE"]);
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
					new CommandParameter(":EPISODEID", episodeId2, DbType.String),
					new CommandParameter(":PROCEDURECODE", procedureCode, DbType.String),
				};

				var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, EpisodeProcedureListSql, parameters);

				foreach (DataRow dataRow in dataTable.Rows)
				{
					var procedureRequestDetail = new ProcedureRequestDetailDto();

					procedureRequestDetail.DetailId = Convert.ToString(dataRow["OBJECTID"]);
					procedureRequestDetail.ProcedureCode = Convert.ToString(dataRow["SUTCODE"]);
					procedureRequestDetail.ProcedureName = Convert.ToString(dataRow["NAME"]);
					procedureRequestDetail.Quantity = Convert.ToDecimal(dataRow["AMOUNT"]);
					procedureRequestDetail.RequestDate = Convert.ToDateTime(dataRow["ACTIONDATE"]);

					procedureRequestList.Add(procedureRequestDetail);
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
					new CommandParameter(":EPISODEID", episodeId2, DbType.String),
				};

				var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, EpisodeAllProcedureListSql, parameters);

				foreach (DataRow dataRow in dataTable.Rows)
				{
					var procedureRequestDetail = new ProcedureRequestDetailDto();

					procedureRequestDetail.DetailId = Convert.ToString(dataRow["OBJECTID"]);
					procedureRequestDetail.ProcedureCode = Convert.ToString(dataRow["SUTCODE"]);
					procedureRequestDetail.ProcedureName = Convert.ToString(dataRow["NAME"]);
					procedureRequestDetail.Quantity = Convert.ToDecimal(dataRow["AMOUNT"]);
					procedureRequestDetail.RequestDate = Convert.ToDateTime(dataRow["ACTIONDATE"]);

					procedureRequestList.Add(procedureRequestDetail);
				}
			}

			return procedureRequestList;
		}
	}
}