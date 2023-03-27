using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DentalCommitmentConfig : IEntityTypeConfiguration<AtlasModel.DentalCommitment>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DentalCommitment> builder)
        {
            builder.ToTable("DENTALCOMMITMENT");
            builder.HasKey(nameof(AtlasModel.DentalCommitment.ObjectId));
            builder.Property(nameof(AtlasModel.DentalCommitment.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DentalCommitment.CommitmentNo)).HasColumnName("COMMITMENTNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DentalCommitment.CommitmentProtocolNo)).HasColumnName("COMMITMENTPROTOCOLNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DentalCommitment.CommitmentResultCode)).HasColumnName("COMMITMENTRESULTCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DentalCommitment.CommitmentResultMessage)).HasColumnName("COMMITMENTRESULTMESSAGE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.DentalCommitment.SendDate)).HasColumnName("SENDDATE");
            builder.Property(nameof(AtlasModel.DentalCommitment.PostCode)).HasColumnName("POSTCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DentalCommitment.StreetName)).HasColumnName("STREETNAME").HasMaxLength(500);
            builder.Property(nameof(AtlasModel.DentalCommitment.OuterDoorNo)).HasColumnName("OUTERDOORNO").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DentalCommitment.PhoneNumber)).HasColumnName("PHONENUMBER");
            builder.Property(nameof(AtlasModel.DentalCommitment.EMail)).HasColumnName("EMAIL").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.DentalCommitment.CommitmentTakenByName)).HasColumnName("COMMITMENTTAKENBYNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DentalCommitment.CommitmentTakenBySurname)).HasColumnName("COMMITMENTTAKENBYSURNAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DentalCommitment.InnerDoorNo)).HasColumnName("INNERDOORNO");
            builder.Property(nameof(AtlasModel.DentalCommitment.CityRef)).HasColumnName("CITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DentalCommitment.TownRef)).HasColumnName("TOWN").HasMaxLength(36).IsFixedLength();
        }
    }
}