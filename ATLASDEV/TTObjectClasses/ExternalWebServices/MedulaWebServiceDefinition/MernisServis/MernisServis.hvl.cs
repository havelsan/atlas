
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MernisServis")] 

    public  partial class MernisServis : TTObject
    {
        public class MernisServisList : TTObjectCollection<MernisServis> { }
                    
        public class ChildMernisServisCollection : TTObject.TTChildObjectCollection<MernisServis>
        {
            public ChildMernisServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMernisServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MernisServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MernisServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MernisServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MernisServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MernisServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MERNISSERVIS", dataRow) { }
        protected MernisServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MERNISSERVIS", dataRow, isImported) { }
        public MernisServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MernisServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MernisServis() : base() { }

    }
}