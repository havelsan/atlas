
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Allergy")] 

    public  partial class Allergy : TTObject
    {
        public class AllergyList : TTObjectCollection<Allergy> { }
                    
        public class ChildAllergyCollection : TTObject.TTChildObjectCollection<Allergy>
        {
            public ChildAllergyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAllergyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<Allergy> GetAllergiesByImpMedInfoID(TTObjectContext objectContext, string ImpMedInfoID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ALLERGY"].QueryDefs["GetAllergiesByImpMedInfoID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("IMPMEDINFOID", ImpMedInfoID);

            return ((ITTQuery)objectContext).QueryObjects<Allergy>(queryDef, paramList);
        }

    /// <summary>
    /// Reaksiyon
    /// </summary>
        public string Reaction
        {
            get { return (string)this["REACTION"]; }
            set { this["REACTION"] = value; }
        }

    /// <summary>
    /// Allerji
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public RiskEnum? Risk
        {
            get { return (RiskEnum?)(int?)this["RISK"]; }
            set { this["RISK"] = value; }
        }

    /// <summary>
    /// Allergies
    /// </summary>
        public ImportantMedicalInformation ImportantMedicalInformation
        {
            get { return (ImportantMedicalInformation)((ITTObject)this).GetParent("IMPORTANTMEDICALINFORMATION"); }
            set { this["IMPORTANTMEDICALINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Allergies
    /// </summary>
        public EmergencySpecialityObject EmergencySpecialityObject
        {
            get { return (EmergencySpecialityObject)((ITTObject)this).GetParent("EMERGENCYSPECIALITYOBJECT"); }
            set { this["EMERGENCYSPECIALITYOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Allergy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Allergy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Allergy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Allergy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Allergy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ALLERGY", dataRow) { }
        protected Allergy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ALLERGY", dataRow, isImported) { }
        public Allergy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Allergy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Allergy() : base() { }

    }
}