
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralInvoiceDocumentGroup")] 

    public  partial class GeneralInvoiceDocumentGroup : AccountDocumentGroup
    {
        public class GeneralInvoiceDocumentGroupList : TTObjectCollection<GeneralInvoiceDocumentGroup> { }
                    
        public class ChildGeneralInvoiceDocumentGroupCollection : TTObject.TTChildObjectCollection<GeneralInvoiceDocumentGroup>
        {
            public ChildGeneralInvoiceDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralInvoiceDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected GeneralInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralInvoiceDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALINVOICEDOCUMENTGROUP", dataRow) { }
        protected GeneralInvoiceDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALINVOICEDOCUMENTGROUP", dataRow, isImported) { }
        public GeneralInvoiceDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralInvoiceDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralInvoiceDocumentGroup() : base() { }

    }
}