using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugDeliveryActionDetailConfig : IEntityTypeConfiguration<AtlasModel.DrugDeliveryActionDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugDeliveryActionDetail> builder)
        {
            builder.ToTable("DRUGDELIVERYACTIONDETAIL");
            builder.HasKey(nameof(AtlasModel.DrugDeliveryActionDetail.ObjectId));
            builder.Property(nameof(AtlasModel.DrugDeliveryActionDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugDeliveryActionDetail.DrugName)).HasColumnName("DRUGNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DrugDeliveryActionDetail.ResDose)).HasColumnName("RESDOSE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugDeliveryActionDetail.DrugDeliveryActionRef)).HasColumnName("DRUGDELIVERYACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugDeliveryActionDetail.DrugOrderTransactionRef)).HasColumnName("DRUGORDERTRANSACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugDeliveryAction).WithOne().HasForeignKey<AtlasModel.DrugDeliveryActionDetail>(x => x.DrugDeliveryActionRef).IsRequired(false);
            builder.HasOne(t => t.DrugOrderTransaction).WithOne().HasForeignKey<AtlasModel.DrugDeliveryActionDetail>(x => x.DrugOrderTransactionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}