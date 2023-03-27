using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SendMessageToPatientConfig : IEntityTypeConfiguration<AtlasModel.SendMessageToPatient>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SendMessageToPatient> builder)
        {
            builder.ToTable("SENDMESSAGETOPATIENT");
            builder.HasKey(nameof(AtlasModel.SendMessageToPatient.ObjectId));
            builder.Property(nameof(AtlasModel.SendMessageToPatient.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SendMessageToPatient.MessageInfo)).HasColumnName("MESSAGEINFO").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.SendMessageToPatient.MessageDate)).HasColumnName("MESSAGEDATE");
            builder.Property(nameof(AtlasModel.SendMessageToPatient.SubEpisodeRef)).HasColumnName("SUBEPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SendMessageToPatient.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SendMessageToPatient.SKRSHastaMesajlariRef)).HasColumnName("SKRSHASTAMESAJLARI").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SubEpisode).WithOne().HasForeignKey<AtlasModel.SendMessageToPatient>(x => x.SubEpisodeRef).IsRequired(false);
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.SendMessageToPatient>(x => x.PatientRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}