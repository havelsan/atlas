using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BasePhysiotherapyOrderDetailConfig : IEntityTypeConfiguration<AtlasModel.BasePhysiotherapyOrderDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BasePhysiotherapyOrderDetail> builder)
        {
            builder.ToTable("BASEPHYSIOTHERAPYORDERDET");
            builder.HasKey(nameof(AtlasModel.BasePhysiotherapyOrderDetail.ObjectId));
            builder.Property(nameof(AtlasModel.BasePhysiotherapyOrderDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SubactionProcedureFlowable).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(p => p.ObjectId);
        }
    }
}