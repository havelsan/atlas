using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSICDMSVSIliskisiConfig : IEntityTypeConfiguration<AtlasModel.SKRSICDMSVSIliskisi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSICDMSVSIliskisi> builder)
        {
            builder.ToTable("SKRSICDMSVSILISKISI");
            builder.HasKey(nameof(AtlasModel.SKRSICDMSVSIliskisi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSICDMSVSIliskisi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSICDMSVSIliskisi.ICDKODU)).HasColumnName("ICDKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDMSVSIliskisi.MSVSKODU)).HasColumnName("MSVSKODU");
            builder.Property(nameof(AtlasModel.SKRSICDMSVSIliskisi.MSVSADI)).HasColumnName("MSVSADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDMSVSIliskisi.CINSIYETKODU)).HasColumnName("CINSIYETKODU").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDMSVSIliskisi.CINSIYETADI)).HasColumnName("CINSIYETADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSICDMSVSIliskisi.GUNCELLENMETARIHI)).HasColumnName("GUNCELLENMETARIHI");
            builder.Property(nameof(AtlasModel.SKRSICDMSVSIliskisi.OLUSTURULMATARIHI)).HasColumnName("OLUSTURULMATARIHI");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}