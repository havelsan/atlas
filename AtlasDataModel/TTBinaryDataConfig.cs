using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel
{
    //public partial class TTBinaryDataConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.AtlasModel.TTBinaryData>
    //{
    //    public void Configure(EntityTypeBuilder<AtlasModel.TTBinaryData> builder)
    //    {
    //        builder.ToTable("TTBINARYDATA");
    //        builder.HasKey(t => t.DataId);
    //        builder.Property(t => t.DataId).HasColumnName("DATAID").HasMaxLength(36).IsFixedLength().IsRequired();
    //        builder.Property(t => t.ObjectId).HasColumnName("OBJECTID").HasMaxLength(36).IsFixedLength();
    //        builder.Property(t => t.Data).HasColumnName("DATA");
    //        builder.Property(t => t.PropertyDefId).HasColumnName("PROPERTYDEFID").HasMaxLength(36).IsFixedLength();
    //        builder.Property(t => t.IsDeleted).HasColumnName("ISDELETED");
    //    }
    //}
}