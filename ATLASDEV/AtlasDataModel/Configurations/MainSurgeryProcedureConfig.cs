using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MainSurgeryProcedureConfig : IEntityTypeConfiguration<AtlasModel.MainSurgeryProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MainSurgeryProcedure> builder)
        {
            builder.ToTable("MAINSURGERYPROCEDURE");
            builder.HasKey(nameof(AtlasModel.MainSurgeryProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.MainSurgeryProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MainSurgeryProcedure.MainSurgeryRef)).HasColumnName("MAINSURGERY").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SurgeryProcedure).WithOne().HasForeignKey<AtlasModel.SurgeryProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MainSurgery).WithOne().HasForeignKey<AtlasModel.MainSurgeryProcedure>(x => x.MainSurgeryRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}