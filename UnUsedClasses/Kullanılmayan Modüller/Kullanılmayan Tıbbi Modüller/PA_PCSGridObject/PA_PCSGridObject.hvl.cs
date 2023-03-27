
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_PCSGridObject")] 

    public  partial class PA_PCSGridObject : TTObject
    {
        public class PA_PCSGridObjectList : TTObjectCollection<PA_PCSGridObject> { }
                    
        public class ChildPA_PCSGridObjectCollection : TTObject.TTChildObjectCollection<PA_PCSGridObject>
        {
            public ChildPA_PCSGridObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_PCSGridObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Öncelik (Sistem)
    /// </summary>
        public QueuePrioritySystemEnum? QueuePrioritySystem
        {
            get { return (QueuePrioritySystemEnum?)(int?)this["QUEUEPRIORITYSYSTEM"]; }
            set { this["QUEUEPRIORITYSYSTEM"] = value; }
        }

    /// <summary>
    /// Seçim
    /// </summary>
        public bool? Checked
        {
            get { return (bool?)this["CHECKED"]; }
            set { this["CHECKED"] = value; }
        }

    /// <summary>
    /// Öncelik Sebebi
    /// </summary>
        public string PriorityText
        {
            get { return (string)this["PRIORITYTEXT"]; }
            set { this["PRIORITYTEXT"] = value; }
        }

        public QueuePriorityDefinition QueuePriorityDefinition
        {
            get { return (QueuePriorityDefinition)((ITTObject)this).GetParent("QUEUEPRIORITYDEFINITION"); }
            set { this["QUEUEPRIORITYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PA_PCSGridObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_PCSGridObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_PCSGridObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_PCSGridObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_PCSGridObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_PCSGRIDOBJECT", dataRow) { }
        protected PA_PCSGridObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_PCSGRIDOBJECT", dataRow, isImported) { }
        public PA_PCSGridObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_PCSGridObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_PCSGridObject() : base() { }

    }
}