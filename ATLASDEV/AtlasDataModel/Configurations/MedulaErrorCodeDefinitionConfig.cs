using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MedulaErrorCodeDefinitionConfig : IEntityTypeConfiguration<AtlasModel.MedulaErrorCodeDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MedulaErrorCodeDefinition> builder)
        {
            builder.ToTable("MEDULAERRORCODEDEF");
            builder.HasKey(nameof(AtlasModel.MedulaErrorCodeDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.MedulaErrorCodeDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MedulaErrorCodeDefinition.Code)).HasColumnName("CODE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.MedulaErrorCodeDefinition.Controlled)).HasColumnName("CONTROLLED");
            builder.Property(nameof(AtlasModel.MedulaErrorCodeDefinition.Message)).HasColumnName("MESSAGE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.MedulaErrorCodeDefinition.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.MedulaErrorCodeDefinition.UserNote)).HasColumnName("USERNOTE").HasMaxLength(1000);
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}