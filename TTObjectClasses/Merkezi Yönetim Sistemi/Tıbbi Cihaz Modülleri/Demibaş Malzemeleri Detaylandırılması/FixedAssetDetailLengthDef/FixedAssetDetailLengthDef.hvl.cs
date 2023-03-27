
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDetailLengthDef")] 

    public  partial class FixedAssetDetailLengthDef : TerminologyManagerDef
    {
        public class FixedAssetDetailLengthDefList : TTObjectCollection<FixedAssetDetailLengthDef> { }
                    
        public class ChildFixedAssetDetailLengthDefCollection : TTObject.TTChildObjectCollection<FixedAssetDetailLengthDef>
        {
            public ChildFixedAssetDetailLengthDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDetailLengthDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFixedAssetDetailLengthDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Length
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LENGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILLENGTHDEF"].AllPropertyDefs["LENGTH"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetFixedAssetDetailLengthDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetDetailLengthDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetDetailLengthDefList_Class() : base() { }
        }

        public static BindingList<FixedAssetDetailLengthDef.GetFixedAssetDetailLengthDefList_Class> GetFixedAssetDetailLengthDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILLENGTHDEF"].QueryDefs["GetFixedAssetDetailLengthDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailLengthDef.GetFixedAssetDetailLengthDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDetailLengthDef.GetFixedAssetDetailLengthDefList_Class> GetFixedAssetDetailLengthDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILLENGTHDEF"].QueryDefs["GetFixedAssetDetailLengthDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailLengthDef.GetFixedAssetDetailLengthDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Length
        {
            get { return (string)this["LENGTH"]; }
            set { this["LENGTH"] = value; }
        }

    /// <summary>
    /// Sahanın Önerdiği Stok Numarası
    /// </summary>
        public string ProposedNATOStockNo
        {
            get { return (string)this["PROPOSEDNATOSTOCKNO"]; }
            set { this["PROPOSEDNATOSTOCKNO"] = value; }
        }

    /// <summary>
    /// Sahanın Önerdiği Stok Adı
    /// </summary>
        public string ProposedStockcardName
        {
            get { return (string)this["PROPOSEDSTOCKCARDNAME"]; }
            set { this["PROPOSEDSTOCKCARDNAME"] = value; }
        }

        public FixedAssetDetailEdgeDef FixedAssetDetailEdgeDef
        {
            get { return (FixedAssetDetailEdgeDef)((ITTObject)this).GetParent("FIXEDASSETDETAILEDGEDEF"); }
            set { this["FIXEDASSETDETAILEDGEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetDetailLengthDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDetailLengthDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDetailLengthDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDetailLengthDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDetailLengthDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDETAILLENGTHDEF", dataRow) { }
        protected FixedAssetDetailLengthDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDETAILLENGTHDEF", dataRow, isImported) { }
        public FixedAssetDetailLengthDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDetailLengthDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDetailLengthDef() : base() { }

    }
}