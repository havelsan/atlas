
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSIncomingPaymentOrderPayment")] 

    /// <summary>
    /// Gelen Ödeme Emri Harcam
    /// </summary>
    public  partial class MBtSIncomingPaymentOrderPayment : TTObject
    {
        public class MBtSIncomingPaymentOrderPaymentList : TTObjectCollection<MBtSIncomingPaymentOrderPayment> { }
                    
        public class ChildMBtSIncomingPaymentOrderPaymentCollection : TTObject.TTChildObjectCollection<MBtSIncomingPaymentOrderPayment>
        {
            public ChildMBtSIncomingPaymentOrderPaymentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSIncomingPaymentOrderPaymentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem No
    /// </summary>
        public string OperationNo
        {
            get { return (string)this["OPERATIONNO"]; }
            set { this["OPERATIONNO"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

    /// <summary>
    /// Gönderen Makam
    /// </summary>
        public string Sender
        {
            get { return (string)this["SENDER"]; }
            set { this["SENDER"] = value; }
        }

    /// <summary>
    /// Verile Emri Tarihi
    /// </summary>
        public DateTime? PayOrderDate
        {
            get { return (DateTime?)this["PAYORDERDATE"]; }
            set { this["PAYORDERDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            protected set { this["COMMENT"] = value; }
        }

        public MBtSProject Project
        {
            get { return (MBtSProject)((ITTObject)this).GetParent("PROJECT"); }
            set { this["PROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBtSIncomingPaymentOrderPayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSIncomingPaymentOrderPayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSIncomingPaymentOrderPayment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSIncomingPaymentOrderPayment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSIncomingPaymentOrderPayment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSINCOMINGPAYMENTORDERPAYMENT", dataRow) { }
        protected MBtSIncomingPaymentOrderPayment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSINCOMINGPAYMENTORDERPAYMENT", dataRow, isImported) { }
        public MBtSIncomingPaymentOrderPayment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSIncomingPaymentOrderPayment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSIncomingPaymentOrderPayment() : base() { }

    }
}