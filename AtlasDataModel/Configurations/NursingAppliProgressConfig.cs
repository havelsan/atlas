using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingAppliProgressConfig : IEntityTypeConfiguration<AtlasModel.NursingAppliProgress>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingAppliProgress> builder)
        {
            builder.ToTable("NURSINGAPPLIPROGRESS");
            builder.HasKey(nameof(AtlasModel.NursingAppliProgress.ObjectId));
            builder.Property(nameof(AtlasModel.NursingAppliProgress.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingAppliProgress.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.NursingAppliProgress.ProgressDate)).HasColumnName("PROGRESSDATE");
            builder.Property(nameof(AtlasModel.NursingAppliProgress.HandOverNote)).HasColumnName("HANDOVERNOTE");
            builder.HasOne(t => t.BaseNursingDataEntry).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(p => p.ObjectId);
        }
    }
}