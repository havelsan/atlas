
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalInfoDrugAllergies")] 

    /// <summary>
    /// Etkin madde bazında
    /// </summary>
    public  partial class MedicalInfoDrugAllergies : TTObject
    {
        public class MedicalInfoDrugAllergiesList : TTObjectCollection<MedicalInfoDrugAllergies> { }
                    
        public class ChildMedicalInfoDrugAllergiesCollection : TTObject.TTChildObjectCollection<MedicalInfoDrugAllergies>
        {
            public ChildMedicalInfoDrugAllergiesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalInfoDrugAllergiesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MedicalInfoAllergies MedicalInfoAllergies
        {
            get { return (MedicalInfoAllergies)((ITTObject)this).GetParent("MEDICALINFOALLERGIES"); }
            set { this["MEDICALINFOALLERGIES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ActiveIngredientDefinition ActiveIngredient
        {
            get { return (ActiveIngredientDefinition)((ITTObject)this).GetParent("ACTIVEINGREDIENT"); }
            set { this["ACTIVEINGREDIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalInfoDrugAllergies(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalInfoDrugAllergies(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalInfoDrugAllergies(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalInfoDrugAllergies(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalInfoDrugAllergies(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALINFODRUGALLERGIES", dataRow) { }
        protected MedicalInfoDrugAllergies(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALINFODRUGALLERGIES", dataRow, isImported) { }
        public MedicalInfoDrugAllergies(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalInfoDrugAllergies(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalInfoDrugAllergies() : base() { }

    }
}