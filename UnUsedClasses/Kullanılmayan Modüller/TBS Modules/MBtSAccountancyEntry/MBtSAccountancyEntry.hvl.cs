
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSAccountancyEntry")] 

    public  partial class MBtSAccountancyEntry : TTObject
    {
        public class MBtSAccountancyEntryList : TTObjectCollection<MBtSAccountancyEntry> { }
                    
        public class ChildMBtSAccountancyEntryCollection : TTObject.TTChildObjectCollection<MBtSAccountancyEntry>
        {
            public ChildMBtSAccountancyEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSAccountancyEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Gönderen Makam
    /// </summary>
        public string Sender
        {
            get { return (string)this["SENDER"]; }
            set { this["SENDER"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public int? Type
        {
            get { return (int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Saymanlık Kodu
    /// </summary>
        public string AccountancyCode
        {
            get { return (string)this["ACCOUNTANCYCODE"]; }
            set { this["ACCOUNTANCYCODE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

        virtual protected void CreateProjectCollection()
        {
            _Project = new MBtSProject.ChildMBtSProjectCollection(this, new Guid("6da1fa30-a720-448a-8a38-5acb18618490"));
            ((ITTChildObjectCollection)_Project).GetChildren();
        }

        protected MBtSProject.ChildMBtSProjectCollection _Project = null;
        public MBtSProject.ChildMBtSProjectCollection Project
        {
            get
            {
                if (_Project == null)
                    CreateProjectCollection();
                return _Project;
            }
        }

        virtual protected void CreateBudgetYearCollection()
        {
            _BudgetYear = new MBtSBudgetYear.ChildMBtSBudgetYearCollection(this, new Guid("8b3f4353-44b6-49c1-882b-81dd5e547bf2"));
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

        virtual protected void CreateFinanceEntryCollection()
        {
            _FinanceEntry = new MBtSFinanceEntry.ChildMBtSFinanceEntryCollection(this, new Guid("983c1b41-9207-45fe-b856-dcae05c6430d"));
            ((ITTChildObjectCollection)_FinanceEntry).GetChildren();
        }

        protected MBtSFinanceEntry.ChildMBtSFinanceEntryCollection _FinanceEntry = null;
        public MBtSFinanceEntry.ChildMBtSFinanceEntryCollection FinanceEntry
        {
            get
            {
                if (_FinanceEntry == null)
                    CreateFinanceEntryCollection();
                return _FinanceEntry;
            }
        }

        protected MBtSAccountancyEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSAccountancyEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSAccountancyEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSAccountancyEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSAccountancyEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSACCOUNTANCYENTRY", dataRow) { }
        protected MBtSAccountancyEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSACCOUNTANCYENTRY", dataRow, isImported) { }
        public MBtSAccountancyEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSAccountancyEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSAccountancyEntry() : base() { }

    }
}