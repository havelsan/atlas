using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DynamicFormConfig : IEntityTypeConfiguration<AtlasModel.DynamicForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DynamicForm> builder)
        {
            builder.ToTable("DYNAMICFORM");
            builder.HasKey(nameof(AtlasModel.DynamicForm.ObjectId));
            builder.Property(nameof(AtlasModel.DynamicForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DynamicForm.Name)).HasColumnName("NAME").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.DynamicForm.Code)).HasColumnName("CODE").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.DynamicForm.IsEnable)).HasColumnName("ISENABLE");
            builder.Property(nameof(AtlasModel.DynamicForm.ClassName)).HasColumnName("CLASSNAME");
            builder.Property(nameof(AtlasModel.DynamicForm.CheckClassName)).HasColumnName("CHECKCLASSNAME");
        }
    }
}