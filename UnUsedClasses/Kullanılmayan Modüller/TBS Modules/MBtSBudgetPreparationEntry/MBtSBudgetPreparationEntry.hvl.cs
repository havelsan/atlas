
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSBudgetPreparationEntry")] 

    public  partial class MBtSBudgetPreparationEntry : TTObject
    {
        public class MBtSBudgetPreparationEntryList : TTObjectCollection<MBtSBudgetPreparationEntry> { }
                    
        public class ChildMBtSBudgetPreparationEntryCollection : TTObject.TTChildObjectCollection<MBtSBudgetPreparationEntry>
        {
            public ChildMBtSBudgetPreparationEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSBudgetPreparationEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mali İşlem
    /// </summary>
        public bool? FinanceOperationType
        {
            get { return (bool?)this["FINANCEOPERATIONTYPE"]; }
            set { this["FINANCEOPERATIONTYPE"] = value; }
        }

    /// <summary>
    /// Tanım
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Finansman Tipi
    /// </summary>
        public bool? FinanceType
        {
            get { return (bool?)this["FINANCETYPE"]; }
            set { this["FINANCETYPE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public MBtSFinanceCenter FinanceCenter
        {
            get { return (MBtSFinanceCenter)((ITTObject)this).GetParent("FINANCECENTER"); }
            set { this["FINANCECENTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSBudgetPreparationInformation BudgetPreparationInformation
        {
            get { return (MBtSBudgetPreparationInformation)((ITTObject)this).GetParent("BUDGETPREPARATIONINFORMATION"); }
            set { this["BUDGETPREPARATIONINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSBudget Budget
        {
            get { return (MBtSBudget)((ITTObject)this).GetParent("BUDGET"); }
            set { this["BUDGET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBudgetYearCollection()
        {
            _BudgetYear = new MBtSBudgetYear.ChildMBtSBudgetYearCollection(this, new Guid("f6d2e244-41ad-410a-bca0-ff1d2bff5e0b"));
            ((ITTChildObjectCollection)_BudgetYear).GetChildren();
        }

        protected MBtSBudgetYear.ChildMBtSBudgetYearCollection _BudgetYear = null;
        public MBtSBudgetYear.ChildMBtSBudgetYearCollection BudgetYear
        {
            get
            {
                if (_BudgetYear == null)
                    CreateBudgetYearCollection();
                return _BudgetYear;
            }
        }

        protected MBtSBudgetPreparationEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSBudgetPreparationEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSBudgetPreparationEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSBudgetPreparationEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSBudgetPreparationEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSBUDGETPREPARATIONENTRY", dataRow) { }
        protected MBtSBudgetPreparationEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSBUDGETPREPARATIONENTRY", dataRow, isImported) { }
        public MBtSBudgetPreparationEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSBudgetPreparationEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSBudgetPreparationEntry() : base() { }

    }
}