
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Receipt")] 

    /// <summary>
    /// Hastadan Tahsilat İşlemi
    /// </summary>
    public  partial class Receipt : EpisodeAccountAction
    {
        public class ReceiptList : TTObjectCollection<Receipt> { }
                    
        public class ChildReceiptCollection : TTObject.TTChildObjectCollection<Receipt>
        {
            public ChildReceiptCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ReceiptReportQuery_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPayment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPAYMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["TOTALPAYMENT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ConvertedTotalPayment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONVERTEDTOTALPAYMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["CONVERTEDTOTALPAYMENT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MoneyPaid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MONEYPAID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["MONEYPAID"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? RemainderOfMoney
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REMAINDEROFMONEY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["REMAINDEROFMONEY"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? DailyRateDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DAILYRATEDEFINITION"]);
                }
            }

            public Guid? Dailyratecurrencytype
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DAILYRATECURRENCYTYPE"]);
                }
            }

            public string CashOfficeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["CASHOFFICENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Receiptdocumentobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RECEIPTDOCUMENTOBJECTID"]);
                }
            }

            public PaymentTypeEnum? PaymentType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["PAYMENTTYPE"].DataType;
                    return (PaymentTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string PayeeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYEENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["PAYEENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? SpecialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["SPECIALNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Cashieruniquerefno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Cashiername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrencyType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENCYTYPE"]);
                }
            }

            public long? HospitalProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string HomeAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hometown
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMETOWN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILCEKODLARI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Homecity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMECITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ReceiptReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ReceiptReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ReceiptReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class EmergentPatientRecordFormQuery_Class : TTReportNqlObject 
        {
            public string PatientName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["PATIENTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Homeaddress
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                }
            }

            public Object Homephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                }
            }

            public EmergentPatientRecordFormQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public EmergentPatientRecordFormQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected EmergentPatientRecordFormQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ReceiptCreditCardReportQuery_Class : TTReportNqlObject 
        {
            public string CashOfficeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["CASHOFFICENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PayeeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYEENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["PAYEENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CreditCardSpecialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREDITCARDSPECIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["CREDITCARDSPECIALNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string CreditCardDocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREDITCARDDOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["CREDITCARDDOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Cashiername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Creditcardpayment
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CREDITCARDPAYMENT"]);
                }
            }

            public Object Cardowner
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CARDOWNER"]);
                }
            }

            public ReceiptCreditCardReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ReceiptCreditCardReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ReceiptCreditCardReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ReceiptDetailsQuery_Class : TTReportNqlObject 
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalDiscountPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? VATPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VATPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["VATPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalDiscountedPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTEDPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["TOTALDISCOUNTEDPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public ReceiptDetailsQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ReceiptDetailsQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ReceiptDetailsQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReceiptDebentures_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetReceiptDebentures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReceiptDebentures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReceiptDebentures_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReceipts_Class : TTReportNqlObject 
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

            public Currency? TotalPayment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPAYMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["TOTALPAYMENT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string CashOfficeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["CASHOFFICENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetReceipts_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReceipts_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReceipts_Class() : base() { }
        }

        [Serializable] 

        public partial class OrthesisToothIVFPatientParticipationReport_Class : TTReportNqlObject 
        {
            public long? Tckimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Protokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Bolum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOLUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTPROCEDURE"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTPROCEDURE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Tutar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TUTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTPROCEDURE"].AllPropertyDefs["TOTALDISCOUNTEDPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public OrthesisToothIVFPatientParticipationReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OrthesisToothIVFPatientParticipationReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OrthesisToothIVFPatientParticipationReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetForeignSgkPatientParticipationByDate_Class : TTReportNqlObject 
        {
            public long? Tckimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Protokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Bolum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOLUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTPROCEDURE"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTPROCEDURE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Tutar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TUTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTPROCEDURE"].AllPropertyDefs["TOTALDISCOUNTEDPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetForeignSgkPatientParticipationByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetForeignSgkPatientParticipationByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetForeignSgkPatientParticipationByDate_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("3a9e132b-ceec-4e0a-b7ec-3b4f56deaed9"); } }
            public static Guid Paid { get { return new Guid("f752966f-742d-4847-b1ad-a32fd8149ff4"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("21058283-c147-490e-97ac-c9ad3fc67d66"); } }
        }

        public static BindingList<Receipt.ReceiptReportQuery_Class> ReceiptReportQuery(string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["ReceiptReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<Receipt.ReceiptReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Receipt.ReceiptReportQuery_Class> ReceiptReportQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["ReceiptReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<Receipt.ReceiptReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Receipt.EmergentPatientRecordFormQuery_Class> EmergentPatientRecordFormQuery(string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["EmergentPatientRecordFormQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<Receipt.EmergentPatientRecordFormQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Receipt.EmergentPatientRecordFormQuery_Class> EmergentPatientRecordFormQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["EmergentPatientRecordFormQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<Receipt.EmergentPatientRecordFormQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Receipt.ReceiptCreditCardReportQuery_Class> ReceiptCreditCardReportQuery(string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["ReceiptCreditCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<Receipt.ReceiptCreditCardReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Receipt.ReceiptCreditCardReportQuery_Class> ReceiptCreditCardReportQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["ReceiptCreditCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<Receipt.ReceiptCreditCardReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Receipt> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<Receipt>(queryDef, paramList);
        }

        public static BindingList<Receipt.ReceiptDetailsQuery_Class> ReceiptDetailsQuery(string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["ReceiptDetailsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<Receipt.ReceiptDetailsQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Receipt.ReceiptDetailsQuery_Class> ReceiptDetailsQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["ReceiptDetailsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<Receipt.ReceiptDetailsQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Receipt> GetByEpisode(TTObjectContext objectContext, string PARAMEPISODE, string PARAMSTATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMEPISODE", PARAMEPISODE);
            paramList.Add("PARAMSTATE", PARAMSTATE);

            return ((ITTQuery)objectContext).QueryObjects<Receipt>(queryDef, paramList);
        }

        public static BindingList<Receipt.GetReceiptDebentures_Class> GetReceiptDebentures(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["GetReceiptDebentures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Receipt.GetReceiptDebentures_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Receipt.GetReceiptDebentures_Class> GetReceiptDebentures(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["GetReceiptDebentures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Receipt.GetReceiptDebentures_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Receipt.GetReceipts_Class> GetReceipts(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["GetReceipts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Receipt.GetReceipts_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Receipt.GetReceipts_Class> GetReceipts(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["GetReceipts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Receipt.GetReceipts_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Receipt.OrthesisToothIVFPatientParticipationReport_Class> OrthesisToothIVFPatientParticipationReport(DateTime STARTDATE, DateTime ENDDATE, int RESOURCEFLAG, IList<string> RESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["OrthesisToothIVFPatientParticipationReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("RESOURCE", RESOURCE);

            return TTReportNqlObject.QueryObjects<Receipt.OrthesisToothIVFPatientParticipationReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Receipt.OrthesisToothIVFPatientParticipationReport_Class> OrthesisToothIVFPatientParticipationReport(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int RESOURCEFLAG, IList<string> RESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["OrthesisToothIVFPatientParticipationReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);
            paramList.Add("RESOURCE", RESOURCE);

            return TTReportNqlObject.QueryObjects<Receipt.OrthesisToothIVFPatientParticipationReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Receipt.GetForeignSgkPatientParticipationByDate_Class> GetForeignSgkPatientParticipationByDate(DateTime STARTDATE, DateTime ENDDATE, IList<string> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["GetForeignSgkPatientParticipationByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<Receipt.GetForeignSgkPatientParticipationByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Receipt.GetForeignSgkPatientParticipationByDate_Class> GetForeignSgkPatientParticipationByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["GetForeignSgkPatientParticipationByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<Receipt.GetForeignSgkPatientParticipationByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Receipt> GetByEpisodeStateAndDocumentNo(TTObjectContext objectContext, string EPISODE, string STATE, string DOCUMENTNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["GetByEpisodeStateAndDocumentNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STATE", STATE);
            paramList.Add("DOCUMENTNO", DOCUMENTNO);

            return ((ITTQuery)objectContext).QueryObjects<Receipt>(queryDef, paramList);
        }

        public static BindingList<Receipt> GetByEpisodeStateAndCreditCardDocumentNo(TTObjectContext objectContext, string EPISODE, string STATE, string DOCUMENTNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].QueryDefs["GetByEpisodeStateAndCreditCardDocumentNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STATE", STATE);
            paramList.Add("DOCUMENTNO", DOCUMENTNO);

            return ((ITTQuery)objectContext).QueryObjects<Receipt>(queryDef, paramList);
        }

    /// <summary>
    /// İndirilecek Tutar
    /// </summary>
        public Currency? TotalDiscountEntry
        {
            get { return (Currency?)this["TOTALDISCOUNTENTRY"]; }
            set { this["TOTALDISCOUNTENTRY"] = value; }
        }

    /// <summary>
    /// Toplam Ödeme
    /// </summary>
        public Currency? TotalPayment
        {
            get { return (Currency?)this["TOTALPAYMENT"]; }
            set { this["TOTALPAYMENT"] = value; }
        }

    /// <summary>
    /// Daha önce Alınmış Senet Tutarı
    /// </summary>
        public Currency? DebentureTaken
        {
            get { return (Currency?)this["DEBENTURETAKEN"]; }
            set { this["DEBENTURETAKEN"] = value; }
        }

    /// <summary>
    /// Daha önce Alınmış Avans Tutarı
    /// </summary>
        public Currency? AdvanceTaken
        {
            get { return (Currency?)this["ADVANCETAKEN"]; }
            set { this["ADVANCETAKEN"] = value; }
        }

    /// <summary>
    /// Detaylı Makbuz kesebilmek için
    /// </summary>
        public bool? UnDetailedReport
        {
            get { return (bool?)this["UNDETAILEDREPORT"]; }
            set { this["UNDETAILEDREPORT"] = value; }
        }

        public Currency? ConvertedTotalPayment
        {
            get { return (Currency?)this["CONVERTEDTOTALPAYMENT"]; }
            set { this["CONVERTEDTOTALPAYMENT"] = value; }
        }

    /// <summary>
    /// Hastadan Alınan Ücret
    /// </summary>
        public Currency? MoneyPaid
        {
            get { return (Currency?)this["MONEYPAID"]; }
            set { this["MONEYPAID"] = value; }
        }

    /// <summary>
    /// Para Üstü
    /// </summary>
        public Currency? RemainderOfMoney
        {
            get { return (Currency?)this["REMAINDEROFMONEY"]; }
            set { this["REMAINDEROFMONEY"] = value; }
        }

    /// <summary>
    /// İndirim Tipleriyle ilişki
    /// </summary>
        public DiscountTypeDefinition DiscountTypeDefinition
        {
            get { return (DiscountTypeDefinition)((ITTObject)this).GetParent("DISCOUNTTYPEDEFINITION"); }
            set { this["DISCOUNTTYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısıyla ilişkisi
    /// </summary>
        public ReceiptDocument ReceiptDocument
        {
            get { return (ReceiptDocument)((ITTObject)this).GetParent("RECEIPTDOCUMENT"); }
            set { this["RECEIPTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DailyRateDefinition DailyRateDefinition
        {
            get { return (DailyRateDefinition)((ITTObject)this).GetParent("DAILYRATEDEFINITION"); }
            set { this["DAILYRATEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("8450880c-8ca2-4787-8b3c-6f6e97ba9fdb"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        virtual protected void CreateReceiptProceduresCollection()
        {
            _ReceiptProcedures = new ReceiptProcedure.ChildReceiptProcedureCollection(this, new Guid("64f67d99-4d2d-4bb6-b5ad-9b3ed5f4bd32"));
            ((ITTChildObjectCollection)_ReceiptProcedures).GetChildren();
        }

        protected ReceiptProcedure.ChildReceiptProcedureCollection _ReceiptProcedures = null;
    /// <summary>
    /// Child collection for Muhasebe Yetkilisi Mutemedi Alındısı ilişkisi
    /// </summary>
        public ReceiptProcedure.ChildReceiptProcedureCollection ReceiptProcedures
        {
            get
            {
                if (_ReceiptProcedures == null)
                    CreateReceiptProceduresCollection();
                return _ReceiptProcedures;
            }
        }

        virtual protected void CreateReceiptMaterialsCollection()
        {
            _ReceiptMaterials = new ReceiptMaterial.ChildReceiptMaterialCollection(this, new Guid("5ec4938d-a6dc-4ea9-a032-e1952ec2a258"));
            ((ITTChildObjectCollection)_ReceiptMaterials).GetChildren();
        }

        protected ReceiptMaterial.ChildReceiptMaterialCollection _ReceiptMaterials = null;
    /// <summary>
    /// Child collection for Muhasebe Yetkilisi Mutemedi Alındısı ilişkisi
    /// </summary>
        public ReceiptMaterial.ChildReceiptMaterialCollection ReceiptMaterials
        {
            get
            {
                if (_ReceiptMaterials == null)
                    CreateReceiptMaterialsCollection();
                return _ReceiptMaterials;
            }
        }

        virtual protected void CreateReceiptBackCollection()
        {
            _ReceiptBack = new ReceiptBack.ChildReceiptBackCollection(this, new Guid("a29e5d62-9f00-41c9-93f9-bacb3d773cf5"));
            ((ITTChildObjectCollection)_ReceiptBack).GetChildren();
        }

        protected ReceiptBack.ChildReceiptBackCollection _ReceiptBack = null;
        public ReceiptBack.ChildReceiptBackCollection ReceiptBack
        {
            get
            {
                if (_ReceiptBack == null)
                    CreateReceiptBackCollection();
                return _ReceiptBack;
            }
        }

        protected Receipt(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Receipt(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Receipt(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Receipt(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Receipt(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPT", dataRow) { }
        protected Receipt(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPT", dataRow, isImported) { }
        public Receipt(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Receipt(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Receipt() : base() { }

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