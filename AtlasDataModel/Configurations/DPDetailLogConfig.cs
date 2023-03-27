using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DPDetailLogConfig : IEntityTypeConfiguration<AtlasModel.DPDetailLog>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DPDetailLog> builder)
        {
            builder.ToTable("DPDETAILLOG");
            builder.HasKey(nameof(AtlasModel.DPDetailLog.ObjectId));
            builder.Property(nameof(AtlasModel.DPDetailLog.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DPDetailLog.ExecDate)).HasColumnName("EXECDATE");
            builder.Property(nameof(AtlasModel.DPDetailLog.Log)).HasColumnName("LOG").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DPDetailLog.TotalCalcPoint)).HasColumnName("TOTALCALCPOINT");
            builder.Property(nameof(AtlasModel.DPDetailLog.TermRef)).HasColumnName("TERM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DPDetailLog.DoctorRef)).HasColumnName("DOCTOR").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Doctor).WithOne().HasForeignKey<AtlasModel.DPDetailLog>(x => x.DoctorRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}