
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DepStoreFirstIn")] 

    /// <summary>
    /// Bağlı Birlik İlk Giriş İşlemi
    /// </summary>
    public  partial class DepStoreFirstIn : StockAction, IDepStoreFirstIn, IStockInTransaction
    {
        public class DepStoreFirstInList : TTObjectCollection<DepStoreFirstIn> { }
                    
        public class ChildDepStoreFirstInCollection : TTObject.TTChildObjectCollection<DepStoreFirstIn>
        {
            public ChildDepStoreFirstInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDepStoreFirstInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("062fa4be-2639-4c7c-85f6-e4ddc17a42a3"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("fc73bf6f-f448-4eb9-a8f3-4df8d5ca5308"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("02da5769-3efc-4370-b33f-29dc290ec9ac"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _DepStoreFirstInDetails = new DepStoreFirstInDetail.ChildDepStoreFirstInDetailCollection(_StockActionDetails, "DepStoreFirstInDetails");
        }

        private DepStoreFirstInDetail.ChildDepStoreFirstInDetailCollection _DepStoreFirstInDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public DepStoreFirstInDetail.ChildDepStoreFirstInDetailCollection DepStoreFirstInDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _DepStoreFirstInDetails;
            }            
        }

        protected DepStoreFirstIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DepStoreFirstIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DepStoreFirstIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DepStoreFirstIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DepStoreFirstIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEPSTOREFIRSTIN", dataRow) { }
        protected DepStoreFirstIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEPSTOREFIRSTIN", dataRow, isImported) { }
        public DepStoreFirstIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DepStoreFirstIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DepStoreFirstIn() : base() { }

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