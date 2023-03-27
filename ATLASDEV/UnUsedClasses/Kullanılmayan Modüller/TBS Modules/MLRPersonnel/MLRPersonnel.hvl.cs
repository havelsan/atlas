
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRPersonnel")] 

    /// <summary>
    /// Personel
    /// </summary>
    public  partial class MLRPersonnel : TTDefinitionSet
    {
        public class MLRPersonnelList : TTObjectCollection<MLRPersonnel> { }
                    
        public class ChildMLRPersonnelCollection : TTObject.TTChildObjectCollection<MLRPersonnel>
        {
            public ChildMLRPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MLRPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRPERSONNEL", dataRow) { }
        protected MLRPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRPERSONNEL", dataRow, isImported) { }
        public MLRPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRPersonnel() : base() { }

    }
}