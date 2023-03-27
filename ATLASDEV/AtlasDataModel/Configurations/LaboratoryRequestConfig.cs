using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LaboratoryRequestConfig : IEntityTypeConfiguration<AtlasModel.LaboratoryRequest>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LaboratoryRequest> builder)
        {
            builder.ToTable("LABORATORYREQUEST");
            builder.HasKey(nameof(AtlasModel.LaboratoryRequest.ObjectId));
            builder.Property(nameof(AtlasModel.LaboratoryRequest.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LaboratoryRequest.Prediagnosis)).HasColumnName("PREDIAGNOSIS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.LaboratoryRequest.Urgent)).HasColumnName("URGENT");
            builder.Property(nameof(AtlasModel.LaboratoryRequest.PatientSex)).HasColumnName("PATIENTSEX").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LaboratoryRequest.Notes)).HasColumnName("NOTES").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.LaboratoryRequest.LastMensturationDate)).HasColumnName("LASTMENSTURATIONDATE");
            builder.Property(nameof(AtlasModel.LaboratoryRequest.ProtocolNo)).HasColumnName("PROTOCOLNO");
            builder.Property(nameof(AtlasModel.LaboratoryRequest.BarcodeID)).HasColumnName("BARCODEID");
            builder.Property(nameof(AtlasModel.LaboratoryRequest.PatientAge)).HasColumnName("PATIENTAGE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.LaboratoryRequest.LabRequestAcceptionDate)).HasColumnName("LABREQUESTACCEPTIONDATE");
            builder.Property(nameof(AtlasModel.LaboratoryRequest.Pregnancy)).HasColumnName("PREGNANCY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LaboratoryRequest.MessageID)).HasColumnName("MESSAGEID");
            builder.Property(nameof(AtlasModel.LaboratoryRequest.TargetObjectID)).HasColumnName("TARGETOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryRequest.SourceObjectID)).HasColumnName("SOURCEOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryRequest.IsRequestSent)).HasColumnName("ISREQUESTSENT");
            builder.Property(nameof(AtlasModel.LaboratoryRequest.LaboratoryRequestTemplateRef)).HasColumnName("LABORATORYREQUESTTEMPLATE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryRequest.RequestDoctorRef)).HasColumnName("REQUESTDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryRequest.MasterTestDefinitionRef)).HasColumnName("MASTERTESTDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryRequest.ApprovedByRef)).HasColumnName("APPROVEDBY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryRequest.LaboratoryTripleTestInfoRef)).HasColumnName("LABORATORYTRIPLETESTINFO").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryRequest.LaboratoryBinaryScanInfoRef)).HasColumnName("LABORATORYBINARYSCANINFO").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeActionWithDiagnosis).WithOne().HasForeignKey<AtlasModel.EpisodeActionWithDiagnosis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.RequestDoctor).WithOne().HasForeignKey<AtlasModel.LaboratoryRequest>(x => x.RequestDoctorRef).IsRequired(false);
            builder.HasOne(t => t.MasterTestDefinition).WithOne().HasForeignKey<AtlasModel.LaboratoryRequest>(x => x.MasterTestDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.ApprovedBy).WithOne().HasForeignKey<AtlasModel.LaboratoryRequest>(x => x.ApprovedByRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}