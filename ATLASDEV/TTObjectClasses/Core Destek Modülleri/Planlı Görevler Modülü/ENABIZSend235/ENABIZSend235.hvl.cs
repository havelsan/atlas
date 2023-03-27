
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend235")] 

    public  partial class ENABIZSend235 : BaseScheduledTask
    {
        public class ENABIZSend235List : TTObjectCollection<ENABIZSend235> { }
                    
        public class ChildENABIZSend235Collection : TTObject.TTChildObjectCollection<ENABIZSend235>
        {
            public ChildENABIZSend235Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend235Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend235(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend235(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend235(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend235(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend235(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND235", dataRow) { }
        protected ENABIZSend235(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND235", dataRow, isImported) { }
        public ENABIZSend235(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend235(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend235() : base() { }

    }
}