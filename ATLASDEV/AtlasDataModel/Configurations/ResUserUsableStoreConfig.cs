using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResUserUsableStoreConfig : IEntityTypeConfiguration<AtlasModel.ResUserUsableStore>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResUserUsableStore> builder)
        {
            builder.ToTable("RESUSERUSABLESTORE");
            builder.HasKey(nameof(AtlasModel.ResUserUsableStore.ObjectId));
            builder.Property(nameof(AtlasModel.ResUserUsableStore.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResUserUsableStore.StoreRef)).HasColumnName("STORE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ResUserUsableStore.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Store).WithOne().HasForeignKey<AtlasModel.ResUserUsableStore>(x => x.StoreRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.ResUserUsableStore>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}