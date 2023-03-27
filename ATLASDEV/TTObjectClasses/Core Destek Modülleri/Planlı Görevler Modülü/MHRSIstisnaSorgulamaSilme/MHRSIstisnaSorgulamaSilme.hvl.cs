
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MHRSIstisnaSorgulamaSilme")] 

    public  partial class MHRSIstisnaSorgulamaSilme : BaseScheduledTask
    {
        public class MHRSIstisnaSorgulamaSilmeList : TTObjectCollection<MHRSIstisnaSorgulamaSilme> { }
                    
        public class ChildMHRSIstisnaSorgulamaSilmeCollection : TTObject.TTChildObjectCollection<MHRSIstisnaSorgulamaSilme>
        {
            public ChildMHRSIstisnaSorgulamaSilmeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMHRSIstisnaSorgulamaSilmeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MHRSIstisnaSorgulamaSilme(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MHRSIstisnaSorgulamaSilme(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MHRSIstisnaSorgulamaSilme(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MHRSIstisnaSorgulamaSilme(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MHRSIstisnaSorgulamaSilme(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHRSISTISNASORGULAMASILME", dataRow) { }
        protected MHRSIstisnaSorgulamaSilme(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHRSISTISNASORGULAMASILME", dataRow, isImported) { }
        public MHRSIstisnaSorgulamaSilme(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MHRSIstisnaSorgulamaSilme(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MHRSIstisnaSorgulamaSilme() : base() { }

    }
}