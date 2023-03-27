using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingReasonGridConfig : IEntityTypeConfiguration<AtlasModel.NursingReasonGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingReasonGrid> builder)
        {
            builder.ToTable("NURSINGREASONGRID");
            builder.HasKey(nameof(AtlasModel.NursingReasonGrid.ObjectId));
            builder.Property(nameof(AtlasModel.NursingReasonGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingReasonGrid.NursingReasonRef)).HasColumnName("NURSINGREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingReasonGrid.NursingNandaRef)).HasColumnName("NURSINGNANDA").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.NursingReason).WithOne().HasForeignKey<AtlasModel.NursingReasonGrid>(x => x.NursingReasonRef).IsRequired(false);
            builder.HasOne(t => t.NursingNanda).WithOne().HasForeignKey<AtlasModel.NursingReasonGrid>(x => x.NursingNandaRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}