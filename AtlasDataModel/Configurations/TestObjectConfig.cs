using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TestObjectConfig : IEntityTypeConfiguration<AtlasModel.TestObject>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TestObject> builder)
        {
            builder.ToTable("TESTOBJECT2");
            builder.HasKey(nameof(AtlasModel.TestObject.ObjectId));
            builder.Property(nameof(AtlasModel.TestObject.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.TestObject.Name)).HasColumnName("NAME");
            builder.Property(nameof(AtlasModel.TestObject.Telephone)).HasColumnName("TELEPHONE");
            builder.Property(nameof(AtlasModel.TestObject.Address)).HasColumnName("ADDRESS").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.TestObject.CityRef)).HasColumnName("CITY").HasMaxLength(36).IsFixedLength();
        }
    }
}