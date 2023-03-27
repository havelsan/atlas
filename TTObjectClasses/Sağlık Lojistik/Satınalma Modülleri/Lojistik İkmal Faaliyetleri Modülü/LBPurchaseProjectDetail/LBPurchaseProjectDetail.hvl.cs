
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LBPurchaseProjectDetail")] 

    /// <summary>
    /// Lojistik ikmal faaliyetlerinde kullanılan temel detay sınıfıdır
    /// </summary>
    public  partial class LBPurchaseProjectDetail : TTObject
    {
        public class LBPurchaseProjectDetailList : TTObjectCollection<LBPurchaseProjectDetail> { }
                    
        public class ChildLBPurchaseProjectDetailCollection : TTObject.TTChildObjectCollection<LBPurchaseProjectDetail>
        {
            public ChildLBPurchaseProjectDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLBPurchaseProjectDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("222ab4a0-5000-455c-9023-3630b0c02766"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("fcfa3d5d-5780-4b74-8f6e-7b3188e52e8a"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("cccf7119-49f4-4a37-9b44-de0b674ac4ff"); } }
        }

    /// <summary>
    /// İptal
    /// </summary>
        public Currency? CancelledAmount
        {
            get { return (Currency?)this["CANCELLEDAMOUNT"]; }
            set { this["CANCELLEDAMOUNT"] = value; }
        }

    /// <summary>
    /// İstek Miktarı
    /// </summary>
        public Currency? RequestedAmount
        {
            get { return (Currency?)this["REQUESTEDAMOUNT"]; }
            set { this["REQUESTEDAMOUNT"] = value; }
        }

    /// <summary>
    /// Son İBF İstek Miktarı
    /// </summary>
        public Currency? LastIBFRequestAmount
        {
            get { return (Currency?)this["LASTIBFREQUESTAMOUNT"]; }
            set { this["LASTIBFREQUESTAMOUNT"] = value; }
        }

    /// <summary>
    /// Onaylanan Miktar
    /// </summary>
        public Currency? ApprovedAmount
        {
            get { return (Currency?)this["APPROVEDAMOUNT"]; }
            set { this["APPROVEDAMOUNT"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public long? OrderNO
        {
            get { return (long?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Önceki Yıl Sarf Miktarı
    /// </summary>
        public Currency? ConsumptionAmount
        {
            get { return (Currency?)this["CONSUMPTIONAMOUNT"]; }
            set { this["CONSUMPTIONAMOUNT"] = value; }
        }

    /// <summary>
    /// Nato Stok No
    /// </summary>
        public string NSN
        {
            get { return (string)this["NSN"]; }
            set { this["NSN"] = value; }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateLBApproveDetailsCollection()
        {
            _LBApproveDetails = new LBApproveDetail.ChildLBApproveDetailCollection(this, new Guid("824ad0a9-ddc7-46d5-a9b1-02224ffc7a9e"));
            ((ITTChildObjectCollection)_LBApproveDetails).GetChildren();
        }

        protected LBApproveDetail.ChildLBApproveDetailCollection _LBApproveDetails = null;
        public LBApproveDetail.ChildLBApproveDetailCollection LBApproveDetails
        {
            get
            {
                if (_LBApproveDetails == null)
                    CreateLBApproveDetailsCollection();
                return _LBApproveDetails;
            }
        }

        protected LBPurchaseProjectDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LBPurchaseProjectDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LBPurchaseProjectDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LBPurchaseProjectDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LBPurchaseProjectDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LBPURCHASEPROJECTDETAIL", dataRow) { }
        protected LBPurchaseProjectDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LBPURCHASEPROJECTDETAIL", dataRow, isImported) { }
        public LBPurchaseProjectDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LBPurchaseProjectDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LBPurchaseProjectDetail() : base() { }

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