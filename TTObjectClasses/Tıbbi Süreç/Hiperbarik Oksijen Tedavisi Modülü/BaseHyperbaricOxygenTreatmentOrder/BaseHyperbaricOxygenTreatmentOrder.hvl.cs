
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseHyperbaricOxygenTreatmentOrder")] 

    public  partial class BaseHyperbaricOxygenTreatmentOrder : PlannedAction
    {
        public class BaseHyperbaricOxygenTreatmentOrderList : TTObjectCollection<BaseHyperbaricOxygenTreatmentOrder> { }
                    
        public class ChildBaseHyperbaricOxygenTreatmentOrderCollection : TTObject.TTChildObjectCollection<BaseHyperbaricOxygenTreatmentOrder>
        {
            public ChildBaseHyperbaricOxygenTreatmentOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseHyperbaricOxygenTreatmentOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected BaseHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEHYPERBARICOXYGENTREATMENTORDER", dataRow) { }
        protected BaseHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEHYPERBARICOXYGENTREATMENTORDER", dataRow, isImported) { }
        public BaseHyperbaricOxygenTreatmentOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseHyperbaricOxygenTreatmentOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseHyperbaricOxygenTreatmentOrder() : base() { }

    }
}