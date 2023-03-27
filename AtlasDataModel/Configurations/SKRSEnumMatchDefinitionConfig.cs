using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSEnumMatchDefinitionConfig : IEntityTypeConfiguration<AtlasModel.SKRSEnumMatchDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSEnumMatchDefinition> builder)
        {
            builder.ToTable("SKRSENUMMATCHDEFINITION");
            builder.HasKey(nameof(AtlasModel.SKRSEnumMatchDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSEnumMatchDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSEnumMatchDefinition.EnumValue)).HasColumnName("ENUMVALUE");
            builder.Property(nameof(AtlasModel.SKRSEnumMatchDefinition.SKRSDefinitionObjectId)).HasColumnName("SKRSDEFINITIONOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SKRSEnumMatchDefinition.SKRSDefinitionRef)).HasColumnName("SKRSDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SKRSDefinition).WithOne().HasForeignKey<AtlasModel.SKRSEnumMatchDefinition>(x => x.SKRSDefinitionRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}