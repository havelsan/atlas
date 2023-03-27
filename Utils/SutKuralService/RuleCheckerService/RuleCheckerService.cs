using Microsoft.Practices.ServiceLocation;
using Oracle.ManagedDataAccess.Client;
using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TTUtils;

namespace RuleCheckerService
{
    public class RuleCheckerService : MarshalByRefObject, ISutKuralService
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void CheckException(Exception ex)
        {
            OracleException oracleEx = ex as OracleException;

            if (oracleEx == null)
                return;

            // iletişim kanalında dosya sonu hatası
            // bu durumda ConnectionPool boşaltılacak
            if (oracleEx.Number == 3113)
            {
                OracleConnection.ClearAllPools();
            }
        }

        public TTUtils.Entities.RuleValidateResultDto ValidateRules(object patientId, object episodeId
            , TTUtils.Entities.ProcedureEntryDto[] procedureEntries
            , string[] icd10Entries)
        {

            try
            {

                IRuleCheckEngine ruleCheckEngine = ServiceLocator.Current.GetInstance<IRuleCheckEngine>();

                var inputParams = from p in procedureEntries
                                  select new ProcedureEntryDto
                                  {
                                      ProcedureCode = p.ProcedureCode,
                                      EntryDate = p.EntryDate,
                                      EntryQuantity = p.EntryQuantity,
                                      SubActionProcedureId = p.SubActionprocedureId,
                                  };

                var iparams = inputParams.ToArray();

                var validateResult = ruleCheckEngine.ValidateRules(patientId
                  , episodeId
                  , iparams
                  , icd10Entries);

                var outParams = new List<TTUtils.Entities.RuleViolateMessageDto>();

                foreach (var outItem in validateResult.Messages)
                {
                    var message = new TTUtils.Entities.RuleViolateMessageDto
                    {
                        RuleId = outItem.RuleId,
                        RuleGroupId = outItem.RuleGroupId,
                        ProcedureCode = outItem.ProcedureCode,
                        Message = outItem.Message,
                        DetailId1 = outItem.DetailId1,
                        DetailId2 = outItem.DetailId2,
                    };

                    if (outItem.Icd10List != null)
                    {
                        message.Icd10List = outItem.Icd10List.ToArray();
                    }

                    outParams.Add(message);

                }

                var ruleValidateResult = new TTUtils.Entities.RuleValidateResultDto()
                {
                    Messages = outParams.ToArray(),
                    BlockRequest = validateResult.BlockRequest,
                };

                return ruleValidateResult;

            }
            catch (Exception ex)
            {
                log.Error(ex);
                // oracle hatası server tarafından deserialize edilemiyor
                // bu yüzden hata ttexception'a dönüştürülüyor
                throw new TTException(ex.Message);
            }
        }

        public TTUtils.Entities.RuleValidateResultDto ValidateRulesForInvoice(object patientId, object episodeId)
        {
            try
            {

                IRuleCheckEngine ruleCheckEngine = ServiceLocator.Current.GetInstance<IRuleCheckEngine>();

                var validateResult = ruleCheckEngine.ValidateRulesForInvoice(patientId
                  , episodeId);

                var outParams = new List<TTUtils.Entities.RuleViolateMessageDto>();

                foreach (var outItem in validateResult.Messages)
                {
                    var message = new TTUtils.Entities.RuleViolateMessageDto
                    {
                        RuleId = outItem.RuleId,
                        RuleGroupId = outItem.RuleGroupId,
                        ProcedureCode = outItem.ProcedureCode,
                        Message = outItem.Message,
                        DetailId1 = outItem.DetailId1,
                        DetailId2 = outItem.DetailId2,
                    };

                    if (outItem.Icd10List != null)
                    {
                        message.Icd10List = outItem.Icd10List.ToArray();
                    }

                    outParams.Add(message);

                }

                var ruleValidateResult = new TTUtils.Entities.RuleValidateResultDto()
                {
                    Messages = outParams.ToArray(),
                    BlockRequest = validateResult.BlockRequest,
                };

                return ruleValidateResult;

            }
            catch (Exception ex)
            {
                log.Error(ex);
                // oracle hatası server tarafından deserialize edilemiyor
                // bu yüzden hata ttexception'a dönüştürülüyor
                throw new TTException(ex.Message);
            }

        }
        public string Echo(string message)
        {
            return message;
        }

    }
}
