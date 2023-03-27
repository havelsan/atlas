
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseOLAPRole")] 

    public  abstract  partial class BaseOLAPRole : BaseOLAPDefinition
    {
        public class BaseOLAPRoleList : TTObjectCollection<BaseOLAPRole> { }
                    
        public class ChildBaseOLAPRoleCollection : TTObject.TTChildObjectCollection<BaseOLAPRole>
        {
            public ChildBaseOLAPRoleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseOLAPRoleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOLAPRoles_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? RoleID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROLEID"]);
                }
            }

            public Guid? Olapmenu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OLAPMENU"]);
                }
            }

            public GetOLAPRoles_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOLAPRoles_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOLAPRoles_Class() : base() { }
        }

        public static BindingList<BaseOLAPRole.GetOLAPRoles_Class> GetOLAPRoles(Guid OLAPMENU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEOLAPROLE"].QueryDefs["GetOLAPRoles"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OLAPMENU", OLAPMENU);

            return TTReportNqlObject.QueryObjects<BaseOLAPRole.GetOLAPRoles_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseOLAPRole.GetOLAPRoles_Class> GetOLAPRoles(TTObjectContext objectContext, Guid OLAPMENU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEOLAPROLE"].QueryDefs["GetOLAPRoles"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OLAPMENU", OLAPMENU);

            return TTReportNqlObject.QueryObjects<BaseOLAPRole.GetOLAPRoles_Class>(objectContext, queryDef, paramList, pi);
        }

        public Guid? RoleID
        {
            get { return (Guid?)this["ROLEID"]; }
            set { this["ROLEID"] = value; }
        }

    /// <summary>
    /// OLAPDefinition Parent Relation
    /// </summary>
        public BaseOLAPDefinition BaseOLAPDefinition
        {
            get { return (BaseOLAPDefinition)((ITTObject)this).GetParent("BASEOLAPDEFINITION"); }
            set { this["BASEOLAPDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseOLAPRole(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseOLAPRole(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseOLAPRole(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseOLAPRole(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseOLAPRole(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEOLAPROLE", dataRow) { }
        protected BaseOLAPRole(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEOLAPROLE", dataRow, isImported) { }
        public BaseOLAPRole(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseOLAPRole(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseOLAPRole() : base() { }

    }
}