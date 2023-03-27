using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RuleChecker.Service.Repositories
{
    public class OraclePatientProcedureRepository : IPatientProcedureRepository
    {
        private readonly static string PatientProcedureListSql = @"select s.objectid, PD.SUTCODE, PD.NAME, s.ACTIONDATE, s.AMOUNT, e.objectID, E.OPENINGDATE  from episode e
inner join subactionprocedure s on S.EPISODE = e.objectID
inner join proceduredefinition pd on PD.OBJECTID = s.procedureobject
where e.patient = :PATIENTID
and pd.sutcode = :PROCEDURECODE
and not exists ( select * from ttobjectstatedef d
		where D.STATEDEFID = S.CURRENTSTATEDEFID
		and D.STATUS = '4' )";

        private readonly IRuleCheckerServiceSettings _settings;

        public OraclePatientProcedureRepository(IRuleCheckerServiceSettings settings)
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

        private readonly static string EpisodeProcedureListSql = @"select s.objectid, pd.sutcode, pd.name, s.actiondate, s.amount from subactionprocedure s
inner join proceduredefinition pd on PD.OBJECTID = s.procedureobject
where S.EPISODE = :EPISODEID
and PD.SUTCODE = :PROCEDURECODE
and not exists ( select * from ttobjectstatedef d
		where D.STATEDEFID = S.CURRENTSTATEDEFID
		and D.STATUS = '4' )";

        private readonly static string EpisodeAllProcedureListSql = @"select s.objectid, pd.sutcode, pd.name, s.actiondate, s.amount from subactionprocedure s
inner join proceduredefinition pd on PD.OBJECTID = s.procedureobject
where S.EPISODE = :EPISODEID
and   S.ACTIONDATE > :RULESTARTDATE
and not exists ( select * from ttobjectstatedef d
		where D.STATEDEFID = S.CURRENTSTATEDEFID
		and D.STATUS = '4' )";

        private readonly static string MedulaProvisionApplicationSql = @"select DISTINCT P.MEDULABASVURUNO from subepisodeprotocol P
INNER JOIN SUBEPISODE SE ON P.SUBEPISODE = SE.OBJECTID
WHERE SE.EPISODE = :EPISODEID
";

        private readonly static string MedulaProvisionEpisodeSql = @"select DISTINCT SE.EPISODE from subepisodeprotocol P
INNER JOIN SUBEPISODE SE ON P.SUBEPISODE = SE.OBJECTID
WHERE P.MEDULABASVURUNO = :APPLICATIONNO";

        private readonly static string RuleStartDateSql = @"select value from systemparameter where name = 'SUT_RULE_ENGINE_STARTDATE'";

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
            DateTime ruleStartDate = GetRuleStartDate();

            foreach (var episodeId2 in episodeList)
            {
                var parameters = new[] {
                    new CommandParameter(":EPISODEID", episodeId2, DbType.String),
                    new CommandParameter(":RULESTARTDATE", ruleStartDate, DbType.DateTime)
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

        public DateTime GetRuleStartDate()
        {
            var dataTable = DatabaseManager.ExecuteDataTable(_settings.StoreConnectionString, RuleStartDateSql, null);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["VALUE"] != null)
                {
                    string ruleStartDateParam = Convert.ToString(dataRow["VALUE"]);
                    if (!string.IsNullOrWhiteSpace(ruleStartDateParam))
                    {
                        DateTime ruleStartDate;
                        if (DateTime.TryParse(ruleStartDateParam, out ruleStartDate))
                            return ruleStartDate;
                    }
                }
            }

            return DateTime.MinValue;
        }
    }
}