using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReviewActionDetailConfig : IEntityTypeConfiguration<AtlasModel.ReviewActionDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReviewActionDetail> builder)
        {
            builder.ToTable("REVIEWACTIONDETAIL");
            builder.HasKey(nameof(AtlasModel.ReviewActionDetail.ObjectId));
            builder.Property(nameof(AtlasModel.ReviewActionDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReviewActionDetail.StoreObjID)).HasColumnName("STOREOBJID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReviewActionDetail.StoreName)).HasColumnName("STORENAME").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.ReviewActionDetail.UnitPrice)).HasColumnName("UNITPRICE").HasColumnType("NUMBER(31,6)");
            builder.Property(nameof(AtlasModel.ReviewActionDetail.StockTranactionGuid)).HasColumnName("STOCKTRANACTIONGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReviewActionDetail.BudgetTypeDefinitionRef)).HasColumnName("BUDGETTYPEDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.BudgetTypeDefinition).WithOne().HasForeignKey<AtlasModel.ReviewActionDetail>(x => x.BudgetTypeDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}