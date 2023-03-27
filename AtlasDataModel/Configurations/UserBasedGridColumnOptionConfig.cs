using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class UserBasedGridColumnOptionConfig : IEntityTypeConfiguration<AtlasModel.UserBasedGridColumnOption>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.UserBasedGridColumnOption> builder)
        {
            builder.ToTable("USERBASEDGRIDCOLUMNOPTION");
            builder.HasKey(nameof(AtlasModel.UserBasedGridColumnOption.ObjectId));
            builder.Property(nameof(AtlasModel.UserBasedGridColumnOption.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.UserBasedGridColumnOption.GridName)).HasColumnName("GRIDNAME");
            builder.Property(nameof(AtlasModel.UserBasedGridColumnOption.ColumnList)).HasColumnName("COLUMNLIST").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.UserBasedGridColumnOption.PageName)).HasColumnName("PAGENAME");
            builder.Property(nameof(AtlasModel.UserBasedGridColumnOption.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.UserBasedGridColumnOption>(x => x.ResUserRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}