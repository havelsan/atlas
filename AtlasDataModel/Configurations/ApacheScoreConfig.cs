using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ApacheScoreConfig : IEntityTypeConfiguration<AtlasModel.ApacheScore>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ApacheScore> builder)
        {
            builder.ToTable("APACHESCORE");
            builder.HasKey(nameof(AtlasModel.ApacheScore.ObjectId));
            builder.Property(nameof(AtlasModel.ApacheScore.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ApacheScore.BodyTemperature)).HasColumnName("BODYTEMPERATURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.MeanBloodPressure)).HasColumnName("MEANBLOODPRESSURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.HeartRate)).HasColumnName("HEARTRATE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.BreathRate)).HasColumnName("BREATHRATE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.FIO2Over)).HasColumnName("FIO2OVER").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.FIO2Under)).HasColumnName("FIO2UNDER").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.NoAKG)).HasColumnName("NOAKG").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.ArterialpH)).HasColumnName("ARTERIALPH").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.SerumSodium)).HasColumnName("SERUMSODIUM").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.ExpectedMortalityRate)).HasColumnName("EXPECTEDMORTALITYRATE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.ApacheScore.SerumPotassium)).HasColumnName("SERUMPOTASSIUM").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.SerumCreatinineYesFailure)).HasColumnName("SERUMCREATININEYESFAILURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.Ht)).HasColumnName("HT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.WBC)).HasColumnName("WBC").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.GlasgowComaScale)).HasColumnName("GLASGOWCOMASCALE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.Age)).HasColumnName("AGE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.ChronicOrganFailure)).HasColumnName("CHRONICORGANFAILURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.ApacheIITotal)).HasColumnName("APACHEIITOTAL");
            builder.Property(nameof(AtlasModel.ApacheScore.SerumCreatinineNoFailure)).HasColumnName("SERUMCREATININENOFAILURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ApacheScore.FIO2)).HasColumnName("FIO2");
            builder.Property(nameof(AtlasModel.ApacheScore.PaCO2)).HasColumnName("PACO2");
            builder.Property(nameof(AtlasModel.ApacheScore.PaO2)).HasColumnName("PAO2");
            builder.HasOne(t => t.BaseMultipleDataEntry).WithOne().HasForeignKey<AtlasModel.BaseMultipleDataEntry>(p => p.ObjectId);
        }
    }
}