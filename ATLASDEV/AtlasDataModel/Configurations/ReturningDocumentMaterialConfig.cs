using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ReturningDocumentMaterialConfig : IEntityTypeConfiguration<AtlasModel.ReturningDocumentMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ReturningDocumentMaterial> builder)
        {
            builder.ToTable("RETURNINGDOCUMENTMATERIAL");
            builder.HasKey(nameof(AtlasModel.ReturningDocumentMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.ReturningDocumentMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ReturningDocumentMaterial.RequireAmount)).HasColumnName("REQUIREAMOUNT").HasColumnType("NUMBER(15,4)");
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}