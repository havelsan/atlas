using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class UserResourceConfig : IEntityTypeConfiguration<AtlasModel.UserResource>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.UserResource> builder)
        {
            builder.ToTable("USERRESOURCE");
            builder.HasKey(nameof(AtlasModel.UserResource.ObjectId));
            builder.Property(nameof(AtlasModel.UserResource.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.UserResource.UserRef)).HasColumnName("USER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserResource.ResourceRef)).HasColumnName("RESOURCE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.User).WithOne().HasForeignKey<AtlasModel.UserResource>(x => x.UserRef).IsRequired(false);
            builder.HasOne(t => t.Resource).WithOne().HasForeignKey<AtlasModel.UserResource>(x => x.ResourceRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}