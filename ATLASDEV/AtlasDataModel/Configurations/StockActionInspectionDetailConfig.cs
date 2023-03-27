using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockActionInspectionDetailConfig : IEntityTypeConfiguration<AtlasModel.StockActionInspectionDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockActionInspectionDetail> builder)
        {
            builder.ToTable("STOCKACTIONINSPECTIONDET");
            builder.HasKey(nameof(AtlasModel.StockActionInspectionDetail.ObjectId));
            builder.Property(nameof(AtlasModel.StockActionInspectionDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockActionInspectionDetail.ShortMilitaryClass)).HasColumnName("SHORTMILITARYCLASS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.StockActionInspectionDetail.ShortRank)).HasColumnName("SHORTRANK").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.StockActionInspectionDetail.EmploymentRecordID)).HasColumnName("EMPLOYMENTRECORDID").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.StockActionInspectionDetail.NameString)).HasColumnName("NAMESTRING").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.StockActionInspectionDetail.InspectionUserType)).HasColumnName("INSPECTIONUSERTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.StockActionInspectionDetail.InspectionUserRef)).HasColumnName("INSPECTIONUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockActionInspectionDetail.StockActionInspectionRef)).HasColumnName("STOCKACTIONINSPECTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InspectionUser).WithOne().HasForeignKey<AtlasModel.StockActionInspectionDetail>(x => x.InspectionUserRef).IsRequired(false);
            builder.HasOne(t => t.StockActionInspection).WithOne().HasForeignKey<AtlasModel.StockActionInspectionDetail>(x => x.StockActionInspectionRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}