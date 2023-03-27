
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UpdatePhySessionsForOldPhy")] 

    /// <summary>
    /// Eski FTR işlemleri için SessionInfo Ekleme
    /// </summary>
    public  partial class UpdatePhySessionsForOldPhy : BaseScheduledTask
    {
        public class UpdatePhySessionsForOldPhyList : TTObjectCollection<UpdatePhySessionsForOldPhy> { }
                    
        public class ChildUpdatePhySessionsForOldPhyCollection : TTObject.TTChildObjectCollection<UpdatePhySessionsForOldPhy>
        {
            public ChildUpdatePhySessionsForOldPhyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUpdatePhySessionsForOldPhyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected UpdatePhySessionsForOldPhy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UpdatePhySessionsForOldPhy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UpdatePhySessionsForOldPhy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UpdatePhySessionsForOldPhy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UpdatePhySessionsForOldPhy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UPDATEPHYSESSIONSFOROLDPHY", dataRow) { }
        protected UpdatePhySessionsForOldPhy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UPDATEPHYSESSIONSFOROLDPHY", dataRow, isImported) { }
        public UpdatePhySessionsForOldPhy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UpdatePhySessionsForOldPhy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UpdatePhySessionsForOldPhy() : base() { }

    }
}