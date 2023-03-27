using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CollectiveInvoiceOpConfig : IEntityTypeConfiguration<AtlasModel.CollectiveInvoiceOp>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.CollectiveInvoiceOp> builder)
        {
            builder.ToTable("COLLECTIVEINVOICEOP");
            builder.HasKey(nameof(AtlasModel.CollectiveInvoiceOp.ObjectId));
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.OpType)).HasColumnName("OPTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.PayerType)).HasColumnName("PAYERTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.InvoiceDate)).HasColumnName("INVOICEDATE");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.InvoiceDescription)).HasColumnName("INVOICEDESCRIPTION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.InvoiceCollectionID)).HasColumnName("INVOICECOLLECTIONID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.ExtraData)).HasColumnName("EXTRADATA").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.CreateDate)).HasColumnName("CREATEDATE");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.TaskType)).HasColumnName("TASKTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.ErrorCodeText)).HasColumnName("ERRORCODETEXT").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.ErrorSutCodeText)).HasColumnName("ERRORSUTCODETEXT").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.ExecType)).HasColumnName("EXECTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.UserRef)).HasColumnName("USER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CollectiveInvoiceOp.NextCIORef)).HasColumnName("NEXTCIO").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.User).WithOne().HasForeignKey<AtlasModel.CollectiveInvoiceOp>(x => x.UserRef).IsRequired(false);
            builder.HasOne(t => t.NextCIO).WithOne().HasForeignKey<AtlasModel.CollectiveInvoiceOp>(x => x.NextCIORef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}