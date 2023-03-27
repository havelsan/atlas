using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubActionMaterialConfig : IEntityTypeConfiguration<AtlasModel.SubActionMaterial>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubActionMaterial> builder)
        {
            builder.ToTable("SUBACTIONMATERIAL");
            builder.HasKey(nameof(AtlasModel.SubActionMaterial.ObjectId));
            builder.Property(nameof(AtlasModel.SubActionMaterial.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SubActionMaterial.Eligible)).HasColumnName("ELIGIBLE");
            builder.Property(nameof(AtlasModel.SubActionMaterial.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.SubActionMaterial.ActionDate)).HasColumnName("ACTIONDATE");
            builder.Property(nameof(AtlasModel.SubActionMaterial.PricingDate)).HasColumnName("PRICINGDATE");
            builder.Property(nameof(AtlasModel.SubActionMaterial.Active)).HasColumnName("ACTIVE");
            builder.Property(nameof(AtlasModel.SubActionMaterial.ID)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.SubActionMaterial.AccTrxsMultipliedByAmount)).HasColumnName("ACCTRXSMULTIPLIEDBYAMOUNT");
            builder.Property(nameof(AtlasModel.SubActionMaterial.AccountOperationDone)).HasColumnName("ACCOUNTOPERATIONDONE");
            builder.Property(nameof(AtlasModel.SubActionMaterial.PatientPay)).HasColumnName("PATIENTPAY");
            builder.Property(nameof(AtlasModel.SubActionMaterial.DonorID)).HasColumnName("DONORID");
            builder.Property(nameof(AtlasModel.SubActionMaterial.UseAmount)).HasColumnName("USEAMOUNT");
            builder.Property(nameof(AtlasModel.SubActionMaterial.UBBCode)).HasColumnName("UBBCODE");
            builder.Property(nameof(AtlasModel.SubActionMaterial.CreationDate)).HasColumnName("CREATIONDATE");
            builder.Property(nameof(AtlasModel.SubActionMaterial.IsOldAction)).HasColumnName("ISOLDACTION");
            builder.Property(nameof(AtlasModel.SubActionMaterial.MedulaReportNo)).HasColumnName("MEDULAREPORTNO");
            builder.Property(nameof(AtlasModel.SubActionMaterial.StoreRef)).HasColumnName("STORE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionMaterial.EpisodeRef)).HasColumnName("EPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionMaterial.MasterPackgSubActionProcedureRef)).HasColumnName("MASTERPACKGSUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionMaterial.StockActionDetailRef)).HasColumnName("STOCKACTIONDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionMaterial.MedulaHastaKabulRef)).HasColumnName("MEDULAHASTAKABUL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionMaterial.MaterialRef)).HasColumnName("MATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionMaterial.SubEpisodeRef)).HasColumnName("SUBEPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubActionMaterial.RequestedByUserRef)).HasColumnName("REQUESTEDBYUSER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Store).WithOne().HasForeignKey<AtlasModel.SubActionMaterial>(x => x.StoreRef).IsRequired(false);
            builder.HasOne(t => t.Episode).WithOne().HasForeignKey<AtlasModel.SubActionMaterial>(x => x.EpisodeRef).IsRequired(true);
            builder.HasOne(t => t.MasterPackgSubActionProcedure).WithOne().HasForeignKey<AtlasModel.SubActionMaterial>(x => x.MasterPackgSubActionProcedureRef).IsRequired(false);
            builder.HasOne(t => t.StockActionDetail).WithOne().HasForeignKey<AtlasModel.SubActionMaterial>(x => x.StockActionDetailRef).IsRequired(false);
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.SubActionMaterial>(x => x.MaterialRef).IsRequired(false);
            builder.HasOne(t => t.SubEpisode).WithOne().HasForeignKey<AtlasModel.SubActionMaterial>(x => x.SubEpisodeRef).IsRequired(false);
            builder.HasOne(t => t.RequestedByUser).WithOne().HasForeignKey<AtlasModel.SubActionMaterial>(x => x.RequestedByUserRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}