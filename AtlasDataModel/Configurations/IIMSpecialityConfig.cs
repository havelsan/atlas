using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class IIMSpecialityConfig : IEntityTypeConfiguration<AtlasModel.IIMSpeciality>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.IIMSpeciality> builder)
        {
            builder.ToTable("IIMSPECIALITY");
            builder.HasKey(nameof(AtlasModel.IIMSpeciality.ObjectId));
            builder.Property(nameof(AtlasModel.IIMSpeciality.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.IIMSpeciality.Checked)).HasColumnName("CHECKED");
            builder.Property(nameof(AtlasModel.IIMSpeciality.SpecialityRef)).HasColumnName("SPECIALITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.IIMSpeciality.InvoiceInclusionMasterRef)).HasColumnName("INVOICEINCLUSIONMASTER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InvoiceInclusionMaster).WithOne().HasForeignKey<AtlasModel.IIMSpeciality>(x => x.InvoiceInclusionMasterRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}