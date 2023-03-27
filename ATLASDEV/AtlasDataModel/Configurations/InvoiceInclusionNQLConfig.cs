using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InvoiceInclusionNQLConfig : IEntityTypeConfiguration<AtlasModel.InvoiceInclusionNQL>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InvoiceInclusionNQL> builder)
        {
            builder.ToTable("INVOICEINCLUSIONNQL");
            builder.HasKey(nameof(AtlasModel.InvoiceInclusionNQL.ObjectId));
            builder.Property(nameof(AtlasModel.InvoiceInclusionNQL.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InvoiceInclusionNQL.NQL)).HasColumnName("NQL").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.InvoiceInclusionNQL.OrderNo)).HasColumnName("ORDERNO");
            builder.Property(nameof(AtlasModel.InvoiceInclusionNQL.ProcedureMaterialType)).HasColumnName("PROCEDUREMATERIALTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.InvoiceInclusionNQL.Name)).HasColumnName("NAME");
        }
    }
}