
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryBacteriaGroupDefinition")] 

    /// <summary>
    /// Laboratuvar Bakteri Grup Tanımı
    /// </summary>
    public  partial class LaboratoryBacteriaGroupDefinition : TTDefinitionSet
    {
        public class LaboratoryBacteriaGroupDefinitionList : TTObjectCollection<LaboratoryBacteriaGroupDefinition> { }
                    
        public class ChildLaboratoryBacteriaGroupDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryBacteriaGroupDefinition>
        {
            public ChildLaboratoryBacteriaGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryBacteriaGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Gram-Negatif
    /// </summary>
        public bool? IsGramNegative
        {
            get { return (bool?)this["ISGRAMNEGATIVE"]; }
            set { this["ISGRAMNEGATIVE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Gram-Pozitif
    /// </summary>
        public bool? IsGramPositive
        {
            get { return (bool?)this["ISGRAMPOSITIVE"]; }
            set { this["ISGRAMPOSITIVE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreateSensitivityValuesCollection()
        {
            _SensitivityValues = new LaboratoryGridSensitivityValueDefinition.ChildLaboratoryGridSensitivityValueDefinitionCollection(this, new Guid("45c3f0df-1259-4152-af26-2c171073c1af"));
            ((ITTChildObjectCollection)_SensitivityValues).GetChildren();
        }

        protected LaboratoryGridSensitivityValueDefinition.ChildLaboratoryGridSensitivityValueDefinitionCollection _SensitivityValues = null;
        public LaboratoryGridSensitivityValueDefinition.ChildLaboratoryGridSensitivityValueDefinitionCollection SensitivityValues
        {
            get
            {
                if (_SensitivityValues == null)
                    CreateSensitivityValuesCollection();
                return _SensitivityValues;
            }
        }

        protected LaboratoryBacteriaGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryBacteriaGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryBacteriaGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryBacteriaGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryBacteriaGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYBACTERIAGROUPDEFINITION", dataRow) { }
        protected LaboratoryBacteriaGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYBACTERIAGROUPDEFINITION", dataRow, isImported) { }
        public LaboratoryBacteriaGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryBacteriaGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryBacteriaGroupDefinition() : base() { }

    }
}