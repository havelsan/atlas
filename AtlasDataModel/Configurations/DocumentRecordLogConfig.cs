using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DocumentRecordLogConfig : IEntityTypeConfiguration<AtlasModel.DocumentRecordLog>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DocumentRecordLog> builder)
        {
            builder.ToTable("DOCUMENTRECORDLOG");
            builder.HasKey(nameof(AtlasModel.DocumentRecordLog.ObjectId));
            builder.Property(nameof(AtlasModel.DocumentRecordLog.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DocumentRecordLog.TakenGivenPlace_Shadow)).HasColumnName("TAKENGIVENPLACE_SHADOW");
            builder.Property(nameof(AtlasModel.DocumentRecordLog.Descriptions)).HasColumnName("DESCRIPTIONS").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DocumentRecordLog.DocumentDateTime)).HasColumnName("DOCUMENTDATETIME");
            builder.Property(nameof(AtlasModel.DocumentRecordLog.DocumentRecordLogNumber)).HasColumnName("DOCUMENTRECORDLOGNUMBER");
            builder.Property(nameof(AtlasModel.DocumentRecordLog.DocumentTransactionType)).HasColumnName("DOCUMENTTRANSACTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DocumentRecordLog.NumberOfRows)).HasColumnName("NUMBEROFROWS");
            builder.Property(nameof(AtlasModel.DocumentRecordLog.Subject)).HasColumnName("SUBJECT").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.DocumentRecordLog.TakenGivenPlace)).HasColumnName("TAKENGIVENPLACE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DocumentRecordLog.BudgeType)).HasColumnName("BUDGETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DocumentRecordLog.ReceiptNumber)).HasColumnName("RECEIPTNUMBER");
            builder.Property(nameof(AtlasModel.DocumentRecordLog.MKYSStatus)).HasColumnName("MKYSSTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DocumentRecordLog.StockActionRef)).HasColumnName("STOCKACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.DocumentRecordLog>(x => x.StockActionRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}