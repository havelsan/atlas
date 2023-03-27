using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class EkokardiografiBulguConfig : IEntityTypeConfiguration<AtlasModel.EkokardiografiBulgu>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.EkokardiografiBulgu> builder)
        {
            builder.ToTable("EKOKARDIOGRAFIBULGU");
            builder.HasKey(nameof(AtlasModel.EkokardiografiBulgu.ObjectId));
            builder.Property(nameof(AtlasModel.EkokardiografiBulgu.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.EkokardiografiBulgu.EkokardiografiTest)).HasColumnName("EKOKARDIOGRAFITEST").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.EkokardiografiBulgu.EkokardiografiTestBulgu)).HasColumnName("EKOKARDIOGRAFITESTBULGU").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.EkokardiografiBulgu.EkokardiografiFormObjectRef)).HasColumnName("EKOKARDIOGRAFIFORMOBJECT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EkokardiografiFormObject).WithOne().HasForeignKey<AtlasModel.EkokardiografiBulgu>(x => x.EkokardiografiFormObjectRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}