using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PregnantInformationConfig : IEntityTypeConfiguration<AtlasModel.PregnantInformation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PregnantInformation> builder)
        {
            builder.ToTable("PREGNANTINFORMATION");
            builder.HasKey(nameof(AtlasModel.PregnantInformation.ObjectId));
            builder.Property(nameof(AtlasModel.PregnantInformation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PregnantInformation.PregnancyNumber)).HasColumnName("PREGNANCYNUMBER");
            builder.Property(nameof(AtlasModel.PregnantInformation.Parity)).HasColumnName("PARITY");
            builder.Property(nameof(AtlasModel.PregnantInformation.Abortions)).HasColumnName("ABORTIONS");
            builder.Property(nameof(AtlasModel.PregnantInformation.DC)).HasColumnName("DC");
            builder.Property(nameof(AtlasModel.PregnantInformation.UIEX)).HasColumnName("UIEX");
            builder.Property(nameof(AtlasModel.PregnantInformation.NumberOfLivingChildren)).HasColumnName("NUMBEROFLIVINGCHILDREN");
        }
    }
}