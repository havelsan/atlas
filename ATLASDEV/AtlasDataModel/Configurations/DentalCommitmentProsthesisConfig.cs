using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DentalCommitmentProsthesisConfig : IEntityTypeConfiguration<AtlasModel.DentalCommitmentProsthesis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DentalCommitmentProsthesis> builder)
        {
            builder.ToTable("DENTALCOMMITMENTPROSTHESIS");
            builder.HasKey(nameof(AtlasModel.DentalCommitmentProsthesis.ObjectId));
            builder.Property(nameof(AtlasModel.DentalCommitmentProsthesis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DentalCommitmentProsthesis.ToothNo)).HasColumnName("TOOTHNO").HasMaxLength(10);
            builder.Property(nameof(AtlasModel.DentalCommitmentProsthesis.DentalProsthesisDefinitionRef)).HasColumnName("DENTALPROSTHESISDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalCommitmentProsthesis.DentalCommitmentRef)).HasColumnName("DENTALCOMMITMENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DentalCommitment).WithOne().HasForeignKey<AtlasModel.DentalCommitmentProsthesis>(x => x.DentalCommitmentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}