using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseAdditionalInfoConfig : IEntityTypeConfiguration<AtlasModel.BaseAdditionalInfo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseAdditionalInfo> builder)
        {
            builder.ToTable("BASEADDITIONALINFO");
            builder.HasKey(nameof(AtlasModel.BaseAdditionalInfo.ObjectId));
            builder.Property(nameof(AtlasModel.BaseAdditionalInfo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseAdditionalInfo.Code)).HasColumnName("CODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.BaseAdditionalInfo.CreationDate)).HasColumnName("CREATIONDATE");
        }
    }
}