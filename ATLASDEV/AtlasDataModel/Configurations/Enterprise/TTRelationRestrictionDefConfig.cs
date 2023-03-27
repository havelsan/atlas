using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    //public partial class TTRelationRestrictionDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTRelationRestrictionDef>
    //{
    //    public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTRelationRestrictionDef> builder)
    //    {
    //        builder.HasKey(t => t.RestrictionDefId);
    //        builder.Property(t => t.RestrictionDefId).HasColumnName("RESTRICTIONDEFID").HasMaxLength(36);
    //        builder.Property(t => t.ObjectDefId).HasColumnName("OBJECTDEFID").HasMaxLength(36);
    //        builder.Property(t => t.RelationDefId).HasColumnName("RELATIONDEFID").HasMaxLength(36);
    //        builder.Property(t => t.RestrictedObjectDefId).HasColumnName("RESTRICTEDOBJECTDEFID").HasMaxLength(36);
    //        builder.Property(t => t.IsParent).HasColumnName("ISPARENT");
    //        builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
    //    }
    //}
}