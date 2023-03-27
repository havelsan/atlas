
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockIn")] 

    /// <summary>
    /// Stok Girişlerinin Yapılması İçin kullanılan sınıftır
    /// </summary>
    public  partial class StockIn : StockAction, IStockInTransaction, IAutoDocumentNumber, IAutoDocumentRecordLog
    {
        public class StockInList : TTObjectCollection<StockIn> { }
                    
        public class ChildStockInCollection : TTObject.TTChildObjectCollection<StockIn>
        {
            public ChildStockInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("e4a172b1-852f-410a-980f-0ef916743c2a"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("e1473217-3530-4161-bdda-73fc7645827f"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("86057be8-856b-42b7-9d99-c2ff6a166119"); } }
        }

        public DrugReturnAction DrugReturnAction
        {
            get { return (DrugReturnAction)((ITTObject)this).GetParent("DRUGRETURNACTION"); }
            set { this["DRUGRETURNACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _StockInMaterials = new StockInMaterial.ChildStockInMaterialCollection(_StockActionDetails, "StockInMaterials");
        }

        private StockInMaterial.ChildStockInMaterialCollection _StockInMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public StockInMaterial.ChildStockInMaterialCollection StockInMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _StockInMaterials;
            }            
        }

        protected StockIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKIN", dataRow) { }
        protected StockIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKIN", dataRow, isImported) { }
        public StockIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockIn() : base() { }

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