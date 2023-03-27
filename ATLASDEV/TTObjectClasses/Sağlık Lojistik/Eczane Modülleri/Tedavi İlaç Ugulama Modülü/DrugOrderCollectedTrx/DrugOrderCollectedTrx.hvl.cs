
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugOrderCollectedTrx")] 

    public  partial class DrugOrderCollectedTrx : TTObject
    {
        public class DrugOrderCollectedTrxList : TTObjectCollection<DrugOrderCollectedTrx> { }
                    
        public class ChildDrugOrderCollectedTrxCollection : TTObject.TTChildObjectCollection<DrugOrderCollectedTrx>
        {
            public ChildDrugOrderCollectedTrxCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugOrderCollectedTrxCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public StockActionDetail StockActionDetail
        {
            get { return (StockActionDetail)((ITTObject)this).GetParent("STOCKACTIONDETAIL"); }
            set { this["STOCKACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrderTransactionDetail DrugOrderTransactionDetail
        {
            get { return (DrugOrderTransactionDetail)((ITTObject)this).GetParent("DRUGORDERTRANSACTIONDETAIL"); }
            set { this["DRUGORDERTRANSACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugOrderCollectedTrx(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugOrderCollectedTrx(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugOrderCollectedTrx(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugOrderCollectedTrx(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugOrderCollectedTrx(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGORDERCOLLECTEDTRX", dataRow) { }
        protected DrugOrderCollectedTrx(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGORDERCOLLECTEDTRX", dataRow, isImported) { }
        public DrugOrderCollectedTrx(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugOrderCollectedTrx(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugOrderCollectedTrx() : base() { }

    }
}