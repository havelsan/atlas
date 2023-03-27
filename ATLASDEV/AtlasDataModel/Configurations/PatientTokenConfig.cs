using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientTokenConfig : IEntityTypeConfiguration<AtlasModel.PatientToken>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientToken> builder)
        {
            builder.ToTable("PATIENTTOKEN");
            builder.HasKey(nameof(AtlasModel.PatientToken.ObjectId));
            builder.Property(nameof(AtlasModel.PatientToken.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientToken.Token)).HasColumnName("TOKEN").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PatientToken.TokenType)).HasColumnName("TOKENTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientToken.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.PatientToken>(x => x.PatientRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}