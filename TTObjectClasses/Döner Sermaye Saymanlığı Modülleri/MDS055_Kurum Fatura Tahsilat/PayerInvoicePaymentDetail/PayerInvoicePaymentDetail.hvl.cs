
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerInvoicePaymentDetail")] 

    /// <summary>
    /// Fatura Tahsilat Detayı
    /// </summary>
    public  partial class PayerInvoicePaymentDetail : TTObject
    {
        public class PayerInvoicePaymentDetailList : TTObjectCollection<PayerInvoicePaymentDetail> { }
                    
        public class ChildPayerInvoicePaymentDetailCollection : TTObject.TTChildObjectCollection<PayerInvoicePaymentDetail>
        {
            public ChildPayerInvoicePaymentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerInvoicePaymentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByPIPObjectId_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? InvoiceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENTDETAIL"].AllPropertyDefs["INVOICEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string InvoiceNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENTDETAIL"].AllPropertyDefs["INVOICENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? InvoicePrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENTDETAIL"].AllPropertyDefs["INVOICEPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? InvoiceRestPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICERESTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENTDETAIL"].AllPropertyDefs["INVOICERESTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Payment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENTDETAIL"].AllPropertyDefs["PAYMENT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Deduction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEDUCTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENTDETAIL"].AllPropertyDefs["DEDUCTION"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetByPIPObjectId_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByPIPObjectId_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByPIPObjectId_Class() : base() { }
        }

        public static BindingList<PayerInvoicePaymentDetail.GetByPIPObjectId_Class> GetByPIPObjectId(Guid PIPOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENTDETAIL"].QueryDefs["GetByPIPObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PIPOBJECTID", PIPOBJECTID);

            return TTReportNqlObject.QueryObjects<PayerInvoicePaymentDetail.GetByPIPObjectId_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoicePaymentDetail.GetByPIPObjectId_Class> GetByPIPObjectId(TTObjectContext objectContext, Guid PIPOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENTDETAIL"].QueryDefs["GetByPIPObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PIPOBJECTID", PIPOBJECTID);

            return TTReportNqlObject.QueryObjects<PayerInvoicePaymentDetail.GetByPIPObjectId_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Fatura Tarihi
    /// </summary>
        public DateTime? InvoiceDate
        {
            get { return (DateTime?)this["INVOICEDATE"]; }
            set { this["INVOICEDATE"] = value; }
        }

    /// <summary>
    /// Finansal Numarası
    /// </summary>
        public string InvoiceNo
        {
            get { return (string)this["INVOICENO"]; }
            set { this["INVOICENO"] = value; }
        }

    /// <summary>
    /// Fatura Tutarı
    /// </summary>
        public Currency? InvoicePrice
        {
            get { return (Currency?)this["INVOICEPRICE"]; }
            set { this["INVOICEPRICE"] = value; }
        }

    /// <summary>
    /// Fatura Tutarı
    /// </summary>
        public Currency? InvoiceRestPrice
        {
            get { return (Currency?)this["INVOICERESTPRICE"]; }
            set { this["INVOICERESTPRICE"] = value; }
        }

    /// <summary>
    /// Ödeme Tutarı
    /// </summary>
        public Currency? Payment
        {
            get { return (Currency?)this["PAYMENT"]; }
            set { this["PAYMENT"] = value; }
        }

    /// <summary>
    /// Kesinti Tutarı
    /// </summary>
        public Currency? Deduction
        {
            get { return (Currency?)this["DEDUCTION"]; }
            set { this["DEDUCTION"] = value; }
        }

        public PayerInvoicePayment PIP
        {
            get { return (PayerInvoicePayment)((ITTObject)this).GetParent("PIP"); }
            set { this["PIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InvoiceCollectionDetail ICD
        {
            get { return (InvoiceCollectionDetail)((ITTObject)this).GetParent("ICD"); }
            set { this["ICD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PayerInvoicePaymentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerInvoicePaymentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerInvoicePaymentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerInvoicePaymentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerInvoicePaymentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERINVOICEPAYMENTDETAIL", dataRow) { }
        protected PayerInvoicePaymentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERINVOICEPAYMENTDETAIL", dataRow, isImported) { }
        public PayerInvoicePaymentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerInvoicePaymentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerInvoicePaymentDetail() : base() { }

    }
}