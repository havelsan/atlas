using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResourceConfig : IEntityTypeConfiguration<AtlasModel.Resource>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Resource> builder)
        {
            builder.ToTable("RESOURCE");
            builder.HasKey(nameof(AtlasModel.Resource.ObjectId));
            builder.Property(nameof(AtlasModel.Resource.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.Resource.Qref)).HasColumnName("QREF").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Resource.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.Resource.ID)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.Resource.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.Resource.Location)).HasColumnName("LOCATION").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.Resource.DeskPhoneNumber)).HasColumnName("DESKPHONENUMBER").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.Resource.ResTypeRef)).HasColumnName("RESTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.Resource.StoreRef)).HasColumnName("STORE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Store).WithOne().HasForeignKey<AtlasModel.Resource>(x => x.StoreRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}