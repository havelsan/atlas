using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OldDrugOrderConfig : IEntityTypeConfiguration<AtlasModel.OldDrugOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OldDrugOrder> builder)
        {
            builder.ToTable("OLDDRUGORDER");
            builder.HasKey(nameof(AtlasModel.OldDrugOrder.ObjectId));
            builder.Property(nameof(AtlasModel.OldDrugOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OldDrugOrder.DrugOrderRef)).HasColumnName("DRUGORDER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.OldDrugOrder.DrugOrderIntroductionRef)).HasColumnName("DRUGORDERINTRODUCTION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugOrder).WithOne().HasForeignKey<AtlasModel.OldDrugOrder>(x => x.DrugOrderRef).IsRequired(false);
            builder.HasOne(t => t.DrugOrderIntroduction).WithOne().HasForeignKey<AtlasModel.OldDrugOrder>(x => x.DrugOrderIntroductionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}