using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingOrderConfig : IEntityTypeConfiguration<AtlasModel.NursingOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingOrder> builder)
        {
            builder.ToTable("NURSINGORDER");
            builder.HasKey(nameof(AtlasModel.NursingOrder.ObjectId));
            builder.Property(nameof(AtlasModel.NursingOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingOrder.NursingApplicationRef)).HasColumnName("NURSINGAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingOrder.InPatientPhysicianApplicationRef)).HasColumnName("INPATIENTPHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseNursingOrder).WithOne().HasForeignKey<AtlasModel.BaseNursingOrder>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.NursingApplication).WithOne().HasForeignKey<AtlasModel.NursingOrder>(x => x.NursingApplicationRef).IsRequired(false);
            builder.HasOne(t => t.InPatientPhysicianApplication).WithOne().HasForeignKey<AtlasModel.NursingOrder>(x => x.InPatientPhysicianApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}