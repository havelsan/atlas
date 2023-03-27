
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSBudgetYear")] 

    /// <summary>
    /// Bütçe Yılı
    /// </summary>
    public  partial class MBtSBudgetYear : TTObject
    {
        public class MBtSBudgetYearList : TTObjectCollection<MBtSBudgetYear> { }
                    
        public class ChildMBtSBudgetYearCollection : TTObject.TTChildObjectCollection<MBtSBudgetYear>
        {
            public ChildMBtSBudgetYearCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSBudgetYearCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Durum
    /// </summary>
        public int? Status
        {
            get { return (int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Yıl
    /// </summary>
        public int? Year
        {
            get { return (int?)this["YEAR"]; }
            set { this["YEAR"] = value; }
        }

        public MBtSOperation Operation
        {
            get { return (MBtSOperation)((ITTObject)this).GetParent("OPERATION"); }
            set { this["OPERATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSAccountancyEntry AccountancyEntry
        {
            get { return (MBtSAccountancyEntry)((ITTObject)this).GetParent("ACCOUNTANCYENTRY"); }
            set { this["ACCOUNTANCYENTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSAccountancyReceipt AccountancyReceipt
        {
            get { return (MBtSAccountancyReceipt)((ITTObject)this).GetParent("ACCOUNTANCYRECEIPT"); }
            set { this["ACCOUNTANCYRECEIPT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBtSBudgetPreparationEntry BudgetPreparationEntry
        {
            get { return (MBtSBudgetPreparationEntry)((ITTObject)this).GetParent("BUDGETPREPARATIONENTRY"); }
            set { this["BUDGETPREPARATIONENTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBtSBudgetYear(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSBudgetYear(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSBudgetYear(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSBudgetYear(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSBudgetYear(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSBUDGETYEAR", dataRow) { }
        protected MBtSBudgetYear(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSBUDGETYEAR", dataRow, isImported) { }
        public MBtSBudgetYear(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSBudgetYear(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSBudgetYear() : base() { }

    }
}