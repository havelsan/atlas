using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SystemInterrogationDefinitionConfig : IEntityTypeConfiguration<AtlasModel.SystemInterrogationDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SystemInterrogationDefinition> builder)
        {
            builder.ToTable("SYSINTERROGDEF");
            builder.HasKey(nameof(AtlasModel.SystemInterrogationDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.SystemInterrogationDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SystemInterrogationDefinition.ActivityGroup)).HasColumnName("ACTIVITYGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SystemInterrogationDefinition.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.SystemInterrogationDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}