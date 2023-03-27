
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENabizSend302")] 

    public  partial class ENabizSend302 : BaseScheduledTask
    {
        public class ENabizSend302List : TTObjectCollection<ENabizSend302> { }
                    
        public class ChildENabizSend302Collection : TTObject.TTChildObjectCollection<ENabizSend302>
        {
            public ChildENabizSend302Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENabizSend302Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENabizSend302(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENabizSend302(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENabizSend302(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENabizSend302(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENabizSend302(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND302", dataRow) { }
        protected ENabizSend302(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND302", dataRow, isImported) { }
        public ENabizSend302(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENabizSend302(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENabizSend302() : base() { }

    }
}