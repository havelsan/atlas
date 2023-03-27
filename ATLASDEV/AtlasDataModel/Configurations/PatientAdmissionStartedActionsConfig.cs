using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientAdmissionStartedActionsConfig : IEntityTypeConfiguration<AtlasModel.PatientAdmissionStartedActions>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientAdmissionStartedActions> builder)
        {
            builder.ToTable("PASTARTEDACTIONS");
            builder.HasKey(nameof(AtlasModel.PatientAdmissionStartedActions.ObjectId));
            builder.Property(nameof(AtlasModel.PatientAdmissionStartedActions.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientAdmissionStartedActions.DefaultActionType)).HasColumnName("DEFAULTACTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientAdmissionStartedActions.AdmissionStatus)).HasColumnName("ADMISSIONSTATUS").HasColumnType("NUMBER(10)");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}