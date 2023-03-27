
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReceiptDocument")] 

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı Dökümanı
    /// </summary>
    public  partial class ReceiptDocument : AccountDocument
    {
        public class ReceiptDocumentList : TTObjectCollection<ReceiptDocument> { }
                    
        public class ChildReceiptDocumentCollection : TTObject.TTChildObjectCollection<ReceiptDocument>
        {
            public ChildReceiptDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetCancelledReceiptDocument_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetCancelledReceiptDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledReceiptDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledReceiptDocument_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReceiptDocument_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OutPatientInPatientBothEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (OutPatientInPatientBothEnum?)(int)dataType.ConvertValue(val);
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

            public bool? SendToAccounting
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDTOACCOUNTING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["SENDTOACCOUNTING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? DocumentID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public DateTime? CreateDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["CREATEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CancelDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["CANCELDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalVATPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALVATPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["TOTALVATPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public long? PatientNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["PATIENTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

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

            public Currency? GeneralTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetReceiptDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReceiptDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReceiptDocument_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetReceiptDocument_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public Object Countryofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNTRYOFBIRTH"]);
                }
            }

            public Object Homecountry
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECOUNTRY"]);
                }
            }

            public OLAP_GetReceiptDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetReceiptDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetReceiptDocument_Class() : base() { }
        }

        [Serializable] 

        public partial class CashOfficeRevenueReportDetailQuery_Class : TTReportNqlObject 
        {
            public Guid? Receiptobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RECEIPTOBJECTID"]);
                }
            }

            public Guid? Acctrxobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ACCTRXOBJECTID"]);
                }
            }

            public Object Type
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TYPE"]);
                }
            }

            public Object Accountcode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACCOUNTCODE"]);
                }
            }

            public Object Materialobjectdefname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MATERIALOBJECTDEFNAME"]);
                }
            }

            public string tedaviTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVITURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TEDAVITURU"].AllPropertyDefs["TEDAVITURUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Isparticipationshare
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISPARTICIPATIONSHARE"]);
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

            public Currency? PaymentPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMENTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTPAYMENTDETAIL"].AllPropertyDefs["PAYMENTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public PayerTypeEnum? PayerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["PAYERTYPE"].DataType;
                    return (PayerTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public Object Isparticipationprocedure
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISPARTICIPATIONPROCEDURE"]);
                }
            }

            public string MedulaTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].AllPropertyDefs["MEDULATAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Ishealthtourism
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISHEALTHTOURISM"]);
                }
            }

            public Object Medulaistisnaihalkodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULAISTISNAIHALKODU"]);
                }
            }

            public CashOfficeRevenueReportDetailQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CashOfficeRevenueReportDetailQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CashOfficeRevenueReportDetailQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ReceiptPaymentStatQuery_Class : TTReportNqlObject 
        {
            public string Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Adsoyad
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADSOYAD"]);
                }
            }

            public string Ulke
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ULKE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPT"].AllPropertyDefs["TOTALPAYMENT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Odemetarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODEMETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Makbuzno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKBUZNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kurumadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURUMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ReceiptPaymentStatQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ReceiptPaymentStatQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ReceiptPaymentStatQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("ea1b07ff-a8e4-4c79-9f70-12cafe54ef65"); } }
            public static Guid Paid { get { return new Guid("786d4ad2-b098-499d-8874-03a8732c44fd"); } }
            public static Guid Cancelled { get { return new Guid("8b39de2f-17b4-47a4-94b4-e1f285db135e"); } }
        }

        public static BindingList<ReceiptDocument.OLAP_GetCancelledReceiptDocument_Class> OLAP_GetCancelledReceiptDocument(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["OLAP_GetCancelledReceiptDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ReceiptDocument.OLAP_GetCancelledReceiptDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocument.OLAP_GetCancelledReceiptDocument_Class> OLAP_GetCancelledReceiptDocument(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["OLAP_GetCancelledReceiptDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ReceiptDocument.OLAP_GetCancelledReceiptDocument_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocument.GetReceiptDocument_Class> GetReceiptDocument(string ROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["GetReceiptDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ROBJECTID", ROBJECTID);

            return TTReportNqlObject.QueryObjects<ReceiptDocument.GetReceiptDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocument.GetReceiptDocument_Class> GetReceiptDocument(TTObjectContext objectContext, string ROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["GetReceiptDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ROBJECTID", ROBJECTID);

            return TTReportNqlObject.QueryObjects<ReceiptDocument.GetReceiptDocument_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocument> GetByDocumentNoAndState(TTObjectContext objectContext, string PARAMDOCNO, string PARAMSTATE, string PARAMEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["GetByDocumentNoAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDOCNO", PARAMDOCNO);
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMEPISODE", PARAMEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<ReceiptDocument>(queryDef, paramList);
        }

        public static BindingList<ReceiptDocument.OLAP_GetReceiptDocument_Class> OLAP_GetReceiptDocument(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["OLAP_GetReceiptDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ReceiptDocument.OLAP_GetReceiptDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocument.OLAP_GetReceiptDocument_Class> OLAP_GetReceiptDocument(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["OLAP_GetReceiptDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ReceiptDocument.OLAP_GetReceiptDocument_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocument> GetByCreditCardDocumentNoAndState(TTObjectContext objectContext, string PARAMDOCNO, string PARAMSTATE, string PARAMEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["GetByCreditCardDocumentNoAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDOCNO", PARAMDOCNO);
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMEPISODE", PARAMEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<ReceiptDocument>(queryDef, paramList);
        }

        public static BindingList<ReceiptDocument.CashOfficeRevenueReportDetailQuery_Class> CashOfficeRevenueReportDetailQuery(DateTime STARTDATE, DateTime ENDDATE, Guid CASHOFFICE, int CASHOFFICECONTROL, Guid CASHIER, int CASHIERCONTROL, PaymentTypeCashCCEnum PAYMENTTYPE, int PAYMENTTYPECONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["CashOfficeRevenueReportDetailQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("CASHOFFICE", CASHOFFICE);
            paramList.Add("CASHOFFICECONTROL", CASHOFFICECONTROL);
            paramList.Add("CASHIER", CASHIER);
            paramList.Add("CASHIERCONTROL", CASHIERCONTROL);
            paramList.Add("PAYMENTTYPE", (int)PAYMENTTYPE);
            paramList.Add("PAYMENTTYPECONTROL", PAYMENTTYPECONTROL);

            return TTReportNqlObject.QueryObjects<ReceiptDocument.CashOfficeRevenueReportDetailQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocument.CashOfficeRevenueReportDetailQuery_Class> CashOfficeRevenueReportDetailQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid CASHOFFICE, int CASHOFFICECONTROL, Guid CASHIER, int CASHIERCONTROL, PaymentTypeCashCCEnum PAYMENTTYPE, int PAYMENTTYPECONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["CashOfficeRevenueReportDetailQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("CASHOFFICE", CASHOFFICE);
            paramList.Add("CASHOFFICECONTROL", CASHOFFICECONTROL);
            paramList.Add("CASHIER", CASHIER);
            paramList.Add("CASHIERCONTROL", CASHIERCONTROL);
            paramList.Add("PAYMENTTYPE", (int)PAYMENTTYPE);
            paramList.Add("PAYMENTTYPECONTROL", PAYMENTTYPECONTROL);

            return TTReportNqlObject.QueryObjects<ReceiptDocument.CashOfficeRevenueReportDetailQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocument.ReceiptPaymentStatQuery_Class> ReceiptPaymentStatQuery(DateTime STARTDATE, DateTime ENDDATE, Guid PAYER, int PAYERCONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["ReceiptPaymentStatQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERCONTROL", PAYERCONTROL);

            return TTReportNqlObject.QueryObjects<ReceiptDocument.ReceiptPaymentStatQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReceiptDocument.ReceiptPaymentStatQuery_Class> ReceiptPaymentStatQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid PAYER, int PAYERCONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTDOCUMENT"].QueryDefs["ReceiptPaymentStatQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERCONTROL", PAYERCONTROL);

            return TTReportNqlObject.QueryObjects<ReceiptDocument.ReceiptPaymentStatQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplam Vergi Tutarı
    /// </summary>
        public Currency? TotalVATPrice
        {
            get { return (Currency?)this["TOTALVATPRICE"]; }
            set { this["TOTALVATPRICE"] = value; }
        }

    /// <summary>
    /// Kredi Kartı Özel Numarası
    /// </summary>
        public TTSequence CreditCardSpecialNo
        {
            get { return GetSequence("CREDITCARDSPECIALNO"); }
        }

    /// <summary>
    /// Hasta Numarası
    /// </summary>
        public long? PatientNo
        {
            get { return (long?)this["PATIENTNO"]; }
            set { this["PATIENTNO"] = value; }
        }

    /// <summary>
    /// Hasta Adı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
        }

    /// <summary>
    /// Kredi Kartı Belge Numarası
    /// </summary>
        public string CreditCardDocumentNo
        {
            get { return (string)this["CREDITCARDDOCUMENTNO"]; }
            set { this["CREDITCARDDOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Özel Numara
    /// </summary>
        public TTSequence SpecialNo
        {
            get { return GetSequence("SPECIALNO"); }
        }

    /// <summary>
    /// Ödeme Yapan Kişi
    /// </summary>
        public string PayeeName
        {
            get { return (string)this["PAYEENAME"]; }
            set { this["PAYEENAME"] = value; }
        }

    /// <summary>
    /// İndirimli Toplam Tutar
    /// </summary>
        public Currency? GeneralTotalPrice
        {
            get { return (Currency?)this["GENERALTOTALPRICE"]; }
            set { this["GENERALTOTALPRICE"] = value; }
        }

    /// <summary>
    /// Toplam İndirim Tutarı
    /// </summary>
        public Currency? TotalDiscountPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTPRICE"]; }
            set { this["TOTALDISCOUNTPRICE"] = value; }
        }

        virtual protected void CreateAdvanceDocumentsCollection()
        {
            _AdvanceDocuments = new AdvanceDocument.ChildAdvanceDocumentCollection(this, new Guid("22d4bba7-7ef6-46e7-9fe9-03b70d56ebd9"));
            ((ITTChildObjectCollection)_AdvanceDocuments).GetChildren();
        }

        protected AdvanceDocument.ChildAdvanceDocumentCollection _AdvanceDocuments = null;
    /// <summary>
    /// Child collection for Muhasebe Yetkilisi Mutemedi Alındısı Dökümanıyla İlişkisi
    /// </summary>
        public AdvanceDocument.ChildAdvanceDocumentCollection AdvanceDocuments
        {
            get
            {
                if (_AdvanceDocuments == null)
                    CreateAdvanceDocumentsCollection();
                return _AdvanceDocuments;
            }
        }

        virtual protected void CreateReceiptCollection()
        {
            _Receipt = new Receipt.ChildReceiptCollection(this, new Guid("7432bde1-1e12-41a4-b654-37269e3dffd8"));
            ((ITTChildObjectCollection)_Receipt).GetChildren();
        }

        protected Receipt.ChildReceiptCollection _Receipt = null;
    /// <summary>
    /// Child collection for Muhasebe Yetkilisi Mutemedi Alındısıyla ilişkisi
    /// </summary>
        public Receipt.ChildReceiptCollection Receipt
        {
            get
            {
                if (_Receipt == null)
                    CreateReceiptCollection();
                return _Receipt;
            }
        }

        virtual protected void CreateAccountingLinesForCashCollection()
        {
            _AccountingLinesForCash = new AccountingLinesForCash.ChildAccountingLinesForCashCollection(this, new Guid("ea7ada22-3be1-48f3-a583-f7f19be53d43"));
            ((ITTChildObjectCollection)_AccountingLinesForCash).GetChildren();
        }

        protected AccountingLinesForCash.ChildAccountingLinesForCashCollection _AccountingLinesForCash = null;
    /// <summary>
    /// Child collection for Muhasebe yetkilisi mutemedi alındısı ile ilişki
    /// </summary>
        public AccountingLinesForCash.ChildAccountingLinesForCashCollection AccountingLinesForCash
        {
            get
            {
                if (_AccountingLinesForCash == null)
                    CreateAccountingLinesForCashCollection();
                return _AccountingLinesForCash;
            }
        }

        protected ReceiptDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReceiptDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReceiptDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReceiptDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReceiptDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPTDOCUMENT", dataRow) { }
        protected ReceiptDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPTDOCUMENT", dataRow, isImported) { }
        public ReceiptDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReceiptDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReceiptDocument() : base() { }

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