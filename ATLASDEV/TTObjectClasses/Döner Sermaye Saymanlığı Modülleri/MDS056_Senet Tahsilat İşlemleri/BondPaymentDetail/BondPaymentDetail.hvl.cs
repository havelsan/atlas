
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BondPaymentDetail")] 

    /// <summary>
    /// Senet Tahsilat Detayı
    /// </summary>
    public  partial class BondPaymentDetail : TTObject
    {
        public class BondPaymentDetailList : TTObjectCollection<BondPaymentDetail> { }
                    
        public class ChildBondPaymentDetailCollection : TTObject.TTChildObjectCollection<BondPaymentDetail>
        {
            public ChildBondPaymentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBondPaymentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ödendi
    /// </summary>
        public bool? Paid
        {
            get { return (bool?)this["PAID"]; }
            set { this["PAID"] = value; }
        }

    /// <summary>
    /// Vade Tarihi
    /// </summary>
        public DateTime? BondDetailDate
        {
            get { return (DateTime?)this["BONDDETAILDATE"]; }
            set { this["BONDDETAILDATE"] = value; }
        }

    /// <summary>
    /// Vade Tutar
    /// </summary>
        public Currency? BondDetailPrice
        {
            get { return (Currency?)this["BONDDETAILPRICE"]; }
            set { this["BONDDETAILPRICE"] = value; }
        }

    /// <summary>
    /// Senet No
    /// </summary>
        public string BondNo
        {
            get { return (string)this["BONDNO"]; }
            set { this["BONDNO"] = value; }
        }

        public BondPayment BondPayment
        {
            get { return (BondPayment)((ITTObject)this).GetParent("BONDPAYMENT"); }
            set { this["BONDPAYMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BondDetail BondDetail
        {
            get { return (BondDetail)((ITTObject)this).GetParent("BONDDETAIL"); }
            set { this["BONDDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BondPaymentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BondPaymentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BondPaymentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BondPaymentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BondPaymentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BONDPAYMENTDETAIL", dataRow) { }
        protected BondPaymentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BONDPAYMENTDETAIL", dataRow, isImported) { }
        public BondPaymentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BondPaymentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BondPaymentDetail() : base() { }

    }
}