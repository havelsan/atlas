
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend237")] 

    public  partial class ENABIZSend237 : BaseScheduledTask
    {
        public class ENABIZSend237List : TTObjectCollection<ENABIZSend237> { }
                    
        public class ChildENABIZSend237Collection : TTObject.TTChildObjectCollection<ENABIZSend237>
        {
            public ChildENABIZSend237Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend237Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend237(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend237(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend237(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend237(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend237(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND237", dataRow) { }
        protected ENABIZSend237(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND237", dataRow, isImported) { }
        public ENABIZSend237(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend237(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend237() : base() { }

    }
}