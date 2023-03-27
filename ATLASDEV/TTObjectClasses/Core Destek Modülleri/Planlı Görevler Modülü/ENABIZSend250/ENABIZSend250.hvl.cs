
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend250")] 

    /// <summary>
    /// NABIZ - Verem 
    /// </summary>
    public  partial class ENABIZSend250 : BaseScheduledTask
    {
        public class ENABIZSend250List : TTObjectCollection<ENABIZSend250> { }
                    
        public class ChildENABIZSend250Collection : TTObject.TTChildObjectCollection<ENABIZSend250>
        {
            public ChildENABIZSend250Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend250Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend250(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend250(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend250(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend250(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend250(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND250", dataRow) { }
        protected ENABIZSend250(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND250", dataRow, isImported) { }
        public ENABIZSend250(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend250(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend250() : base() { }

    }
}