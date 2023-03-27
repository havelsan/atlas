using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MitralKapakBulguConfig : IEntityTypeConfiguration<AtlasModel.MitralKapakBulgu>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MitralKapakBulgu> builder)
        {
            builder.ToTable("MITRALKAPAKBULGU");
            builder.HasKey(nameof(AtlasModel.MitralKapakBulgu.ObjectId));
            builder.Property(nameof(AtlasModel.MitralKapakBulgu.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MitralKapakBulgu.MitralKapakTest)).HasColumnName("MITRALKAPAKTEST").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MitralKapakBulgu.MitralKapakTestBulgu)).HasColumnName("MITRALKAPAKTESTBULGU").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.MitralKapakBulgu.EkokardiografiFormObjectRef)).HasColumnName("EKOKARDIOGRAFIFORMOBJECT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EkokardiografiFormObject).WithOne().HasForeignKey<AtlasModel.MitralKapakBulgu>(x => x.EkokardiografiFormObjectRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}