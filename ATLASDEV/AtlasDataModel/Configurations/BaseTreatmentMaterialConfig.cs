using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseTreatmentMaterialConfig : IEntityTypeConfiguration<AtlasModel.BaseTreatmentMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseTreatmentMaterial> builder)
        {
            builder.ToTable("BASETREATMENTMATERIAL");
            builder.HasKey(nameof(AtlasModel.BaseTreatmentMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.Note)).HasColumnName("NOTE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.Kdv)).HasColumnName("KDV");
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.MalzemeBrans)).HasColumnName("MALZEMEBRANS").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.MalzemeSatinAlisTarihi)).HasColumnName("MALZEMESATINALISTARIHI");
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.KodsuzMalzemeFiyati)).HasColumnName("KODSUZMALZEMEFIYATI").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.UnitPrice)).HasColumnName("UNITPRICE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.DealerNo)).HasColumnName("DEALERNO").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.SubactionProcedureFlowableRef)).HasColumnName("SUBACTIONPROCEDUREFLOWABLE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.MalzemeTuruRef)).HasColumnName("MALZEMETURU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.EpisodeActionRef)).HasColumnName("EPISODEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.SetMaterialRef)).HasColumnName("SETMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseTreatmentMaterial.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionMaterial).WithOne().HasForeignKey<AtlasModel.SubActionMaterial>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SubactionProcedureFlowable).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(x => x.SubactionProcedureFlowableRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(x => x.EpisodeActionRef).IsRequired(false);
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.BaseTreatmentMaterial>(x => x.PatientRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}