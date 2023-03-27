using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InvoiceBlockingDefinitionConfig : IEntityTypeConfiguration<AtlasModel.InvoiceBlockingDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InvoiceBlockingDefinition> builder)
        {
            builder.ToTable("INVOICEBLOCKINGDEFINITION");
            builder.HasKey(nameof(AtlasModel.InvoiceBlockingDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.InvoiceBlockingDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InvoiceBlockingDefinition.StateDefId)).HasColumnName("STATEDEFID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InvoiceBlockingDefinition.ObjectName)).HasColumnName("OBJECTNAME");
            builder.Property(nameof(AtlasModel.InvoiceBlockingDefinition.Type)).HasColumnName("TYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.InvoiceBlockingDefinition.StateName)).HasColumnName("STATENAME");
            builder.Property(nameof(AtlasModel.InvoiceBlockingDefinition.InvoiceBlock)).HasColumnName("INVOICEBLOCK");
            builder.Property(nameof(AtlasModel.InvoiceBlockingDefinition.CashOfficeBlock)).HasColumnName("CASHOFFICEBLOCK");
        }
    }
}