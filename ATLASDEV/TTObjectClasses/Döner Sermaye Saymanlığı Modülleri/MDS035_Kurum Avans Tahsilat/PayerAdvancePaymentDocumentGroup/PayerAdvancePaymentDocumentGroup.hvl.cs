
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerAdvancePaymentDocumentGroup")] 

    /// <summary>
    /// Kurum Avans Tahsilat Döküman Grubu
    /// </summary>
    public  partial class PayerAdvancePaymentDocumentGroup : AccountDocumentGroup
    {
        public class PayerAdvancePaymentDocumentGroupList : TTObjectCollection<PayerAdvancePaymentDocumentGroup> { }
                    
        public class ChildPayerAdvancePaymentDocumentGroupCollection : TTObject.TTChildObjectCollection<PayerAdvancePaymentDocumentGroup>
        {
            public ChildPayerAdvancePaymentDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerAdvancePaymentDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected PayerAdvancePaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerAdvancePaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerAdvancePaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerAdvancePaymentDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerAdvancePaymentDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERADVANCEPAYMENTDOCUMENTGROUP", dataRow) { }
        protected PayerAdvancePaymentDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERADVANCEPAYMENTDOCUMENTGROUP", dataRow, isImported) { }
        public PayerAdvancePaymentDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerAdvancePaymentDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerAdvancePaymentDocumentGroup() : base() { }

    }
}