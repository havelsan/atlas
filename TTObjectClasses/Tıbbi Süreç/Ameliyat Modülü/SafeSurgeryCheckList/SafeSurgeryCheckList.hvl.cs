
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SafeSurgeryCheckList")] 

    /// <summary>
    /// Güvenli Cerrahi Kontrol Listesi
    /// </summary>
    public  partial class SafeSurgeryCheckList : TTObject
    {
        public class SafeSurgeryCheckListList : TTObjectCollection<SafeSurgeryCheckList> { }
                    
        public class ChildSafeSurgeryCheckListCollection : TTObject.TTChildObjectCollection<SafeSurgeryCheckList>
        {
            public ChildSafeSurgeryCheckListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSafeSurgeryCheckListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSafeSurgeryChecklistWL_Class : TTReportNqlObject 
        {
            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSafeSurgeryChecklistWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSafeSurgeryChecklistWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSafeSurgeryChecklistWL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Klinikten Ayrılmadan Önce
    /// </summary>
            public static Guid BeforeLeavingClinic { get { return new Guid("e3423b86-2ca3-452a-9b5d-32ef4569d87e"); } }
    /// <summary>
    /// Anestezi Verilmeden Önce
    /// </summary>
            public static Guid BeforeAnesthesia { get { return new Guid("4a0aa94c-c571-4f05-a2a4-482a8a5a72f0"); } }
    /// <summary>
    /// Ameliyat Kesisinden Önce
    /// </summary>
            public static Guid BeforeSurgicalIncision { get { return new Guid("1ab8e670-5ab9-48fc-914e-fa7716e99402"); } }
    /// <summary>
    /// Ameliyattan Çıkmadan Önce
    /// </summary>
            public static Guid BeforeLeavingSurgery { get { return new Guid("bc5a938b-d365-4e29-93ff-657735d89b8e"); } }
    /// <summary>
    /// Ameliyat isteği iptal edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("b07dc3b5-f705-4802-86a2-6f737361624e"); } }
            public static Guid Completed { get { return new Guid("b23114d2-e439-431c-97fc-c1e901e74053"); } }
        }

        public static BindingList<SafeSurgeryCheckList.GetSafeSurgeryChecklistWL_Class> GetSafeSurgeryChecklistWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAFESURGERYCHECKLIST"].QueryDefs["GetSafeSurgeryChecklistWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SafeSurgeryCheckList.GetSafeSurgeryChecklistWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SafeSurgeryCheckList.GetSafeSurgeryChecklistWL_Class> GetSafeSurgeryChecklistWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAFESURGERYCHECKLIST"].QueryDefs["GetSafeSurgeryChecklistWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SafeSurgeryCheckList.GetSafeSurgeryChecklistWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hastanın Kimlik Bilgileri Doğrulandı
    /// </summary>
        public bool? PatientIDInfoVerified
        {
            get { return (bool?)this["PATIENTIDINFOVERIFIED"]; }
            set { this["PATIENTIDINFOVERIFIED"] = value; }
        }

    /// <summary>
    /// Hastanın Ameliyatı Doğrulandı
    /// </summary>
        public bool? PatientSurgeryVerified
        {
            get { return (bool?)this["PATIENTSURGERYVERIFIED"]; }
            set { this["PATIENTSURGERYVERIFIED"] = value; }
        }

    /// <summary>
    /// Hastanın Ameliyat Bölgesi Doğrulandı
    /// </summary>
        public bool? PatientSurgeryAreaVerified
        {
            get { return (bool?)this["PATIENTSURGERYAREAVERIFIED"]; }
            set { this["PATIENTSURGERYAREAVERIFIED"] = value; }
        }

    /// <summary>
    /// Hastanın Rızası Kontrol Edildi
    /// </summary>
        public bool? PatientConsentChecked
        {
            get { return (bool?)this["PATIENTCONSENTCHECKED"]; }
            set { this["PATIENTCONSENTCHECKED"] = value; }
        }

    /// <summary>
    /// Hasta Aç mı?
    /// </summary>
        public bool? IsPatientHungry
        {
            get { return (bool?)this["ISPATIENTHUNGRY"]; }
            set { this["ISPATIENTHUNGRY"] = value; }
        }

    /// <summary>
    /// Hasta Aç Değilse Açıklaması
    /// </summary>
        public string PatientHungerDescription
        {
            get { return (string)this["PATIENTHUNGERDESCRIPTION"]; }
            set { this["PATIENTHUNGERDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Hastada makyaj, protez, değerli eşya var mı?
    /// </summary>
        public bool? MakeupProsthesisValuableItem
        {
            get { return (bool?)this["MAKEUPPROSTHESISVALUABLEITEM"]; }
            set { this["MAKEUPPROSTHESISVALUABLEITEM"] = value; }
        }

    /// <summary>
    /// Ameliyat Bölgesi Tıraşı Yapıldı
    /// </summary>
        public bool? SurgeryAreaShaved
        {
            get { return (bool?)this["SURGERYAREASHAVED"]; }
            set { this["SURGERYAREASHAVED"] = value; }
        }

    /// <summary>
    /// Ameliyat Bölgesi Tıraşı Yapılmadıysa Açıklama
    /// </summary>
        public string SurgeryAreaShavedDescription
        {
            get { return (string)this["SURGERYAREASHAVEDDESCRIPTION"]; }
            set { this["SURGERYAREASHAVEDDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Hastada makyaj, protez, değerli eşya varsa Açıklama
    /// </summary>
        public string MakeupProstValItemDescription
        {
            get { return (string)this["MAKEUPPROSTVALITEMDESCRIPTION"]; }
            set { this["MAKEUPPROSTVALITEMDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Ameliyat kıyafetleri giydirildi
    /// </summary>
        public bool? IsPatientClothesReady
        {
            get { return (bool?)this["ISPATIENTCLOTHESREADY"]; }
            set { this["ISPATIENTCLOTHESREADY"] = value; }
        }

    /// <summary>
    /// Ameliyat öncesi gerekli özel işlem mi
    /// </summary>
        public bool? LavmanRequired
        {
            get { return (bool?)this["LAVMANREQUIRED"]; }
            set { this["LAVMANREQUIRED"] = value; }
        }

    /// <summary>
    /// Varis Çorabı Gerekli mi
    /// </summary>
        public bool? VaricoseBandageRequired
        {
            get { return (bool?)this["VARICOSEBANDAGEREQUIRED"]; }
            set { this["VARICOSEBANDAGEREQUIRED"] = value; }
        }

    /// <summary>
    /// Mesane Kateterizasyonu Gerekli mi
    /// </summary>
        public bool? CatheterizationRequired
        {
            get { return (bool?)this["CATHETERIZATIONREQUIRED"]; }
            set { this["CATHETERIZATIONREQUIRED"] = value; }
        }

    /// <summary>
    /// Özel Tedavi Protokolü Gerekli mi
    /// </summary>
        public bool? TreatmentProtocolRequired
        {
            get { return (bool?)this["TREATMENTPROTOCOLREQUIRED"]; }
            set { this["TREATMENTPROTOCOLREQUIRED"] = value; }
        }

    /// <summary>
    /// Ameliyat öncesi DİĞER gerekli özel işlem var mı
    /// </summary>
        public bool? OtherSpecialActionRequired
        {
            get { return (bool?)this["OTHERSPECIALACTIONREQUIRED"]; }
            set { this["OTHERSPECIALACTIONREQUIRED"] = value; }
        }

    /// <summary>
    /// Diğer özel işlem açıklaması
    /// </summary>
        public string OtherSpecialActionDescription
        {
            get { return (string)this["OTHERSPECIALACTIONDESCRIPTION"]; }
            set { this["OTHERSPECIALACTIONDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Özel malzeme, implant, kan veya kan ürünleri hazırlığı teyit edildi mi
    /// </summary>
        public bool? MaterialPreparationChecked
        {
            get { return (bool?)this["MATERIALPREPARATIONCHECKED"]; }
            set { this["MATERIALPREPARATIONCHECKED"] = value; }
        }

    /// <summary>
    /// Laboratuvar ve Radyoloji Tetkikleri Mevcut mu
    /// </summary>
        public bool? LabAndRadioTestsAvailable
        {
            get { return (bool?)this["LABANDRADIOTESTSAVAILABLE"]; }
            set { this["LABANDRADIOTESTSAVAILABLE"] = value; }
        }

    /// <summary>
    /// Hastanın kendisinden kimlik bilgileri doğrulandı
    /// </summary>
        public bool? PatientIDVerifiedByPatient
        {
            get { return (bool?)this["PATIENTIDVERIFIEDBYPATIENT"]; }
            set { this["PATIENTIDVERIFIEDBYPATIENT"] = value; }
        }

    /// <summary>
    /// Hastanın kendisinden ameliyatı doğrulandı
    /// </summary>
        public bool? SurgeryVerifiedByPatient
        {
            get { return (bool?)this["SURGERYVERIFIEDBYPATIENT"]; }
            set { this["SURGERYVERIFIEDBYPATIENT"] = value; }
        }

    /// <summary>
    /// Hastanın Kendisinden Ameliyat Bölgesi Doğrulandı
    /// </summary>
        public bool? SugeryAreaVerifiedByPatient
        {
            get { return (bool?)this["SUGERYAREAVERIFIEDBYPATIENT"]; }
            set { this["SUGERYAREAVERIFIEDBYPATIENT"] = value; }
        }

    /// <summary>
    /// Hastanın Kendisinden Rızası Doğrulandı
    /// </summary>
        public bool? ConsentVerifiedByPatient
        {
            get { return (bool?)this["CONSENTVERIFIEDBYPATIENT"]; }
            set { this["CONSENTVERIFIEDBYPATIENT"] = value; }
        }

    /// <summary>
    /// Ameliyat Bölgesinde İşaretleme Var mı
    /// </summary>
        public bool? HasSignInSurgeryArea
        {
            get { return (bool?)this["HASSIGNINSURGERYAREA"]; }
            set { this["HASSIGNINSURGERYAREA"] = value; }
        }

    /// <summary>
    /// Anestezi Güvenlik Kontrol Listesi Tamamlandı mı
    /// </summary>
        public bool? AnesthesiaChecklistCompleted
        {
            get { return (bool?)this["ANESTHESIACHECKLISTCOMPLETED"]; }
            set { this["ANESTHESIACHECKLISTCOMPLETED"] = value; }
        }

    /// <summary>
    /// Pulse oksimetre hasta üzerinde ve çalışıyor mu?
    /// </summary>
        public bool? PulseOximeterWorksOut
        {
            get { return (bool?)this["PULSEOXIMETERWORKSOUT"]; }
            set { this["PULSEOXIMETERWORKSOUT"] = value; }
        }

    /// <summary>
    /// Hastanın bilinen alerjisi var mı
    /// </summary>
        public bool? PatientHasAnAllergy
        {
            get { return (bool?)this["PATIENTHASANALLERGY"]; }
            set { this["PATIENTHASANALLERGY"] = value; }
        }

    /// <summary>
    /// Gerekli görüntüleme cihazları var mı?
    /// </summary>
        public bool? HasImagingDevice
        {
            get { return (bool?)this["HASIMAGINGDEVICE"]; }
            set { this["HASIMAGINGDEVICE"] = value; }
        }

    /// <summary>
    /// 500 ml ya da daha fazla kan kaybı riski var mı
    /// </summary>
        public bool? HasBloodLossRisk
        {
            get { return (bool?)this["HASBLOODLOSSRISK"]; }
            set { this["HASBLOODLOSSRISK"] = value; }
        }

    /// <summary>
    /// Hastanın alerjisi var ise açıklaması
    /// </summary>
        public string PatientAllergyDescription
        {
            get { return (string)this["PATIENTALLERGYDESCRIPTION"]; }
            set { this["PATIENTALLERGYDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Ekipteki kişiler kendini tanıttı mı
    /// </summary>
        public bool? TeamMembersIntroThemselves
        {
            get { return (bool?)this["TEAMMEMBERSINTROTHEMSELVES"]; }
            set { this["TEAMMEMBERSINTROTHEMSELVES"] = value; }
        }

    /// <summary>
    /// Tahmini ameliyat süresi gözden geçirildi mi?
    /// </summary>
        public bool? ReviewedEstimatedSurgeryTime
        {
            get { return (bool?)this["REVIEWEDESTIMATEDSURGERYTIME"]; }
            set { this["REVIEWEDESTIMATEDSURGERYTIME"] = value; }
        }

    /// <summary>
    /// Beklenen kan kabı gözden geçirildi mi?
    /// </summary>
        public bool? ReviewedExpectedBloodLoss
        {
            get { return (bool?)this["REVIEWEDEXPECTEDBLOODLOSS"]; }
            set { this["REVIEWEDEXPECTEDBLOODLOSS"] = value; }
        }

    /// <summary>
    /// Ameliyat sırasında gerçekleşebilecek beklenmedik olaylar gözden geçirildi mi?
    /// </summary>
        public bool? ReviewedUnexpectedEvents
        {
            get { return (bool?)this["REVIEWEDUNEXPECTEDEVENTS"]; }
            set { this["REVIEWEDUNEXPECTEDEVENTS"] = value; }
        }

    /// <summary>
    /// Olası anestezi riskleri gözden geçirildi mi?
    /// </summary>
        public bool? ReviewedPossibAnesthesiaRisk
        {
            get { return (bool?)this["REVIEWEDPOSSIBANESTHESIARISK"]; }
            set { this["REVIEWEDPOSSIBANESTHESIARISK"] = value; }
        }

    /// <summary>
    /// Hastanın pozisyonu gözden geçirildi mi?
    /// </summary>
        public bool? ReviewedPatientPosition
        {
            get { return (bool?)this["REVIEWEDPATIENTPOSITION"]; }
            set { this["REVIEWEDPATIENTPOSITION"] = value; }
        }

    /// <summary>
    /// Profilaktik antibiyotik uygulandı mı
    /// </summary>
        public bool? AppliedProphylacticAntibiotic
        {
            get { return (bool?)this["APPLIEDPROPHYLACTICANTIBIOTIC"]; }
            set { this["APPLIEDPROPHYLACTICANTIBIOTIC"] = value; }
        }

    /// <summary>
    /// Kullanılacak malzemeler hazır mı
    /// </summary>
        public bool? ReadyUsedMaterials
        {
            get { return (bool?)this["READYUSEDMATERIALS"]; }
            set { this["READYUSEDMATERIALS"] = value; }
        }

    /// <summary>
    /// Malzemelerin sterilizasyonu uygun mu
    /// </summary>
        public bool? SuitableMaterialSterilization
        {
            get { return (bool?)this["SUITABLEMATERIALSTERILIZATION"]; }
            set { this["SUITABLEMATERIALSTERILIZATION"] = value; }
        }

    /// <summary>
    /// Kan şekeri kontrolü gerekli mi
    /// </summary>
        public bool? NecessaryBloodSugarControl
        {
            get { return (bool?)this["NECESSARYBLOODSUGARCONTROL"]; }
            set { this["NECESSARYBLOODSUGARCONTROL"] = value; }
        }

    /// <summary>
    /// Antikoagülan kullanımı var mı
    /// </summary>
        public bool? HasAnticoagulantUsage
        {
            get { return (bool?)this["HASANTICOAGULANTUSAGE"]; }
            set { this["HASANTICOAGULANTUSAGE"] = value; }
        }

    /// <summary>
    /// Derin ven trombozu profilaksisi gerekli mi
    /// </summary>
        public bool? NecessaryDeepVeinThrombosis
        {
            get { return (bool?)this["NECESSARYDEEPVEINTHROMBOSIS"]; }
            set { this["NECESSARYDEEPVEINTHROMBOSIS"] = value; }
        }

    /// <summary>
    /// Ameliyattan çıkınca hasta sözlü olarak teyit edildi
    /// </summary>
        public bool? ConfirmedPatientVerbally
        {
            get { return (bool?)this["CONFIRMEDPATIENTVERBALLY"]; }
            set { this["CONFIRMEDPATIENTVERBALLY"] = value; }
        }

    /// <summary>
    /// Yapılan ameliyat sözlü olarak teyit edildi
    /// </summary>
        public bool? ConfirmedSurgeryVerbally
        {
            get { return (bool?)this["CONFIRMEDSURGERYVERBALLY"]; }
            set { this["CONFIRMEDSURGERYVERBALLY"] = value; }
        }

    /// <summary>
    /// Ameliyat Bölgesi sözlü olarak teyit edildi
    /// </summary>
        public bool? ConfirmedSurgeryAreaVerbally
        {
            get { return (bool?)this["CONFIRMEDSURGERYAREAVERBALLY"]; }
            set { this["CONFIRMEDSURGERYAREAVERBALLY"] = value; }
        }

    /// <summary>
    /// Alet, spanç/kompres, iğne sayımları yapıldı.
    /// </summary>
        public bool? ToolSpongeNeedleCountsDone
        {
            get { return (bool?)this["TOOLSPONGENEEDLECOUNTSDONE"]; }
            set { this["TOOLSPONGENEEDLECOUNTSDONE"] = value; }
        }

    /// <summary>
    /// Numune etiketinde hastanın adı yazılı
    /// </summary>
        public bool? PatientNameOnSampleLabel
        {
            get { return (bool?)this["PATIENTNAMEONSAMPLELABEL"]; }
            set { this["PATIENTNAMEONSAMPLELABEL"] = value; }
        }

    /// <summary>
    /// Numune etiketinde numunenin alındığı bölge yazılı
    /// </summary>
        public bool? SampleRegionOnSampleLabel
        {
            get { return (bool?)this["SAMPLEREGIONONSAMPLELABEL"]; }
            set { this["SAMPLEREGIONONSAMPLELABEL"] = value; }
        }

    /// <summary>
    /// Ameliyat Sonrası Kritik Gereksinimler - Anestezistin Önerileri
    /// </summary>
        public string AnesthetistSuggestions
        {
            get { return (string)this["ANESTHETISTSUGGESTIONS"]; }
            set { this["ANESTHETISTSUGGESTIONS"] = value; }
        }

    /// <summary>
    /// Ameliyat Sonrası Kritik Gereksinimler - Cerrahın Önerileri
    /// </summary>
        public string SurgeonSuggestions
        {
            get { return (string)this["SURGEONSUGGESTIONS"]; }
            set { this["SURGEONSUGGESTIONS"] = value; }
        }

    /// <summary>
    /// Hastanın ameliyat sonrası gideceği bölüm teyit edildi mi?
    /// </summary>
        public bool? ConfirmedAfterSurgeryClinic
        {
            get { return (bool?)this["CONFIRMEDAFTERSURGERYCLINIC"]; }
            set { this["CONFIRMEDAFTERSURGERYCLINIC"] = value; }
        }

    /// <summary>
    /// Hastanın kıyafetleri hazır değilse açıklama
    /// </summary>
        public string PatientClothesDescription
        {
            get { return (string)this["PATIENTCLOTHESDESCRIPTION"]; }
            set { this["PATIENTCLOTHESDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Ekipten bir kişi sesli olarak hastanın kimliğini, yapılan ameliyatı, ameliyat bölgesini teyit etti mi?
    /// </summary>
        public bool? TeamMemberInformedVerbally
        {
            get { return (bool?)this["TEAMMEMBERINFORMEDVERBALLY"]; }
            set { this["TEAMMEMBERINFORMEDVERBALLY"] = value; }
        }

    /// <summary>
    /// BeforeLeavingClinic Klinik Hemşiresi
    /// </summary>
        public ResUser ClinicalNurse
        {
            get { return (ResUser)((ITTObject)this).GetParent("CLINICALNURSE"); }
            set { this["CLINICALNURSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// BeforeLeavingSurgery Ameliyathane Hemşiresi
    /// </summary>
        public ResUser OperatingRoomNurse
        {
            get { return (ResUser)((ITTObject)this).GetParent("OPERATINGROOMNURSE"); }
            set { this["OPERATINGROOMNURSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// BeforeSurgicalIncision Ameliyatı Yapan Doktor
    /// </summary>
        public ResUser SurgeryDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("SURGERYDOCTOR"); }
            set { this["SURGERYDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// BeforeAnesthesia Anestezi Doktoru
    /// </summary>
        public ResUser Anesthesiologist
        {
            get { return (ResUser)((ITTObject)this).GetParent("ANESTHESIOLOGIST"); }
            set { this["ANESTHESIOLOGIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSurgeryCollection()
        {
            _Surgery = new Surgery.ChildSurgeryCollection(this, new Guid("dc00ce1c-764d-47b4-aab1-a8db6f328efb"));
            ((ITTChildObjectCollection)_Surgery).GetChildren();
        }

        protected Surgery.ChildSurgeryCollection _Surgery = null;
    /// <summary>
    /// Child collection for Güvenli Cerrahi Kontrol Listesi
    /// </summary>
        public Surgery.ChildSurgeryCollection Surgery
        {
            get
            {
                if (_Surgery == null)
                    CreateSurgeryCollection();
                return _Surgery;
            }
        }

        protected SafeSurgeryCheckList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SafeSurgeryCheckList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SafeSurgeryCheckList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SafeSurgeryCheckList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SafeSurgeryCheckList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SAFESURGERYCHECKLIST", dataRow) { }
        protected SafeSurgeryCheckList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SAFESURGERYCHECKLIST", dataRow, isImported) { }
        public SafeSurgeryCheckList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SafeSurgeryCheckList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SafeSurgeryCheckList() : base() { }

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