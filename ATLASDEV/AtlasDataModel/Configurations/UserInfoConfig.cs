using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class UserInfoConfig : IEntityTypeConfiguration<AtlasModel.UserInfo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.UserInfo> builder)
        {
            builder.ToTable("USERINFO");
            builder.HasKey(nameof(AtlasModel.UserInfo.ObjectId));
            builder.Property(nameof(AtlasModel.UserInfo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.UserInfo.UserName)).HasColumnName("USERNAME");
            builder.Property(nameof(AtlasModel.UserInfo.Ping)).HasColumnName("PING");
            builder.Property(nameof(AtlasModel.UserInfo.ChromeVersion)).HasColumnName("CHROMEVERSION");
            builder.Property(nameof(AtlasModel.UserInfo.SoftwareVersion)).HasColumnName("SOFTWAREVERSION");
            builder.Property(nameof(AtlasModel.UserInfo.CPU)).HasColumnName("CPU");
            builder.Property(nameof(AtlasModel.UserInfo.RAM)).HasColumnName("RAM");
            builder.Property(nameof(AtlasModel.UserInfo.Width)).HasColumnName("WIDTH");
            builder.Property(nameof(AtlasModel.UserInfo.Height)).HasColumnName("HEIGHT");
            builder.Property(nameof(AtlasModel.UserInfo.ServerTime)).HasColumnName("SERVERTIME");
            builder.Property(nameof(AtlasModel.UserInfo.JSTime)).HasColumnName("JSTIME");
            builder.Property(nameof(AtlasModel.UserInfo.IP)).HasColumnName("IP");
            builder.Property(nameof(AtlasModel.UserInfo.PingCount)).HasColumnName("PINGCOUNT");
            builder.Property(nameof(AtlasModel.UserInfo.UserRef)).HasColumnName("USER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.User).WithOne().HasForeignKey<AtlasModel.UserInfo>(x => x.UserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}