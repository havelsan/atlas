using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Person
    {
        public Guid ObjectId { get; set; }
        public string IdentificationSeriesNo { get; set; }
        public string MotherName { get; set; }
        public string FamilyNo { get; set; }
        public string OtherBirthPlace { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string VillageOfRegistry { get; set; }
        public string IdentificationCardNo { get; set; }
        public bool? NameIsUpdated { get; set; }
        public string IdentificationVolumeNo { get; set; }
        public bool? SurnameIsUpdated { get; set; }
        public bool? BDYearOnly { get; set; }
        public string IdentificationCardSerialNo { get; set; }
        public double? ForeignUniqueRefNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? ExDate { get; set; }
        public long? UniqueRefNo { get; set; }
        public string PassportNo { get; set; }
        public string IdentificationGivenTown { get; set; }
        public string IdentificationGivenReason { get; set; }
        public DateTime? IdentificationGivenDate { get; set; }
        public string BirthPlace { get; set; }
        public string MobilePhone { get; set; }
        public int? DeathReportNo { get; set; }
        public long? PrivacyUniqueRefNo { get; set; }
        public string HomePhone { get; set; }
        public Guid? TownOfBirthSKRSRef { get; set; }
        public Guid? CityOfBirthRef { get; set; }
        public Guid? CountryOfBirthRef { get; set; }
        public Guid? TownOfBirthRef { get; set; }
        public Guid? TownOfRegistryRef { get; set; }
        public Guid? CityOfRegistryRef { get; set; }
        public Guid? NationalityRef { get; set; }
        public Guid? TownOfRegistrySKRSRef { get; set; }
        public Guid? SexRef { get; set; }
        public Guid? SKRSMaritalStatusRef { get; set; }

        #region Parent Relations
        public virtual SKRSIlceKodlari TownOfBirthSKRS { get; set; }
        public virtual SKRSIlceKodlari TownOfRegistrySKRS { get; set; }
        #endregion Parent Relations
    }
}