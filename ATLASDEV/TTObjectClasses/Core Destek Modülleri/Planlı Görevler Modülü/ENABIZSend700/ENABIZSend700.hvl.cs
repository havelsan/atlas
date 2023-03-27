
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend700")] 

    public  partial class ENABIZSend700 : BaseScheduledTask
    {
        public class ENABIZSend700List : TTObjectCollection<ENABIZSend700> { }
                    
        public class ChildENABIZSend700Collection : TTObject.TTChildObjectCollection<ENABIZSend700>
        {
            public ChildENABIZSend700Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend700Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend700(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend700(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend700(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend700(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend700(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND700", dataRow) { }
        protected ENABIZSend700(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND700", dataRow, isImported) { }
        public ENABIZSend700(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend700(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend700() : base() { }

    }
}