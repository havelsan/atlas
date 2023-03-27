using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChattelDocumentInputDetailWithAccountancyConfig : IEntityTypeConfiguration<AtlasModel.ChattelDocumentInputDetailWithAccountancy>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChattelDocumentInputDetailWithAccountancy> builder)
        {
            builder.ToTable("CHATTELDOCIDACCOUNTANCY");
            builder.HasKey(nameof(AtlasModel.ChattelDocumentInputDetailWithAccountancy.ObjectId));
            builder.Property(nameof(AtlasModel.ChattelDocumentInputDetailWithAccountancy.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChattelDocumentInputDetailWithAccountancy.SupplierRef)).HasColumnName("SUPPLIER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.StockActionDetailIn).WithOne().HasForeignKey<AtlasModel.StockActionDetailIn>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Supplier).WithOne().HasForeignKey<AtlasModel.ChattelDocumentInputDetailWithAccountancy>(x => x.SupplierRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}