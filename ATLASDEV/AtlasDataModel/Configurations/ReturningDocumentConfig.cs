using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReturningDocumentConfig : IEntityTypeConfiguration<AtlasModel.ReturningDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReturningDocument> builder)
        {
            builder.ToTable("RETURNINGDOCUMENT");
            builder.HasKey(nameof(AtlasModel.ReturningDocument.ObjectId));
            builder.Property(nameof(AtlasModel.ReturningDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReturningDocument.FillingDate)).HasColumnName("FILLINGDATE");
            builder.Property(nameof(AtlasModel.ReturningDocument.RepairObjectID)).HasColumnName("REPAIROBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReturningDocument.MaterialRepairObjectID)).HasColumnName("MATERIALREPAIROBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReturningDocument.ReturnDepStoreObjectID)).HasColumnName("RETURNDEPSTOREOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ReturningDocument.IsChattelDocFlag)).HasColumnName("ISCHATTELDOCFLAG");
            builder.Property(nameof(AtlasModel.ReturningDocument.BaseDateTime)).HasColumnName("BASEDATETIME");
            builder.Property(nameof(AtlasModel.ReturningDocument.BaseNumber)).HasColumnName("BASENUMBER").HasMaxLength(250);
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}