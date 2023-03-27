
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend102")] 

    public  partial class ENABIZSend102 : BaseScheduledTask
    {
        public class ENABIZSend102List : TTObjectCollection<ENABIZSend102> { }
                    
        public class ChildENABIZSend102Collection : TTObject.TTChildObjectCollection<ENABIZSend102>
        {
            public ChildENABIZSend102Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend102Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend102(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend102(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend102(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend102(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend102(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND102", dataRow) { }
        protected ENABIZSend102(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND102", dataRow, isImported) { }
        public ENABIZSend102(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend102(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend102() : base() { }

    }
}