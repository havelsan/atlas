using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingPainScaleConfig : IEntityTypeConfiguration<AtlasModel.NursingPainScale>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingPainScale> builder)
        {
            builder.ToTable("NURSINGPAINSCALE");
            builder.HasKey(nameof(AtlasModel.NursingPainScale.ObjectId));
            builder.Property(nameof(AtlasModel.NursingPainScale.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingPainScale.NursingAppDoneDate)).HasColumnName("NURSINGAPPDONEDATE");
            builder.Property(nameof(AtlasModel.NursingPainScale.PostNursingInitiative)).HasColumnName("POSTNURSINGINITIATIVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingPainScale.PainDetail)).HasColumnName("PAINDETAIL").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.NursingPainScale.PainTime)).HasColumnName("PAINTIME").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.NursingPainScale.DurationofPain)).HasColumnName("DURATIONOFPAIN").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.NursingPainScale.AchingSide)).HasColumnName("ACHINGSIDE");
            builder.Property(nameof(AtlasModel.NursingPainScale.PainQualityDescription)).HasColumnName("PAINQUALITYDESCRIPTION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.NursingPainScale.PainFaceScale)).HasColumnName("PAINFACESCALE").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}