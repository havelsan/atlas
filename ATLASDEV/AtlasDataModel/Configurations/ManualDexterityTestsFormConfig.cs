using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ManualDexterityTestsFormConfig : IEntityTypeConfiguration<AtlasModel.ManualDexterityTestsForm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ManualDexterityTestsForm> builder)
        {
            builder.ToTable("MANUALDEXTERITYTESTSFORM");
            builder.HasKey(nameof(AtlasModel.ManualDexterityTestsForm.ObjectId));
            builder.Property(nameof(AtlasModel.ManualDexterityTestsForm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ManualDexterityTestsForm.PurduePegboardTest)).HasColumnName("PURDUEPEGBOARDTEST").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ManualDexterityTestsForm.OConnorFingerDexterityTest)).HasColumnName("OCONNORFINGERDEXTERITYTEST").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ManualDexterityTestsForm.NineHolePegTest)).HasColumnName("NINEHOLEPEGTEST").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ManualDexterityTestsForm.MobergTest)).HasColumnName("MOBERGTEST").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ManualDexterityTestsForm.BimanuelFineMotorTest)).HasColumnName("BIMANUELFINEMOTORTEST").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.ManualDexterityTestsForm.DellonTest)).HasColumnName("DELLONTEST").HasMaxLength(1000);
            builder.HasOne(t => t.BaseAdditionalInfo).WithOne().HasForeignKey<AtlasModel.BaseAdditionalInfo>(p => p.ObjectId);
        }
    }
}