using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SendSMSDetailConfig : IEntityTypeConfiguration<AtlasModel.SendSMSDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SendSMSDetail> builder)
        {
            builder.ToTable("SENDSMSDETAIL");
            builder.HasKey(nameof(AtlasModel.SendSMSDetail.ObjectId));
            builder.Property(nameof(AtlasModel.SendSMSDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SendSMSDetail.FirstName)).HasColumnName("FIRSTNAME");
            builder.Property(nameof(AtlasModel.SendSMSDetail.SurName)).HasColumnName("SURNAME");
            builder.Property(nameof(AtlasModel.SendSMSDetail.PhoneNumber)).HasColumnName("PHONENUMBER");
            builder.Property(nameof(AtlasModel.SendSMSDetail.SendSMSMasterRef)).HasColumnName("SENDSMSMASTER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SendSMSDetail.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SendSMSDetail.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SendSMSMaster).WithOne().HasForeignKey<AtlasModel.SendSMSDetail>(x => x.SendSMSMasterRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.SendSMSDetail>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.SendSMSDetail>(x => x.PatientRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}