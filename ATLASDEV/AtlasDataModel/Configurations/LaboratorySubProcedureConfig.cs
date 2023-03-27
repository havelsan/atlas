using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LaboratorySubProcedureConfig : IEntityTypeConfiguration<AtlasModel.LaboratorySubProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LaboratorySubProcedure> builder)
        {
            builder.ToTable("LABORATORYSUBPROCEDURE");
            builder.HasKey(nameof(AtlasModel.LaboratorySubProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.Result)).HasColumnName("RESULT");
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.Check)).HasColumnName("CHECK");
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.Unit)).HasColumnName("UNIT").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.Reference)).HasColumnName("REFERENCE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.Warning)).HasColumnName("WARNING").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.LabProcedureID)).HasColumnName("LABPROCEDUREID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.MicrobiologyPanicNotification)).HasColumnName("MICROBIOLOGYPANICNOTIFICATION");
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.Panic)).HasColumnName("PANIC").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.AcceptDate)).HasColumnName("ACCEPTDATE");
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.ApproveDate)).HasColumnName("APPROVEDATE");
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.ProcedureDate)).HasColumnName("PROCEDUREDATE");
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.LongReport)).HasColumnName("LONGREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.ResultDescription)).HasColumnName("RESULTDESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.ProcessNote)).HasColumnName("PROCESSNOTE").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.Report)).HasColumnName("REPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.RequestDate)).HasColumnName("REQUESTDATE");
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.RequestNote)).HasColumnName("REQUESTNOTE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.SampleAcceptionDate)).HasColumnName("SAMPLEACCEPTIONDATE");
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.SampleDate)).HasColumnName("SAMPLEDATE");
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.SpecialReference)).HasColumnName("SPECIALREFERENCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.Techniciannote)).HasColumnName("TECHNICIANNOTE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.TestDefID)).HasColumnName("TESTDEFID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.EquipmentRef)).HasColumnName("EQUIPMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.AcceptResourceRef)).HasColumnName("ACCEPTRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.AcceptUserRef)).HasColumnName("ACCEPTUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.ProcedureDepartmentRef)).HasColumnName("PROCEDUREDEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.ProcedureUserRef)).HasColumnName("PROCEDUREUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.RequestResourceRef)).HasColumnName("REQUESTRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.RequestUserRef)).HasColumnName("REQUESTUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.SampleResourceRef)).HasColumnName("SAMPLERESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.LaboratorySubProcedure.SampleUserRef)).HasColumnName("SAMPLEUSER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubactionProcedureFlowable).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.AcceptResource).WithOne().HasForeignKey<AtlasModel.LaboratorySubProcedure>(x => x.AcceptResourceRef).IsRequired(false);
            builder.HasOne(t => t.AcceptUser).WithOne().HasForeignKey<AtlasModel.LaboratorySubProcedure>(x => x.AcceptUserRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDepartment).WithOne().HasForeignKey<AtlasModel.LaboratorySubProcedure>(x => x.ProcedureDepartmentRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureUser).WithOne().HasForeignKey<AtlasModel.LaboratorySubProcedure>(x => x.ProcedureUserRef).IsRequired(false);
            builder.HasOne(t => t.RequestResource).WithOne().HasForeignKey<AtlasModel.LaboratorySubProcedure>(x => x.RequestResourceRef).IsRequired(false);
            builder.HasOne(t => t.RequestUser).WithOne().HasForeignKey<AtlasModel.LaboratorySubProcedure>(x => x.RequestUserRef).IsRequired(false);
            builder.HasOne(t => t.SampleResource).WithOne().HasForeignKey<AtlasModel.LaboratorySubProcedure>(x => x.SampleResourceRef).IsRequired(false);
            builder.HasOne(t => t.SampleUser).WithOne().HasForeignKey<AtlasModel.LaboratorySubProcedure>(x => x.SampleUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}