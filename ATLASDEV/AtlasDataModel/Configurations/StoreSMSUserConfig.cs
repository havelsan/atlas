using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StoreSMSUserConfig : IEntityTypeConfiguration<AtlasModel.StoreSMSUser>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StoreSMSUser> builder)
        {
            builder.ToTable("STORESMSUSER");
            builder.HasKey(nameof(AtlasModel.StoreSMSUser.ObjectId));
            builder.Property(nameof(AtlasModel.StoreSMSUser.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StoreSMSUser.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StoreSMSUser.StoreRef)).HasColumnName("STORE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.StoreSMSUser>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.Store).WithOne().HasForeignKey<AtlasModel.StoreSMSUser>(x => x.StoreRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}