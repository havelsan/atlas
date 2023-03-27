
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSJournalEntry")] 

    public  partial class MhSJournalEntry : TTObject
    {
        public class MhSJournalEntryList : TTObjectCollection<MhSJournalEntry> { }
                    
        public class ChildMhSJournalEntryCollection : TTObject.TTChildObjectCollection<MhSJournalEntry>
        {
            public ChildMhSJournalEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSJournalEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Alacak
    /// </summary>
        public double? Credit
        {
            get { return (double?)this["CREDIT"]; }
            set { this["CREDIT"] = value; }
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
    /// Sıra
    /// </summary>
        public int? Order
        {
            get { return (int?)this["ORDER"]; }
            set { this["ORDER"] = value; }
        }

    /// <summary>
    /// Fiş Maddeleri
    /// </summary>
        public MhSSlip Slip
        {
            get { return (MhSSlip)((ITTObject)this).GetParent("SLIP"); }
            set { this["SLIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hesap
    /// </summary>
        public MhSAccount Account
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("ACCOUNT"); }
            set { this["ACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSJournalEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSJournalEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSJournalEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSJournalEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSJournalEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSJOURNALENTRY", dataRow) { }
        protected MhSJournalEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSJOURNALENTRY", dataRow, isImported) { }
        public MhSJournalEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSJournalEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSJournalEntry() : base() { }

    }
}