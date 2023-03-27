
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DeleteRecordDocumentWaste")] 

    /// <summary>
    /// Kayıt Silme Belgesi - Hek Edilen için kullanılan temel sınıftır
    /// </summary>
    public  partial class DeleteRecordDocumentWaste : BaseDeleteRecordDocument, IDeleteRecordDocumentWaste, IStockOutTransaction, IAutoDocumentNumber, IAutoDocumentRecordLog
    {
        public class DeleteRecordDocumentWasteList : TTObjectCollection<DeleteRecordDocumentWaste> { }
                    
        public class ChildDeleteRecordDocumentWasteCollection : TTObject.TTChildObjectCollection<DeleteRecordDocumentWaste>
        {
            public ChildDeleteRecordDocumentWasteCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDeleteRecordDocumentWasteCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("9e33418b-9588-4bc7-b792-50246c9150fc"); } }
            public static Guid Cancelled { get { return new Guid("f5f51bf4-4951-4647-83f1-1ccba39c5fce"); } }
    /// <summary>
    /// Malzeme Kontrolü
    /// </summary>
            public static Guid MaterialCheck { get { return new Guid("5f9d2399-15da-4795-819d-2402d330f94b"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("cf2e3a8d-2cc7-4a8e-b95b-9eb0794cddb6"); } }
    /// <summary>
    /// Kayıt Silme Muayene
    /// </summary>
            public static Guid DeleteRecordInspection { get { return new Guid("53f80452-ab57-4f64-be7e-3bfbcfaf261f"); } }
    /// <summary>
    /// Stok Kart Kayıt
    /// </summary>
            public static Guid StockCardRegistry { get { return new Guid("9f599480-67be-4c80-b72c-f6fddf3b629b"); } }
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("863c0013-671a-4f6a-a30c-fe97bb2b590c"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _DeleteRecordDocumentWasteOutMaterials = new DeleteRecordDocumentWasteMaterialOut.ChildDeleteRecordDocumentWasteMaterialOutCollection(_StockActionDetails, "DeleteRecordDocumentWasteOutMaterials");
        }

        private DeleteRecordDocumentWasteMaterialOut.ChildDeleteRecordDocumentWasteMaterialOutCollection _DeleteRecordDocumentWasteOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public DeleteRecordDocumentWasteMaterialOut.ChildDeleteRecordDocumentWasteMaterialOutCollection DeleteRecordDocumentWasteOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _DeleteRecordDocumentWasteOutMaterials;
            }            
        }

        protected DeleteRecordDocumentWaste(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DeleteRecordDocumentWaste(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DeleteRecordDocumentWaste(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DeleteRecordDocumentWaste(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DeleteRecordDocumentWaste(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DELETERECORDDOCUMENTWASTE", dataRow) { }
        protected DeleteRecordDocumentWaste(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DELETERECORDDOCUMENTWASTE", dataRow, isImported) { }
        public DeleteRecordDocumentWaste(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DeleteRecordDocumentWaste(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DeleteRecordDocumentWaste() : base() { }

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