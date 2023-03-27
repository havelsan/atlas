using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSSUTVSConfig : IEntityTypeConfiguration<AtlasModel.SKRSSUTVS>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSSUTVS> builder)
        {
            builder.ToTable("SKRSSUTVS");
            builder.HasKey(nameof(AtlasModel.SKRSSUTVS.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSSUTVS.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSSUTVS.MSVSKODU)).HasColumnName("MSVSKODU");
            builder.Property(nameof(AtlasModel.SKRSSUTVS.MSVSADI)).HasColumnName("MSVSADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSSUTVS.SUTKODU)).HasColumnName("SUTKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSSUTVS.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSSUTVS.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}