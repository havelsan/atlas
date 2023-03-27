
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresChaDocDetWithPurchase")] 

    public  partial class PresChaDocDetWithPurchase : ChattelDocumentDetailWithPurchase
    {
        public class PresChaDocDetWithPurchaseList : TTObjectCollection<PresChaDocDetWithPurchase> { }
                    
        public class ChildPresChaDocDetWithPurchaseCollection : TTObject.TTChildObjectCollection<PresChaDocDetWithPurchase>
        {
            public ChildPresChaDocDetWithPurchaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresChaDocDetWithPurchaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PresChaDocWithPurchase PresChaDocWithPurchase
        {
            get 
            {   
                if (StockAction is PresChaDocWithPurchase)
                    return (PresChaDocWithPurchase)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PresChaDocDetWithPurchase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresChaDocDetWithPurchase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresChaDocDetWithPurchase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresChaDocDetWithPurchase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresChaDocDetWithPurchase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCHADOCDETWITHPURCHASE", dataRow) { }
        protected PresChaDocDetWithPurchase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCHADOCDETWITHPURCHASE", dataRow, isImported) { }
        public PresChaDocDetWithPurchase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresChaDocDetWithPurchase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresChaDocDetWithPurchase() : base() { }

    }
}