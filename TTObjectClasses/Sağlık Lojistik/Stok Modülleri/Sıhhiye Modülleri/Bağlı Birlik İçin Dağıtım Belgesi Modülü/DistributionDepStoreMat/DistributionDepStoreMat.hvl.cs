
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DistributionDepStoreMat")] 

    public  partial class DistributionDepStoreMat : StockActionDetailIn, IDistributionDepStoreMat
    {
        public class DistributionDepStoreMatList : TTObjectCollection<DistributionDepStoreMat> { }
                    
        public class ChildDistributionDepStoreMatCollection : TTObject.TTChildObjectCollection<DistributionDepStoreMat>
        {
            public ChildDistributionDepStoreMatCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDistributionDepStoreMatCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İstenen Miktar
    /// </summary>
        public Currency? AcceptedAmount
        {
            get { return (Currency?)this["ACCEPTEDAMOUNT"]; }
            set { this["ACCEPTEDAMOUNT"] = value; }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public DistributionDepStore DistributionDepStore
        {
            get 
            {   
                if (StockAction is DistributionDepStore)
                    return (DistributionDepStore)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected DistributionDepStoreMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DistributionDepStoreMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DistributionDepStoreMat(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DistributionDepStoreMat(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DistributionDepStoreMat(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTRIBUTIONDEPSTOREMAT", dataRow) { }
        protected DistributionDepStoreMat(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTRIBUTIONDEPSTOREMAT", dataRow, isImported) { }
        public DistributionDepStoreMat(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DistributionDepStoreMat(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DistributionDepStoreMat() : base() { }

    }
}