using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugSpecificationsConfig : IEntityTypeConfiguration<AtlasModel.DrugSpecifications>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugSpecifications> builder)
        {
            builder.ToTable("DRUGSPECIFICATIONS");
            builder.HasKey(nameof(AtlasModel.DrugSpecifications.ObjectId));
            builder.Property(nameof(AtlasModel.DrugSpecifications.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugSpecifications.DrugSpecification)).HasColumnName("DRUGSPECIFICATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugSpecifications.DrugDefinitionRef)).HasColumnName("DRUGDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugDefinition).WithOne().HasForeignKey<AtlasModel.DrugSpecifications>(x => x.DrugDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}