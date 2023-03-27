using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingCareGridConfig : IEntityTypeConfiguration<AtlasModel.NursingCareGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingCareGrid> builder)
        {
            builder.ToTable("NURSINGCAREGRID");
            builder.HasKey(nameof(AtlasModel.NursingCareGrid.ObjectId));
            builder.Property(nameof(AtlasModel.NursingCareGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingCareGrid.NursingCareRef)).HasColumnName("NURSINGCARE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingCareGrid.NursingNandaRef)).HasColumnName("NURSINGNANDA").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.NursingCare).WithOne().HasForeignKey<AtlasModel.NursingCareGrid>(x => x.NursingCareRef).IsRequired(false);
            builder.HasOne(t => t.NursingNanda).WithOne().HasForeignKey<AtlasModel.NursingCareGrid>(x => x.NursingNandaRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}