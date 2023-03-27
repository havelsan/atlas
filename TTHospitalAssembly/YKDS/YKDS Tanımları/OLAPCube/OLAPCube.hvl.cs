
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OLAPCube")] 

    public  partial class OLAPCube : OLAPBaseAction
    {
        public class OLAPCubeList : TTObjectCollection<OLAPCube> { }
                    
        public class ChildOLAPCubeCollection : TTObject.TTChildObjectCollection<OLAPCube>
        {
            public ChildOLAPCubeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOLAPCubeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOLAPCubeItems_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["CAPTION"].DataType;
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

            public GetOLAPCubeItems_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOLAPCubeItems_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOLAPCubeItems_Class() : base() { }
        }

        [Serializable] 

        public partial class GetChildOLAPCubes_Class : TTReportNqlObject 
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

            public int? OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["ORDERNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CubeNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CUBENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["CUBENO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetChildOLAPCubes_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChildOLAPCubes_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChildOLAPCubes_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOLAPCubes_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CubeNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CUBENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["CUBENO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public GetOLAPCubes_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOLAPCubes_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOLAPCubes_Class() : base() { }
        }

    /// <summary>
    /// For SuperNova
    /// </summary>
        public static BindingList<OLAPCube.GetOLAPCubeItems_Class> GetOLAPCubeItems(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].QueryDefs["GetOLAPCubeItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPCube.GetOLAPCubeItems_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// For SuperNova
    /// </summary>
        public static BindingList<OLAPCube.GetOLAPCubeItems_Class> GetOLAPCubeItems(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].QueryDefs["GetOLAPCubeItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPCube.GetOLAPCubeItems_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OLAPCube.GetChildOLAPCubes_Class> GetChildOLAPCubes(Guid PARENTMENU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].QueryDefs["GetChildOLAPCubes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTMENU", PARENTMENU);

            return TTReportNqlObject.QueryObjects<OLAPCube.GetChildOLAPCubes_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OLAPCube.GetChildOLAPCubes_Class> GetChildOLAPCubes(TTObjectContext objectContext, Guid PARENTMENU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].QueryDefs["GetChildOLAPCubes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTMENU", PARENTMENU);

            return TTReportNqlObject.QueryObjects<OLAPCube.GetChildOLAPCubes_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OLAPCube.GetOLAPCubes_Class> GetOLAPCubes(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].QueryDefs["GetOLAPCubes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPCube.GetOLAPCubes_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OLAPCube.GetOLAPCubes_Class> GetOLAPCubes(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAPCUBE"].QueryDefs["GetOLAPCubes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OLAPCube.GetOLAPCubes_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? OrderNO
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public string Caption
        {
            get { return (string)this["CAPTION"]; }
            set { this["CAPTION"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public TTSequence CubeNO
        {
            get { return GetSequence("CUBENO"); }
        }

        public OLAPMenu OLAPMenu
        {
            get { return (OLAPMenu)((ITTObject)this).GetParent("OLAPMENU"); }
            set { this["OLAPMENU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateOLAPRolesCollectionViews()
        {
            base.CreateOLAPRolesCollectionViews();
            _OLAPCubeRoles = new OLAPCubeRole.ChildOLAPCubeRoleCollection(_OLAPRoles, "OLAPCubeRoles");
        }

        private OLAPCubeRole.ChildOLAPCubeRoleCollection _OLAPCubeRoles = null;
        public OLAPCubeRole.ChildOLAPCubeRoleCollection OLAPCubeRoles
        {
            get
            {
                if (_OLAPRoles == null)
                    CreateOLAPRolesCollection();
                return _OLAPCubeRoles;
            }            
        }

        protected OLAPCube(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OLAPCube(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OLAPCube(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OLAPCube(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OLAPCube(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLAPCUBE", dataRow) { }
        protected OLAPCube(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLAPCUBE", dataRow, isImported) { }
        public OLAPCube(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OLAPCube(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OLAPCube() : base() { }

    }
}