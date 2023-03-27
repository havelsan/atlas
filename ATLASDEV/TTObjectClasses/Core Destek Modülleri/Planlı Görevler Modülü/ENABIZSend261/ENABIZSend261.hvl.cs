
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend261")] 

    public  partial class ENABIZSend261 : BaseScheduledTask
    {
        public class ENABIZSend261List : TTObjectCollection<ENABIZSend261> { }
                    
        public class ChildENABIZSend261Collection : TTObject.TTChildObjectCollection<ENABIZSend261>
        {
            public ChildENABIZSend261Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend261Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend261(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend261(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend261(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend261(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend261(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND261", dataRow) { }
        protected ENABIZSend261(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND261", dataRow, isImported) { }
        public ENABIZSend261(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend261(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend261() : base() { }

    }
}