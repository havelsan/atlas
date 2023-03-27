using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SkinPrickTestDetailConfig : IEntityTypeConfiguration<AtlasModel.SkinPrickTestDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SkinPrickTestDetail> builder)
        {
            builder.ToTable("SKINPRICKTESTDETAIL");
            builder.HasKey(nameof(AtlasModel.SkinPrickTestDetail.ObjectId));
            builder.Property(nameof(AtlasModel.SkinPrickTestDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SkinPrickTestDetail.Negative)).HasColumnName("NEGATIVE");
            builder.Property(nameof(AtlasModel.SkinPrickTestDetail.Positive)).HasColumnName("POSITIVE");
            builder.Property(nameof(AtlasModel.SkinPrickTestDetail.Description)).HasColumnName("DESCRIPTION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.SkinPrickTestDetail.SkinPrickTestResultRef)).HasColumnName("SKINPRICKTESTRESULT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SkinPrickTestDetail.BaseAdditionalApplicationRef)).HasColumnName("BASEADDITIONALAPPLICATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SkinPrickTestResult).WithOne().HasForeignKey<AtlasModel.SkinPrickTestDetail>(x => x.SkinPrickTestResultRef).IsRequired(false);
            builder.HasOne(t => t.BaseAdditionalApplication).WithOne().HasForeignKey<AtlasModel.SkinPrickTestDetail>(x => x.BaseAdditionalApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}