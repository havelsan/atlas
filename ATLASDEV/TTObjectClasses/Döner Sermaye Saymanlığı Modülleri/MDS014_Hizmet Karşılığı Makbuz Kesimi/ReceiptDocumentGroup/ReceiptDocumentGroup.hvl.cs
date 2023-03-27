
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReceiptDocumentGroup")] 

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı Döküman Grubu
    /// </summary>
    public  partial class ReceiptDocumentGroup : AccountDocumentGroup
    {
        public class ReceiptDocumentGroupList : TTObjectCollection<ReceiptDocumentGroup> { }
                    
        public class ChildReceiptDocumentGroupCollection : TTObject.TTChildObjectCollection<ReceiptDocumentGroup>
        {
            public ChildReceiptDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReceiptDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPTDOCUMENTGROUP", dataRow) { }
        protected ReceiptDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPTDOCUMENTGROUP", dataRow, isImported) { }
        public ReceiptDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReceiptDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReceiptDocumentGroup() : base() { }

    }
}