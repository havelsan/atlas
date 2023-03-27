using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class UserOptionGroupConfig : IEntityTypeConfiguration<AtlasModel.UserOptionGroup>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.UserOptionGroup> builder)
        {
            builder.ToTable("USEROPTIONGROUP");
            builder.HasKey(nameof(AtlasModel.UserOptionGroup.ObjectId));
            builder.Property(nameof(AtlasModel.UserOptionGroup.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.UserOptionGroup.UserOptionType)).HasColumnName("USEROPTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.UserOptionGroup.UserOptionGroupType)).HasColumnName("USEROPTIONGROUPTYPE").HasColumnType("NUMBER(10)");
        }
    }
}