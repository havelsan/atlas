using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SubEpisodeProtocolConfig : IEntityTypeConfiguration<AtlasModel.SubEpisodeProtocol>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SubEpisodeProtocol> builder)
        {
            builder.ToTable("SUBEPISODEPROTOCOL");
            builder.HasKey(nameof(AtlasModel.SubEpisodeProtocol.ObjectId));
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.CreationDate)).HasColumnName("CREATIONDATE");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaBasvuruNo)).HasColumnName("MEDULABASVURUNO").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaDonorTCKimlikNo)).HasColumnName("MEDULADONORTCKIMLIKNO");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaFaturaTutari)).HasColumnName("MEDULAFATURATUTARI").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaPlakaNo)).HasColumnName("MEDULAPLAKANO");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaKatilimPayindanMuaf)).HasColumnName("MEDULAKATILIMPAYINDANMUAF");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaProvizyonTarihi)).HasColumnName("MEDULAPROVIZYONTARIHI");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaYupassNo)).HasColumnName("MEDULAYUPASSNO");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.CheckPaid)).HasColumnName("CHECKPAID");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.InvoiceStatus)).HasColumnName("INVOICESTATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaTakipNo)).HasColumnName("MEDULATAKIPNO").HasMaxLength(15);
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaSonucKodu)).HasColumnName("MEDULASONUCKODU");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaSonucMesaji)).HasColumnName("MEDULASONUCMESAJI").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaKapsamAdi)).HasColumnName("MEDULAKAPSAMADI").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.CloneType)).HasColumnName("CLONETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.Id)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaGreenCardFacilityCode)).HasColumnName("MEDULAGREENCARDFACILITYCODE");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.DischargeDate)).HasColumnName("DISCHARGEDATE");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.Investigation)).HasColumnName("INVESTIGATION");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.Checked)).HasColumnName("CHECKED");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaFaturaTeslimNo)).HasColumnName("MEDULAFATURATESLIMNO");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaFaturaTarihi)).HasColumnName("MEDULAFATURATARIHI");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaVakaTarihi)).HasColumnName("MEDULAVAKATARIHI");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.Description)).HasColumnName("DESCRIPTION").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.InvoiceCancelCount)).HasColumnName("INVOICECANCELCOUNT");
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.InvoiceCollectionDetailRef)).HasColumnName("INVOICECOLLECTIONDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.ParentSEPRef)).HasColumnName("PARENTSEP").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.BransRef)).HasColumnName("BRANS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaDevredilenKurumRef)).HasColumnName("MEDULADEVREDILENKURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaIstisnaiHalRef)).HasColumnName("MEDULAISTISNAIHAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaSigortaliTuruRef)).HasColumnName("MEDULASIGORTALITURU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.SEPMasterRef)).HasColumnName("SEPMASTER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.LastIIMRef)).HasColumnName("LASTIIM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.ClonedFromRef)).HasColumnName("CLONEDFROM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.PatientAdmissionRef)).HasColumnName("PATIENTADMISSION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.SubEpisodeRef)).HasColumnName("SUBEPISODE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.PayerRef)).HasColumnName("PAYER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.ProtocolRef)).HasColumnName("PROTOCOL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaProvizyonTipiRef)).HasColumnName("MEDULAPROVIZYONTIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaTakipTipiRef)).HasColumnName("MEDULATAKIPTIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaTedaviTipiRef)).HasColumnName("MEDULATEDAVITIPI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.MedulaTedaviTuruRef)).HasColumnName("MEDULATEDAVITURU").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.EpicrisisRef)).HasColumnName("EPICRISIS").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.IzlemUserRef)).HasColumnName("IZLEMUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.TriageRef)).HasColumnName("TRIAGE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.SubEpisodeProtocol.DischargeTypeRef)).HasColumnName("DISCHARGETYPE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InvoiceCollectionDetail).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.InvoiceCollectionDetailRef).IsRequired(false);
            builder.HasOne(t => t.ParentSEP).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.ParentSEPRef).IsRequired(false);
            builder.HasOne(t => t.MedulaDevredilenKurum).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.MedulaDevredilenKurumRef).IsRequired(false);
            builder.HasOne(t => t.SEPMaster).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.SEPMasterRef).IsRequired(true);
            builder.HasOne(t => t.LastIIM).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.LastIIMRef).IsRequired(false);
            builder.HasOne(t => t.ClonedFrom).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.ClonedFromRef).IsRequired(false);
            builder.HasOne(t => t.PatientAdmission).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.PatientAdmissionRef).IsRequired(false);
            builder.HasOne(t => t.SubEpisode).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.SubEpisodeRef).IsRequired(true);
            builder.HasOne(t => t.Payer).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.PayerRef).IsRequired(true);
            builder.HasOne(t => t.Epicrisis).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.EpicrisisRef).IsRequired(false);
            builder.HasOne(t => t.IzlemUser).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.IzlemUserRef).IsRequired(false);
            builder.HasOne(t => t.DischargeType).WithOne().HasForeignKey<AtlasModel.SubEpisodeProtocol>(x => x.DischargeTypeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}