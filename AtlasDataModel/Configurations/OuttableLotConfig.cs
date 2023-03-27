using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OuttableLotConfig : IEntityTypeConfiguration<AtlasModel.OuttableLot>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OuttableLot> builder)
        {
            builder.ToTable("OUTTABLELOT");
            builder.HasKey(nameof(AtlasModel.OuttableLot.ObjectId));
            builder.Property(nameof(AtlasModel.OuttableLot.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OuttableLot.isUse)).HasColumnName("ISUSE");
            builder.Property(nameof(AtlasModel.OuttableLot.Amount)).HasColumnName("AMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.OuttableLot.RestAmount)).HasColumnName("RESTAMOUNT").HasColumnType("NUMBER(15,4)");
            builder.Property(nameof(AtlasModel.OuttableLot.ExpirationDate)).HasColumnName("EXPIRATIONDATE");
            builder.Property(nameof(AtlasModel.OuttableLot.LotNo)).HasColumnName("LOTNO");
            builder.Property(nameof(AtlasModel.OuttableLot.BudgetTypeName)).HasColumnName("BUDGETTYPENAME");
            builder.Property(nameof(AtlasModel.OuttableLot.SerialNo)).HasColumnName("SERIALNO").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.OuttableLot.TrxObjectID)).HasColumnName("TRXOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OuttableLot.StockActionDetailOutRef)).HasColumnName("STOCKACTIONDETAILOUT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.OuttableLot>(x => x.StockActionDetailOutRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}