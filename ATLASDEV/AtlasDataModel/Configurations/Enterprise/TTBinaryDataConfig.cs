using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTBinaryDataConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTBinaryData>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTBinaryData> builder)
        {
            builder.HasKey(t => t.DataId);
            builder.Property(t => t.DataId).HasColumnName("DATAID").HasMaxLength(36);
            builder.Property(t => t.ObjectId).HasColumnName("OBJECTID").HasMaxLength(36);
            builder.Property(t => t.Data).HasColumnName("DATA");
            builder.Property(t => t.PropertyDefId).HasColumnName("PROPERTYDEFID").HasMaxLength(36);
            builder.Property(t => t.IsDeleted).HasColumnName("ISDELETED");
        }
    }
}