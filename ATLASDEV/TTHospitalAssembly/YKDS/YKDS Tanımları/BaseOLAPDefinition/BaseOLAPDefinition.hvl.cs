
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseOLAPDefinition")] 

    public  abstract  partial class BaseOLAPDefinition : TerminologyManagerDef
    {
        public class BaseOLAPDefinitionList : TTObjectCollection<BaseOLAPDefinition> { }
                    
        public class ChildBaseOLAPDefinitionCollection : TTObject.TTChildObjectCollection<BaseOLAPDefinition>
        {
            public ChildBaseOLAPDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseOLAPDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBaseMenus_Class : TTReportNqlObject 
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

            public GetBaseMenus_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBaseMenus_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBaseMenus_Class() : base() { }
        }

        public static BindingList<BaseOLAPDefinition> GetBaseMenusObjectQuery(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEOLAPDEFINITION"].QueryDefs["GetBaseMenusObjectQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<BaseOLAPDefinition>(queryDef, paramList);
        }

        public static BindingList<BaseOLAPDefinition.GetBaseMenus_Class> GetBaseMenus(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEOLAPDEFINITION"].QueryDefs["GetBaseMenus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseOLAPDefinition.GetBaseMenus_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseOLAPDefinition.GetBaseMenus_Class> GetBaseMenus(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEOLAPDEFINITION"].QueryDefs["GetBaseMenus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseOLAPDefinition.GetBaseMenus_Class>(objectContext, queryDef, paramList, pi);
        }

        virtual protected void CreateOLAPRolesCollectionViews()
        {
        }

        virtual protected void CreateOLAPRolesCollection()
        {
            _OLAPRoles = new BaseOLAPRole.ChildBaseOLAPRoleCollection(this, new Guid("85de1712-b2c8-482f-84a1-bc417baa2afe"));
            CreateOLAPRolesCollectionViews();
            ((ITTChildObjectCollection)_OLAPRoles).GetChildren();
        }

        protected BaseOLAPRole.ChildBaseOLAPRoleCollection _OLAPRoles = null;
    /// <summary>
    /// Child collection for OLAPDefinition Parent Relation
    /// </summary>
        public BaseOLAPRole.ChildBaseOLAPRoleCollection OLAPRoles
        {
            get
            {
                if (_OLAPRoles == null)
                    CreateOLAPRolesCollection();
                return _OLAPRoles;
            }
        }

        protected BaseOLAPDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseOLAPDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseOLAPDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseOLAPDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseOLAPDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEOLAPDEFINITION", dataRow) { }
        protected BaseOLAPDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEOLAPDEFINITION", dataRow, isImported) { }
        public BaseOLAPDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseOLAPDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseOLAPDefinition() : base() { }

    }
}