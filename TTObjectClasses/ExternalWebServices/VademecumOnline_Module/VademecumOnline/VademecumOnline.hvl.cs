
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VademecumOnline")] 

    public  partial class VademecumOnline : TTObject
    {
        public class VademecumOnlineList : TTObjectCollection<VademecumOnline> { }
                    
        public class ChildVademecumOnlineCollection : TTObject.TTChildObjectCollection<VademecumOnline>
        {
            public ChildVademecumOnlineCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVademecumOnlineCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected VademecumOnline(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VademecumOnline(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VademecumOnline(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VademecumOnline(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VademecumOnline(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VADEMECUMONLINE", dataRow) { }
        protected VademecumOnline(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VADEMECUMONLINE", dataRow, isImported) { }
        public VademecumOnline(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VademecumOnline(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VademecumOnline() : base() { }

    }
}