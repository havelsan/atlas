
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicFormSavedJSON")] 

    public  partial class DynamicFormSavedJSON : TTObject
    {
        public class DynamicFormSavedJSONList : TTObjectCollection<DynamicFormSavedJSON> { }
                    
        public class ChildDynamicFormSavedJSONCollection : TTObject.TTChildObjectCollection<DynamicFormSavedJSON>
        {
            public ChildDynamicFormSavedJSONCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicFormSavedJSONCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public object Value
        {
            get { return (object)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        public DynamicForm DynamicFormID
        {
            get { return (DynamicForm)((ITTObject)this).GetParent("DYNAMICFORMID"); }
            set { this["DYNAMICFORMID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DynamicFormRevision DynamicFormRevisionID
        {
            get { return (DynamicFormRevision)((ITTObject)this).GetParent("DYNAMICFORMREVISIONID"); }
            set { this["DYNAMICFORMREVISIONID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DynamicFormSubmission DynamicFormSubmission
        {
            get { return (DynamicFormSubmission)((ITTObject)this).GetParent("DYNAMICFORMSUBMISSION"); }
            set { this["DYNAMICFORMSUBMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DynamicFormSavedJSON(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicFormSavedJSON(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicFormSavedJSON(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicFormSavedJSON(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicFormSavedJSON(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICFORMSAVEDJSON", dataRow) { }
        protected DynamicFormSavedJSON(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICFORMSAVEDJSON", dataRow, isImported) { }
        public DynamicFormSavedJSON(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicFormSavedJSON(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicFormSavedJSON() : base() { }

    }
}