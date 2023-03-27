
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSMonthlyBalance")] 

    /// <summary>
    /// Aylık Durum
    /// </summary>
    public  partial class MhSMonthlyBalance : TTDefinitionSet
    {
        public class MhSMonthlyBalanceList : TTObjectCollection<MhSMonthlyBalance> { }
                    
        public class ChildMhSMonthlyBalanceCollection : TTObject.TTChildObjectCollection<MhSMonthlyBalance>
        {
            public ChildMhSMonthlyBalanceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSMonthlyBalanceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Borç
    /// </summary>
        public double? Debit
        {
            get { return (double?)this["DEBIT"]; }
            set { this["DEBIT"] = value; }
        }

    /// <summary>
    /// Bakiye
    /// </summary>
        public double? Balance
        {
            get { return (double?)this["BALANCE"]; }
            set { this["BALANCE"] = value; }
        }

    /// <summary>
    /// Alacak
    /// </summary>
        public double? Credit
        {
            get { return (double?)this["CREDIT"]; }
            set { this["CREDIT"] = value; }
        }

    /// <summary>
    /// Bakiye Durumu
    /// </summary>
        public MhSAccount Account
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("ACCOUNT"); }
            set { this["ACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSMonthlyBalance(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSMonthlyBalance(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSMonthlyBalance(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSMonthlyBalance(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSMonthlyBalance(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSMONTHLYBALANCE", dataRow) { }
        protected MhSMonthlyBalance(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSMONTHLYBALANCE", dataRow, isImported) { }
        public MhSMonthlyBalance(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSMonthlyBalance(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSMonthlyBalance() : base() { }

    }
}