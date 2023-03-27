
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend226")] 

    public  partial class ENABIZSend226 : BaseScheduledTask
    {
        public class ENABIZSend226List : TTObjectCollection<ENABIZSend226> { }
                    
        public class ChildENABIZSend226Collection : TTObject.TTChildObjectCollection<ENABIZSend226>
        {
            public ChildENABIZSend226Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend226Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend226(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend226(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend226(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend226(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend226(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND226", dataRow) { }
        protected ENABIZSend226(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND226", dataRow, isImported) { }
        public ENABIZSend226(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend226(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend226() : base() { }

    }
}