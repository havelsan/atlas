
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Common")] 

    public  abstract  partial class Common : TTObject
    {
        public class CommonList : TTObjectCollection<Common> { }
                    
        public class ChildCommonCollection : TTObject.TTChildObjectCollection<Common>
        {
            public ChildCommonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected Common(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Common(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Common(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Common(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Common(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMON", dataRow) { }
        protected Common(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMON", dataRow, isImported) { }
        public Common(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Common(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Common() : base() { }

    }
}