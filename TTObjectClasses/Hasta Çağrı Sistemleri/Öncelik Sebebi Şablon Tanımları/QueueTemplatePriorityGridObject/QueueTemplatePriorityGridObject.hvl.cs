
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="QueueTemplatePriorityGridObject")] 

    /// <summary>
    /// Grid Nesnesi
    /// </summary>
    public  partial class QueueTemplatePriorityGridObject : TTDefinitionSet
    {
        public class QueueTemplatePriorityGridObjectList : TTObjectCollection<QueueTemplatePriorityGridObject> { }
                    
        public class ChildQueueTemplatePriorityGridObjectCollection : TTObject.TTChildObjectCollection<QueueTemplatePriorityGridObject>
        {
            public ChildQueueTemplatePriorityGridObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildQueueTemplatePriorityGridObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Önceliği
    /// </summary>
        public int? Priority
        {
            get { return (int?)this["PRIORITY"]; }
            set { this["PRIORITY"] = value; }
        }

    /// <summary>
    /// Öncelik Sebebi (Sistem)
    /// </summary>
        public QueuePrioritySystemEnum? QueuePrioritySystem
        {
            get { return (QueuePrioritySystemEnum?)(int?)this["QUEUEPRIORITYSYSTEM"]; }
            set { this["QUEUEPRIORITYSYSTEM"] = value; }
        }

    /// <summary>
    /// Rütbeye Göre Sırala
    /// </summary>
        public bool? OrderByRank
        {
            get { return (bool?)this["ORDERBYRANK"]; }
            set { this["ORDERBYRANK"] = value; }
        }

        public QueuePriorityTemplateDef QueuePriorityTemplateDef
        {
            get { return (QueuePriorityTemplateDef)((ITTObject)this).GetParent("QUEUEPRIORITYTEMPLATEDEF"); }
            set { this["QUEUEPRIORITYTEMPLATEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public QueuePriorityDefinition QueuePriorityDefinition
        {
            get { return (QueuePriorityDefinition)((ITTObject)this).GetParent("QUEUEPRIORITYDEFINITION"); }
            set { this["QUEUEPRIORITYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected QueueTemplatePriorityGridObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected QueueTemplatePriorityGridObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected QueueTemplatePriorityGridObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected QueueTemplatePriorityGridObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected QueueTemplatePriorityGridObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "QUEUETEMPLATEPRIORITYGRIDOBJECT", dataRow) { }
        protected QueueTemplatePriorityGridObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "QUEUETEMPLATEPRIORITYGRIDOBJECT", dataRow, isImported) { }
        public QueueTemplatePriorityGridObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public QueueTemplatePriorityGridObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public QueueTemplatePriorityGridObject() : base() { }

    }
}