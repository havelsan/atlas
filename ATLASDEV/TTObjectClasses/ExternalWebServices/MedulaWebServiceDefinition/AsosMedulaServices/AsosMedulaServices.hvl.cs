
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="XXXXXXMedulaServices")] 

    public  partial class XXXXXXMedulaServices : TTObject
    {
        public class XXXXXXMedulaServicesList : TTObjectCollection<XXXXXXMedulaServices> { }
                    
        public class ChildXXXXXXMedulaServicesCollection : TTObject.TTChildObjectCollection<XXXXXXMedulaServices>
        {
            public ChildXXXXXXMedulaServicesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildXXXXXXMedulaServicesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected XXXXXXMedulaServices(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected XXXXXXMedulaServices(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected XXXXXXMedulaServices(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected XXXXXXMedulaServices(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected XXXXXXMedulaServices(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "XXXXXXMEDULASERVICES", dataRow) { }
        protected XXXXXXMedulaServices(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "XXXXXXMEDULASERVICES", dataRow, isImported) { }
        public XXXXXXMedulaServices(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public XXXXXXMedulaServices(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public XXXXXXMedulaServices() : base() { }

    }
}