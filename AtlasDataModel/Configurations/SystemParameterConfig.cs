using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SystemParameterConfig : IEntityTypeConfiguration<AtlasModel.SystemParameter>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SystemParameter> builder)
        {
            builder.ToTable("SYSTEMPARAMETER");
            builder.HasKey(nameof(AtlasModel.SystemParameter.ObjectId));
            builder.Property(nameof(AtlasModel.SystemParameter.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SystemParameter.Value)).HasColumnName("VALUE").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SystemParameter.SubType)).HasColumnName("SUBTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SystemParameter.Description)).HasColumnName("DESCRIPTION").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SystemParameter.Name)).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.SystemParameter.IsEncrypted)).HasColumnName("ISENCRYPTED");
            builder.Property(nameof(AtlasModel.SystemParameter.CacheDurationInMinutes)).HasColumnName("CACHEDURATIONINMINUTES");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}