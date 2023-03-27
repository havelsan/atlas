using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TrikuspitKapakBulguConfig : IEntityTypeConfiguration<AtlasModel.TrikuspitKapakBulgu>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TrikuspitKapakBulgu> builder)
        {
            builder.ToTable("TRIKUSPITKAPAKBULGU");
            builder.HasKey(nameof(AtlasModel.TrikuspitKapakBulgu.ObjectId));
            builder.Property(nameof(AtlasModel.TrikuspitKapakBulgu.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TrikuspitKapakBulgu.TrikuspitKapakTest)).HasColumnName("TRIKUSPITKAPAKTEST").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.TrikuspitKapakBulgu.TrikuspitKapakTestBulgu)).HasColumnName("TRIKUSPITKAPAKTESTBULGU").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.TrikuspitKapakBulgu.EkokardiografiFormObjectRef)).HasColumnName("EKOKARDIOGRAFIFORMOBJECT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EkokardiografiFormObject).WithOne().HasForeignKey<AtlasModel.TrikuspitKapakBulgu>(x => x.EkokardiografiFormObjectRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}