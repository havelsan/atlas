
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Payment")] 

    /// <summary>
    /// Ödeme tiplerinin ana sınıfıdır
    /// </summary>
    public  partial class Payment : TTObject
    {
        public class PaymentList : TTObjectCollection<Payment> { }
                    
        public class ChildPaymentCollection : TTObject.TTChildObjectCollection<Payment>
        {
            public ChildPaymentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPaymentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Fiyat
    /// </summary>
        public Currency? Price
        {
            get { return (Currency?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// AccountDocument ile relation
    /// </summary>
        public AccountDocument AccountDocument
        {
            get { return (AccountDocument)((ITTObject)this).GetParent("ACCOUNTDOCUMENT"); }
            set { this["ACCOUNTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Payment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Payment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Payment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Payment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Payment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYMENT", dataRow) { }
        protected Payment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYMENT", dataRow, isImported) { }
        public Payment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Payment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Payment() : base() { }

    }
}