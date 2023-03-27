
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicForm")] 

    public  partial class DynamicForm : TTObject
    {
        public class DynamicFormList : TTObjectCollection<DynamicForm> { }
                    
        public class ChildDynamicFormCollection : TTObject.TTChildObjectCollection<DynamicForm>
        {
            public ChildDynamicFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public bool? IsEnable
        {
            get { return (bool?)this["ISENABLE"]; }
            set { this["ISENABLE"] = value; }
        }

        public string ClassName
        {
            get { return (string)this["CLASSNAME"]; }
            set { this["CLASSNAME"] = value; }
        }

        public string CheckClassName
        {
            get { return (string)this["CHECKCLASSNAME"]; }
            set { this["CHECKCLASSNAME"] = value; }
        }

        protected DynamicForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICFORM", dataRow) { }
        protected DynamicForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICFORM", dataRow, isImported) { }
        public DynamicForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicForm() : base() { }

    }
}