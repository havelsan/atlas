
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnnualRequirementDetail")] 

    public  abstract  partial class AnnualRequirementDetail : TTObject
    {
        public class AnnualRequirementDetailList : TTObjectCollection<AnnualRequirementDetail> { }
                    
        public class ChildAnnualRequirementDetailCollection : TTObject.TTChildObjectCollection<AnnualRequirementDetail>
        {
            public ChildAnnualRequirementDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnnualRequirementDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("d9fc1811-1f02-4d91-905e-96cb589bd920"); } }
            public static Guid New { get { return new Guid("b598888e-7eef-48fb-9f95-495cae2a77ca"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("81b0c9a7-849c-4b52-b4b8-acd19a2615c8"); } }
        }

    /// <summary>
    /// Talep Miktarı
    /// </summary>
        public Currency? RequestAmount
        {
            get { return (Currency?)this["REQUESTAMOUNT"]; }
            set { this["REQUESTAMOUNT"] = value; }
        }

    /// <summary>
    /// Lojistik Büro Onay Miktarı
    /// </summary>
        public Currency? LB_ApproveAmount
        {
            get { return (Currency?)this["LB_APPROVEAMOUNT"]; }
            set { this["LB_APPROVEAMOUNT"] = value; }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public AnnualRequirementDetailEnum? Status
        {
            get { return (AnnualRequirementDetailEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Kur
    /// </summary>
        public Currency? Rate
        {
            get { return (Currency?)this["RATE"]; }
            set { this["RATE"] = value; }
        }

    /// <summary>
    /// Saymanlık Mevcudu
    /// </summary>
        public Currency? AccountancyStock
        {
            get { return (Currency?)this["ACCOUNTANCYSTOCK"]; }
            set { this["ACCOUNTANCYSTOCK"] = value; }
        }

    /// <summary>
    /// İptal
    /// </summary>
        public bool? Cancelled
        {
            get { return (bool?)this["CANCELLED"]; }
            set { this["CANCELLED"] = value; }
        }

    /// <summary>
    /// Lojistik Büro Onay Miktarı
    /// </summary>
        public Currency? ACC_ApproveAmount
        {
            get { return (Currency?)this["ACC_APPROVEAMOUNT"]; }
            set { this["ACC_APPROVEAMOUNT"] = value; }
        }

    /// <summary>
    /// Teknik Müdür Onay Miktarı
    /// </summary>
        public Currency? TM_ApproveAmount
        {
            get { return (Currency?)this["TM_APPROVEAMOUNT"]; }
            set { this["TM_APPROVEAMOUNT"] = value; }
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
    /// Son İBF İstek Miktarı
    /// </summary>
        public Currency? LastIBFRequestAmount
        {
            get { return (Currency?)this["LASTIBFREQUESTAMOUNT"]; }
            set { this["LASTIBFREQUESTAMOUNT"] = value; }
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
    /// Birim Fiyat
    /// </summary>
        public BigCurrency? UnitPrice
        {
            get { return (BigCurrency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// Klinik Mevcutları
    /// </summary>
        public Currency? ClinicStocks
        {
            get { return (Currency?)this["CLINICSTOCKS"]; }
            set { this["CLINICSTOCKS"] = value; }
        }

    /// <summary>
    /// Lojistik Daire Onay Miktarı
    /// </summary>
        public Currency? LD_ApproveAmount
        {
            get { return (Currency?)this["LD_APPROVEAMOUNT"]; }
            set { this["LD_APPROVEAMOUNT"] = value; }
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

        public AnnualRequirement AnnualRequirement
        {
            get { return (AnnualRequirement)((ITTObject)this).GetParent("ANNUALREQUIREMENT"); }
            set { this["ANNUALREQUIREMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateARD_AccountancyAmountsCollection()
        {
            _ARD_AccountancyAmounts = new ARD_AccountancyAmount.ChildARD_AccountancyAmountCollection(this, new Guid("66794630-f8ff-4c60-8178-a5a00054ce19"));
            ((ITTChildObjectCollection)_ARD_AccountancyAmounts).GetChildren();
        }

        protected ARD_AccountancyAmount.ChildARD_AccountancyAmountCollection _ARD_AccountancyAmounts = null;
        public ARD_AccountancyAmount.ChildARD_AccountancyAmountCollection ARD_AccountancyAmounts
        {
            get
            {
                if (_ARD_AccountancyAmounts == null)
                    CreateARD_AccountancyAmountsCollection();
                return _ARD_AccountancyAmounts;
            }
        }

        virtual protected void CreateARDDetDetailsCollection()
        {
            _ARDDetDetails = new ARDDetDetail.ChildARDDetDetailCollection(this, new Guid("1fe1cb14-11eb-44d8-94fe-e7323b70a0be"));
            ((ITTChildObjectCollection)_ARDDetDetails).GetChildren();
        }

        protected ARDDetDetail.ChildARDDetDetailCollection _ARDDetDetails = null;
        public ARDDetDetail.ChildARDDetDetailCollection ARDDetDetails
        {
            get
            {
                if (_ARDDetDetails == null)
                    CreateARDDetDetailsCollection();
                return _ARDDetDetails;
            }
        }

        protected AnnualRequirementDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnnualRequirementDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnnualRequirementDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnnualRequirementDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnnualRequirementDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANNUALREQUIREMENTDETAIL", dataRow) { }
        protected AnnualRequirementDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANNUALREQUIREMENTDETAIL", dataRow, isImported) { }
        public AnnualRequirementDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnnualRequirementDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnnualRequirementDetail() : base() { }

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