using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class IIMDetailConfig : IEntityTypeConfiguration<AtlasModel.IIMDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.IIMDetail> builder)
        {
            builder.ToTable("IIMDETAIL");
            builder.HasKey(nameof(AtlasModel.IIMDetail.ObjectId));
            builder.Property(nameof(AtlasModel.IIMDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.IIMDetail.Checked)).HasColumnName("CHECKED");
            builder.Property(nameof(AtlasModel.IIMDetail.InvoiceInclusionMasterRef)).HasColumnName("INVOICEINCLUSIONMASTER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.IIMDetail.InvoiceInclusionDetailRef)).HasColumnName("INVOICEINCLUSIONDETAIL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InvoiceInclusionMaster).WithOne().HasForeignKey<AtlasModel.IIMDetail>(x => x.InvoiceInclusionMasterRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}