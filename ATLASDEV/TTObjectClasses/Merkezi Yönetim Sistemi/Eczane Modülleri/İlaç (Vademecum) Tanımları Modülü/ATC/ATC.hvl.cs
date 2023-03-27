
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ATC")] 

    public  partial class ATC : TerminologyManagerDef
    {
        public class ATCList : TTObjectCollection<ATC> { }
                    
        public class ChildATCCollection : TTObject.TTChildObjectCollection<ATC>
        {
            public ChildATCCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildATCCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetATC_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ATC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ATC"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentCode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTCODE"]);
                }
            }

            public OLAP_GetATC_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetATC_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetATC_Class() : base() { }
        }

        [Serializable] 

        public partial class GetATCListQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ATC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ATC"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SPTSATCID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSATCID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ATC"].AllPropertyDefs["SPTSATCID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ATC"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetATCListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetATCListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetATCListQuery_Class() : base() { }
        }

        public static BindingList<ATC> GetAtcBySPTSATCID(TTObjectContext objectContext, long SPTSATCID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ATC"].QueryDefs["GetAtcBySPTSATCID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPTSATCID", SPTSATCID);

            return ((ITTQuery)objectContext).QueryObjects<ATC>(queryDef, paramList);
        }

        public static BindingList<ATC> GetATCbyLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ATC"].QueryDefs["GetATCbyLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ATC>(queryDef, paramList);
        }

        public static BindingList<ATC.OLAP_GetATC_Class> OLAP_GetATC(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ATC"].QueryDefs["OLAP_GetATC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ATC.OLAP_GetATC_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ATC.OLAP_GetATC_Class> OLAP_GetATC(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ATC"].QueryDefs["OLAP_GetATC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ATC.OLAP_GetATC_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ATC.GetATCListQuery_Class> GetATCListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ATC"].QueryDefs["GetATCListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ATC.GetATCListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ATC.GetATCListQuery_Class> GetATCListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ATC"].QueryDefs["GetATCListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ATC.GetATCListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// ATC Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// ATC Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Grup
    /// </summary>
        public bool? IsGroup
        {
            get { return (bool?)this["ISGROUP"]; }
            set { this["ISGROUP"] = value; }
        }

        public string SPTSATCID
        {
            get { return (string)this["SPTSATCID"]; }
            set { this["SPTSATCID"] = value; }
        }

        public ATC ParentCode
        {
            get { return (ATC)((ITTObject)this).GetParent("PARENTCODE"); }
            set { this["PARENTCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ATC(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ATC(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ATC(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ATC(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ATC(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ATC", dataRow) { }
        protected ATC(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ATC", dataRow, isImported) { }
        public ATC(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ATC(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ATC() : base() { }

    }
}