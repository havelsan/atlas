using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResSurgeryDeskConfig : IEntityTypeConfiguration<AtlasModel.ResSurgeryDesk>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResSurgeryDesk> builder)
        {
            builder.ToTable("RESSURGERYDESK");
            builder.HasKey(nameof(AtlasModel.ResSurgeryDesk.ObjectId));
            builder.Property(nameof(AtlasModel.ResSurgeryDesk.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResSurgeryDesk.SurgeryRoomRef)).HasColumnName("SURGERYROOM").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.SurgeryRoom).WithOne().HasForeignKey<AtlasModel.ResSurgeryDesk>(x => x.SurgeryRoomRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}