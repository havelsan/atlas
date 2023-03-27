
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainStoreStockTransferMat")] 

    public  partial class MainStoreStockTransferMat : StockActionDetailOut
    {
        public class MainStoreStockTransferMatList : TTObjectCollection<MainStoreStockTransferMat> { }
                    
        public class ChildMainStoreStockTransferMatCollection : TTObject.TTChildObjectCollection<MainStoreStockTransferMat>
        {
            public ChildMainStoreStockTransferMatCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainStoreStockTransferMatCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İstenen Miktar
    /// </summary>
        public Currency? RequestAmount
        {
            get { return (Currency?)this["REQUESTAMOUNT"]; }
            set { this["REQUESTAMOUNT"] = value; }
        }

        protected MainStoreStockTransferMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainStoreStockTransferMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainStoreStockTransferMat(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainStoreStockTransferMat(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainStoreStockTransferMat(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINSTORESTOCKTRANSFERMAT", dataRow) { }
        protected MainStoreStockTransferMat(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINSTORESTOCKTRANSFERMAT", dataRow, isImported) { }
        public MainStoreStockTransferMat(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainStoreStockTransferMat(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainStoreStockTransferMat() : base() { }

    }
}