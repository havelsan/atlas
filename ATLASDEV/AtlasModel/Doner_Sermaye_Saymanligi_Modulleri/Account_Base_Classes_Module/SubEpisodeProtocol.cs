using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SubEpisodeProtocol
    {
        public Guid ObjectId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string MedulaBasvuruNo { get; set; }
        public long? MedulaDonorTCKimlikNo { get; set; }
        public decimal? MedulaFaturaTutari { get; set; }
        public string MedulaPlakaNo { get; set; }
        public string MedulaKatilimPayindanMuaf { get; set; }
        public DateTime? MedulaProvizyonTarihi { get; set; }
        public int? MedulaYupassNo { get; set; }
        public bool? CheckPaid { get; set; }
        public MedulaSubEpisodeStatusEnum? InvoiceStatus { get; set; }
        public string MedulaTakipNo { get; set; }
        public string MedulaSonucKodu { get; set; }
        public string MedulaSonucMesaji { get; set; }
        public string MedulaKapsamAdi { get; set; }
        public SEPCloneTypeEnum? CloneType { get; set; }
        public long? Id { get; set; }
        public int? MedulaGreenCardFacilityCode { get; set; }
        public DateTime? DischargeDate { get; set; }
        public bool? Investigation { get; set; }
        public bool? Checked { get; set; }
        public string MedulaFaturaTeslimNo { get; set; }
        public DateTime? MedulaFaturaTarihi { get; set; }
        public DateTime? MedulaVakaTarihi { get; set; }
        public string Description { get; set; }
        public int? InvoiceCancelCount { get; set; }
        public Guid? InvoiceCollectionDetailRef { get; set; }
        public Guid? ParentSEPRef { get; set; }
        public Guid? BransRef { get; set; }
        public Guid? MedulaDevredilenKurumRef { get; set; }
        public Guid? MedulaIstisnaiHalRef { get; set; }
        public Guid? MedulaSigortaliTuruRef { get; set; }
        public Guid? SEPMasterRef { get; set; }
        public Guid? LastIIMRef { get; set; }
        public Guid? ClonedFromRef { get; set; }
        public Guid? PatientAdmissionRef { get; set; }
        public Guid? SubEpisodeRef { get; set; }
        public Guid? PayerRef { get; set; }
        public Guid? ProtocolRef { get; set; }
        public Guid? MedulaProvizyonTipiRef { get; set; }
        public Guid? MedulaTakipTipiRef { get; set; }
        public Guid? MedulaTedaviTipiRef { get; set; }
        public Guid? MedulaTedaviTuruRef { get; set; }
        public Guid? EpicrisisRef { get; set; }
        public Guid? IzlemUserRef { get; set; }
        public Guid? TriageRef { get; set; }
        public Guid? DischargeTypeRef { get; set; }

        #region Parent Relations
        public virtual InvoiceCollectionDetail InvoiceCollectionDetail { get; set; }
        public virtual SubEpisodeProtocol ParentSEP { get; set; }
        public virtual DevredilenKurum MedulaDevredilenKurum { get; set; }
        public virtual SEPMaster SEPMaster { get; set; }
        public virtual InvoiceInclusionMaster LastIIM { get; set; }
        public virtual SubEpisodeProtocol ClonedFrom { get; set; }
        public virtual PatientAdmission PatientAdmission { get; set; }
        public virtual SubEpisode SubEpisode { get; set; }
        public virtual PayerDefinition Payer { get; set; }
        public virtual SEPEpicrisis Epicrisis { get; set; }
        public virtual ResUser IzlemUser { get; set; }
        public virtual TaburcuKodu DischargeType { get; set; }
        #endregion Parent Relations
    }
}