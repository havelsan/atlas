
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialRepair")] 

    /// <summary>
    /// Onarım [Stok Numaralı]
    /// </summary>
    public  partial class MaterialRepair : Repair
    {
        public class MaterialRepairList : TTObjectCollection<MaterialRepair> { }
                    
        public class ChildMaterialRepairCollection : TTObject.TTChildObjectCollection<MaterialRepair>
        {
            public ChildMaterialRepairCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialRepairCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMaterialRepairQuery_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? RequestNoSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNOSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["REQUESTNOSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string HEKReportDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["HEKREPORTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DeliveredPerson
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVEREDPERSON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["DELIVEREDPERSON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RULObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RULOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["RULOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RepairNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["REPAIRNOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryToFirmDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYTOFIRMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["DELIVERYTOFIRMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string UserTel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERTEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["USERTEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["DELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string StateIDBeforeLastControl
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEIDBEFORELASTCONTROL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["STATEIDBEFORELASTCONTROL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DetailDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["DETAILDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActualDeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTUALDELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["ACTUALDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PreControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRECONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["PRECONTROLNOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReceiveDateFromFirm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVEDATEFROMFIRM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["RECEIVEDATEFROMFIRM"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public RepairPlaceEnum? RepairPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["REPAIRPLACE"].DataType;
                    return (RepairPlaceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string FaultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["FAULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? TotalWorkLoad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALWORKLOAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["TOTALWORKLOAD"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitWorkLoadPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITWORKLOADPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["UNITWORKLOADPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? RepairTotalCost
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRTOTALCOST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["REPAIRTOTALCOST"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MaterialPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["MATERIALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string HEKReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["HEKREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? LaborTotalCost
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABORTOTALCOST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["LABORTOTALCOST"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string HEKReportRepairDetail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTREPAIRDETAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["HEKREPORTREPAIRDETAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MaterialPurchasePrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPURCHASEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["MATERIALPURCHASEPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string LastControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTCONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["LASTCONTROLNOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? HEKMaterialAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKMATERIALAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["HEKMATERIALAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? FixedAssetMaterialAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDASSETMATERIALAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["FIXEDASSETMATERIALAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string FixedAssetMaterialDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDASSETMATERIALDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].AllPropertyDefs["FIXEDASSETMATERIALDESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? SenderSection
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SENDERSECTION"]);
                }
            }

            public Guid? WorkShop
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WORKSHOP"]);
                }
            }

            public Guid? ResponsibleWorkShopUser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLEWORKSHOPUSER"]);
                }
            }

            public Guid? FixedAssetDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FIXEDASSETDEFINITION"]);
                }
            }

            public Guid? DeviceUser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEVICEUSER"]);
                }
            }

            public GetMaterialRepairQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialRepairQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialRepairQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Son Kontrol
    /// </summary>
            public static Guid LastControl { get { return new Guid("523479d6-3d58-41ec-9042-a1eadde7cd68"); } }
    /// <summary>
    /// Seyyar Ekip
    /// </summary>
            public static Guid MobileTeam { get { return new Guid("7fd5b8cc-f56e-4c7a-96af-349b1bec4be1"); } }
    /// <summary>
    /// Ön Kontrol
    /// </summary>
            public static Guid PreControl { get { return new Guid("0ade7af8-11a0-4db3-b4db-e8baa4e9c70c"); } }
    /// <summary>
    /// Onarım
    /// </summary>
            public static Guid Repair { get { return new Guid("62858f10-e150-46d8-ae1c-73469d60b132"); } }
    /// <summary>
    /// Malzeme Temin
    /// </summary>
            public static Guid Supply_Of_Materials { get { return new Guid("5e6a67ac-2655-4c6d-a41b-533197ffa283"); } }
    /// <summary>
    /// Üst Kademeye Sevk
    /// </summary>
            public static Guid UpperStage { get { return new Guid("5e6643cc-eaa9-4ac5-a6c2-8daeae55f2a9"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("650e4e0e-421a-4a52-acb5-2210607bb237"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Comleted { get { return new Guid("78af8684-5273-48fc-a256-1ee7ff19b48b"); } }
    /// <summary>
    /// Teslim Tesellüm
    /// </summary>
            public static Guid Delivery { get { return new Guid("d796af28-4c43-406d-9bbd-fe2d3724ce1b"); } }
    /// <summary>
    /// Firma Onarımı
    /// </summary>
            public static Guid FirmRepair { get { return new Guid("83a133a8-32e1-4926-b9ea-12fc8098f812"); } }
    /// <summary>
    /// Garanti Onarımı
    /// </summary>
            public static Guid GuarantyRepair { get { return new Guid("998be4cc-4f4d-41cf-be81-983aeb1dde84"); } }
    /// <summary>
    /// HEK'e Ayırma
    /// </summary>
            public static Guid HEK { get { return new Guid("409bb493-582b-4e96-bc47-bf7f29c9eee3"); } }
        }

        public static BindingList<MaterialRepair.GetMaterialRepairQuery_Class> GetMaterialRepairQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].QueryDefs["GetMaterialRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MaterialRepair.GetMaterialRepairQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialRepair.GetMaterialRepairQuery_Class> GetMaterialRepairQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALREPAIR"].QueryDefs["GetMaterialRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MaterialRepair.GetMaterialRepairQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// HEK Malzeme Sayısı
    /// </summary>
        public double? HEKMaterialAmount
        {
            get { return (double?)this["HEKMATERIALAMOUNT"]; }
            set { this["HEKMATERIALAMOUNT"] = value; }
        }

    /// <summary>
    /// Malzeme Sayısı
    /// </summary>
        public double? FixedAssetMaterialAmount
        {
            get { return (double?)this["FIXEDASSETMATERIALAMOUNT"]; }
            set { this["FIXEDASSETMATERIALAMOUNT"] = value; }
        }

    /// <summary>
    /// Yapılacak İşlem
    /// </summary>
        public string FixedAssetMaterialDesc
        {
            get { return (string)this["FIXEDASSETMATERIALDESC"]; }
            set { this["FIXEDASSETMATERIALDESC"] = value; }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialRepair(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialRepair(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialRepair(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialRepair(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialRepair(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALREPAIR", dataRow) { }
        protected MaterialRepair(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALREPAIR", dataRow, isImported) { }
        public MaterialRepair(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialRepair(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialRepair() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}