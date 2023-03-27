using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PricingDetailDefinitionConfig : IEntityTypeConfiguration<AtlasModel.PricingDetailDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PricingDetailDefinition> builder)
        {
            builder.ToTable("PRICINGDETAILDEFINITION");
            builder.HasKey(nameof(AtlasModel.PricingDetailDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.DateEnd)).HasColumnName("DATEEND");
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.DateStart)).HasColumnName("DATESTART");
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.ExternalCode)).HasColumnName("EXTERNALCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.SPTSPricingDetailID)).HasColumnName("SPTSPRICINGDETAILID");
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.OutPatientDiscountPercent)).HasColumnName("OUTPATIENTDISCOUNTPERCENT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.Description_Shadow)).HasColumnName("DESCRIPTION_SHADOW");
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.Price)).HasColumnName("PRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.Point)).HasColumnName("POINT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.PriceWithOutDiscount)).HasColumnName("PRICEWITHOUTDISCOUNT").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.DiscountPercent)).HasColumnName("DISCOUNTPERCENT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.MedulaSUTGroup)).HasColumnName("MEDULASUTGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.InPatientDiscountPercent)).HasColumnName("INPATIENTDISCOUNTPERCENT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.PricingListRef)).HasColumnName("PRICINGLIST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.PricingListGroupRef)).HasColumnName("PRICINGLISTGROUP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PricingDetailDefinition.CurrencyTypeRef)).HasColumnName("CURRENCYTYPE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}