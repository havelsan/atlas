using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class UserMessageGroupUsersConfig : IEntityTypeConfiguration<AtlasModel.UserMessageGroupUsers>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.UserMessageGroupUsers> builder)
        {
            builder.ToTable("USERMESSAGEGROUPUSERS");
            builder.HasKey(nameof(AtlasModel.UserMessageGroupUsers.ObjectId));
            builder.Property(nameof(AtlasModel.UserMessageGroupUsers.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.UserMessageGroupUsers.UserMessageGroupDefinitionRef)).HasColumnName("USERMESSAGEGROUPDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.UserMessageGroupUsers.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.UserMessageGroupUsers>(x => x.ResUserRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}