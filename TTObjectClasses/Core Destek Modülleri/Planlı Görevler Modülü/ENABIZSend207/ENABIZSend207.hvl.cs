
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend207")] 

    public  partial class ENABIZSend207 : BaseScheduledTask
    {
        public class ENABIZSend207List : TTObjectCollection<ENABIZSend207> { }
                    
        public class ChildENABIZSend207Collection : TTObject.TTChildObjectCollection<ENABIZSend207>
        {
            public ChildENABIZSend207Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend207Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend207(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend207(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend207(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend207(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend207(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND207", dataRow) { }
        protected ENABIZSend207(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND207", dataRow, isImported) { }
        public ENABIZSend207(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend207(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend207() : base() { }

    }
}