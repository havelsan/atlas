
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseOrderDetail")] 

    /// <summary>
    /// Her sipariş için sipariş detaylarının/kalemlerinin bilgilerinin tutulduğu sınıftır
    /// </summary>
    public  partial class PurchaseOrderDetail : TTObject
    {
        public class PurchaseOrderDetailList : TTObjectCollection<PurchaseOrderDetail> { }
                    
        public class ChildPurchaseOrderDetailCollection : TTObject.TTChildObjectCollection<PurchaseOrderDetail>
        {
            public ChildPurchaseOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("432fdc1d-6e5d-466b-b08c-48b8e6877013"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("349edb1c-fac8-4d79-9605-21d858db2d81"); } }
        }

        public static BindingList<PurchaseOrderDetail> GetByStatus(TTObjectContext objectContext, int STATUS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDERDETAIL"].QueryDefs["GetByStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATUS", STATUS);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseOrderDetail>(queryDef, paramList);
        }

    /// <summary>
    /// Tebliğ Edilen Alan Firma Yetkilisi
    /// </summary>
        public string AuthorizedFirmStaff
        {
            get { return (string)this["AUTHORIZEDFIRMSTAFF"]; }
            set { this["AUTHORIZEDFIRMSTAFF"] = value; }
        }

    /// <summary>
    /// Kalan Miktar
    /// </summary>
        public Currency? RestAmount
        {
            get { return (Currency?)this["RESTAMOUNT"]; }
            set { this["RESTAMOUNT"] = value; }
        }

    /// <summary>
    /// Teslim Tarihi
    /// </summary>
        public DateTime? DeliveryDate
        {
            get { return (DateTime?)this["DELIVERYDATE"]; }
            set { this["DELIVERYDATE"] = value; }
        }

    /// <summary>
    /// Sipariş Tutarı
    /// </summary>
        public BigCurrency? OrderPrice
        {
            get { return (BigCurrency?)this["ORDERPRICE"]; }
            set { this["ORDERPRICE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Tebliğ Şekli
    /// </summary>
        public NotificationTypeEnum? NotificationType
        {
            get { return (NotificationTypeEnum?)(int?)this["NOTIFICATIONTYPE"]; }
            set { this["NOTIFICATIONTYPE"] = value; }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public OrderDetailStatusEnum? Status
        {
            get { return (OrderDetailStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

        public PurchaseProjectDetail PurchaseProjectDetail
        {
            get { return (PurchaseProjectDetail)((ITTObject)this).GetParent("PURCHASEPROJECTDETAIL"); }
            set { this["PURCHASEPROJECTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseOrder PurchaseOrder
        {
            get { return (PurchaseOrder)((ITTObject)this).GetParent("PURCHASEORDER"); }
            set { this["PURCHASEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ContractDetail ContractDetail
        {
            get { return (ContractDetail)((ITTObject)this).GetParent("CONTRACTDETAIL"); }
            set { this["CONTRACTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PurchaseOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEORDERDETAIL", dataRow) { }
        protected PurchaseOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEORDERDETAIL", dataRow, isImported) { }
        public PurchaseOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseOrderDetail() : base() { }

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