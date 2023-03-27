using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BedProcedureConfig : IEntityTypeConfiguration<AtlasModel.BedProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BedProcedure> builder)
        {
            builder.ToTable("BEDPROCEDURE");
            builder.HasKey(nameof(AtlasModel.BedProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.BedProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BedProcedure.BaseBedProcedureRef)).HasColumnName("BASEBEDPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.BaseBedProcedure).WithOne().HasForeignKey<AtlasModel.BedProcedure>(x => x.BaseBedProcedureRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}