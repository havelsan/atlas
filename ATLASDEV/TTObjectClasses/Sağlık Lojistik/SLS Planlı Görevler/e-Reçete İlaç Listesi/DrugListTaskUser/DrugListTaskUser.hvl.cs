
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugListTaskUser")] 

    public  partial class DrugListTaskUser : TTObject
    {
        public class DrugListTaskUserList : TTObjectCollection<DrugListTaskUser> { }
                    
        public class ChildDrugListTaskUserCollection : TTObject.TTChildObjectCollection<DrugListTaskUser>
        {
            public ChildDrugListTaskUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugListTaskUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DrugListTaskUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugListTaskUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugListTaskUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugListTaskUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugListTaskUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGLISTTASKUSER", dataRow) { }
        protected DrugListTaskUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGLISTTASKUSER", dataRow, isImported) { }
        public DrugListTaskUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugListTaskUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugListTaskUser() : base() { }

    }
}