using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DispatchToOtherHospitalConfig : IEntityTypeConfiguration<AtlasModel.DispatchToOtherHospital>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DispatchToOtherHospital> builder)
        {
            builder.ToTable("DISPATCHTOOTHERHOSPITAL");
            builder.HasKey(nameof(AtlasModel.DispatchToOtherHospital.ObjectId));
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.MedulaSiteCode)).HasColumnName("MEDULASITECODE");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.DispatcherDoctorName)).HasColumnName("DISPATCHERDOCTORNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.DispatcherDoctorEmploymentID)).HasColumnName("DISPATCHERDOCTOREMPLOYMENTID").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.DispatchedDoctorName)).HasColumnName("DISPATCHEDDOCTORNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.DispatchedDoctorEmploymentID)).HasColumnName("DISPATCHEDDOCTOREMPLOYMENTID").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.DispatcherDoctorDiplomaRegNo)).HasColumnName("DISPATCHERDOCTORDIPLOMAREGNO").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.DispatchedDoctorDiplomaRegNo)).HasColumnName("DISPATCHEDDOCTORDIPLOMAREGNO").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.ReasonOfDispatch)).HasColumnName("REASONOFDISPATCH").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.CompanionReason)).HasColumnName("COMPANIONREASON").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.DispatchVehicle)).HasColumnName("DISPATCHVEHICLE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.SourceObjectID)).HasColumnName("SOURCEOBJECTID");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.TargetObjectID)).HasColumnName("TARGETOBJECTID");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.MedulaRefakatciDurumu)).HasColumnName("MEDULAREFAKATCIDURUMU");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.MutatDisiAracRaporId)).HasColumnName("MUTATDISIARACRAPORID");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.MutatDisiAracRaporTarihi)).HasColumnName("MUTATDISIARACRAPORTARIHI");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.MutatDisiAracBitisTarihi)).HasColumnName("MUTATDISIARACBITISTARIHI");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.MutatDisiAracBaslangicTarihi)).HasColumnName("MUTATDISIARACBASLANGICTARIHI");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.MutatDisiGerekcesi)).HasColumnName("MUTATDISIGEREKCESI");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.MedulaSevkTakipNo)).HasColumnName("MEDULASEVKTAKIPNO");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.MessageID)).HasColumnName("MESSAGEID");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.TargetEpisodeObjectID)).HasColumnName("TARGETEPISODEOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.GSSOwnerName)).HasColumnName("GSSOWNERNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.RestingStartDate)).HasColumnName("RESTINGSTARTDATE");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.CompanionStatus)).HasColumnName("COMPANIONSTATUS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.RestingEndDate)).HasColumnName("RESTINGENDDATE");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.MutatDisiAracXXXXXXRaporID)).HasColumnName("MUTATDISIARACXXXXXXRAPORID");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.GSSOwnerUniquerefNo)).HasColumnName("GSSOWNERUNIQUEREFNO");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.EpicrisisDelivered)).HasColumnName("EPICRISISDELIVERED");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.NeedSpecialEquipment)).HasColumnName("NEEDSPECIALEQUIPMENT");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.IlSinir)).HasColumnName("ILSINIR").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.DispatcherDoctorRef)).HasColumnName("DISPATCHERDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.RequestedSiteRef)).HasColumnName("REQUESTEDSITE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.DispatchedSpecialityRef)).HasColumnName("DISPATCHEDSPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.DispatchedDoctorRef)).HasColumnName("DISPATCHEDDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.RequestedReferableResourceRef)).HasColumnName("REQUESTEDREFERABLERESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.RequestedReferableHospitalRef)).HasColumnName("REQUESTEDREFERABLEHOSPITAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.RequestedExternalHospitalRef)).HasColumnName("REQUESTEDEXTERNALHOSPITAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.RequestedExternalDepartmentRef)).HasColumnName("REQUESTEDEXTERNALDEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.RequesterHospitalRef)).HasColumnName("REQUESTERHOSPITAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.RequesterSiteRef)).HasColumnName("REQUESTERSITE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.SevkVasitasiRef)).HasColumnName("SEVKVASITASI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.SevkNedeniRef)).HasColumnName("SEVKNEDENI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.SevkTedaviTipiRef)).HasColumnName("SEVKTEDAVITIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DispatchToOtherHospital.DispatchCityRef)).HasColumnName("DISPATCHCITY").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.DispatcherDoctor).WithOne().HasForeignKey<AtlasModel.DispatchToOtherHospital>(x => x.DispatcherDoctorRef).IsRequired(false);
            builder.HasOne(t => t.DispatchedDoctor).WithOne().HasForeignKey<AtlasModel.DispatchToOtherHospital>(x => x.DispatchedDoctorRef).IsRequired(false);
            builder.HasOne(t => t.RequestedReferableResource).WithOne().HasForeignKey<AtlasModel.DispatchToOtherHospital>(x => x.RequestedReferableResourceRef).IsRequired(false);
            builder.HasOne(t => t.RequestedExternalHospital).WithOne().HasForeignKey<AtlasModel.DispatchToOtherHospital>(x => x.RequestedExternalHospitalRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}