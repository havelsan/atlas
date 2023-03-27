
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockPrescriptionOut")] 

    /// <summary>
    /// Reçete Çıkış
    /// </summary>
    public  partial class StockPrescriptionOut : StockAction, IStockOutTransaction, IBasePrescriptionTransaction
    {
        public class StockPrescriptionOutList : TTObjectCollection<StockPrescriptionOut> { }
                    
        public class ChildStockPrescriptionOutCollection : TTObject.TTChildObjectCollection<StockPrescriptionOut>
        {
            public ChildStockPrescriptionOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockPrescriptionOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f5b4f4c2-e817-401f-8f6f-edd2f45ec9a2"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("f0319be7-23ee-486e-bd0e-a09d9a3db0c2"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("71d426c4-e826-46e0-a7d6-2a05ec565789"); } }
        }

        public PrescriptionPaper PrescriptionPaper
        {
            get { return (PrescriptionPaper)((ITTObject)this).GetParent("PRESCRIPTIONPAPER"); }
            set { this["PRESCRIPTIONPAPER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Prescription Prescription
        {
            get { return (Prescription)((ITTObject)this).GetParent("PRESCRIPTION"); }
            set { this["PRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _StockPrescriptionOutMaterials = new StockPrescriptionOutMat.ChildStockPrescriptionOutMatCollection(_StockActionDetails, "StockPrescriptionOutMaterials");
        }

        private StockPrescriptionOutMat.ChildStockPrescriptionOutMatCollection _StockPrescriptionOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public StockPrescriptionOutMat.ChildStockPrescriptionOutMatCollection StockPrescriptionOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _StockPrescriptionOutMaterials;
            }            
        }

        protected StockPrescriptionOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockPrescriptionOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockPrescriptionOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockPrescriptionOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockPrescriptionOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKPRESCRIPTIONOUT", dataRow) { }
        protected StockPrescriptionOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKPRESCRIPTIONOUT", dataRow, isImported) { }
        public StockPrescriptionOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockPrescriptionOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockPrescriptionOut() : base() { }

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