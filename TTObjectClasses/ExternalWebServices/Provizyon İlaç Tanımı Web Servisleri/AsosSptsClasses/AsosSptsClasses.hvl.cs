
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="XXXXXXSptsClasses")] 

    public  partial class XXXXXXSptsClasses : TTObject
    {
        public class XXXXXXSptsClassesList : TTObjectCollection<XXXXXXSptsClasses> { }
                    
        public class ChildXXXXXXSptsClassesCollection : TTObject.TTChildObjectCollection<XXXXXXSptsClasses>
        {
            public ChildXXXXXXSptsClassesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildXXXXXXSptsClassesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected XXXXXXSptsClasses(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected XXXXXXSptsClasses(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected XXXXXXSptsClasses(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected XXXXXXSptsClasses(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected XXXXXXSptsClasses(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "XXXXXXSPTSCLASSES", dataRow) { }
        protected XXXXXXSptsClasses(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "XXXXXXSPTSCLASSES", dataRow, isImported) { }
        protected XXXXXXSptsClasses(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public XXXXXXSptsClasses(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public XXXXXXSptsClasses() : base() { }

    }
}