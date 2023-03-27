using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResponseOfENabizConfig : IEntityTypeConfiguration<AtlasModel.ResponseOfENabiz>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResponseOfENabiz> builder)
        {
            builder.ToTable("RESPONSEOFENABIZ");
            builder.HasKey(nameof(AtlasModel.ResponseOfENabiz.ObjectId));
            builder.Property(nameof(AtlasModel.ResponseOfENabiz.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResponseOfENabiz.SendDate)).HasColumnName("SENDDATE");
            builder.Property(nameof(AtlasModel.ResponseOfENabiz.ResponseCode)).HasColumnName("RESPONSECODE");
            builder.Property(nameof(AtlasModel.ResponseOfENabiz.ResponseMessage)).HasColumnName("RESPONSEMESSAGE").HasColumnType("CLOB");
            builder.Property(nameof(AtlasModel.ResponseOfENabiz.SendToENabizRef)).HasColumnName("SENDTOENABIZ").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SendToENabiz).WithOne().HasForeignKey<AtlasModel.ResponseOfENabiz>(x => x.SendToENabizRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}