using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientIdentityAndAddress
    {
        public Guid ObjectId { get; set; }
        public string BusinessPostcode { get; set; }
        public string BusinessPhone { get; set; }
        public string BusinessAddress { get; set; }
        public string ForeignAddress { get; set; }
        public string ForeignCity { get; set; }
        public string ForeignCountry { get; set; }
        public string BuildingSheet { get; set; }
        public string BuildingParcel { get; set; }
        public string BuildingNo { get; set; }
        public string BuildingCode { get; set; }
        public string BuildingBlockName { get; set; }
        public string BuildingSquare { get; set; }
        public string AddressNo { get; set; }
        public string SiteName { get; set; }
        public string HomeAddress { get; set; }
        public string DisKapi { get; set; }
        public string HomePhone { get; set; }
        public string HomePostcode { get; set; }
        public string IcKapi { get; set; }
        public string MobilePhone { get; set; }
        public string SKRSAcikAdresIlce { get; set; }
        public string SKRSAdresKodu { get; set; }
        public string RelativeMobilePhone { get; set; }
        public string RelativeHomeAddress { get; set; }
        public string RelativeFullName { get; set; }
        public string VemHastaIletisimKodu { get; set; }
        public Guid? HomeCityRef { get; set; }
        public Guid? HomeCountryRef { get; set; }
        public Guid? SKRSAdresKoduSeviyesiRef { get; set; }
        public Guid? SKRSAdresTipiRef { get; set; }
        public Guid? SKRSIlceKodlariRef { get; set; }
        public Guid? SKRSILKodlariRef { get; set; }
        public Guid? SKRSKoyKodlariRef { get; set; }
        public Guid? SKRSMahalleKodlariRef { get; set; }
        public Guid? BusinessCityRef { get; set; }
        public Guid? BusinessCountryRef { get; set; }
        public Guid? SKRSBucakKoduRef { get; set; }
        public Guid? SKRSCsbmKoduRef { get; set; }
        public Guid? BusinessTownRef { get; set; }
        public Guid? HomeTownRef { get; set; }

        #region Parent Relations
        public virtual SKRSIlceKodlari SKRSIlceKodlari { get; set; }
        public virtual SKRSMahalleKodlari SKRSMahalleKodlari { get; set; }
        public virtual SKRSIlceKodlari BusinessTown { get; set; }
        public virtual SKRSIlceKodlari HomeTown { get; set; }
        #endregion Parent Relations
    }
}