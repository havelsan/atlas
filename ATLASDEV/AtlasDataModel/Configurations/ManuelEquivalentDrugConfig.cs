using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ManuelEquivalentDrugConfig : IEntityTypeConfiguration<AtlasModel.ManuelEquivalentDrug>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ManuelEquivalentDrug> builder)
        {
            builder.ToTable("MANUELEQUIVALENTDRUG");
            builder.HasKey(nameof(AtlasModel.ManuelEquivalentDrug.ObjectId));
            builder.Property(nameof(AtlasModel.ManuelEquivalentDrug.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ManuelEquivalentDrug.DrugDefinitionRef)).HasColumnName("DRUGDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ManuelEquivalentDrug.EquivalentDrugRef)).HasColumnName("EQUIVALENTDRUG").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.DrugDefinition).WithOne().HasForeignKey<AtlasModel.ManuelEquivalentDrug>(x => x.DrugDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.EquivalentDrug).WithOne().HasForeignKey<AtlasModel.ManuelEquivalentDrug>(x => x.EquivalentDrugRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}