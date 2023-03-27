using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReturnDescriptionsGridConfig : IEntityTypeConfiguration<AtlasModel.ReturnDescriptionsGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReturnDescriptionsGrid> builder)
        {
            builder.ToTable("RETURNDESCRIPTIONSGRID");
            builder.HasKey(nameof(AtlasModel.ReturnDescriptionsGrid.ObjectId));
            builder.Property(nameof(AtlasModel.ReturnDescriptionsGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReturnDescriptionsGrid.EntryDate)).HasColumnName("ENTRYDATE");
            builder.Property(nameof(AtlasModel.ReturnDescriptionsGrid.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ReturnDescriptionsGrid.UserName)).HasColumnName("USERNAME").HasMaxLength(50);
        }
    }
}