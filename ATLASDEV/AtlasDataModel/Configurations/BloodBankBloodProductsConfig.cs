using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BloodBankBloodProductsConfig : IEntityTypeConfiguration<AtlasModel.BloodBankBloodProducts>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BloodBankBloodProducts> builder)
        {
            builder.ToTable("BLOODBANKBLOODPRODUCTS");
            builder.HasKey(nameof(AtlasModel.BloodBankBloodProducts.ObjectId));
            builder.Property(nameof(AtlasModel.BloodBankBloodProducts.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BloodBankBloodProducts.ISBTUnitNumber)).HasColumnName("ISBTUNITNUMBER");
            builder.Property(nameof(AtlasModel.BloodBankBloodProducts.Used)).HasColumnName("USED");
            builder.Property(nameof(AtlasModel.BloodBankBloodProducts.ProductNumber)).HasColumnName("PRODUCTNUMBER").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.BloodBankBloodProducts.ProductDate)).HasColumnName("PRODUCTDATE");
            builder.Property(nameof(AtlasModel.BloodBankBloodProducts.IsFilter)).HasColumnName("ISFILTER");
            builder.Property(nameof(AtlasModel.BloodBankBloodProducts.Returned)).HasColumnName("RETURNED");
            builder.Property(nameof(AtlasModel.BloodBankBloodProducts.Notes)).HasColumnName("NOTES").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.BloodBankBloodProducts.IsIsinlama)).HasColumnName("ISISINLAMA");
            builder.Property(nameof(AtlasModel.BloodBankBloodProducts.BloodProductExternalID)).HasColumnName("BLOODPRODUCTEXTERNALID");
            builder.Property(nameof(AtlasModel.BloodBankBloodProducts.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubactionProcedureFlowable).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.BloodBankBloodProducts>(x => x.OzelDurumRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}