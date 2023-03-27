
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBankExternalBloodProductEntry")] 

    /// <summary>
    /// Dışarıdan Hastaya Kan Ürünü Girişi
    /// </summary>
    public  partial class BloodBankExternalBloodProductEntry : EpisodeAction
    {
        public class BloodBankExternalBloodProductEntryList : TTObjectCollection<BloodBankExternalBloodProductEntry> { }
                    
        public class ChildBloodBankExternalBloodProductEntryCollection : TTObject.TTChildObjectCollection<BloodBankExternalBloodProductEntry>
        {
            public ChildBloodBankExternalBloodProductEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBankExternalBloodProductEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Reject { get { return new Guid("c98916b6-1e12-4919-ab43-05edc1b38a69"); } }
            public static Guid Entry { get { return new Guid("68286e6e-0711-4026-a5a3-d2dc99b020af"); } }
            public static Guid Completed { get { return new Guid("a93d37c1-8803-4940-a281-e71ace573081"); } }
        }

    /// <summary>
    /// İstek Açıklaması
    /// </summary>
        public string RequestDescription
        {
            get { return (string)this["REQUESTDESCRIPTION"]; }
            set { this["REQUESTDESCRIPTION"] = value; }
        }

        protected BloodBankExternalBloodProductEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBankExternalBloodProductEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBankExternalBloodProductEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBankExternalBloodProductEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBankExternalBloodProductEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBANKEXTERNALBLOODPRODUCTENTRY", dataRow) { }
        protected BloodBankExternalBloodProductEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBANKEXTERNALBLOODPRODUCTENTRY", dataRow, isImported) { }
        public BloodBankExternalBloodProductEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBankExternalBloodProductEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBankExternalBloodProductEntry() : base() { }

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