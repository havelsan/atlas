
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CashOfficeReceiptDocumentGroup")] 

    /// <summary>
    /// Vezne Tahsilat Alındısı Döküman Grubu
    /// </summary>
    public  partial class CashOfficeReceiptDocumentGroup : AccountDocumentGroup
    {
        public class CashOfficeReceiptDocumentGroupList : TTObjectCollection<CashOfficeReceiptDocumentGroup> { }
                    
        public class ChildCashOfficeReceiptDocumentGroupCollection : TTObject.TTChildObjectCollection<CashOfficeReceiptDocumentGroup>
        {
            public ChildCashOfficeReceiptDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashOfficeReceiptDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CashOfficeReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CashOfficeReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CashOfficeReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CashOfficeReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CashOfficeReceiptDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASHOFFICERECEIPTDOCUMENTGROUP", dataRow) { }
        protected CashOfficeReceiptDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASHOFFICERECEIPTDOCUMENTGROUP", dataRow, isImported) { }
        public CashOfficeReceiptDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CashOfficeReceiptDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CashOfficeReceiptDocumentGroup() : base() { }

    }
}