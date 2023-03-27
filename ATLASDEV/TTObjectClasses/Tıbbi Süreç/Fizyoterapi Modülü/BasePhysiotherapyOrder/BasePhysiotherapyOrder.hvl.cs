
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BasePhysiotherapyOrder")] 

    public  partial class BasePhysiotherapyOrder : PlannedAction
    {
        public class BasePhysiotherapyOrderList : TTObjectCollection<BasePhysiotherapyOrder> { }
                    
        public class ChildBasePhysiotherapyOrderCollection : TTObject.TTChildObjectCollection<BasePhysiotherapyOrder>
        {
            public ChildBasePhysiotherapyOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBasePhysiotherapyOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected BasePhysiotherapyOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BasePhysiotherapyOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BasePhysiotherapyOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BasePhysiotherapyOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BasePhysiotherapyOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEPHYSIOTHERAPYORDER", dataRow) { }
        protected BasePhysiotherapyOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEPHYSIOTHERAPYORDER", dataRow, isImported) { }
        public BasePhysiotherapyOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BasePhysiotherapyOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BasePhysiotherapyOrder() : base() { }

    }
}