
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResCardDrawer")] 

    public  partial class ResCardDrawer : ResSection
    {
        public class ResCardDrawerList : TTObjectCollection<ResCardDrawer> { }
                    
        public class ChildResCardDrawerCollection : TTObject.TTChildObjectCollection<ResCardDrawer>
        {
            public ChildResCardDrawerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResCardDrawerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResStockControlSection StockControlSection
        {
            get { return (ResStockControlSection)((ITTObject)this).GetParent("STOCKCONTROLSECTION"); }
            set { this["STOCKCONTROLSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockCardsCollection()
        {
            _StockCards = new StockCard.ChildStockCardCollection(this, new Guid("e38cd4d9-34e8-459e-b1b5-95feff8822aa"));
            ((ITTChildObjectCollection)_StockCards).GetChildren();
        }

        protected StockCard.ChildStockCardCollection _StockCards = null;
    /// <summary>
    /// Child collection for Masa-Stok Kartları
    /// </summary>
        public StockCard.ChildStockCardCollection StockCards
        {
            get
            {
                if (_StockCards == null)
                    CreateStockCardsCollection();
                return _StockCards;
            }
        }

        protected ResCardDrawer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResCardDrawer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResCardDrawer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResCardDrawer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResCardDrawer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESCARDDRAWER", dataRow) { }
        protected ResCardDrawer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESCARDDRAWER", dataRow, isImported) { }
        public ResCardDrawer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResCardDrawer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResCardDrawer() : base() { }

    }
}