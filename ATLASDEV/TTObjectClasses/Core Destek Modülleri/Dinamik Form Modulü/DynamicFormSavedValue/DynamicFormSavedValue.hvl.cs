
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicFormSavedValue")] 

    public  partial class DynamicFormSavedValue : TTObject
    {
        public class DynamicFormSavedValueList : TTObjectCollection<DynamicFormSavedValue> { }
                    
        public class ChildDynamicFormSavedValueCollection : TTObject.TTChildObjectCollection<DynamicFormSavedValue>
        {
            public ChildDynamicFormSavedValueCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicFormSavedValueCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public object Value
        {
            get { return (object)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        public Guid? RelatedObjectID
        {
            get { return (Guid?)this["RELATEDOBJECTID"]; }
            set { this["RELATEDOBJECTID"] = value; }
        }

        public FormField FormFieldID
        {
            get { return (FormField)((ITTObject)this).GetParent("FORMFIELDID"); }
            set { this["FORMFIELDID"] = (value==null ? null : (Guid?)value.ObjectID); }
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

        public DynamicFormRevisionField DynamicFormRevisionFieldID
        {
            get { return (DynamicFormRevisionField)((ITTObject)this).GetParent("DYNAMICFORMREVISIONFIELDID"); }
            set { this["DYNAMICFORMREVISIONFIELDID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DynamicFormSavedValue(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicFormSavedValue(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicFormSavedValue(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicFormSavedValue(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicFormSavedValue(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICFORMSAVEDVALUE", dataRow) { }
        protected DynamicFormSavedValue(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICFORMSAVEDVALUE", dataRow, isImported) { }
        public DynamicFormSavedValue(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicFormSavedValue(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicFormSavedValue() : base() { }

    }
}