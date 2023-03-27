using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResponseOfENabizWOSYSConfig : IEntityTypeConfiguration<AtlasModel.ResponseOfENabizWOSYS>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResponseOfENabizWOSYS> builder)
        {
            builder.ToTable("RESPONSEOFENABIZWOSYS");
            builder.HasKey(nameof(AtlasModel.ResponseOfENabizWOSYS.ObjectId));
            builder.Property(nameof(AtlasModel.ResponseOfENabizWOSYS.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResponseOfENabizWOSYS.PackageCode)).HasColumnName("PACKAGECODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ResponseOfENabizWOSYS.Status)).HasColumnName("STATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ResponseOfENabizWOSYS.SendDate)).HasColumnName("SENDDATE");
            builder.Property(nameof(AtlasModel.ResponseOfENabizWOSYS.ResponseCode)).HasColumnName("RESPONSECODE");
            builder.Property(nameof(AtlasModel.ResponseOfENabizWOSYS.ResponseMessage)).HasColumnName("RESPONSEMESSAGE").HasColumnType("CLOB");
        }
    }
}