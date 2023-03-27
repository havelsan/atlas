
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodDonationEntry")] 

    /// <summary>
    /// Kan Bağışı Girişi
    /// </summary>
    public  partial class BloodDonationEntry : EpisodeAction
    {
        public class BloodDonationEntryList : TTObjectCollection<BloodDonationEntry> { }
                    
        public class ChildBloodDonationEntryCollection : TTObject.TTChildObjectCollection<BloodDonationEntry>
        {
            public ChildBloodDonationEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodDonationEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("a8d334ce-1826-4fde-b220-4fbcc3cdcb6f"); } }
            public static Guid Entry { get { return new Guid("02a32198-8e54-48c0-9596-4344c264ded9"); } }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected BloodDonationEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodDonationEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodDonationEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodDonationEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodDonationEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODDONATIONENTRY", dataRow) { }
        protected BloodDonationEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODDONATIONENTRY", dataRow, isImported) { }
        public BloodDonationEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodDonationEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodDonationEntry() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}