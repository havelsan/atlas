using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class FTRPackageProcedureConfig : IEntityTypeConfiguration<AtlasModel.FTRPackageProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.FTRPackageProcedure> builder)
        {
            builder.ToTable("FTRPACKAGEPROCEDURE");
            builder.HasKey(nameof(AtlasModel.FTRPackageProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.FTRPackageProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.FTRPackageProcedure.PhysiotherapyOrderDetailRef)).HasColumnName("PHYSIOTHERAPYORDERDETAIL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionPackageProcedure).WithOne().HasForeignKey<AtlasModel.SubActionPackageProcedure>(p => p.ObjectId);
        }
    }
}