
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockTrxUpdateAction")] 

    /// <summary>
    /// Birim Fiyat Değiştirme
    /// </summary>
    public  partial class StockTrxUpdateAction : BaseAction, IWorkListBaseAction
    {
        public class StockTrxUpdateActionList : TTObjectCollection<StockTrxUpdateAction> { }
                    
        public class ChildStockTrxUpdateActionCollection : TTObject.TTChildObjectCollection<StockTrxUpdateAction>
        {
            public ChildStockTrxUpdateActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockTrxUpdateActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("0fbb3d37-1c98-4531-8431-e15fc0e6210c"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("5a5ed2a7-ece8-41c7-a546-6b2f5c64f3c4"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("bfe13726-6299-495c-b429-23f5ffc86ec3"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Canceled { get { return new Guid("4f91d7f1-fee4-4bfa-95e5-84f54c4bbdb1"); } }
        }

    /// <summary>
    /// Yeni Birim Fiyatı
    /// </summary>
        public BigCurrency? NewUnitPrice
        {
            get { return (BigCurrency?)this["NEWUNITPRICE"]; }
            set { this["NEWUNITPRICE"] = value; }
        }

        public MainStoreDefinition MainStoreDefinition
        {
            get { return (MainStoreDefinition)((ITTObject)this).GetParent("MAINSTOREDEFINITION"); }
            set { this["MAINSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockTrxUpdateActionDetailsCollection()
        {
            _StockTrxUpdateActionDetails = new StockTrxUpdateActionDetail.ChildStockTrxUpdateActionDetailCollection(this, new Guid("e1263db7-27e0-43d8-ac53-7e402152fb76"));
            ((ITTChildObjectCollection)_StockTrxUpdateActionDetails).GetChildren();
        }

        protected StockTrxUpdateActionDetail.ChildStockTrxUpdateActionDetailCollection _StockTrxUpdateActionDetails = null;
        public StockTrxUpdateActionDetail.ChildStockTrxUpdateActionDetailCollection StockTrxUpdateActionDetails
        {
            get
            {
                if (_StockTrxUpdateActionDetails == null)
                    CreateStockTrxUpdateActionDetailsCollection();
                return _StockTrxUpdateActionDetails;
            }
        }

        protected StockTrxUpdateAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockTrxUpdateAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockTrxUpdateAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockTrxUpdateAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockTrxUpdateAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKTRXUPDATEACTION", dataRow) { }
        protected StockTrxUpdateAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKTRXUPDATEACTION", dataRow, isImported) { }
        public StockTrxUpdateAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockTrxUpdateAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockTrxUpdateAction() : base() { }

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