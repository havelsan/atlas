using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SurgeryExtensionConfig : IEntityTypeConfiguration<AtlasModel.SurgeryExtension>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SurgeryExtension> builder)
        {
            builder.ToTable("SURGERYEXTENSION");
            builder.HasKey(nameof(AtlasModel.SurgeryExtension.ObjectId));
            builder.Property(nameof(AtlasModel.SurgeryExtension.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SurgeryExtension.DescriptionToPreOp)).HasColumnName("DESCRIPTIONTOPREOP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SurgeryExtension.CancelledBySurgery)).HasColumnName("CANCELLEDBYSURGERY");
            builder.Property(nameof(AtlasModel.SurgeryExtension.PreOpDescriptions)).HasColumnName("PREOPDESCRIPTIONS").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.SurgeryExtension.MainSurgeryRef)).HasColumnName("MAINSURGERY").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.MainSurgery).WithOne().HasForeignKey<AtlasModel.SurgeryExtension>(x => x.MainSurgeryRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}