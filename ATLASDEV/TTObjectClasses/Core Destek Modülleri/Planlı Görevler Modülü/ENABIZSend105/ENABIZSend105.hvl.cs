
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend105")] 

    public  partial class ENABIZSend105 : BaseScheduledTask
    {
        public class ENABIZSend105List : TTObjectCollection<ENABIZSend105> { }
                    
        public class ChildENABIZSend105Collection : TTObject.TTChildObjectCollection<ENABIZSend105>
        {
            public ChildENABIZSend105Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend105Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend105(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend105(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend105(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend105(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend105(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND105", dataRow) { }
        protected ENABIZSend105(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND105", dataRow, isImported) { }
        public ENABIZSend105(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend105(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend105() : base() { }

    }
}