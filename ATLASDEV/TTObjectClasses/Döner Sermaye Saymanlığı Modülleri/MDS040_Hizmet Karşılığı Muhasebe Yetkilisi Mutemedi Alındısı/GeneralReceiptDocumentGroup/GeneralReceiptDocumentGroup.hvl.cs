
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralReceiptDocumentGroup")] 

    /// <summary>
    /// Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı Döküman Grubu
    /// </summary>
    public  partial class GeneralReceiptDocumentGroup : AccountDocumentGroup
    {
        public class GeneralReceiptDocumentGroupList : TTObjectCollection<GeneralReceiptDocumentGroup> { }
                    
        public class ChildGeneralReceiptDocumentGroupCollection : TTObject.TTChildObjectCollection<GeneralReceiptDocumentGroup>
        {
            public ChildGeneralReceiptDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralReceiptDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected GeneralReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralReceiptDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralReceiptDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALRECEIPTDOCUMENTGROUP", dataRow) { }
        protected GeneralReceiptDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALRECEIPTDOCUMENTGROUP", dataRow, isImported) { }
        public GeneralReceiptDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralReceiptDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralReceiptDocumentGroup() : base() { }

    }
}