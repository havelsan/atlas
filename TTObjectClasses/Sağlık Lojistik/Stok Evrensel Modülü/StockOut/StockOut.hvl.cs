
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockOut")] 

    /// <summary>
    /// Stok Çıkışlarının Yapılması İçin kullanılan sınıftır
    /// </summary>
    public  partial class StockOut : StockAction, ICheckStockActionOutDetail, IStockOutTransaction
    {
        public class StockOutList : TTObjectCollection<StockOut> { }
                    
        public class ChildStockOutCollection : TTObject.TTChildObjectCollection<StockOut>
        {
            public ChildStockOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("c50d4cfb-c8e6-4384-a295-34915fac03d0"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("233e7cb1-4ca2-45dd-99d3-995b946dc78a"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("a7f5e22a-ff1c-40b5-a2d1-d65328cb6a9e"); } }
        }

        public bool? CreateRemote
        {
            get { return (bool?)this["CREATEREMOTE"]; }
            set { this["CREATEREMOTE"] = value; }
        }

        public Guid? ProductionDepStoreObjectID
        {
            get { return (Guid?)this["PRODUCTIONDEPSTOREOBJECTID"]; }
            set { this["PRODUCTIONDEPSTOREOBJECTID"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _StockOutMaterials = new StockOutMaterial.ChildStockOutMaterialCollection(_StockActionDetails, "StockOutMaterials");
        }

        private StockOutMaterial.ChildStockOutMaterialCollection _StockOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public StockOutMaterial.ChildStockOutMaterialCollection StockOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _StockOutMaterials;
            }            
        }

        protected StockOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKOUT", dataRow) { }
        protected StockOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKOUT", dataRow, isImported) { }
        public StockOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockOut() : base() { }

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