
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSPaymentBudget")] 

    /// <summary>
    /// Ödeme Bütçe
    /// </summary>
    public  partial class MhSPaymentBudget : TTObject
    {
        public class MhSPaymentBudgetList : TTObjectCollection<MhSPaymentBudget> { }
                    
        public class ChildMhSPaymentBudgetCollection : TTObject.TTChildObjectCollection<MhSPaymentBudget>
        {
            public ChildMhSPaymentBudgetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSPaymentBudgetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Kalan
    /// </summary>
        public double? Remaining
        {
            get { return (double?)this["REMAINING"]; }
            set { this["REMAINING"] = value; }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public MhSPaymentUnit Birim
        {
            get { return (MhSPaymentUnit)((ITTObject)this).GetParent("BIRIM"); }
            set { this["BIRIM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Çalışma Yılı
    /// </summary>
        public MhSPeriod Period
        {
            get { return (MhSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSPaymentBudget(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSPaymentBudget(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSPaymentBudget(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSPaymentBudget(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSPaymentBudget(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSPAYMENTBUDGET", dataRow) { }
        protected MhSPaymentBudget(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSPAYMENTBUDGET", dataRow, isImported) { }
        public MhSPaymentBudget(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSPaymentBudget(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSPaymentBudget() : base() { }

    }
}