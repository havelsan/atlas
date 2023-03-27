
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CollectedInvoiceDocumentGroup")] 

    /// <summary>
    /// Toplu Fatura Döküman Grubu
    /// </summary>
    public  partial class CollectedInvoiceDocumentGroup : AccountDocumentGroup
    {
        public class CollectedInvoiceDocumentGroupList : TTObjectCollection<CollectedInvoiceDocumentGroup> { }
                    
        public class ChildCollectedInvoiceDocumentGroupCollection : TTObject.TTChildObjectCollection<CollectedInvoiceDocumentGroup>
        {
            public ChildCollectedInvoiceDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCollectedInvoiceDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CollectedInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CollectedInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CollectedInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CollectedInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CollectedInvoiceDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLLECTEDINVOICEDOCUMENTGROUP", dataRow) { }
        protected CollectedInvoiceDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLLECTEDINVOICEDOCUMENTGROUP", dataRow, isImported) { }
        public CollectedInvoiceDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CollectedInvoiceDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CollectedInvoiceDocumentGroup() : base() { }

    }
}