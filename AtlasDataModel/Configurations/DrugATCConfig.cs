using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugATCConfig : IEntityTypeConfiguration<AtlasModel.DrugATC>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugATC> builder)
        {
            builder.ToTable("DRUGATC");
            builder.HasKey(nameof(AtlasModel.DrugATC.ObjectId));
            builder.Property(nameof(AtlasModel.DrugATC.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugATC.OldDrugDefinition)).HasColumnName("OLDDRUGDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugATC.ATCRef)).HasColumnName("ATC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugATC.DrugDefinitionRef)).HasColumnName("DRUGDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.DrugDefinition).WithOne().HasForeignKey<AtlasModel.DrugATC>(x => x.DrugDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}