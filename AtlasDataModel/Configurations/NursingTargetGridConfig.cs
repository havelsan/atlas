using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingTargetGridConfig : IEntityTypeConfiguration<AtlasModel.NursingTargetGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingTargetGrid> builder)
        {
            builder.ToTable("NURSINGTARGETGRID");
            builder.HasKey(nameof(AtlasModel.NursingTargetGrid.ObjectId));
            builder.Property(nameof(AtlasModel.NursingTargetGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingTargetGrid.NursingTargetRef)).HasColumnName("NURSINGTARGET").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingTargetGrid.NursingNandaRef)).HasColumnName("NURSINGNANDA").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.NursingTarget).WithOne().HasForeignKey<AtlasModel.NursingTargetGrid>(x => x.NursingTargetRef).IsRequired(false);
            builder.HasOne(t => t.NursingNanda).WithOne().HasForeignKey<AtlasModel.NursingTargetGrid>(x => x.NursingNandaRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}