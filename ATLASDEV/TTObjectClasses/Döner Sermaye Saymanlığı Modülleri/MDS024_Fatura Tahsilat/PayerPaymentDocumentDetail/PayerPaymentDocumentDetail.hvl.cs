
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerPaymentDocumentDetail")] 

    /// <summary>
    /// Fatura Tahsilat Döküman Detayları
    /// </summary>
    public  partial class PayerPaymentDocumentDetail : AccountDocumentDetail
    {
        public class PayerPaymentDocumentDetailList : TTObjectCollection<PayerPaymentDocumentDetail> { }
                    
        public class ChildPayerPaymentDocumentDetailCollection : TTObject.TTChildObjectCollection<PayerPaymentDocumentDetail>
        {
            public ChildPayerPaymentDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerPaymentDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected PayerPaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerPaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerPaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerPaymentDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerPaymentDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERPAYMENTDOCUMENTDETAIL", dataRow) { }
        protected PayerPaymentDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERPAYMENTDOCUMENTDETAIL", dataRow, isImported) { }
        public PayerPaymentDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerPaymentDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerPaymentDocumentDetail() : base() { }

    }
}