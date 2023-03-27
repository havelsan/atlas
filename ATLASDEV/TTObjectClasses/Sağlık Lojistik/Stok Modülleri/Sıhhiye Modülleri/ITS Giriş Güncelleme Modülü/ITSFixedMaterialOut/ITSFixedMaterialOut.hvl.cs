
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ITSFixedMaterialOut")] 

    public  partial class ITSFixedMaterialOut : StockActionDetailOut
    {
        public class ITSFixedMaterialOutList : TTObjectCollection<ITSFixedMaterialOut> { }
                    
        public class ChildITSFixedMaterialOutCollection : TTObject.TTChildObjectCollection<ITSFixedMaterialOut>
        {
            public ChildITSFixedMaterialOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildITSFixedMaterialOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        protected ITSFixedMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ITSFixedMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ITSFixedMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ITSFixedMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ITSFixedMaterialOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ITSFIXEDMATERIALOUT", dataRow) { }
        protected ITSFixedMaterialOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ITSFIXEDMATERIALOUT", dataRow, isImported) { }
        public ITSFixedMaterialOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ITSFixedMaterialOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ITSFixedMaterialOut() : base() { }

    }
}