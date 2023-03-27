
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockFirstTransfer")] 

    /// <summary>
    /// İlk Transfer işlemi için kullanılan ana sınıftır
    /// </summary>
    public  partial class StockFirstTransfer : StockAction, IStockTransferTransaction
    {
        public class StockFirstTransferList : TTObjectCollection<StockFirstTransfer> { }
                    
        public class ChildStockFirstTransferCollection : TTObject.TTChildObjectCollection<StockFirstTransfer>
        {
            public ChildStockFirstTransferCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockFirstTransferCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("c8a7b8af-f3e4-443f-9f73-566429d91df1"); } }
            public static Guid Cancelled { get { return new Guid("81cce88a-0737-4dab-be81-aa096461bbda"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("47bae426-6e51-402e-a842-dcc3b875421e"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _StockFirstTransferDetails = new StockFirstTransferDetail.ChildStockFirstTransferDetailCollection(_StockActionDetails, "StockFirstTransferDetails");
        }

        private StockFirstTransferDetail.ChildStockFirstTransferDetailCollection _StockFirstTransferDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public StockFirstTransferDetail.ChildStockFirstTransferDetailCollection StockFirstTransferDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _StockFirstTransferDetails;
            }            
        }

        protected StockFirstTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockFirstTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockFirstTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockFirstTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockFirstTransfer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKFIRSTTRANSFER", dataRow) { }
        protected StockFirstTransfer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKFIRSTTRANSFER", dataRow, isImported) { }
        public StockFirstTransfer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockFirstTransfer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockFirstTransfer() : base() { }

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