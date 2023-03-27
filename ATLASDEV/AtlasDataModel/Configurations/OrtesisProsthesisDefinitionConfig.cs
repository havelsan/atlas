using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OrtesisProsthesisDefinitionConfig : IEntityTypeConfiguration<AtlasModel.OrtesisProsthesisDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OrtesisProsthesisDefinition> builder)
        {
            builder.ToTable("ORTESISPROSTHESISDEF");
            builder.HasKey(nameof(AtlasModel.OrtesisProsthesisDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.OrtesisProsthesisDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OrtesisProsthesisDefinition.HealthCommitteeType)).HasColumnName("HEALTHCOMMITTEETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.OrtesisProsthesisDefinition.SideSelect)).HasColumnName("SIDESELECT");
            builder.Property(nameof(AtlasModel.OrtesisProsthesisDefinition.Warranty)).HasColumnName("WARRANTY").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.OrtesisProsthesisDefinition.DefaultAmount)).HasColumnName("DEFAULTAMOUNT");
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.ProcedureDefinition>(p => p.ObjectId);
        }
    }
}