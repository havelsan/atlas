
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerPaymentAdvanceList")] 

    /// <summary>
    /// Avanstan Ödeme Detaylarını Tutar
    /// </summary>
    public  partial class PayerPaymentAdvanceList : TTObject
    {
        public class PayerPaymentAdvanceListList : TTObjectCollection<PayerPaymentAdvanceList> { }
                    
        public class ChildPayerPaymentAdvanceListCollection : TTObject.TTChildObjectCollection<PayerPaymentAdvanceList>
        {
            public ChildPayerPaymentAdvanceListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerPaymentAdvanceListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dekont No
    /// </summary>
        public string DecountNo
        {
            get { return (string)this["DECOUNTNO"]; }
            set { this["DECOUNTNO"] = value; }
        }

    /// <summary>
    /// Kullanılacak Tutar
    /// </summary>
        public Currency? UsedPrice
        {
            get { return (Currency?)this["USEDPRICE"]; }
            set { this["USEDPRICE"] = value; }
        }

    /// <summary>
    /// Kalan Tutar
    /// </summary>
        public Currency? RemainingPrice
        {
            get { return (Currency?)this["REMAININGPRICE"]; }
            set { this["REMAININGPRICE"] = value; }
        }

    /// <summary>
    /// Kullanıldı mı ?
    /// </summary>
        public bool? Used
        {
            get { return (bool?)this["USED"]; }
            set { this["USED"] = value; }
        }

    /// <summary>
    /// Kurum Avans
    /// </summary>
        public PayerAdvancePayment PayerAdvancePayment
        {
            get { return (PayerAdvancePayment)((ITTObject)this).GetParent("PAYERADVANCEPAYMENT"); }
            set { this["PAYERADVANCEPAYMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fatura Tahsilat ilişkisi
    /// </summary>
        public InvoicePayment InvoicePayment
        {
            get { return (InvoicePayment)((ITTObject)this).GetParent("INVOICEPAYMENT"); }
            set { this["INVOICEPAYMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PayerPaymentAdvanceList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerPaymentAdvanceList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerPaymentAdvanceList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerPaymentAdvanceList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerPaymentAdvanceList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERPAYMENTADVANCELIST", dataRow) { }
        protected PayerPaymentAdvanceList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERPAYMENTADVANCELIST", dataRow, isImported) { }
        public PayerPaymentAdvanceList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerPaymentAdvanceList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerPaymentAdvanceList() : base() { }

    }
}