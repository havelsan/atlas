using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChattelDocumentDistributionConfig : IEntityTypeConfiguration<AtlasModel.ChattelDocumentDistribution>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChattelDocumentDistribution> builder)
        {
            builder.ToTable("CHEQUEDOCUMENTDISTRIBUTION");
            builder.HasKey(nameof(AtlasModel.ChattelDocumentDistribution.ObjectId));
            builder.Property(nameof(AtlasModel.ChattelDocumentDistribution.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChattelDocumentDistribution.DistributionAmount)).HasColumnName("DISTRIBUTIONAMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.ChattelDocumentDistribution.DemandDetailRef)).HasColumnName("DEMANDDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChattelDocumentDistribution.ChattelDocumentWithPurchaseRef)).HasColumnName("CHATTELDOCUMENTWITHPURCHASE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChattelDocumentDistribution.ChattelDocDetailWithPurchaseRef)).HasColumnName("CHATTELDOCDETAILWITHPURCHASE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ChattelDocumentWithPurchase).WithOne().HasForeignKey<AtlasModel.ChattelDocumentDistribution>(x => x.ChattelDocumentWithPurchaseRef).IsRequired(true);
            builder.HasOne(t => t.ChattelDocDetailWithPurchase).WithOne().HasForeignKey<AtlasModel.ChattelDocumentDistribution>(x => x.ChattelDocDetailWithPurchaseRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}