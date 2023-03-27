using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SEPMasterConfig : IEntityTypeConfiguration<AtlasModel.SEPMaster>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SEPMaster> builder)
        {
            builder.ToTable("SEPMASTER");
            builder.HasKey(nameof(AtlasModel.SEPMaster.ObjectId));
            builder.Property(nameof(AtlasModel.SEPMaster.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
        }
    }
}