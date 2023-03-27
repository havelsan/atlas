using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MkysCensusSyncDataConfig : IEntityTypeConfiguration<AtlasModel.MkysCensusSyncData>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MkysCensusSyncData> builder)
        {
            builder.ToTable("MKYSCENSUSSYNCDATA");
            builder.HasKey(nameof(AtlasModel.MkysCensusSyncData.ObjectId));
            builder.Property(nameof(AtlasModel.MkysCensusSyncData.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MkysCensusSyncData.YeniBirimFiyat)).HasColumnName("YENIBIRIMFIYAT").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.MkysCensusSyncData.EskiBirimFiyat)).HasColumnName("ESKIBIRIMFIYAT").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.MkysCensusSyncData.YeniStokHareketId)).HasColumnName("YENISTOKHAREKETID");
            builder.Property(nameof(AtlasModel.MkysCensusSyncData.EskiStokHareketId)).HasColumnName("ESKISTOKHAREKETID");
            builder.Property(nameof(AtlasModel.MkysCensusSyncData.StockTransactionGuid)).HasColumnName("STOCKTRANSACTIONGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MkysCensusSyncData.StockGuid)).HasColumnName("STOCKGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MkysCensusSyncData.StockCensusRef)).HasColumnName("STOCKCENSUS").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockCensus).WithOne().HasForeignKey<AtlasModel.MkysCensusSyncData>(x => x.StockCensusRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}