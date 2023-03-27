
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalInformation")] 

    /// <summary>
    /// Tıbbi Bilgiler/Uyarılar/Alarmlar
    /// </summary>
    public  partial class MedicalInformation : TTObject
    {
        public class MedicalInformationList : TTObjectCollection<MedicalInformation> { }
                    
        public class ChildMedicalInformationCollection : TTObject.TTChildObjectCollection<MedicalInformation>
        {
            public ChildMedicalInformationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalInformationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Alerji Var/Yok
    /// </summary>
        public VarYokGarantiEnum? HasAllergy
        {
            get { return (VarYokGarantiEnum?)(int?)this["HASALLERGY"]; }
            set { this["HASALLERGY"] = value; }
        }

    /// <summary>
    /// Diğer
    /// </summary>
        public string OtherInformation
        {
            get { return (string)this["OTHERINFORMATION"]; }
            set { this["OTHERINFORMATION"] = value; }
        }

        public string Transplantation
        {
            get { return (string)this["TRANSPLANTATION"]; }
            set { this["TRANSPLANTATION"] = value; }
        }

        public string OncologicFollowUp
        {
            get { return (string)this["ONCOLOGICFOLLOWUP"]; }
            set { this["ONCOLOGICFOLLOWUP"] = value; }
        }

        public string Implant
        {
            get { return (string)this["IMPLANT"]; }
            set { this["IMPLANT"] = value; }
        }

        public string Hemodialysis
        {
            get { return (string)this["HEMODIALYSIS"]; }
            set { this["HEMODIALYSIS"] = value; }
        }

        public bool? Pregnancy
        {
            get { return (bool?)this["PREGNANCY"]; }
            set { this["PREGNANCY"] = value; }
        }

        public string ChronicDiseases
        {
            get { return (string)this["CHRONICDISEASES"]; }
            set { this["CHRONICDISEASES"] = value; }
        }

    /// <summary>
    /// Bulaşıcı Hastalık 
    /// </summary>
        public VarYokGarantiEnum? HasContagiousDisease
        {
            get { return (VarYokGarantiEnum?)(int?)this["HASCONTAGIOUSDISEASE"]; }
            set { this["HASCONTAGIOUSDISEASE"] = value; }
        }

    /// <summary>
    /// Bulaşıcı Hastalık
    /// </summary>
        public string ContagiousDisease
        {
            get { return (string)this["CONTAGIOUSDISEASE"]; }
            set { this["CONTAGIOUSDISEASE"] = value; }
        }

    /// <summary>
    /// Kalp Pili
    /// </summary>
        public bool? CardiacPacemaker
        {
            get { return (bool?)this["CARDIACPACEMAKER"]; }
            set { this["CARDIACPACEMAKER"] = value; }
        }

        public bool? HeartFailure
        {
            get { return (bool?)this["HEARTFAILURE"]; }
            set { this["HEARTFAILURE"] = value; }
        }

        public bool? Broken
        {
            get { return (bool?)this["BROKEN"]; }
            set { this["BROKEN"] = value; }
        }

        public bool? Diabetes
        {
            get { return (bool?)this["DIABETES"]; }
            set { this["DIABETES"] = value; }
        }

        public bool? Malignancy
        {
            get { return (bool?)this["MALIGNANCY"]; }
            set { this["MALIGNANCY"] = value; }
        }

        public bool? MetalImplant
        {
            get { return (bool?)this["METALIMPLANT"]; }
            set { this["METALIMPLANT"] = value; }
        }

        public bool? VascularDisorder
        {
            get { return (bool?)this["VASCULARDISORDER"]; }
            set { this["VASCULARDISORDER"] = value; }
        }

        public bool? Infection
        {
            get { return (bool?)this["INFECTION"]; }
            set { this["INFECTION"] = value; }
        }

        public bool? Stent
        {
            get { return (bool?)this["STENT"]; }
            set { this["STENT"] = value; }
        }

        public bool? Other
        {
            get { return (bool?)this["OTHER"]; }
            set { this["OTHER"] = value; }
        }

        public bool? Pandemic
        {
            get { return (bool?)this["PANDEMIC"]; }
            set { this["PANDEMIC"] = value; }
        }

        public bool? Advers
        {
            get { return (bool?)this["ADVERS"]; }
            set { this["ADVERS"] = value; }
        }

        public bool? HighRiskPregnancy
        {
            get { return (bool?)this["HIGHRISKPREGNANCY"]; }
            set { this["HIGHRISKPREGNANCY"] = value; }
        }

    /// <summary>
    /// Metal implant açıklaması
    /// </summary>
        public string MetalImplantDescription
        {
            get { return (string)this["METALIMPLANTDESCRIPTION"]; }
            set { this["METALIMPLANTDESCRIPTION"] = value; }
        }

        public DateTime? HighRiskPregnancyDate
        {
            get { return (DateTime?)this["HIGHRISKPREGNANCYDATE"]; }
            set { this["HIGHRISKPREGNANCYDATE"] = value; }
        }

        public MedicalInfoAllergies MedicalInfoAllergies
        {
            get { return (MedicalInfoAllergies)((ITTObject)this).GetParent("MEDICALINFOALLERGIES"); }
            set { this["MEDICALINFOALLERGIES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalInfoHabits MedicalInfoHabits
        {
            get { return (MedicalInfoHabits)((ITTObject)this).GetParent("MEDICALINFOHABITS"); }
            set { this["MEDICALINFOHABITS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalInfoDisabledGroup MedicalInfoDisabledGroup
        {
            get { return (MedicalInfoDisabledGroup)((ITTObject)this).GetParent("MEDICALINFODISABLEDGROUP"); }
            set { this["MEDICALINFODISABLEDGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePatientCollection()
        {
            _Patient = new Patient.ChildPatientCollection(this, new Guid("5825707b-80c2-49aa-afc1-390e691c391c"));
            ((ITTChildObjectCollection)_Patient).GetChildren();
        }

        protected Patient.ChildPatientCollection _Patient = null;
        public Patient.ChildPatientCollection Patient
        {
            get
            {
                if (_Patient == null)
                    CreatePatientCollection();
                return _Patient;
            }
        }

        virtual protected void CreateMedicalInfoSurgeriesCollection()
        {
            _MedicalInfoSurgeries = new MedicalInfoSurgeries.ChildMedicalInfoSurgeriesCollection(this, new Guid("f3127ea9-6a74-495d-a40c-9572e9d24014"));
            ((ITTChildObjectCollection)_MedicalInfoSurgeries).GetChildren();
        }

        protected MedicalInfoSurgeries.ChildMedicalInfoSurgeriesCollection _MedicalInfoSurgeries = null;
        public MedicalInfoSurgeries.ChildMedicalInfoSurgeriesCollection MedicalInfoSurgeries
        {
            get
            {
                if (_MedicalInfoSurgeries == null)
                    CreateMedicalInfoSurgeriesCollection();
                return _MedicalInfoSurgeries;
            }
        }

        virtual protected void CreateMedicalInfoContiniousDrugsCollection()
        {
            _MedicalInfoContiniousDrugs = new MedicalInfoContiniousDrugs.ChildMedicalInfoContiniousDrugsCollection(this, new Guid("76f0220f-ca48-4601-9781-670af9ea3dcc"));
            ((ITTChildObjectCollection)_MedicalInfoContiniousDrugs).GetChildren();
        }

        protected MedicalInfoContiniousDrugs.ChildMedicalInfoContiniousDrugsCollection _MedicalInfoContiniousDrugs = null;
        public MedicalInfoContiniousDrugs.ChildMedicalInfoContiniousDrugsCollection MedicalInfoContiniousDrugs
        {
            get
            {
                if (_MedicalInfoContiniousDrugs == null)
                    CreateMedicalInfoContiniousDrugsCollection();
                return _MedicalInfoContiniousDrugs;
            }
        }

        protected MedicalInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalInformation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalInformation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalInformation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALINFORMATION", dataRow) { }
        protected MedicalInformation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALINFORMATION", dataRow, isImported) { }
        public MedicalInformation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalInformation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalInformation() : base() { }

    }
}