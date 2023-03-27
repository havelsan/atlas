using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InvoiceInclusionMasterConfig : IEntityTypeConfiguration<AtlasModel.InvoiceInclusionMaster>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InvoiceInclusionMaster> builder)
        {
            builder.ToTable("INVOICEINCLUSIONMASTER");
            builder.HasKey(nameof(AtlasModel.InvoiceInclusionMaster.ObjectId));
            builder.Property(nameof(AtlasModel.InvoiceInclusionMaster.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InvoiceInclusionMaster.Name)).HasColumnName("NAME");
            builder.Property(nameof(AtlasModel.InvoiceInclusionMaster.FirstDate)).HasColumnName("FIRSTDATE");
            builder.Property(nameof(AtlasModel.InvoiceInclusionMaster.LastDate)).HasColumnName("LASTDATE");
            builder.Property(nameof(AtlasModel.InvoiceInclusionMaster.Description)).HasColumnName("DESCRIPTION").HasColumnType("VARCHAR2(4000)");
        }
    }
}