using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class OrthesisProsthesis_ReturnDescriptionsGridConfig : IEntityTypeConfiguration<AtlasModel.OrthesisProsthesis_ReturnDescriptionsGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.OrthesisProsthesis_ReturnDescriptionsGrid> builder)
        {
            builder.ToTable("ORTHESISPROSTRETURNDESCGRD");
            builder.HasKey(nameof(AtlasModel.OrthesisProsthesis_ReturnDescriptionsGrid.ObjectId));
            builder.Property(nameof(AtlasModel.OrthesisProsthesis_ReturnDescriptionsGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.OrthesisProsthesis_ReturnDescriptionsGrid.OrthesisProsthesisRequestRef)).HasColumnName("ORTHESISPROSTHESISREQUEST").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ReturnDescriptionsGrid).WithOne().HasForeignKey<AtlasModel.ReturnDescriptionsGrid>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.OrthesisProsthesisRequest).WithOne().HasForeignKey<AtlasModel.OrthesisProsthesis_ReturnDescriptionsGrid>(x => x.OrthesisProsthesisRequestRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}