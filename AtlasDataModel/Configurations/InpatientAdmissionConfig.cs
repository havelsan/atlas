using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InpatientAdmissionConfig : IEntityTypeConfiguration<AtlasModel.InpatientAdmission>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InpatientAdmission> builder)
        {
            builder.ToTable("INPATIENTADMISSION");
            builder.HasKey(nameof(AtlasModel.InpatientAdmission.ObjectId));
            builder.Property(nameof(AtlasModel.InpatientAdmission.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InpatientAdmission.DischargeNumber)).HasColumnName("DISCHARGENUMBER");
            builder.Property(nameof(AtlasModel.InpatientAdmission.QuarantineProtocolNo)).HasColumnName("QUARANTINEPROTOCOLNO");
            builder.Property(nameof(AtlasModel.InpatientAdmission.ReturnToClinicReason)).HasColumnName("RETURNTOCLINICREASON").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.InpatientAdmission.ReturnToQuarantineReason)).HasColumnName("RETURNTOQUARANTINEREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InpatientAdmission.ReturnToRequestReason)).HasColumnName("RETURNTOREQUESTREASON").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InpatientAdmission.ReportNo)).HasColumnName("REPORTNO");
            builder.Property(nameof(AtlasModel.InpatientAdmission.NumberOfEmptyBeds)).HasColumnName("NUMBEROFEMPTYBEDS");
            builder.Property(nameof(AtlasModel.InpatientAdmission.IsPatientApprovalFormGiven)).HasColumnName("ISPATIENTAPPROVALFORMGIVEN");
            builder.Property(nameof(AtlasModel.InpatientAdmission.MutatDisiAracRaporId)).HasColumnName("MUTATDISIARACRAPORID");
            builder.Property(nameof(AtlasModel.InpatientAdmission.MutatDisiAracRaporTarihi)).HasColumnName("MUTATDISIARACRAPORTARIHI");
            builder.Property(nameof(AtlasModel.InpatientAdmission.MutatDisiGerekcesi)).HasColumnName("MUTATDISIGEREKCESI");
            builder.Property(nameof(AtlasModel.InpatientAdmission.MedulaRefakatciDurumu)).HasColumnName("MEDULAREFAKATCIDURUMU");
            builder.Property(nameof(AtlasModel.InpatientAdmission.MedulaRefakatciGerekcesi)).HasColumnName("MEDULAREFAKATCIGEREKCESI");
            builder.Property(nameof(AtlasModel.InpatientAdmission.MedulaESevkNo)).HasColumnName("MEDULAESEVKNO");
            builder.Property(nameof(AtlasModel.InpatientAdmission.MedulaMutatDisiAracRaporNo)).HasColumnName("MEDULAMUTATDISIARACRAPORNO");
            builder.Property(nameof(AtlasModel.InpatientAdmission.MutatDisiAracBaslangicTarihi)).HasColumnName("MUTATDISIARACBASLANGICTARIHI");
            builder.Property(nameof(AtlasModel.InpatientAdmission.MutatDisiAracBitisTarihi)).HasColumnName("MUTATDISIARACBITISTARIHI");
            builder.Property(nameof(AtlasModel.InpatientAdmission.ActiveInPatientTrtmentClcAppRef)).HasColumnName("ACTIVEINPATIENTTRTMENTCLCAPP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InpatientAdmission.MedulaSevkDonusVasitasiRef)).HasColumnName("MEDULASEVKDONUSVASITASI").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseInpatientAdmission).WithOne().HasForeignKey<AtlasModel.BaseInpatientAdmission>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ActiveInPatientTrtmentClcApp).WithOne().HasForeignKey<AtlasModel.InpatientAdmission>(x => x.ActiveInPatientTrtmentClcAppRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}