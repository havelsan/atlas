using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseDeleteRecordDocumentDetailConfig : IEntityTypeConfiguration<AtlasModel.BaseDeleteRecordDocumentDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseDeleteRecordDocumentDetail> builder)
        {
            builder.ToTable("BASEDRDOCUMENTDETAIL");
            builder.HasKey(nameof(AtlasModel.BaseDeleteRecordDocumentDetail.ObjectId));
            builder.Property(nameof(AtlasModel.BaseDeleteRecordDocumentDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}