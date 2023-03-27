
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WaitingDistributionDocTask")] 

    /// <summary>
    /// Bekleyen Dağıtım Belgelerini Tamamlama
    /// </summary>
    public  partial class WaitingDistributionDocTask : BaseScheduledTask
    {
        public class WaitingDistributionDocTaskList : TTObjectCollection<WaitingDistributionDocTask> { }
                    
        public class ChildWaitingDistributionDocTaskCollection : TTObject.TTChildObjectCollection<WaitingDistributionDocTask>
        {
            public ChildWaitingDistributionDocTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWaitingDistributionDocTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Günden Fazla Bekleyen
    /// </summary>
        public int? ExpirationDay
        {
            get { return (int?)this["EXPIRATIONDAY"]; }
            set { this["EXPIRATIONDAY"] = value; }
        }

        protected WaitingDistributionDocTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WaitingDistributionDocTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WaitingDistributionDocTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WaitingDistributionDocTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WaitingDistributionDocTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WAITINGDISTRIBUTIONDOCTASK", dataRow) { }
        protected WaitingDistributionDocTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WAITINGDISTRIBUTIONDOCTASK", dataRow, isImported) { }
        public WaitingDistributionDocTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WaitingDistributionDocTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WaitingDistributionDocTask() : base() { }

    }
}