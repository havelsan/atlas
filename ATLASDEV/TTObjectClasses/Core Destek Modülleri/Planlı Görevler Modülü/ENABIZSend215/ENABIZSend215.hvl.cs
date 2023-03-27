
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend215")] 

    public  partial class ENABIZSend215 : BaseScheduledTask
    {
        public class ENABIZSend215List : TTObjectCollection<ENABIZSend215> { }
                    
        public class ChildENABIZSend215Collection : TTObject.TTChildObjectCollection<ENABIZSend215>
        {
            public ChildENABIZSend215Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend215Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend215(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend215(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend215(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend215(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend215(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND215", dataRow) { }
        protected ENABIZSend215(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND215", dataRow, isImported) { }
        public ENABIZSend215(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend215(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend215() : base() { }

    }
}