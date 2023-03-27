using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubactionProcedureFlowableConfig : IEntityTypeConfiguration<AtlasModel.SubactionProcedureFlowable>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubactionProcedureFlowable> builder)
        {
            builder.ToTable("SUBACTIONPROCEDUREFLOWABLE");
            builder.HasKey(nameof(AtlasModel.SubactionProcedureFlowable.ObjectId));
            builder.Property(nameof(AtlasModel.SubactionProcedureFlowable.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SubactionProcedureFlowable.ReasonOfReject)).HasColumnName("REASONOFREJECT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubactionProcedureFlowable.MasterResourceRef)).HasColumnName("MASTERRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubactionProcedureFlowable.OrderObjectRef)).HasColumnName("ORDEROBJECT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubactionProcedureFlowable.SecondaryMasterResourceRef)).HasColumnName("SECONDARYMASTERRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubactionProcedureFlowable.FromResourceRef)).HasColumnName("FROMRESOURCE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MasterResource).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(x => x.MasterResourceRef).IsRequired(true);
            builder.HasOne(t => t.OrderObject).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(x => x.OrderObjectRef).IsRequired(false);
            builder.HasOne(t => t.SecondaryMasterResource).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(x => x.SecondaryMasterResourceRef).IsRequired(false);
            builder.HasOne(t => t.FromResource).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(x => x.FromResourceRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}