using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PhysiotherapyRequestConfig : IEntityTypeConfiguration<AtlasModel.PhysiotherapyRequest>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PhysiotherapyRequest> builder)
        {
            builder.ToTable("PHYSIOTHERAPYREQUEST");
            builder.HasKey(nameof(AtlasModel.PhysiotherapyRequest.ObjectId));
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.NoteToPhysiotherapist)).HasColumnName("NOTETOPHYSIOTHERAPIST").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.DiagnosisGroup)).HasColumnName("DIAGNOSISGROUP");
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.InPatientsBed)).HasColumnName("INPATIENTSBED");
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.ClinicInformationRTF)).HasColumnName("CLINICINFORMATIONRTF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.MedulaRaporTakipNo)).HasColumnName("MEDULARAPORTAKIPNO");
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.ReportEndDate)).HasColumnName("REPORTENDDATE");
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.ReportStartDate)).HasColumnName("REPORTSTARTDATE");
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.ReportNo)).HasColumnName("REPORTNO");
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.ClinicInformation)).HasColumnName("CLINICINFORMATION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.PhysiotherapyRequestDate)).HasColumnName("PHYSIOTHERAPYREQUESTDATE");
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.PhysiotherapyStartDate)).HasColumnName("PHYSIOTHERAPYSTARTDATE");
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.SecondProcedureDoctorRef)).HasColumnName("SECONDPROCEDUREDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.ThirdProcedureDoctorRef)).HasColumnName("THIRDPROCEDUREDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PhysiotherapyRequest.InpatientBedRef)).HasColumnName("INPATIENTBED").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SecondProcedureDoctor).WithOne().HasForeignKey<AtlasModel.PhysiotherapyRequest>(x => x.SecondProcedureDoctorRef).IsRequired(false);
            builder.HasOne(t => t.ThirdProcedureDoctor).WithOne().HasForeignKey<AtlasModel.PhysiotherapyRequest>(x => x.ThirdProcedureDoctorRef).IsRequired(false);
            builder.HasOne(t => t.InpatientBed).WithOne().HasForeignKey<AtlasModel.PhysiotherapyRequest>(x => x.InpatientBedRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}