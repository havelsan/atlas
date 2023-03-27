using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseActionConfig : IEntityTypeConfiguration<AtlasModel.BaseAction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseAction> builder)
        {
            builder.ToTable("BASEACTION");
            builder.HasKey(nameof(AtlasModel.BaseAction.ObjectId));
            builder.Property(nameof(AtlasModel.BaseAction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseAction.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.BaseAction.ReasonOfCancel)).HasColumnName("REASONOFCANCEL").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.BaseAction.Active)).HasColumnName("ACTIVE");
            builder.Property(nameof(AtlasModel.BaseAction.WorkListDate)).HasColumnName("WORKLISTDATE");
            builder.Property(nameof(AtlasModel.BaseAction.ReasonOfReject)).HasColumnName("REASONOFREJECT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseAction.ID)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.BaseAction.OlapLastUpdate)).HasColumnName("OLAPLASTUPDATE");
            builder.Property(nameof(AtlasModel.BaseAction.OlapDate)).HasColumnName("OLAPDATE");
            builder.Property(nameof(AtlasModel.BaseAction.ClonedObjectID)).HasColumnName("CLONEDOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseAction.WorkListDescription)).HasColumnName("WORKLISTDESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.BaseAction.IsOldAction)).HasColumnName("ISOLDACTION");
            builder.Property(nameof(AtlasModel.BaseAction.MasterActionRef)).HasColumnName("MASTERACTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.MasterAction).WithOne().HasForeignKey<AtlasModel.BaseAction>(x => x.MasterActionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}