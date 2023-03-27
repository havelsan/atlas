using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubStoreDefinitionConfig : IEntityTypeConfiguration<AtlasModel.SubStoreDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubStoreDefinition> builder)
        {
            builder.ToTable("SUBSTOREDEFINITION");
            builder.HasKey(nameof(AtlasModel.SubStoreDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.SubStoreDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SubStoreDefinition.DependantUnitID)).HasColumnName("DEPENDANTUNITID");
            builder.Property(nameof(AtlasModel.SubStoreDefinition.UnitRegistryNo)).HasColumnName("UNITREGISTRYNO");
            builder.Property(nameof(AtlasModel.SubStoreDefinition.UnitCode)).HasColumnName("UNITCODE");
            builder.Property(nameof(AtlasModel.SubStoreDefinition.MKYS_CikisHareketTuru)).HasColumnName("MKYS_CIKISHAREKETTURU").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SubStoreDefinition.StoreResponsibleRef)).HasColumnName("STORERESPONSIBLE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubStoreDefinition.SubStoreMKYSRef)).HasColumnName("SUBSTOREMKYS").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.Store).WithOne().HasForeignKey<AtlasModel.Store>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.StoreResponsible).WithOne().HasForeignKey<AtlasModel.SubStoreDefinition>(x => x.StoreResponsibleRef).IsRequired(false);
            builder.HasOne(t => t.SubStoreMKYS).WithOne().HasForeignKey<AtlasModel.SubStoreDefinition>(x => x.SubStoreMKYSRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}