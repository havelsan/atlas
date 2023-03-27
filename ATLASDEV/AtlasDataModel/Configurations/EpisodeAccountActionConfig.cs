using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EpisodeAccountActionConfig : IEntityTypeConfiguration<AtlasModel.EpisodeAccountAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EpisodeAccountAction> builder)
        {
            builder.ToTable("EPISODEACCOUNTACTION");
            builder.HasKey(nameof(AtlasModel.EpisodeAccountAction.ObjectId));
            builder.Property(nameof(AtlasModel.EpisodeAccountAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EpisodeAccountAction.TotalDiscountPrice)).HasColumnName("TOTALDISCOUNTPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.EpisodeAccountAction.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.EpisodeAccountAction.CashOfficeName)).HasColumnName("CASHOFFICENAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.EpisodeAccountAction.GeneralTotalPrice)).HasColumnName("GENERALTOTALPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.EpisodeAccountAction.TotalPrice)).HasColumnName("TOTALPRICE").HasColumnType("NUMBER(15,2)");
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);
        }
    }
}