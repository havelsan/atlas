
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoicePaymentPatientList")] 

    /// <summary>
    /// Fatura Tahsilattaki fatura bilgilerini tutar (Fatura Listesi)
    /// </summary>
    public  partial class InvoicePaymentPatientList : TTObject
    {
        public class InvoicePaymentPatientListList : TTObjectCollection<InvoicePaymentPatientList> { }
                    
        public class ChildInvoicePaymentPatientListCollection : TTObject.TTChildObjectCollection<InvoicePaymentPatientList>
        {
            public ChildInvoicePaymentPatientListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoicePaymentPatientListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Fatura Kesinti Tutarı
    /// </summary>
        public Currency? InvoiceCutOffPrice
        {
            get { return (Currency?)this["INVOICECUTOFFPRICE"]; }
            set { this["INVOICECUTOFFPRICE"] = value; }
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
    /// Hasta No
    /// </summary>
        public long? PatientNo
        {
            get { return (long?)this["PATIENTNO"]; }
            set { this["PATIENTNO"] = value; }
        }

    /// <summary>
    /// Fatura Tutarı
    /// </summary>
        public Currency? InvoiceTotalPrice
        {
            get { return (Currency?)this["INVOICETOTALPRICE"]; }
            set { this["INVOICETOTALPRICE"] = value; }
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
    /// Fatura Numarası
    /// </summary>
        public string InvoiceDocumentNo
        {
            get { return (string)this["INVOICEDOCUMENTNO"]; }
            set { this["INVOICEDOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Ödendi mi ?
    /// </summary>
        public bool? Paid
        {
            get { return (bool?)this["PAID"]; }
            set { this["PAID"] = value; }
        }

    /// <summary>
    /// Fatura Tahsilat ilişkisi
    /// </summary>
        public InvoicePayment InvoicePayment
        {
            get { return (InvoicePayment)((ITTObject)this).GetParent("INVOICEPAYMENT"); }
            set { this["INVOICEPAYMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Toplu Fatura Dökümanı ilişkisi
    /// </summary>
        public CollectedInvoiceDocument CollectedInvoiceDocument
        {
            get { return (CollectedInvoiceDocument)((ITTObject)this).GetParent("COLLECTEDINVOICEDOCUMENT"); }
            set { this["COLLECTEDINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum Faturası Dökümanı ilişkisi
    /// </summary>
        public PayerInvoiceDocument PayerInvoiceDocument
        {
            get { return (PayerInvoiceDocument)((ITTObject)this).GetParent("PAYERINVOICEDOCUMENT"); }
            set { this["PAYERINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Karşılığı Kurum Fatura Dökümanı ilişkisi
    /// </summary>
        public GeneralInvoiceDocument GeneralInvoiceDocument
        {
            get { return (GeneralInvoiceDocument)((ITTObject)this).GetParent("GENERALINVOICEDOCUMENT"); }
            set { this["GENERALINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Manuel Kurum Faturası Dökümanı ile ilişki
    /// </summary>
        public ManualInvoiceDocument ManualInvoiceDocument
        {
            get { return (ManualInvoiceDocument)((ITTObject)this).GetParent("MANUALINVOICEDOCUMENT"); }
            set { this["MANUALINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InvoicePaymentPatientList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoicePaymentPatientList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoicePaymentPatientList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoicePaymentPatientList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoicePaymentPatientList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICEPAYMENTPATIENTLIST", dataRow) { }
        protected InvoicePaymentPatientList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICEPAYMENTPATIENTLIST", dataRow, isImported) { }
        public InvoicePaymentPatientList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoicePaymentPatientList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoicePaymentPatientList() : base() { }

    }
}