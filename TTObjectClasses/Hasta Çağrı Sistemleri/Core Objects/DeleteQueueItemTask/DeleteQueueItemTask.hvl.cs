
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DeleteQueueItemTask")] 

    public  partial class DeleteQueueItemTask : BaseScheduledTask
    {
        public class DeleteQueueItemTaskList : TTObjectCollection<DeleteQueueItemTask> { }
                    
        public class ChildDeleteQueueItemTaskCollection : TTObject.TTChildObjectCollection<DeleteQueueItemTask>
        {
            public ChildDeleteQueueItemTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDeleteQueueItemTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DeleteQueueItemTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DeleteQueueItemTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DeleteQueueItemTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DeleteQueueItemTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DeleteQueueItemTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DELETEQUEUEITEMTASK", dataRow) { }
        protected DeleteQueueItemTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DELETEQUEUEITEMTASK", dataRow, isImported) { }
        public DeleteQueueItemTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DeleteQueueItemTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DeleteQueueItemTask() : base() { }

    }
}