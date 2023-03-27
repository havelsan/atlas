
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDetailEdgeDef")] 

    public  partial class FixedAssetDetailEdgeDef : TerminologyManagerDef
    {
        public class FixedAssetDetailEdgeDefList : TTObjectCollection<FixedAssetDetailEdgeDef> { }
                    
        public class ChildFixedAssetDetailEdgeDefCollection : TTObject.TTChildObjectCollection<FixedAssetDetailEdgeDef>
        {
            public ChildFixedAssetDetailEdgeDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDetailEdgeDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFixedAssetDetailEdgeDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string EdgeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EDGENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILEDGEDEF"].AllPropertyDefs["EDGENAME"].DataType;
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

            public GetFixedAssetDetailEdgeDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetDetailEdgeDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetDetailEdgeDefList_Class() : base() { }
        }

        public static BindingList<FixedAssetDetailEdgeDef.GetFixedAssetDetailEdgeDefList_Class> GetFixedAssetDetailEdgeDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILEDGEDEF"].QueryDefs["GetFixedAssetDetailEdgeDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailEdgeDef.GetFixedAssetDetailEdgeDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDetailEdgeDef.GetFixedAssetDetailEdgeDefList_Class> GetFixedAssetDetailEdgeDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILEDGEDEF"].QueryDefs["GetFixedAssetDetailEdgeDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailEdgeDef.GetFixedAssetDetailEdgeDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string EdgeName
        {
            get { return (string)this["EDGENAME"]; }
            set { this["EDGENAME"] = value; }
        }

        public FixedAssetDetailBodyDef FixedAssetDetailBodyDef
        {
            get { return (FixedAssetDetailBodyDef)((ITTObject)this).GetParent("FIXEDASSETDETAILBODYDEF"); }
            set { this["FIXEDASSETDETAILBODYDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetDetailEdgeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDetailEdgeDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDetailEdgeDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDetailEdgeDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDetailEdgeDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDETAILEDGEDEF", dataRow) { }
        protected FixedAssetDetailEdgeDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDETAILEDGEDEF", dataRow, isImported) { }
        public FixedAssetDetailEdgeDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDetailEdgeDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDetailEdgeDef() : base() { }

    }
}