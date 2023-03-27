
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientInvoiceDocument")] 

    /// <summary>
    /// Hasta Faturası Dökümanı
    /// </summary>
    public  partial class PatientInvoiceDocument : AccountDocument
    {
        public class PatientInvoiceDocumentList : TTObjectCollection<PatientInvoiceDocument> { }
                    
        public class ChildPatientInvoiceDocumentCollection : TTObject.TTChildObjectCollection<PatientInvoiceDocument>
        {
            public ChildPatientInvoiceDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientInvoiceDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Faturalandı
    /// </summary>
            public static Guid Invoiced { get { return new Guid("5f658722-76f3-47be-8d52-426786eb7ab1"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("d4bb46b4-ffc8-4f65-8c73-99c139419a62"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("dfedbbf7-cde4-455b-8e7e-e83fe7ce5152"); } }
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
    /// Toplan indirim tutarı
    /// </summary>
        public Currency? TotalDiscountPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTPRICE"]; }
            set { this["TOTALDISCOUNTPRICE"] = value; }
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
    /// Adresi
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

    /// <summary>
    /// Toplam KDV tutarı
    /// </summary>
        public Currency? TotalVATPrice
        {
            get { return (Currency?)this["TOTALVATPRICE"]; }
            set { this["TOTALVATPRICE"] = value; }
        }

    /// <summary>
    /// Hastayla İlişki
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePatientInvoiceCollection()
        {
            _PatientInvoice = new PatientInvoice.ChildPatientInvoiceCollection(this, new Guid("358c9b5e-5612-4432-98b7-e975e1193048"));
            ((ITTChildObjectCollection)_PatientInvoice).GetChildren();
        }

        protected PatientInvoice.ChildPatientInvoiceCollection _PatientInvoice = null;
    /// <summary>
    /// Child collection for Hasta Faturası Dökümanıyla İlişki
    /// </summary>
        public PatientInvoice.ChildPatientInvoiceCollection PatientInvoice
        {
            get
            {
                if (_PatientInvoice == null)
                    CreatePatientInvoiceCollection();
                return _PatientInvoice;
            }
        }

        protected PatientInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientInvoiceDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTINVOICEDOCUMENT", dataRow) { }
        protected PatientInvoiceDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTINVOICEDOCUMENT", dataRow, isImported) { }
        public PatientInvoiceDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientInvoiceDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientInvoiceDocument() : base() { }

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