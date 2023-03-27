using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockOutConfig : IEntityTypeConfiguration<AtlasModel.StockOut>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockOut> builder)
        {
            builder.ToTable("STOCKOUT");
            builder.HasKey(nameof(AtlasModel.StockOut.ObjectId));
            builder.Property(nameof(AtlasModel.StockOut.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockOut.CreateRemote)).HasColumnName("CREATEREMOTE");
            builder.Property(nameof(AtlasModel.StockOut.ProductionDepStoreObjectID)).HasColumnName("PRODUCTIONDEPSTOREOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);
        }
    }
}