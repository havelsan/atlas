
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DietMaterialGrid")] 

    public  partial class DietMaterialGrid : TTObject
    {
        public class DietMaterialGridList : TTObjectCollection<DietMaterialGrid> { }
                    
        public class ChildDietMaterialGridCollection : TTObject.TTChildObjectCollection<DietMaterialGrid>
        {
            public ChildDietMaterialGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDietMaterialGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public CourseDefinition CourseDefinition
        {
            get { return (CourseDefinition)((ITTObject)this).GetParent("COURSEDEFINITION"); }
            set { this["COURSEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DietMaterialDefinition DietMaterialDefinition
        {
            get { return (DietMaterialDefinition)((ITTObject)this).GetParent("DIETMATERIALDEFINITION"); }
            set { this["DIETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DietMaterialGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DietMaterialGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DietMaterialGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DietMaterialGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DietMaterialGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIETMATERIALGRID", dataRow) { }
        protected DietMaterialGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIETMATERIALGRID", dataRow, isImported) { }
        public DietMaterialGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DietMaterialGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DietMaterialGrid() : base() { }

    }
}