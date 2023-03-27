using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PeriodicOrderDetailConfig : IEntityTypeConfiguration<AtlasModel.PeriodicOrderDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PeriodicOrderDetail> builder)
        {
            builder.ToTable("PERIODICORDERDETAIL");
            builder.HasKey(nameof(AtlasModel.PeriodicOrderDetail.ObjectId));
            builder.Property(nameof(AtlasModel.PeriodicOrderDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PeriodicOrderDetail.ExecutionDate)).HasColumnName("EXECUTIONDATE");
            builder.Property(nameof(AtlasModel.PeriodicOrderDetail.PeriodicOrderRef)).HasColumnName("PERIODICORDER").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubactionProcedureFlowable).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.PeriodicOrder).WithOne().HasForeignKey<AtlasModel.PeriodicOrderDetail>(x => x.PeriodicOrderRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}