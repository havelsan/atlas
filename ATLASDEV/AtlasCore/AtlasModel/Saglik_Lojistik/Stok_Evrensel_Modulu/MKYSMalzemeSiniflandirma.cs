using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MKYSMalzemeSiniflandirma
    {
        public Guid ObjectId { get; set; }
        public int? MalzemeKayitID { get; set; }
        public string MalzemeKodu { get; set; }
        public string MalzemeAdi { get; set; }
        public DateTime? DegisiklikTarihi { get; set; }
        public string TibbiSarfKlinikBransi { get; set; }
        public string TibbiSarfKullanimYeri { get; set; }
        public string TibbiSarfKullanimAmaci { get; set; }
        public string TibbiSarfMalzemeCinsi { get; set; }
        public string TibbiSarfSutKodu { get; set; }
        public string LaboratuvarBransi { get; set; }
        public string LaboratuvarCinsi { get; set; }
        public string LaboratuvarSutKodu { get; set; }
        public string CerrahiAletBransi { get; set; }
        public string CerrahiAletCinsi { get; set; }
        public string CerrahiAletSutKodu { get; set; }
        public string BiyomedikalCihazTur { get; set; }
        public string BiyomedikalCihazTanim { get; set; }
        public string BiyomedikalSarfTur { get; set; }
        public string BiyomedikalSarfTanim { get; set; }
        public string BiyomedikalSarfCins { get; set; }
        public string BiyomedikalSarfNitelik { get; set; }
        public string BiyomedikalSarfSutKodu { get; set; }
        public string IlacBarkod { get; set; }
        public string IlacAdi { get; set; }
        public string IlacJenerikKodu { get; set; }
        public string IlacJenerikAdi { get; set; }
        public string Pasif { get; set; }
        public string BarkodDogrulamaDurumu { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}