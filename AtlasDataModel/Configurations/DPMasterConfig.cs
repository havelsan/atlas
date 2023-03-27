using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DPMasterConfig : IEntityTypeConfiguration<AtlasModel.DPMaster>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DPMaster> builder)
        {
            builder.ToTable("DPMASTER");
            builder.HasKey(nameof(AtlasModel.DPMaster.ObjectId));
            builder.Property(nameof(AtlasModel.DPMaster.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DPMaster.ExecDate)).HasColumnName("EXECDATE");
            builder.Property(nameof(AtlasModel.DPMaster.DoctorRef)).HasColumnName("DOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DPMaster.TermRef)).HasColumnName("TERM").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Doctor).WithOne().HasForeignKey<AtlasModel.DPMaster>(x => x.DoctorRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}