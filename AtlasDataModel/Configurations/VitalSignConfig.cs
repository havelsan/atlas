using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class VitalSignConfig : IEntityTypeConfiguration<AtlasModel.VitalSign>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.VitalSign> builder)
        {
            builder.ToTable("VITALSIGNS");
            builder.HasKey(nameof(AtlasModel.VitalSign.ObjectId));
            builder.Property(nameof(AtlasModel.VitalSign.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.VitalSign.ExecutionDate)).HasColumnName("EXECUTIONDATE");
            builder.Property(nameof(AtlasModel.VitalSign.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VitalSign.SubActionProcedureRef)).HasColumnName("SUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.VitalSign>(x => x.EpisodeActionRef).IsRequired(false);
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.VitalSign>(x => x.SubActionProcedureRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}