
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryGridSensitivityValueDefinition")] 

    /// <summary>
    /// Laboratuvar Duyarlılık Değerleri Tanımı
    /// </summary>
    public  partial class LaboratoryGridSensitivityValueDefinition : TTDefinitionSet
    {
        public class LaboratoryGridSensitivityValueDefinitionList : TTObjectCollection<LaboratoryGridSensitivityValueDefinition> { }
                    
        public class ChildLaboratoryGridSensitivityValueDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryGridSensitivityValueDefinition>
        {
            public ChildLaboratoryGridSensitivityValueDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryGridSensitivityValueDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dirençli(mm)
    /// </summary>
        public string ResistanceMM
        {
            get { return (string)this["RESISTANCEMM"]; }
            set { this["RESISTANCEMM"] = value; }
        }

    /// <summary>
    /// Duyarlı(mm)
    /// </summary>
        public string SensitiveMM
        {
            get { return (string)this["SENSITIVEMM"]; }
            set { this["SENSITIVEMM"] = value; }
        }

    /// <summary>
    /// Duyarlı(MIK)
    /// </summary>
        public string SensitiveMIC
        {
            get { return (string)this["SENSITIVEMIC"]; }
            set { this["SENSITIVEMIC"] = value; }
        }

    /// <summary>
    /// Dirençli(MIK)
    /// </summary>
        public string ResistanceMIC
        {
            get { return (string)this["RESISTANCEMIC"]; }
            set { this["RESISTANCEMIC"] = value; }
        }

        public LaboratoryBacteriaGroupDefinition LaboratoryBacteriaGroup
        {
            get { return (LaboratoryBacteriaGroupDefinition)((ITTObject)this).GetParent("LABORATORYBACTERIAGROUP"); }
            set { this["LABORATORYBACTERIAGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratuvar Ingredient Tanımı İlişkisi
    /// </summary>
        public LaboratoryIngredientDefinition Ingredient
        {
            get { return (LaboratoryIngredientDefinition)((ITTObject)this).GetParent("INGREDIENT"); }
            set { this["INGREDIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryGridSensitivityValueDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryGridSensitivityValueDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryGridSensitivityValueDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryGridSensitivityValueDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryGridSensitivityValueDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYGRIDSENSITIVITYVALUEDEFINITION", dataRow) { }
        protected LaboratoryGridSensitivityValueDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYGRIDSENSITIVITYVALUEDEFINITION", dataRow, isImported) { }
        public LaboratoryGridSensitivityValueDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryGridSensitivityValueDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryGridSensitivityValueDefinition() : base() { }

    }
}