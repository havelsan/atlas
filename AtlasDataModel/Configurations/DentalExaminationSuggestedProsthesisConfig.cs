using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DentalExaminationSuggestedProsthesisConfig : IEntityTypeConfiguration<AtlasModel.DentalExaminationSuggestedProsthesis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DentalExaminationSuggestedProsthesis> builder)
        {
            builder.ToTable("DENTALEXAMSUGGESTPROSTH");
            builder.HasKey(nameof(AtlasModel.DentalExaminationSuggestedProsthesis.ObjectId));
            builder.Property(nameof(AtlasModel.DentalExaminationSuggestedProsthesis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DentalExaminationSuggestedProsthesis.DentalExaminationRef)).HasColumnName("DENTALEXAMINATION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalExaminationSuggestedProsthesis.DentalLaboratoryProcedureRef)).HasColumnName("DENTALLABORATORYPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.DentalProsthesisRequestSuggestedProsthesis).WithOne().HasForeignKey<AtlasModel.DentalProsthesisRequestSuggestedProsthesis>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.DentalExamination).WithOne().HasForeignKey<AtlasModel.DentalExaminationSuggestedProsthesis>(x => x.DentalExaminationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}