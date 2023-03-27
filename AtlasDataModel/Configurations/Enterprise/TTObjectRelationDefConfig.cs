using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations.Enterprise
{
    public partial class TTObjectRelationDefConfig : IEntityTypeConfiguration<AtlasModel.Enterprise.TTObjectRelationDef>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.Enterprise.TTObjectRelationDef> builder)
        {
            builder.HasKey(t => t.RelationDefId);
            builder.Property(t => t.RelationDefId).HasColumnName("RELATIONDEFID").HasMaxLength(36);
            builder.Property(t => t.ParentName).HasColumnName("PARENTNAME").HasMaxLength(29);
            builder.Property(t => t.ChildrenName).HasColumnName("CHILDRENNAME").HasMaxLength(50);
            builder.Property(t => t.ParentCaption).HasColumnName("PARENTCAPTION").HasMaxLength(50);
            builder.Property(t => t.ChildCaption).HasColumnName("CHILDCAPTION").HasMaxLength(50);
            builder.Property(t => t.ParentObjectDefId).HasColumnName("PARENTOBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.ChildObjectDefId).HasColumnName("CHILDOBJECTDEFID").HasMaxLength(36);
            builder.Property(t => t.OverridesRelationDefId).HasColumnName("OVERRIDESRELATIONDEFID").HasMaxLength(36);
            builder.Property(t => t.Cardinality).HasColumnName("CARDINALITY");
            builder.Property(t => t.IsParentRequired).HasColumnName("ISPARENTREQUIRED");
            builder.Property(t => t.IsEmbedded).HasColumnName("ISEMBEDDED");
            builder.Property(t => t.IsProtected).HasColumnName("ISPROTECTED");
            builder.Property(t => t.IsDynamic).HasColumnName("ISDYNAMIC");
            builder.Property(t => t.SetParentScript).HasColumnName("SETPARENTSCRIPT").HasMaxLength(2147483647);
            builder.Property(t => t.SortChildrenByPropertyId).HasColumnName("SORTCHILDRENBYPROPERTYID").HasMaxLength(36);
            builder.Property(t => t.CheckOutStatus).HasColumnName("CHECKOUTSTATUS");
            builder.Property(t => t.CacheTableName).HasColumnName("CACHETABLENAME").HasMaxLength(36);
            builder.Property(t => t.IsIndexed).HasColumnName("ISINDEXED");
            builder.Property(t => t.IsNoLock).HasColumnName("ISNOLOCK");
            builder.Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(512);
            builder.Property(t => t.SortByDescending).HasColumnName("SORTBYDESCENDING");
        }
    }
}