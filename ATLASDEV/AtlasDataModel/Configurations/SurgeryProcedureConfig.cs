using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SurgeryProcedureConfig : IEntityTypeConfiguration<AtlasModel.SurgeryProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SurgeryProcedure> builder)
        {
            builder.ToTable("SURGERYPROCEDURE");
            builder.HasKey(nameof(AtlasModel.SurgeryProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.SurgeryProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SurgeryProcedure.HasChangedAtChildObjects)).HasColumnName("HASCHANGEDATCHILDOBJECTS");
            builder.Property(nameof(AtlasModel.SurgeryProcedure.RabsonGroup)).HasColumnName("RABSONGROUP").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SurgeryProcedure.ComplicationDescription)).HasColumnName("COMPLICATIONDESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.SurgeryProcedure.IsComplicationSurgery)).HasColumnName("ISCOMPLICATIONSURGERY");
            builder.Property(nameof(AtlasModel.SurgeryProcedure.IsScoliosisSurgery)).HasColumnName("ISSCOLIOSISSURGERY");
            builder.Property(nameof(AtlasModel.SurgeryProcedure.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseSurgeryProcedure).WithOne().HasForeignKey<AtlasModel.BaseSurgeryProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Department).WithOne().HasForeignKey<AtlasModel.SurgeryProcedure>(x => x.DepartmentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}