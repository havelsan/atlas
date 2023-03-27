
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FreePrescriptionEntry")] 

    /// <summary>
    /// Ayaktan Er/Erbaş Reçete Giriş
    /// </summary>
    public  partial class FreePrescriptionEntry : StockAction, ICheckStockActionOutDetail, IStockOutTransaction
    {
        public class FreePrescriptionEntryList : TTObjectCollection<FreePrescriptionEntry> { }
                    
        public class ChildFreePrescriptionEntryCollection : TTObject.TTChildObjectCollection<FreePrescriptionEntry>
        {
            public ChildFreePrescriptionEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFreePrescriptionEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("88683bb3-69f2-4d12-aeaf-0db0273055d3"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("c8724f4b-0248-44f2-a9d9-94d355c79746"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("c26735c7-6d6c-49b9-8407-33b78ca68648"); } }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _FreePrescriptionEntryDetails = new FreePrescriptionEntryDet.ChildFreePrescriptionEntryDetCollection(_StockActionDetails, "FreePrescriptionEntryDetails");
        }

        private FreePrescriptionEntryDet.ChildFreePrescriptionEntryDetCollection _FreePrescriptionEntryDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public FreePrescriptionEntryDet.ChildFreePrescriptionEntryDetCollection FreePrescriptionEntryDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _FreePrescriptionEntryDetails;
            }            
        }

        protected FreePrescriptionEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FreePrescriptionEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FreePrescriptionEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FreePrescriptionEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FreePrescriptionEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FREEPRESCRIPTIONENTRY", dataRow) { }
        protected FreePrescriptionEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FREEPRESCRIPTIONENTRY", dataRow, isImported) { }
        public FreePrescriptionEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FreePrescriptionEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FreePrescriptionEntry() : base() { }

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