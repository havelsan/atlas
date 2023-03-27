
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceCollectionDocumentDetail")] 

    /// <summary>
    /// Toplu Fatura Döküman Detayı
    /// </summary>
    public  partial class InvoiceCollectionDocumentDetail : AccountDocumentDetail
    {
        public class InvoiceCollectionDocumentDetailList : TTObjectCollection<InvoiceCollectionDocumentDetail> { }
                    
        public class ChildInvoiceCollectionDocumentDetailCollection : TTObject.TTChildObjectCollection<InvoiceCollectionDocumentDetail>
        {
            public ChildInvoiceCollectionDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceCollectionDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected InvoiceCollectionDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceCollectionDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceCollectionDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceCollectionDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceCollectionDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICECOLLECTIONDOCUMENTDETAIL", dataRow) { }
        protected InvoiceCollectionDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICECOLLECTIONDOCUMENTDETAIL", dataRow, isImported) { }
        public InvoiceCollectionDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceCollectionDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceCollectionDocumentDetail() : base() { }

    }
}