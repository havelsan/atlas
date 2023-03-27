
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend229")] 

    public  partial class ENABIZSend229 : BaseScheduledTask
    {
        public class ENABIZSend229List : TTObjectCollection<ENABIZSend229> { }
                    
        public class ChildENABIZSend229Collection : TTObject.TTChildObjectCollection<ENABIZSend229>
        {
            public ChildENABIZSend229Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend229Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend229(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend229(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend229(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend229(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend229(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND229", dataRow) { }
        protected ENABIZSend229(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND229", dataRow, isImported) { }
        public ENABIZSend229(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend229(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend229() : base() { }

    }
}