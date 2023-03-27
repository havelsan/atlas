
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerInvoiceDocument")] 

    /// <summary>
    /// Kurum Faturası Dökümanı
    /// </summary>
    public  partial class PayerInvoiceDocument : AccountDocument
    {
        public class PayerInvoiceDocumentList : TTObjectCollection<PayerInvoiceDocument> { }
                    
        public class ChildPayerInvoiceDocumentCollection : TTObject.TTChildObjectCollection<PayerInvoiceDocument>
        {
            public ChildPayerInvoiceDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerInvoiceDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetPayerInvoiceDocument_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Payer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYER"]);
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

            public OLAP_GetPayerInvoiceDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetPayerInvoiceDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetPayerInvoiceDocument_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledPayerInvoiceDocument_Class : TTReportNqlObject 
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

            public OLAP_GetCancelledPayerInvoiceDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledPayerInvoiceDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledPayerInvoiceDocument_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPayerInvoiceDocumentByPayer_Class : TTReportNqlObject 
        {
            public Guid? Payer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYER"]);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Paidprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAIDPRICE"]);
                }
            }

            public Object Cutoffprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CUTOFFPRICE"]);
                }
            }

            public GetPayerInvoiceDocumentByPayer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPayerInvoiceDocumentByPayer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPayerInvoiceDocumentByPayer_Class() : base() { }
        }

        [Serializable] 

        public partial class ICProceduresReportQuery_Class : TTReportNqlObject 
        {
            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public ICProceduresReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ICProceduresReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ICProceduresReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class PayerInvoiceReportInfoQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Payer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYER"]);
                }
            }

            public long? Payercode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Payerid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Payercitycode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITYCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payercityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payeraddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payertaxoffice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTAXOFFICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["TAXOFFICE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payertaxnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTAXNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["TAXNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Drugtotal
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DRUGTOTAL"]);
                }
            }

            public Object Materialtotal
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MATERIALTOTAL"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? GeneralTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Cashier
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CASHIER"]);
                }
            }

            public PayerInvoiceReportInfoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PayerInvoiceReportInfoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PayerInvoiceReportInfoQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class PayerInvoiceReportQuery_Class : TTReportNqlObject 
        {
            public string Pricinggroupdescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGGROUPDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTGROUP"].AllPropertyDefs["GROUPDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public string Trxexternalcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRXEXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Trxname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRXNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PackageOutReasonEnum? PackageOutReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEOUTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["PACKAGEOUTREASON"].DataType;
                    return (PackageOutReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public PayerInvoiceReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PayerInvoiceReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PayerInvoiceReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class MedulaInvoiceProceduresReportQuery_Class : TTReportNqlObject 
        {
            public Object Pricinggroupdescription
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICINGGROUPDESCRIPTION"]);
                }
            }

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public string Trxexternalcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRXEXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Trxname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRXNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? MedulaPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["MEDULAPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public MedulaInvoiceProceduresReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MedulaInvoiceProceduresReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MedulaInvoiceProceduresReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class PayerInvoiceReportQueryBySE_Class : TTReportNqlObject 
        {
            public string Pricinggroupdescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGGROUPDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTGROUP"].AllPropertyDefs["GROUPDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public string Trxexternalcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRXEXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Trxname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRXNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PackageOutReasonEnum? PackageOutReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEOUTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["PACKAGEOUTREASON"].DataType;
                    return (PackageOutReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public PayerInvoiceReportQueryBySE_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PayerInvoiceReportQueryBySE_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PayerInvoiceReportQueryBySE_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Faturalandı
    /// </summary>
            public static Guid Invoiced { get { return new Guid("67695ef7-e9f8-452d-9a9a-208976f32467"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("97466111-c71c-4ae9-8c09-2b2aab50a381"); } }
        }

        public static BindingList<PayerInvoiceDocument.OLAP_GetPayerInvoiceDocument_Class> OLAP_GetPayerInvoiceDocument(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["OLAP_GetPayerInvoiceDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.OLAP_GetPayerInvoiceDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.OLAP_GetPayerInvoiceDocument_Class> OLAP_GetPayerInvoiceDocument(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["OLAP_GetPayerInvoiceDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.OLAP_GetPayerInvoiceDocument_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument> GetByPayerAndStateAndDocumentNo(TTObjectContext objectContext, string PARAMSTATE, string PARAMDOCNO, long PAYERSTARTNO, long PAYERENDNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetByPayerAndStateAndDocumentNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMDOCNO", PARAMDOCNO);
            paramList.Add("PAYERSTARTNO", PAYERSTARTNO);
            paramList.Add("PAYERENDNO", PAYERENDNO);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<PayerInvoiceDocument> GetByStateAndDocumentNoInterval(TTObjectContext objectContext, string PARAMSTATE, string PARAMSTARTDOCNO, string PARAMENDDOCNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetByStateAndDocumentNoInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMSTARTDOCNO", PARAMSTARTDOCNO);
            paramList.Add("PARAMENDDOCNO", PARAMENDDOCNO);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<PayerInvoiceDocument> GetByStateAndDocumentNo(TTObjectContext objectContext, string PARAMSTATE, string PARAMDOCNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetByStateAndDocumentNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMDOCNO", PARAMDOCNO);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<PayerInvoiceDocument> GetByPayerAndDateAndState(TTObjectContext objectContext, DateTime PARAMSTARTDATE, string PARAMSTATE, DateTime PARAMENDDATE, long PAYERSTARTNO, long PAYERENDNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetByPayerAndDateAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);
            paramList.Add("PAYERSTARTNO", PAYERSTARTNO);
            paramList.Add("PAYERENDNO", PAYERENDNO);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<PayerInvoiceDocument> GetByPayerAndStateAndDocumentNoInterval(TTObjectContext objectContext, string PARAMSTATE, string PARAMSTARTDOCNO, string PARAMENDDOCNO, long PAYERSTARTNO, long PAYERENDNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetByPayerAndStateAndDocumentNoInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMSTARTDOCNO", PARAMSTARTDOCNO);
            paramList.Add("PARAMENDDOCNO", PARAMENDDOCNO);
            paramList.Add("PAYERSTARTNO", PAYERSTARTNO);
            paramList.Add("PAYERENDNO", PAYERENDNO);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<PayerInvoiceDocument.OLAP_GetCancelledPayerInvoiceDocument_Class> OLAP_GetCancelledPayerInvoiceDocument(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["OLAP_GetCancelledPayerInvoiceDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.OLAP_GetCancelledPayerInvoiceDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.OLAP_GetCancelledPayerInvoiceDocument_Class> OLAP_GetCancelledPayerInvoiceDocument(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["OLAP_GetCancelledPayerInvoiceDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.OLAP_GetCancelledPayerInvoiceDocument_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument> GetByDate(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<PayerInvoiceDocument> GetByDocumentNo(TTObjectContext objectContext, string DOCUMENTNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetByDocumentNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCUMENTNO", DOCUMENTNO);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<PayerInvoiceDocument> GetByPayerIdAndDateAndState(TTObjectContext objectContext, DateTime PARAMSTARTDATE, string PARAMSTATE, DateTime PARAMENDDATE, string PAYERID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetByPayerIdAndDateAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);
            paramList.Add("PAYERID", PAYERID);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<PayerInvoiceDocument> GetByPayerIdAndStateAndDocumentNo(TTObjectContext objectContext, string PARAMSTATE, string PARAMDOCNO, string PAYERID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetByPayerIdAndStateAndDocumentNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMDOCNO", PARAMDOCNO);
            paramList.Add("PAYERID", PAYERID);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<PayerInvoiceDocument> GetByPayerIdAndStateAndDocumentNoInterval(TTObjectContext objectContext, string PARAMSTATE, string PARAMSTARTDOCNO, string PARAMENDDOCNO, string PAYERID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetByPayerIdAndStateAndDocumentNoInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMSTARTDOCNO", PARAMSTARTDOCNO);
            paramList.Add("PARAMENDDOCNO", PARAMENDDOCNO);
            paramList.Add("PAYERID", PAYERID);

            return ((ITTQuery)objectContext).QueryObjects<PayerInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<PayerInvoiceDocument.GetPayerInvoiceDocumentByPayer_Class> GetPayerInvoiceDocumentByPayer(DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetPayerInvoiceDocumentByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.GetPayerInvoiceDocumentByPayer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.GetPayerInvoiceDocumentByPayer_Class> GetPayerInvoiceDocumentByPayer(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["GetPayerInvoiceDocumentByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.GetPayerInvoiceDocumentByPayer_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.ICProceduresReportQuery_Class> ICProceduresReportQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["ICProceduresReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.ICProceduresReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.ICProceduresReportQuery_Class> ICProceduresReportQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["ICProceduresReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.ICProceduresReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class> PayerInvoiceReportInfoQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["PayerInvoiceReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class> PayerInvoiceReportInfoQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["PayerInvoiceReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.PayerInvoiceReportQuery_Class> PayerInvoiceReportQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["PayerInvoiceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.PayerInvoiceReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.PayerInvoiceReportQuery_Class> PayerInvoiceReportQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["PayerInvoiceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.PayerInvoiceReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.MedulaInvoiceProceduresReportQuery_Class> MedulaInvoiceProceduresReportQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["MedulaInvoiceProceduresReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.MedulaInvoiceProceduresReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.MedulaInvoiceProceduresReportQuery_Class> MedulaInvoiceProceduresReportQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["MedulaInvoiceProceduresReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.MedulaInvoiceProceduresReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.PayerInvoiceReportQueryBySE_Class> PayerInvoiceReportQueryBySE(Guid OBJECTID, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["PayerInvoiceReportQueryBySE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.PayerInvoiceReportQueryBySE_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocument.PayerInvoiceReportQueryBySE_Class> PayerInvoiceReportQueryBySE(TTObjectContext objectContext, Guid OBJECTID, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].QueryDefs["PayerInvoiceReportQueryBySE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocument.PayerInvoiceReportQueryBySE_Class>(objectContext, queryDef, paramList, pi);
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
    /// Toplam KDV tutari
    /// </summary>
        public Currency? TotalVATPrice
        {
            get { return (Currency?)this["TOTALVATPRICE"]; }
            set { this["TOTALVATPRICE"] = value; }
        }

    /// <summary>
    /// Toplam indirim tutari
    /// </summary>
        public Currency? TotalDiscountPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTPRICE"]; }
            set { this["TOTALDISCOUNTPRICE"] = value; }
        }

    /// <summary>
    /// Fatura Tipi
    /// </summary>
        public InvoicePostingInvoiceTypeEnum? InvoicePostingInvoiceType
        {
            get { return (InvoicePostingInvoiceTypeEnum?)(int?)this["INVOICEPOSTINGINVOICETYPE"]; }
            set { this["INVOICEPOSTINGINVOICETYPE"] = value; }
        }

    /// <summary>
    /// Sıra Numarası
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// İlaç Toplamı
    /// </summary>
        public Currency? DrugTotal
        {
            get { return (Currency?)this["DRUGTOTAL"]; }
            set { this["DRUGTOTAL"] = value; }
        }

    /// <summary>
    /// Malzeme Toplamı
    /// </summary>
        public Currency? MaterialTotal
        {
            get { return (Currency?)this["MATERIALTOTAL"]; }
            set { this["MATERIALTOTAL"] = value; }
        }

    /// <summary>
    /// Kurumla İlişki
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePayerInvoiceCollection()
        {
            _PayerInvoice = new PayerInvoice.ChildPayerInvoiceCollection(this, new Guid("4b83ef4a-c7ea-4a10-803b-7a85a7578479"));
            ((ITTChildObjectCollection)_PayerInvoice).GetChildren();
        }

        protected PayerInvoice.ChildPayerInvoiceCollection _PayerInvoice = null;
    /// <summary>
    /// Child collection for Kurum Faturasıyla İlişki
    /// </summary>
        public PayerInvoice.ChildPayerInvoiceCollection PayerInvoice
        {
            get
            {
                if (_PayerInvoice == null)
                    CreatePayerInvoiceCollection();
                return _PayerInvoice;
            }
        }

        virtual protected void CreateInvoicePaymentPatientListCollection()
        {
            _InvoicePaymentPatientList = new InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection(this, new Guid("9a75a70b-53d8-4b8b-8d99-f738e82c4fa4"));
            ((ITTChildObjectCollection)_InvoicePaymentPatientList).GetChildren();
        }

        protected InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection _InvoicePaymentPatientList = null;
    /// <summary>
    /// Child collection for Kurum Faturası Dökümanı ilişkisi
    /// </summary>
        public InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection InvoicePaymentPatientList
        {
            get
            {
                if (_InvoicePaymentPatientList == null)
                    CreateInvoicePaymentPatientListCollection();
                return _InvoicePaymentPatientList;
            }
        }

        virtual protected void CreateInvoicePostDetailCollection()
        {
            _InvoicePostDetail = new InvoicePostDetail.ChildInvoicePostDetailCollection(this, new Guid("d90ce0a9-a51d-44ab-89e0-c4ec6f14d152"));
            ((ITTChildObjectCollection)_InvoicePostDetail).GetChildren();
        }

        protected InvoicePostDetail.ChildInvoicePostDetailCollection _InvoicePostDetail = null;
    /// <summary>
    /// Child collection for Kurum Faturası Dökümanıyla İlişki
    /// </summary>
        public InvoicePostDetail.ChildInvoicePostDetailCollection InvoicePostDetail
        {
            get
            {
                if (_InvoicePostDetail == null)
                    CreateInvoicePostDetailCollection();
                return _InvoicePostDetail;
            }
        }

        virtual protected void CreateSendingInvoiceDetailsCollection()
        {
            _SendingInvoiceDetails = new SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection(this, new Guid("e0e06ca3-d3d4-4d7c-a64a-833c7959d02d"));
            ((ITTChildObjectCollection)_SendingInvoiceDetails).GetChildren();
        }

        protected SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection _SendingInvoiceDetails = null;
    /// <summary>
    /// Child collection for Kurum faturası dökümanı ile ilişki
    /// </summary>
        public SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection SendingInvoiceDetails
        {
            get
            {
                if (_SendingInvoiceDetails == null)
                    CreateSendingInvoiceDetailsCollection();
                return _SendingInvoiceDetails;
            }
        }

        virtual protected void CreateCancelledInvoicePatientListCollection()
        {
            _CancelledInvoicePatientList = new CancelledInvoicePatientList.ChildCancelledInvoicePatientListCollection(this, new Guid("ca5c4496-1eb1-4f96-9ff7-2de4dbda36f0"));
            ((ITTChildObjectCollection)_CancelledInvoicePatientList).GetChildren();
        }

        protected CancelledInvoicePatientList.ChildCancelledInvoicePatientListCollection _CancelledInvoicePatientList = null;
    /// <summary>
    /// Child collection for Kurum Faturası Dökümanı İlişkisi
    /// </summary>
        public CancelledInvoicePatientList.ChildCancelledInvoicePatientListCollection CancelledInvoicePatientList
        {
            get
            {
                if (_CancelledInvoicePatientList == null)
                    CreateCancelledInvoicePatientListCollection();
                return _CancelledInvoicePatientList;
            }
        }

        virtual protected void CreateCancelledInvoicesCollection()
        {
            _CancelledInvoices = new CancelledInvoice.ChildCancelledInvoiceCollection(this, new Guid("4c0d46d7-4eab-49d6-86aa-897a236dd828"));
            ((ITTChildObjectCollection)_CancelledInvoices).GetChildren();
        }

        protected CancelledInvoice.ChildCancelledInvoiceCollection _CancelledInvoices = null;
        public CancelledInvoice.ChildCancelledInvoiceCollection CancelledInvoices
        {
            get
            {
                if (_CancelledInvoices == null)
                    CreateCancelledInvoicesCollection();
                return _CancelledInvoices;
            }
        }

        virtual protected void CreateInvoiceCollectionDetailsCollection()
        {
            _InvoiceCollectionDetails = new InvoiceCollectionDetail.ChildInvoiceCollectionDetailCollection(this, new Guid("c07c14cf-dc9e-42ba-bb38-77fd1ac7cbef"));
            ((ITTChildObjectCollection)_InvoiceCollectionDetails).GetChildren();
        }

        protected InvoiceCollectionDetail.ChildInvoiceCollectionDetailCollection _InvoiceCollectionDetails = null;
    /// <summary>
    /// Child collection for Fatura Dökümanı
    /// </summary>
        public InvoiceCollectionDetail.ChildInvoiceCollectionDetailCollection InvoiceCollectionDetails
        {
            get
            {
                if (_InvoiceCollectionDetails == null)
                    CreateInvoiceCollectionDetailsCollection();
                return _InvoiceCollectionDetails;
            }
        }

        override protected void CreateAccountDocumentGroupsCollectionViews()
        {
            base.CreateAccountDocumentGroupsCollectionViews();
            _PayerInvoiceDocumentGroups = new PayerInvoiceDocumentGroup.ChildPayerInvoiceDocumentGroupCollection(_AccountDocumentGroups, "PayerInvoiceDocumentGroups");
        }

        private PayerInvoiceDocumentGroup.ChildPayerInvoiceDocumentGroupCollection _PayerInvoiceDocumentGroups = null;
        public PayerInvoiceDocumentGroup.ChildPayerInvoiceDocumentGroupCollection PayerInvoiceDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _PayerInvoiceDocumentGroups;
            }            
        }

        protected PayerInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerInvoiceDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERINVOICEDOCUMENT", dataRow) { }
        protected PayerInvoiceDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERINVOICEDOCUMENT", dataRow, isImported) { }
        public PayerInvoiceDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerInvoiceDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerInvoiceDocument() : base() { }

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