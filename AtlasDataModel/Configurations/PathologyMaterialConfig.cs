using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PathologyMaterialConfig : IEntityTypeConfiguration<AtlasModel.PathologyMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PathologyMaterial> builder)
        {
            builder.ToTable("PATHOLOGYMATERIAL");
            builder.HasKey(nameof(AtlasModel.PathologyMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.PathologyMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PathologyMaterial.ClinicalFindings)).HasColumnName("CLINICALFINDINGS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.PathologyMaterial.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.PathologyMaterial.DateOfSampleTaken)).HasColumnName("DATEOFSAMPLETAKEN");
            builder.Property(nameof(AtlasModel.PathologyMaterial.Macroscopy)).HasColumnName("MACROSCOPY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.Microscopy)).HasColumnName("MICROSCOPY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.Note)).HasColumnName("NOTE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.PathologicDiagnosis)).HasColumnName("PATHOLOGICDIAGNOSIS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.Frozen)).HasColumnName("FROZEN");
            builder.Property(nameof(AtlasModel.PathologyMaterial.Malign)).HasColumnName("MALIGN");
            builder.Property(nameof(AtlasModel.PathologyMaterial.MaterialNumber)).HasColumnName("MATERIALNUMBER").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PathologyMaterial.No)).HasColumnName("NO");
            builder.Property(nameof(AtlasModel.PathologyMaterial.SuspiciousMalign)).HasColumnName("SUSPICIOUSMALIGN");
            builder.Property(nameof(AtlasModel.PathologyMaterial.Benign)).HasColumnName("BENIGN");
            builder.Property(nameof(AtlasModel.PathologyMaterial.AlindigiDokununTemelOzelligiRef)).HasColumnName("ALINDIGIDOKUNUNTEMELOZELLIGI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.MorfolojiKoduRef)).HasColumnName("MORFOLOJIKODU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.NumuneAlinmaSekliRef)).HasColumnName("NUMUNEALINMASEKLI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.PatolojiPreparatiDurumuRef)).HasColumnName("PATOLOJIPREPARATIDURUMU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.YerlesimYeriRef)).HasColumnName("YERLESIMYERI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.PathologyRequestRef)).HasColumnName("PATHOLOGYREQUEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.PathologyRef)).HasColumnName("PATHOLOGY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.ReasonForPathologyRejectionRef)).HasColumnName("REASONFORPATHOLOGYREJECTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyMaterial.KavanozTipiRef)).HasColumnName("KAVANOZTIPI").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.MorfolojiKodu).WithOne().HasForeignKey<AtlasModel.PathologyMaterial>(x => x.MorfolojiKoduRef).IsRequired(false);
            builder.HasOne(t => t.YerlesimYeri).WithOne().HasForeignKey<AtlasModel.PathologyMaterial>(x => x.YerlesimYeriRef).IsRequired(false);
            builder.HasOne(t => t.PathologyRequest).WithOne().HasForeignKey<AtlasModel.PathologyMaterial>(x => x.PathologyRequestRef).IsRequired(false);
            builder.HasOne(t => t.Pathology).WithOne().HasForeignKey<AtlasModel.PathologyMaterial>(x => x.PathologyRef).IsRequired(false);
            builder.HasOne(t => t.KavanozTipi).WithOne().HasForeignKey<AtlasModel.PathologyMaterial>(x => x.KavanozTipiRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}