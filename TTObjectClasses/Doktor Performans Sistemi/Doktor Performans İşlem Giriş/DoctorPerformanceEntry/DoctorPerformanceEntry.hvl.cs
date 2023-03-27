
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoctorPerformanceEntry")] 

    /// <summary>
    /// Doktor Performans İşlem Giriş
    /// </summary>
    public  partial class DoctorPerformanceEntry : EpisodeAction
    {
        public class DoctorPerformanceEntryList : TTObjectCollection<DoctorPerformanceEntry> { }
                    
        public class ChildDoctorPerformanceEntryCollection : TTObject.TTChildObjectCollection<DoctorPerformanceEntry>
        {
            public ChildDoctorPerformanceEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoctorPerformanceEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("517a3684-0727-410d-bf08-2627400040ed"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("bf31363f-30e0-4873-89f7-0874e1d401fc"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("7ca20fec-300a-4ab8-a20c-be95c266b9a4"); } }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _DPEntryProcedures = new DPEntryProcedure.ChildDPEntryProcedureCollection(_SubactionProcedures, "DPEntryProcedures");
        }

        private DPEntryProcedure.ChildDPEntryProcedureCollection _DPEntryProcedures = null;
        public DPEntryProcedure.ChildDPEntryProcedureCollection DPEntryProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _DPEntryProcedures;
            }            
        }

        protected DoctorPerformanceEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoctorPerformanceEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoctorPerformanceEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoctorPerformanceEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoctorPerformanceEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOCTORPERFORMANCEENTRY", dataRow) { }
        protected DoctorPerformanceEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOCTORPERFORMANCEENTRY", dataRow, isImported) { }
        public DoctorPerformanceEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoctorPerformanceEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoctorPerformanceEntry() : base() { }

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