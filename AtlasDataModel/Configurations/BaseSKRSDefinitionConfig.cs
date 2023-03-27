using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseSKRSDefinitionConfig : IEntityTypeConfiguration<AtlasModel.BaseSKRSDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseSKRSDefinition> builder)
        {
            builder.ToTable("BASESKRSDEFINITION");
            builder.HasKey(nameof(AtlasModel.BaseSKRSDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.BaseSKRSDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseSKRSDefinition.Default)).HasColumnName("DEFAULT");
            builder.Property(nameof(AtlasModel.BaseSKRSDefinition.AKTIF)).HasColumnName("AKTIF").HasMaxLength(255);
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}