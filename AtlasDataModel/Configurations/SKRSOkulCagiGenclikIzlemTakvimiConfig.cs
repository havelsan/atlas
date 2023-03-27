using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SKRSOkulCagiGenclikIzlemTakvimiConfig : IEntityTypeConfiguration<AtlasModel.SKRSOkulCagiGenclikIzlemTakvimi>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SKRSOkulCagiGenclikIzlemTakvimi> builder)
        {
            builder.ToTable("SKRSOKULCAGIGENCLIKIZLEMTA");
            builder.HasKey(nameof(AtlasModel.SKRSOkulCagiGenclikIzlemTakvimi.ObjectId));
            builder.Property(nameof(AtlasModel.SKRSOkulCagiGenclikIzlemTakvimi.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SKRSOkulCagiGenclikIzlemTakvimi.ADI)).HasColumnName("ADI").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.SKRSOkulCagiGenclikIzlemTakvimi.KODU)).HasColumnName("KODU");
            builder.Property(nameof(AtlasModel.SKRSOkulCagiGenclikIzlemTakvimi.ILKUYGULANMATARIHI)).HasColumnName("ILKUYGULANMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSOkulCagiGenclikIzlemTakvimi.SONUYGULANMATARIHI)).HasColumnName("SONUYGULANMATARIHI");
            builder.Property(nameof(AtlasModel.SKRSOkulCagiGenclikIzlemTakvimi.PERFDAHILMI)).HasColumnName("PERFDAHILMI");
            builder.HasOne(t => t.BaseSKRSDefinition).WithOne().HasForeignKey<AtlasModel.BaseSKRSDefinition>(p => p.ObjectId);
        }
    }
}