
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSBudget")] 

    /// <summary>
    /// Bütçe
    /// </summary>
    public  partial class MBtSBudget : TTObject
    {
        public class MBtSBudgetList : TTObjectCollection<MBtSBudget> { }
                    
        public class ChildMBtSBudgetCollection : TTObject.TTChildObjectCollection<MBtSBudget>
        {
            public ChildMBtSBudgetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSBudgetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tenkis tutarı
    /// </summary>
        public double? TotalReduction
        {
            get { return (double?)this["TOTALREDUCTION"]; }
            set { this["TOTALREDUCTION"] = value; }
        }

    /// <summary>
    /// Tahmini bütçe
    /// </summary>
        public double? ApproximateBudget
        {
            get { return (double?)this["APPROXIMATEBUDGET"]; }
            set { this["APPROXIMATEBUDGET"] = value; }
        }

    /// <summary>
    /// Açık avans, kredi tutarı
    /// </summary>
        public double? TotalOpenAdvanceCredit
        {
            get { return (double?)this["TOTALOPENADVANCECREDIT"]; }
            set { this["TOTALOPENADVANCECREDIT"] = value; }
        }

    /// <summary>
    /// Harcanan tutarı
    /// </summary>
        public double? TotalOutgoing
        {
            get { return (double?)this["TOTALOUTGOING"]; }
            set { this["TOTALOUTGOING"] = value; }
        }

    /// <summary>
    /// Kesin bütçe
    /// </summary>
        public double? AbsoluteBudget
        {
            get { return (double?)this["ABSOLUTEBUDGET"]; }
            set { this["ABSOLUTEBUDGET"] = value; }
        }

    /// <summary>
    /// Mahsup avans,kredi tutarı
    /// </summary>
        public double? TotalDeductionAdvanceCredit
        {
            get { return (double?)this["TOTALDEDUCTIONADVANCECREDIT"]; }
            set { this["TOTALDEDUCTIONADVANCECREDIT"] = value; }
        }

    /// <summary>
    /// Gelen tutarı
    /// </summary>
        public double? TotalIncoming
        {
            get { return (double?)this["TOTALINCOMING"]; }
            set { this["TOTALINCOMING"] = value; }
        }

        public MBtSAccountancy Accountancy
        {
            get { return (MBtSAccountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBudgetPreparationEntriesCollection()
        {
            _BudgetPreparationEntries = new MBtSBudgetPreparationEntry.ChildMBtSBudgetPreparationEntryCollection(this, new Guid("87833b81-fd02-49c4-a535-c711922866c9"));
            ((ITTChildObjectCollection)_BudgetPreparationEntries).GetChildren();
        }

        protected MBtSBudgetPreparationEntry.ChildMBtSBudgetPreparationEntryCollection _BudgetPreparationEntries = null;
        public MBtSBudgetPreparationEntry.ChildMBtSBudgetPreparationEntryCollection BudgetPreparationEntries
        {
            get
            {
                if (_BudgetPreparationEntries == null)
                    CreateBudgetPreparationEntriesCollection();
                return _BudgetPreparationEntries;
            }
        }

        protected MBtSBudget(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSBudget(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSBudget(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSBudget(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSBudget(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSBUDGET", dataRow) { }
        protected MBtSBudget(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSBUDGET", dataRow, isImported) { }
        public MBtSBudget(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSBudget(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSBudget() : base() { }

    }
}