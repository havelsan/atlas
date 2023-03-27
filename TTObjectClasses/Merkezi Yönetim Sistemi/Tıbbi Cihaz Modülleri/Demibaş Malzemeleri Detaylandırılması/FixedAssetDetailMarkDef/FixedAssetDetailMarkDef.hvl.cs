
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDetailMarkDef")] 

    public  partial class FixedAssetDetailMarkDef : TerminologyManagerDef
    {
        public class FixedAssetDetailMarkDefList : TTObjectCollection<FixedAssetDetailMarkDef> { }
                    
        public class ChildFixedAssetDetailMarkDefCollection : TTObject.TTChildObjectCollection<FixedAssetDetailMarkDef>
        {
            public ChildFixedAssetDetailMarkDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDetailMarkDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFixedAssetDetailMarkDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string MarkName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARKNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILMARKDEF"].AllPropertyDefs["MARKNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MainClassName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINCLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILMAINCLASSDEFINITION"].AllPropertyDefs["MAINCLASSNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFixedAssetDetailMarkDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetDetailMarkDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetDetailMarkDefList_Class() : base() { }
        }

        public static BindingList<FixedAssetDetailMarkDef.GetFixedAssetDetailMarkDefList_Class> GetFixedAssetDetailMarkDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILMARKDEF"].QueryDefs["GetFixedAssetDetailMarkDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailMarkDef.GetFixedAssetDetailMarkDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDetailMarkDef.GetFixedAssetDetailMarkDefList_Class> GetFixedAssetDetailMarkDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILMARKDEF"].QueryDefs["GetFixedAssetDetailMarkDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailMarkDef.GetFixedAssetDetailMarkDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string MarkName
        {
            get { return (string)this["MARKNAME"]; }
            set { this["MARKNAME"] = value; }
        }

        public FixedAssetDetailMainClassDefinition FixedAssetDetailMainClass
        {
            get { return (FixedAssetDetailMainClassDefinition)((ITTObject)this).GetParent("FIXEDASSETDETAILMAINCLASS"); }
            set { this["FIXEDASSETDETAILMAINCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetDetailMarkDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDetailMarkDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDetailMarkDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDetailMarkDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDetailMarkDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDETAILMARKDEF", dataRow) { }
        protected FixedAssetDetailMarkDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDETAILMARKDEF", dataRow, isImported) { }
        public FixedAssetDetailMarkDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDetailMarkDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDetailMarkDef() : base() { }

    }
}