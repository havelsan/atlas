
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoicePayment")] 

    /// <summary>
    /// Fatura Tahsilat
    /// </summary>
    public  partial class InvoicePayment : AccountAction, IWorkListBaseAction
    {
        public class InvoicePaymentList : TTObjectCollection<InvoicePayment> { }
                    
        public class ChildInvoicePaymentCollection : TTObject.TTChildObjectCollection<InvoicePayment>
        {
            public ChildInvoicePaymentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoicePaymentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("4b66c4df-4b2f-4059-9027-0828c85c8681"); } }
            public static Guid New { get { return new Guid("3a065d3a-d8f9-4ae3-84d7-8d7888dae270"); } }
            public static Guid Paid { get { return new Guid("34e32fd6-cdda-4460-ac31-d1ea6a3eeae0"); } }
        }

    /// <summary>
    /// Fatura No (Başlangıç)
    /// </summary>
        public string InvoiceDocumentNoStart
        {
            get { return (string)this["INVOICEDOCUMENTNOSTART"]; }
            set { this["INVOICEDOCUMENTNOSTART"] = value; }
        }

    /// <summary>
    /// Fatura Tarihi (Başlangıç)
    /// </summary>
        public DateTime? InvoiceDateStart
        {
            get { return (DateTime?)this["INVOICEDATESTART"]; }
            set { this["INVOICEDATESTART"] = value; }
        }

    /// <summary>
    /// Ödenecek Tutar
    /// </summary>
        public Currency? PaymentPrice
        {
            get { return (Currency?)this["PAYMENTPRICE"]; }
            set { this["PAYMENTPRICE"] = value; }
        }

    /// <summary>
    /// Fatura Tarihi (Bitiş)
    /// </summary>
        public DateTime? InvoiceDateEnd
        {
            get { return (DateTime?)this["INVOICEDATEEND"]; }
            set { this["INVOICEDATEEND"] = value; }
        }

    /// <summary>
    /// Ödenen Tutar
    /// </summary>
        public Currency? TotalPayment
        {
            get { return (Currency?)this["TOTALPAYMENT"]; }
            set { this["TOTALPAYMENT"] = value; }
        }

    /// <summary>
    /// Avans Kullan
    /// </summary>
        public bool? UseAdvance
        {
            get { return (bool?)this["USEADVANCE"]; }
            set { this["USEADVANCE"] = value; }
        }

    /// <summary>
    /// Fatura No (Bitiş)
    /// </summary>
        public string InvoiceDocumentNoEnd
        {
            get { return (string)this["INVOICEDOCUMENTNOEND"]; }
            set { this["INVOICEDOCUMENTNOEND"] = value; }
        }

    /// <summary>
    /// Kesinti Tutarı
    /// </summary>
        public Currency? CutOffPrice
        {
            get { return (Currency?)this["CUTOFFPRICE"]; }
            set { this["CUTOFFPRICE"] = value; }
        }

    /// <summary>
    /// Kurum ilişkisi
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fatura Tahsilat Dökümanı ilişkisi
    /// </summary>
        public PayerPaymentDocument PayerPaymentDocument
        {
            get { return (PayerPaymentDocument)((ITTObject)this).GetParent("PAYERPAYMENTDOCUMENT"); }
            set { this["PAYERPAYMENTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateInvoicePaymentPatientsCollection()
        {
            _InvoicePaymentPatients = new InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection(this, new Guid("30c86f0b-62d4-4f09-b6e0-70216a8b6027"));
            ((ITTChildObjectCollection)_InvoicePaymentPatients).GetChildren();
        }

        protected InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection _InvoicePaymentPatients = null;
    /// <summary>
    /// Child collection for Fatura Tahsilat ilişkisi
    /// </summary>
        public InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection InvoicePaymentPatients
        {
            get
            {
                if (_InvoicePaymentPatients == null)
                    CreateInvoicePaymentPatientsCollection();
                return _InvoicePaymentPatients;
            }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("fe3c8a49-f894-4469-9e31-7c103728deec"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        virtual protected void CreatePayerPaymentAdvancesCollection()
        {
            _PayerPaymentAdvances = new PayerPaymentAdvanceList.ChildPayerPaymentAdvanceListCollection(this, new Guid("7757c336-ff67-498d-a77b-c34d3792797a"));
            ((ITTChildObjectCollection)_PayerPaymentAdvances).GetChildren();
        }

        protected PayerPaymentAdvanceList.ChildPayerPaymentAdvanceListCollection _PayerPaymentAdvances = null;
    /// <summary>
    /// Child collection for Fatura Tahsilat ilişkisi
    /// </summary>
        public PayerPaymentAdvanceList.ChildPayerPaymentAdvanceListCollection PayerPaymentAdvances
        {
            get
            {
                if (_PayerPaymentAdvances == null)
                    CreatePayerPaymentAdvancesCollection();
                return _PayerPaymentAdvances;
            }
        }

        virtual protected void CreateCancelledInvoicePatientsCollection()
        {
            _CancelledInvoicePatients = new CancelledInvoicePatientList.ChildCancelledInvoicePatientListCollection(this, new Guid("991e3e7e-4f85-40c2-8838-63f8862fc43c"));
            ((ITTChildObjectCollection)_CancelledInvoicePatients).GetChildren();
        }

        protected CancelledInvoicePatientList.ChildCancelledInvoicePatientListCollection _CancelledInvoicePatients = null;
    /// <summary>
    /// Child collection for Fatura Tahsilat ilişkisi
    /// </summary>
        public CancelledInvoicePatientList.ChildCancelledInvoicePatientListCollection CancelledInvoicePatients
        {
            get
            {
                if (_CancelledInvoicePatients == null)
                    CreateCancelledInvoicePatientsCollection();
                return _CancelledInvoicePatients;
            }
        }

        protected InvoicePayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoicePayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoicePayment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoicePayment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoicePayment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICEPAYMENT", dataRow) { }
        protected InvoicePayment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICEPAYMENT", dataRow, isImported) { }
        public InvoicePayment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoicePayment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoicePayment() : base() { }

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