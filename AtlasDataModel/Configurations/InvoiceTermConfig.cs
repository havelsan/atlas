using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InvoiceTermConfig : IEntityTypeConfiguration<AtlasModel.InvoiceTerm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InvoiceTerm> builder)
        {
            builder.ToTable("INVOICETERM");
            builder.HasKey(nameof(AtlasModel.InvoiceTerm.ObjectId));
            builder.Property(nameof(AtlasModel.InvoiceTerm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InvoiceTerm.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.InvoiceTerm.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.InvoiceTerm.Name)).HasColumnName("NAME");
            builder.Property(nameof(AtlasModel.InvoiceTerm.DocumentNo)).HasColumnName("DOCUMENTNO");
            builder.Property(nameof(AtlasModel.InvoiceTerm.Approved)).HasColumnName("APPROVED");
            builder.Property(nameof(AtlasModel.InvoiceTerm.ApproveDate)).HasColumnName("APPROVEDATE");
            builder.Property(nameof(AtlasModel.InvoiceTerm.LastStateUserRef)).HasColumnName("LASTSTATEUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InvoiceTerm.ApproveUserRef)).HasColumnName("APPROVEUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.LastStateUser).WithOne().HasForeignKey<AtlasModel.InvoiceTerm>(x => x.LastStateUserRef).IsRequired(false);
            builder.HasOne(t => t.ApproveUser).WithOne().HasForeignKey<AtlasModel.InvoiceTerm>(x => x.ApproveUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}