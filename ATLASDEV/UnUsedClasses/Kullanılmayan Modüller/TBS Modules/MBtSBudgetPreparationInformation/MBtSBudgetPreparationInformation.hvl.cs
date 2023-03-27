
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSBudgetPreparationInformation")] 

    public  partial class MBtSBudgetPreparationInformation : TTObject
    {
        public class MBtSBudgetPreparationInformationList : TTObjectCollection<MBtSBudgetPreparationInformation> { }
                    
        public class ChildMBtSBudgetPreparationInformationCollection : TTObject.TTChildObjectCollection<MBtSBudgetPreparationInformation>
        {
            public ChildMBtSBudgetPreparationInformationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSBudgetPreparationInformationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
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
    /// Toplam Ödenek
    /// </summary>
        public double? TotalFund
        {
            get { return (double?)this["TOTALFUND"]; }
            set { this["TOTALFUND"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

        public MBtSAccountancy Accountancy
        {
            get { return (MBtSAccountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBudgetPreparationEntriesCollection()
        {
            _BudgetPreparationEntries = new MBtSBudgetPreparationEntry.ChildMBtSBudgetPreparationEntryCollection(this, new Guid("7b2ef280-afab-46f1-8f58-768bf7fe68af"));
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

        protected MBtSBudgetPreparationInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSBudgetPreparationInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSBudgetPreparationInformation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSBudgetPreparationInformation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSBudgetPreparationInformation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSBUDGETPREPARATIONINFORMATION", dataRow) { }
        protected MBtSBudgetPreparationInformation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSBUDGETPREPARATIONINFORMATION", dataRow, isImported) { }
        public MBtSBudgetPreparationInformation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSBudgetPreparationInformation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSBudgetPreparationInformation() : base() { }

    }
}