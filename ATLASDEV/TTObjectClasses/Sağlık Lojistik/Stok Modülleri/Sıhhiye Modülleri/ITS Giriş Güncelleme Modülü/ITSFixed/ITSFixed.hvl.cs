
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ITSFixed")] 

    /// <summary>
    /// ITS Giriş Güncelleme
    /// </summary>
    public  partial class ITSFixed : StockAction, IStockInTransaction, IStockOutTransaction
    {
        public class ITSFixedList : TTObjectCollection<ITSFixed> { }
                    
        public class ChildITSFixedCollection : TTObject.TTChildObjectCollection<ITSFixed>
        {
            public ChildITSFixedCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildITSFixedCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("b346243c-cccf-4694-9ef7-2be0a2cee51c"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("690e1887-6eba-4244-b0ff-c81a3edf8400"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("50506f5b-d296-4b49-b7f1-b68fe8c56d43"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ITSFixedInMaterials = new ITSFixedMaterialIn.ChildITSFixedMaterialInCollection(_StockActionDetails, "ITSFixedInMaterials");
            _ITSFixedOutMaterials = new ITSFixedMaterialOut.ChildITSFixedMaterialOutCollection(_StockActionDetails, "ITSFixedOutMaterials");
        }

        private ITSFixedMaterialIn.ChildITSFixedMaterialInCollection _ITSFixedInMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ITSFixedMaterialIn.ChildITSFixedMaterialInCollection ITSFixedInMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ITSFixedInMaterials;
            }            
        }

        private ITSFixedMaterialOut.ChildITSFixedMaterialOutCollection _ITSFixedOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ITSFixedMaterialOut.ChildITSFixedMaterialOutCollection ITSFixedOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ITSFixedOutMaterials;
            }            
        }

        protected ITSFixed(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ITSFixed(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ITSFixed(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ITSFixed(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ITSFixed(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ITSFIXED", dataRow) { }
        protected ITSFixed(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ITSFIXED", dataRow, isImported) { }
        public ITSFixed(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ITSFixed(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ITSFixed() : base() { }

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