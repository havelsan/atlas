
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseOrder")] 

    /// <summary>
    /// Firmaya verilen sipariş bilgilerinin tutuldufu sınıftır
    /// </summary>
    public  partial class PurchaseOrder : BasePurchaseAction, IPurchaseOrderWorkList
    {
        public class PurchaseOrderList : TTObjectCollection<PurchaseOrder> { }
                    
        public class ChildPurchaseOrderCollection : TTObject.TTChildObjectCollection<PurchaseOrder>
        {
            public ChildPurchaseOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Prosedürler
    /// </summary>
            public static Guid Procedures { get { return new Guid("02ccf945-d3a7-4e2d-9abe-18a61bbc3e7c"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("253506d9-e9eb-46c8-bb83-1a5f9f8692e5"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("871732d6-5eb0-4554-9ac1-5cb13b3b82ca"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("bb1d22db-c8f2-4d94-9371-bcae75ebdf64"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("165fa04d-eaa0-4cff-ab06-d356c655a840"); } }
        }

        public static BindingList<PurchaseOrder> GetOrderByOrderNo(TTObjectContext objectContext, int ORDERNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].QueryDefs["GetOrderByOrderNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDERNO", ORDERNO);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseOrder>(queryDef, paramList);
        }

        public static BindingList<PurchaseOrder> GetOrdersByDueDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].QueryDefs["GetOrdersByDueDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseOrder>(queryDef, paramList);
        }

        public static BindingList<PurchaseOrder> PurchaseOrderListBySupplierNQL(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].QueryDefs["PurchaseOrderListBySupplierNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PurchaseOrder>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<PurchaseOrder> GetOrdersByOrderDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].QueryDefs["GetOrdersByOrderDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseOrder>(queryDef, paramList);
        }

        public static BindingList<PurchaseOrder> GetAllOrdersByFirm(TTObjectContext objectContext, string SUPPLIER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].QueryDefs["GetAllOrdersByFirm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUPPLIER", SUPPLIER);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseOrder>(queryDef, paramList);
        }

        public static BindingList<PurchaseOrder> GetCurrentOrdersByFirm(TTObjectContext objectContext, string SUPPLIER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].QueryDefs["GetCurrentOrdersByFirm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUPPLIER", SUPPLIER);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseOrder>(queryDef, paramList);
        }

        public static BindingList<PurchaseOrder> WorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].QueryDefs["WorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseOrder>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<PurchaseOrder> GetActiveOrders(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].QueryDefs["GetActiveOrders"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PurchaseOrder>(queryDef, paramList);
        }

    /// <summary>
    /// Sipariş No
    /// </summary>
        public long? OrderNO
        {
            get { return (long?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Sipariş Verilmiş Tutar
    /// </summary>
        public double? OrderedPrice
        {
            get { return (double?)this["ORDEREDPRICE"]; }
            set { this["ORDEREDPRICE"] = value; }
        }

    /// <summary>
    /// Uyarı Mesajı
    /// </summary>
        public string WarningMsg
        {
            get { return (string)this["WARNINGMSG"]; }
            set { this["WARNINGMSG"] = value; }
        }

    /// <summary>
    /// Kalan Sipariş Tutarı
    /// </summary>
        public double? RemainingOrderPrice
        {
            get { return (double?)this["REMAININGORDERPRICE"]; }
            set { this["REMAININGORDERPRICE"] = value; }
        }

    /// <summary>
    /// Depoya Teslim Tarihi
    /// </summary>
        public DateTime? DueDate
        {
            get { return (DateTime?)this["DUEDATE"]; }
            set { this["DUEDATE"] = value; }
        }

    /// <summary>
    /// Sipraiş Tarihi
    /// </summary>
        public DateTime? OrderDate
        {
            get { return (DateTime?)this["ORDERDATE"]; }
            set { this["ORDERDATE"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Contract Contract
        {
            get { return (Contract)((ITTObject)this).GetParent("CONTRACT"); }
            set { this["CONTRACT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Contract TmpContract
        {
            get { return (Contract)((ITTObject)this).GetParent("TMPCONTRACT"); }
            set { this["TMPCONTRACT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateKIMKsCollection()
        {
            _KIMKs = new InternalCorrespondenceKIMK.ChildInternalCorrespondenceKIMKCollection(this, new Guid("2625b00b-4b73-4c6e-8e04-0543745dfe69"));
            ((ITTChildObjectCollection)_KIMKs).GetChildren();
        }

        protected InternalCorrespondenceKIMK.ChildInternalCorrespondenceKIMKCollection _KIMKs = null;
        public InternalCorrespondenceKIMK.ChildInternalCorrespondenceKIMKCollection KIMKs
        {
            get
            {
                if (_KIMKs == null)
                    CreateKIMKsCollection();
                return _KIMKs;
            }
        }

        virtual protected void CreatePurchaseOrderDetailsCollection()
        {
            _PurchaseOrderDetails = new PurchaseOrderDetail.ChildPurchaseOrderDetailCollection(this, new Guid("9ba27ef1-8401-4602-a764-4793890a61d7"));
            ((ITTChildObjectCollection)_PurchaseOrderDetails).GetChildren();
        }

        protected PurchaseOrderDetail.ChildPurchaseOrderDetailCollection _PurchaseOrderDetails = null;
        public PurchaseOrderDetail.ChildPurchaseOrderDetailCollection PurchaseOrderDetails
        {
            get
            {
                if (_PurchaseOrderDetails == null)
                    CreatePurchaseOrderDetailsCollection();
                return _PurchaseOrderDetails;
            }
        }

        virtual protected void CreateBaseCorrespondencesCollection()
        {
            _BaseCorrespondences = new BaseCorrespondence.ChildBaseCorrespondenceCollection(this, new Guid("f65bd5d1-4006-441f-bf9f-9db380610e55"));
            ((ITTChildObjectCollection)_BaseCorrespondences).GetChildren();
        }

        protected BaseCorrespondence.ChildBaseCorrespondenceCollection _BaseCorrespondences = null;
        public BaseCorrespondence.ChildBaseCorrespondenceCollection BaseCorrespondences
        {
            get
            {
                if (_BaseCorrespondences == null)
                    CreateBaseCorrespondencesCollection();
                return _BaseCorrespondences;
            }
        }

        virtual protected void CreateTmpContractsCollection()
        {
            _TmpContracts = new Contract.ChildContractCollection(this, new Guid("42783ee8-2fbd-4193-b5a0-d4c5da1153f5"));
            ((ITTChildObjectCollection)_TmpContracts).GetChildren();
        }

        protected Contract.ChildContractCollection _TmpContracts = null;
        public Contract.ChildContractCollection TmpContracts
        {
            get
            {
                if (_TmpContracts == null)
                    CreateTmpContractsCollection();
                return _TmpContracts;
            }
        }

        protected PurchaseOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEORDER", dataRow) { }
        protected PurchaseOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEORDER", dataRow, isImported) { }
        public PurchaseOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseOrder() : base() { }

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