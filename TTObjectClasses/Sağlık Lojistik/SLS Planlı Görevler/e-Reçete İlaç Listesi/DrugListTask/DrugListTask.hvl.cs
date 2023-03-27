
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugListTask")] 

    /// <summary>
    /// Geri ödeme kapsamında olan ilaç listesi
    /// </summary>
    public  partial class DrugListTask : BaseScheduledTask
    {
        public class DrugListTaskList : TTObjectCollection<DrugListTask> { }
                    
        public class ChildDrugListTaskCollection : TTObject.TTChildObjectCollection<DrugListTask>
        {
            public ChildDrugListTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugListTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DrugListTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugListTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugListTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugListTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugListTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGLISTTASK", dataRow) { }
        protected DrugListTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGLISTTASK", dataRow, isImported) { }
        public DrugListTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugListTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugListTask() : base() { }

    }
}