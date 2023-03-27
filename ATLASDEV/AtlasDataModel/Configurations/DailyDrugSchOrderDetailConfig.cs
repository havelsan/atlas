using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DailyDrugSchOrderDetailConfig : IEntityTypeConfiguration<AtlasModel.DailyDrugSchOrderDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DailyDrugSchOrderDetail> builder)
        {
            builder.ToTable("DAILYDRUGSCHORDERDETAIL");
            builder.HasKey(nameof(AtlasModel.DailyDrugSchOrderDetail.ObjectId));
            builder.Property(nameof(AtlasModel.DailyDrugSchOrderDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DailyDrugSchOrderDetail.DrugOrderDetailRef)).HasColumnName("DRUGORDERDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DailyDrugSchOrderDetail.DailyDrugSchOrderRef)).HasColumnName("DAILYDRUGSCHORDER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugOrderDetail).WithOne().HasForeignKey<AtlasModel.DailyDrugSchOrderDetail>(x => x.DrugOrderDetailRef).IsRequired(false);
            builder.HasOne(t => t.DailyDrugSchOrder).WithOne().HasForeignKey<AtlasModel.DailyDrugSchOrderDetail>(x => x.DailyDrugSchOrderRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}