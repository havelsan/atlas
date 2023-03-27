
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyGridMaterialDefinition")] 

    public  partial class PathologyGridMaterialDefinition : TTDefinitionSet
    {
        public class PathologyGridMaterialDefinitionList : TTObjectCollection<PathologyGridMaterialDefinition> { }
                    
        public class ChildPathologyGridMaterialDefinitionCollection : TTObject.TTChildObjectCollection<PathologyGridMaterialDefinition>
        {
            public ChildPathologyGridMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyGridMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Patoloji Test Tanım İlişkisi
    /// </summary>
        public PathologyTestDefinition PathologyTest
        {
            get { return (PathologyTestDefinition)((ITTObject)this).GetParent("PATHOLOGYTEST"); }
            set { this["PATHOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme İlişkisi
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PathologyGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyGridMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYGRIDMATERIALDEFINITION", dataRow) { }
        protected PathologyGridMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYGRIDMATERIALDEFINITION", dataRow, isImported) { }
        public PathologyGridMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyGridMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyGridMaterialDefinition() : base() { }

    }
}