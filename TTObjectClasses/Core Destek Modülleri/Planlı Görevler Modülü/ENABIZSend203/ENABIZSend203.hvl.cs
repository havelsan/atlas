
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend203")] 

    public  partial class ENABIZSend203 : BaseScheduledTask
    {
        public class ENABIZSend203List : TTObjectCollection<ENABIZSend203> { }
                    
        public class ChildENABIZSend203Collection : TTObject.TTChildObjectCollection<ENABIZSend203>
        {
            public ChildENABIZSend203Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend203Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend203(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend203(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend203(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend203(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend203(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND203", dataRow) { }
        protected ENABIZSend203(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND203", dataRow, isImported) { }
        public ENABIZSend203(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend203(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend203() : base() { }

    }
}