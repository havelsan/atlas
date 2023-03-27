
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend236")] 

    public  partial class ENABIZSend236 : BaseScheduledTask
    {
        public class ENABIZSend236List : TTObjectCollection<ENABIZSend236> { }
                    
        public class ChildENABIZSend236Collection : TTObject.TTChildObjectCollection<ENABIZSend236>
        {
            public ChildENABIZSend236Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend236Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend236(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend236(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend236(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend236(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend236(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND236", dataRow) { }
        protected ENABIZSend236(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND236", dataRow, isImported) { }
        public ENABIZSend236(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend236(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend236() : base() { }

    }
}