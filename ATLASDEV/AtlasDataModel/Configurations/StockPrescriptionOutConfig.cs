using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class StockPrescriptionOutConfig : IEntityTypeConfiguration<AtlasModel.StockPrescriptionOut>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.StockPrescriptionOut> builder)
        {
            builder.ToTable("STOCKPRESCRIPTIONOUT");
            builder.HasKey(nameof(AtlasModel.StockPrescriptionOut.ObjectId));
            builder.Property(nameof(AtlasModel.StockPrescriptionOut.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.StockPrescriptionOut.PrescriptionPaperRef)).HasColumnName("PRESCRIPTIONPAPER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.StockPrescriptionOut.PrescriptionRef)).HasColumnName("PRESCRIPTION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.StockAction).WithOne().HasForeignKey<AtlasModel.StockAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Prescription).WithOne().HasForeignKey<AtlasModel.StockPrescriptionOut>(x => x.PrescriptionRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}