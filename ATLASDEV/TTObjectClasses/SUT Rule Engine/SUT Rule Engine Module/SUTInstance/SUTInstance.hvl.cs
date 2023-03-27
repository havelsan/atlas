
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SUTInstance")] 

    public  partial class SUTInstance : TTObject, ISUTInstance
    {
        public class SUTInstanceList : TTObjectCollection<SUTInstance> { }
                    
        public class ChildSUTInstanceCollection : TTObject.TTChildObjectCollection<SUTInstance>
        {
            public ChildSUTInstanceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSUTInstanceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SUTInstance(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SUTInstance(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SUTInstance(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SUTInstance(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SUTInstance(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUTINSTANCE", dataRow) { }
        protected SUTInstance(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUTINSTANCE", dataRow, isImported) { }
        public SUTInstance(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SUTInstance(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SUTInstance() : base() { }

    }
}