
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Vaccination")] 

    public  partial class Vaccination : TTObject
    {
        public class VaccinationList : TTObjectCollection<Vaccination> { }
                    
        public class ChildVaccinationCollection : TTObject.TTChildObjectCollection<Vaccination>
        {
            public ChildVaccinationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVaccinationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Aşı Bilgileri
    /// </summary>
        public static BindingList<Vaccination> GetVaccinationsByImpMedInfoID(TTObjectContext objectContext, string ImpMedInfoID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VACCINATION"].QueryDefs["GetVaccinationsByImpMedInfoID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("IMPMEDINFOID", ImpMedInfoID);

            return ((ITTQuery)objectContext).QueryObjects<Vaccination>(queryDef, paramList);
        }

        public RiskEnum? Risk
        {
            get { return (RiskEnum?)(int?)this["RISK"]; }
            set { this["RISK"] = value; }
        }

    /// <summary>
    /// Aşı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Geçerliliği
    /// </summary>
        public string Effectiveness
        {
            get { return (string)this["EFFECTIVENESS"]; }
            set { this["EFFECTIVENESS"] = value; }
        }

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

        protected Vaccination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Vaccination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Vaccination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Vaccination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Vaccination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VACCINATION", dataRow) { }
        protected Vaccination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VACCINATION", dataRow, isImported) { }
        public Vaccination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Vaccination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Vaccination() : base() { }

    }
}