
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend240")] 

    public  partial class ENABIZSend240 : BaseScheduledTask
    {
        public class ENABIZSend240List : TTObjectCollection<ENABIZSend240> { }
                    
        public class ChildENABIZSend240Collection : TTObject.TTChildObjectCollection<ENABIZSend240>
        {
            public ChildENABIZSend240Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend240Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend240(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend240(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend240(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend240(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend240(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND240", dataRow) { }
        protected ENABIZSend240(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND240", dataRow, isImported) { }
        public ENABIZSend240(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend240(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend240() : base() { }

    }
}