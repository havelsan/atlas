using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ProcedureMaterialAddingConfig : IEntityTypeConfiguration<AtlasModel.ProcedureMaterialAdding>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ProcedureMaterialAdding> builder)
        {
            builder.ToTable("PROCEDUREMATERIALADDING");
            builder.HasKey(nameof(AtlasModel.ProcedureMaterialAdding.ObjectId));
            builder.Property(nameof(AtlasModel.ProcedureMaterialAdding.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ProcedureMaterialAdding.PStartDate)).HasColumnName("PSTARTDATE");
            builder.Property(nameof(AtlasModel.ProcedureMaterialAdding.PEndDate)).HasColumnName("PENDDATE");
            builder.Property(nameof(AtlasModel.ProcedureMaterialAdding.ProcedureDefinitionRef)).HasColumnName("PROCEDUREDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ProcedureDefinition).WithOne().HasForeignKey<AtlasModel.ProcedureMaterialAdding>(x => x.ProcedureDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}