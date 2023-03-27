
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend239")] 

    public  partial class ENABIZSend239 : BaseScheduledTask
    {
        public class ENABIZSend239List : TTObjectCollection<ENABIZSend239> { }
                    
        public class ChildENABIZSend239Collection : TTObject.TTChildObjectCollection<ENABIZSend239>
        {
            public ChildENABIZSend239Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend239Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend239(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend239(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend239(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend239(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend239(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND239", dataRow) { }
        protected ENABIZSend239(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND239", dataRow, isImported) { }
        public ENABIZSend239(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend239(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend239() : base() { }

    }
}