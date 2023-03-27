using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HealthCommitteeProcedureConfig : IEntityTypeConfiguration<AtlasModel.HealthCommitteeProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.HealthCommitteeProcedure> builder)
        {
            builder.ToTable("HEALTHCOMMITTEEPROCEDURE");
            builder.HasKey(nameof(AtlasModel.HealthCommitteeProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.HealthCommitteeProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.HealthCommitteeProcedure.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.HealthCommitteeProcedure>(x => x.OzelDurumRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}