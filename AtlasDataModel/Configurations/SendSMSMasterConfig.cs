using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SendSMSMasterConfig : IEntityTypeConfiguration<AtlasModel.SendSMSMaster>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SendSMSMaster> builder)
        {
            builder.ToTable("SENDSMSMASTER");
            builder.HasKey(nameof(AtlasModel.SendSMSMaster.ObjectId));
            builder.Property(nameof(AtlasModel.SendSMSMaster.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SendSMSMaster.MessageText)).HasColumnName("MESSAGETEXT").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.SendSMSMaster.IsPatientSMS)).HasColumnName("ISPATIENTSMS");
            builder.Property(nameof(AtlasModel.SendSMSMaster.Cancelled)).HasColumnName("CANCELLED");
            builder.Property(nameof(AtlasModel.SendSMSMaster.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.SendSMSMaster>(x => x.ResUserRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}