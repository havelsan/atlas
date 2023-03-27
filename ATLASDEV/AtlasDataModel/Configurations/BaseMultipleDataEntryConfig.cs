using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseMultipleDataEntryConfig : IEntityTypeConfiguration<AtlasModel.BaseMultipleDataEntry>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseMultipleDataEntry> builder)
        {
            builder.ToTable("BASEMULTIPLEDATAENTRY");
            builder.HasKey(nameof(AtlasModel.BaseMultipleDataEntry.ObjectId));
            builder.Property(nameof(AtlasModel.BaseMultipleDataEntry.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseMultipleDataEntry.EntryDate)).HasColumnName("ENTRYDATE");
            builder.Property(nameof(AtlasModel.BaseMultipleDataEntry.EntryUserRef)).HasColumnName("ENTRYUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseMultipleDataEntry.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EntryUser).WithOne().HasForeignKey<AtlasModel.BaseMultipleDataEntry>(x => x.EntryUserRef).IsRequired(false);
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.BaseMultipleDataEntry>(x => x.EpisodeActionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}