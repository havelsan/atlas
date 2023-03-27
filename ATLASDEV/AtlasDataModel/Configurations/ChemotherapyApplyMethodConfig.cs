using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChemotherapyApplyMethodConfig : IEntityTypeConfiguration<AtlasModel.ChemotherapyApplyMethod>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChemotherapyApplyMethod> builder)
        {
            builder.ToTable("CHEMOTHERAPYAPPLYMETHOD");
            builder.HasKey(nameof(AtlasModel.ChemotherapyApplyMethod.ObjectId));
            builder.Property(nameof(AtlasModel.ChemotherapyApplyMethod.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChemotherapyApplyMethod.Code)).HasColumnName("CODE").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.ChemotherapyApplyMethod.Name)).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ChemotherapyApplyMethod.Active)).HasColumnName("ACTIVE");
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);
        }
    }
}