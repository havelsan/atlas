using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class FavoriteDrugConfig : IEntityTypeConfiguration<AtlasModel.FavoriteDrug>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.FavoriteDrug> builder)
        {
            builder.ToTable("FAVORITEDRUG");
            builder.HasKey(nameof(AtlasModel.FavoriteDrug.ObjectId));
            builder.Property(nameof(AtlasModel.FavoriteDrug.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.FavoriteDrug.Count)).HasColumnName("COUNT");
            builder.Property(nameof(AtlasModel.FavoriteDrug.DrugDefinitionRef)).HasColumnName("DRUGDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.FavoriteDrug.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugDefinition).WithOne().HasForeignKey<AtlasModel.FavoriteDrug>(x => x.DrugDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.FavoriteDrug>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}