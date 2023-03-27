
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MHRSYonetim")] 

    public  partial class MHRSYonetim : TTObject
    {
        public class MHRSYonetimList : TTObjectCollection<MHRSYonetim> { }
                    
        public class ChildMHRSYonetimCollection : TTObject.TTChildObjectCollection<MHRSYonetim>
        {
            public ChildMHRSYonetimCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMHRSYonetimCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MHRSYonetim(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MHRSYonetim(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MHRSYonetim(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MHRSYonetim(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MHRSYonetim(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHRSYONETIM", dataRow) { }
        protected MHRSYonetim(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHRSYONETIM", dataRow, isImported) { }
        public MHRSYonetim(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MHRSYonetim(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MHRSYonetim() : base() { }

    }
}