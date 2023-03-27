using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DiyabetKompBilgisiConfig : IEntityTypeConfiguration<AtlasModel.DiyabetKompBilgisi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DiyabetKompBilgisi> builder)
        {
            builder.ToTable("DIYABETKOMPBILGISI");
            builder.HasKey(nameof(AtlasModel.DiyabetKompBilgisi.ObjectId));
            builder.Property(nameof(AtlasModel.DiyabetKompBilgisi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DiyabetKompBilgisi.DiyabetVeriSetiRef)).HasColumnName("DIYABETVERISETI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DiyabetKompBilgisi.SKRSDiyabetKomplikasyonlariRef)).HasColumnName("SKRSDIYABETKOMPLIKASYONLARI").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DiyabetVeriSeti).WithOne().HasForeignKey<AtlasModel.DiyabetKompBilgisi>(x => x.DiyabetVeriSetiRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}