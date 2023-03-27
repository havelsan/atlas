using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TTUtils;
using TTUtils.Entities;

namespace RuleChecker.Engine
{
    public class RuleCheckEngine : IRuleCheckEngine
    {
        private readonly IRuleSetLoader _ruleSetLoader;
        private readonly IPatientRepository _patientRepository;
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IIcd10Repository _icd10Repository;
        private readonly IRuleRepository _ruleRepository;
        private readonly IProcedureRepository _procedureRepository;
        private readonly IPatientProcedureRepository _patientProcedureRepository;
        private readonly IInvoicePatientProcedureRepository _invoicePatientProcedureRepository;

        public RuleCheckEngine(IRuleSetLoader ruleSetLoader
           , IPatientRepository patientRepository
           , IEpisodeRepository episodeRepository
           , IBranchRepository branchRepository
           , IIcd10Repository icd10Repository
           , IRuleRepository ruleRepository
           , IProcedureRepository procedureRepository
           , IPatientProcedureRepository patientProcedureRepository
           , IInvoicePatientProcedureRepository invoicePatientProcedureRepository)
        {
            _ruleSetLoader = ruleSetLoader;
            _patientRepository = patientRepository;
            _episodeRepository = episodeRepository;
            _branchRepository = branchRepository;
            _icd10Repository = icd10Repository;
            _ruleRepository = ruleRepository;
            _procedureRepository = procedureRepository;
            _patientProcedureRepository = patientProcedureRepository;
            _invoicePatientProcedureRepository = invoicePatientProcedureRepository;
        }

        private RuleCheckParameters BuildRuleCheckParameters(object patientId
            , object episodeId
            , ProcedureRepositoryType procRepositoryType)
        {
            var ruleCheckParameters = new RuleCheckParameters
            {
                RuleCheckDate = DateTime.Now,
                BranchRepository = _branchRepository,
                Icd10Repository = _icd10Repository,
                ProcedureRepository = _procedureRepository,
                PatientProcedureRepository = GetPatientProcedureRepository(procRepositoryType),

                PatientInfo = _patientRepository.GetPatientInfo(patientId),
                EpisodeInfo = _episodeRepository.GetEpisodeInfo(episodeId)
            };

            BuildPatientIcd10DiagnosisList(episodeId, ruleCheckParameters);

            return ruleCheckParameters;
        }

        private IPatientProcedureRepository GetPatientProcedureRepository(ProcedureRepositoryType repositoryType)
        {
            if (repositoryType == ProcedureRepositoryType.PatientNewRequest)
                return _patientProcedureRepository;

            if (repositoryType == ProcedureRepositoryType.InvoiceSohaCheck)
                return _invoicePatientProcedureRepository;

            return null;
        }

        private void BuildPatientIcd10DiagnosisList(object episodeId, RuleCheckParameters ruleCheckParameters)
        {
            ruleCheckParameters.EpisodeInfo = _episodeRepository.GetEpisodeInfo(episodeId);
            ruleCheckParameters.PatientIcd10DiagnosisList = _episodeRepository.GetEpisodeIcd10DiagnosisList(episodeId);
        }

        private void SetDetailLocalId(IList<ProcedureRequestDetailDto> detailList)
        {
            foreach (var detail in detailList)
            {
                detail.LocalId = detail.DetailId ?? (object)Guid.NewGuid();
            }
        }

        public RuleValidateResultDto ValidateRules(object patientId
            , object episodeId
            , IEnumerable<ProcedureEntryDto> procedureEntries
            , IEnumerable<string> icd10Entries)
        {

            var ruleViolateMessageList = new List<RuleViolateMessage>();

            var ruleSet = _ruleSetLoader.RuleSet;

            var ruleCheckParameters = BuildRuleCheckParameters(patientId, episodeId, ProcedureRepositoryType.PatientNewRequest);

            var detailList = new List<ProcedureRequestDetailDto>();

            var newEntries = BuildNewInputEntries(ruleCheckParameters, episodeId, procedureEntries);

            ruleCheckParameters.NewEntries = newEntries;

            detailList.AddRange(newEntries);

            var episodeDetailList = ruleCheckParameters.PatientProcedureRepository.EpisodeProcedureList(episodeId);

            detailList.AddRange(episodeDetailList);

            ruleCheckParameters.DetailList = detailList;

            SetDetailLocalId(detailList);

            var targetRules = FilterRules(newEntries, ruleSet);

            foreach (var ruleChecker in targetRules)
            {
                ruleChecker.CheckRule(ruleCheckParameters, (m) =>
                    {
                        // İlgili satırlardan herhangi biri yeni girilen detaya ait ise listeye eklencek
                        // Eski satırlar için kural seti devreye alınmadan önceki girişler olabilir
                        //if (m.DetailId1 == null || m.DetailId2 == null)
                        //{
                            ruleViolateMessageList.Add(m);
                        //}
                    });
            }

            var ruleList = _ruleRepository.RuleList();

            var query = from m in ruleViolateMessageList
                        from rl in ruleList
                        where rl.ObjectId == m.RuleId && rl.BlockRequest
                        select rl;

            var validateResult = new RuleValidateResultDto
            {
                Messages = ruleViolateMessageList,
                BlockRequest = query.Any(),
            };

            return validateResult;
        }

        public RuleValidateResultDto ValidateRulesForInvoice(object patientId
            , object episodeId)
        {

            var ruleViolateMessageList = new List<RuleViolateMessage>();

            var ruleSet = _ruleSetLoader.RuleSet;

            var ruleCheckParameters = BuildRuleCheckParameters(patientId, episodeId, ProcedureRepositoryType.InvoiceSohaCheck);

            var detailList = new List<ProcedureRequestDetailDto>();

            var episodeDetailList = ruleCheckParameters.PatientProcedureRepository.EpisodeProcedureList(episodeId);

            detailList.AddRange(episodeDetailList);

            ruleCheckParameters.DetailList = detailList;

            var targetRules = FilterRules(episodeDetailList, ruleSet);

            foreach (var ruleChecker in targetRules)
            {
                ruleChecker.CheckRule(ruleCheckParameters, (m) =>
                {
                    ruleViolateMessageList.Add(m);
                });
            }

            var ruleList = _ruleRepository.RuleList();

            var query = from m in ruleViolateMessageList
                        from rl in ruleList
                        where rl.ObjectId == m.RuleId && rl.BlockRequest
                        select rl;


            var validateResult = new RuleValidateResultDto
            {
                Messages = ruleViolateMessageList,
                BlockRequest = query.Any(),
            };

            return validateResult;
        }

        private IList<IRuleChecker> FilterRules(IEnumerable<ProcedureRequestDetailDto> newEntries, IRuleSet ruleSet)
        {
            var procedureCodes = newEntries.Select(e => e.ProcedureCode).ToList();

            var query = from r in ruleSet.Rules.OfType<IRule>()
                        where procedureCodes.Contains(r.ProcedureCode)
                        select r;

            return query.OfType<IRuleChecker>().ToList();
        }


        private IList<ProcedureRequestDetailDto> BuildNewInputEntries(RuleCheckParameters ruleCheckParameters
            , object episodeId
            , IEnumerable<ProcedureEntryDto> procedureEntries)
        {

            var procedureRepository = ruleCheckParameters.ProcedureRepository;

            var procedureNameList = procedureRepository.ProcedureList(procedureEntries.Select(p => p.ProcedureCode));

            string getProcedureName(string code)
            {
                var query1 = from p in procedureNameList
                             where p.SutCode == code
                             select p;

                var procedureDef = query1.FirstOrDefault();

                if (procedureDef != null)
                    return procedureDef.Name;

                return string.Empty;
            }

            var queryNewEntries = from p in procedureEntries
                                  select new ProcedureRequestDetailDto
                                  {
                                      DetailId = null,
                                      BranchCode = string.Empty,
                                      ProcedureCode = p.ProcedureCode,
                                      ProcedureName = getProcedureName(p.ProcedureCode),
                                      Quantity = p.EntryQuantity,
                                      RequestDate = p.EntryDate,
                                  };

            return queryNewEntries.ToList();
        }

    }
}
