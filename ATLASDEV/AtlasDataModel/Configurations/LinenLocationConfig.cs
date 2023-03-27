using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LinenLocationConfig : IEntityTypeConfiguration<AtlasModel.LinenLocation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LinenLocation> builder)
        {
            builder.ToTable("LINENLOCATION");
            builder.HasKey(nameof(AtlasModel.LinenLocation.ObjectId));
            builder.Property(nameof(AtlasModel.LinenLocation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LinenLocation.IntegrationCode)).HasColumnName("INTEGRATIONCODE");
            builder.Property(nameof(AtlasModel.LinenLocation.Location)).HasColumnName("LOCATION");
            builder.Property(nameof(AtlasModel.LinenLocation.MahalNo)).HasColumnName("MAHALNO");
        }
    }
}