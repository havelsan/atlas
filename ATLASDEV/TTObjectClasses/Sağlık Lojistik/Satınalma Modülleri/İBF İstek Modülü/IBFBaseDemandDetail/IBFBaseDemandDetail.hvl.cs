
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IBFBaseDemandDetail")] 

    /// <summary>
    /// İBF istek işleminde, İBF kalemleri için temel sınıftır.
    /// </summary>
    public  abstract  partial class IBFBaseDemandDetail : TTObject
    {
        public class IBFBaseDemandDetailList : TTObjectCollection<IBFBaseDemandDetail> { }
                    
        public class ChildIBFBaseDemandDetailCollection : TTObject.TTChildObjectCollection<IBFBaseDemandDetail>
        {
            public ChildIBFBaseDemandDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIBFBaseDemandDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("28662ca0-6fd6-4a8f-8cd9-3dc69151b79f"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("bae6c84c-c920-41b2-9136-221e13a8b558"); } }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Klinik Onay Miktarı
    /// </summary>
        public Currency? ClinicApprovedAmount
        {
            get { return (Currency?)this["CLINICAPPROVEDAMOUNT"]; }
            set { this["CLINICAPPROVEDAMOUNT"] = value; }
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
    /// Nato Stok No
    /// </summary>
        public string NSN
        {
            get { return (string)this["NSN"]; }
            set { this["NSN"] = value; }
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
    /// Önceki Yıl Sarf Miktarı
    /// </summary>
        public Currency? ConsumptionAmount
        {
            get { return (Currency?)this["CONSUMPTIONAMOUNT"]; }
            set { this["CONSUMPTIONAMOUNT"] = value; }
        }

    /// <summary>
    /// İdari Şartnameye Atıfta Bulunulan Hususlar
    /// </summary>
        public string ISABH
        {
            get { return (string)this["ISABH"]; }
            set { this["ISABH"] = value; }
        }

    /// <summary>
    /// İstek Miktarı
    /// </summary>
        public Currency? RequestAmount
        {
            get { return (Currency?)this["REQUESTAMOUNT"]; }
            set { this["REQUESTAMOUNT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string DetailDescription
        {
            get { return (string)this["DETAILDESCRIPTION"]; }
            set { this["DETAILDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Birim Depo Mevcudu
    /// </summary>
        public Currency? StoreStocks
        {
            get { return (Currency?)this["STORESTOCKS"]; }
            set { this["STORESTOCKS"] = value; }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AnnualRequirementDetail AnnualRequirementDetail
        {
            get { return (AnnualRequirementDetail)((ITTObject)this).GetParent("ANNUALREQUIREMENTDETAIL"); }
            set { this["ANNUALREQUIREMENTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IBFDemand IBFDemand
        {
            get { return (IBFDemand)((ITTObject)this).GetParent("IBFDEMAND"); }
            set { this["IBFDEMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IBFBaseDemandDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IBFBaseDemandDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IBFBaseDemandDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IBFBaseDemandDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IBFBaseDemandDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IBFBASEDEMANDDETAIL", dataRow) { }
        protected IBFBaseDemandDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IBFBASEDEMANDDETAIL", dataRow, isImported) { }
        public IBFBaseDemandDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IBFBaseDemandDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IBFBaseDemandDetail() : base() { }

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