using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OutpatientPresDetailConfig : IEntityTypeConfiguration<AtlasModel.OutpatientPresDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OutpatientPresDetail> builder)
        {
            builder.ToTable("OUTPATIENTPRESDETAIL");
            builder.HasKey(nameof(AtlasModel.OutpatientPresDetail.ObjectId));
            builder.Property(nameof(AtlasModel.OutpatientPresDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OutpatientPresDetail.DrugOrderIntroductionRef)).HasColumnName("DRUGORDERINTRODUCTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OutpatientPresDetail.OutPatientPrescriptionRef)).HasColumnName("OUTPATIENTPRESCRIPTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugOrderIntroduction).WithOne().HasForeignKey<AtlasModel.OutpatientPresDetail>(x => x.DrugOrderIntroductionRef).IsRequired(false);
            builder.HasOne(t => t.OutPatientPrescription).WithOne().HasForeignKey<AtlasModel.OutpatientPresDetail>(x => x.OutPatientPrescriptionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}