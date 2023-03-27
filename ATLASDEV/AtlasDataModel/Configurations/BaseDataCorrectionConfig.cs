using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseDataCorrectionConfig : IEntityTypeConfiguration<AtlasModel.BaseDataCorrection>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseDataCorrection> builder)
        {
            builder.ToTable("BASEDATACORRECTION");
            builder.HasKey(nameof(AtlasModel.BaseDataCorrection.ObjectId));
            builder.Property(nameof(AtlasModel.BaseDataCorrection.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseAction).WithOne().HasForeignKey<AtlasModel.BaseAction>(p => p.ObjectId);
        }
    }
}