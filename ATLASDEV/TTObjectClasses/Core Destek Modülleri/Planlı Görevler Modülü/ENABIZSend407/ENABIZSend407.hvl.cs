
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend407")] 

    public  partial class ENABIZSend407 : BaseScheduledTask
    {
        public class ENABIZSend407List : TTObjectCollection<ENABIZSend407> { }
                    
        public class ChildENABIZSend407Collection : TTObject.TTChildObjectCollection<ENABIZSend407>
        {
            public ChildENABIZSend407Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend407Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend407(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend407(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend407(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend407(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend407(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND407", dataRow) { }
        protected ENABIZSend407(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND407", dataRow, isImported) { }
        public ENABIZSend407(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend407(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend407() : base() { }

    }
}