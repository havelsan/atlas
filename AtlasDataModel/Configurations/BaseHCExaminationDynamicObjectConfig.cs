using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseHCExaminationDynamicObjectConfig : IEntityTypeConfiguration<AtlasModel.BaseHCExaminationDynamicObject>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseHCExaminationDynamicObject> builder)
        {
            builder.ToTable("BASEHCEDYNAMICOBJECT");
            builder.HasKey(nameof(AtlasModel.BaseHCExaminationDynamicObject.ObjectId));
            builder.Property(nameof(AtlasModel.BaseHCExaminationDynamicObject.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseHCExaminationDynamicObject.PatientExaminationRef)).HasColumnName("PATIENTEXAMINATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.PatientExamination).WithOne().HasForeignKey<AtlasModel.BaseHCExaminationDynamicObject>(x => x.PatientExaminationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}