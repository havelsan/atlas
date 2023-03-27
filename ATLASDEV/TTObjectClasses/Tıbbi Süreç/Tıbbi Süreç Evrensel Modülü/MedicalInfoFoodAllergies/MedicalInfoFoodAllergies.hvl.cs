
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalInfoFoodAllergies")] 

    public  partial class MedicalInfoFoodAllergies : TTObject
    {
        public class MedicalInfoFoodAllergiesList : TTObjectCollection<MedicalInfoFoodAllergies> { }
                    
        public class ChildMedicalInfoFoodAllergiesCollection : TTObject.TTChildObjectCollection<MedicalInfoFoodAllergies>
        {
            public ChildMedicalInfoFoodAllergiesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalInfoFoodAllergiesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DietMaterialDefinition DietMaterial
        {
            get { return (DietMaterialDefinition)((ITTObject)this).GetParent("DIETMATERIAL"); }
            set { this["DIETMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalInfoAllergies MedicalInfoAllergies
        {
            get { return (MedicalInfoAllergies)((ITTObject)this).GetParent("MEDICALINFOALLERGIES"); }
            set { this["MEDICALINFOALLERGIES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalInfoFoodAllergies(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalInfoFoodAllergies(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalInfoFoodAllergies(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalInfoFoodAllergies(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalInfoFoodAllergies(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALINFOFOODALLERGIES", dataRow) { }
        protected MedicalInfoFoodAllergies(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALINFOFOODALLERGIES", dataRow, isImported) { }
        public MedicalInfoFoodAllergies(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalInfoFoodAllergies(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalInfoFoodAllergies() : base() { }

    }
}