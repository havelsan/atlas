
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CancelledInvoicePatientList")] 

    /// <summary>
    /// İptal Edilmiş Faturalar
    /// </summary>
    public  partial class CancelledInvoicePatientList : TTObject
    {
        public class CancelledInvoicePatientListList : TTObjectCollection<CancelledInvoicePatientList> { }
                    
        public class ChildCancelledInvoicePatientListCollection : TTObject.TTChildObjectCollection<CancelledInvoicePatientList>
        {
            public ChildCancelledInvoicePatientListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCancelledInvoicePatientListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Hasta Adı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
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
    /// Fatura Numarası
    /// </summary>
        public string InvoiceDocumentNo
        {
            get { return (string)this["INVOICEDOCUMENTNO"]; }
            set { this["INVOICEDOCUMENTNO"] = value; }
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
    /// İptal Nedeni
    /// </summary>
        public string CancelReason
        {
            get { return (string)this["CANCELREASON"]; }
            set { this["CANCELREASON"] = value; }
        }

    /// <summary>
    /// Kurum Faturası Dökümanı İlişkisi
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
    /// Fatura Tahsilat ilişkisi
    /// </summary>
        public InvoicePayment InvoicePayment
        {
            get { return (InvoicePayment)((ITTObject)this).GetParent("INVOICEPAYMENT"); }
            set { this["INVOICEPAYMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CancelledInvoicePatientList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CancelledInvoicePatientList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CancelledInvoicePatientList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CancelledInvoicePatientList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CancelledInvoicePatientList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CANCELLEDINVOICEPATIENTLIST", dataRow) { }
        protected CancelledInvoicePatientList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CANCELLEDINVOICEPATIENTLIST", dataRow, isImported) { }
        public CancelledInvoicePatientList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CancelledInvoicePatientList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CancelledInvoicePatientList() : base() { }

    }
}