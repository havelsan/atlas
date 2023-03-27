using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class IIMProtocolConfig : IEntityTypeConfiguration<AtlasModel.IIMProtocol>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.IIMProtocol> builder)
        {
            builder.ToTable("IIMPROTOCOL");
            builder.HasKey(nameof(AtlasModel.IIMProtocol.ObjectId));
            builder.Property(nameof(AtlasModel.IIMProtocol.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.IIMProtocol.Checked)).HasColumnName("CHECKED");
            builder.Property(nameof(AtlasModel.IIMProtocol.InvoiceInclusionMasterRef)).HasColumnName("INVOICEINCLUSIONMASTER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.IIMProtocol.ProtocolDefinitionRef)).HasColumnName("PROTOCOLDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InvoiceInclusionMaster).WithOne().HasForeignKey<AtlasModel.IIMProtocol>(x => x.InvoiceInclusionMasterRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}