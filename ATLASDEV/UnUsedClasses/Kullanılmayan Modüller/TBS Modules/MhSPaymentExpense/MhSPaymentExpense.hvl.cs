
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSPaymentExpense")] 

    /// <summary>
    /// Ödeme Harcama
    /// </summary>
    public  partial class MhSPaymentExpense : TTObject
    {
        public class MhSPaymentExpenseList : TTObjectCollection<MhSPaymentExpense> { }
                    
        public class ChildMhSPaymentExpenseCollection : TTObject.TTChildObjectCollection<MhSPaymentExpense>
        {
            public ChildMhSPaymentExpenseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSPaymentExpenseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Onay
    /// </summary>
        public int? Approval
        {
            get { return (int?)this["APPROVAL"]; }
            set { this["APPROVAL"] = value; }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public MhSPaymentUnit Unit
        {
            get { return (MhSPaymentUnit)((ITTObject)this).GetParent("UNIT"); }
            set { this["UNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiş
    /// </summary>
        public MhSSlip Slip
        {
            get { return (MhSSlip)((ITTObject)this).GetParent("SLIP"); }
            set { this["SLIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSPaymentExpense(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSPaymentExpense(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSPaymentExpense(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSPaymentExpense(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSPaymentExpense(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSPAYMENTEXPENSE", dataRow) { }
        protected MhSPaymentExpense(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSPAYMENTEXPENSE", dataRow, isImported) { }
        public MhSPaymentExpense(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSPaymentExpense(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSPaymentExpense() : base() { }

    }
}