
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ScheduledTaskDeneme")] 

    /// <summary>
    /// Planlı Görev Deneme
    /// </summary>
    public  partial class ScheduledTaskDeneme : BaseScheduledTask
    {
        public class ScheduledTaskDenemeList : TTObjectCollection<ScheduledTaskDeneme> { }
                    
        public class ChildScheduledTaskDenemeCollection : TTObject.TTChildObjectCollection<ScheduledTaskDeneme>
        {
            public ChildScheduledTaskDenemeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildScheduledTaskDenemeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ScheduledTaskDeneme(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ScheduledTaskDeneme(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ScheduledTaskDeneme(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ScheduledTaskDeneme(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ScheduledTaskDeneme(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SCHEDULEDTASKDENEME", dataRow) { }
        protected ScheduledTaskDeneme(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SCHEDULEDTASKDENEME", dataRow, isImported) { }
        public ScheduledTaskDeneme(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ScheduledTaskDeneme(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ScheduledTaskDeneme() : base() { }

    }
}