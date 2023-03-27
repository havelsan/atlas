using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ConsumableMaterialDefinitionConfig : IEntityTypeConfiguration<AtlasModel.ConsumableMaterialDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ConsumableMaterialDefinition> builder)
        {
            builder.ToTable("CONSUMABLEMATERIALDEF");
            builder.HasKey(nameof(AtlasModel.ConsumableMaterialDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.IsAllogreft)).HasColumnName("ISALLOGREFT");
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.SEX)).HasColumnName("SEX").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.MaxPatientAge)).HasColumnName("MAXPATIENTAGE");
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.MinPatientAge)).HasColumnName("MINPATIENTAGE");
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.OrderRPTDay)).HasColumnName("ORDERRPTDAY").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.SpecificationFile)).HasColumnName("SPECIFICATIONFILE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.SpecificationFileName)).HasColumnName("SPECIFICATIONFILENAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.SpecificationUploadDate)).HasColumnName("SPECIFICATIONUPLOADDATE");
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.NotAppearInEpicrisis)).HasColumnName("NOTAPPEARINEPICRISIS");
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.HasEstimatedTime)).HasColumnName("HASESTIMATEDTIME");
            builder.Property(nameof(AtlasModel.ConsumableMaterialDefinition.ParentConsumableMaterialRef)).HasColumnName("PARENTCONSUMABLEMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.Material>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ParentConsumableMaterial).WithOne().HasForeignKey<AtlasModel.ConsumableMaterialDefinition>(x => x.ParentConsumableMaterialRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}