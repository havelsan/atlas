using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PhysiotherapyOrderConfig : IEntityTypeConfiguration<AtlasModel.PhysiotherapyOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PhysiotherapyOrder> builder)
        {
            builder.ToTable("PHYSIOTHERAPYORDER");
            builder.HasKey(nameof(AtlasModel.PhysiotherapyOrder.ObjectId));
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.TreatmentProperties)).HasColumnName("TREATMENTPROPERTIES").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.ApplicationArea)).HasColumnName("APPLICATIONAREA").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.Duration)).HasColumnName("DURATION");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.SeansGunSayisi)).HasColumnName("SEANSGUNSAYISI");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.drAnesteziTescilNo)).HasColumnName("DRANESTEZITESCILNO");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.Dose)).HasColumnName("DOSE");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.StartSession)).HasColumnName("STARTSESSION");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.FinishSession)).HasColumnName("FINISHSESSION");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.IncludeSaturday)).HasColumnName("INCLUDESATURDAY");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.IncludeSunday)).HasColumnName("INCLUDESUNDAY");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.IsAdditionalTreatment)).HasColumnName("ISADDITIONALTREATMENT");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.IsChangedAutomatically)).HasColumnName("ISCHANGEDAUTOMATICALLY");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.IncludeTuesday)).HasColumnName("INCLUDETUESDAY");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.IncludeMonday)).HasColumnName("INCLUDEMONDAY");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.IncludeWednesday)).HasColumnName("INCLUDEWEDNESDAY");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.IncludeThursday)).HasColumnName("INCLUDETHURSDAY");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.IncludeFriday)).HasColumnName("INCLUDEFRIDAY");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.IsPaidTreatment)).HasColumnName("ISPAIDTREATMENT");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.raporTakipNo)).HasColumnName("RAPORTAKIPNO");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.DoseDurationInfo)).HasColumnName("DOSEDURATIONINFO").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.SessionCount)).HasColumnName("SESSIONCOUNT");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.PhysiotherapyStartDate)).HasColumnName("PHYSIOTHERAPYSTARTDATE");
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.PhysiotherapyRequestRef)).HasColumnName("PHYSIOTHERAPYREQUEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.TreatmentDiagnosisUnitRef)).HasColumnName("TREATMENTDIAGNOSISUNIT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.FTRApplicationAreaDefRef)).HasColumnName("FTRAPPLICATIONAREADEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.TreatmentRoomRef)).HasColumnName("TREATMENTROOM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.AyniFarkliKesiRef)).HasColumnName("AYNIFARKLIKESI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyOrder.PackageProcedureRef)).HasColumnName("PACKAGEPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BasePhysiotherapyOrder).WithOne().HasForeignKey<AtlasModel.BasePhysiotherapyOrder>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.PhysiotherapyRequest).WithOne().HasForeignKey<AtlasModel.PhysiotherapyOrder>(x => x.PhysiotherapyRequestRef).IsRequired(false);
            builder.HasOne(t => t.TreatmentDiagnosisUnit).WithOne().HasForeignKey<AtlasModel.PhysiotherapyOrder>(x => x.TreatmentDiagnosisUnitRef).IsRequired(true);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.PhysiotherapyOrder>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.PhysiotherapyOrder>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.PackageProcedure).WithOne().HasForeignKey<AtlasModel.PhysiotherapyOrder>(x => x.PackageProcedureRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}