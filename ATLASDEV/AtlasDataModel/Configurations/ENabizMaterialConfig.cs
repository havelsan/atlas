using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ENabizMaterialConfig : IEntityTypeConfiguration<AtlasModel.ENabizMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ENabizMaterial> builder)
        {
            builder.ToTable("ENABIZMATERIAL");
            builder.HasKey(nameof(AtlasModel.ENabizMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.ENabizMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ENabizMaterial.RequestDate)).HasColumnName("REQUESTDATE");
            builder.Property(nameof(AtlasModel.ENabizMaterial.PatientPrice)).HasColumnName("PATIENTPRICE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.ENabizMaterial.PayerPrice)).HasColumnName("PAYERPRICE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.ENabizMaterial.ApplicationDate)).HasColumnName("APPLICATIONDATE");
            builder.Property(nameof(AtlasModel.ENabizMaterial.SubActionMaterialRef)).HasColumnName("SUBACTIONMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ENabizMaterial.AccountTransactionRef)).HasColumnName("ACCOUNTTRANSACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SubActionMaterial).WithOne().HasForeignKey<AtlasModel.ENabizMaterial>(x => x.SubActionMaterialRef).IsRequired(true);
            builder.HasOne(t => t.AccountTransaction).WithOne().HasForeignKey<AtlasModel.ENabizMaterial>(x => x.AccountTransactionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}