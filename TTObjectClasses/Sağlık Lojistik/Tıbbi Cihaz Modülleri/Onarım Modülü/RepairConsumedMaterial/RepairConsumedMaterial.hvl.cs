
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RepairConsumedMaterial")] 

    /// <summary>
    /// Onarımda Kullanılan Malzemeler Sekmesi
    /// </summary>
    public  partial class RepairConsumedMaterial : ConsumedMaterial
    {
        public class RepairConsumedMaterialList : TTObjectCollection<RepairConsumedMaterial> { }
                    
        public class ChildRepairConsumedMaterialCollection : TTObject.TTChildObjectCollection<RepairConsumedMaterial>
        {
            public ChildRepairConsumedMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRepairConsumedMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class RepairConsumableMaterialNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? RequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIRCONSUMEDMATERIAL"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? SuppliedAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIEDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIRCONSUMEDMATERIAL"].AllPropertyDefs["SUPPLIEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public RepairConsumableMaterialNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RepairConsumableMaterialNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RepairConsumableMaterialNQL_Class() : base() { }
        }

        public static BindingList<RepairConsumedMaterial.RepairConsumableMaterialNQL_Class> RepairConsumableMaterialNQL(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIRCONSUMEDMATERIAL"].QueryDefs["RepairConsumableMaterialNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<RepairConsumedMaterial.RepairConsumableMaterialNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RepairConsumedMaterial.RepairConsumableMaterialNQL_Class> RepairConsumableMaterialNQL(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIRCONSUMEDMATERIAL"].QueryDefs["RepairConsumableMaterialNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<RepairConsumedMaterial.RepairConsumableMaterialNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public Repair Repair
        {
            get { return (Repair)((ITTObject)this).GetParent("REPAIR"); }
            set { this["REPAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RepairConsumedMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RepairConsumedMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RepairConsumedMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RepairConsumedMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RepairConsumedMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REPAIRCONSUMEDMATERIAL", dataRow) { }
        protected RepairConsumedMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REPAIRCONSUMEDMATERIAL", dataRow, isImported) { }
        public RepairConsumedMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RepairConsumedMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RepairConsumedMaterial() : base() { }

    }
}