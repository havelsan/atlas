using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugOrderDetailConfig : IEntityTypeConfiguration<AtlasModel.DrugOrderDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugOrderDetail> builder)
        {
            builder.ToTable("DRUGORDERDETAIL");
            builder.HasKey(nameof(AtlasModel.DrugOrderDetail.ObjectId));
            builder.Property(nameof(AtlasModel.DrugOrderDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugOrderDetail.PackageQuantity)).HasColumnName("PACKAGEQUANTITY").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugOrderDetail.OrderPlannedDate)).HasColumnName("ORDERPLANNEDDATE");
            builder.Property(nameof(AtlasModel.DrugOrderDetail.DrugDone)).HasColumnName("DRUGDONE");
            builder.Property(nameof(AtlasModel.DrugOrderDetail.Stage)).HasColumnName("STAGE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DrugOrderDetail.Note)).HasColumnName("NOTE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.DrugOrderDetail.DetailNo)).HasColumnName("DETAILNO");
            builder.Property(nameof(AtlasModel.DrugOrderDetail.CRCCode)).HasColumnName("CRCCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DrugOrderDetail.NursingApplicationRef)).HasColumnName("NURSINGAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderDetail.KScheduleCollectedOrderRef)).HasColumnName("KSCHEDULECOLLECTEDORDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderDetail.DrugOrderRef)).HasColumnName("DRUGORDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderDetail.DrugDeliveryActionDetailRef)).HasColumnName("DRUGDELIVERYACTIONDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderDetail.DrugReturnActionDetailRef)).HasColumnName("DRUGRETURNACTIONDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderDetail.KScheduleUnListMaterialRef)).HasColumnName("KSCHEDULEUNLISTMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOrderDetail.KSchedulePatienOwnDrugRef)).HasColumnName("KSCHEDULEPATIENOWNDRUG").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseDrugOrder).WithOne().HasForeignKey<AtlasModel.BaseDrugOrder>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.NursingApplication).WithOne().HasForeignKey<AtlasModel.DrugOrderDetail>(x => x.NursingApplicationRef).IsRequired(false);
            builder.HasOne(t => t.KScheduleCollectedOrder).WithOne().HasForeignKey<AtlasModel.DrugOrderDetail>(x => x.KScheduleCollectedOrderRef).IsRequired(false);
            builder.HasOne(t => t.DrugOrder).WithOne().HasForeignKey<AtlasModel.DrugOrderDetail>(x => x.DrugOrderRef).IsRequired(false);
            builder.HasOne(t => t.DrugDeliveryActionDetail).WithOne().HasForeignKey<AtlasModel.DrugOrderDetail>(x => x.DrugDeliveryActionDetailRef).IsRequired(false);
            builder.HasOne(t => t.DrugReturnActionDetail).WithOne().HasForeignKey<AtlasModel.DrugOrderDetail>(x => x.DrugReturnActionDetailRef).IsRequired(false);
            builder.HasOne(t => t.KScheduleUnListMaterial).WithOne().HasForeignKey<AtlasModel.DrugOrderDetail>(x => x.KScheduleUnListMaterialRef).IsRequired(false);
            builder.HasOne(t => t.KSchedulePatienOwnDrug).WithOne().HasForeignKey<AtlasModel.DrugOrderDetail>(x => x.KSchedulePatienOwnDrugRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}