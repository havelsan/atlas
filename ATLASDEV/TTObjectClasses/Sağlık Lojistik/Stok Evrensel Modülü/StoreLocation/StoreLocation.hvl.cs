
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StoreLocation")] 

    public  partial class StoreLocation : TTObject
    {
        public class StoreLocationList : TTObjectCollection<StoreLocation> { }
                    
        public class ChildStoreLocationCollection : TTObject.TTChildObjectCollection<StoreLocation>
        {
            public ChildStoreLocationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStoreLocationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public StockLocation StockLocation
        {
            get { return (StockLocation)((ITTObject)this).GetParent("STOCKLOCATION"); }
            set { this["STOCKLOCATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StoreLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StoreLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StoreLocation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StoreLocation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StoreLocation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STORELOCATION", dataRow) { }
        protected StoreLocation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STORELOCATION", dataRow, isImported) { }
        public StoreLocation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StoreLocation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StoreLocation() : base() { }

    }
}