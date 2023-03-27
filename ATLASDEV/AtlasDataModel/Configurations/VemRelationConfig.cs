using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class VemRelationConfig : IEntityTypeConfiguration<AtlasModel.VemRelation>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.VemRelation> builder)
        {
            builder.ToTable("VEMRELATION");
            builder.HasKey(nameof(AtlasModel.VemRelation.ObjectId));
            builder.Property(nameof(AtlasModel.VemRelation.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.VemRelation.VemTableName)).HasColumnName("VEMTABLENAME").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.VemRelation.HvlObjectID)).HasColumnName("HVLOBJECTID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.VemRelation.VemObjectID)).HasColumnName("VEMOBJECTID").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.VemRelation.VemID)).HasColumnName("VEMID");
        }
    }
}