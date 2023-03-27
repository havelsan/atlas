using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace Core.Models
{
    public class SMSFormViewModel
    {
        public List<IstisnaiHal> IstisnaiHalDataSource { get; set; } = new List<IstisnaiHal>();
        public List<SKRSIlDTO> SKRSIlDataSource { get; set; } = new List<SKRSIlDTO>();
        public List<ProvizyonTipi> ProvizyonTipiDataSource { get; set; } = new List<ProvizyonTipi>();
        public List<SpecialityDefinitionDTO> SpecialityDefDataSource { get; set; } = new List<SpecialityDefinitionDTO>();
        public List<TedaviTuru> TedaviTuruDataSource { get; set; } = new List<TedaviTuru>();
    }

    #region Personel SMS Modeli
    public class SMSPersonnelFormViewModel
    {
        public List<SpecialityDefinition> SpecialityDataSource { get; set; } = new List<SpecialityDefinition>();
        public SMSPersonnelSearchModel PersonnelSearcModel { get; set; } = new SMSPersonnelSearchModel();
        public string SMSText;
    }

    public class SpecialityDefinitionDTO
    {
        public string Name { get; set; }
        public string Name_LowerCase { get; set; }
        public string Name_UpperCase { get; set; }
        public string Name_Shadow { get; set; }
        public Guid ObjectID { get; set; }
        public string Code { get; set; }

    }

    public class SMSPersonnelGridViewModel
    {
        //ResUser ObjectID
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string WorkStatus { get; set; }
        //ResUser daki Work alanı
        public string Position { get; set; }
    }

    public class SMSPersonnelSearchModel
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int? WorkStatus { get; set; } = null;
        public int? Gender { get; set; } = null;
        public DateTime? BirthDate { get; set; } = null;
        public int? Title { get; set; } = null;
        public bool? HasPhoneNumber { get; set; } = true;
        public List<int> SelectedOccupations { get; set; } = new List<int>();
        //Doğum yeri şehir listesi
        public List<Guid> SelectedCitiesObjectIDs { get; set; } = new List<Guid>();
        //Görev yeri listesi
        public List<Guid> SelectedResourcesObjectIDs { get; set; } = new List<Guid>();
        public List<Guid> SelectedSpecialityObjectIDs { get; set; } = new List<Guid>();
    }
    #endregion Personel SMS Modeli

    #region Hasta SMS Modeli
    public class SMSPatientFormViewModel
    {
        public SMSPatientSearchModel PatientSearcModel { get; set; } = new SMSPatientSearchModel();
        public string SMSText;
    }

    public class SMSPatientGridViewModel
    {
        //Patient ObjectID
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string UniqueRefNo { get; set; }
    }

    public class SMSPatientSearchModel
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int? Gender { get; set; } = null;
        public DateTime? BirthDate { get; set; } = null;
        public bool? HasPhoneNumber { get; set; } = true;
        public Guid? SelectedCityOfBirthPlace { get; set; }
        // Doğum yeri İlçesi
        public Guid? SelectedCountyOfBirthPlace { get; set; }
        //Adres İl
        public Guid? SelectedCityOfAddress { get; set; }
        //Adres İlçe
        public Guid? SelectedCountyOfAddress { get; set; }
        //Uyruk
        public Guid? Nationality { get; set; }
        //Kurum
        public List<Guid> SelectedPayers { get; set; }
        //Geliş sebebi
        public List<Guid> SelectedProvizyonTipi { get; set; }
        //İstisnai Hal
        public List<Guid> SelectedIstisnaiHal { get; set; }
        //Tanı
        public List<Guid> SelectedDiagnosis { get; set; }
        //Tedavi Türü
        public Guid? SelectedTreatment { get; set; }
        //Kabul tarihi başlangıç
        public DateTime? AdmissionStartDate { get; set; }
        //Kabul tarihi bitiş
        public DateTime? AdmissionEndDate { get; set; }
        //Yatış tarihi başlangıç
        public DateTime? InPatientStartDate { get; set; }
        //Yatış tarihi başlangıç
        public DateTime? InPatientEndDate { get; set; }
        public List<Guid> SelectedAdmissionDoctor { get; set; }
        public List<Guid> SelectedSpecialities { get; set; }
        public List<Guid> SelectedPoliclinics { get; set; }
    }
    #endregion Hasta SMS Modeli

    public class ResourceDTO
    {
        public string Name { get; set; }
        public string Name_Shadow { get; set; }
        public Guid ObjectId { get; set; }
    }

    public class SKRSIlDTO
    {
        public string ADI_LowerCase { get; set; }
        public string ADI_UpperCase { get; set; }

        public int? KODU { get; set; }
        public Guid ObjectID { get; set; }
        public string ADI { get; set; }
    }

    public class DiagnosisDefinitionDTO
    {
        public string Code { get; set; }
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public string Name_Shadow { get; set; }
    }

    public class SKRSIlceDTO
    {
        public int? ILKODU { get; set; }
        public int? KODU { get; set; }
        public Guid? ObjectID { get; set; }
        public string ADI { get; set; }
    }

    public class SendPersonnelSMSModel
    {
        public List<SMSPersonnelGridViewModel> SMSModel { get; set; }
        public string SMSText { get; set; }
        public SMSTypeEnum? SMSType { get; set; }
    }

    public class SendPatientSMSModel
    {
        public List<SMSPatientGridViewModel> SMSModel { get; set; }
        public string SMSText { get; set; }
        public SMSTypeEnum? smsType { get; set; }
    }

    public enum SendSMSResultEnum
    {
        Successful = 0,
        UnSuccessful = 1,
        Cancelled = 2
    }
}
