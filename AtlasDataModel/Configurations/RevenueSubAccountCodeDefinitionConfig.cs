using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class RevenueSubAccountCodeDefinitionConfig : IEntityTypeConfiguration<AtlasModel.RevenueSubAccountCodeDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.RevenueSubAccountCodeDefinition> builder)
        {
            builder.ToTable("REVENUESUBACCOUNTCODEDEF");
            builder.HasKey(nameof(AtlasModel.RevenueSubAccountCodeDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.RevenueSubAccountCodeDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.RevenueSubAccountCodeDefinition.AccountCode)).HasColumnName("ACCOUNTCODE").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.RevenueSubAccountCodeDefinition.Description)).HasColumnName("DESCRIPTION").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.RevenueSubAccountCodeDefinition.Description_Shadow)).HasColumnName("DESCRIPTION_SHADOW");
            builder.Property(nameof(AtlasModel.RevenueSubAccountCodeDefinition.AccountType)).HasColumnName("ACCOUNTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.RevenueSubAccountCodeDefinition.SubAccountType)).HasColumnName("SUBACCOUNTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.RevenueSubAccountCodeDefinition.MasterRevenueSubAccountRef)).HasColumnName("MASTERREVENUESUBACCOUNT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.RevenueSubAccountCodeDefinition.RelatedRevenueSubAccountRef)).HasColumnName("RELATEDREVENUESUBACCOUNT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MasterRevenueSubAccount).WithOne().HasForeignKey<AtlasModel.RevenueSubAccountCodeDefinition>(x => x.MasterRevenueSubAccountRef).IsRequired(false);
            builder.HasOne(t => t.RelatedRevenueSubAccount).WithOne().HasForeignKey<AtlasModel.RevenueSubAccountCodeDefinition>(x => x.RelatedRevenueSubAccountRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}