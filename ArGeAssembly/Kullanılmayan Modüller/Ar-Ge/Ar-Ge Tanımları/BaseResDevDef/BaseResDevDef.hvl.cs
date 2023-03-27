
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseResDevDef")] 

    public  abstract  partial class BaseResDevDef : TTDefinitionSet
    {
        public class BaseResDevDefList : TTObjectCollection<BaseResDevDef> { }
                    
        public class ChildBaseResDevDefCollection : TTObject.TTChildObjectCollection<BaseResDevDef>
        {
            public ChildBaseResDevDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseResDevDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        protected BaseResDevDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseResDevDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseResDevDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseResDevDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseResDevDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASERESDEVDEF", dataRow) { }
        protected BaseResDevDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASERESDEVDEF", dataRow, isImported) { }
        public BaseResDevDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseResDevDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseResDevDef() : base() { }

    }
}