using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PulmonerKapakBulguConfig : IEntityTypeConfiguration<AtlasModel.PulmonerKapakBulgu>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PulmonerKapakBulgu> builder)
        {
            builder.ToTable("PULMONERKAPAKBULGU");
            builder.HasKey(nameof(AtlasModel.PulmonerKapakBulgu.ObjectId));
            builder.Property(nameof(AtlasModel.PulmonerKapakBulgu.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PulmonerKapakBulgu.PulmonerKapakTest)).HasColumnName("PULMONERKAPAKTEST").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PulmonerKapakBulgu.PulmonerKapakTestBulgu)).HasColumnName("PULMONERKAPAKTESTBULGU").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PulmonerKapakBulgu.EkokardiografiFormObjectRef)).HasColumnName("EKOKARDIOGRAFIFORMOBJECT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.EkokardiografiFormObject).WithOne().HasForeignKey<AtlasModel.PulmonerKapakBulgu>(x => x.EkokardiografiFormObjectRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}