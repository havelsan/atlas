using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DoctorQuotaDefinitionConfig : IEntityTypeConfiguration<AtlasModel.DoctorQuotaDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DoctorQuotaDefinition> builder)
        {
            builder.ToTable("DOCTORQUOTADEF");
            builder.HasKey(nameof(AtlasModel.DoctorQuotaDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.DoctorQuotaDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DoctorQuotaDefinition.WorkDate)).HasColumnName("WORKDATE");
            builder.Property(nameof(AtlasModel.DoctorQuotaDefinition.Quota)).HasColumnName("QUOTA").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DoctorQuotaDefinition.Active)).HasColumnName("ACTIVE");
            builder.Property(nameof(AtlasModel.DoctorQuotaDefinition.AutomaticReception)).HasColumnName("AUTOMATICRECEPTION");
            builder.Property(nameof(AtlasModel.DoctorQuotaDefinition.PoliclinicRef)).HasColumnName("POLICLINIC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DoctorQuotaDefinition.ProcedureDoctorRef)).HasColumnName("PROCEDUREDOCTOR").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Policlinic).WithOne().HasForeignKey<AtlasModel.DoctorQuotaDefinition>(x => x.PoliclinicRef).IsRequired(false);
            builder.HasOne(t => t.ProcedureDoctor).WithOne().HasForeignKey<AtlasModel.DoctorQuotaDefinition>(x => x.ProcedureDoctorRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}