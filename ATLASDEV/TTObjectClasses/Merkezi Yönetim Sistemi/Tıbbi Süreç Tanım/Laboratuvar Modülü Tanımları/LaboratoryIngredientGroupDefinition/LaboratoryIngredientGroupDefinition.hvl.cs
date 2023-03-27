
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryIngredientGroupDefinition")] 

    /// <summary>
    /// Laboratuvar Etken Madde Grup Tanımı
    /// </summary>
    public  partial class LaboratoryIngredientGroupDefinition : TTDefinitionSet
    {
        public class LaboratoryIngredientGroupDefinitionList : TTObjectCollection<LaboratoryIngredientGroupDefinition> { }
                    
        public class ChildLaboratoryIngredientGroupDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryIngredientGroupDefinition>
        {
            public ChildLaboratoryIngredientGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryIngredientGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected LaboratoryIngredientGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryIngredientGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryIngredientGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryIngredientGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryIngredientGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYINGREDIENTGROUPDEFINITION", dataRow) { }
        protected LaboratoryIngredientGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYINGREDIENTGROUPDEFINITION", dataRow, isImported) { }
        public LaboratoryIngredientGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryIngredientGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryIngredientGroupDefinition() : base() { }

    }
}