
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UsedConsumedMaterail")] 

    /// <summary>
    /// Kullanılan Malzeme Sekmesi
    /// </summary>
    public  partial class UsedConsumedMaterail : TTObject, IUsedConsumeMaterial
    {
        public class UsedConsumedMaterailList : TTObjectCollection<UsedConsumedMaterail> { }
                    
        public class ChildUsedConsumedMaterailCollection : TTObject.TTChildObjectCollection<UsedConsumedMaterail>
        {
            public ChildUsedConsumedMaterailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUsedConsumedMaterailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUsedMaterialsOfRepair_Class : TTReportNqlObject 
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

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USEDCONSUMEDMATERAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Currency? RequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USEDCONSUMEDMATERAIL"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USEDCONSUMEDMATERAIL"].AllPropertyDefs["SUPPLIEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USEDCONSUMEDMATERAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public GetUsedMaterialsOfRepair_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUsedMaterialsOfRepair_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUsedMaterialsOfRepair_Class() : base() { }
        }

        [Serializable] 

        public partial class GetColletedCMRAction_Class : TTReportNqlObject 
        {
            public string Siparis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIPARIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Onarim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ONARIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yardimciatolye
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YARDIMCIATOLYE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKSTEP"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ambalajlama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMBALAJLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PACKAGINGDEPARTMENTACTION"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Malzeme_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEME_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USEDCONSUMEDMATERAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetColletedCMRAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetColletedCMRAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetColletedCMRAction_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("8f5ed680-a0d3-4231-b8d5-d56904fe9d41"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("2263c62b-0007-4d19-b717-3379c0726999"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("80e21add-654b-4bf1-9dad-5c528ac43563"); } }
        }

        public static BindingList<UsedConsumedMaterail.GetUsedMaterialsOfRepair_Class> GetUsedMaterialsOfRepair(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USEDCONSUMEDMATERAIL"].QueryDefs["GetUsedMaterialsOfRepair"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<UsedConsumedMaterail.GetUsedMaterialsOfRepair_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UsedConsumedMaterail.GetUsedMaterialsOfRepair_Class> GetUsedMaterialsOfRepair(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USEDCONSUMEDMATERAIL"].QueryDefs["GetUsedMaterialsOfRepair"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<UsedConsumedMaterail.GetUsedMaterialsOfRepair_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UsedConsumedMaterail.GetColletedCMRAction_Class> GetColletedCMRAction(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USEDCONSUMEDMATERAIL"].QueryDefs["GetColletedCMRAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<UsedConsumedMaterail.GetColletedCMRAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UsedConsumedMaterail.GetColletedCMRAction_Class> GetColletedCMRAction(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USEDCONSUMEDMATERAIL"].QueryDefs["GetColletedCMRAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<UsedConsumedMaterail.GetColletedCMRAction_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Birim Fiyat
    /// </summary>
        public BigCurrency? UnitPrice
        {
            get { return (BigCurrency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// İstenen Miktar
    /// </summary>
        public Currency? RequestAmount
        {
            get { return (Currency?)this["REQUESTAMOUNT"]; }
            set { this["REQUESTAMOUNT"] = value; }
        }

    /// <summary>
    /// Karşılanan Miktar
    /// </summary>
        public Currency? SuppliedAmount
        {
            get { return (Currency?)this["SUPPLIEDAMOUNT"]; }
            set { this["SUPPLIEDAMOUNT"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public WorkStep WorkStep
        {
            get { return (WorkStep)((ITTObject)this).GetParent("WORKSTEP"); }
            set { this["WORKSTEP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockOut StockOut
        {
            get { return (StockOut)((ITTObject)this).GetParent("STOCKOUT"); }
            set { this["STOCKOUT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenanceOrder MaintenanceOrder
        {
            get { return (MaintenanceOrder)((ITTObject)this).GetParent("MAINTENANCEORDER"); }
            set { this["MAINTENANCEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Repair Repair
        {
            get { return (Repair)((ITTObject)this).GetParent("REPAIR"); }
            set { this["REPAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PackagingDepartmentAction PackagingDepartmentAction
        {
            get { return (PackagingDepartmentAction)((ITTObject)this).GetParent("PACKAGINGDEPARTMENTACTION"); }
            set { this["PACKAGINGDEPARTMENTACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Calibration Calibration
        {
            get { return (Calibration)((ITTObject)this).GetParent("CALIBRATION"); }
            set { this["CALIBRATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OuttableLot OuttableLot
        {
            get { return (OuttableLot)((ITTObject)this).GetParent("OUTTABLELOT"); }
            set { this["OUTTABLELOT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UsedConsumedMaterail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UsedConsumedMaterail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UsedConsumedMaterail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UsedConsumedMaterail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UsedConsumedMaterail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USEDCONSUMEDMATERAIL", dataRow) { }
        protected UsedConsumedMaterail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USEDCONSUMEDMATERAIL", dataRow, isImported) { }
        public UsedConsumedMaterail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UsedConsumedMaterail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UsedConsumedMaterail() : base() { }

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