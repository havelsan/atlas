
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Repair_ItemEquipment")] 

    /// <summary>
    /// Cihazla Gelen Muhtelif Malzemeler
    /// </summary>
    public  partial class Repair_ItemEquipment : ItemEquipment
    {
        public class Repair_ItemEquipmentList : TTObjectCollection<Repair_ItemEquipment> { }
                    
        public class ChildRepair_ItemEquipmentCollection : TTObject.TTChildObjectCollection<Repair_ItemEquipment>
        {
            public ChildRepair_ItemEquipmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRepair_ItemEquipmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRepairItemEquipmentOfCompletedRepair_Class : TTReportNqlObject 
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

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Comments
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMENTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["COMMENTS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsNormal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNORMAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["ISNORMAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsChanged
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCHANGED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["ISCHANGED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMissing
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMISSING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["ISMISSING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsDamaged
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDAMAGED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["ISDAMAGED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetRepairItemEquipmentOfCompletedRepair_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRepairItemEquipmentOfCompletedRepair_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRepairItemEquipmentOfCompletedRepair_Class() : base() { }
        }

        public static BindingList<Repair_ItemEquipment.GetRepairItemEquipmentOfCompletedRepair_Class> GetRepairItemEquipmentOfCompletedRepair(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].QueryDefs["GetRepairItemEquipmentOfCompletedRepair"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Repair_ItemEquipment.GetRepairItemEquipmentOfCompletedRepair_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair_ItemEquipment.GetRepairItemEquipmentOfCompletedRepair_Class> GetRepairItemEquipmentOfCompletedRepair(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].QueryDefs["GetRepairItemEquipmentOfCompletedRepair"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Repair_ItemEquipment.GetRepairItemEquipmentOfCompletedRepair_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Düşünceler
    /// </summary>
        public string Comments
        {
            get { return (string)this["COMMENTS"]; }
            set { this["COMMENTS"] = value; }
        }

    /// <summary>
    /// Tamam
    /// </summary>
        public bool? IsNormal
        {
            get { return (bool?)this["ISNORMAL"]; }
            set { this["ISNORMAL"] = value; }
        }

    /// <summary>
    /// Değişik
    /// </summary>
        public bool? IsChanged
        {
            get { return (bool?)this["ISCHANGED"]; }
            set { this["ISCHANGED"] = value; }
        }

    /// <summary>
    /// Eksik
    /// </summary>
        public bool? IsMissing
        {
            get { return (bool?)this["ISMISSING"]; }
            set { this["ISMISSING"] = value; }
        }

    /// <summary>
    /// Hasarlı
    /// </summary>
        public bool? IsDamaged
        {
            get { return (bool?)this["ISDAMAGED"]; }
            set { this["ISDAMAGED"] = value; }
        }

        public Repair Repair
        {
            get { return (Repair)((ITTObject)this).GetParent("REPAIR"); }
            set { this["REPAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Repair_ItemEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Repair_ItemEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Repair_ItemEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Repair_ItemEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Repair_ItemEquipment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REPAIR_ITEMEQUIPMENT", dataRow) { }
        protected Repair_ItemEquipment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REPAIR_ITEMEQUIPMENT", dataRow, isImported) { }
        public Repair_ItemEquipment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Repair_ItemEquipment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Repair_ItemEquipment() : base() { }

    }
}