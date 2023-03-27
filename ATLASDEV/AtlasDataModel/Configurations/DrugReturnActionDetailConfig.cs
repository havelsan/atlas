using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugReturnActionDetailConfig : IEntityTypeConfiguration<AtlasModel.DrugReturnActionDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugReturnActionDetail> builder)
        {
            builder.ToTable("DRUGRETURNACTIONDETAIL");
            builder.HasKey(nameof(AtlasModel.DrugReturnActionDetail.ObjectId));
            builder.Property(nameof(AtlasModel.DrugReturnActionDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugReturnActionDetail.SendAmount)).HasColumnName("SENDAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugReturnActionDetail.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugReturnActionDetail.DrugName)).HasColumnName("DRUGNAME").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.DrugReturnActionDetail.DrugReturnActionRef)).HasColumnName("DRUGRETURNACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugReturnActionDetail.DrugOrderTransactionRef)).HasColumnName("DRUGORDERTRANSACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugReturnAction).WithOne().HasForeignKey<AtlasModel.DrugReturnActionDetail>(x => x.DrugReturnActionRef).IsRequired(false);
            builder.HasOne(t => t.DrugOrderTransaction).WithOne().HasForeignKey<AtlasModel.DrugReturnActionDetail>(x => x.DrugOrderTransactionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}