
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CashOfficeClosingDocumentGroup")] 

    /// <summary>
    /// Vezne Kapama Dökümanı Grubu
    /// </summary>
    public  partial class CashOfficeClosingDocumentGroup : AccountDocumentGroup
    {
        public class CashOfficeClosingDocumentGroupList : TTObjectCollection<CashOfficeClosingDocumentGroup> { }
                    
        public class ChildCashOfficeClosingDocumentGroupCollection : TTObject.TTChildObjectCollection<CashOfficeClosingDocumentGroup>
        {
            public ChildCashOfficeClosingDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashOfficeClosingDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CashOfficeClosingDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CashOfficeClosingDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CashOfficeClosingDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CashOfficeClosingDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CashOfficeClosingDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASHOFFICECLOSINGDOCUMENTGROUP", dataRow) { }
        protected CashOfficeClosingDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASHOFFICECLOSINGDOCUMENTGROUP", dataRow, isImported) { }
        public CashOfficeClosingDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CashOfficeClosingDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CashOfficeClosingDocumentGroup() : base() { }

    }
}