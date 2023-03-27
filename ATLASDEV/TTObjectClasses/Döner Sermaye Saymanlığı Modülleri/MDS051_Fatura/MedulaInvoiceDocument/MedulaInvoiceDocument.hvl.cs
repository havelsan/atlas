
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaInvoiceDocument")] 

    public  partial class MedulaInvoiceDocument : InvoiceDocument
    {
        public class MedulaInvoiceDocumentList : TTObjectCollection<MedulaInvoiceDocument> { }
                    
        public class ChildMedulaInvoiceDocumentCollection : TTObject.TTChildObjectCollection<MedulaInvoiceDocument>
        {
            public ChildMedulaInvoiceDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaInvoiceDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Fatura Referans Numarası
    /// </summary>
        public TTSequence InvoiceReferenceNo
        {
            get { return GetSequence("INVOICEREFERENCENO"); }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string ResultCode
        {
            get { return (string)this["RESULTCODE"]; }
            set { this["RESULTCODE"] = value; }
        }

    /// <summary>
    /// Sonuç Mesajı
    /// </summary>
        public string ResultMessage
        {
            get { return (string)this["RESULTMESSAGE"]; }
            set { this["RESULTMESSAGE"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public MedulaInvoiceStatusEnum? Status
        {
            get { return (MedulaInvoiceStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

        protected MedulaInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaInvoiceDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAINVOICEDOCUMENT", dataRow) { }
        protected MedulaInvoiceDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAINVOICEDOCUMENT", dataRow, isImported) { }
        public MedulaInvoiceDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaInvoiceDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaInvoiceDocument() : base() { }

    }
}