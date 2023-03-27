
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ITSFixedMaterialIn")] 

    public  partial class ITSFixedMaterialIn : StockActionDetailIn
    {
        public class ITSFixedMaterialInList : TTObjectCollection<ITSFixedMaterialIn> { }
                    
        public class ChildITSFixedMaterialInCollection : TTObject.TTChildObjectCollection<ITSFixedMaterialIn>
        {
            public ChildITSFixedMaterialInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildITSFixedMaterialInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Guid? OutStockTransactionID
        {
            get { return (Guid?)this["OUTSTOCKTRANSACTIONID"]; }
            set { this["OUTSTOCKTRANSACTIONID"] = value; }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public ITSFixed ITSFixed
        {
            get 
            {   
                if (StockAction is ITSFixed)
                    return (ITSFixed)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected ITSFixedMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ITSFixedMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ITSFixedMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ITSFixedMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ITSFixedMaterialIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ITSFIXEDMATERIALIN", dataRow) { }
        protected ITSFixedMaterialIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ITSFIXEDMATERIALIN", dataRow, isImported) { }
        public ITSFixedMaterialIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ITSFixedMaterialIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ITSFixedMaterialIn() : base() { }

    }
}