using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTRelationPropagationDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTRelationPropagationDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTRelationPropagationDef> builder)
        {
            builder.HasKey(t => t.RelationDefId);
            builder.Property(t => t.RelationDefId).HasColumnName("RELATIONDEFID").HasMaxLength(36);
            builder.Property(t => t.ChildRelationDefId).HasColumnName("CHILDRELATIONDEFID").HasMaxLength(36);
            builder.Property(t => t.ParentRelationDefId).HasColumnName("PARENTRELATIONDEFID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
        }
    }
}