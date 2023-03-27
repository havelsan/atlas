using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LaboratoryProcedureConfig : IEntityTypeConfiguration<AtlasModel.LaboratoryProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LaboratoryProcedure> builder)
        {
            builder.ToTable("LABORATORYPROCEDURE");
            builder.HasKey(nameof(AtlasModel.LaboratoryProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.TechnicianApproveDate)).HasColumnName("TECHNICIANAPPROVEDATE");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.Reference)).HasColumnName("REFERENCE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.Warning)).HasColumnName("WARNING").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.Result)).HasColumnName("RESULT");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.Check)).HasColumnName("CHECK");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.TechnicianID)).HasColumnName("TECHNICIANID");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.OwnerType)).HasColumnName("OWNERTYPE").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.Unit)).HasColumnName("UNIT").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.BarcodeId)).HasColumnName("BARCODEID");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.IsAntibiogram)).HasColumnName("ISANTIBIOGRAM");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.ResultDate)).HasColumnName("RESULTDATE");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.LongReport)).HasColumnName("LONGREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.MicrobiologyPanicNotification)).HasColumnName("MICROBIOLOGYPANICNOTIFICATION");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.Panic)).HasColumnName("PANIC").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.TestGroup)).HasColumnName("TESTGROUP").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.Environment)).HasColumnName("ENVIRONMENT").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.drAnesteziTescilNo)).HasColumnName("DRANESTEZITESCILNO");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.AcceptDate)).HasColumnName("ACCEPTDATE");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.ApproveDate)).HasColumnName("APPROVEDATE");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.ProcedureDate)).HasColumnName("PROCEDUREDATE");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.ResultDescription)).HasColumnName("RESULTDESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.ProcessNote)).HasColumnName("PROCESSNOTE").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.Report)).HasColumnName("REPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.RequestDate)).HasColumnName("REQUESTDATE");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.RequestNote)).HasColumnName("REQUESTNOTE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.SampleAcceptionDate)).HasColumnName("SAMPLEACCEPTIONDATE");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.SampleDate)).HasColumnName("SAMPLEDATE");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.SpecialReference)).HasColumnName("SPECIALREFERENCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.Techniciannote)).HasColumnName("TECHNICIANNOTE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.TestDefID)).HasColumnName("TESTDEFID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.IsResultSeen)).HasColumnName("ISRESULTSEEN");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.SpecimenId)).HasColumnName("SPECIMENID");
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.MasterTestDefRef)).HasColumnName("MASTERTESTDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.TubeInformationRef)).HasColumnName("TUBEINFORMATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.AcceptUserRef)).HasColumnName("ACCEPTUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.ProcedureDepartmentRef)).HasColumnName("PROCEDUREDEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.ProcedureUserRef)).HasColumnName("PROCEDUREUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.AcceptResourceRef)).HasColumnName("ACCEPTRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.EquipmentRef)).HasColumnName("EQUIPMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.RequestedTabRef)).HasColumnName("REQUESTEDTAB").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.AyniFarkliKesiRef)).HasColumnName("AYNIFARKLIKESI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.SagSolRef)).HasColumnName("SAGSOL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.SampleRejectionReasonRef)).HasColumnName("SAMPLEREJECTIONREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.AnesteziDoktorRef)).HasColumnName("ANESTEZIDOKTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.UserOfSampleRejectionRef)).HasColumnName("USEROFSAMPLEREJECTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.RequestResourceRef)).HasColumnName("REQUESTRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.RequestUserRef)).HasColumnName("REQUESTUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.SampleResourceRef)).HasColumnName("SAMPLERESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.SampleUserRef)).HasColumnName("SAMPLEUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratoryProcedure.ApproveUserRef)).HasColumnName("APPROVEUSER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubactionProcedureFlowable).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MasterTestDef).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.MasterTestDefRef).IsRequired(false);
            builder.HasOne(t => t.TubeInformation).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.TubeInformationRef).IsRequired(false);
            builder.HasOne(t => t.AcceptUser).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.AcceptUserRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDepartment).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.ProcedureDepartmentRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureUser).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.ProcedureUserRef).IsRequired(false);
            builder.HasOne(t => t.AcceptResource).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.AcceptResourceRef).IsRequired(false);
            builder.HasOne(t => t.AnesteziDoktor).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.AnesteziDoktorRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.UserOfSampleRejection).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.UserOfSampleRejectionRef).IsRequired(false);
            builder.HasOne(t => t.RequestResource).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.RequestResourceRef).IsRequired(false);
            builder.HasOne(t => t.RequestUser).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.RequestUserRef).IsRequired(false);
            builder.HasOne(t => t.SampleResource).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.SampleResourceRef).IsRequired(false);
            builder.HasOne(t => t.SampleUser).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.SampleUserRef).IsRequired(false);
            builder.HasOne(t => t.ApproveUser).WithOne().HasForeignKey<AtlasModel.LaboratoryProcedure>(x => x.ApproveUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}