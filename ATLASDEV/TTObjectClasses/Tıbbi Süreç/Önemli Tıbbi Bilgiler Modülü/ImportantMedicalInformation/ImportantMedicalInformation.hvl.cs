
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ImportantMedicalInformation")] 

    /// <summary>
    /// Hastanın Önemli Tıbbi Bilgilerinin Grişinin Yapıldığı Nesnedir.
    /// </summary>
    public  partial class ImportantMedicalInformation : EpisodeAction
    {
        public class ImportantMedicalInformationList : TTObjectCollection<ImportantMedicalInformation> { }
                    
        public class ChildImportantMedicalInformationCollection : TTObject.TTChildObjectCollection<ImportantMedicalInformation>
        {
            public ChildImportantMedicalInformationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildImportantMedicalInformationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("2124044a-65d4-4128-85b7-8e8e625f52bd"); } }
            public static Guid New { get { return new Guid("e40e5624-8e3d-459f-a970-5599a206d552"); } }
            public static Guid InActive { get { return new Guid("6ad348ae-a72f-4180-b25b-e3b01841e3e6"); } }
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
    /// Hamile
    /// </summary>
        public bool? IsPregnant
        {
            get { return (bool?)this["ISPREGNANT"]; }
            set { this["ISPREGNANT"] = value; }
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

        public bool? UnActive
        {
            get { return (bool?)this["UNACTIVE"]; }
            set { this["UNACTIVE"] = value; }
        }

    /// <summary>
    /// Tüm Personeli Uyar
    /// </summary>
        public bool? WarnAllMedicalPersonnel
        {
            get { return (bool?)this["WARNALLMEDICALPERSONNEL"]; }
            set { this["WARNALLMEDICALPERSONNEL"] = value; }
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
    /// Aile
    /// </summary>
        public object ParentHistory
        {
            get { return (object)this["PARENTHISTORY"]; }
            set { this["PARENTHISTORY"] = value; }
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
    /// Son Adet Tarihi
    /// </summary>
        public DateTime? LastMenstrualPeriod
        {
            get { return (DateTime?)this["LASTMENSTRUALPERIOD"]; }
            set { this["LASTMENSTRUALPERIOD"] = value; }
        }

        virtual protected void CreateCancelledDiagnosisCollection()
        {
            _CancelledDiagnosis = new ImportantMedicalInformationCancelledDiagnosis.ChildImportantMedicalInformationCancelledDiagnosisCollection(this, new Guid("30b995a8-d873-47f6-93fb-2d0529b677d1"));
            ((ITTChildObjectCollection)_CancelledDiagnosis).GetChildren();
        }

        protected ImportantMedicalInformationCancelledDiagnosis.ChildImportantMedicalInformationCancelledDiagnosisCollection _CancelledDiagnosis = null;
        public ImportantMedicalInformationCancelledDiagnosis.ChildImportantMedicalInformationCancelledDiagnosisCollection CancelledDiagnosis
        {
            get
            {
                if (_CancelledDiagnosis == null)
                    CreateCancelledDiagnosisCollection();
                return _CancelledDiagnosis;
            }
        }

        virtual protected void CreateVaccinationsCollection()
        {
            _Vaccinations = new Vaccination.ChildVaccinationCollection(this, new Guid("7bb21f26-3f72-4eef-af89-21129b6bd2c5"));
            ((ITTChildObjectCollection)_Vaccinations).GetChildren();
        }

        protected Vaccination.ChildVaccinationCollection _Vaccinations = null;
        public Vaccination.ChildVaccinationCollection Vaccinations
        {
            get
            {
                if (_Vaccinations == null)
                    CreateVaccinationsCollection();
                return _Vaccinations;
            }
        }

        virtual protected void CreateAllergiesCollection()
        {
            _Allergies = new Allergy.ChildAllergyCollection(this, new Guid("64b0b985-de23-416e-a850-73b6e7ee033f"));
            ((ITTChildObjectCollection)_Allergies).GetChildren();
        }

        protected Allergy.ChildAllergyCollection _Allergies = null;
    /// <summary>
    /// Child collection for Allergies
    /// </summary>
        public Allergy.ChildAllergyCollection Allergies
        {
            get
            {
                if (_Allergies == null)
                    CreateAllergiesCollection();
                return _Allergies;
            }
        }

        virtual protected void CreateDiagnosisHistoryCollection()
        {
            _DiagnosisHistory = new DiagnosisGrid.ChildDiagnosisGridCollection(this, new Guid("c75b92b1-ac7c-46c1-9b53-c59900f1c8a7"));
            ((ITTChildObjectCollection)_DiagnosisHistory).GetChildren();
        }

        protected DiagnosisGrid.ChildDiagnosisGridCollection _DiagnosisHistory = null;
    /// <summary>
    /// Child collection for Önemli Tıbbi Bilgiler-Tanı Özgeçmişi
    /// </summary>
        public DiagnosisGrid.ChildDiagnosisGridCollection DiagnosisHistory
        {
            get
            {
                if (_DiagnosisHistory == null)
                    CreateDiagnosisHistoryCollection();
                return _DiagnosisHistory;
            }
        }

        protected ImportantMedicalInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ImportantMedicalInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ImportantMedicalInformation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ImportantMedicalInformation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ImportantMedicalInformation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IMPORTANTMEDICALINFORMATION", dataRow) { }
        protected ImportantMedicalInformation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IMPORTANTMEDICALINFORMATION", dataRow, isImported) { }
        public ImportantMedicalInformation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ImportantMedicalInformation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ImportantMedicalInformation() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}