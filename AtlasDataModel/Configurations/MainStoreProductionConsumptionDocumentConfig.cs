using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MainStoreProductionConsumptionDocumentConfig : IEntityTypeConfiguration<AtlasModel.MainStoreProductionConsumptionDocument>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MainStoreProductionConsumptionDocument> builder)
        {
            builder.ToTable("MSCONSUMPTIONDOCUMENT");
            builder.HasKey(nameof(AtlasModel.MainStoreProductionConsumptionDocument.ObjectId));
            builder.Property(nameof(AtlasModel.MainStoreProductionConsumptionDocument.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MainStoreProductionConsumptionDocument.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.MainStoreProductionConsumptionDocument.FillingDate)).HasColumnName("FILLINGDATE");
            builder.Property(nameof(AtlasModel.MainStoreProductionConsumptionDocument.StartDate)).HasColumnName("STARTDATE");
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}