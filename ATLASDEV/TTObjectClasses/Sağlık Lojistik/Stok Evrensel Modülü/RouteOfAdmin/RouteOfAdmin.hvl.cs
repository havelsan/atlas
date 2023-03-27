
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RouteOfAdmin")] 

    /// <summary>
    /// Uygulama Şekli
    /// </summary>
    public  partial class RouteOfAdmin : TerminologyManagerDef
    {
        public class RouteOfAdminList : TTObjectCollection<RouteOfAdmin> { }
                    
        public class ChildRouteOfAdminCollection : TTObject.TTChildObjectCollection<RouteOfAdmin>
        {
            public ChildRouteOfAdminCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRouteOfAdminCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRouteOfAdminDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ROUTEOFADMIN"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DrugUsageTypeEnum? DrugUsageType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGUSAGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ROUTEOFADMIN"].AllPropertyDefs["DRUGUSAGETYPE"].DataType;
                    return (DrugUsageTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ROUTEOFADMIN"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ROUTEOFADMIN"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? SPTSRouteOfAdminID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSROUTEOFADMINID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ROUTEOFADMIN"].AllPropertyDefs["SPTSROUTEOFADMINID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetRouteOfAdminDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRouteOfAdminDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRouteOfAdminDefinitionQuery_Class() : base() { }
        }

        public static BindingList<RouteOfAdmin> GetRouteOfAdminBySPTSRouteOfAdminID(TTObjectContext objectContext, long SPTSROUTEOFADMINID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ROUTEOFADMIN"].QueryDefs["GetRouteOfAdminBySPTSRouteOfAdminID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPTSROUTEOFADMINID", SPTSROUTEOFADMINID);

            return ((ITTQuery)objectContext).QueryObjects<RouteOfAdmin>(queryDef, paramList);
        }

        public static BindingList<RouteOfAdmin> GetRouteOfAdminbyLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ROUTEOFADMIN"].QueryDefs["GetRouteOfAdminbyLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<RouteOfAdmin>(queryDef, paramList);
        }

        public static BindingList<RouteOfAdmin.GetRouteOfAdminDefinitionQuery_Class> GetRouteOfAdminDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ROUTEOFADMIN"].QueryDefs["GetRouteOfAdminDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RouteOfAdmin.GetRouteOfAdminDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RouteOfAdmin.GetRouteOfAdminDefinitionQuery_Class> GetRouteOfAdminDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ROUTEOFADMIN"].QueryDefs["GetRouteOfAdminDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RouteOfAdmin.GetRouteOfAdminDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hızlı Referans
    /// </summary>
        public string QREF
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

    /// <summary>
    /// İsim
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public long? SPTSRouteOfAdminID
        {
            get { return (long?)this["SPTSROUTEOFADMINID"]; }
            set { this["SPTSROUTEOFADMINID"] = value; }
        }

    /// <summary>
    /// Medula Kodu
    /// </summary>
        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// E Reçete Kullanım Şekli
    /// </summary>
        public DrugUsageTypeEnum? DrugUsageType
        {
            get { return (DrugUsageTypeEnum?)(int?)this["DRUGUSAGETYPE"]; }
            set { this["DRUGUSAGETYPE"] = value; }
        }

        protected RouteOfAdmin(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RouteOfAdmin(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RouteOfAdmin(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RouteOfAdmin(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RouteOfAdmin(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ROUTEOFADMIN", dataRow) { }
        protected RouteOfAdmin(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ROUTEOFADMIN", dataRow, isImported) { }
        public RouteOfAdmin(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RouteOfAdmin(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RouteOfAdmin() : base() { }

    }
}