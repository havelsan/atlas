using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTPropertyPropagationDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTPropertyPropagationDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTPropertyPropagationDef> builder)
        {
            builder.HasKey(t => t.RelationDefId);
            builder.Property(t => t.RelationDefId).HasColumnName("RELATIONDEFID").HasMaxLength(36);
            builder.Property(t => t.ChildPropertyDefId).HasColumnName("CHILDPROPERTYDEFID").HasMaxLength(36);
            builder.Property(t => t.ParentPropertyDefId).HasColumnName("PARENTPROPERTYDEFID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.RelationSubtypeDefId).HasColumnName("RELATIONSUBTYPEDEFID").HasMaxLength(36);
        }
    }
}