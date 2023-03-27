
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSEnumMatchDefinition")] 

    public  partial class SKRSEnumMatchDefinition : TerminologyManagerDef
    {
        public class SKRSEnumMatchDefinitionList : TTObjectCollection<SKRSEnumMatchDefinition> { }
                    
        public class ChildSKRSEnumMatchDefinitionCollection : TTObject.TTChildObjectCollection<SKRSEnumMatchDefinition>
        {
            public ChildSKRSEnumMatchDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSEnumMatchDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSEnumMatchDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public int? EnumValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENUMVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSENUMMATCHDEFINITION"].AllPropertyDefs["ENUMVALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? SKRSDefinitionObjectId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SKRSDEFINITIONOBJECTID"]);
                }
            }

            public GetSKRSEnumMatchDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSEnumMatchDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSEnumMatchDefinition_Class() : base() { }
        }

        public static BindingList<SKRSEnumMatchDefinition> GetBySKRSObjectId(TTObjectContext objectContext, Guid SKRSOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSENUMMATCHDEFINITION"].QueryDefs["GetBySKRSObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SKRSOBJECTID", SKRSOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<SKRSEnumMatchDefinition>(queryDef, paramList);
        }

        public static BindingList<SKRSEnumMatchDefinition.GetSKRSEnumMatchDefinition_Class> GetSKRSEnumMatchDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSENUMMATCHDEFINITION"].QueryDefs["GetSKRSEnumMatchDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSEnumMatchDefinition.GetSKRSEnumMatchDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSEnumMatchDefinition.GetSKRSEnumMatchDefinition_Class> GetSKRSEnumMatchDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSENUMMATCHDEFINITION"].QueryDefs["GetSKRSEnumMatchDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSEnumMatchDefinition.GetSKRSEnumMatchDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSEnumMatchDefinition> GetBySKRSDefObjectIdAndEnumValue(TTObjectContext objectContext, Guid SKRSDEFOBJECTID, int ENUMVALUE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSENUMMATCHDEFINITION"].QueryDefs["GetBySKRSDefObjectIdAndEnumValue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SKRSDEFOBJECTID", SKRSDEFOBJECTID);
            paramList.Add("ENUMVALUE", ENUMVALUE);

            return ((ITTQuery)objectContext).QueryObjects<SKRSEnumMatchDefinition>(queryDef, paramList, injectionSQL);
        }

        public int? EnumValue
        {
            get { return (int?)this["ENUMVALUE"]; }
            set { this["ENUMVALUE"] = value; }
        }

        public Guid? SKRSDefinitionObjectId
        {
            get { return (Guid?)this["SKRSDEFINITIONOBJECTID"]; }
            set { this["SKRSDEFINITIONOBJECTID"] = value; }
        }

        public BaseSKRSDefinition SKRSDefinition
        {
            get { return (BaseSKRSDefinition)((ITTObject)this).GetParent("SKRSDEFINITION"); }
            set { this["SKRSDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SKRSEnumMatchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSEnumMatchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSEnumMatchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSEnumMatchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSEnumMatchDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSENUMMATCHDEFINITION", dataRow) { }
        protected SKRSEnumMatchDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSENUMMATCHDEFINITION", dataRow, isImported) { }
        public SKRSEnumMatchDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSEnumMatchDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSEnumMatchDefinition() : base() { }

    }
}