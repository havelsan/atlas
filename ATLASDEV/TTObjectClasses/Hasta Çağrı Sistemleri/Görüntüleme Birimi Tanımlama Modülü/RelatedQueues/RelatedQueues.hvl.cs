
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RelatedQueues")] 

    public  partial class RelatedQueues : TTObject
    {
        public class RelatedQueuesList : TTObjectCollection<RelatedQueues> { }
                    
        public class ChildRelatedQueuesCollection : TTObject.TTChildObjectCollection<RelatedQueues>
        {
            public ChildRelatedQueuesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRelatedQueuesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ExaminationQueueDefinition ExaminationQueueDefinition
        {
            get { return (ExaminationQueueDefinition)((ITTObject)this).GetParent("EXAMINATIONQUEUEDEFINITION"); }
            set { this["EXAMINATIONQUEUEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AppointmentViewerCompDef AppointmentViewerCompDef
        {
            get { return (AppointmentViewerCompDef)((ITTObject)this).GetParent("APPOINTMENTVIEWERCOMPDEF"); }
            set { this["APPOINTMENTVIEWERCOMPDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RelatedQueues(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RelatedQueues(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RelatedQueues(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RelatedQueues(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RelatedQueues(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RELATEDQUEUES", dataRow) { }
        protected RelatedQueues(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RELATEDQUEUES", dataRow, isImported) { }
        public RelatedQueues(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RelatedQueues(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RelatedQueues() : base() { }

    }
}