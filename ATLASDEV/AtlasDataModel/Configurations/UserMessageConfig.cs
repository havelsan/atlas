using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class UserMessageConfig : IEntityTypeConfiguration<AtlasModel.UserMessage>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.UserMessage> builder)
        {
            builder.ToTable("USERMESSAGE");
            builder.HasKey(nameof(AtlasModel.UserMessage.ObjectId));
            builder.Property(nameof(AtlasModel.UserMessage.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.UserMessage.MessageBody)).HasColumnName("MESSAGEBODY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserMessage.MessageDate)).HasColumnName("MESSAGEDATE");
            builder.Property(nameof(AtlasModel.UserMessage.IsSystemMessage)).HasColumnName("ISSYSTEMMESSAGE");
            builder.Property(nameof(AtlasModel.UserMessage.ReceiverStatus)).HasColumnName("RECEIVERSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.UserMessage.Subject)).HasColumnName("SUBJECT").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.UserMessage.IsPanicMessage)).HasColumnName("ISPANICMESSAGE");
            builder.Property(nameof(AtlasModel.UserMessage.ExpireDate)).HasColumnName("EXPIREDATE");
            builder.Property(nameof(AtlasModel.UserMessage.OpenForm)).HasColumnName("OPENFORM");
            builder.Property(nameof(AtlasModel.UserMessage.IsSplashMessage)).HasColumnName("ISSPLASHMESSAGE");
            builder.Property(nameof(AtlasModel.UserMessage.MessageFeedback)).HasColumnName("MESSAGEFEEDBACK");
            builder.Property(nameof(AtlasModel.UserMessage.UserMessageID)).HasColumnName("USERMESSAGEID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserMessage.ReportDefID)).HasColumnName("REPORTDEFID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserMessage.SenderStatus)).HasColumnName("SENDERSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.UserMessage.SenderRef)).HasColumnName("SENDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserMessage.ToUserRef)).HasColumnName("TOUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserMessage.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserMessage.UserMessageGroupRef)).HasColumnName("USERMESSAGEGROUP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserMessage.BaseActionRef)).HasColumnName("BASEACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserMessage.SubActionRef)).HasColumnName("SUBACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Sender).WithOne().HasForeignKey<AtlasModel.UserMessage>(x => x.SenderRef).IsRequired(false);
            builder.HasOne(t => t.ToUser).WithOne().HasForeignKey<AtlasModel.UserMessage>(x => x.ToUserRef).IsRequired(false);
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.UserMessage>(x => x.PatientRef).IsRequired(false);
            builder.HasOne(t => t.BaseAction).WithOne().HasForeignKey<AtlasModel.UserMessage>(x => x.BaseActionRef).IsRequired(false);
            builder.HasOne(t => t.SubAction).WithOne().HasForeignKey<AtlasModel.UserMessage>(x => x.SubActionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}