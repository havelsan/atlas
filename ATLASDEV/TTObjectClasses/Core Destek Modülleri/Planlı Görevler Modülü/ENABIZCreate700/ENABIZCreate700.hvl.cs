
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZCreate700")] 

    public  partial class ENABIZCreate700 : BaseScheduledTask
    {
        public class ENABIZCreate700List : TTObjectCollection<ENABIZCreate700> { }
                    
        public class ChildENABIZCreate700Collection : TTObject.TTChildObjectCollection<ENABIZCreate700>
        {
            public ChildENABIZCreate700Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZCreate700Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZCreate700(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZCreate700(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZCreate700(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZCreate700(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZCreate700(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZCREATE700", dataRow) { }
        protected ENABIZCreate700(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZCREATE700", dataRow, isImported) { }
        public ENABIZCreate700(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZCreate700(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZCreate700() : base() { }

    }
}