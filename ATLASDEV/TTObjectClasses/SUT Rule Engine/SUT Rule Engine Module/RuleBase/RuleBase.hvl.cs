
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RuleBase")] 

    public  abstract  partial class RuleBase : TTDefinitionSet
    {
        public class RuleBaseList : TTObjectCollection<RuleBase> { }
                    
        public class ChildRuleBaseCollection : TTObject.TTChildObjectCollection<RuleBase>
        {
            public ChildRuleBaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRuleBaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAvailableRules_Class : TTReportNqlObject 
        {
            public Guid? Ruleobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RULEOBJECTID"]);
                }
            }

            public GetAvailableRules_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAvailableRules_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAvailableRules_Class() : base() { }
        }

        public static BindingList<RuleBase> GetRules(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RULEBASE"].QueryDefs["GetRules"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RuleBase>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<RuleBase.GetAvailableRules_Class> GetAvailableRules(DateTime ACTIONDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RULEBASE"].QueryDefs["GetAvailableRules"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONDATE", ACTIONDATE);

            return TTReportNqlObject.QueryObjects<RuleBase.GetAvailableRules_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RuleBase.GetAvailableRules_Class> GetAvailableRules(TTObjectContext objectContext, DateTime ACTIONDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RULEBASE"].QueryDefs["GetAvailableRules"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONDATE", ACTIONDATE);

            return TTReportNqlObject.QueryObjects<RuleBase.GetAvailableRules_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Sonuç Açıklaması
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

    /// <summary>
    /// Yalnızca Uyarı
    /// </summary>
        public bool? IsWarningOnly
        {
            get { return (bool?)this["ISWARNINGONLY"]; }
            set { this["ISWARNINGONLY"] = value; }
        }

    /// <summary>
    /// Ödenir / Ödenmez
    /// </summary>
        public bool? IsPayable
        {
            get { return (bool?)this["ISPAYABLE"]; }
            set { this["ISPAYABLE"] = value; }
        }

    /// <summary>
    /// Öncelik
    /// </summary>
        public RulePriorityEnum? RulePriority
        {
            get { return (RulePriorityEnum?)(int?)this["RULEPRIORITY"]; }
            set { this["RULEPRIORITY"] = value; }
        }

    /// <summary>
    /// Kural Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Uyarı Mesajı
    /// </summary>
        public string WarningMessage
        {
            get { return (string)this["WARNINGMESSAGE"]; }
            set { this["WARNINGMESSAGE"] = value; }
        }

        virtual protected void CreateRuleSetRulesCollection()
        {
            _RuleSetRules = new RuleSetRule.ChildRuleSetRuleCollection(this, new Guid("7e5ba40d-da76-4e3c-bf7e-45c514f778f4"));
            ((ITTChildObjectCollection)_RuleSetRules).GetChildren();
        }

        protected RuleSetRule.ChildRuleSetRuleCollection _RuleSetRules = null;
    /// <summary>
    /// Child collection for Kural
    /// </summary>
        public RuleSetRule.ChildRuleSetRuleCollection RuleSetRules
        {
            get
            {
                if (_RuleSetRules == null)
                    CreateRuleSetRulesCollection();
                return _RuleSetRules;
            }
        }

        virtual protected void CreateRuleConditionsCollectionViews()
        {
            _AgeConditions = new AgeCondition.ChildAgeConditionCollection(_RuleConditions, "AgeConditions");
            _DiagnosisConditions = new DiagnosisCondition.ChildDiagnosisConditionCollection(_RuleConditions, "DiagnosisConditions");
            _SpecialityConditions = new SpecialityCondition.ChildSpecialityConditionCollection(_RuleConditions, "SpecialityConditions");
            _TherapyTypeConditions = new TherapyTypeCondition.ChildTherapyTypeConditionCollection(_RuleConditions, "TherapyTypeConditions");
            _SpecialDiagnosisConditions = new SpecialDiagnosisCondition.ChildSpecialDiagnosisConditionCollection(_RuleConditions, "SpecialDiagnosisConditions");
            _ProvisionTypeConditions = new ProvisionTypeCondition.ChildProvisionTypeConditionCollection(_RuleConditions, "ProvisionTypeConditions");
            _SocialSecurityTypeConditions = new SocialSecurityTypeCondition.ChildSocialSecurityTypeConditionCollection(_RuleConditions, "SocialSecurityTypeConditions");
            _HealthCommitteeReportConditions = new HealthCommitteeReportCondition.ChildHealthCommitteeReportConditionCollection(_RuleConditions, "HealthCommitteeReportConditions");
            _TherapyKindConditions = new TherapyKindCondition.ChildTherapyKindConditionCollection(_RuleConditions, "TherapyKindConditions");
            _SexConditions = new SexCondition.ChildSexConditionCollection(_RuleConditions, "SexConditions");
            _ProcedureConditions = new ProcedureCondition.ChildProcedureConditionCollection(_RuleConditions, "ProcedureConditions");
        }

        virtual protected void CreateRuleConditionsCollection()
        {
            _RuleConditions = new RuleConditionBase.ChildRuleConditionBaseCollection(this, new Guid("f57ff431-b64d-4c42-a05b-fc08733ad47f"));
            CreateRuleConditionsCollectionViews();
            ((ITTChildObjectCollection)_RuleConditions).GetChildren();
        }

        protected RuleConditionBase.ChildRuleConditionBaseCollection _RuleConditions = null;
    /// <summary>
    /// Child collection for Kural-Kural Koşulları
    /// </summary>
        public RuleConditionBase.ChildRuleConditionBaseCollection RuleConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _RuleConditions;
            }
        }

        private AgeCondition.ChildAgeConditionCollection _AgeConditions = null;
    /// <summary>
    /// Kural Koşulları
    /// </summary>
        public AgeCondition.ChildAgeConditionCollection AgeConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _AgeConditions;
            }            
        }

        private DiagnosisCondition.ChildDiagnosisConditionCollection _DiagnosisConditions = null;
    /// <summary>
    /// Kural Koşulları
    /// </summary>
        public DiagnosisCondition.ChildDiagnosisConditionCollection DiagnosisConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _DiagnosisConditions;
            }            
        }

        private SpecialityCondition.ChildSpecialityConditionCollection _SpecialityConditions = null;
    /// <summary>
    /// Kural Koşulları
    /// </summary>
        public SpecialityCondition.ChildSpecialityConditionCollection SpecialityConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _SpecialityConditions;
            }            
        }

        private TherapyTypeCondition.ChildTherapyTypeConditionCollection _TherapyTypeConditions = null;
    /// <summary>
    /// Kural Koşulları
    /// </summary>
        public TherapyTypeCondition.ChildTherapyTypeConditionCollection TherapyTypeConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _TherapyTypeConditions;
            }            
        }

        private SpecialDiagnosisCondition.ChildSpecialDiagnosisConditionCollection _SpecialDiagnosisConditions = null;
    /// <summary>
    /// Kural Koşulları
    /// </summary>
        public SpecialDiagnosisCondition.ChildSpecialDiagnosisConditionCollection SpecialDiagnosisConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _SpecialDiagnosisConditions;
            }            
        }

        private ProvisionTypeCondition.ChildProvisionTypeConditionCollection _ProvisionTypeConditions = null;
    /// <summary>
    /// Kural Koşulları
    /// </summary>
        public ProvisionTypeCondition.ChildProvisionTypeConditionCollection ProvisionTypeConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _ProvisionTypeConditions;
            }            
        }

        private SocialSecurityTypeCondition.ChildSocialSecurityTypeConditionCollection _SocialSecurityTypeConditions = null;
    /// <summary>
    /// Kural Koşulları
    /// </summary>
        public SocialSecurityTypeCondition.ChildSocialSecurityTypeConditionCollection SocialSecurityTypeConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _SocialSecurityTypeConditions;
            }            
        }

        private HealthCommitteeReportCondition.ChildHealthCommitteeReportConditionCollection _HealthCommitteeReportConditions = null;
    /// <summary>
    /// Kural Koşulları
    /// </summary>
        public HealthCommitteeReportCondition.ChildHealthCommitteeReportConditionCollection HealthCommitteeReportConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _HealthCommitteeReportConditions;
            }            
        }

        private TherapyKindCondition.ChildTherapyKindConditionCollection _TherapyKindConditions = null;
    /// <summary>
    /// Kural Koşulları
    /// </summary>
        public TherapyKindCondition.ChildTherapyKindConditionCollection TherapyKindConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _TherapyKindConditions;
            }            
        }

        private SexCondition.ChildSexConditionCollection _SexConditions = null;
    /// <summary>
    /// Kural Koşulları
    /// </summary>
        public SexCondition.ChildSexConditionCollection SexConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _SexConditions;
            }            
        }

        private ProcedureCondition.ChildProcedureConditionCollection _ProcedureConditions = null;
    /// <summary>
    /// Kural Koşulları
    /// </summary>
        public ProcedureCondition.ChildProcedureConditionCollection ProcedureConditions
        {
            get
            {
                if (_RuleConditions == null)
                    CreateRuleConditionsCollection();
                return _ProcedureConditions;
            }            
        }

        protected RuleBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RuleBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RuleBase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RuleBase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RuleBase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RULEBASE", dataRow) { }
        protected RuleBase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RULEBASE", dataRow, isImported) { }
        public RuleBase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RuleBase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RuleBase() : base() { }

    }
}