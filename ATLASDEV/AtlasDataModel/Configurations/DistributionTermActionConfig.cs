using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DistributionTermActionConfig : IEntityTypeConfiguration<AtlasModel.DistributionTermAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DistributionTermAction> builder)
        {
            builder.ToTable("DISTRIBUTIONTERMACTION");
            builder.HasKey(nameof(AtlasModel.DistributionTermAction.ObjectId));
            builder.Property(nameof(AtlasModel.DistributionTermAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DistributionTermAction.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DistributionTermAction.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.DistributionTermAction.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.DistributionTermAction.CloseTermRef)).HasColumnName("CLOSETERM").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseAction).WithOne().HasForeignKey<AtlasModel.BaseAction>(p => p.ObjectId);
        }
    }
}