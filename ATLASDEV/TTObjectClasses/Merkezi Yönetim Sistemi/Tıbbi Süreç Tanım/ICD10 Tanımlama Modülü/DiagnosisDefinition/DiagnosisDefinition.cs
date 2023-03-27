
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Tanı
    /// </summary>
    public partial class DiagnosisDefinition : TerminologyManagerDef, ISUTRulableDiagnosis, ITTListTreeObject
    {
        public partial class GetDiagnosisDefinition_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_DiagnosisDefinition_Class : TTReportNqlObject
        {
        }

        public partial class GetDiagnosisDefinitionByDiagnosisCode_Class : TTReportNqlObject
        {
        }

        /// <summary>
        /// Bildirimi Zounlu
        /// </summary>
        public string DeclerationMustTR
        {
            get
            {
                try
                {
                    #region DeclerationMustTR_GetScript                    
                    string s = null;
                    if (DeclerationMust == true)
                        s = TTUtils.CultureService.GetText("M14018", "Evet");
                    else
                        s = TTUtils.CultureService.GetText("M15570", "Hayır");
                    return s;
                    #endregion DeclerationMustTR_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "DeclerationMustTR") + " : " + ex.Message, ex);
                }
            }
        }

        #region Methods
        public override string ToString()
        {
            return Code + " " + Name;
        }

        bool ITTListObject.IsSelectable
        {
            get
            {
                return ((ITTListTreeObject)this).IsLeaf;
            }
        }

        bool ITTListTreeObject.IsLeaf
        {
            get
            {
                if (IsLeaf.HasValue)
                    return IsLeaf.Value;
                return false;
            }
        }

        public bool GetIsRuleExist()
        {
            if (DiagnosisRuleSets.Select(string.Empty).Count > 0)
                return true;
            else
                return false;
        }

        public bool DeclerationMust
        {
            get
            {
                if (InfectiousIllnesesInfoGroup.HasValue)
                    return true;
                else
                    return false;
            }
        }


        public List<RuleBase> GetSuitableRules(DateTime actionDate, ISUTInstance currentInstance)
        {
            List<RuleBase> retValue = new List<RuleBase>();
            foreach (RuleBase rule in GetAvailableRules(actionDate))
            {
                if (rule.IsActive.HasValue && rule.IsActive.Value)
                {
                    if (rule.IsSuitable(actionDate, currentInstance))
                        retValue.Add(rule);
                }
            }
            return retValue;
        }

        public List<RuleBase> GetAvailableRules(DateTime actionDate)
        {
            List<RuleBase> retValue = new List<RuleBase>();
            TTObjectContext readOnlyObjectContext = new TTObjectContext(true);
            IList ruleObjectIDs = RuleBase.GetAvailableRules(readOnlyObjectContext, actionDate, " AND RULESETRULES.RULESET.DIAGNOSISRULESETS.DIAGNOSIS = " + ConnectionManager.GuidToString(ObjectID));
            if (ruleObjectIDs.Count > 0)
            {
                string filterExpression = string.Empty;
                filterExpression += " WHERE OBJECTID IN(";
                int i = 1;
                foreach (RuleBase.GetAvailableRules_Class o in ruleObjectIDs)
                {
                    if (o.Ruleobjectid.HasValue)
                    {
                        filterExpression += ConnectionManager.GuidToString(o.Ruleobjectid.Value);
                        if (i < ruleObjectIDs.Count)
                            filterExpression += ",";
                    }
                    i++;
                }
                filterExpression += ")";
                retValue.AddRange(RuleBase.GetRules(readOnlyObjectContext, filterExpression));
            }
            return retValue;
        }


        public List<RuleBase.RuleResult> RunRules(DateTime actionDate, ISUTInstance currentInstance)
        {
            List<RuleBase.RuleResult> ruleResults = new List<RuleBase.RuleResult>();

            if (GetIsRuleExist())
            {
                List<RuleBase> suitableRules = GetSuitableRules(actionDate, currentInstance);
                if (suitableRules.Count > 0)
                {
                    foreach (RuleBase ruleBase in suitableRules)
                        ruleResults.AddRange(ruleBase.RunRule(actionDate, currentInstance));
                }
                else
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    GlobalRule globalRule = new GlobalRule(objectContext);
                    globalRule.IsWarningOnly = false;
                    globalRule.Name = "TANI BULUNAMAYAN UYGUN KURAL";
                    globalRule.Result = TTUtils.CultureService.GetText("M27043", "Tanıya ait ödemeye uygun kural bulunamadığından işleme devam edemezsiniz.");

                    foreach (RuleBase rule in GetAvailableRules(actionDate))
                        globalRule.Result += "\r\n" + rule.Result;

                    globalRule.IsActive = true;

                    ruleResults.Add(new RuleBase.RuleResult(this, globalRule, string.Empty));
                }
            }

            return ruleResults;
        }

        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.DiagnosisDefinitionInfo;
        }

        public override BaseSKRSDefinition GetSKRSDefinition()
        {
            BindingList<SKRSICD> SKRSICDList = SKRSICD.GetByKodu(ObjectContext, Code);
            if (SKRSICDList.Count > 0)
                return SKRSICDList[0];
            return null;
        }

        public MedulaDiagnosisDefinition GetMedulaDiagnosisDefinition()
        {
            List<MedulaDiagnosisDefinition> medulaDiagnosisDefinitions = MedulaDiagnosisDefinition.GetDiagnosisByCode(ObjectContext, Code).ToList();
            if (medulaDiagnosisDefinitions.Count > 0)
                return medulaDiagnosisDefinitions[0];
            return null;
        }

        public string GetName()
        {
            return Name;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }

        protected override void PreInsert()
        {
            base.PreInsert();

            if(this.SendSms == true && this.SMSText == null || this.SMSText == "")
            {
                throw new TTException("SMS Gönderilecek Seçilen Tanıları Kaydetmek İçin SMS Metni Girilmelidir.");
            }

            Common.SohaRuleRuleRepositoryChanged(ObjectContext, SohaRuleRepoTypeEnum.ICD10Repository);
        }

        protected override void PreUpdate()
        {
            base.PreUpdate();

            if (this.SendSms == true && this.SMSText == null || this.SMSText == "")
            {
                throw new TTException("SMS Gönderilecek Seçilen Tanıları Kaydetmek İçin SMS Metni Girilmelidir.");
            }

            if (this.HasMemberChanged("NAME") || this.HasMemberChanged("CODE"))
                Common.SohaRuleRuleRepositoryChanged(ObjectContext, SohaRuleRepoTypeEnum.ICD10Repository);
        }

        #endregion Methods

    }
}