using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class WomanSpecialityObjectConfig : IEntityTypeConfiguration<AtlasModel.WomanSpecialityObject>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.WomanSpecialityObject> builder)
        {
            builder.ToTable("WOMANSPECIALITYOBJECT");
            builder.HasKey(nameof(AtlasModel.WomanSpecialityObject.ObjectId));
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.RhIncompatibility)).HasColumnName("RHINCOMPATIBILITY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.DegreeOfRelationship)).HasColumnName("DEGREEOFRELATIONSHIP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.HusbandBloodGroup)).HasColumnName("HUSBANDBLOODGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.NumberOfPregnancy)).HasColumnName("NUMBEROFPREGNANCY");
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.Parity)).HasColumnName("PARITY");
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.Abortion)).HasColumnName("ABORTION");
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.LivingBabies)).HasColumnName("LIVINGBABIES");
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.DC)).HasColumnName("DC");
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.HusbandFullName)).HasColumnName("HUSBANDFULLNAME").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.MarriageDate)).HasColumnName("MARRIAGEDATE");
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.WomanBloodGroup)).HasColumnName("WOMANBLOODGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.InfertilityRef)).HasColumnName("INFERTILITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.PregnancyFollowRef)).HasColumnName("PREGNANCYFOLLOW").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.GynecologyRef)).HasColumnName("GYNECOLOGY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.HusbandRef)).HasColumnName("HUSBAND").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.WomanSpecialityObject.PregnantInformationRef)).HasColumnName("PREGNANTINFORMATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SpecialityBasedObject).WithOne().HasForeignKey<AtlasModel.SpecialityBasedObject>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Gynecology).WithOne().HasForeignKey<AtlasModel.WomanSpecialityObject>(x => x.GynecologyRef).IsRequired(false);
            builder.HasOne(t => t.Husband).WithOne().HasForeignKey<AtlasModel.WomanSpecialityObject>(x => x.HusbandRef).IsRequired(false);
            builder.HasOne(t => t.PregnantInformation).WithOne().HasForeignKey<AtlasModel.WomanSpecialityObject>(x => x.PregnantInformationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}