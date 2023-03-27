
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockActionDetail")] 

    /// <summary>
    /// Stok Hareket Detaylarının temel detaylarını barındırır.
    /// </summary>
    public  abstract  partial class StockActionDetail : TTObject, IStockActionDetail
    {
        public class StockActionDetailList : TTObjectCollection<StockActionDetail> { }
                    
        public class ChildStockActionDetailCollection : TTObject.TTChildObjectCollection<StockActionDetail>
        {
            public ChildStockActionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockActionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetActionDetailsForCensus_InventoryAccountReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTION"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Stockaction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTION"]);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public StockLevelTypeEnum? StockLevelTypeStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKLEVELTYPESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKLEVELTYPE"].AllPropertyDefs["STOCKLEVELTYPESTATUS"].DataType;
                    return (StockLevelTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

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

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? AccountingTerm
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACCOUNTINGTERM"]);
                }
            }

            public GetActionDetailsForCensus_InventoryAccountReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActionDetailsForCensus_InventoryAccountReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActionDetailsForCensus_InventoryAccountReport_Class() : base() { }
        }

        public static BindingList<StockActionDetail> GetStockActionDetailFromStockCard(TTObjectContext objectContext, Guid STOCKCARDID, Guid STOREID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAIL"].QueryDefs["GetStockActionDetailFromStockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);

            return ((ITTQuery)objectContext).QueryObjects<StockActionDetail>(queryDef, paramList);
        }

        public static BindingList<StockActionDetail> GetStockActionDetailFromStockCardByTerm(TTObjectContext objectContext, Guid STOCKCARDID, Guid STOREID, Guid ACCOUNTINGTERMID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAIL"].QueryDefs["GetStockActionDetailFromStockCardByTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARDID", STOCKCARDID);
            paramList.Add("STOREID", STOREID);
            paramList.Add("ACCOUNTINGTERMID", ACCOUNTINGTERMID);

            return ((ITTQuery)objectContext).QueryObjects<StockActionDetail>(queryDef, paramList);
        }

        public static BindingList<StockActionDetail.GetActionDetailsForCensus_InventoryAccountReport_Class> GetActionDetailsForCensus_InventoryAccountReport(Guid MATERIAL, Guid STOREID, Guid ACCOUNTINGTERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAIL"].QueryDefs["GetActionDetailsForCensus_InventoryAccountReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STOREID", STOREID);
            paramList.Add("ACCOUNTINGTERM", ACCOUNTINGTERM);

            return TTReportNqlObject.QueryObjects<StockActionDetail.GetActionDetailsForCensus_InventoryAccountReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StockActionDetail.GetActionDetailsForCensus_InventoryAccountReport_Class> GetActionDetailsForCensus_InventoryAccountReport(TTObjectContext objectContext, Guid MATERIAL, Guid STOREID, Guid ACCOUNTINGTERM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKACTIONDETAIL"].QueryDefs["GetActionDetailsForCensus_InventoryAccountReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STOREID", STOREID);
            paramList.Add("ACCOUNTINGTERM", ACCOUNTINGTERM);

            return TTReportNqlObject.QueryObjects<StockActionDetail.GetActionDetailsForCensus_InventoryAccountReport_Class>(objectContext, queryDef, paramList, pi);
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
    /// Durum
    /// </summary>
        public StockActionDetailStatusEnum? Status
        {
            get { return (StockActionDetailStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? ChattelDocDetailOrderNo
        {
            get { return (int?)this["CHATTELDOCDETAILORDERNO"]; }
            set { this["CHATTELDOCDETAILORDERNO"] = value; }
        }

    /// <summary>
    /// İhale Kesinleşme Tarihi
    /// </summary>
        public DateTime? AuctionDate
        {
            get { return (DateTime?)this["AUCTIONDATE"]; }
            set { this["AUCTIONDATE"] = value; }
        }

    /// <summary>
    /// İhale Kayıt No /Alım No
    /// </summary>
        public string RegistrationAuctionNo
        {
            get { return (string)this["REGISTRATIONAUCTIONNO"]; }
            set { this["REGISTRATIONAUCTIONNO"] = value; }
        }

    /// <summary>
    /// Reset OuttableStockTransaction
    /// </summary>
        public bool? ResetOuttableStockTransaction
        {
            get { return (bool?)this["RESETOUTTABLESTOCKTRANSACTION"]; }
            set { this["RESETOUTTABLESTOCKTRANSACTION"] = value; }
        }

    /// <summary>
    /// Fatura Tarihi
    /// </summary>
        public DateTime? InvoiceDate
        {
            get { return (DateTime?)this["INVOICEDATE"]; }
            set { this["INVOICEDATE"] = value; }
        }

        public int? MKYS_StokHareketID
        {
            get { return (int?)this["MKYS_STOKHAREKETID"]; }
            set { this["MKYS_STOKHAREKETID"] = value; }
        }

        public int? MKYS_CikisStokHareketID
        {
            get { return (int?)this["MKYS_CIKISSTOKHAREKETID"]; }
            set { this["MKYS_CIKISSTOKHAREKETID"] = value; }
        }

        public string SerialNo
        {
            get { return (string)this["SERIALNO"]; }
            set { this["SERIALNO"] = value; }
        }

        public StockLevelType StockLevelType
        {
            get { return (StockLevelType)((ITTObject)this).GetParent("STOCKLEVELTYPE"); }
            set { this["STOCKLEVELTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ana İşlem-Alt İşlemler
    /// </summary>
        public StockAction StockAction
        {
            get { return (StockAction)((ITTObject)this).GetParent("STOCKACTION"); }
            set { this["STOCKACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public UTSNotification UTSNotification
        {
            get { return (UTSNotification)((ITTObject)this).GetParent("UTSNOTIFICATION"); }
            set { this["UTSNOTIFICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PTSStockActionDetail PTSStockActionDetail
        {
            get { return (PTSStockActionDetail)((ITTObject)this).GetParent("PTSSTOCKACTIONDETAIL"); }
            set { this["PTSSTOCKACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockCollectedTrxsCollection()
        {
            _StockCollectedTrxs = new StockCollectedTrx.ChildStockCollectedTrxCollection(this, new Guid("6f6f3352-6e80-4078-8613-18953dc1ec13"));
            ((ITTChildObjectCollection)_StockCollectedTrxs).GetChildren();
        }

        protected StockCollectedTrx.ChildStockCollectedTrxCollection _StockCollectedTrxs = null;
        public StockCollectedTrx.ChildStockCollectedTrxCollection StockCollectedTrxs
        {
            get
            {
                if (_StockCollectedTrxs == null)
                    CreateStockCollectedTrxsCollection();
                return _StockCollectedTrxs;
            }
        }

        virtual protected void CreateFixedAssetDetailsCollectionViews()
        {
        }

        virtual protected void CreateFixedAssetDetailsCollection()
        {
            _FixedAssetDetails = new FixedAssetDetail.ChildFixedAssetDetailCollection(this, new Guid("00e7d12d-573e-4d21-ac27-9aa3b14280a9"));
            CreateFixedAssetDetailsCollectionViews();
            ((ITTChildObjectCollection)_FixedAssetDetails).GetChildren();
        }

        protected FixedAssetDetail.ChildFixedAssetDetailCollection _FixedAssetDetails = null;
        public FixedAssetDetail.ChildFixedAssetDetailCollection FixedAssetDetails
        {
            get
            {
                if (_FixedAssetDetails == null)
                    CreateFixedAssetDetailsCollection();
                return _FixedAssetDetails;
            }
        }

        virtual protected void CreateStockTransactionsCollection()
        {
            _StockTransactions = new StockTransaction.ChildStockTransactionCollection(this, new Guid("b360afd5-0011-40c3-9049-ea1c1707d87d"));
            ((ITTChildObjectCollection)_StockTransactions).GetChildren();
        }

        protected StockTransaction.ChildStockTransactionCollection _StockTransactions = null;
        public StockTransaction.ChildStockTransactionCollection StockTransactions
        {
            get
            {
                if (_StockTransactions == null)
                    CreateStockTransactionsCollection();
                return _StockTransactions;
            }
        }

        virtual protected void CreateSubActionMaterialCollection()
        {
            _SubActionMaterial = new SubActionMaterial.ChildSubActionMaterialCollection(this, new Guid("3498c01b-3c5f-43bd-8e67-eca10aabea69"));
            ((ITTChildObjectCollection)_SubActionMaterial).GetChildren();
        }

        protected SubActionMaterial.ChildSubActionMaterialCollection _SubActionMaterial = null;
        public SubActionMaterial.ChildSubActionMaterialCollection SubActionMaterial
        {
            get
            {
                if (_SubActionMaterial == null)
                    CreateSubActionMaterialCollection();
                return _SubActionMaterial;
            }
        }

        virtual protected void CreateQRCodeDetailsCollectionViews()
        {
        }

        virtual protected void CreateQRCodeDetailsCollection()
        {
            _QRCodeDetails = new QRCodeDetail.ChildQRCodeDetailCollection(this, new Guid("98304d91-1844-4798-9d61-17ab06ffb438"));
            CreateQRCodeDetailsCollectionViews();
            ((ITTChildObjectCollection)_QRCodeDetails).GetChildren();
        }

        protected QRCodeDetail.ChildQRCodeDetailCollection _QRCodeDetails = null;
        public QRCodeDetail.ChildQRCodeDetailCollection QRCodeDetails
        {
            get
            {
                if (_QRCodeDetails == null)
                    CreateQRCodeDetailsCollection();
                return _QRCodeDetails;
            }
        }

        virtual protected void CreateInvoiceDetailsCollection()
        {
            _InvoiceDetails = new InvoiceDetail.ChildInvoiceDetailCollection(this, new Guid("3b4054c7-ca84-4ffd-9015-df21d72880e8"));
            ((ITTChildObjectCollection)_InvoiceDetails).GetChildren();
        }

        protected InvoiceDetail.ChildInvoiceDetailCollection _InvoiceDetails = null;
        public InvoiceDetail.ChildInvoiceDetailCollection InvoiceDetails
        {
            get
            {
                if (_InvoiceDetails == null)
                    CreateInvoiceDetailsCollection();
                return _InvoiceDetails;
            }
        }

        virtual protected void CreatePrescriptionPaperDetailsCollectionViews()
        {
        }

        virtual protected void CreatePrescriptionPaperDetailsCollection()
        {
            _PrescriptionPaperDetails = new PrescriptionPaperDetail.ChildPrescriptionPaperDetailCollection(this, new Guid("62478c6b-b4f6-4de1-99dc-3ecf54a8135a"));
            CreatePrescriptionPaperDetailsCollectionViews();
            ((ITTChildObjectCollection)_PrescriptionPaperDetails).GetChildren();
        }

        protected PrescriptionPaperDetail.ChildPrescriptionPaperDetailCollection _PrescriptionPaperDetails = null;
        public PrescriptionPaperDetail.ChildPrescriptionPaperDetailCollection PrescriptionPaperDetails
        {
            get
            {
                if (_PrescriptionPaperDetails == null)
                    CreatePrescriptionPaperDetailsCollection();
                return _PrescriptionPaperDetails;
            }
        }

        virtual protected void CreateDrugOrderCollectedTrxsCollection()
        {
            _DrugOrderCollectedTrxs = new DrugOrderCollectedTrx.ChildDrugOrderCollectedTrxCollection(this, new Guid("65e2c5e2-297d-4905-973f-1eca74c6312b"));
            ((ITTChildObjectCollection)_DrugOrderCollectedTrxs).GetChildren();
        }

        protected DrugOrderCollectedTrx.ChildDrugOrderCollectedTrxCollection _DrugOrderCollectedTrxs = null;
        public DrugOrderCollectedTrx.ChildDrugOrderCollectedTrxCollection DrugOrderCollectedTrxs
        {
            get
            {
                if (_DrugOrderCollectedTrxs == null)
                    CreateDrugOrderCollectedTrxsCollection();
                return _DrugOrderCollectedTrxs;
            }
        }

        protected StockActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockActionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKACTIONDETAIL", dataRow) { }
        protected StockActionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKACTIONDETAIL", dataRow, isImported) { }
        public StockActionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockActionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockActionDetail() : base() { }

    }
}