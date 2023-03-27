
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
    public  abstract  partial class RuleBase : TTDefinitionSet
    {
        public partial class GetAvailableRules_Class : TTReportNqlObject 
        {
        }

#region Methods
        public class RuleResult
        {
            public string RuleDescription;
            public bool IsWarningOnly;
            public RuleResult(ISUTRulableObject rulableObject, RuleBase rule, string injectionMessage)
            {
                if (rule.IsWarningOnly.HasValue && rule.IsWarningOnly.Value)
                {
                    IsWarningOnly = rule.IsWarningOnly.Value;
                    RuleDescription = rulableObject.GetName() + " için " + rule.WarningMessage;
                }
                else
                {
                    RuleDescription = rulableObject.GetName() + " için " + rule.Result;
                    IsWarningOnly = false;
                }

                if (string.IsNullOrEmpty(injectionMessage) == false)
                    RuleDescription += "\r\n" + injectionMessage;
            }
        }

        virtual public List<RuleBase.RuleResult> RunRule(DateTime actionDate, ISUTInstance currentInstance)
        {
            return new List<RuleBase.RuleResult>();
        }

        abstract public List<ISUTInstance> SubactionProcedures(DateTime actionDate, ISUTInstance currentInstance);

        public bool IsSuitable(DateTime actionDate, ISUTInstance currentInstance)
        {
            bool isSexSuitable = true;
            bool isAgeSuitable = true;
            bool isProcedureSuitable = true;
            bool isProvisionTypeSuitable = true;
            bool isTherapyKindSuitable = true;
            bool isTherapyTypeSuitable = true;
            bool isSocialSecurityTypeSuitable = true;
            bool isDiagnosisSuitable = true;
            bool isSpecialitySuitable = true;

            if (SexConditions.Count > 0)
            {
                isSexSuitable = false;
                foreach (SexCondition sexCondition in SexConditions)
                    isSexSuitable = isSexSuitable || sexCondition.IsSuitable(currentInstance.GetSUTEpisodeAction().SUTEpisode.SUTPatient);
            }
            
            if (AgeConditions.Count > 0)
            {
                isAgeSuitable = false;
                foreach (AgeCondition ageCondition in AgeConditions)
                    isAgeSuitable = isAgeSuitable || ageCondition.IsSuitable(currentInstance.GetSUTEpisodeAction().SUTEpisode.SUTPatient);
            }
            
            if (ProcedureConditions.Count > 0)
            {
                isProcedureSuitable = false;
                bool isEqualProcedureConditionsSuitable = true;
                bool isNotEqualProcedureConditionsSuitable = true;

                IList equalProcedureConditions = ProcedureConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.Equal);
                if (equalProcedureConditions.Count > 0)
                {
                    isEqualProcedureConditionsSuitable = false;
                    foreach (ProcedureCondition procedureCondition in equalProcedureConditions)
                        isEqualProcedureConditionsSuitable = isEqualProcedureConditionsSuitable || procedureCondition.IsSuitable(SubactionProcedures(actionDate, currentInstance));
                }

                IList notEqualProcedureConditions = ProcedureConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.NotEqual);
                if (notEqualProcedureConditions.Count > 0)
                {
                    isNotEqualProcedureConditionsSuitable = true;
                    foreach (ProcedureCondition procedureCondition in notEqualProcedureConditions)
                        isNotEqualProcedureConditionsSuitable = isNotEqualProcedureConditionsSuitable && procedureCondition.IsSuitable(SubactionProcedures(actionDate, currentInstance));
                }

                isProcedureSuitable = isEqualProcedureConditionsSuitable && isNotEqualProcedureConditionsSuitable;
            }

            if (ProvisionTypeConditions.Count > 0)
            {
                isProvisionTypeSuitable = false;
                bool isEqualProvisionTypeConditionsSuitable = true;
                bool isNotEqualProvisionTypeConditionsSuitable = true;

                IList equalProvisionTypeConditions = ProvisionTypeConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.Equal);
                if (equalProvisionTypeConditions.Count > 0)
                {
                    isEqualProvisionTypeConditionsSuitable = false;
                    foreach (ProvisionTypeCondition provisionTypeCondition in equalProvisionTypeConditions)
                        isEqualProvisionTypeConditionsSuitable = isEqualProvisionTypeConditionsSuitable || provisionTypeCondition.IsSuitable(currentInstance.GetSUTEpisodeAction());
                }
                
                IList notEqualProvisionTypeConditions = ProvisionTypeConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.NotEqual);
                if (notEqualProvisionTypeConditions.Count > 0)
                {
                    isNotEqualProvisionTypeConditionsSuitable = true;
                    foreach (ProvisionTypeCondition provisionTypeCondition in notEqualProvisionTypeConditions)
                        isNotEqualProvisionTypeConditionsSuitable = isNotEqualProvisionTypeConditionsSuitable && provisionTypeCondition.IsSuitable(currentInstance.GetSUTEpisodeAction());
                }

                isProvisionTypeSuitable = isEqualProvisionTypeConditionsSuitable && isNotEqualProvisionTypeConditionsSuitable;
            }
            
            if (TherapyKindConditions.Count > 0)
            {
                isTherapyKindSuitable = false;
                bool isEqualTherapyKindConditionsSuitable = true;
                bool isNotEqualTherapyKindConditionsSuitable = true;

                IList equalTherapyKindConditions = TherapyKindConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.Equal);
                if (equalTherapyKindConditions.Count > 0)
                {
                    isEqualTherapyKindConditionsSuitable = false;
                    foreach (TherapyKindCondition therapyKindCondition in equalTherapyKindConditions)
                        isEqualTherapyKindConditionsSuitable = isEqualTherapyKindConditionsSuitable || therapyKindCondition.IsSuitable(currentInstance.GetSUTEpisodeAction());
                }

                IList notEqualTherapyKindConditions = TherapyKindConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.NotEqual);
                if (notEqualTherapyKindConditions.Count > 0)
                {
                    isNotEqualTherapyKindConditionsSuitable = true;
                    foreach (TherapyKindCondition therapyKindCondition in notEqualTherapyKindConditions)
                        isNotEqualTherapyKindConditionsSuitable = isNotEqualTherapyKindConditionsSuitable && therapyKindCondition.IsSuitable(currentInstance.GetSUTEpisodeAction());
                }

                isTherapyKindSuitable = isEqualTherapyKindConditionsSuitable && isNotEqualTherapyKindConditionsSuitable;
            }

            if (TherapyTypeConditions.Count > 0)
            {
                isTherapyTypeSuitable = false;
                bool isEqualTherapyTypeConditionsSuitable = true;
                bool isNotEqualTherapyTypeConditionsSuitable = true;

                IList equalTherapyTypeConditions = TherapyTypeConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.Equal);
                if (equalTherapyTypeConditions.Count > 0)
                {
                    isEqualTherapyTypeConditionsSuitable = false;
                    foreach (TherapyTypeCondition therapyTypeCondition in equalTherapyTypeConditions)
                        isEqualTherapyTypeConditionsSuitable = isEqualTherapyTypeConditionsSuitable || therapyTypeCondition.IsSuitable(currentInstance.GetSUTEpisodeAction());
                }

                IList notEqualTherapyTypeConditions = TherapyTypeConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.NotEqual);
                if (notEqualTherapyTypeConditions.Count > 0)
                {
                    isNotEqualTherapyTypeConditionsSuitable = true;
                    foreach (TherapyTypeCondition therapyTypeCondition in notEqualTherapyTypeConditions)
                        isNotEqualTherapyTypeConditionsSuitable = isNotEqualTherapyTypeConditionsSuitable && therapyTypeCondition.IsSuitable(currentInstance.GetSUTEpisodeAction());
                }

                isTherapyTypeSuitable = isEqualTherapyTypeConditionsSuitable && isNotEqualTherapyTypeConditionsSuitable;
            }

            if (SocialSecurityTypeConditions.Count > 0)
            {
                isSocialSecurityTypeSuitable = false;
                bool isEqualSocialSecurityTypeConditionsSuitable = true;
                bool isNotEqualSocialSecurityTypeConditionsSuitable = true;

                IList equalSocialSecurityTypeConditions = SocialSecurityTypeConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.Equal);
                if (equalSocialSecurityTypeConditions.Count > 0)
                {
                    isEqualSocialSecurityTypeConditionsSuitable = false;
                    foreach (SocialSecurityTypeCondition socialSecurityTypeCondition in equalSocialSecurityTypeConditions)
                        isEqualSocialSecurityTypeConditionsSuitable = isEqualSocialSecurityTypeConditionsSuitable || socialSecurityTypeCondition.IsSuitable(currentInstance.GetSUTEpisodeAction());
                }

                IList notEqualSocialSecurityTypeConditions = SocialSecurityTypeConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.NotEqual);
                if (notEqualSocialSecurityTypeConditions.Count > 0)
                {
                    isNotEqualSocialSecurityTypeConditionsSuitable = true;
                    foreach (SocialSecurityTypeCondition socialSecurityTypeCondition in notEqualSocialSecurityTypeConditions)
                        isNotEqualSocialSecurityTypeConditionsSuitable = isNotEqualSocialSecurityTypeConditionsSuitable && socialSecurityTypeCondition.IsSuitable(currentInstance.GetSUTEpisodeAction());
                }

                isSocialSecurityTypeSuitable = isEqualSocialSecurityTypeConditionsSuitable && isNotEqualSocialSecurityTypeConditionsSuitable;
            }

            if (DiagnosisConditions.Count > 0)
            {
                isDiagnosisSuitable = false;
                bool isEqualDiagnosisConditionsSuitable = true;
                bool isNotEqualDiagnosisConditionsSuitable = true;

                IList equalDiagnosisConditions = DiagnosisConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.Equal);
                if (equalDiagnosisConditions.Count > 0)
                {
                    isEqualDiagnosisConditionsSuitable = false;
                    foreach (DiagnosisCondition diagnosisCondition in equalDiagnosisConditions)
                        isEqualDiagnosisConditionsSuitable = isEqualDiagnosisConditionsSuitable || diagnosisCondition.IsSuitable(currentInstance.GetSUTEpisodeAction().SUTEpisode.SUTDiagnosisGrid());
                }

                IList notEqualDiagnosisConditions = DiagnosisConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.NotEqual);
                if (notEqualDiagnosisConditions.Count > 0)
                {
                    isNotEqualDiagnosisConditionsSuitable = true;
                    foreach (DiagnosisCondition diagnosisCondition in notEqualDiagnosisConditions)
                        isNotEqualDiagnosisConditionsSuitable = isNotEqualDiagnosisConditionsSuitable && diagnosisCondition.IsSuitable(currentInstance.GetSUTEpisodeAction().SUTEpisode.SUTDiagnosisGrid());
                }

                isDiagnosisSuitable = isEqualDiagnosisConditionsSuitable && isNotEqualDiagnosisConditionsSuitable;
            }


            if (SpecialityConditions.Count > 0)
            {
                isSpecialitySuitable = false;
                bool isEqualSpecialityConditionsSuitable = true;
                bool isNotEqualSpecialityConditionsSuitable = true;

                IList equalSpecialityConditions = SpecialityConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.Equal);
                if (equalSpecialityConditions.Count > 0)
                {
                    isEqualSpecialityConditionsSuitable = false;
                    foreach (SpecialityCondition specialityCondition in equalSpecialityConditions)
                        isEqualSpecialityConditionsSuitable = isEqualSpecialityConditionsSuitable || specialityCondition.IsSuitable(currentInstance);
                }

                IList notEqualSpecialityConditions = SpecialityConditions.Select("OPERATORTYPE = " + (int)OperatorTypeEnum.NotEqual);
                if (notEqualSpecialityConditions.Count > 0)
                {
                    isNotEqualSpecialityConditionsSuitable = true;
                    foreach (SpecialityCondition specialityCondition in notEqualSpecialityConditions)
                        isNotEqualSpecialityConditionsSuitable = isNotEqualSpecialityConditionsSuitable && specialityCondition.IsSuitable(currentInstance);
                }

                isSpecialitySuitable = isEqualSpecialityConditionsSuitable && isNotEqualSpecialityConditionsSuitable;
            }


            bool isSuitable = isSexSuitable && isAgeSuitable && isProcedureSuitable && isProvisionTypeSuitable && isTherapyKindSuitable && isTherapyTypeSuitable && isSocialSecurityTypeSuitable && isDiagnosisSuitable && isSpecialitySuitable;
            return  isSuitable && IsPayable.Value;
        }
        
#endregion Methods

    }
}