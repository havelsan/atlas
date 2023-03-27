
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReferableInTransaction")] 

    public  partial class ReferableInTransaction : TTObject
    {
        public class ReferableInTransactionList : TTObjectCollection<ReferableInTransaction> { }
                    
        public class ChildReferableInTransactionCollection : TTObject.TTChildObjectCollection<ReferableInTransaction>
        {
            public ChildReferableInTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReferableInTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public StockTransaction InStockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("INSTOCKTRANSACTION"); }
            set { this["INSTOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OuttableLot OuttableLot
        {
            get { return (OuttableLot)((ITTObject)this).GetParent("OUTTABLELOT"); }
            set { this["OUTTABLELOT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ReferableInTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReferableInTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReferableInTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReferableInTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReferableInTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REFERABLEINTRANSACTION", dataRow) { }
        protected ReferableInTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REFERABLEINTRANSACTION", dataRow, isImported) { }
        public ReferableInTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReferableInTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReferableInTransaction() : base() { }

    }
}