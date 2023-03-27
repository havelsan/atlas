using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class FavoriteDiagnosisConfig : IEntityTypeConfiguration<AtlasModel.FavoriteDiagnosis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.FavoriteDiagnosis> builder)
        {
            builder.ToTable("FAVORITEDIAGNOSIS");
            builder.HasKey(nameof(AtlasModel.FavoriteDiagnosis.ObjectId));
            builder.Property(nameof(AtlasModel.FavoriteDiagnosis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.FavoriteDiagnosis.Order)).HasColumnName("ORDER");
            builder.Property(nameof(AtlasModel.FavoriteDiagnosis.DiagnoseRef)).HasColumnName("DIAGNOSE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.FavoriteDiagnosis.UserRef)).HasColumnName("USER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Diagnose).WithOne().HasForeignKey<AtlasModel.FavoriteDiagnosis>(x => x.DiagnoseRef).IsRequired(true);
            builder.HasOne(t => t.User).WithOne().HasForeignKey<AtlasModel.FavoriteDiagnosis>(x => x.UserRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}