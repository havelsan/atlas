
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MHRSRandevuSorgulama")] 

    public  partial class MHRSRandevuSorgulama : BaseScheduledTask
    {
        public class MHRSRandevuSorgulamaList : TTObjectCollection<MHRSRandevuSorgulama> { }
                    
        public class ChildMHRSRandevuSorgulamaCollection : TTObject.TTChildObjectCollection<MHRSRandevuSorgulama>
        {
            public ChildMHRSRandevuSorgulamaCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMHRSRandevuSorgulamaCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MHRSRandevuSorgulama(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MHRSRandevuSorgulama(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MHRSRandevuSorgulama(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MHRSRandevuSorgulama(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MHRSRandevuSorgulama(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHRSRANDEVUSORGULAMA", dataRow) { }
        protected MHRSRandevuSorgulama(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHRSRANDEVUSORGULAMA", dataRow, isImported) { }
        public MHRSRandevuSorgulama(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MHRSRandevuSorgulama(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MHRSRandevuSorgulama() : base() { }

    }
}