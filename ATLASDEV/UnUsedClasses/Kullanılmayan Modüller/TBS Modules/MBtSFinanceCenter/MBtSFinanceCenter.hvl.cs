
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSFinanceCenter")] 

    /// <summary>
    /// Mali Merkez
    /// </summary>
    public  partial class MBtSFinanceCenter : TTObject
    {
        public class MBtSFinanceCenterList : TTObjectCollection<MBtSFinanceCenter> { }
                    
        public class ChildMBtSFinanceCenterCollection : TTObject.TTChildObjectCollection<MBtSFinanceCenter>
        {
            public ChildMBtSFinanceCenterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSFinanceCenterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanım
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public MBtSPaymaster PayMaster
        {
            get { return (MBtSPaymaster)((ITTObject)this).GetParent("PAYMASTER"); }
            set { this["PAYMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSAdditionalFund AdditionalFund
        {
            get { return (MBtSAdditionalFund)((ITTObject)this).GetParent("ADDITIONALFUND"); }
            set { this["ADDITIONALFUND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBudgetPreparationEntriesCollection()
        {
            _BudgetPreparationEntries = new MBtSBudgetPreparationEntry.ChildMBtSBudgetPreparationEntryCollection(this, new Guid("fd8f8728-b63e-4c9d-a7a6-1834986c40ad"));
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

        virtual protected void CreateFinanceEntriesCollection()
        {
            _FinanceEntries = new MBtSFinanceEntry.ChildMBtSFinanceEntryCollection(this, new Guid("df56534b-a726-402f-93f9-b4d495510f9d"));
            ((ITTChildObjectCollection)_FinanceEntries).GetChildren();
        }

        protected MBtSFinanceEntry.ChildMBtSFinanceEntryCollection _FinanceEntries = null;
        public MBtSFinanceEntry.ChildMBtSFinanceEntryCollection FinanceEntries
        {
            get
            {
                if (_FinanceEntries == null)
                    CreateFinanceEntriesCollection();
                return _FinanceEntries;
            }
        }

        protected MBtSFinanceCenter(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSFinanceCenter(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSFinanceCenter(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSFinanceCenter(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSFinanceCenter(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSFINANCECENTER", dataRow) { }
        protected MBtSFinanceCenter(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSFINANCECENTER", dataRow, isImported) { }
        public MBtSFinanceCenter(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSFinanceCenter(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSFinanceCenter() : base() { }

    }
}