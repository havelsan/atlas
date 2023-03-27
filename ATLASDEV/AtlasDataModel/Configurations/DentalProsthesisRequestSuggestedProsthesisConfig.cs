using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DentalProsthesisRequestSuggestedProsthesisConfig : IEntityTypeConfiguration<AtlasModel.DentalProsthesisRequestSuggestedProsthesis>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DentalProsthesisRequestSuggestedProsthesis> builder)
        {
            builder.ToTable("DENTALPROSTREQSUGGESTPROST");
            builder.HasKey(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.ObjectId));
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.Definition)).HasColumnName("DEFINITION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.Emergency)).HasColumnName("EMERGENCY");
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.DentalPosition)).HasColumnName("DENTALPOSITION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.ToothNumber)).HasColumnName("TOOTHNUMBER").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.CurrentState)).HasColumnName("CURRENTSTATE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.Color)).HasColumnName("COLOR").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.ExternalLab)).HasColumnName("EXTERNALLAB").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.TechnicianNote)).HasColumnName("TECHNICIANNOTE").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.DepartmentRef)).HasColumnName("DEPARTMENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.SuggestedProsthesisProcedureRef)).HasColumnName("SUGGESTEDPROSTHESISPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.DentalProthesisRequestRef)).HasColumnName("DENTALPROTHESISREQUEST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalProsthesisRequestSuggestedProsthesis.TechnicianRef)).HasColumnName("TECHNICIAN").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Department).WithOne().HasForeignKey<AtlasModel.DentalProsthesisRequestSuggestedProsthesis>(x => x.DepartmentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}