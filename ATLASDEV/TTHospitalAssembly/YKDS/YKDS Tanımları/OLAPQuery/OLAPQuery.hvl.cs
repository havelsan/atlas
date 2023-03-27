
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OLAPQuery")] 

    public  partial class OLAPQuery : OLAPBaseAction
    {
        public class OLAPQueryList : TTObjectCollection<OLAPQuery> { }
                    
        public class ChildOLAPQueryCollection : TTObject.TTChildObjectCollection<OLAPQuery>
        {
            public ChildOLAPQueryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOLAPQueryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOLAPQuery_NWS_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Caption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Query
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUERY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["QUERY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetOLAPQuery_NWS_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOLAPQuery_NWS_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOLAPQuery_NWS_Class() : base() { }
        }

        [Serializable] 

        public partial class GetChildOLAPQueries_Class : TTReportNqlObject 
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

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Caption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? QueryNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUERYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["QUERYNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object Query
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUERY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["QUERY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetChildOLAPQueries_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChildOLAPQueries_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChildOLAPQueries_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOLAPQueryItems_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Caption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Parentmenu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTMENU"]);
                }
            }

            public GetOLAPQueryItems_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOLAPQueryItems_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOLAPQueryItems_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOLAPQueries_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Caption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public object Query
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUERY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["QUERY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? QueryNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUERYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].AllPropertyDefs["QUERYNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Parentmenu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARENTMENU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cube
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CUBE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOLAPQueries_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOLAPQueries_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOLAPQueries_Class() : base() { }
        }

        public static BindingList<OLAPQuery.GetOLAPQuery_NWS_Class> GetOLAPQuery_NWS(Guid OLAPQUERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].QueryDefs["GetOLAPQuery_NWS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OLAPQUERY", OLAPQUERY);

            return TTReportNqlObject.QueryObjects<OLAPQuery.GetOLAPQuery_NWS_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OLAPQuery.GetOLAPQuery_NWS_Class> GetOLAPQuery_NWS(TTObjectContext objectContext, Guid OLAPQUERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].QueryDefs["GetOLAPQuery_NWS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OLAPQUERY", OLAPQUERY);

            return TTReportNqlObject.QueryObjects<OLAPQuery.GetOLAPQuery_NWS_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OLAPQuery.GetChildOLAPQueries_Class> GetChildOLAPQueries(Guid PARENTMENU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].QueryDefs["GetChildOLAPQueries"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTMENU", PARENTMENU);

            return TTReportNqlObject.QueryObjects<OLAPQuery.GetChildOLAPQueries_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OLAPQuery.GetChildOLAPQueries_Class> GetChildOLAPQueries(TTObjectContext objectContext, Guid PARENTMENU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].QueryDefs["GetChildOLAPQueries"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTMENU", PARENTMENU);

            return TTReportNqlObject.QueryObjects<OLAPQuery.GetChildOLAPQueries_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// For SuperNova
    /// </summary>
        public static BindingList<OLAPQuery.GetOLAPQueryItems_Class> GetOLAPQueryItems(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].QueryDefs["GetOLAPQueryItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPQuery.GetOLAPQueryItems_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// For SuperNova
    /// </summary>
        public static BindingList<OLAPQuery.GetOLAPQueryItems_Class> GetOLAPQueryItems(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].QueryDefs["GetOLAPQueryItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPQuery.GetOLAPQueryItems_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OLAPQuery.GetOLAPQueries_Class> GetOLAPQueries(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].QueryDefs["GetOLAPQueries"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPQuery.GetOLAPQueries_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OLAPQuery.GetOLAPQueries_Class> GetOLAPQueries(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPQUERY"].QueryDefs["GetOLAPQueries"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPQuery.GetOLAPQueries_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public string Caption
        {
            get { return (string)this["CAPTION"]; }
            set { this["CAPTION"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Sorgu Nu
    /// </summary>
        public TTSequence QueryNO
        {
            get { return GetSequence("QUERYNO"); }
        }

        public object Query
        {
            get { return (object)this["QUERY"]; }
            set { this["QUERY"] = value; }
        }

        public OLAPCube OLAPCube
        {
            get { return (OLAPCube)((ITTObject)this).GetParent("OLAPCUBE"); }
            set { this["OLAPCUBE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OLAPMenu OLAPMenu
        {
            get { return (OLAPMenu)((ITTObject)this).GetParent("OLAPMENU"); }
            set { this["OLAPMENU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateOLAPRolesCollectionViews()
        {
            base.CreateOLAPRolesCollectionViews();
            _OLAPQueryRoles = new OLAPQueryRole.ChildOLAPQueryRoleCollection(_OLAPRoles, "OLAPQueryRoles");
        }

        private OLAPQueryRole.ChildOLAPQueryRoleCollection _OLAPQueryRoles = null;
        public OLAPQueryRole.ChildOLAPQueryRoleCollection OLAPQueryRoles
        {
            get
            {
                if (_OLAPRoles == null)
                    CreateOLAPRolesCollection();
                return _OLAPQueryRoles;
            }            
        }

        protected OLAPQuery(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OLAPQuery(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OLAPQuery(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OLAPQuery(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OLAPQuery(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLAPQUERY", dataRow) { }
        protected OLAPQuery(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLAPQUERY", dataRow, isImported) { }
        public OLAPQuery(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OLAPQuery(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OLAPQuery() : base() { }

    }
}