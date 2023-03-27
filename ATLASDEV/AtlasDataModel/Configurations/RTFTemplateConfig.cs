using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RTFTemplateConfig : IEntityTypeConfiguration<AtlasModel.RTFTemplate>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.RTFTemplate> builder)
        {
            builder.ToTable("RTFTEMPLATE");
            builder.HasKey(nameof(AtlasModel.RTFTemplate.ObjectId));
            builder.Property(nameof(AtlasModel.RTFTemplate.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseTemplate).WithOne().HasForeignKey<AtlasModel.BaseTemplate>(p => p.ObjectId);
        }
    }
}