using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AortKapakBulguConfig : IEntityTypeConfiguration<AtlasModel.AortKapakBulgu>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AortKapakBulgu> builder)
        {
            builder.ToTable("AORTKAPAKBULGU");
            builder.HasKey(nameof(AtlasModel.AortKapakBulgu.ObjectId));
            builder.Property(nameof(AtlasModel.AortKapakBulgu.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AortKapakBulgu.AortKapakTest)).HasColumnName("AORTKAPAKTEST").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AortKapakBulgu.AortKapakTestBulgu)).HasColumnName("AORTKAPAKTESTBULGU").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AortKapakBulgu.EkokardiografiFormObjectRef)).HasColumnName("EKOKARDIOGRAFIFORMOBJECT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EkokardiografiFormObject).WithOne().HasForeignKey<AtlasModel.AortKapakBulgu>(x => x.EkokardiografiFormObjectRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}