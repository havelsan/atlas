
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicFormRevisionField")] 

    public  partial class DynamicFormRevisionField : TTObject
    {
        public class DynamicFormRevisionFieldList : TTObjectCollection<DynamicFormRevisionField> { }
                    
        public class ChildDynamicFormRevisionFieldCollection : TTObject.TTChildObjectCollection<DynamicFormRevisionField>
        {
            public ChildDynamicFormRevisionFieldCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicFormRevisionFieldCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public FormField FormFieldID
        {
            get { return (FormField)((ITTObject)this).GetParent("FORMFIELDID"); }
            set { this["FORMFIELDID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DynamicFormRevision DynamicFormRevisionID
        {
            get { return (DynamicFormRevision)((ITTObject)this).GetParent("DYNAMICFORMREVISIONID"); }
            set { this["DYNAMICFORMREVISIONID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DynamicFormRevisionField(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicFormRevisionField(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicFormRevisionField(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicFormRevisionField(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicFormRevisionField(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICFORMREVISIONFIELD", dataRow) { }
        protected DynamicFormRevisionField(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICFORMREVISIONFIELD", dataRow, isImported) { }
        public DynamicFormRevisionField(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicFormRevisionField(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicFormRevisionField() : base() { }

    }
}