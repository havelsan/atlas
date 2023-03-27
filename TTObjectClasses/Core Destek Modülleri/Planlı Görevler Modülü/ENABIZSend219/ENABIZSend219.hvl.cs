
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend219")] 

    public  partial class ENABIZSend219 : BaseScheduledTask
    {
        public class ENABIZSend219List : TTObjectCollection<ENABIZSend219> { }
                    
        public class ChildENABIZSend219Collection : TTObject.TTChildObjectCollection<ENABIZSend219>
        {
            public ChildENABIZSend219Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend219Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend219(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend219(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend219(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend219(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend219(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND219", dataRow) { }
        protected ENABIZSend219(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND219", dataRow, isImported) { }
        public ENABIZSend219(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend219(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend219() : base() { }

    }
}