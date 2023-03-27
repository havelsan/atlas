using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ManagerPrescriptionCountsConfig : IEntityTypeConfiguration<AtlasModel.ManagerPrescriptionCounts>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ManagerPrescriptionCounts> builder)
        {
            builder.ToTable("MANAGERPRESCRIPTIONCOUNTS");
            builder.HasKey(nameof(AtlasModel.ManagerPrescriptionCounts.ObjectId));
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.ePrescriptionCount)).HasColumnName("EPRESCRIPTIONCOUNT");
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.PaperPrescriptionCount)).HasColumnName("PAPERPRESCRIPTIONCOUNT");
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.TotalPrescriptionCounts)).HasColumnName("TOTALPRESCRIPTIONCOUNTS");
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.PrescriptionCountRate)).HasColumnName("PRESCRIPTIONCOUNTRATE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.Cancelled)).HasColumnName("CANCELLED");
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.EmergencyPrescriptionCount)).HasColumnName("EMERGENCYPRESCRIPTIONCOUNT");
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.PoliclinicPrescriptionCount)).HasColumnName("POLICLINICPRESCRIPTIONCOUNT");
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.AddedUserRef)).HasColumnName("ADDEDUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ManagerPrescriptionCounts.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.AddedUser).WithOne().HasForeignKey<AtlasModel.ManagerPrescriptionCounts>(x => x.AddedUserRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.ManagerPrescriptionCounts>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}