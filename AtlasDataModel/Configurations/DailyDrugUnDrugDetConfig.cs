using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DailyDrugUnDrugDetConfig : IEntityTypeConfiguration<AtlasModel.DailyDrugUnDrugDet>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DailyDrugUnDrugDet> builder)
        {
            builder.ToTable("DAILYDRUGUNDRUGDET");
            builder.HasKey(nameof(AtlasModel.DailyDrugUnDrugDet.ObjectId));
            builder.Property(nameof(AtlasModel.DailyDrugUnDrugDet.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DailyDrugUnDrugDet.DailyDrugUnDrugRef)).HasColumnName("DAILYDRUGUNDRUG").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DailyDrugUnDrugDet.DrugOrderDetailRef)).HasColumnName("DRUGORDERDETAIL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DailyDrugUnDrug).WithOne().HasForeignKey<AtlasModel.DailyDrugUnDrugDet>(x => x.DailyDrugUnDrugRef).IsRequired(false);
            builder.HasOne(t => t.DrugOrderDetail).WithOne().HasForeignKey<AtlasModel.DailyDrugUnDrugDet>(x => x.DrugOrderDetailRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}