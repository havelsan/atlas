using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MHRSActionTypeDefinitionConfig : IEntityTypeConfiguration<AtlasModel.MHRSActionTypeDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MHRSActionTypeDefinition> builder)
        {
            builder.ToTable("MHRSACTIONTYPEDEFINITION");
            builder.HasKey(nameof(AtlasModel.MHRSActionTypeDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.MHRSActionTypeDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MHRSActionTypeDefinition.IsDocumentRequired)).HasColumnName("ISDOCUMENTREQUIRED");
            builder.Property(nameof(AtlasModel.MHRSActionTypeDefinition.IsIstisnaType)).HasColumnName("ISISTISNATYPE");
            builder.Property(nameof(AtlasModel.MHRSActionTypeDefinition.ActionName)).HasColumnName("ACTIONNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.MHRSActionTypeDefinition.ActionCode)).HasColumnName("ACTIONCODE");
            builder.Property(nameof(AtlasModel.MHRSActionTypeDefinition.OpenMHRS)).HasColumnName("OPENMHRS");
            builder.Property(nameof(AtlasModel.MHRSActionTypeDefinition.Mustesna)).HasColumnName("MUSTESNA");
            builder.Property(nameof(AtlasModel.MHRSActionTypeDefinition.Day)).HasColumnName("DAY");
            builder.Property(nameof(AtlasModel.MHRSActionTypeDefinition.IsWorkingHour)).HasColumnName("ISWORKINGHOUR");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}