using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ExtendExpirationDateDetailConfig : IEntityTypeConfiguration<AtlasModel.ExtendExpirationDateDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ExtendExpirationDateDetail> builder)
        {
            builder.ToTable("EXTENDEXPIRATIONDATEDETAIL");
            builder.HasKey(nameof(AtlasModel.ExtendExpirationDateDetail.ObjectId));
            builder.Property(nameof(AtlasModel.ExtendExpirationDateDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ExtendExpirationDateDetail.NewDateForExpiration)).HasColumnName("NEWDATEFOREXPIRATION");
            builder.Property(nameof(AtlasModel.ExtendExpirationDateDetail.CurrentExpirationDate)).HasColumnName("CURRENTEXPIRATIONDATE");
            builder.Property(nameof(AtlasModel.ExtendExpirationDateDetail.SelectedLotRestAmount)).HasColumnName("SELECTEDLOTRESTAMOUNT").HasColumnType("NUMBER(15,4)");
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}