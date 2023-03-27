
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend247")] 

    public  partial class ENABIZSend247 : BaseScheduledTask
    {
        public class ENABIZSend247List : TTObjectCollection<ENABIZSend247> { }
                    
        public class ChildENABIZSend247Collection : TTObject.TTChildObjectCollection<ENABIZSend247>
        {
            public ChildENABIZSend247Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend247Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend247(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend247(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend247(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend247(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend247(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND247", dataRow) { }
        protected ENABIZSend247(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND247", dataRow, isImported) { }
        public ENABIZSend247(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend247(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend247() : base() { }

    }
}