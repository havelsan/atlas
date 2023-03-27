
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockTransactionCollectedDefinition")] 

    public  partial class StockTransactionCollectedDefinition : TerminologyManagerDef
    {
        public class StockTransactionCollectedDefinitionList : TTObjectCollection<StockTransactionCollectedDefinition> { }
                    
        public class ChildStockTransactionCollectedDefinitionCollection : TTObject.TTChildObjectCollection<StockTransactionCollectedDefinition>
        {
            public ChildStockTransactionCollectedDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockTransactionCollectedDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<StockTransactionCollectedDefinition> GetStockTransactionCollectedDefinition(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTIONCOLLECTEDDEFINITION"].QueryDefs["GetStockTransactionCollectedDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<StockTransactionCollectedDefinition>(queryDef, paramList);
        }

        public StockTransactionDefinition CheckedStockTransactionDef
        {
            get { return (StockTransactionDefinition)((ITTObject)this).GetParent("CHECKEDSTOCKTRANSACTIONDEF"); }
            set { this["CHECKEDSTOCKTRANSACTIONDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockTransactionDefinition StockTransactionDefinition
        {
            get { return (StockTransactionDefinition)((ITTObject)this).GetParent("STOCKTRANSACTIONDEFINITION"); }
            set { this["STOCKTRANSACTIONDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockTransactionCollectedDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockTransactionCollectedDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockTransactionCollectedDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockTransactionCollectedDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockTransactionCollectedDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKTRANSACTIONCOLLECTEDDEFINITION", dataRow) { }
        protected StockTransactionCollectedDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKTRANSACTIONCOLLECTEDDEFINITION", dataRow, isImported) { }
        public StockTransactionCollectedDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockTransactionCollectedDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockTransactionCollectedDefinition() : base() { }

    }
}