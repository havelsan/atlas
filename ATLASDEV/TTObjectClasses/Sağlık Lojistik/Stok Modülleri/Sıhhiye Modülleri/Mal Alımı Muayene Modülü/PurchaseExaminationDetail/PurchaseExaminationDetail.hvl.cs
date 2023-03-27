
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseExaminationDetail")] 

    /// <summary>
    /// Geçici Kabulde malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class PurchaseExaminationDetail : StockActionDetailIn
    {
        public class PurchaseExaminationDetailList : TTObjectCollection<PurchaseExaminationDetail> { }
                    
        public class ChildPurchaseExaminationDetailCollection : TTObject.TTChildObjectCollection<PurchaseExaminationDetail>
        {
            public ChildPurchaseExaminationDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseExaminationDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ExaminationDetailReportNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["STATUS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["CHATTELDOCDETAILORDERNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["AUCTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["REGISTRATIONAUCTIONNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["RESETOUTTABLESTOCKTRANSACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["INVOICEDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["MKYS_STOKHAREKETID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["SERIALNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["NOTDISCOUNTEDUNITPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["TOTALPRICENOTDISCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["TOTALDISCOUNTAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["LOTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["VATRATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["DISCOUNTRATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["DISCOUNTAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["MKYS_DIGERACIKLAMA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["PRODUCTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["RETRIEVALYEAR"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["VOUCHERDETAILRECORDNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["DELIVERYNOTIFICTIONID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["INCOMINGDELIVERYNOTIFID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["RECEIVENOTIFICATIONID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PurchaseExaminationDetailStatusEnum? PurchaseExaminationDetStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEEXAMINATIONDETSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["PURCHASEEXAMINATIONDETSTATUS"].DataType;
                    return (PurchaseExaminationDetailStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ProductNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["PRODUCTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Objectdefid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID1"]);
                }
            }

            public Guid? Currentstatedefid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID1"]);
                }
            }

            public DateTime? Lastupdate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE1"]);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? RegistrationNumberSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBERSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["REGISTRATIONNUMBERSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string SequenceNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["SEQUENCENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? SequenceNumberSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENUMBERSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["SEQUENCENUMBERSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? AdditionalDocumentCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALDOCUMENTCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ADDITIONALDOCUMENTCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsEntryOldMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISENTRYOLDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ISENTRYOLDMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Currency? GrandTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRANDTOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["GRANDTOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public object InvoicePicture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEPICTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["INVOICEPICTURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_Yil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_YIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_YIL"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_GelenVeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GELENVERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_GELENVERI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_AyniyatMakbuzID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_AYNIYATMAKBUZID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_AYNIYATMAKBUZID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MKYS_EAlimYontemiEnum? MKYS_EAlimYontemi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_EALIMYONTEMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_EALIMYONTEMI"].DataType;
                    return (MKYS_EAlimYontemiEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MKYS_EButceTurEnum? MKYS_EButceTur
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_EBUTCETUR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_EBUTCETUR"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MKYS_ETedarikTurEnum? MKYS_ETedarikTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_ETEDARIKTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_ETEDARIKTURU"].DataType;
                    return (MKYS_ETedarikTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MKYS_TeslimEden
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_TESLIMEDEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_TESLIMEDEN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MKYS_EMalzemeGrupEnum? MKYS_EMalzemeGrup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_EMALZEMEGRUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_EMALZEMEGRUP"].DataType;
                    return (MKYS_EMalzemeGrupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MKYS_TeslimAlan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_TESLIMALAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_TESLIMALAN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MKYS_MakbuzTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MAKBUZTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_MAKBUZTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_DepoKayitNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_DEPOKAYITNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_DEPOKAYITNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MKYS_ECikisIslemTuruEnum? MKYS_CikisIslemTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISISLEMTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_CIKISISLEMTURU"].DataType;
                    return (MKYS_ECikisIslemTuruEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MKYS_ECikisStokHareketTurEnum? MKYS_CikisStokHareketTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISSTOKHAREKETTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_CIKISSTOKHAREKETTURU"].DataType;
                    return (MKYS_ECikisStokHareketTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_CikisYapilanDepoKayitNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISYAPILANDEPOKAYITNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_CIKISYAPILANDEPOKAYITNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_CikisYapilanKisiTCNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISYAPILANKISITCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_CIKISYAPILANKISITCNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MKYS_GonderimTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GONDERIMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_GONDERIMTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_GidenVeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GIDENVERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_GIDENVERI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MKYS_GeldigiYer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GELDIGIYER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_GELDIGIYER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_KarsiBirimKayitNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_KARSIBIRIMKAYITNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_KARSIBIRIMKAYITNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_MakbuzNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MAKBUZNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_MAKBUZNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_MuayeneNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MUAYENENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_MUAYENENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MKYS_MuayeneTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MUAYENETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_MUAYENETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? MKYSControl
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSCONTROL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYSCONTROL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? MKYS_TeslimAlanObjID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MKYS_TESLIMALANOBJID"]);
                }
            }

            public Guid? MKYS_TeslimEdenObjID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MKYS_TESLIMEDENOBJID"]);
                }
            }

            public bool? IsEmergencyMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCYMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ISEMERGENCYMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPTSAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPTSACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ISPTSACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PTSNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PTSNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["PTSNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GeneralInspectionFinalReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALINSPECTIONFINALREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["GENERALINSPECTIONFINALREPORT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExaminationFinishDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONFINISHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["EXAMINATIONFINISHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string FunctionInspectionFinalReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FUNCTIONINSPECTIONFINALREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["FUNCTIONINSPECTIONFINALREPORT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FileNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FILENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["FILENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PhysicalInspectionNoticeText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALINSPECTIONNOTICETEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["PHYSICALINSPECTIONNOTICETEXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TemporaryDeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPORARYDELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["TEMPORARYDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? ManuelEntry
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANUELENTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MANUELENTRY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public PurchaseExaminationStatusEnum? InspectionStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INSPECTIONSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["INSPECTIONSTATUS"].DataType;
                    return (PurchaseExaminationStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string FunctionTestReportHeaderTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FUNCTIONTESTREPORTHEADERTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["FUNCTIONTESTREPORTHEADERTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PhysicalInspectionFinalReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALINSPECTIONFINALREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["PHYSICALINSPECTIONFINALREPORT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? InspectionMemoCollacationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INSPECTIONMEMOCOLLACATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["INSPECTIONMEMOCOLLACATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public TemporaryReceivingProcessStatusEnum? TempReceivingProcessStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPRECEIVINGPROCESSSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["TEMPRECEIVINGPROCESSSTATUS"].DataType;
                    return (TemporaryReceivingProcessStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string FunctionInspectionRequestTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FUNCTIONINSPECTIONREQUESTTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["FUNCTIONINSPECTIONREQUESTTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExaminationStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["EXAMINATIONSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string InspectionPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INSPECTIONPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["INSPECTIONPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ContractDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["CONTRACTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ContractNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["CONTRACTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ExaminationDetailReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ExaminationDetailReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ExaminationDetailReportNQL_Class() : base() { }
        }

        public static BindingList<PurchaseExaminationDetail.ExaminationDetailReportNQL_Class> ExaminationDetailReportNQL(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].QueryDefs["ExaminationDetailReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseExaminationDetail.ExaminationDetailReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseExaminationDetail.ExaminationDetailReportNQL_Class> ExaminationDetailReportNQL(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].QueryDefs["ExaminationDetailReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseExaminationDetail.ExaminationDetailReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseExaminationDetail> GetExaminationDetailsByOrderDetail(TTObjectContext objectContext, string PURCHASEORDERDETAILID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].QueryDefs["GetExaminationDetailsByOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PURCHASEORDERDETAILID", PURCHASEORDERDETAILID);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseExaminationDetail>(queryDef, paramList);
        }

    /// <summary>
    /// Mal Alım Muayene Detay Durumu
    /// </summary>
        public PurchaseExaminationDetailStatusEnum? PurchaseExaminationDetStatus
        {
            get { return (PurchaseExaminationDetailStatusEnum?)(int?)this["PURCHASEEXAMINATIONDETSTATUS"]; }
            set { this["PURCHASEEXAMINATIONDETSTATUS"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNO
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public string ProductNumber
        {
            get { return (string)this["PRODUCTNUMBER"]; }
            set { this["PRODUCTNUMBER"] = value; }
        }

        public PurchaseOrderDetail PurchaseOrderDetail
        {
            get { return (PurchaseOrderDetail)((ITTObject)this).GetParent("PURCHASEORDERDETAIL"); }
            set { this["PURCHASEORDERDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PurchaseExamination PurchaseExamination
        {
            get 
            {   
                if (StockAction is PurchaseExamination)
                    return (PurchaseExamination)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        virtual protected void CreateExaminationDetailsCollection()
        {
            _ExaminationDetails = new ExaminationDetail.ChildExaminationDetailCollection(this, new Guid("480e9a5f-957f-4ad0-a895-cd4052760dd5"));
            ((ITTChildObjectCollection)_ExaminationDetails).GetChildren();
        }

        protected ExaminationDetail.ChildExaminationDetailCollection _ExaminationDetails = null;
        public ExaminationDetail.ChildExaminationDetailCollection ExaminationDetails
        {
            get
            {
                if (_ExaminationDetails == null)
                    CreateExaminationDetailsCollection();
                return _ExaminationDetails;
            }
        }

        protected PurchaseExaminationDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseExaminationDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseExaminationDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseExaminationDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseExaminationDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEEXAMINATIONDETAIL", dataRow) { }
        protected PurchaseExaminationDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEEXAMINATIONDETAIL", dataRow, isImported) { }
        public PurchaseExaminationDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseExaminationDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseExaminationDetail() : base() { }

    }
}