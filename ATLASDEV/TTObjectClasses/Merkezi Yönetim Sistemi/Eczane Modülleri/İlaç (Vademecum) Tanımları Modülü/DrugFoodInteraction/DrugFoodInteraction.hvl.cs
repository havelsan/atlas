
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugFoodInteraction")] 

    public  partial class DrugFoodInteraction : TTObject
    {
        public class DrugFoodInteractionList : TTObjectCollection<DrugFoodInteraction> { }
                    
        public class ChildDrugFoodInteractionCollection : TTObject.TTChildObjectCollection<DrugFoodInteraction>
        {
            public ChildDrugFoodInteractionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugFoodInteractionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Etkileşim Seviyesi
    /// </summary>
        public InteractionLevelTypeEnum? InteractionLevelType
        {
            get { return (InteractionLevelTypeEnum?)(int?)this["INTERACTIONLEVELTYPE"]; }
            set { this["INTERACTIONLEVELTYPE"] = value; }
        }

    /// <summary>
    /// Uyarı Mesajı
    /// </summary>
        public string Message
        {
            get { return (string)this["MESSAGE"]; }
            set { this["MESSAGE"] = value; }
        }

        public DietMaterialDefinition DietMaterialDefinition
        {
            get { return (DietMaterialDefinition)((ITTObject)this).GetParent("DIETMATERIALDEFINITION"); }
            set { this["DIETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugFoodInteraction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugFoodInteraction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugFoodInteraction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugFoodInteraction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugFoodInteraction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGFOODINTERACTION", dataRow) { }
        protected DrugFoodInteraction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGFOODINTERACTION", dataRow, isImported) { }
        public DrugFoodInteraction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugFoodInteraction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugFoodInteraction() : base() { }

    }
}