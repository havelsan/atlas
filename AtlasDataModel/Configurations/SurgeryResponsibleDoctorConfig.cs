using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SurgeryResponsibleDoctorConfig : IEntityTypeConfiguration<AtlasModel.SurgeryResponsibleDoctor>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SurgeryResponsibleDoctor> builder)
        {
            builder.ToTable("SURGERYRESPONSIBLEDOCTOR");
            builder.HasKey(nameof(AtlasModel.SurgeryResponsibleDoctor.ObjectId));
            builder.Property(nameof(AtlasModel.SurgeryResponsibleDoctor.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SurgeryResponsibleDoctor.RankingNumber)).HasColumnName("RANKINGNUMBER");
            builder.Property(nameof(AtlasModel.SurgeryResponsibleDoctor.ResponsibleDoctorRef)).HasColumnName("RESPONSIBLEDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SurgeryResponsibleDoctor.SurgeryProcedureRef)).HasColumnName("SURGERYPROCEDURE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResponsibleDoctor).WithOne().HasForeignKey<AtlasModel.SurgeryResponsibleDoctor>(x => x.ResponsibleDoctorRef).IsRequired(false);
            builder.HasOne(t => t.SurgeryProcedure).WithOne().HasForeignKey<AtlasModel.SurgeryResponsibleDoctor>(x => x.SurgeryProcedureRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}