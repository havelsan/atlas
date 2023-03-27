
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerPaymentDocument")] 

    /// <summary>
    /// Fatura Tahsilat Dökümanı
    /// </summary>
    public  partial class PayerPaymentDocument : AccountDocument
    {
        public class PayerPaymentDocumentList : TTObjectCollection<PayerPaymentDocument> { }
                    
        public class ChildPayerPaymentDocumentCollection : TTObject.TTChildObjectCollection<PayerPaymentDocument>
        {
            public ChildPayerPaymentDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerPaymentDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetPayerPaymentDocument_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? PayerName
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYERNAME"]);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERPAYMENTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERPAYMENTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalCutOffPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALCUTOFFPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERPAYMENTDOCUMENT"].AllPropertyDefs["TOTALCUTOFFPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERPAYMENTDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPayment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPAYMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEPAYMENT"].AllPropertyDefs["TOTALPAYMENT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetPayerPaymentDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetPayerPaymentDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetPayerPaymentDocument_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledPayerPaymentDocument_Class : TTReportNqlObject 
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

            public OLAP_GetCancelledPayerPaymentDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledPayerPaymentDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledPayerPaymentDocument_Class() : base() { }
        }

        public static class States
        {
            public static Guid Paid { get { return new Guid("6b4559de-2644-4568-9e36-880081d01591"); } }
            public static Guid New { get { return new Guid("d54b1f9a-99ad-44ff-ba6f-d1fbc50eb49c"); } }
            public static Guid Cancelled { get { return new Guid("09ef11c9-63f9-47d5-a3f3-d89964e1fb02"); } }
        }

        public static BindingList<PayerPaymentDocument.OLAP_GetPayerPaymentDocument_Class> OLAP_GetPayerPaymentDocument(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERPAYMENTDOCUMENT"].QueryDefs["OLAP_GetPayerPaymentDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PayerPaymentDocument.OLAP_GetPayerPaymentDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerPaymentDocument.OLAP_GetPayerPaymentDocument_Class> OLAP_GetPayerPaymentDocument(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERPAYMENTDOCUMENT"].QueryDefs["OLAP_GetPayerPaymentDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PayerPaymentDocument.OLAP_GetPayerPaymentDocument_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerPaymentDocument.OLAP_GetCancelledPayerPaymentDocument_Class> OLAP_GetCancelledPayerPaymentDocument(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERPAYMENTDOCUMENT"].QueryDefs["OLAP_GetCancelledPayerPaymentDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PayerPaymentDocument.OLAP_GetCancelledPayerPaymentDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerPaymentDocument.OLAP_GetCancelledPayerPaymentDocument_Class> OLAP_GetCancelledPayerPaymentDocument(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERPAYMENTDOCUMENT"].QueryDefs["OLAP_GetCancelledPayerPaymentDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PayerPaymentDocument.OLAP_GetCancelledPayerPaymentDocument_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplam Kesinti Tutarı
    /// </summary>
        public Currency? TotalCutOffPrice
        {
            get { return (Currency?)this["TOTALCUTOFFPRICE"]; }
            set { this["TOTALCUTOFFPRICE"] = value; }
        }

    /// <summary>
    /// Kurum ilişkisi
    /// </summary>
        public PayerDefinition PayerName
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYERNAME"); }
            set { this["PAYERNAME"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateInvoicePaymentCollection()
        {
            _InvoicePayment = new InvoicePayment.ChildInvoicePaymentCollection(this, new Guid("68c02392-693e-40d8-9e72-aa2ce5214f01"));
            ((ITTChildObjectCollection)_InvoicePayment).GetChildren();
        }

        protected InvoicePayment.ChildInvoicePaymentCollection _InvoicePayment = null;
    /// <summary>
    /// Child collection for Fatura Tahsilat Dökümanı ilişkisi
    /// </summary>
        public InvoicePayment.ChildInvoicePaymentCollection InvoicePayment
        {
            get
            {
                if (_InvoicePayment == null)
                    CreateInvoicePaymentCollection();
                return _InvoicePayment;
            }
        }

        protected PayerPaymentDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerPaymentDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerPaymentDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerPaymentDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerPaymentDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERPAYMENTDOCUMENT", dataRow) { }
        protected PayerPaymentDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERPAYMENTDOCUMENT", dataRow, isImported) { }
        public PayerPaymentDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerPaymentDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerPaymentDocument() : base() { }

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