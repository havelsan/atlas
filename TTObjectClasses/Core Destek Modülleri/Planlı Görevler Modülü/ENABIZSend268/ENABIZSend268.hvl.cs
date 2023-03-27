
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend268")] 

    public  partial class ENABIZSend268 : BaseScheduledTask
    {
        public class ENABIZSend268List : TTObjectCollection<ENABIZSend268> { }
                    
        public class ChildENABIZSend268Collection : TTObject.TTChildObjectCollection<ENABIZSend268>
        {
            public ChildENABIZSend268Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend268Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend268(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend268(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend268(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend268(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend268(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND268", dataRow) { }
        protected ENABIZSend268(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND268", dataRow, isImported) { }
        public ENABIZSend268(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend268(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend268() : base() { }

    }
}