using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PersonConfig : IEntityTypeConfiguration<AtlasModel.Person>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Person> builder)
        {
            builder.ToTable("PERSON");
            builder.HasKey(nameof(AtlasModel.Person.ObjectId));
            builder.Property(nameof(AtlasModel.Person.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Person.IdentificationSeriesNo)).HasColumnName("IDENTIFICATIONSERIESNO").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.Person.MotherName)).HasColumnName("MOTHERNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.FamilyNo)).HasColumnName("FAMILYNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.OtherBirthPlace)).HasColumnName("OTHERBIRTHPLACE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.Surname)).HasColumnName("SURNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.Name)).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.FatherName)).HasColumnName("FATHERNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.VillageOfRegistry)).HasColumnName("VILLAGEOFREGISTRY").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Person.IdentificationCardNo)).HasColumnName("IDENTIFICATIONCARDNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.NameIsUpdated)).HasColumnName("NAMEISUPDATED");
            builder.Property(nameof(AtlasModel.Person.IdentificationVolumeNo)).HasColumnName("IDENTIFICATIONVOLUMENO").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.Person.SurnameIsUpdated)).HasColumnName("SURNAMEISUPDATED");
            builder.Property(nameof(AtlasModel.Person.BDYearOnly)).HasColumnName("BDYEARONLY");
            builder.Property(nameof(AtlasModel.Person.IdentificationCardSerialNo)).HasColumnName("IDENTIFICATIONCARDSERIALNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.ForeignUniqueRefNo)).HasColumnName("FOREIGNUNIQUEREFNO").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.Person.BirthDate)).HasColumnName("BIRTHDATE");
            builder.Property(nameof(AtlasModel.Person.ExDate)).HasColumnName("EXDATE");
            builder.Property(nameof(AtlasModel.Person.UniqueRefNo)).HasColumnName("UNIQUEREFNO");
            builder.Property(nameof(AtlasModel.Person.PassportNo)).HasColumnName("PASSPORTNO");
            builder.Property(nameof(AtlasModel.Person.IdentificationGivenTown)).HasColumnName("IDENTIFICATIONGIVENTOWN").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.IdentificationGivenReason)).HasColumnName("IDENTIFICATIONGIVENREASON").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.Person.IdentificationGivenDate)).HasColumnName("IDENTIFICATIONGIVENDATE");
            builder.Property(nameof(AtlasModel.Person.BirthPlace)).HasColumnName("BIRTHPLACE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.MobilePhone)).HasColumnName("MOBILEPHONE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.DeathReportNo)).HasColumnName("DEATHREPORTNO");
            builder.Property(nameof(AtlasModel.Person.PrivacyUniqueRefNo)).HasColumnName("PRIVACYUNIQUEREFNO");
            builder.Property(nameof(AtlasModel.Person.HomePhone)).HasColumnName("HOMEPHONE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Person.TownOfBirthSKRSRef)).HasColumnName("TOWNOFBIRTHSKRS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Person.CityOfBirthRef)).HasColumnName("CITYOFBIRTH").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Person.CountryOfBirthRef)).HasColumnName("COUNTRYOFBIRTH").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Person.TownOfBirthRef)).HasColumnName("TOWNOFBIRTH").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Person.TownOfRegistryRef)).HasColumnName("TOWNOFREGISTRY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Person.CityOfRegistryRef)).HasColumnName("CITYOFREGISTRY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Person.NationalityRef)).HasColumnName("NATIONALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Person.TownOfRegistrySKRSRef)).HasColumnName("TOWNOFREGISTRYSKRS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Person.SexRef)).HasColumnName("SEX").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Person.SKRSMaritalStatusRef)).HasColumnName("SKRSMARITALSTATUS").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.TownOfBirthSKRS).WithOne().HasForeignKey<AtlasModel.Person>(x => x.TownOfBirthSKRSRef).IsRequired(false);
            builder.HasOne(t => t.TownOfRegistrySKRS).WithOne().HasForeignKey<AtlasModel.Person>(x => x.TownOfRegistrySKRSRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}