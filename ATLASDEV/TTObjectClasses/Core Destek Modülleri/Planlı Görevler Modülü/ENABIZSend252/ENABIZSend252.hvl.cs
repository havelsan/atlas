
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend252")] 

    public  partial class ENABIZSend252 : BaseScheduledTask
    {
        public class ENABIZSend252List : TTObjectCollection<ENABIZSend252> { }
                    
        public class ChildENABIZSend252Collection : TTObject.TTChildObjectCollection<ENABIZSend252>
        {
            public ChildENABIZSend252Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend252Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend252(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend252(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend252(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend252(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend252(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND252", dataRow) { }
        protected ENABIZSend252(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND252", dataRow, isImported) { }
        public ENABIZSend252(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend252(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend252() : base() { }

    }
}