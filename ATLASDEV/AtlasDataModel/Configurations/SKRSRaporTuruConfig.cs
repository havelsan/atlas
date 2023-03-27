using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSRaporTuruConfig : IEntityTypeConfiguration<AtlasModel.SKRSRaporTuru>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSRaporTuru> builder)
        {
            builder.ToTable("SKRSRAPORTURU");
            builder.HasKey(nameof(AtlasModel.SKRSRaporTuru.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSRaporTuru.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSRaporTuru.RaporGrubu)).HasColumnName("RAPORGRUBU").HasMaxLength(250);
            builder.HasOne(t => t.BaseSKRSCommonDef).WithOne().HasForeignKey<AtlasModel.BaseSKRSCommonDef>(p => p.ObjectId);
        }
    }
}