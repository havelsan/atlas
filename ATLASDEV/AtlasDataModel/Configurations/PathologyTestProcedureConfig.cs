using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PathologyTestProcedureConfig : IEntityTypeConfiguration<AtlasModel.PathologyTestProcedure>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PathologyTestProcedure> builder)
        {
            builder.ToTable("PATHOLOGYTESTPROCEDURE");
            builder.HasKey(nameof(AtlasModel.PathologyTestProcedure.ObjectId));
            builder.Property(nameof(AtlasModel.PathologyTestProcedure.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PathologyTestProcedure.IsResultSeen)).HasColumnName("ISRESULTSEEN");
            builder.Property(nameof(AtlasModel.PathologyTestProcedure.Description)).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.PathologyTestProcedure.PathologyMaterialRef)).HasColumnName("PATHOLOGYMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyTestProcedure.PathologyRequestRef)).HasColumnName("PATHOLOGYREQUEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PathologyTestProcedure.TestCategoryRef)).HasColumnName("TESTCATEGORY").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionProcedure>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.PathologyMaterial).WithOne().HasForeignKey<AtlasModel.PathologyTestProcedure>(x => x.PathologyMaterialRef).IsRequired(false);
            builder.HasOne(t => t.PathologyRequest).WithOne().HasForeignKey<AtlasModel.PathologyTestProcedure>(x => x.PathologyRequestRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}