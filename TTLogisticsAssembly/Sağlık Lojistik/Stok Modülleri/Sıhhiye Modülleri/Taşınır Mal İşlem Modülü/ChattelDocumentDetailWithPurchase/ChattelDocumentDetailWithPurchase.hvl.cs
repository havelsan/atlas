
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChattelDocumentDetailWithPurchase")] 

    public  partial class ChattelDocumentDetailWithPurchase : StockActionDetailIn, IChattelDocumentDetailWithPurchase
    {
        public class ChattelDocumentDetailWithPurchaseList : TTObjectCollection<ChattelDocumentDetailWithPurchase> { }
                    
        public class ChildChattelDocumentDetailWithPurchaseCollection : TTObject.TTChildObjectCollection<ChattelDocumentDetailWithPurchase>
        {
            public ChildChattelDocumentDetailWithPurchaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChattelDocumentDetailWithPurchaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPurchaseDetail_Class : TTReportNqlObject 
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

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public StockActionDetailStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["STATUS"].DataType;
                    return (StockActionDetailStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? ChattelDocDetailOrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHATTELDOCDETAILORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["CHATTELDOCDETAILORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AuctionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUCTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["AUCTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RegistrationAuctionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONAUCTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["REGISTRATIONAUCTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? ResetOuttableStockTransaction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESETOUTTABLESTOCKTRANSACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["RESETOUTTABLESTOCKTRANSACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? InvoiceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["INVOICEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_StokHareketID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_STOKHAREKETID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["MKYS_STOKHAREKETID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SerialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["SERIALNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? NotDiscountedUnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTDISCOUNTEDUNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["NOTDISCOUNTEDUNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? TotalPriceNotDiscount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICENOTDISCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["TOTALPRICENOTDISCOUNT"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? TotalDiscountAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["TOTALDISCOUNTAMOUNT"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public string LotNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["LOTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? VatRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VATRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["VATRATE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? DiscountRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["DISCOUNTRATE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? DiscountAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["DISCOUNTAMOUNT"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_DigerAciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_DIGERACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["MKYS_DIGERACIKLAMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProductionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["PRODUCTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? RetrievalYear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETRIEVALYEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["RETRIEVALYEAR"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? VoucherDetailRecordNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOUCHERDETAILRECORDNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["VOUCHERDETAILRECORDNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string DeliveryNotifictionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYNOTIFICTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["DELIVERYNOTIFICTIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IncomingDeliveryNotifID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCOMINGDELIVERYNOTIFID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["INCOMINGDELIVERYNOTIFID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReceiveNotificationID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVENOTIFICATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["RECEIVENOTIFICATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPriceWithOutVat
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICEWITHOUTVAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["UNITPRICEWITHOUTVAT"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Currency? UnitPriceWithInVat
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICEWITHINVAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].AllPropertyDefs["UNITPRICEWITHINVAT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetPurchaseDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPurchaseDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPurchaseDetail_Class() : base() { }
        }

        public static BindingList<ChattelDocumentDetailWithPurchase.GetPurchaseDetail_Class> GetPurchaseDetail(Guid StockActionID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].QueryDefs["GetPurchaseDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", StockActionID);

            return TTReportNqlObject.QueryObjects<ChattelDocumentDetailWithPurchase.GetPurchaseDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChattelDocumentDetailWithPurchase.GetPurchaseDetail_Class> GetPurchaseDetail(TTObjectContext objectContext, Guid StockActionID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTDETAILWITHPURCHASE"].QueryDefs["GetPurchaseDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", StockActionID);

            return TTReportNqlObject.QueryObjects<ChattelDocumentDetailWithPurchase.GetPurchaseDetail_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// KDV'siz Birim Fiyatı
    /// </summary>
        public BigCurrency? UnitPriceWithOutVat
        {
            get { return (BigCurrency?)this["UNITPRICEWITHOUTVAT"]; }
            set { this["UNITPRICEWITHOUTVAT"] = value; }
        }

    /// <summary>
    /// KDV'siz Birim Fiyatı
    /// </summary>
        public Currency? UnitPriceWithInVat
        {
            get { return (Currency?)this["UNITPRICEWITHINVAT"]; }
            set { this["UNITPRICEWITHINVAT"] = value; }
        }

        virtual protected void CreateChattelDocumentDistributionsCollection()
        {
            _ChattelDocumentDistributions = new ChattelDocumentDistribution.ChildChattelDocumentDistributionCollection(this, new Guid("cc93958e-2740-4153-a2ad-9df8bf4ddd00"));
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

        protected ChattelDocumentDetailWithPurchase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChattelDocumentDetailWithPurchase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChattelDocumentDetailWithPurchase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChattelDocumentDetailWithPurchase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChattelDocumentDetailWithPurchase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHATTELDOCUMENTDETAILWITHPURCHASE", dataRow) { }
        protected ChattelDocumentDetailWithPurchase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHATTELDOCUMENTDETAILWITHPURCHASE", dataRow, isImported) { }
        public ChattelDocumentDetailWithPurchase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChattelDocumentDetailWithPurchase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChattelDocumentDetailWithPurchase() : base() { }

    }
}