
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RuleSet")] 

    public  partial class RuleSet : TTDefinitionSet
    {
        public class RuleSetList : TTObjectCollection<RuleSet> { }
                    
        public class ChildRuleSetCollection : TTObject.TTChildObjectCollection<RuleSet>
        {
            public ChildRuleSetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRuleSetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRuleSetDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RULESET"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RULESET"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RULESET"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public GetRuleSetDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRuleSetDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRuleSetDefinitionQuery_Class() : base() { }
        }

        public static BindingList<RuleSet.GetRuleSetDefinitionQuery_Class> GetRuleSetDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RULESET"].QueryDefs["GetRuleSetDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RuleSet.GetRuleSetDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RuleSet.GetRuleSetDefinitionQuery_Class> GetRuleSetDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RULESET"].QueryDefs["GetRuleSetDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RuleSet.GetRuleSetDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Kural Seti Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        virtual protected void CreateMaterialRuleSetsCollection()
        {
            _MaterialRuleSets = new MaterialRuleSet.ChildMaterialRuleSetCollection(this, new Guid("e723a122-6e3f-4fbf-9bd2-0761d537728b"));
            ((ITTChildObjectCollection)_MaterialRuleSets).GetChildren();
        }

        protected MaterialRuleSet.ChildMaterialRuleSetCollection _MaterialRuleSets = null;
    /// <summary>
    /// Child collection for Kural Seti-Malzeme Kural Setleri
    /// </summary>
        public MaterialRuleSet.ChildMaterialRuleSetCollection MaterialRuleSets
        {
            get
            {
                if (_MaterialRuleSets == null)
                    CreateMaterialRuleSetsCollection();
                return _MaterialRuleSets;
            }
        }

        virtual protected void CreateProcedureRuleSetsCollection()
        {
            _ProcedureRuleSets = new ProcedureRuleSet.ChildProcedureRuleSetCollection(this, new Guid("bd12de97-fc79-4ace-bef2-4cab4609f7ed"));
            ((ITTChildObjectCollection)_ProcedureRuleSets).GetChildren();
        }

        protected ProcedureRuleSet.ChildProcedureRuleSetCollection _ProcedureRuleSets = null;
    /// <summary>
    /// Child collection for Kural Seti-Hizmet Kural Setleri
    /// </summary>
        public ProcedureRuleSet.ChildProcedureRuleSetCollection ProcedureRuleSets
        {
            get
            {
                if (_ProcedureRuleSets == null)
                    CreateProcedureRuleSetsCollection();
                return _ProcedureRuleSets;
            }
        }

        virtual protected void CreateRuleSetRulesCollection()
        {
            _RuleSetRules = new RuleSetRule.ChildRuleSetRuleCollection(this, new Guid("4eff67de-f0db-4073-bda4-10322a95aed4"));
            ((ITTChildObjectCollection)_RuleSetRules).GetChildren();
        }

        protected RuleSetRule.ChildRuleSetRuleCollection _RuleSetRules = null;
    /// <summary>
    /// Child collection for Kural Seti-Kural Seti Kuralları
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

        virtual protected void CreateDiagnosisRuleSetsCollection()
        {
            _DiagnosisRuleSets = new DiagnosisRuleSet.ChildDiagnosisRuleSetCollection(this, new Guid("ff6b88ea-c3eb-4d45-b9b7-0e06a2b4dcbb"));
            ((ITTChildObjectCollection)_DiagnosisRuleSets).GetChildren();
        }

        protected DiagnosisRuleSet.ChildDiagnosisRuleSetCollection _DiagnosisRuleSets = null;
    /// <summary>
    /// Child collection for Kural Seti-Tanı Kural Setleri
    /// </summary>
        public DiagnosisRuleSet.ChildDiagnosisRuleSetCollection DiagnosisRuleSets
        {
            get
            {
                if (_DiagnosisRuleSets == null)
                    CreateDiagnosisRuleSetsCollection();
                return _DiagnosisRuleSets;
            }
        }

        protected RuleSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RuleSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RuleSet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RuleSet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RuleSet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RULESET", dataRow) { }
        protected RuleSet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RULESET", dataRow, isImported) { }
        public RuleSet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RuleSet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RuleSet() : base() { }

    }
}