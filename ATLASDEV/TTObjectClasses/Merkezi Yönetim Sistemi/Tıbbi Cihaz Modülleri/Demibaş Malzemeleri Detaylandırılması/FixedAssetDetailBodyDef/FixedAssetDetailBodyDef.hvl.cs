
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDetailBodyDef")] 

    public  partial class FixedAssetDetailBodyDef : TerminologyManagerDef
    {
        public class FixedAssetDetailBodyDefList : TTObjectCollection<FixedAssetDetailBodyDef> { }
                    
        public class ChildFixedAssetDetailBodyDefCollection : TTObject.TTChildObjectCollection<FixedAssetDetailBodyDef>
        {
            public ChildFixedAssetDetailBodyDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDetailBodyDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFixedAssetDetailBodyDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string BodyName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BODYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILBODYDEF"].AllPropertyDefs["BODYNAME"].DataType;
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

            public GetFixedAssetDetailBodyDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetDetailBodyDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetDetailBodyDefList_Class() : base() { }
        }

        public static BindingList<FixedAssetDetailBodyDef.GetFixedAssetDetailBodyDefList_Class> GetFixedAssetDetailBodyDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILBODYDEF"].QueryDefs["GetFixedAssetDetailBodyDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailBodyDef.GetFixedAssetDetailBodyDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDetailBodyDef.GetFixedAssetDetailBodyDefList_Class> GetFixedAssetDetailBodyDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILBODYDEF"].QueryDefs["GetFixedAssetDetailBodyDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailBodyDef.GetFixedAssetDetailBodyDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string BodyName
        {
            get { return (string)this["BODYNAME"]; }
            set { this["BODYNAME"] = value; }
        }

        public FixedAssetDetailMainClassDefinition FixedAssetDetailMainClass
        {
            get { return (FixedAssetDetailMainClassDefinition)((ITTObject)this).GetParent("FIXEDASSETDETAILMAINCLASS"); }
            set { this["FIXEDASSETDETAILMAINCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetDetailBodyDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDetailBodyDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDetailBodyDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDetailBodyDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDetailBodyDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDETAILBODYDEF", dataRow) { }
        protected FixedAssetDetailBodyDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDETAILBODYDEF", dataRow, isImported) { }
        public FixedAssetDetailBodyDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDetailBodyDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDetailBodyDef() : base() { }

    }
}