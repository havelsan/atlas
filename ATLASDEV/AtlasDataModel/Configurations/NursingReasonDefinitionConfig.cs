using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingReasonDefinitionConfig : IEntityTypeConfiguration<AtlasModel.NursingReasonDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingReasonDefinition> builder)
        {
            builder.ToTable("NURSINGREASONDEFINITION");
            builder.HasKey(nameof(AtlasModel.NursingReasonDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.NursingReasonDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingReasonDefinition.Name)).HasColumnName("NAME");
            builder.Property(nameof(AtlasModel.NursingReasonDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}