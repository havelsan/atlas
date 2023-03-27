
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend103")] 

    public  partial class ENABIZSend103 : BaseScheduledTask
    {
        public class ENABIZSend103List : TTObjectCollection<ENABIZSend103> { }
                    
        public class ChildENABIZSend103Collection : TTObject.TTChildObjectCollection<ENABIZSend103>
        {
            public ChildENABIZSend103Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend103Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend103(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend103(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend103(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend103(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend103(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND103", dataRow) { }
        protected ENABIZSend103(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND103", dataRow, isImported) { }
        public ENABIZSend103(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend103(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend103() : base() { }

    }
}