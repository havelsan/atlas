using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MainCashOfficePaymentTypeDefinitionConfig : IEntityTypeConfiguration<AtlasModel.MainCashOfficePaymentTypeDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MainCashOfficePaymentTypeDefinition> builder)
        {
            builder.ToTable("MAINCASHOFFICEPAYTYPEDEF");
            builder.HasKey(nameof(AtlasModel.MainCashOfficePaymentTypeDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.MainCashOfficePaymentTypeDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MainCashOfficePaymentTypeDefinition.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MainCashOfficePaymentTypeDefinition.Code)).HasColumnName("CODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.MainCashOfficePaymentTypeDefinition.IsSubCashOfficePayment)).HasColumnName("ISSUBCASHOFFICEPAYMENT");
            builder.Property(nameof(AtlasModel.MainCashOfficePaymentTypeDefinition.AccountEntegration)).HasColumnName("ACCOUNTENTEGRATION");
            builder.Property(nameof(AtlasModel.MainCashOfficePaymentTypeDefinition.IsBankOperation)).HasColumnName("ISBANKOPERATION");
            builder.Property(nameof(AtlasModel.MainCashOfficePaymentTypeDefinition.SubCashierCanDo)).HasColumnName("SUBCASHIERCANDO");
            builder.Property(nameof(AtlasModel.MainCashOfficePaymentTypeDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.MainCashOfficePaymentTypeDefinition.IsChattel)).HasColumnName("ISCHATTEL");
            builder.Property(nameof(AtlasModel.MainCashOfficePaymentTypeDefinition.RevenueSubAccountCodeRef)).HasColumnName("REVENUESUBACCOUNTCODE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.RevenueSubAccountCode).WithOne().HasForeignKey<AtlasModel.MainCashOfficePaymentTypeDefinition>(x => x.RevenueSubAccountCodeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}