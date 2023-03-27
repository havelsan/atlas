
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockMergeMaterialIn")] 

    public  partial class StockMergeMaterialIn : StockActionDetailIn, IStockMergeMaterialIn
    {
        public class StockMergeMaterialInList : TTObjectCollection<StockMergeMaterialIn> { }
                    
        public class ChildStockMergeMaterialInCollection : TTObject.TTChildObjectCollection<StockMergeMaterialIn>
        {
            public ChildStockMergeMaterialInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockMergeMaterialInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public StockMergeMaterialOut StockMergeMaterialOut
        {
            get { return (StockMergeMaterialOut)((ITTObject)this).GetParent("STOCKMERGEMATERIALOUT"); }
            set { this["STOCKMERGEMATERIALOUT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public StockMerge StockMerge
        {
            get 
            {   
                if (StockAction is StockMerge)
                    return (StockMerge)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected StockMergeMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockMergeMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockMergeMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockMergeMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockMergeMaterialIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKMERGEMATERIALIN", dataRow) { }
        protected StockMergeMaterialIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKMERGEMATERIALIN", dataRow, isImported) { }
        public StockMergeMaterialIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockMergeMaterialIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockMergeMaterialIn() : base() { }

    }
}