using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    //public partial class TTObjectRelationSubTypeDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTObjectRelationSubTypeDef>
    //{
    //    public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTObjectRelationSubTypeDef> builder)
    //    {
    //        builder.HasKey(t => t.RelationSubTypeDefId);
    //        builder.Property(t => t.RelationSubTypeDefId).HasColumnName("RELATIONSUBTYPEDEFID").HasMaxLength(36);
    //        builder.Property(t => t.RelationDefId).HasColumnName("RELATIONDEFID").HasMaxLength(36);
    //        builder.Property(t => t.ParentObjectDefId).HasColumnName("PARENTOBJECTDEFID").HasMaxLength(36);
    //        builder.Property(t => t.ChildObjectDefId).HasColumnName("CHILDOBJECTDEFID").HasMaxLength(36);
    //        builder.Property(t => t.ParentName).HasColumnName("PARENTNAME").HasMaxLength(50);
    //        builder.Property(t => t.ChildrenName).HasColumnName("CHILDRENNAME").HasMaxLength(50);
    //        builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
    //    }
    //}
}