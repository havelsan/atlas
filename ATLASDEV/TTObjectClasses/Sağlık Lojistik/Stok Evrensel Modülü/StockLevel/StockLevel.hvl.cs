
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockLevel")] 

    /// <summary>
    /// Stok işlemlerinde malzemenin stok seviyesini tutar. yeni/kullanılmış/heke ayrılmış
    /// </summary>
    public  partial class StockLevel : TTObject
    {
        public class StockLevelList : TTObjectCollection<StockLevel> { }
                    
        public class ChildStockLevelCollection : TTObject.TTChildObjectCollection<StockLevel>
        {
            public ChildStockLevelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockLevelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mevcut
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockLevelType StockLevelType
        {
            get { return (StockLevelType)((ITTObject)this).GetParent("STOCKLEVELTYPE"); }
            set { this["STOCKLEVELTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockLevel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockLevel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockLevel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKLEVEL", dataRow) { }
        protected StockLevel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKLEVEL", dataRow, isImported) { }
        public StockLevel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockLevel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockLevel() : base() { }

    }
}