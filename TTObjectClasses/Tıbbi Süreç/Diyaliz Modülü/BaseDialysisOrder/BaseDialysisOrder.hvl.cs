
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDialysisOrder")] 

    public  partial class BaseDialysisOrder : PlannedAction
    {
        public class BaseDialysisOrderList : TTObjectCollection<BaseDialysisOrder> { }
                    
        public class ChildBaseDialysisOrderCollection : TTObject.TTChildObjectCollection<BaseDialysisOrder>
        {
            public ChildBaseDialysisOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDialysisOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected BaseDialysisOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDialysisOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDialysisOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDialysisOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDialysisOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDIALYSISORDER", dataRow) { }
        protected BaseDialysisOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDIALYSISORDER", dataRow, isImported) { }
        public BaseDialysisOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDialysisOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDialysisOrder() : base() { }

    }
}