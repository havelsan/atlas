using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MainStoreDefinitionConfig : IEntityTypeConfiguration<AtlasModel.MainStoreDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MainStoreDefinition> builder)
        {
            builder.ToTable("MAINSTOREDEFINITION");
            builder.HasKey(nameof(AtlasModel.MainStoreDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.MainStoreDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MainStoreDefinition.MKYS_ButceTuru)).HasColumnName("MKYS_BUTCETURU").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MainStoreDefinition.IntegrationScope)).HasColumnName("INTEGRATIONSCOPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MainStoreDefinition.StoreCode)).HasColumnName("STORECODE").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.MainStoreDefinition.StoreRecordNo)).HasColumnName("STORERECORDNO");
            builder.Property(nameof(AtlasModel.MainStoreDefinition.UnitRecordNo)).HasColumnName("UNITRECORDNO");
            builder.Property(nameof(AtlasModel.MainStoreDefinition.AccountancyRef)).HasColumnName("ACCOUNTANCY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MainStoreDefinition.GoodsAccountantRef)).HasColumnName("GOODSACCOUNTANT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MainStoreDefinition.GoodsResponsibleRef)).HasColumnName("GOODSRESPONSIBLE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MainStoreDefinition.AccountManagerRef)).HasColumnName("ACCOUNTMANAGER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.Store).WithOne().HasForeignKey<AtlasModel.Store>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Accountancy).WithOne().HasForeignKey<AtlasModel.MainStoreDefinition>(x => x.AccountancyRef).IsRequired(true);
            builder.HasOne(t => t.GoodsAccountant).WithOne().HasForeignKey<AtlasModel.MainStoreDefinition>(x => x.GoodsAccountantRef).IsRequired(false);
            builder.HasOne(t => t.GoodsResponsible).WithOne().HasForeignKey<AtlasModel.MainStoreDefinition>(x => x.GoodsResponsibleRef).IsRequired(false);
            builder.HasOne(t => t.AccountManager).WithOne().HasForeignKey<AtlasModel.MainStoreDefinition>(x => x.AccountManagerRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}