using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    //public partial class TTServiceLogConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTServiceLog>
    //{
    //    public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTServiceLog> builder)
    //    {
    //        builder.HasKey(t => t.LogId);
    //        builder.Property(t => t.LogId).HasColumnName("LOGID").HasMaxLength(40);
    //        builder.Property(t => t.RequestMethod).HasColumnName("REQUESTMETHOD").HasMaxLength(255);
    //        builder.Property(t => t.RequestPath).HasColumnName("REQUESTPATH").HasMaxLength(255);
    //        builder.Property(t => t.StatusCode).HasColumnName("STATUSCODE").HasMaxLength(64);
    //        builder.Property(t => t.CallDate).HasColumnName("CALLDATE");
    //        builder.Property(t => t.WorkstationIp).HasColumnName("WORKSTATIONIP").HasMaxLength(64);
    //        builder.Property(t => t.Elapsed).HasColumnName("ELAPSED");
    //    }
    //}
}