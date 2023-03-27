
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChattelDocumentWithPurchase")] 

    /// <summary>
    /// Satınalma Yoluyla
    /// </summary>
    public  partial class ChattelDocumentWithPurchase : BaseChattelDocument, IAutoDocumentNumber, IStockInTransaction, IAutoDocumentRecordLog, IChattelDocumentWithPurchase, ICheckStockActionInDetail
    {
        public class ChattelDocumentWithPurchaseList : TTObjectCollection<ChattelDocumentWithPurchase> { }
                    
        public class ChildChattelDocumentWithPurchaseCollection : TTObject.TTChildObjectCollection<ChattelDocumentWithPurchase>
        {
            public ChildChattelDocumentWithPurchaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChattelDocumentWithPurchaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetChattelDocumentWithPurchaseByInvoiceNumber_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Waybill
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WAYBILL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTWITHPURCHASE"].AllPropertyDefs["WAYBILL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetChattelDocumentWithPurchaseByInvoiceNumber_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChattelDocumentWithPurchaseByInvoiceNumber_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChattelDocumentWithPurchaseByInvoiceNumber_Class() : base() { }
        }

        [Serializable] 

        public partial class ControlOfDublicatePurschase_Class : TTReportNqlObject 
        {
            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTWITHPURCHASE"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public ControlOfDublicatePurschase_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ControlOfDublicatePurschase_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ControlOfDublicatePurschase_Class() : base() { }
        }

        [Serializable] 

        public partial class DrugPaymentFirmReportQuery_Class : TTReportNqlObject 
        {
            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTWITHPURCHASE"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTWITHPURCHASE"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Suppliername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DrugPaymentFirmReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DrugPaymentFirmReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DrugPaymentFirmReportQuery_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Approved { get { return new Guid("fe957627-b05f-49e5-a5b4-40d58593410b"); } }
            public static Guid Cancelled { get { return new Guid("3774fa98-ea78-4e0c-aef3-32ffe8c5d3e4"); } }
            public static Guid Completed { get { return new Guid("221cd0fe-3286-4f99-8049-9b3d95ad1d9f"); } }
            public static Guid New { get { return new Guid("53e407a6-c41b-41c5-ab73-21fe0850802e"); } }
    /// <summary>
    /// Belge Düzeltme
    /// </summary>
            public static Guid FixDocument { get { return new Guid("73ff8886-9c15-4efb-85f4-86ecab674eb5"); } }
        }

        public static BindingList<ChattelDocumentWithPurchase.GetChattelDocumentWithPurchaseByInvoiceNumber_Class> GetChattelDocumentWithPurchaseByInvoiceNumber(IList<string> Waybills, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTWITHPURCHASE"].QueryDefs["GetChattelDocumentWithPurchaseByInvoiceNumber"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WAYBILLS", Waybills);

            return TTReportNqlObject.QueryObjects<ChattelDocumentWithPurchase.GetChattelDocumentWithPurchaseByInvoiceNumber_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChattelDocumentWithPurchase.GetChattelDocumentWithPurchaseByInvoiceNumber_Class> GetChattelDocumentWithPurchaseByInvoiceNumber(TTObjectContext objectContext, IList<string> Waybills, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTWITHPURCHASE"].QueryDefs["GetChattelDocumentWithPurchaseByInvoiceNumber"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WAYBILLS", Waybills);

            return TTReportNqlObject.QueryObjects<ChattelDocumentWithPurchase.GetChattelDocumentWithPurchaseByInvoiceNumber_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ChattelDocumentWithPurchase.ControlOfDublicatePurschase_Class> ControlOfDublicatePurschase(string SUPPLIER, string WAYBILL, string STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTWITHPURCHASE"].QueryDefs["ControlOfDublicatePurschase"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUPPLIER", SUPPLIER);
            paramList.Add("WAYBILL", WAYBILL);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<ChattelDocumentWithPurchase.ControlOfDublicatePurschase_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChattelDocumentWithPurchase.ControlOfDublicatePurschase_Class> ControlOfDublicatePurschase(TTObjectContext objectContext, string SUPPLIER, string WAYBILL, string STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTWITHPURCHASE"].QueryDefs["ControlOfDublicatePurschase"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUPPLIER", SUPPLIER);
            paramList.Add("WAYBILL", WAYBILL);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<ChattelDocumentWithPurchase.ControlOfDublicatePurschase_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ChattelDocumentWithPurchase.DrugPaymentFirmReportQuery_Class> DrugPaymentFirmReportQuery(DateTime ENDDATE, DateTime STARTDATE, int SUPPLIERFLAG, int MATERIALFLAG, string SUPPLIER, IList<string> MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTWITHPURCHASE"].QueryDefs["DrugPaymentFirmReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("SUPPLIERFLAG", SUPPLIERFLAG);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);
            paramList.Add("SUPPLIER", SUPPLIER);
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<ChattelDocumentWithPurchase.DrugPaymentFirmReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChattelDocumentWithPurchase.DrugPaymentFirmReportQuery_Class> DrugPaymentFirmReportQuery(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, int SUPPLIERFLAG, int MATERIALFLAG, string SUPPLIER, IList<string> MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTWITHPURCHASE"].QueryDefs["DrugPaymentFirmReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("SUPPLIERFLAG", SUPPLIERFLAG);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);
            paramList.Add("SUPPLIER", SUPPLIER);
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<ChattelDocumentWithPurchase.DrugPaymentFirmReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// XXXXXX Genel Toplam
    /// </summary>
        public Currency? XXXXXXGeneralTotal
        {
            get { return (Currency?)this["XXXXXXGENERALTOTAL"]; }
            set { this["XXXXXXGENERALTOTAL"] = value; }
        }

    /// <summary>
    /// XXXXXX KDV Tutarı
    /// </summary>
        public Currency? XXXXXXVatTotal
        {
            get { return (Currency?)this["XXXXXXVATTOTAL"]; }
            set { this["XXXXXXVATTOTAL"] = value; }
        }

    /// <summary>
    /// XXXXXX İndirim Tutarı
    /// </summary>
        public Currency? XXXXXXSaleTotal
        {
            get { return (Currency?)this["XXXXXXSALETOTAL"]; }
            set { this["XXXXXXSALETOTAL"] = value; }
        }

    /// <summary>
    /// XXXXXX Fatura Tutarı
    /// </summary>
        public Currency? XXXXXXInvoice
        {
            get { return (Currency?)this["XXXXXXINVOICE"]; }
            set { this["XXXXXXINVOICE"] = value; }
        }

    /// <summary>
    /// Dayanak Belge Tarihi
    /// </summary>
        public DateTime? WaybillDate
        {
            get { return (DateTime?)this["WAYBILLDATE"]; }
            set { this["WAYBILLDATE"] = value; }
        }

    /// <summary>
    /// Talep Numarası
    /// </summary>
        public string XXXXXXTalepNo
        {
            get { return (string)this["XXXXXXTALEPNO"]; }
            set { this["XXXXXXTALEPNO"] = value; }
        }

    /// <summary>
    /// İhale Tarihi
    /// </summary>
        public DateTime? AuctionDate
        {
            get { return (DateTime?)this["AUCTIONDATE"]; }
            set { this["AUCTIONDATE"] = value; }
        }

    /// <summary>
    /// İhale No
    /// </summary>
        public string RegistrationAuctionNo
        {
            get { return (string)this["REGISTRATIONAUCTIONNO"]; }
            set { this["REGISTRATIONAUCTIONNO"] = value; }
        }

        public DateTime? ConclusionDateTime
        {
            get { return (DateTime?)this["CONCLUSIONDATETIME"]; }
            set { this["CONCLUSIONDATETIME"] = value; }
        }

        public string ConclusionNumber
        {
            get { return (string)this["CONCLUSIONNUMBER"]; }
            set { this["CONCLUSIONNUMBER"] = value; }
        }

        public DateTime? ContractDateTime
        {
            get { return (DateTime?)this["CONTRACTDATETIME"]; }
            set { this["CONTRACTDATETIME"] = value; }
        }

        public string ContractNumber
        {
            get { return (string)this["CONTRACTNUMBER"]; }
            set { this["CONTRACTNUMBER"] = value; }
        }

    /// <summary>
    /// Serbest Giriş
    /// </summary>
        public bool? FreeEntry
        {
            get { return (bool?)this["FREEENTRY"]; }
            set { this["FREEENTRY"] = value; }
        }

    /// <summary>
    /// Muayene Komisyonu Rapor Tarihi
    /// </summary>
        public DateTime? ExaminationReportDate
        {
            get { return (DateTime?)this["EXAMINATIONREPORTDATE"]; }
            set { this["EXAMINATIONREPORTDATE"] = value; }
        }

    /// <summary>
    /// Muayene Komisyonu Rapor Sayısı
    /// </summary>
        public string ExaminationReportNo
        {
            get { return (string)this["EXAMINATIONREPORTNO"]; }
            set { this["EXAMINATIONREPORTNO"] = value; }
        }

    /// <summary>
    /// XXXXXXEtkilenenAdet
    /// </summary>
        public int? XXXXXXEtkilenenAdet
        {
            get { return (int?)this["XXXXXXETKILENENADET"]; }
            set { this["XXXXXXETKILENENADET"] = value; }
        }

    /// <summary>
    /// XXXXXXIslemBasarili
    /// </summary>
        public bool? XXXXXXIslemBasarili
        {
            get { return (bool?)this["XXXXXXISLEMBASARILI"]; }
            set { this["XXXXXXISLEMBASARILI"] = value; }
        }

    /// <summary>
    /// XXXXXXKayitId
    /// </summary>
        public int? XXXXXXKayitId
        {
            get { return (int?)this["XXXXXXKAYITID"]; }
            set { this["XXXXXXKAYITID"] = value; }
        }

    /// <summary>
    /// XXXXXXMesaj
    /// </summary>
        public string XXXXXXMesaj
        {
            get { return (string)this["XXXXXXMESAJ"]; }
            set { this["XXXXXXMESAJ"] = value; }
        }

    /// <summary>
    /// Dayanak Belge No
    /// </summary>
        public string Waybill
        {
            get { return (string)this["WAYBILL"]; }
            set { this["WAYBILL"] = value; }
        }

    /// <summary>
    /// Hasta Tckno
    /// </summary>
        public string PatientUniqueNo
        {
            get { return (string)this["PATIENTUNIQUENO"]; }
            set { this["PATIENTUNIQUENO"] = value; }
        }

    /// <summary>
    /// Hasta Adı Soyadı
    /// </summary>
        public string PatientFullName
        {
            get { return (string)this["PATIENTFULLNAME"]; }
            set { this["PATIENTFULLNAME"] = value; }
        }

    /// <summary>
    /// Sat Muayene Kabul Id
    /// </summary>
        public int? XXXXXXSatMKabulId
        {
            get { return (int?)this["XXXXXXSATMKABULID"]; }
            set { this["XXXXXXSATMKABULID"] = value; }
        }

    /// <summary>
    /// 1 ise Doğrudan temin, 11 ise ihale olduğunu temsil eder.
    /// </summary>
        public int? FastSoftUygulamaId
        {
            get { return (int?)this["FASTSOFTUYGULAMAID"]; }
            set { this["FASTSOFTUYGULAMAID"] = value; }
        }

    /// <summary>
    /// Fastsofttaki FaturaId alanını temsil eder. UygulamaId alanı ile birlikte Unique dir.
    /// </summary>
        public int? FastSoftFaturaId
        {
            get { return (int?)this["FASTSOFTFATURAID"]; }
            set { this["FASTSOFTFATURAID"] = value; }
        }

        public bool? IsFastSoft
        {
            get { return (bool?)this["ISFASTSOFT"]; }
            set { this["ISFASTSOFT"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProjectCodeDefinition ProjectCodeDefinition
        {
            get { return (ProjectCodeDefinition)((ITTObject)this).GetParent("PROJECTCODEDEFINITION"); }
            set { this["PROJECTCODEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientPhysicianApplication InPatientPhysicianApplication
        {
            get { return (InPatientPhysicianApplication)((ITTObject)this).GetParent("INPATIENTPHYSICIANAPPLICATION"); }
            set { this["INPATIENTPHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTmpOrderedSuppliersCollection()
        {
            _TmpOrderedSuppliers = new TmpOrderedSupplier.ChildTmpOrderedSupplierCollection(this, new Guid("2b69335a-eee7-4f39-8227-00be9ce4035c"));
            ((ITTChildObjectCollection)_TmpOrderedSuppliers).GetChildren();
        }

        protected TmpOrderedSupplier.ChildTmpOrderedSupplierCollection _TmpOrderedSuppliers = null;
        public TmpOrderedSupplier.ChildTmpOrderedSupplierCollection TmpOrderedSuppliers
        {
            get
            {
                if (_TmpOrderedSuppliers == null)
                    CreateTmpOrderedSuppliersCollection();
                return _TmpOrderedSuppliers;
            }
        }

        virtual protected void CreateTmpOrderedDetailsCollection()
        {
            _TmpOrderedDetails = new TmpOrderedDetail.ChildTmpOrderedDetailCollection(this, new Guid("1e150842-3917-48d2-bda8-0a73545cc6fd"));
            ((ITTChildObjectCollection)_TmpOrderedDetails).GetChildren();
        }

        protected TmpOrderedDetail.ChildTmpOrderedDetailCollection _TmpOrderedDetails = null;
        public TmpOrderedDetail.ChildTmpOrderedDetailCollection TmpOrderedDetails
        {
            get
            {
                if (_TmpOrderedDetails == null)
                    CreateTmpOrderedDetailsCollection();
                return _TmpOrderedDetails;
            }
        }

        virtual protected void CreateChattelDocumentDistributionsCollection()
        {
            _ChattelDocumentDistributions = new ChattelDocumentDistribution.ChildChattelDocumentDistributionCollection(this, new Guid("0a2b9fda-d97c-4786-b478-e93fae93000b"));
            ((ITTChildObjectCollection)_ChattelDocumentDistributions).GetChildren();
        }

        protected ChattelDocumentDistribution.ChildChattelDocumentDistributionCollection _ChattelDocumentDistributions = null;
        public ChattelDocumentDistribution.ChildChattelDocumentDistributionCollection ChattelDocumentDistributions
        {
            get
            {
                if (_ChattelDocumentDistributions == null)
                    CreateChattelDocumentDistributionsCollection();
                return _ChattelDocumentDistributions;
            }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ChattelDocumentDetailsWithPurchase = new ChattelDocumentDetailWithPurchase.ChildChattelDocumentDetailWithPurchaseCollection(_StockActionDetails, "ChattelDocumentDetailsWithPurchase");
        }

        private ChattelDocumentDetailWithPurchase.ChildChattelDocumentDetailWithPurchaseCollection _ChattelDocumentDetailsWithPurchase = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ChattelDocumentDetailWithPurchase.ChildChattelDocumentDetailWithPurchaseCollection ChattelDocumentDetailsWithPurchase
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ChattelDocumentDetailsWithPurchase;
            }            
        }

        protected ChattelDocumentWithPurchase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChattelDocumentWithPurchase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChattelDocumentWithPurchase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChattelDocumentWithPurchase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChattelDocumentWithPurchase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHATTELDOCUMENTWITHPURCHASE", dataRow) { }
        protected ChattelDocumentWithPurchase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHATTELDOCUMENTWITHPURCHASE", dataRow, isImported) { }
        public ChattelDocumentWithPurchase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChattelDocumentWithPurchase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChattelDocumentWithPurchase() : base() { }

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