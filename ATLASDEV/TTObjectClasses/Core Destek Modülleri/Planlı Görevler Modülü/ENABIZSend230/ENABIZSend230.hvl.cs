
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend230")] 

    public  partial class ENABIZSend230 : BaseScheduledTask
    {
        public class ENABIZSend230List : TTObjectCollection<ENABIZSend230> { }
                    
        public class ChildENABIZSend230Collection : TTObject.TTChildObjectCollection<ENABIZSend230>
        {
            public ChildENABIZSend230Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend230Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend230(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend230(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend230(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend230(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend230(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND230", dataRow) { }
        protected ENABIZSend230(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND230", dataRow, isImported) { }
        public ENABIZSend230(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend230(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend230() : base() { }

    }
}