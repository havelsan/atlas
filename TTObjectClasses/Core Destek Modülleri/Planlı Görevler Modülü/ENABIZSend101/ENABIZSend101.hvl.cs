
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend101")] 

    public  partial class ENABIZSend101 : BaseScheduledTask
    {
        public class ENABIZSend101List : TTObjectCollection<ENABIZSend101> { }
                    
        public class ChildENABIZSend101Collection : TTObject.TTChildObjectCollection<ENABIZSend101>
        {
            public ChildENABIZSend101Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend101Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend101(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend101(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend101(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend101(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend101(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND101", dataRow) { }
        protected ENABIZSend101(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND101", dataRow, isImported) { }
        public ENABIZSend101(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend101(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend101() : base() { }

    }
}