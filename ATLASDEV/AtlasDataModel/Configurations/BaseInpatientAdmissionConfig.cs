using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseInpatientAdmissionConfig : IEntityTypeConfiguration<AtlasModel.BaseInpatientAdmission>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseInpatientAdmission> builder)
        {
            builder.ToTable("BASEINPATIENTADMISSION");
            builder.HasKey(nameof(AtlasModel.BaseInpatientAdmission.ObjectId));
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.ReasonForInpatientAdmission)).HasColumnName("REASONFORINPATIENTADMISSION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.NoCupboard)).HasColumnName("NOCUPBOARD");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.GivenAndTakenStatus)).HasColumnName("GIVENANDTAKENSTATUS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.RiskWarningLastSeenDate)).HasColumnName("RISKWARNINGLASTSEENDATE");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.NeedCompanion)).HasColumnName("NEEDCOMPANION");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.HasTightContactIsolation)).HasColumnName("HASTIGHTCONTACTISOLATION");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.EstimatedInpatientDateCount)).HasColumnName("ESTIMATEDINPATIENTDATECOUNT");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.EstimatedDischargeDate)).HasColumnName("ESTIMATEDDISCHARGEDATE");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.EstimatedInpatientDate)).HasColumnName("ESTIMATEDINPATIENTDATE");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.HasFallingRisk)).HasColumnName("HASFALLINGRISK");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.HasDropletIsolation)).HasColumnName("HASDROPLETISOLATION");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.HasContactIsolation)).HasColumnName("HASCONTACTISOLATION");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.HasAirborneContactIsolation)).HasColumnName("HASAIRBORNECONTACTISOLATION");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.HospitalDischargeDate)).HasColumnName("HOSPITALDISCHARGEDATE");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.HospitalInPatientDate)).HasColumnName("HOSPITALINPATIENTDATE");
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.RoomRef)).HasColumnName("ROOM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.PhysicalStateClinicRef)).HasColumnName("PHYSICALSTATECLINIC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.BedRef)).HasColumnName("BED").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.RoomGroupRef)).HasColumnName("ROOMGROUP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.TreatmentClinicRef)).HasColumnName("TREATMENTCLINIC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.InpatientReasonRef)).HasColumnName("INPATIENTREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseInpatientAdmission.EpisodeFolderRef)).HasColumnName("EPISODEFOLDER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Room).WithOne().HasForeignKey<AtlasModel.BaseInpatientAdmission>(x => x.RoomRef).IsRequired(false);
            builder.HasOne(t => t.PhysicalStateClinic).WithOne().HasForeignKey<AtlasModel.BaseInpatientAdmission>(x => x.PhysicalStateClinicRef).IsRequired(false);
            builder.HasOne(t => t.Bed).WithOne().HasForeignKey<AtlasModel.BaseInpatientAdmission>(x => x.BedRef).IsRequired(false);
            builder.HasOne(t => t.RoomGroup).WithOne().HasForeignKey<AtlasModel.BaseInpatientAdmission>(x => x.RoomGroupRef).IsRequired(false);
            builder.HasOne(t => t.TreatmentClinic).WithOne().HasForeignKey<AtlasModel.BaseInpatientAdmission>(x => x.TreatmentClinicRef).IsRequired(false);
            builder.HasOne(t => t.EpisodeFolder).WithOne().HasForeignKey<AtlasModel.BaseInpatientAdmission>(x => x.EpisodeFolderRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}