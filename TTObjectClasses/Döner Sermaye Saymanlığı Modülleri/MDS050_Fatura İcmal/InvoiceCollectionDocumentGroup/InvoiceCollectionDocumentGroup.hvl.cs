
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceCollectionDocumentGroup")] 

    /// <summary>
    /// Toplu Fatura Döküman Grubu
    /// </summary>
    public  partial class InvoiceCollectionDocumentGroup : AccountDocumentGroup
    {
        public class InvoiceCollectionDocumentGroupList : TTObjectCollection<InvoiceCollectionDocumentGroup> { }
                    
        public class ChildInvoiceCollectionDocumentGroupCollection : TTObject.TTChildObjectCollection<InvoiceCollectionDocumentGroup>
        {
            public ChildInvoiceCollectionDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceCollectionDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        override protected void CreateAccountDocumentDetailsCollectionViews()
        {
            base.CreateAccountDocumentDetailsCollectionViews();
            _InvoiceCollectionDocumentDetails = new InvoiceCollectionDocumentDetail.ChildInvoiceCollectionDocumentDetailCollection(_AccountDocumentDetails, "InvoiceCollectionDocumentDetails");
        }

        private InvoiceCollectionDocumentDetail.ChildInvoiceCollectionDocumentDetailCollection _InvoiceCollectionDocumentDetails = null;
        public InvoiceCollectionDocumentDetail.ChildInvoiceCollectionDocumentDetailCollection InvoiceCollectionDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _InvoiceCollectionDocumentDetails;
            }            
        }

        protected InvoiceCollectionDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceCollectionDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceCollectionDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceCollectionDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceCollectionDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICECOLLECTIONDOCUMENTGROUP", dataRow) { }
        protected InvoiceCollectionDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICECOLLECTIONDOCUMENTGROUP", dataRow, isImported) { }
        public InvoiceCollectionDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceCollectionDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceCollectionDocumentGroup() : base() { }

    }
}