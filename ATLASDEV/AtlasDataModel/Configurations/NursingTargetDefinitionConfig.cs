using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingTargetDefinitionConfig : IEntityTypeConfiguration<AtlasModel.NursingTargetDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingTargetDefinition> builder)
        {
            builder.ToTable("NURSINGTARGETDEFINITION");
            builder.HasKey(nameof(AtlasModel.NursingTargetDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.NursingTargetDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingTargetDefinition.Name)).HasColumnName("NAME");
            builder.Property(nameof(AtlasModel.NursingTargetDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}