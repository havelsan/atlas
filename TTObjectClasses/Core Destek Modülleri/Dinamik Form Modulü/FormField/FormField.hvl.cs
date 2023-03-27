
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FormField")] 

    public  partial class FormField : TTObject
    {
        public class FormFieldList : TTObjectCollection<FormField> { }
                    
        public class ChildFormFieldCollection : TTObject.TTChildObjectCollection<FormField>
        {
            public ChildFormFieldCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFormFieldCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Label
        {
            get { return (string)this["LABEL"]; }
            set { this["LABEL"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public DynamicForm DynamicFormID
        {
            get { return (DynamicForm)((ITTObject)this).GetParent("DYNAMICFORMID"); }
            set { this["DYNAMICFORMID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DynamicDataSource DynamicDataSourceID
        {
            get { return (DynamicDataSource)((ITTObject)this).GetParent("DYNAMICDATASOURCEID"); }
            set { this["DYNAMICDATASOURCEID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FormField(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FormField(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FormField(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FormField(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FormField(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FORMFIELD", dataRow) { }
        protected FormField(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FORMFIELD", dataRow, isImported) { }
        public FormField(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FormField(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FormField() : base() { }

    }
}