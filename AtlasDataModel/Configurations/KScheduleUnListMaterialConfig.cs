using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class KScheduleUnListMaterialConfig : IEntityTypeConfiguration<AtlasModel.KScheduleUnListMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.KScheduleUnListMaterial> builder)
        {
            builder.ToTable("KSCHEDULEUNLISTMATERIAL");
            builder.HasKey(nameof(AtlasModel.KScheduleUnListMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.KScheduleUnListMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.KScheduleUnListMaterial.UnlistVolume)).HasColumnName("UNLISTVOLUME").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.KScheduleUnListMaterial.UnlistDrug)).HasColumnName("UNLISTDRUG").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.KScheduleUnListMaterial.UnlistAmount)).HasColumnName("UNLISTAMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.KScheduleUnListMaterial.UnlistPatient)).HasColumnName("UNLISTPATIENT").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.KScheduleUnListMaterial.UnlistReason)).HasColumnName("UNLISTREASON").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.KScheduleUnListMaterial.KScheduleRef)).HasColumnName("KSCHEDULE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.KSchedule).WithOne().HasForeignKey<AtlasModel.KScheduleUnListMaterial>(x => x.KScheduleRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}