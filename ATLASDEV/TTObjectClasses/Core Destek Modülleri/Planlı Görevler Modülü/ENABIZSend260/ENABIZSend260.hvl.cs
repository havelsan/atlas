
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend260")] 

    public  partial class ENABIZSend260 : BaseScheduledTask
    {
        public class ENABIZSend260List : TTObjectCollection<ENABIZSend260> { }
                    
        public class ChildENABIZSend260Collection : TTObject.TTChildObjectCollection<ENABIZSend260>
        {
            public ChildENABIZSend260Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend260Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend260(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend260(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend260(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend260(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend260(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND260", dataRow) { }
        protected ENABIZSend260(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND260", dataRow, isImported) { }
        public ENABIZSend260(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend260(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend260() : base() { }

    }
}