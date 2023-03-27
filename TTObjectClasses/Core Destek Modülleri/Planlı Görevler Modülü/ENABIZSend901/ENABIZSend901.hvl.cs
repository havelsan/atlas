
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend901")] 

    public  partial class ENABIZSend901 : BaseScheduledTask
    {
        public class ENABIZSend901List : TTObjectCollection<ENABIZSend901> { }
                    
        public class ChildENABIZSend901Collection : TTObject.TTChildObjectCollection<ENABIZSend901>
        {
            public ChildENABIZSend901Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend901Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend901(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend901(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend901(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend901(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend901(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND901", dataRow) { }
        protected ENABIZSend901(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND901", dataRow, isImported) { }
        public ENABIZSend901(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend901(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend901() : base() { }

    }
}