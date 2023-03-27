
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSIncomingDeductionOrder")] 

    public  partial class MBtSIncomingDeductionOrder : TTObject
    {
        public class MBtSIncomingDeductionOrderList : TTObjectCollection<MBtSIncomingDeductionOrder> { }
                    
        public class ChildMBtSIncomingDeductionOrderCollection : TTObject.TTChildObjectCollection<MBtSIncomingDeductionOrder>
        {
            public ChildMBtSIncomingDeductionOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSIncomingDeductionOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
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
    /// No
    /// </summary>
        public string No
        {
            get { return (string)this["NO"]; }
            set { this["NO"] = value; }
        }

    /// <summary>
    /// Saymanlığa verilen miktar
    /// </summary>
        public double? TotalSentAccountancy
        {
            get { return (double?)this["TOTALSENTACCOUNTANCY"]; }
            set { this["TOTALSENTACCOUNTANCY"] = value; }
        }

    /// <summary>
    /// Tutar
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

        public MBtSAccountancy Accountancy
        {
            get { return (MBtSAccountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateFinanceEntriesCollection()
        {
            _FinanceEntries = new MBtSFinanceEntry.ChildMBtSFinanceEntryCollection(this, new Guid("f2f2dee7-8274-41f6-9aed-757e5f8fd13e"));
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

        protected MBtSIncomingDeductionOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSIncomingDeductionOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSIncomingDeductionOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSIncomingDeductionOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSIncomingDeductionOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSINCOMINGDEDUCTIONORDER", dataRow) { }
        protected MBtSIncomingDeductionOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSINCOMINGDEDUCTIONORDER", dataRow, isImported) { }
        public MBtSIncomingDeductionOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSIncomingDeductionOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSIncomingDeductionOrder() : base() { }

    }
}