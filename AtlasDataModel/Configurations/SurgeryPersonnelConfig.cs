using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SurgeryPersonnelConfig : IEntityTypeConfiguration<AtlasModel.SurgeryPersonnel>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SurgeryPersonnel> builder)
        {
            builder.ToTable("SURGERYPERSONNEL");
            builder.HasKey(nameof(AtlasModel.SurgeryPersonnel.ObjectId));
            builder.Property(nameof(AtlasModel.SurgeryPersonnel.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SurgeryPersonnel.Role)).HasColumnName("ROLE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SurgeryPersonnel.SurgeryRef)).HasColumnName("SURGERY").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Surgery).WithOne().HasForeignKey<AtlasModel.SurgeryPersonnel>(x => x.SurgeryRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}