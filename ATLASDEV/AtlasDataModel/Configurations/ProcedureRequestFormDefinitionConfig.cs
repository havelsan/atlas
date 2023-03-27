using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ProcedureRequestFormDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ProcedureRequestFormDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ProcedureRequestFormDefinition> builder)
        {
            builder.ToTable("PROCEDUREREQUESTFORMDEF");
            builder.HasKey(nameof(AtlasModel.ProcedureRequestFormDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ProcedureRequestFormDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ProcedureRequestFormDefinition.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.ProcedureRequestFormDefinition.Name)).HasColumnName("NAME");
            builder.Property(nameof(AtlasModel.ProcedureRequestFormDefinition.OrderNo)).HasColumnName("ORDERNO");
            builder.Property(nameof(AtlasModel.ProcedureRequestFormDefinition.ObservationUnitRef)).HasColumnName("OBSERVATIONUNIT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ObservationUnit).WithOne().HasForeignKey<AtlasModel.ProcedureRequestFormDefinition>(x => x.ObservationUnitRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}