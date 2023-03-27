
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeDecisionDefinition")] 

    /// <summary>
    /// Sağlık Kurulu Karar Tanımı
    /// </summary>
    public  partial class HealthCommitteeDecisionDefinition : TerminologyManagerDef
    {
        public class HealthCommitteeDecisionDefinitionList : TTObjectCollection<HealthCommitteeDecisionDefinition> { }
                    
        public class ChildHealthCommitteeDecisionDefinitionCollection : TTObject.TTChildObjectCollection<HealthCommitteeDecisionDefinition>
        {
            public ChildHealthCommitteeDecisionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeDecisionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetHCDecisionDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public OLAP_GetHCDecisionDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetHCDecisionDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetHCDecisionDef_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCDecisionDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Category
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CATEGORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONCATEGORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? RequiresTimeInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUIRESTIMEINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].AllPropertyDefs["REQUIRESTIMEINFO"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? RequiresAdditionalDecision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUIRESADDITIONALDECISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].AllPropertyDefs["REQUIRESADDITIONALDECISION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ShowOnlyAddDecisionOnReports
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOWONLYADDDECISIONONREPORTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].AllPropertyDefs["SHOWONLYADDDECISIONONREPORTS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? UnsuitableForMilitaryService
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNSUITABLEFORMILITARYSERVICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].AllPropertyDefs["UNSUITABLEFORMILITARYSERVICE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public GetHCDecisionDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCDecisionDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCDecisionDefinitions_Class() : base() { }
        }

        public static BindingList<HealthCommitteeDecisionDefinition.OLAP_GetHCDecisionDef_Class> OLAP_GetHCDecisionDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].QueryDefs["OLAP_GetHCDecisionDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeDecisionDefinition.OLAP_GetHCDecisionDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeDecisionDefinition.OLAP_GetHCDecisionDef_Class> OLAP_GetHCDecisionDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].QueryDefs["OLAP_GetHCDecisionDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeDecisionDefinition.OLAP_GetHCDecisionDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeDecisionDefinition.GetHCDecisionDefinitions_Class> GetHCDecisionDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].QueryDefs["GetHCDecisionDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeDecisionDefinition.GetHCDecisionDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HealthCommitteeDecisionDefinition.GetHCDecisionDefinitions_Class> GetHCDecisionDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONDEFINITION"].QueryDefs["GetHCDecisionDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeDecisionDefinition.GetHCDecisionDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// XXXXXXliğe Elverişli Değildir
    /// </summary>
        public bool? UnsuitableForMilitaryService
        {
            get { return (bool?)this["UNSUITABLEFORMILITARYSERVICE"]; }
            set { this["UNSUITABLEFORMILITARYSERVICE"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Süre Bilgisi Gerektirir
    /// </summary>
        public bool? RequiresTimeInfo
        {
            get { return (bool?)this["REQUIRESTIMEINFO"]; }
            set { this["REQUIRESTIMEINFO"] = value; }
        }

    /// <summary>
    /// İlave Karar Gerektirir
    /// </summary>
        public bool? RequiresAdditionalDecision
        {
            get { return (bool?)this["REQUIRESADDITIONALDECISION"]; }
            set { this["REQUIRESADDITIONALDECISION"] = value; }
        }

    /// <summary>
    /// Raporlarda Sadece İlave Karar Görünür
    /// </summary>
        public bool? ShowOnlyAddDecisionOnReports
        {
            get { return (bool?)this["SHOWONLYADDDECISIONONREPORTS"]; }
            set { this["SHOWONLYADDDECISIONONREPORTS"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu Karar Kategorisi
    /// </summary>
        public HealthCommitteeDecisionCategoryDefinition Category
        {
            get { return (HealthCommitteeDecisionCategoryDefinition)((ITTObject)this).GetParent("CATEGORY"); }
            set { this["CATEGORY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateHCDesicionDefPatGroupGridCollection()
        {
            _HCDesicionDefPatGroupGrid = new HCDesicionDefPatGroupGrid.ChildHCDesicionDefPatGroupGridCollection(this, new Guid("f0125815-fedc-43f6-b5b7-eeb91a635825"));
            ((ITTChildObjectCollection)_HCDesicionDefPatGroupGrid).GetChildren();
        }

        protected HCDesicionDefPatGroupGrid.ChildHCDesicionDefPatGroupGridCollection _HCDesicionDefPatGroupGrid = null;
    /// <summary>
    /// Child collection for Hasta Grubu
    /// </summary>
        public HCDesicionDefPatGroupGrid.ChildHCDesicionDefPatGroupGridCollection HCDesicionDefPatGroupGrid
        {
            get
            {
                if (_HCDesicionDefPatGroupGrid == null)
                    CreateHCDesicionDefPatGroupGridCollection();
                return _HCDesicionDefPatGroupGrid;
            }
        }

        protected HealthCommitteeDecisionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeDecisionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeDecisionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeDecisionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeDecisionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEDECISIONDEFINITION", dataRow) { }
        protected HealthCommitteeDecisionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEDECISIONDEFINITION", dataRow, isImported) { }
        protected HealthCommitteeDecisionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeDecisionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeDecisionDefinition() : base() { }

    }
}