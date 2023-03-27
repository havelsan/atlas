using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SigortaliAdliGecmisiConfig : IEntityTypeConfiguration<AtlasModel.SigortaliAdliGecmisi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SigortaliAdliGecmisi> builder)
        {
            builder.ToTable("SIGORTALIADLIGECMISI");
            builder.HasKey(nameof(AtlasModel.SigortaliAdliGecmisi.ObjectId));
            builder.Property(nameof(AtlasModel.SigortaliAdliGecmisi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SigortaliAdliGecmisi.tckNo)).HasColumnName("TCKNO");
            builder.Property(nameof(AtlasModel.SigortaliAdliGecmisi.provTipi)).HasColumnName("PROVTIPI");
            builder.Property(nameof(AtlasModel.SigortaliAdliGecmisi.provTarihi)).HasColumnName("PROVTARIHI");
            builder.Property(nameof(AtlasModel.SigortaliAdliGecmisi.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.SigortaliAdliGecmisi>(x => x.PatientRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}