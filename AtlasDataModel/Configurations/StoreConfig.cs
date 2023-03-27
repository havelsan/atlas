using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StoreConfig : IEntityTypeConfiguration<AtlasModel.Store>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Store> builder)
        {
            builder.ToTable("STORE");
            builder.HasKey(nameof(AtlasModel.Store.ObjectId));
            builder.Property(nameof(AtlasModel.Store.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Store.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Store.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.Store.ID)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.Store.Status)).HasColumnName("STATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.Store.QREF)).HasColumnName("QREF").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Store.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.Store.AutoReturningDocumentCreat)).HasColumnName("AUTORETURNINGDOCUMENTCREAT");
            builder.Property(nameof(AtlasModel.Store.MkysStore)).HasColumnName("MKYSSTORE");
            builder.Property(nameof(AtlasModel.Store.IsEmergencyStore)).HasColumnName("ISEMERGENCYSTORE");
            builder.Property(nameof(AtlasModel.Store.UnitStoreGetDataRef)).HasColumnName("UNITSTOREGETDATA").HasMaxLength(36).IsFixedLength();
        }
    }
}