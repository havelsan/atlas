
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSPersonnelBase")] 

    /// <summary>
    /// Personel Temel
    /// </summary>
    public  partial class MBSPersonnelBase : TTObject
    {
        public class MBSPersonnelBaseList : TTObjectCollection<MBSPersonnelBase> { }
                    
        public class ChildMBSPersonnelBaseCollection : TTObject.TTChildObjectCollection<MBSPersonnelBase>
        {
            public ChildMBSPersonnelBaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSPersonnelBaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ek Gösterge
    /// </summary>
        public int? AdditionalIndicator
        {
            get { return (int?)this["ADDITIONALINDICATOR"]; }
            set { this["ADDITIONALINDICATOR"] = value; }
        }

    /// <summary>
    /// Görev
    /// </summary>
        public string Job
        {
            get { return (string)this["JOB"]; }
            set { this["JOB"] = value; }
        }

    /// <summary>
    /// Rütbe / Ünvan
    /// </summary>
        public string RankTitle
        {
            get { return (string)this["RANKTITLE"]; }
            set { this["RANKTITLE"] = value; }
        }

    /// <summary>
    /// Gösterge
    /// </summary>
        public int? Indicator
        {
            get { return (int?)this["INDICATOR"]; }
            set { this["INDICATOR"] = value; }
        }

    /// <summary>
    /// Görev Yeri
    /// </summary>
        public string JobPlace
        {
            get { return (string)this["JOBPLACE"]; }
            set { this["JOBPLACE"] = value; }
        }

        virtual protected void CreateCDutyExpensesCollection()
        {
            _CDutyExpenses = new MBSCDutyExpense.ChildMBSCDutyExpenseCollection(this, new Guid("ad167e52-41f8-41da-b5c7-376eb3c1742f"));
            ((ITTChildObjectCollection)_CDutyExpenses).GetChildren();
        }

        protected MBSCDutyExpense.ChildMBSCDutyExpenseCollection _CDutyExpenses = null;
        public MBSCDutyExpense.ChildMBSCDutyExpenseCollection CDutyExpenses
        {
            get
            {
                if (_CDutyExpenses == null)
                    CreateCDutyExpensesCollection();
                return _CDutyExpenses;
            }
        }

        protected MBSPersonnelBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSPersonnelBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSPersonnelBase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSPersonnelBase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSPersonnelBase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSPERSONNELBASE", dataRow) { }
        protected MBSPersonnelBase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSPERSONNELBASE", dataRow, isImported) { }
        public MBSPersonnelBase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSPersonnelBase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSPersonnelBase() : base() { }

    }
}