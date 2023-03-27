using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class HCExaminationDisabledRatioConfig : IEntityTypeConfiguration<AtlasModel.HCExaminationDisabledRatio>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.HCExaminationDisabledRatio> builder)
        {
            builder.ToTable("HCEXAMINATIONDISABLEDRATIO");
            builder.HasKey(nameof(AtlasModel.HCExaminationDisabledRatio.ObjectId));
            builder.Property(nameof(AtlasModel.HCExaminationDisabledRatio.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.HCExaminationDisabledRatio.DisabledRatio)).HasColumnName("DISABLEDRATIO");
            builder.Property(nameof(AtlasModel.HCExaminationDisabledRatio.HCExaminationComponentRef)).HasColumnName("HCEXAMINATIONCOMPONENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.HCExaminationComponent).WithOne().HasForeignKey<AtlasModel.HCExaminationDisabledRatio>(x => x.HCExaminationComponentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}