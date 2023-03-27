
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenanceOrderType")] 

    /// <summary>
    /// Bakım Onarım / Sipariş Türü
    /// </summary>
    public  partial class MaintenanceOrderType : TTDefinitionSet
    {
        public class MaintenanceOrderTypeList : TTObjectCollection<MaintenanceOrderType> { }
                    
        public class ChildMaintenanceOrderTypeCollection : TTObject.TTChildObjectCollection<MaintenanceOrderType>
        {
            public ChildMaintenanceOrderTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenanceOrderTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIsActiveMaintenanceOrderType_Class : TTReportNqlObject 
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

            public string TypeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDERTYPE"].AllPropertyDefs["TYPENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TypeCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDERTYPE"].AllPropertyDefs["TYPECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TypeName_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDERTYPE"].AllPropertyDefs["TYPENAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetIsActiveMaintenanceOrderType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIsActiveMaintenanceOrderType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIsActiveMaintenanceOrderType_Class() : base() { }
        }

        public static BindingList<MaintenanceOrderType.GetIsActiveMaintenanceOrderType_Class> GetIsActiveMaintenanceOrderType(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDERTYPE"].QueryDefs["GetIsActiveMaintenanceOrderType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaintenanceOrderType.GetIsActiveMaintenanceOrderType_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaintenanceOrderType.GetIsActiveMaintenanceOrderType_Class> GetIsActiveMaintenanceOrderType(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDERTYPE"].QueryDefs["GetIsActiveMaintenanceOrderType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaintenanceOrderType.GetIsActiveMaintenanceOrderType_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Tür Adı
    /// </summary>
        public string TypeName
        {
            get { return (string)this["TYPENAME"]; }
            set { this["TYPENAME"] = value; }
        }

    /// <summary>
    /// Tür Kodu
    /// </summary>
        public string TypeCode
        {
            get { return (string)this["TYPECODE"]; }
            set { this["TYPECODE"] = value; }
        }

        public string TypeName_Shadow
        {
            get { return (string)this["TYPENAME_SHADOW"]; }
        }

        public MaintenanceOrderType ParentMaintenanceOrderType
        {
            get { return (MaintenanceOrderType)((ITTObject)this).GetParent("PARENTMAINTENANCEORDERTYPE"); }
            set { this["PARENTMAINTENANCEORDERTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMaintenanceOrderSubTypesCollection()
        {
            _MaintenanceOrderSubTypes = new MaintenanceOrderType.ChildMaintenanceOrderTypeCollection(this, new Guid("d81afab7-037a-4f59-bfef-ea26b34e271b"));
            ((ITTChildObjectCollection)_MaintenanceOrderSubTypes).GetChildren();
        }

        protected MaintenanceOrderType.ChildMaintenanceOrderTypeCollection _MaintenanceOrderSubTypes = null;
        public MaintenanceOrderType.ChildMaintenanceOrderTypeCollection MaintenanceOrderSubTypes
        {
            get
            {
                if (_MaintenanceOrderSubTypes == null)
                    CreateMaintenanceOrderSubTypesCollection();
                return _MaintenanceOrderSubTypes;
            }
        }

        protected MaintenanceOrderType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenanceOrderType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenanceOrderType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenanceOrderType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenanceOrderType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEORDERTYPE", dataRow) { }
        protected MaintenanceOrderType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEORDERTYPE", dataRow, isImported) { }
        public MaintenanceOrderType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenanceOrderType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenanceOrderType() : base() { }

    }
}