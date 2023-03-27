
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerPaymentDocumentGroup")] 

    /// <summary>
    /// Fatura Tahsilat Döküman Grubu
    /// </summary>
    public  partial class PayerPaymentDocumentGroup : AccountDocumentGroup
    {
        public class PayerPaymentDocumentGroupList : TTObjectCollection<PayerPaymentDocumentGroup> { }
                    
        public class ChildPayerPaymentDocumentGroupCollection : TTObject.TTChildObjectCollection<PayerPaymentDocumentGroup>
        {
            public ChildPayerPaymentDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerPaymentDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected PayerPaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerPaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerPaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerPaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerPaymentDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERPAYMENTDOCUMENTGROUP", dataRow) { }
        protected PayerPaymentDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERPAYMENTDOCUMENTGROUP", dataRow, isImported) { }
        public PayerPaymentDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerPaymentDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerPaymentDocumentGroup() : base() { }

    }
}