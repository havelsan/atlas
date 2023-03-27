using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChemotherapyApplySubMethodConfig : IEntityTypeConfiguration<AtlasModel.ChemotherapyApplySubMethod>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChemotherapyApplySubMethod> builder)
        {
            builder.ToTable("CHEMOTHERAPYAPPLYSUBMETHOD");
            builder.HasKey(nameof(AtlasModel.ChemotherapyApplySubMethod.ObjectId));
            builder.Property(nameof(AtlasModel.ChemotherapyApplySubMethod.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChemotherapyApplySubMethod.Code)).HasColumnName("CODE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.ChemotherapyApplySubMethod.Name)).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ChemotherapyApplySubMethod.Active)).HasColumnName("ACTIVE");
            builder.Property(nameof(AtlasModel.ChemotherapyApplySubMethod.ChemotherapyApplyMethodRef)).HasColumnName("CHEMOTHERAPYAPPLYMETHOD").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ChemotherapyApplyMethod).WithOne().HasForeignKey<AtlasModel.ChemotherapyApplySubMethod>(x => x.ChemotherapyApplyMethodRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}