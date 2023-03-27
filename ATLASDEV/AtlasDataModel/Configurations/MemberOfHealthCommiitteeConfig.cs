using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class MemberOfHealthCommiitteeConfig : IEntityTypeConfiguration<AtlasModel.MemberOfHealthCommiittee>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.MemberOfHealthCommiittee> builder)
        {
            builder.ToTable("MEMBEROFHEALTHCOMMIITTEE");
            builder.HasKey(nameof(AtlasModel.MemberOfHealthCommiittee.ObjectId));
            builder.Property(nameof(AtlasModel.MemberOfHealthCommiittee.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.MemberOfHealthCommiittee.HealthCommitteeType)).HasColumnName("HEALTHCOMMITTEETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.MemberOfHealthCommiittee.Approve)).HasColumnName("APPROVE");
            builder.Property(nameof(AtlasModel.MemberOfHealthCommiittee.Reject)).HasColumnName("REJECT");
            builder.Property(nameof(AtlasModel.MemberOfHealthCommiittee.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.MemberOfHealthCommiittee.HealthCommitteeRef)).HasColumnName("HEALTHCOMMITTEE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MemberOfHealthCommiittee.MemberDoctorRef)).HasColumnName("MEMBERDOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.MemberOfHealthCommiittee.SpecialityRef)).HasColumnName("SPECIALITY").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.HealthCommittee).WithOne().HasForeignKey<AtlasModel.MemberOfHealthCommiittee>(x => x.HealthCommitteeRef).IsRequired(false);
            builder.HasOne(t => t.MemberDoctor).WithOne().HasForeignKey<AtlasModel.MemberOfHealthCommiittee>(x => x.MemberDoctorRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}