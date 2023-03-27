
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENABIZSend502")] 

    /// <summary>
    /// NABIZ - Yoğun Bakım İzlem Veri Seti
    /// </summary>
    public  partial class ENABIZSend502 : BaseScheduledTask
    {
        public class ENABIZSend502List : TTObjectCollection<ENABIZSend502> { }
                    
        public class ChildENABIZSend502Collection : TTObject.TTChildObjectCollection<ENABIZSend502>
        {
            public ChildENABIZSend502Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENABIZSend502Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ENABIZSend502(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENABIZSend502(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENABIZSend502(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENABIZSend502(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENABIZSend502(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZSEND502", dataRow) { }
        protected ENABIZSend502(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZSEND502", dataRow, isImported) { }
        public ENABIZSend502(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENABIZSend502(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENABIZSend502() : base() { }

    }
}