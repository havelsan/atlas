
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockMergeMaterialOut")] 

    public  partial class StockMergeMaterialOut : StockActionDetailOut, IStockMergeMaterialOut
    {
        public class StockMergeMaterialOutList : TTObjectCollection<StockMergeMaterialOut> { }
                    
        public class ChildStockMergeMaterialOutCollection : TTObject.TTChildObjectCollection<StockMergeMaterialOut>
        {
            public ChildStockMergeMaterialOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockMergeMaterialOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public StockMergeMaterialIn StockMergeMaterialIn
        {
            get { return (StockMergeMaterialIn)((ITTObject)this).GetParent("STOCKMERGEMATERIALIN"); }
            set { this["STOCKMERGEMATERIALIN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockTransaction OutableStockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("OUTABLESTOCKTRANSACTION"); }
            set { this["OUTABLESTOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
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

        protected StockMergeMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockMergeMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockMergeMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockMergeMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockMergeMaterialOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKMERGEMATERIALOUT", dataRow) { }
        protected StockMergeMaterialOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKMERGEMATERIALOUT", dataRow, isImported) { }
        public StockMergeMaterialOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockMergeMaterialOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockMergeMaterialOut() : base() { }

    }
}