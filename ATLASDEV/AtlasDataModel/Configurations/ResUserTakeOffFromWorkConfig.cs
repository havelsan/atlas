using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResUserTakeOffFromWorkConfig : IEntityTypeConfiguration<AtlasModel.ResUserTakeOffFromWork>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResUserTakeOffFromWork> builder)
        {
            builder.ToTable("RESUSERTAKEOFFFROMWORK");
            builder.HasKey(nameof(AtlasModel.ResUserTakeOffFromWork.ObjectId));
            builder.Property(nameof(AtlasModel.ResUserTakeOffFromWork.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResUserTakeOffFromWork.UniqueRefNo)).HasColumnName("UNIQUEREFNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ResUserTakeOffFromWork.IntegrationId)).HasColumnName("INTEGRATIONID").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ResUserTakeOffFromWork.IntegrationVersion)).HasColumnName("INTEGRATIONVERSION").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.ResUserTakeOffFromWork.Definition)).HasColumnName("DEFINITION").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.ResUserTakeOffFromWork.ResUserTakeOffFromWorkType)).HasColumnName("RESUSERTAKEOFFFROMWORKTYPE");
            builder.Property(nameof(AtlasModel.ResUserTakeOffFromWork.IsActive)).HasColumnName("ISACTIVE");
            builder.Property(nameof(AtlasModel.ResUserTakeOffFromWork.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResUserTakeOffFromWork.MHRSActionTypeRef)).HasColumnName("MHRSACTIONTYPE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.ResUserTakeOffFromWork>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.MHRSActionType).WithOne().HasForeignKey<AtlasModel.ResUserTakeOffFromWork>(x => x.MHRSActionTypeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}