
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BornType")] 

    /// <summary>
    /// Doğum Şekli
    /// </summary>
    public  partial class BornType : TerminologyManagerDef
    {
        public class BornTypeList : TTObjectCollection<BornType> { }
                    
        public class ChildBornTypeCollection : TTObject.TTChildObjectCollection<BornType>
        {
            public ChildBornTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBornTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBornTypes_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BORNTYPE"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BornMainType? MainType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BORNTYPE"].AllPropertyDefs["MAINTYPE"].DataType;
                    return (BornMainType?)(int)dataType.ConvertValue(val);
                }
            }

            public GetBornTypes_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBornTypes_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBornTypes_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetBornType_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BORNTYPE"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BornMainType? MainType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BORNTYPE"].AllPropertyDefs["MAINTYPE"].DataType;
                    return (BornMainType?)(int)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetBornType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetBornType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetBornType_Class() : base() { }
        }

        public static BindingList<BornType.GetBornTypes_Class> GetBornTypes(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BORNTYPE"].QueryDefs["GetBornTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BornType.GetBornTypes_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BornType.GetBornTypes_Class> GetBornTypes(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BORNTYPE"].QueryDefs["GetBornTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BornType.GetBornTypes_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BornType.OLAP_GetBornType_Class> OLAP_GetBornType(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BORNTYPE"].QueryDefs["OLAP_GetBornType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BornType.OLAP_GetBornType_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BornType.OLAP_GetBornType_Class> OLAP_GetBornType(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BORNTYPE"].QueryDefs["OLAP_GetBornType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BornType.OLAP_GetBornType_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BornType> GetBornTypeByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BORNTYPE"].QueryDefs["GetBornTypeByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<BornType>(queryDef, paramList);
        }

        public BornMainType? MainType
        {
            get { return (BornMainType?)(int?)this["MAINTYPE"]; }
            set { this["MAINTYPE"] = value; }
        }

    /// <summary>
    /// Doğum Şekli
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        public string Type_Shadow
        {
            get { return (string)this["TYPE_SHADOW"]; }
        }

        protected BornType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BornType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BornType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BornType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BornType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BORNTYPE", dataRow) { }
        protected BornType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BORNTYPE", dataRow, isImported) { }
        public BornType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BornType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BornType() : base() { }

    }
}