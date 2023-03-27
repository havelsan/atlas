
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebenturePaymentDocumentGroup")] 

    /// <summary>
    /// Senet Tahsilat Döküman Grubu
    /// </summary>
    public  partial class DebenturePaymentDocumentGroup : AccountDocumentGroup
    {
        public class DebenturePaymentDocumentGroupList : TTObjectCollection<DebenturePaymentDocumentGroup> { }
                    
        public class ChildDebenturePaymentDocumentGroupCollection : TTObject.TTChildObjectCollection<DebenturePaymentDocumentGroup>
        {
            public ChildDebenturePaymentDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebenturePaymentDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DebenturePaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebenturePaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebenturePaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebenturePaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebenturePaymentDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTUREPAYMENTDOCUMENTGROUP", dataRow) { }
        protected DebenturePaymentDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTUREPAYMENTDOCUMENTGROUP", dataRow, isImported) { }
        public DebenturePaymentDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebenturePaymentDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebenturePaymentDocumentGroup() : base() { }

    }
}