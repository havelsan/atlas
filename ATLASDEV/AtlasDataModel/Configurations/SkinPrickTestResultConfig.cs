using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SkinPrickTestResultConfig : IEntityTypeConfiguration<AtlasModel.SkinPrickTestResult>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SkinPrickTestResult> builder)
        {
            builder.ToTable("SKINPRICKTESTRESULT");
            builder.HasKey(nameof(AtlasModel.SkinPrickTestResult.ObjectId));
            builder.Property(nameof(AtlasModel.SkinPrickTestResult.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}