
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RemoteMethodDefIteration")] 

    public  partial class RemoteMethodDefIteration : TerminologyManagerDef
    {
        public class RemoteMethodDefIterationList : TTObjectCollection<RemoteMethodDefIteration> { }
                    
        public class ChildRemoteMethodDefIterationCollection : TTObject.TTChildObjectCollection<RemoteMethodDefIteration>
        {
            public ChildRemoteMethodDefIterationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRemoteMethodDefIterationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MessageQueueStatusEnum? MessageQueueStatus
        {
            get { return (MessageQueueStatusEnum?)(int?)this["MESSAGEQUEUESTATUS"]; }
            set { this["MESSAGEQUEUESTATUS"] = value; }
        }

        public int? IterationCount
        {
            get { return (int?)this["ITERATIONCOUNT"]; }
            set { this["ITERATIONCOUNT"] = value; }
        }

        public int? NextTrial
        {
            get { return (int?)this["NEXTTRIAL"]; }
            set { this["NEXTTRIAL"] = value; }
        }

        public RemoteMethodDefCustomization RemoteMethodDefCustomization
        {
            get { return (RemoteMethodDefCustomization)((ITTObject)this).GetParent("REMOTEMETHODDEFCUSTOMIZATION"); }
            set { this["REMOTEMETHODDEFCUSTOMIZATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RemoteMethodDefIteration(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RemoteMethodDefIteration(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RemoteMethodDefIteration(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RemoteMethodDefIteration(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RemoteMethodDefIteration(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REMOTEMETHODDEFITERATION", dataRow) { }
        protected RemoteMethodDefIteration(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REMOTEMETHODDEFITERATION", dataRow, isImported) { }
        public RemoteMethodDefIteration(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RemoteMethodDefIteration(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RemoteMethodDefIteration() : base() { }

    }
}