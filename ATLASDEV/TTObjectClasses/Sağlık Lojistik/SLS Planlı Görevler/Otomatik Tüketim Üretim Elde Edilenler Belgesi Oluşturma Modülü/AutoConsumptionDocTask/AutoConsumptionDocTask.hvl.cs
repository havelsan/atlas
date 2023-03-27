
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AutoConsumptionDocTask")] 

    /// <summary>
    /// Otomatik Tüketim Üretim Elde Edilenler Belgesi Oluşturma
    /// </summary>
    public  partial class AutoConsumptionDocTask : BaseScheduledTask
    {
        public class AutoConsumptionDocTaskList : TTObjectCollection<AutoConsumptionDocTask> { }
                    
        public class ChildAutoConsumptionDocTaskCollection : TTObject.TTChildObjectCollection<AutoConsumptionDocTask>
        {
            public ChildAutoConsumptionDocTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAutoConsumptionDocTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected AutoConsumptionDocTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AutoConsumptionDocTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AutoConsumptionDocTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AutoConsumptionDocTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AutoConsumptionDocTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AUTOCONSUMPTIONDOCTASK", dataRow) { }
        protected AutoConsumptionDocTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AUTOCONSUMPTIONDOCTASK", dataRow, isImported) { }
        public AutoConsumptionDocTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AutoConsumptionDocTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AutoConsumptionDocTask() : base() { }

    }
}