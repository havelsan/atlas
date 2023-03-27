
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend411")] 

    public  partial class ENABIZSend411 : BaseScheduledTask
    {
        public class ENABIZSend411List : TTObjectCollection<ENABIZSend411> { }
                    
        public class ChildENABIZSend411Collection : TTObject.TTChildObjectCollection<ENABIZSend411>
        {
            public ChildENABIZSend411Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend411Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend411(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend411(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend411(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend411(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend411(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND411", dataRow) { }
        protected ENABIZSend411(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND411", dataRow, isImported) { }
        public ENABIZSend411(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend411(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend411() : base() { }

    }
}