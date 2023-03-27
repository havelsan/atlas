
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubStoreStockTransferMat")] 

    public  partial class SubStoreStockTransferMat : StockActionDetailOut
    {
        public class SubStoreStockTransferMatList : TTObjectCollection<SubStoreStockTransferMat> { }
                    
        public class ChildSubStoreStockTransferMatCollection : TTObject.TTChildObjectCollection<SubStoreStockTransferMat>
        {
            public ChildSubStoreStockTransferMatCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubStoreStockTransferMatCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İstenen Miktar
    /// </summary>
        public Currency? RequestAmount
        {
            get { return (Currency?)this["REQUESTAMOUNT"]; }
            set { this["REQUESTAMOUNT"] = value; }
        }

        protected SubStoreStockTransferMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubStoreStockTransferMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubStoreStockTransferMat(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubStoreStockTransferMat(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubStoreStockTransferMat(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBSTORESTOCKTRANSFERMAT", dataRow) { }
        protected SubStoreStockTransferMat(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBSTORESTOCKTRANSFERMAT", dataRow, isImported) { }
        public SubStoreStockTransferMat(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubStoreStockTransferMat(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubStoreStockTransferMat() : base() { }

    }
}