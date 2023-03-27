using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSGKDTARAMASONUCUConfig : IEntityTypeConfiguration<AtlasModel.SKRSGKDTARAMASONUCU>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSGKDTARAMASONUCU> builder)
        {
            builder.ToTable("SKRSGKDTARAMASONUCU");
            builder.HasKey(nameof(AtlasModel.SKRSGKDTARAMASONUCU.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSGKDTARAMASONUCU.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSGKDTARAMASONUCU.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSGKDTARAMASONUCU.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSGKDTARAMASONUCU.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}