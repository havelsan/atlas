using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InpatientPresDetailConfig : IEntityTypeConfiguration<AtlasModel.InpatientPresDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InpatientPresDetail> builder)
        {
            builder.ToTable("INPATIENTPRESDETAIL");
            builder.HasKey(nameof(AtlasModel.InpatientPresDetail.ObjectId));
            builder.Property(nameof(AtlasModel.InpatientPresDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InpatientPresDetail.DrugOrderIntroductionRef)).HasColumnName("DRUGORDERINTRODUCTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InpatientPresDetail.InpatientPrescriptionRef)).HasColumnName("INPATIENTPRESCRIPTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugOrderIntroduction).WithOne().HasForeignKey<AtlasModel.InpatientPresDetail>(x => x.DrugOrderIntroductionRef).IsRequired(false);
            builder.HasOne(t => t.InpatientPrescription).WithOne().HasForeignKey<AtlasModel.InpatientPresDetail>(x => x.InpatientPrescriptionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}