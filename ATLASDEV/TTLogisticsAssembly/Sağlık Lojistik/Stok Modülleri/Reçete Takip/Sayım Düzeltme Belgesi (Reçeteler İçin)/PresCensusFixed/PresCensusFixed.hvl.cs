
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresCensusFixed")] 

    /// <summary>
    /// Sayım Düzeltme Belgesi (Reçeteler İçin)
    /// </summary>
    public  partial class PresCensusFixed : CensusFixed, IAutoDocumentNumber, IAutoDocumentRecordLog, ICensusFixed, IBasePrescriptionTransaction, ICheckStockActionInDetail, ICheckStockActionOutDetail, IStockInTransaction, IStockOutTransaction
    {
        public class PresCensusFixedList : TTObjectCollection<PresCensusFixed> { }
                    
        public class ChildPresCensusFixedCollection : TTObject.TTChildObjectCollection<PresCensusFixed>
        {
            public ChildPresCensusFixedCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresCensusFixedCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("0098e9ee-a9b2-432c-90a7-379303dc330a"); } }
            public static Guid Cancelled { get { return new Guid("c46f81b1-26dd-4457-b2af-191980a7fcdb"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("fc409e77-ae9d-41ff-8632-8e6aa7206bcd"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("000a1f6c-f2d1-4281-b5d0-3deaecf111cc"); } }
    /// <summary>
    /// Stok Kart Kayıt
    /// </summary>
            public static Guid StockCardRegistry { get { return new Guid("5907918e-ac70-4944-b7dd-7189b848f74b"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _PresCensusFixedInMaterials = new PresCensusFixedMaterialIn.ChildPresCensusFixedMaterialInCollection(_StockActionDetails, "PresCensusFixedInMaterials");
            _PresCensusFixedOutMaterials = new PresCensusFixedMaterialOut.ChildPresCensusFixedMaterialOutCollection(_StockActionDetails, "PresCensusFixedOutMaterials");
        }

        private PresCensusFixedMaterialIn.ChildPresCensusFixedMaterialInCollection _PresCensusFixedInMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresCensusFixedMaterialIn.ChildPresCensusFixedMaterialInCollection PresCensusFixedInMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresCensusFixedInMaterials;
            }            
        }

        private PresCensusFixedMaterialOut.ChildPresCensusFixedMaterialOutCollection _PresCensusFixedOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresCensusFixedMaterialOut.ChildPresCensusFixedMaterialOutCollection PresCensusFixedOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresCensusFixedOutMaterials;
            }            
        }

        protected PresCensusFixed(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresCensusFixed(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresCensusFixed(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresCensusFixed(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresCensusFixed(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCENSUSFIXED", dataRow) { }
        protected PresCensusFixed(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCENSUSFIXED", dataRow, isImported) { }
        public PresCensusFixed(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresCensusFixed(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresCensusFixed() : base() { }

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