
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDetailRefDef")] 

    /// <summary>
    /// Referans Numarası Tanımlama
    /// </summary>
    public  partial class FixedAssetDetailRefDef : TerminologyManagerDef
    {
        public class FixedAssetDetailRefDefList : TTObjectCollection<FixedAssetDetailRefDef> { }
                    
        public class ChildFixedAssetDetailRefDefCollection : TTObject.TTChildObjectCollection<FixedAssetDetailRefDef>
        {
            public ChildFixedAssetDetailRefDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDetailRefDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFixedAssetDetailRefDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Referance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILREFDEF"].AllPropertyDefs["REFERANCE"].DataType;
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

            public string Edgedef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EDGEDEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILEDGEDEF"].AllPropertyDefs["EDGENAME"].DataType;
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

            public GetFixedAssetDetailRefDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetDetailRefDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetDetailRefDefList_Class() : base() { }
        }

        public static BindingList<FixedAssetDetailRefDef.GetFixedAssetDetailRefDefList_Class> GetFixedAssetDetailRefDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILREFDEF"].QueryDefs["GetFixedAssetDetailRefDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailRefDef.GetFixedAssetDetailRefDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDetailRefDef.GetFixedAssetDetailRefDefList_Class> GetFixedAssetDetailRefDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILREFDEF"].QueryDefs["GetFixedAssetDetailRefDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDetailRefDef.GetFixedAssetDetailRefDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Referance
        {
            get { return (string)this["REFERANCE"]; }
            set { this["REFERANCE"] = value; }
        }

        public FixedAssetDetailMainClassDefinition FixedAssetDetailMainClass
        {
            get { return (FixedAssetDetailMainClassDefinition)((ITTObject)this).GetParent("FIXEDASSETDETAILMAINCLASS"); }
            set { this["FIXEDASSETDETAILMAINCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailMarkDef FixedAssetDetailMarkDef
        {
            get { return (FixedAssetDetailMarkDef)((ITTObject)this).GetParent("FIXEDASSETDETAILMARKDEF"); }
            set { this["FIXEDASSETDETAILMARKDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailModelDef FixedAssetDetailModelDef
        {
            get { return (FixedAssetDetailModelDef)((ITTObject)this).GetParent("FIXEDASSETDETAILMODELDEF"); }
            set { this["FIXEDASSETDETAILMODELDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailBodyDef FixedAssetDetailBodyDef
        {
            get { return (FixedAssetDetailBodyDef)((ITTObject)this).GetParent("FIXEDASSETDETAILBODYDEF"); }
            set { this["FIXEDASSETDETAILBODYDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailEdgeDef FixedAssetDetailEdgeDef
        {
            get { return (FixedAssetDetailEdgeDef)((ITTObject)this).GetParent("FIXEDASSETDETAILEDGEDEF"); }
            set { this["FIXEDASSETDETAILEDGEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailLengthDef FixedAssetDetailLengthDef
        {
            get { return (FixedAssetDetailLengthDef)((ITTObject)this).GetParent("FIXEDASSETDETAILLENGTHDEF"); }
            set { this["FIXEDASSETDETAILLENGTHDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetDetailRefDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDetailRefDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDetailRefDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDetailRefDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDetailRefDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDETAILREFDEF", dataRow) { }
        protected FixedAssetDetailRefDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDETAILREFDEF", dataRow, isImported) { }
        public FixedAssetDetailRefDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDetailRefDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDetailRefDef() : base() { }

    }
}