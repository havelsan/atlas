
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend201")] 

    public  partial class ENABIZSend201 : BaseScheduledTask
    {
        public class ENABIZSend201List : TTObjectCollection<ENABIZSend201> { }
                    
        public class ChildENABIZSend201Collection : TTObject.TTChildObjectCollection<ENABIZSend201>
        {
            public ChildENABIZSend201Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend201Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend201(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend201(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend201(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend201(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend201(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND201", dataRow) { }
        protected ENABIZSend201(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND201", dataRow, isImported) { }
        public ENABIZSend201(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend201(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend201() : base() { }

    }
}