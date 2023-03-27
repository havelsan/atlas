using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugOtherFormConfig : IEntityTypeConfiguration<AtlasModel.DrugOtherForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugOtherForm> builder)
        {
            builder.ToTable("DRUGOTHERFORM");
            builder.HasKey(nameof(AtlasModel.DrugOtherForm.ObjectId));
            builder.Property(nameof(AtlasModel.DrugOtherForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugOtherForm.DrugDefinitionRef)).HasColumnName("DRUGDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugOtherForm.OtherFormRef)).HasColumnName("OTHERFORM").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.DrugDefinition).WithOne().HasForeignKey<AtlasModel.DrugOtherForm>(x => x.DrugDefinitionRef).IsRequired(false);
            builder.HasOne(t => t.OtherForm).WithOne().HasForeignKey<AtlasModel.DrugOtherForm>(x => x.OtherFormRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}