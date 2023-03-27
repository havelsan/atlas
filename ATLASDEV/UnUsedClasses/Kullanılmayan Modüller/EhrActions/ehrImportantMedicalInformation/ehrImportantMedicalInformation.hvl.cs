
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrImportantMedicalInformation")] 

    /// <summary>
    /// Önemli Tıbbi Bilgiler
    /// </summary>
    public  partial class ehrImportantMedicalInformation : ehrEpisodeAction
    {
        public class ehrImportantMedicalInformationList : TTObjectCollection<ehrImportantMedicalInformation> { }
                    
        public class ChildehrImportantMedicalInformationCollection : TTObject.TTChildObjectCollection<ehrImportantMedicalInformation>
        {
            public ChildehrImportantMedicalInformationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrImportantMedicalInformationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

        public static BindingList<ehrImportantMedicalInformation> GetEhrImportMedinfoByHospital(TTObjectContext objectContext, string HOSPITAL, string PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EHRIMPORTANTMEDICALINFORMATION"].QueryDefs["GetEhrImportMedinfoByHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HOSPITAL", HOSPITAL);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<ehrImportantMedicalInformation>(queryDef, paramList);
        }

    /// <summary>
    /// Hasta Uzuvlarının Durumu
    /// </summary>
        public object OrganInfo
        {
            get { return (object)this["ORGANINFO"]; }
            set { this["ORGANINFO"] = value; }
        }

    /// <summary>
    /// Sosyal
    /// </summary>
        public object SocialHistory
        {
            get { return (object)this["SOCIALHISTORY"]; }
            set { this["SOCIALHISTORY"] = value; }
        }

    /// <summary>
    /// Özgeçmiş
    /// </summary>
        public object PatientHistory
        {
            get { return (object)this["PATIENTHISTORY"]; }
            set { this["PATIENTHISTORY"] = value; }
        }

    /// <summary>
    /// Aile
    /// </summary>
        public object ParentHistory
        {
            get { return (object)this["PARENTHISTORY"]; }
            set { this["PARENTHISTORY"] = value; }
        }

    /// <summary>
    /// Hamile
    /// </summary>
        public bool? IsPregnant
        {
            get { return (bool?)this["ISPREGNANT"]; }
            set { this["ISPREGNANT"] = value; }
        }

    /// <summary>
    /// Hastaya Ait Önemli Bilgiler
    /// </summary>
        public object ImportantPatientInfo
        {
            get { return (object)this["IMPORTANTPATIENTINFO"]; }
            set { this["IMPORTANTPATIENTINFO"] = value; }
        }

    /// <summary>
    /// Kan Grubu
    /// </summary>
        public BloodGroupEnum? BloodGroup
        {
            get { return (BloodGroupEnum?)(int?)this["BLOODGROUP"]; }
            set { this["BLOODGROUP"] = value; }
        }

    /// <summary>
    /// Devamlı İlaçlar
    /// </summary>
        public object ContinuousDrugs
        {
            get { return (object)this["CONTINUOUSDRUGS"]; }
            set { this["CONTINUOUSDRUGS"] = value; }
        }

    /// <summary>
    /// Alışkanlıklar
    /// </summary>
        public object Habits
        {
            get { return (object)this["HABITS"]; }
            set { this["HABITS"] = value; }
        }

    /// <summary>
    /// Bilginin Girildiği XXXXXX 
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDiagnosisHistoryCollection()
        {
            _DiagnosisHistory = new ehrDiagnosis.ChildehrDiagnosisCollection(this, new Guid("ac36be9a-6ba6-4d70-a059-c204423d7d07"));
            ((ITTChildObjectCollection)_DiagnosisHistory).GetChildren();
        }

        protected ehrDiagnosis.ChildehrDiagnosisCollection _DiagnosisHistory = null;
    /// <summary>
    /// Child collection for Önemli Tıbbi Bilgiler-Tanı Özgeçmişi
    /// </summary>
        public ehrDiagnosis.ChildehrDiagnosisCollection DiagnosisHistory
        {
            get
            {
                if (_DiagnosisHistory == null)
                    CreateDiagnosisHistoryCollection();
                return _DiagnosisHistory;
            }
        }

        virtual protected void CreateehrAllergysCollection()
        {
            _ehrAllergys = new ehrAllergy.ChildehrAllergyCollection(this, new Guid("b024182b-dcfe-4e09-97cb-efcf60e69025"));
            ((ITTChildObjectCollection)_ehrAllergys).GetChildren();
        }

        protected ehrAllergy.ChildehrAllergyCollection _ehrAllergys = null;
    /// <summary>
    /// Child collection for Önemli Tıbbi Bilgiler-Allerji Bilgileri
    /// </summary>
        public ehrAllergy.ChildehrAllergyCollection ehrAllergys
        {
            get
            {
                if (_ehrAllergys == null)
                    CreateehrAllergysCollection();
                return _ehrAllergys;
            }
        }

        protected ehrImportantMedicalInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrImportantMedicalInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrImportantMedicalInformation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrImportantMedicalInformation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrImportantMedicalInformation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRIMPORTANTMEDICALINFORMATION", dataRow) { }
        protected ehrImportantMedicalInformation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRIMPORTANTMEDICALINFORMATION", dataRow, isImported) { }
        public ehrImportantMedicalInformation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrImportantMedicalInformation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrImportantMedicalInformation() : base() { }

    }
}