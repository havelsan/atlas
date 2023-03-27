using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AllocationConfig : IEntityTypeConfiguration<AtlasModel.Allocation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Allocation> builder)
        {
            builder.ToTable("ALLOCATION");
            builder.HasKey(nameof(AtlasModel.Allocation.ObjectId));
            builder.Property(nameof(AtlasModel.Allocation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Allocation.AllocateDate)).HasColumnName("ALLOCATEDATE");
            builder.Property(nameof(AtlasModel.Allocation.DeallocateDate)).HasColumnName("DEALLOCATEDATE");
            builder.Property(nameof(AtlasModel.Allocation.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Allocation.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Allocation.SpecialityRef)).HasColumnName("SPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Allocation.SubActionProcedureRef)).HasColumnName("SUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.Allocation>(x => x.EpisodeActionRef).IsRequired(false);
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.Allocation>(x => x.EpisodeRef).IsRequired(false);
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.Allocation>(x => x.SubActionProcedureRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}