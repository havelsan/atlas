using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LinenGroupConfig : IEntityTypeConfiguration<AtlasModel.LinenGroup>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LinenGroup> builder)
        {
            builder.ToTable("LINENGROUP");
            builder.HasKey(nameof(AtlasModel.LinenGroup.ObjectId));
            builder.Property(nameof(AtlasModel.LinenGroup.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LinenGroup.Name)).HasColumnName("NAME");
            builder.Property(nameof(AtlasModel.LinenGroup.IntegrationCode)).HasColumnName("INTEGRATIONCODE");
        }
    }
}