
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend409")] 

    public  partial class ENABIZSend409 : BaseScheduledTask
    {
        public class ENABIZSend409List : TTObjectCollection<ENABIZSend409> { }
                    
        public class ChildENABIZSend409Collection : TTObject.TTChildObjectCollection<ENABIZSend409>
        {
            public ChildENABIZSend409Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend409Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend409(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend409(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend409(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend409(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend409(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND409", dataRow) { }
        protected ENABIZSend409(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND409", dataRow, isImported) { }
        public ENABIZSend409(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend409(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend409() : base() { }

    }
}