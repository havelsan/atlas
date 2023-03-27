
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend301")] 

    public  partial class ENABIZSend301 : BaseScheduledTask
    {
        public class ENABIZSend301List : TTObjectCollection<ENABIZSend301> { }
                    
        public class ChildENABIZSend301Collection : TTObject.TTChildObjectCollection<ENABIZSend301>
        {
            public ChildENABIZSend301Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend301Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend301(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend301(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend301(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend301(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend301(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND301", dataRow) { }
        protected ENABIZSend301(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND301", dataRow, isImported) { }
        public ENABIZSend301(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend301(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend301() : base() { }

    }
}