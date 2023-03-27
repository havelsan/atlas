
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend108")] 

    public  partial class ENABIZSend108 : BaseScheduledTask
    {
        public class ENABIZSend108List : TTObjectCollection<ENABIZSend108> { }
                    
        public class ChildENABIZSend108Collection : TTObject.TTChildObjectCollection<ENABIZSend108>
        {
            public ChildENABIZSend108Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend108Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend108(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend108(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend108(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend108(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend108(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND108", dataRow) { }
        protected ENABIZSend108(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND108", dataRow, isImported) { }
        public ENABIZSend108(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend108(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend108() : base() { }

    }
}