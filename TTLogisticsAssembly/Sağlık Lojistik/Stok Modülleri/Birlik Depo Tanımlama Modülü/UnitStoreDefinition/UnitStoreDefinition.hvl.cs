
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UnitStoreDefinition")] 

    /// <summary>
    /// Birlik Depo Tanımları
    /// </summary>
    public  partial class UnitStoreDefinition : Store, IUnitStoreDefinition
    {
        public class UnitStoreDefinitionList : TTObjectCollection<UnitStoreDefinition> { }
                    
        public class ChildUnitStoreDefinitionCollection : TTObject.TTChildObjectCollection<UnitStoreDefinition>
        {
            public ChildUnitStoreDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUnitStoreDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUnitStoreDefinition_Class : TTReportNqlObject 
        {
            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OpenCloseEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREDEFINITION"].AllPropertyDefs["STATUS"].DataType;
                    return (OpenCloseEnum?)(int)dataType.ConvertValue(val);
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetUnitStoreDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnitStoreDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnitStoreDefinition_Class() : base() { }
        }

        public static BindingList<UnitStoreDefinition.GetUnitStoreDefinition_Class> GetUnitStoreDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREDEFINITION"].QueryDefs["GetUnitStoreDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UnitStoreDefinition.GetUnitStoreDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UnitStoreDefinition.GetUnitStoreDefinition_Class> GetUnitStoreDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREDEFINITION"].QueryDefs["GetUnitStoreDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UnitStoreDefinition.GetUnitStoreDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public ResUser StoreResponsible
        {
            get { return (ResUser)((ITTObject)this).GetParent("STORERESPONSIBLE"); }
            set { this["STORERESPONSIBLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UnitStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UnitStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UnitStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UnitStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UnitStoreDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UNITSTOREDEFINITION", dataRow) { }
        protected UnitStoreDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UNITSTOREDEFINITION", dataRow, isImported) { }
        public UnitStoreDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UnitStoreDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UnitStoreDefinition() : base() { }

    }
}