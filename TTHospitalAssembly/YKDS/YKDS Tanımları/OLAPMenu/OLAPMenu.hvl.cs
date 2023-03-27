
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OLAPMenu")] 

    public  partial class OLAPMenu : BaseOLAPDefinition
    {
        public class OLAPMenuList : TTObjectCollection<OLAPMenu> { }
                    
        public class ChildOLAPMenuCollection : TTObject.TTChildObjectCollection<OLAPMenu>
        {
            public ChildOLAPMenuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOLAPMenuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOLAPMenus_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public long? MenuNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MENUNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].AllPropertyDefs["MENUNO"].DataType;
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

            public GetOLAPMenus_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOLAPMenus_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOLAPMenus_Class() : base() { }
        }

        [Serializable] 

        public partial class GetChildOLAPMenus_Class : TTReportNqlObject 
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

            public string Caption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? MenuNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MENUNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].AllPropertyDefs["MENUNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetChildOLAPMenus_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChildOLAPMenus_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChildOLAPMenus_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOLAPMenuItems_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].AllPropertyDefs["CAPTION"].DataType;
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

            public GetOLAPMenuItems_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOLAPMenuItems_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOLAPMenuItems_Class() : base() { }
        }

        public static BindingList<OLAPMenu.GetOLAPMenus_Class> GetOLAPMenus(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].QueryDefs["GetOLAPMenus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPMenu.GetOLAPMenus_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OLAPMenu.GetOLAPMenus_Class> GetOLAPMenus(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].QueryDefs["GetOLAPMenus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPMenu.GetOLAPMenus_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OLAPMenu.GetChildOLAPMenus_Class> GetChildOLAPMenus(Guid PARENTMENU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].QueryDefs["GetChildOLAPMenus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTMENU", PARENTMENU);

            return TTReportNqlObject.QueryObjects<OLAPMenu.GetChildOLAPMenus_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OLAPMenu.GetChildOLAPMenus_Class> GetChildOLAPMenus(TTObjectContext objectContext, Guid PARENTMENU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].QueryDefs["GetChildOLAPMenus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTMENU", PARENTMENU);

            return TTReportNqlObject.QueryObjects<OLAPMenu.GetChildOLAPMenus_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// For SuperNova
    /// </summary>
        public static BindingList<OLAPMenu.GetOLAPMenuItems_Class> GetOLAPMenuItems(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].QueryDefs["GetOLAPMenuItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPMenu.GetOLAPMenuItems_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// For SuperNova
    /// </summary>
        public static BindingList<OLAPMenu.GetOLAPMenuItems_Class> GetOLAPMenuItems(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPMENU"].QueryDefs["GetOLAPMenuItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPMenu.GetOLAPMenuItems_Class>(objectContext, queryDef, paramList, pi);
        }

        public string Caption
        {
            get { return (string)this["CAPTION"]; }
            set { this["CAPTION"] = value; }
        }

    /// <summary>
    /// Menü Nu
    /// </summary>
        public TTSequence MenuNO
        {
            get { return GetSequence("MENUNO"); }
        }

        public int? OrderNO
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// OLAPMENU
    /// </summary>
        public OLAPMenu ParentMenu
        {
            get { return (OLAPMenu)((ITTObject)this).GetParent("PARENTMENU"); }
            set { this["PARENTMENU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateOLAPMenusCollection()
        {
            _OLAPMenus = new OLAPMenu.ChildOLAPMenuCollection(this, new Guid("5622b145-dfb2-4aae-bc15-cf4c8bc8452e"));
            ((ITTChildObjectCollection)_OLAPMenus).GetChildren();
        }

        protected OLAPMenu.ChildOLAPMenuCollection _OLAPMenus = null;
    /// <summary>
    /// Child collection for OLAPMENU
    /// </summary>
        public OLAPMenu.ChildOLAPMenuCollection OLAPMenus
        {
            get
            {
                if (_OLAPMenus == null)
                    CreateOLAPMenusCollection();
                return _OLAPMenus;
            }
        }

        virtual protected void CreateOLAPCubesCollection()
        {
            _OLAPCubes = new OLAPCube.ChildOLAPCubeCollection(this, new Guid("16a464d2-e9b1-4ae5-8ad4-337db56d7197"));
            ((ITTChildObjectCollection)_OLAPCubes).GetChildren();
        }

        protected OLAPCube.ChildOLAPCubeCollection _OLAPCubes = null;
        public OLAPCube.ChildOLAPCubeCollection OLAPCubes
        {
            get
            {
                if (_OLAPCubes == null)
                    CreateOLAPCubesCollection();
                return _OLAPCubes;
            }
        }

        virtual protected void CreateOLAPQueriesCollection()
        {
            _OLAPQueries = new OLAPQuery.ChildOLAPQueryCollection(this, new Guid("f91599aa-5cc7-4b19-b653-2a09dfb6916c"));
            ((ITTChildObjectCollection)_OLAPQueries).GetChildren();
        }

        protected OLAPQuery.ChildOLAPQueryCollection _OLAPQueries = null;
        public OLAPQuery.ChildOLAPQueryCollection OLAPQueries
        {
            get
            {
                if (_OLAPQueries == null)
                    CreateOLAPQueriesCollection();
                return _OLAPQueries;
            }
        }

        override protected void CreateOLAPRolesCollectionViews()
        {
            base.CreateOLAPRolesCollectionViews();
            _OLAPMenuRoles = new OLAPMenuRole.ChildOLAPMenuRoleCollection(_OLAPRoles, "OLAPMenuRoles");
        }

        private OLAPMenuRole.ChildOLAPMenuRoleCollection _OLAPMenuRoles = null;
        public OLAPMenuRole.ChildOLAPMenuRoleCollection OLAPMenuRoles
        {
            get
            {
                if (_OLAPRoles == null)
                    CreateOLAPRolesCollection();
                return _OLAPMenuRoles;
            }            
        }

        protected OLAPMenu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OLAPMenu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OLAPMenu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OLAPMenu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OLAPMenu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLAPMENU", dataRow) { }
        protected OLAPMenu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLAPMENU", dataRow, isImported) { }
        public OLAPMenu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OLAPMenu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OLAPMenu() : base() { }

    }
}