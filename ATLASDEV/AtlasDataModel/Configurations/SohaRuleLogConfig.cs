using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SohaRuleLogConfig : IEntityTypeConfiguration<AtlasModel.SohaRuleLog>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SohaRuleLog> builder)
        {
            builder.ToTable("SOHARULELOG");
            builder.HasKey(nameof(AtlasModel.SohaRuleLog.ObjectId));
            builder.Property(nameof(AtlasModel.SohaRuleLog.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SohaRuleLog.LogDate)).HasColumnName("LOGDATE");
            builder.Property(nameof(AtlasModel.SohaRuleLog.LogType)).HasColumnName("LOGTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SohaRuleLog.SohaRuleRef)).HasColumnName("SOHARULE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SohaRuleLog.UserRef)).HasColumnName("USER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.User).WithOne().HasForeignKey<AtlasModel.SohaRuleLog>(x => x.UserRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}