
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceDocument")] 

    /// <summary>
    /// Fatura Dökümanı
    /// </summary>
    public  partial class InvoiceDocument : AccountDocument
    {
        public class InvoiceDocumentList : TTObjectCollection<InvoiceDocument> { }
                    
        public class ChildInvoiceDocumentCollection : TTObject.TTChildObjectCollection<InvoiceDocument>
        {
            public ChildInvoiceDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kurumla İlişki
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICEDOCUMENT", dataRow) { }
        protected InvoiceDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICEDOCUMENT", dataRow, isImported) { }
        public InvoiceDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceDocument() : base() { }

    }
}