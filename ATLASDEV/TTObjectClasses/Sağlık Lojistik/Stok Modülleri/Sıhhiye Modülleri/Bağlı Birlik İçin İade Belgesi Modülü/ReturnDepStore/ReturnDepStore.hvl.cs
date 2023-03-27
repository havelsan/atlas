
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReturnDepStore")] 

    /// <summary>
    /// Bağlı Birlik İçin İade Belgesi
    /// </summary>
    public  partial class ReturnDepStore : StockAction, ICheckStockActionOutDetail, IStockOutTransaction, IReturnDepStore
    {
        public class ReturnDepStoreList : TTObjectCollection<ReturnDepStore> { }
                    
        public class ChildReturnDepStoreCollection : TTObject.TTChildObjectCollection<ReturnDepStore>
        {
            public ChildReturnDepStoreCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReturnDepStoreCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("c75b1416-a53b-40d7-b6d6-295b8a7264de"); } }
    /// <summary>
    /// Saymanlık Onay
    /// </summary>
            public static Guid AccountancyApproval { get { return new Guid("bd14a4ea-02a7-43f2-9ee9-4b9cc6b19ac8"); } }
    /// <summary>
    /// Birlik Onay
    /// </summary>
            public static Guid UnitApproval { get { return new Guid("69bb4364-29c6-4b52-a264-2d09f1ecb01b"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("6802ce6c-4174-4cec-96ae-57e43d8bacdb"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("267026d0-2845-4f45-b8d9-a149d18aaf16"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ReturnDepStoreMaterials = new ReturnDepStoreMaterial.ChildReturnDepStoreMaterialCollection(_StockActionDetails, "ReturnDepStoreMaterials");
        }

        private ReturnDepStoreMaterial.ChildReturnDepStoreMaterialCollection _ReturnDepStoreMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ReturnDepStoreMaterial.ChildReturnDepStoreMaterialCollection ReturnDepStoreMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ReturnDepStoreMaterials;
            }            
        }

        protected ReturnDepStore(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReturnDepStore(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReturnDepStore(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReturnDepStore(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReturnDepStore(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RETURNDEPSTORE", dataRow) { }
        protected ReturnDepStore(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RETURNDEPSTORE", dataRow, isImported) { }
        public ReturnDepStore(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReturnDepStore(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReturnDepStore() : base() { }

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