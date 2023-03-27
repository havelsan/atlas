
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend514")] 

    /// <summary>
    /// NABIZ - Sağlık Tesisi Bilgileri
    /// </summary>
    public  partial class ENABIZSend514 : BaseScheduledTask
    {
        public class ENABIZSend514List : TTObjectCollection<ENABIZSend514> { }
                    
        public class ChildENABIZSend514Collection : TTObject.TTChildObjectCollection<ENABIZSend514>
        {
            public ChildENABIZSend514Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend514Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend514(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend514(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend514(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend514(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend514(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND514", dataRow) { }
        protected ENABIZSend514(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND514", dataRow, isImported) { }
        public ENABIZSend514(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend514(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend514() : base() { }

    }
}