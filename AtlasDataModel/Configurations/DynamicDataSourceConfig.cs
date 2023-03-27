using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicDataSourceConfig : IEntityTypeConfiguration<AtlasModel.DynamicDataSource>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicDataSource> builder)
        {
            builder.ToTable("DYNAMICDATASOURCE");
            builder.HasKey(nameof(AtlasModel.DynamicDataSource.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicDataSource.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicDataSource.Name)).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.DynamicDataSource.Type)).HasColumnName("TYPE");
            builder.Property(nameof(AtlasModel.DynamicDataSource.ApiConfig)).HasColumnName("APICONFIG").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.DynamicDataSource.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.DynamicDataSource.IsActive)).HasColumnName("ISACTIVE");
        }
    }
}