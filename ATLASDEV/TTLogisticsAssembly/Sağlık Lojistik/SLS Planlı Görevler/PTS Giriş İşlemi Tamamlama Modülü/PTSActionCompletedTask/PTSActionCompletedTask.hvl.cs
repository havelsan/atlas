
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PTSActionCompletedTask")] 

    /// <summary>
    /// PTS Giriş İşlemi Tamamlama
    /// </summary>
    public  partial class PTSActionCompletedTask : BaseScheduledTask
    {
        public class PTSActionCompletedTaskList : TTObjectCollection<PTSActionCompletedTask> { }
                    
        public class ChildPTSActionCompletedTaskCollection : TTObject.TTChildObjectCollection<PTSActionCompletedTask>
        {
            public ChildPTSActionCompletedTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPTSActionCompletedTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Günden Fazla Bekleyen
    /// </summary>
        public int? ExpirationDay
        {
            get { return (int?)this["EXPIRATIONDAY"]; }
            set { this["EXPIRATIONDAY"] = value; }
        }

        protected PTSActionCompletedTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PTSActionCompletedTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PTSActionCompletedTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PTSActionCompletedTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PTSActionCompletedTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PTSACTIONCOMPLETEDTASK", dataRow) { }
        protected PTSActionCompletedTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PTSACTIONCOMPLETEDTASK", dataRow, isImported) { }
        public PTSActionCompletedTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PTSActionCompletedTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PTSActionCompletedTask() : base() { }

    }
}