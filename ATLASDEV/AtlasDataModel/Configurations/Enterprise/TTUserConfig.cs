using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTUserConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTUser>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTUser> builder)
        {
            builder.HasKey(t => t.UserId);
            builder.Property(t => t.UserId).HasColumnName("USERID").HasMaxLength(36);
            builder.Property(t => t.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(t => t.Password).HasColumnName("PASSWORD").HasMaxLength(50);
            builder.Property(t => t.TTObjectId).HasColumnName("TTOBJECTID").HasMaxLength(36);
            builder.Property(t => t.TTObjectDefId).HasColumnName("TTOBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.Status).HasColumnName("STATUS");
            builder.Property(t => t.PwdExpireDate).HasColumnName("PWDEXPIREDATE");
            builder.Property(t => t.PwdDate).HasColumnName("PWDDATE");
            builder.Property(t => t.CreationDate).HasColumnName("CREATIONDATE");
            builder.Property(t => t.LastLogonDate).HasColumnName("LASTLOGONDATE");
            builder.Property(t => t.Note).HasColumnName("NOTE").HasMaxLength(255);
            builder.Property(t => t.LoginStartTime).HasColumnName("LOGINSTARTTIME");
            builder.Property(t => t.LoginEndTime).HasColumnName("LOGINENDTIME");
        }
    }
}