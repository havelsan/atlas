
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend104")] 

    public  partial class ENABIZSend104 : BaseScheduledTask
    {
        public class ENABIZSend104List : TTObjectCollection<ENABIZSend104> { }
                    
        public class ChildENABIZSend104Collection : TTObject.TTChildObjectCollection<ENABIZSend104>
        {
            public ChildENABIZSend104Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend104Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend104(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend104(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend104(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend104(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend104(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND104", dataRow) { }
        protected ENABIZSend104(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND104", dataRow, isImported) { }
        public ENABIZSend104(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend104(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend104() : base() { }

    }
}