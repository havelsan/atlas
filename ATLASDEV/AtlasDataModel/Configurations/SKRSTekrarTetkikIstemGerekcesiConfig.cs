using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSTekrarTetkikIstemGerekcesiConfig : IEntityTypeConfiguration<AtlasModel.SKRSTekrarTetkikIstemGerekcesi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSTekrarTetkikIstemGerekcesi> builder)
        {
            builder.ToTable("SKRSTEKRARTETKIKISTEMGEREK");
            builder.HasKey(nameof(AtlasModel.SKRSTekrarTetkikIstemGerekcesi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSTekrarTetkikIstemGerekcesi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSTekrarTetkikIstemGerekcesi.KODTIPIADI)).HasColumnName("KODTIPIADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTekrarTetkikIstemGerekcesi.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSTekrarTetkikIstemGerekcesi.KODU)).HasColumnName("KODU").HasMaxLength(500);
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}