using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ServiceLogInfoConfig : IEntityTypeConfiguration<AtlasModel.ServiceLogInfo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ServiceLogInfo> builder)
        {
            builder.ToTable("SERVICELOGINFO");
            builder.HasKey(nameof(AtlasModel.ServiceLogInfo.ObjectId));
            builder.Property(nameof(AtlasModel.ServiceLogInfo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ServiceLogInfo.LOGID)).HasColumnName("LOGID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ServiceLogInfo.StatusCode)).HasColumnName("STATUSCODE");
            builder.Property(nameof(AtlasModel.ServiceLogInfo.RequestPath)).HasColumnName("REQUESTPATH").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.ServiceLogInfo.CallDate)).HasColumnName("CALLDATE");
            builder.Property(nameof(AtlasModel.ServiceLogInfo.WorkstationIp)).HasColumnName("WORKSTATIONIP");
            builder.Property(nameof(AtlasModel.ServiceLogInfo.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.ServiceLogInfo.UserID)).HasColumnName("USERID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ServiceLogInfo.LogType)).HasColumnName("LOGTYPE").HasColumnType("NUMBER(10)");
        }
    }
}