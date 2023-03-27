
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneticGridMaterialDefinition")] 

    public  partial class GeneticGridMaterialDefinition : TTDefinitionSet
    {
        public class GeneticGridMaterialDefinitionList : TTObjectCollection<GeneticGridMaterialDefinition> { }
                    
        public class ChildGeneticGridMaterialDefinitionCollection : TTObject.TTChildObjectCollection<GeneticGridMaterialDefinition>
        {
            public ChildGeneticGridMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneticGridMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public GeneticTestDefinition GeneticTest
        {
            get { return (GeneticTestDefinition)((ITTObject)this).GetParent("GENETICTEST"); }
            set { this["GENETICTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected GeneticGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneticGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneticGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneticGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneticGridMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENETICGRIDMATERIALDEFINITION", dataRow) { }
        protected GeneticGridMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENETICGRIDMATERIALDEFINITION", dataRow, isImported) { }
        public GeneticGridMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneticGridMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneticGridMaterialDefinition() : base() { }

    }
}