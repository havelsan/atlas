using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class TraditionalMedicineConfig : IEntityTypeConfiguration<AtlasModel.TraditionalMedicine>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.TraditionalMedicine> builder)
        {
            builder.ToTable("TRADITIONALMEDICINE");
            builder.HasKey(nameof(AtlasModel.TraditionalMedicine.ObjectId));
            builder.Property(nameof(AtlasModel.TraditionalMedicine.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.SpecialityBasedObject).WithOne().HasForeignKey<AtlasModel.SpecialityBasedObject>(p => p.ObjectId);
        }
    }
}