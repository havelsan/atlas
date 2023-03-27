
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend248")] 

    public  partial class ENABIZSend248 : BaseScheduledTask
    {
        public class ENABIZSend248List : TTObjectCollection<ENABIZSend248> { }
                    
        public class ChildENABIZSend248Collection : TTObject.TTChildObjectCollection<ENABIZSend248>
        {
            public ChildENABIZSend248Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend248Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend248(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend248(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend248(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend248(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend248(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND248", dataRow) { }
        protected ENABIZSend248(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND248", dataRow, isImported) { }
        public ENABIZSend248(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend248(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend248() : base() { }

    }
}