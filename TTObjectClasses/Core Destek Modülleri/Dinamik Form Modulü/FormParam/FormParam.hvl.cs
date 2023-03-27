
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FormParam")] 

    public  partial class FormParam : TTObject
    {
        public class FormParamList : TTObjectCollection<FormParam> { }
                    
        public class ChildFormParamCollection : TTObject.TTChildObjectCollection<FormParam>
        {
            public ChildFormParamCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFormParamCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? IsFilter
        {
            get { return (bool?)this["ISFILTER"]; }
            set { this["ISFILTER"] = value; }
        }

        public bool? IsRequired
        {
            get { return (bool?)this["ISREQUIRED"]; }
            set { this["ISREQUIRED"] = value; }
        }

        public string ParamKey
        {
            get { return (string)this["PARAMKEY"]; }
            set { this["PARAMKEY"] = value; }
        }

        public DynamicForm DynamicFormID
        {
            get { return (DynamicForm)((ITTObject)this).GetParent("DYNAMICFORMID"); }
            set { this["DYNAMICFORMID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FormParam(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FormParam(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FormParam(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FormParam(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FormParam(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FORMPARAM", dataRow) { }
        protected FormParam(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FORMPARAM", dataRow, isImported) { }
        public FormParam(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FormParam(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FormParam() : base() { }

    }
}