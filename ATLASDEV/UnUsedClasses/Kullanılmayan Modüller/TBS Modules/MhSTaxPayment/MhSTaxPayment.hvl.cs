
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSTaxPayment")] 

    /// <summary>
    /// Vergi Ödeme İşlemleri
    /// </summary>
    public  partial class MhSTaxPayment : TTObject
    {
        public class MhSTaxPaymentList : TTObjectCollection<MhSTaxPayment> { }
                    
        public class ChildMhSTaxPaymentCollection : TTObject.TTChildObjectCollection<MhSTaxPayment>
        {
            public ChildMhSTaxPaymentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSTaxPaymentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ay
    /// </summary>
        public MhSAccountingMonths? Month
        {
            get { return (MhSAccountingMonths?)(int?)this["MONTH"]; }
            set { this["MONTH"] = value; }
        }

    /// <summary>
    /// Damga Vergisi
    /// </summary>
        public double? StampTax
        {
            get { return (double?)this["STAMPTAX"]; }
            set { this["STAMPTAX"] = value; }
        }

    /// <summary>
    /// Karar Pulu
    /// </summary>
        public double? DecisionStamp
        {
            get { return (double?)this["DECISIONSTAMP"]; }
            set { this["DECISIONSTAMP"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Gelir Vergisi
    /// </summary>
        public double? IncomeTax
        {
            get { return (double?)this["INCOMETAX"]; }
            set { this["INCOMETAX"] = value; }
        }

    /// <summary>
    /// Ödeme Fişi
    /// </summary>
        public MhSSpendingSlip PaymentSlip
        {
            get { return (MhSSpendingSlip)((ITTObject)this).GetParent("PAYMENTSLIP"); }
            set { this["PAYMENTSLIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Çalışma Yılı
    /// </summary>
        public MhSPeriod Period
        {
            get { return (MhSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSTaxPayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSTaxPayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSTaxPayment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSTaxPayment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSTaxPayment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSTAXPAYMENT", dataRow) { }
        protected MhSTaxPayment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSTAXPAYMENT", dataRow, isImported) { }
        public MhSTaxPayment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSTaxPayment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSTaxPayment() : base() { }

    }
}