using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HealthCommitteeExaminationProcedureConfig : IEntityTypeConfiguration<AtlasModel.HealthCommitteeExaminationProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.HealthCommitteeExaminationProcedure> builder)
        {
            builder.ToTable("HCEXAMINATIONPROCEDURE");
            builder.HasKey(nameof(AtlasModel.HealthCommitteeExaminationProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.HealthCommitteeExaminationProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.HealthCommitteeExaminationProcedure.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.HealthCommitteeExaminationProcedure>(x => x.OzelDurumRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}