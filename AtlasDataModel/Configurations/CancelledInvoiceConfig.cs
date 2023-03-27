using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class CancelledInvoiceConfig : IEntityTypeConfiguration<AtlasModel.CancelledInvoice>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.CancelledInvoice> builder)
        {
            builder.ToTable("CANCELLEDINVOICE");
            builder.HasKey(nameof(AtlasModel.CancelledInvoice.ObjectId));
            builder.Property(nameof(AtlasModel.CancelledInvoice.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.CancelledInvoice.Description)).HasColumnName("DESCRIPTION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.CancelledInvoice.Date)).HasColumnName("DATE");
            builder.Property(nameof(AtlasModel.CancelledInvoice.Type)).HasColumnName("TYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.CancelledInvoice.SEPRef)).HasColumnName("SEP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CancelledInvoice.ICDRef)).HasColumnName("ICD").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CancelledInvoice.PIDRef)).HasColumnName("PID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.CancelledInvoice.UserRef)).HasColumnName("USER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SEP).WithOne().HasForeignKey<AtlasModel.CancelledInvoice>(x => x.SEPRef).IsRequired(true);
            builder.HasOne(t => t.ICD).WithOne().HasForeignKey<AtlasModel.CancelledInvoice>(x => x.ICDRef).IsRequired(true);
            builder.HasOne(t => t.PID).WithOne().HasForeignKey<AtlasModel.CancelledInvoice>(x => x.PIDRef).IsRequired(false);
            builder.HasOne(t => t.User).WithOne().HasForeignKey<AtlasModel.CancelledInvoice>(x => x.UserRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}