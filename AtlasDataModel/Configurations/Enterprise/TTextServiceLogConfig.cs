using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    //public partial class TTextServiceLogConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTextServiceLog>
    //{
    //    public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTextServiceLog> builder)
    //    {
    //        builder.HasKey(t => t.LogId);
    //        builder.Property(t => t.LogId).HasColumnName("LOGID").HasMaxLength(40);
    //        builder.Property(t => t.SiteId).HasColumnName("SITEID").HasMaxLength(40);
    //        builder.Property(t => t.ServiceId).HasColumnName("SERVICEID").HasMaxLength(40);
    //        builder.Property(t => t.CallDate).HasColumnName("CALLDATE");
    //        builder.Property(t => t.CallDuration).HasColumnName("CALLDURATION");
    //        builder.Property(t => t.ServiceName).HasColumnName("SERVICENAME").HasMaxLength(64);
    //        builder.Property(t => t.MethodName).HasColumnName("METHODNAME").HasMaxLength(128);
    //        builder.Property(t => t.Status).HasColumnName("STATUS").HasMaxLength(1);
    //        builder.Property(t => t.ExceptionType).HasColumnName("EXCEPTIONTYPE").HasMaxLength(64);
    //        builder.Property(t => t.ExceptionMessage).HasColumnName("EXCEPTIONMESSAGE").HasMaxLength(1024);
    //        builder.Property(t => t.ResultCode).HasColumnName("RESULTCODE").HasMaxLength(24);
    //        builder.Property(t => t.ResultMessage).HasColumnName("RESULTMESSAGE").HasMaxLength(1024);
    //        builder.Property(t => t.InputParams).HasColumnName("INPUTPARAMS").HasMaxLength(2147483647);
    //        builder.Property(t => t.ReturnValue).HasColumnName("RETURNVALUE").HasMaxLength(2147483647);
    //        builder.Property(t => t.CallERId).HasColumnName("CALLERID");
    //    }
    //}
}