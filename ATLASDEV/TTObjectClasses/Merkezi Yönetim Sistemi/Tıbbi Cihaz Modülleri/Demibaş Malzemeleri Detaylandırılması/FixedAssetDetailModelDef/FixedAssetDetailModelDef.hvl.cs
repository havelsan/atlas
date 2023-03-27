
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDetailModelDef")] 

    public  partial class FixedAssetDetailModelDef : TerminologyManagerDef
    {
        public class FixedAssetDetailModelDefList : TTObjectCollection<FixedAssetDetailModelDef> { }
                    
        public class ChildFixedAssetDetailModelDefCollection : TTObject.TTChildObjectCollection<FixedAssetDetailModelDef>
        {
            public ChildFixedAssetDetailModelDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDetailModelDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFixedAssetDetailModelDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ModelName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODELNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILMODELDEF"].AllPropertyDefs["MODELNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetFixedAssetDetailModelDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetDetailModelDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetDetailModelDefList_Class() : base() { }
        }

        public static BindingList<FixedAssetDetailModelDef.GetFixedAssetDetailModelDefList_Class> GetFixedAssetDetailModelDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILMODELDEF"].QueryDefs["GetFixedAssetDetailModelDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailModelDef.GetFixedAssetDetailModelDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDetailModelDef.GetFixedAssetDetailModelDefList_Class> GetFixedAssetDetailModelDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILMODELDEF"].QueryDefs["GetFixedAssetDetailModelDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailModelDef.GetFixedAssetDetailModelDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string ModelName
        {
            get { return (string)this["MODELNAME"]; }
            set { this["MODELNAME"] = value; }
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

        public FixedAssetDetailMarkDef FixedAssetDetailMarkDef
        {
            get { return (FixedAssetDetailMarkDef)((ITTObject)this).GetParent("FIXEDASSETDETAILMARKDEF"); }
            set { this["FIXEDASSETDETAILMARKDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetDetailModelDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDetailModelDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDetailModelDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDetailModelDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDetailModelDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDETAILMODELDEF", dataRow) { }
        protected FixedAssetDetailModelDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDETAILMODELDEF", dataRow, isImported) { }
        public FixedAssetDetailModelDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDetailModelDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDetailModelDef() : base() { }

    }
}