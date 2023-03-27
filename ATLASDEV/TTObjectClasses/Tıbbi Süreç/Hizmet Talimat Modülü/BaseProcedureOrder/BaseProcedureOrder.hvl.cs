
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseProcedureOrder")] 

    public  partial class BaseProcedureOrder : PeriodicOrder
    {
        public class BaseProcedureOrderList : TTObjectCollection<BaseProcedureOrder> { }
                    
        public class ChildBaseProcedureOrderCollection : TTObject.TTChildObjectCollection<BaseProcedureOrder>
        {
            public ChildBaseProcedureOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseProcedureOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected BaseProcedureOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseProcedureOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseProcedureOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseProcedureOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseProcedureOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEPROCEDUREORDER", dataRow) { }
        protected BaseProcedureOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEPROCEDUREORDER", dataRow, isImported) { }
        public BaseProcedureOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseProcedureOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseProcedureOrder() : base() { }

    }
}