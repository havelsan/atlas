using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InvoiceLogConfig : IEntityTypeConfiguration<AtlasModel.InvoiceLog>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InvoiceLog> builder)
        {
            builder.ToTable("INVOICELOG");
            builder.HasKey(nameof(AtlasModel.InvoiceLog.ObjectId));
            builder.Property(nameof(AtlasModel.InvoiceLog.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InvoiceLog.OperationType)).HasColumnName("OPERATIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.InvoiceLog.Date)).HasColumnName("DATE");
            builder.Property(nameof(AtlasModel.InvoiceLog.Message)).HasColumnName("MESSAGE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.InvoiceLog.MessageType)).HasColumnName("MESSAGETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.InvoiceLog.ObjectPrimaryKey)).HasColumnName("OBJECTPRIMARYKEY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InvoiceLog.ObjectType)).HasColumnName("OBJECTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.InvoiceLog.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.InvoiceLog>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}