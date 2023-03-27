
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeDecisionCategoryDefinition")] 

    /// <summary>
    /// Sağlık Kurulu Karar Kategori Tanımı
    /// </summary>
    public  partial class HealthCommitteeDecisionCategoryDefinition : TerminologyManagerDef
    {
        public class HealthCommitteeDecisionCategoryDefinitionList : TTObjectCollection<HealthCommitteeDecisionCategoryDefinition> { }
                    
        public class ChildHealthCommitteeDecisionCategoryDefinitionCollection : TTObject.TTChildObjectCollection<HealthCommitteeDecisionCategoryDefinition>
        {
            public ChildHealthCommitteeDecisionCategoryDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeDecisionCategoryDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCDecisionCategoryDefinitions_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONCATEGORYDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONCATEGORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetHCDecisionCategoryDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCDecisionCategoryDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCDecisionCategoryDefinitions_Class() : base() { }
        }

        public static BindingList<HealthCommitteeDecisionCategoryDefinition.GetHCDecisionCategoryDefinitions_Class> GetHCDecisionCategoryDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONCATEGORYDEFINITION"].QueryDefs["GetHCDecisionCategoryDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeDecisionCategoryDefinition.GetHCDecisionCategoryDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HealthCommitteeDecisionCategoryDefinition.GetHCDecisionCategoryDefinitions_Class> GetHCDecisionCategoryDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEDECISIONCATEGORYDEFINITION"].QueryDefs["GetHCDecisionCategoryDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeDecisionCategoryDefinition.GetHCDecisionCategoryDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        virtual protected void CreateHCDecisionsCollection()
        {
            _HCDecisions = new HealthCommitteeDecisionDefinition.ChildHealthCommitteeDecisionDefinitionCollection(this, new Guid("47742183-cfea-4fd5-9bb3-725c56d2b196"));
            ((ITTChildObjectCollection)_HCDecisions).GetChildren();
        }

        protected HealthCommitteeDecisionDefinition.ChildHealthCommitteeDecisionDefinitionCollection _HCDecisions = null;
    /// <summary>
    /// Child collection for Sağlık Kurulu Karar Kategorisi
    /// </summary>
        public HealthCommitteeDecisionDefinition.ChildHealthCommitteeDecisionDefinitionCollection HCDecisions
        {
            get
            {
                if (_HCDecisions == null)
                    CreateHCDecisionsCollection();
                return _HCDecisions;
            }
        }

        protected HealthCommitteeDecisionCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeDecisionCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeDecisionCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeDecisionCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeDecisionCategoryDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEDECISIONCATEGORYDEFINITION", dataRow) { }
        protected HealthCommitteeDecisionCategoryDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEDECISIONCATEGORYDEFINITION", dataRow, isImported) { }
        protected HealthCommitteeDecisionCategoryDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeDecisionCategoryDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeDecisionCategoryDefinition() : base() { }

    }
}