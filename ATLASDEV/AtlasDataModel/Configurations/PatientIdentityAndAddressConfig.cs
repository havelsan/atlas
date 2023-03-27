using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientIdentityAndAddressConfig : IEntityTypeConfiguration<AtlasModel.PatientIdentityAndAddress>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientIdentityAndAddress> builder)
        {
            builder.ToTable("PATIENTADDRESS");
            builder.HasKey(nameof(AtlasModel.PatientIdentityAndAddress.ObjectId));
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BusinessPostcode)).HasColumnName("BUSINESSPOSTCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BusinessPhone)).HasColumnName("BUSINESSPHONE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BusinessAddress)).HasColumnName("BUSINESSADDRESS").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.ForeignAddress)).HasColumnName("FOREIGNADDRESS").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.ForeignCity)).HasColumnName("FOREIGNCITY").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.ForeignCountry)).HasColumnName("FOREIGNCOUNTRY").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BuildingSheet)).HasColumnName("BUILDINGSHEET").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BuildingParcel)).HasColumnName("BUILDINGPARCEL").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BuildingNo)).HasColumnName("BUILDINGNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BuildingCode)).HasColumnName("BUILDINGCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BuildingBlockName)).HasColumnName("BUILDINGBLOCKNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BuildingSquare)).HasColumnName("BUILDINGSQUARE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.AddressNo)).HasColumnName("ADDRESSNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.SiteName)).HasColumnName("SITENAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.HomeAddress)).HasColumnName("HOMEADDRESS").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.DisKapi)).HasColumnName("DISKAPI").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.HomePhone)).HasColumnName("HOMEPHONE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.HomePostcode)).HasColumnName("HOMEPOSTCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.IcKapi)).HasColumnName("ICKAPI").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.MobilePhone)).HasColumnName("MOBILEPHONE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.SKRSAcikAdresIlce)).HasColumnName("SKRSACIKADRESILCE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.SKRSAdresKodu)).HasColumnName("SKRSADRESKODU").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.RelativeMobilePhone)).HasColumnName("RELATIVEMOBILEPHONE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.RelativeHomeAddress)).HasColumnName("RELATIVEHOMEADDRESS").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.RelativeFullName)).HasColumnName("RELATIVEFULLNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.VemHastaIletisimKodu)).HasColumnName("VEMHASTAILETISIMKODU").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.HomeCityRef)).HasColumnName("HOMECITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.HomeCountryRef)).HasColumnName("HOMECOUNTRY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.SKRSAdresKoduSeviyesiRef)).HasColumnName("SKRSADRESKODUSEVIYESI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.SKRSAdresTipiRef)).HasColumnName("SKRSADRESTIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.SKRSIlceKodlariRef)).HasColumnName("SKRSILCEKODLARI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.SKRSILKodlariRef)).HasColumnName("SKRSILKODLARI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.SKRSKoyKodlariRef)).HasColumnName("SKRSKOYKODLARI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.SKRSMahalleKodlariRef)).HasColumnName("SKRSMAHALLEKODLARI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BusinessCityRef)).HasColumnName("BUSINESSCITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BusinessCountryRef)).HasColumnName("BUSINESSCOUNTRY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.SKRSBucakKoduRef)).HasColumnName("SKRSBUCAKKODU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.SKRSCsbmKoduRef)).HasColumnName("SKRSCSBMKODU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.BusinessTownRef)).HasColumnName("BUSINESSTOWN").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientIdentityAndAddress.HomeTownRef)).HasColumnName("HOMETOWN").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SKRSIlceKodlari).WithOne().HasForeignKey<AtlasModel.PatientIdentityAndAddress>(x => x.SKRSIlceKodlariRef).IsRequired(false);
            builder.HasOne(t => t.SKRSMahalleKodlari).WithOne().HasForeignKey<AtlasModel.PatientIdentityAndAddress>(x => x.SKRSMahalleKodlariRef).IsRequired(false);
            builder.HasOne(t => t.BusinessTown).WithOne().HasForeignKey<AtlasModel.PatientIdentityAndAddress>(x => x.BusinessTownRef).IsRequired(false);
            builder.HasOne(t => t.HomeTown).WithOne().HasForeignKey<AtlasModel.PatientIdentityAndAddress>(x => x.HomeTownRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}