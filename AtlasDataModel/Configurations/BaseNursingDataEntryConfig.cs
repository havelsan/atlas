using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class BaseNursingDataEntryConfig : IEntityTypeConfiguration<AtlasModel.BaseNursingDataEntry>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.BaseNursingDataEntry> builder)
        {
            builder.ToTable("BASENURSINGDATAENTRY");
            builder.HasKey(nameof(AtlasModel.BaseNursingDataEntry.ObjectId));
            builder.Property(nameof(AtlasModel.BaseNursingDataEntry.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.BaseNursingDataEntry.ApplicationDate)).HasColumnName("APPLICATIONDATE");
            builder.Property(nameof(AtlasModel.BaseNursingDataEntry.EntryDate)).HasColumnName("ENTRYDATE");
            builder.Property(nameof(AtlasModel.BaseNursingDataEntry.ApplicationUserRef)).HasColumnName("APPLICATIONUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.BaseNursingDataEntry.NursingApplicationRef)).HasColumnName("NURSINGAPPLICATION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ApplicationUser).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(x => x.ApplicationUserRef).IsRequired(false);
            builder.HasOne(t => t.NursingApplication).WithOne().HasForeignKey<AtlasModel.BaseNursingDataEntry>(x => x.NursingApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}