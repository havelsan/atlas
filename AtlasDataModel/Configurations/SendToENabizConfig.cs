using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SendToENabizConfig : IEntityTypeConfiguration<AtlasModel.SendToENabiz>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SendToENabiz> builder)
        {
            builder.ToTable("SENDTOENABIZ");
            builder.HasKey(nameof(AtlasModel.SendToENabiz.ObjectId));
            builder.Property(nameof(AtlasModel.SendToENabiz.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SendToENabiz.PackageCode)).HasColumnName("PACKAGECODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.SendToENabiz.Status)).HasColumnName("STATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SendToENabiz.InternalObjectID)).HasColumnName("INTERNALOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SendToENabiz.InternalObjectDefName)).HasColumnName("INTERNALOBJECTDEFNAME");
            builder.Property(nameof(AtlasModel.SendToENabiz.RecordDate)).HasColumnName("RECORDDATE");
            builder.Property(nameof(AtlasModel.SendToENabiz.SubEpisodeRef)).HasColumnName("SUBEPISODE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SubEpisode).WithOne().HasForeignKey<AtlasModel.SendToENabiz>(x => x.SubEpisodeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}