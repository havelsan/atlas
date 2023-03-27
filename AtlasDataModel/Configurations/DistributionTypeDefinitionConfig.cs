using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DistributionTypeDefinitionConfig : IEntityTypeConfiguration<AtlasModel.DistributionTypeDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DistributionTypeDefinition> builder)
        {
            builder.ToTable("DISTRIBUTIONTYPEDEFINITION");
            builder.HasKey(nameof(AtlasModel.DistributionTypeDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.DistributionTypeDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DistributionTypeDefinition.DistributionType)).HasColumnName("DISTRIBUTIONTYPE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DistributionTypeDefinition.QRef)).HasColumnName("QREF").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.DistributionTypeDefinition.DistributionType_Shadow)).HasColumnName("DISTRIBUTIONTYPE_SHADOW");
            builder.Property(nameof(AtlasModel.DistributionTypeDefinition.QRef_Shadow)).HasColumnName("QREF_SHADOW");
            builder.Property(nameof(AtlasModel.DistributionTypeDefinition.MKYS_DistType)).HasColumnName("MKYS_DISTTYPE").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}