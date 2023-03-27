
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend106")] 

    public  partial class ENABIZSend106 : BaseScheduledTask
    {
        public class ENABIZSend106List : TTObjectCollection<ENABIZSend106> { }
                    
        public class ChildENABIZSend106Collection : TTObject.TTChildObjectCollection<ENABIZSend106>
        {
            public ChildENABIZSend106Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend106Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend106(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend106(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend106(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend106(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend106(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND106", dataRow) { }
        protected ENABIZSend106(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND106", dataRow, isImported) { }
        public ENABIZSend106(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend106(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend106() : base() { }

    }
}