
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerAdvancePaymentDocumentDetail")] 

    /// <summary>
    /// Kurum Avans Tahsilat Döküman Detayı
    /// </summary>
    public  partial class PayerAdvancePaymentDocumentDetail : AccountDocumentDetail
    {
        public class PayerAdvancePaymentDocumentDetailList : TTObjectCollection<PayerAdvancePaymentDocumentDetail> { }
                    
        public class ChildPayerAdvancePaymentDocumentDetailCollection : TTObject.TTChildObjectCollection<PayerAdvancePaymentDocumentDetail>
        {
            public ChildPayerAdvancePaymentDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerAdvancePaymentDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected PayerAdvancePaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerAdvancePaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerAdvancePaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerAdvancePaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerAdvancePaymentDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERADVANCEPAYMENTDOCUMENTDETAIL", dataRow) { }
        protected PayerAdvancePaymentDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERADVANCEPAYMENTDOCUMENTDETAIL", dataRow, isImported) { }
        public PayerAdvancePaymentDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerAdvancePaymentDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerAdvancePaymentDocumentDetail() : base() { }

    }
}