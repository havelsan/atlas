using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    //public partial class TTQueueCompletedConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTQueueCompleted>
    //{
    //    public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTQueueCompleted> builder)
    //    {
    //        builder.HasKey(t => t.Id);
    //        builder.Property(t => t.Id).HasColumnName("ID").HasMaxLength(36);
    //        builder.Property(t => t.ToSite).HasColumnName("TOSITE").HasMaxLength(36);
    //        builder.Property(t => t.MessageDate).HasColumnName("MESSAGEDATE");
    //        builder.Property(t => t.CompleteDate).HasColumnName("COMPLETEDATE");
    //        builder.Property(t => t.FromSite).HasColumnName("FROMSITE").HasMaxLength(36);
    //        builder.Property(t => t.BinaryDATAid).HasColumnName("BINARYDATAID").HasMaxLength(36);
    //        builder.Property(t => t.ReturnValueId).HasColumnName("RETURNVALUEID").HasMaxLength(36);
    //        builder.Property(t => t.ClassName).HasColumnName("CLASSNAME").HasMaxLength(1024);
    //        builder.Property(t => t.MethodName).HasColumnName("METHODNAME").HasMaxLength(512);
    //        builder.Property(t => t.RemoteMethodDefId).HasColumnName("REMOTEMETHODDEFID").HasMaxLength(36);
    //        builder.Property(t => t.ResourceObjectId).HasColumnName("RESOURCEOBJECTID").HasMaxLength(36);
    //        builder.Property(t => t.ProcedureObjectId).HasColumnName("PROCEDUREOBJECTID").HasMaxLength(36);
    //    }
    //}
}