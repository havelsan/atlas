using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TestObjConfig : IEntityTypeConfiguration<AtlasModel.TestObj>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TestObj> builder)
        {
            builder.ToTable("TESTOBJ");
            builder.HasKey(nameof(AtlasModel.TestObj.ObjectId));
            builder.Property(nameof(AtlasModel.TestObj.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TestObj.ID)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.TestObj.NAME)).HasColumnName("NAME");
        }
    }
}