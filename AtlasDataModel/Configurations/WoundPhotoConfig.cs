using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class WoundPhotoConfig : IEntityTypeConfiguration<AtlasModel.WoundPhoto>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.WoundPhoto> builder)
        {
            builder.ToTable("WOUNDPHOTO");
            builder.HasKey(nameof(AtlasModel.WoundPhoto.ObjectId));
            builder.Property(nameof(AtlasModel.WoundPhoto.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.WoundPhoto.Photo)).HasColumnName("PHOTO").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.WoundPhoto.PhotoDate)).HasColumnName("PHOTODATE");
            builder.Property(nameof(AtlasModel.WoundPhoto.NursingWoundRef)).HasColumnName("NURSINGWOUND").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.NursingWound).WithOne().HasForeignKey<AtlasModel.WoundPhoto>(x => x.NursingWoundRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}