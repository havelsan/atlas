
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENabizSend262")] 

    public  partial class ENabizSend262 : BaseScheduledTask
    {
        public class ENabizSend262List : TTObjectCollection<ENabizSend262> { }
                    
        public class ChildENabizSend262Collection : TTObject.TTChildObjectCollection<ENabizSend262>
        {
            public ChildENabizSend262Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENabizSend262Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENabizSend262(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENabizSend262(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENabizSend262(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENabizSend262(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENabizSend262(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND262", dataRow) { }
        protected ENabizSend262(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND262", dataRow, isImported) { }
        public ENabizSend262(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENabizSend262(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENabizSend262() : base() { }

    }
}