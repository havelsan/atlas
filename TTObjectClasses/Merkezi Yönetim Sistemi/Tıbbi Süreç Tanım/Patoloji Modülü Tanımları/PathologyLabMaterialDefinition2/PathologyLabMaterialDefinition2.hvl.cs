
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyLabMaterialDefinition2")] 

    public  partial class PathologyLabMaterialDefinition2 : Material
    {
        public class PathologyLabMaterialDefinition2List : TTObjectCollection<PathologyLabMaterialDefinition2> { }
                    
        public class ChildPathologyLabMaterialDefinition2Collection : TTObject.TTChildObjectCollection<PathologyLabMaterialDefinition2>
        {
            public ChildPathologyLabMaterialDefinition2Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyLabMaterialDefinition2Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected PathologyLabMaterialDefinition2(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyLabMaterialDefinition2(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyLabMaterialDefinition2(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyLabMaterialDefinition2(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyLabMaterialDefinition2(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYLABMATERIALDEFINITION2", dataRow) { }
        protected PathologyLabMaterialDefinition2(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYLABMATERIALDEFINITION2", dataRow, isImported) { }
        public PathologyLabMaterialDefinition2(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyLabMaterialDefinition2(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyLabMaterialDefinition2() : base() { }

    }
}