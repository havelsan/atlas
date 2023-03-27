
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend214")] 

    public  partial class ENABIZSend214 : BaseScheduledTask
    {
        public class ENABIZSend214List : TTObjectCollection<ENABIZSend214> { }
                    
        public class ChildENABIZSend214Collection : TTObject.TTChildObjectCollection<ENABIZSend214>
        {
            public ChildENABIZSend214Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend214Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend214(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend214(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend214(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend214(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend214(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND214", dataRow) { }
        protected ENABIZSend214(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND214", dataRow, isImported) { }
        public ENABIZSend214(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend214(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend214() : base() { }

    }
}