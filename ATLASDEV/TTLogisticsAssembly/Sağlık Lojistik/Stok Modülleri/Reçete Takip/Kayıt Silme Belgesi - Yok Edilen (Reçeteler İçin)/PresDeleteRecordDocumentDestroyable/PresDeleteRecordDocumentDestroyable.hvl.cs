
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresDeleteRecordDocumentDestroyable")] 

    /// <summary>
    /// Kayıt Silme Belgesi - Yok Edilen Belgesi (Reçeteler İçin)
    /// </summary>
    public  partial class PresDeleteRecordDocumentDestroyable : DeleteRecordDocumentDestroyable, IBasePrescriptionTransaction, IAutoDocumentNumber, IAutoDocumentRecordLog, IDeleteRecordDocumentDestroyable, IStockOutTransaction
    {
        public class PresDeleteRecordDocumentDestroyableList : TTObjectCollection<PresDeleteRecordDocumentDestroyable> { }
                    
        public class ChildPresDeleteRecordDocumentDestroyableCollection : TTObject.TTChildObjectCollection<PresDeleteRecordDocumentDestroyable>
        {
            public ChildPresDeleteRecordDocumentDestroyableCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresDeleteRecordDocumentDestroyableCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("7ae13617-2719-480d-a511-01462926c1aa"); } }
            public static Guid Cancelled { get { return new Guid("c8553d43-4530-42bc-9d8c-f8a9e408afaf"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("ac9514ae-45ae-47b3-ae83-7030ec298982"); } }
    /// <summary>
    /// Kayıt Silme Muayene
    /// </summary>
            public static Guid DeleteRecordInspection { get { return new Guid("5ef7a076-6576-4663-8eaf-7ba4c8c0a572"); } }
    /// <summary>
    /// Malzeme Kontrolü
    /// </summary>
            public static Guid MaterialCheck { get { return new Guid("fd3ee6c4-83d2-4644-aa80-c0f0e0d4f283"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("d423060e-82bf-4d51-9ab1-8b06075ec169"); } }
    /// <summary>
    /// Stok Kart Kayıt
    /// </summary>
            public static Guid StockCardRegistry { get { return new Guid("11a8c4d1-d061-4ee8-bb06-be325795ee02"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _PresDeleteRecordDocumentDestroyableOutMaterials = new PresDelRecDoctDesMatlOut.ChildPresDelRecDoctDesMatlOutCollection(_StockActionDetails, "PresDeleteRecordDocumentDestroyableOutMaterials");
        }

        private PresDelRecDoctDesMatlOut.ChildPresDelRecDoctDesMatlOutCollection _PresDeleteRecordDocumentDestroyableOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresDelRecDoctDesMatlOut.ChildPresDelRecDoctDesMatlOutCollection PresDeleteRecordDocumentDestroyableOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresDeleteRecordDocumentDestroyableOutMaterials;
            }            
        }

        protected PresDeleteRecordDocumentDestroyable(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresDeleteRecordDocumentDestroyable(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresDeleteRecordDocumentDestroyable(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresDeleteRecordDocumentDestroyable(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresDeleteRecordDocumentDestroyable(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESDELETERECORDDOCUMENTDESTROYABLE", dataRow) { }
        protected PresDeleteRecordDocumentDestroyable(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESDELETERECORDDOCUMENTDESTROYABLE", dataRow, isImported) { }
        public PresDeleteRecordDocumentDestroyable(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresDeleteRecordDocumentDestroyable(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresDeleteRecordDocumentDestroyable() : base() { }

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