
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSOperationEntry")] 

    /// <summary>
    /// İşlem Kalemi
    /// </summary>
    public  partial class MBtSOperationEntry : TTObject
    {
        public class MBtSOperationEntryList : TTObjectCollection<MBtSOperationEntry> { }
                    
        public class ChildMBtSOperationEntryCollection : TTObject.TTChildObjectCollection<MBtSOperationEntry>
        {
            public ChildMBtSOperationEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSOperationEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Gönderen makam
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

        virtual protected void CreateFinanceEntryCollection()
        {
            _FinanceEntry = new MBtSFinanceEntry.ChildMBtSFinanceEntryCollection(this, new Guid("1d1f3d0b-9356-47fb-b9dd-c7878bba36c9"));
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

        protected MBtSOperationEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSOperationEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSOperationEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSOperationEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSOperationEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSOPERATIONENTRY", dataRow) { }
        protected MBtSOperationEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSOPERATIONENTRY", dataRow, isImported) { }
        public MBtSOperationEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSOperationEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSOperationEntry() : base() { }

    }
}