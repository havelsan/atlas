
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DeleteAnimalRecordDocument")] 

    /// <summary>
    /// Taşınır Mal Kayıt Silme Belgesi
    /// </summary>
    public  partial class DeleteAnimalRecordDocument : BaseDeleteRecordDocument, IAutoDocumentNumber, IAutoDocumentRecordLog, IDeleteRecordDocumentDestroyable, IStockOutTransaction
    {
        public class DeleteAnimalRecordDocumentList : TTObjectCollection<DeleteAnimalRecordDocument> { }
                    
        public class ChildDeleteAnimalRecordDocumentCollection : TTObject.TTChildObjectCollection<DeleteAnimalRecordDocument>
        {
            public ChildDeleteAnimalRecordDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDeleteAnimalRecordDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("f1f6f78b-896b-4b54-91f1-eb1745353b78"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("17fab362-9e1a-4c19-866a-90d25abe8ac2"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("e58f0f59-d7cf-49ec-a09b-b225ae9ea66e"); } }
    /// <summary>
    /// Kayıt Silme Muayene
    /// </summary>
            public static Guid DeleteRecordInspection { get { return new Guid("29269d69-9b95-494e-ba58-1569edf054b6"); } }
    /// <summary>
    /// Malzeme Kontrolü
    /// </summary>
            public static Guid MaterialCheck { get { return new Guid("2e2de778-efeb-429f-a26b-9439efcfbe3a"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("61676276-b87a-4be6-97f9-64b4553d2c83"); } }
    /// <summary>
    /// Stok Kart Kayıt
    /// </summary>
            public static Guid StockCardRegistry { get { return new Guid("f0aa89fb-1d7e-4606-a24f-f873d5a5520a"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _DeleteRecordDocumentAnimalOutMaterials = new DeleteRecordDocAnimalDetail.ChildDeleteRecordDocAnimalDetailCollection(_StockActionDetails, "DeleteRecordDocumentAnimalOutMaterials");
        }

        private DeleteRecordDocAnimalDetail.ChildDeleteRecordDocAnimalDetailCollection _DeleteRecordDocumentAnimalOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public DeleteRecordDocAnimalDetail.ChildDeleteRecordDocAnimalDetailCollection DeleteRecordDocumentAnimalOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _DeleteRecordDocumentAnimalOutMaterials;
            }            
        }

        protected DeleteAnimalRecordDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DeleteAnimalRecordDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DeleteAnimalRecordDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DeleteAnimalRecordDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DeleteAnimalRecordDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DELETEANIMALRECORDDOCUMENT", dataRow) { }
        protected DeleteAnimalRecordDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DELETEANIMALRECORDDOCUMENT", dataRow, isImported) { }
        public DeleteAnimalRecordDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DeleteAnimalRecordDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DeleteAnimalRecordDocument() : base() { }

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