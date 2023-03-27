using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ExtendExpirationDateConfig : IEntityTypeConfiguration<AtlasModel.ExtendExpirationDate>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ExtendExpirationDate> builder)
        {
            builder.ToTable("EXTENDEXPIRATIONDATE");
            builder.HasKey(nameof(AtlasModel.ExtendExpirationDate.ObjectId));
            builder.Property(nameof(AtlasModel.ExtendExpirationDate.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ExtendExpirationDate.InMkysControl)).HasColumnName("INMKYSCONTROL");
            builder.Property(nameof(AtlasModel.ExtendExpirationDate.OutMkysControl)).HasColumnName("OUTMKYSCONTROL");
            builder.Property(nameof(AtlasModel.ExtendExpirationDate.MKYS_AyniyatMakbuzIDGiris)).HasColumnName("MKYS_AYNIYATMAKBUZIDGIRIS");
            builder.HasOne(t => t.BaseChattelDocument).WithOne().HasForeignKey<AtlasModel.BaseChattelDocument>(p => p.ObjectId);
        }
    }
}