using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class UserOptionConfig : IEntityTypeConfiguration<AtlasModel.UserOption>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.UserOption> builder)
        {
            builder.ToTable("USEROPTION");
            builder.HasKey(nameof(AtlasModel.UserOption.ObjectId));
            builder.Property(nameof(AtlasModel.UserOption.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.UserOption.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.UserOption.Value)).HasColumnName("VALUE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.UserOption.OptionValue)).HasColumnName("OPTIONVALUE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserOption.QuestionType)).HasColumnName("QUESTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.UserOption.OptionType)).HasColumnName("OPTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.UserOption.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.UserOption>(x => x.ResUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}