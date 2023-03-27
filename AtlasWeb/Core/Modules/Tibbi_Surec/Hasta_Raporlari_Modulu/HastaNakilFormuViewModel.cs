using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTObjectClasses;

namespace Core.Models
{
    public class HastaNakilFormuViewModel
    {
        public bool? IsNew { get; set; }
        public string SubepisodeID { get; set; }
        public string ObjectID { get; set; }
        public DateTime? TalepEdildigiZaman { get; set; }
        public Guid? NakilTalepEdenKlinik { get; set; }
        public Guid? NakilEdilmekIstenilenKlinik { get; set; }
        public Guid? HastaninBulunduguKlinik { get; set; }
        public Guid? KomutaKontrolMerkezi { get; set; }
        public Guid? NakilGerceklestirmeYolu { get; set; }
        public Guid? SevkNedeni { get; set; }
        public string SevkNedeniAciklama { get; set; }
        public Guid? KabulEdenKurumIli { get; set; }
        public Guid? KabulEdenKurum { get; set; }
        public Guid? NakilKabulEdenKlinik { get; set; }
        public Guid? HastaHukumluMu { get; set; }
        public Guid? AdliVakaMi { get; set; }
        public Guid? KanGrubu { get; set; }
        public Guid? NakilTipi { get; set; }
        public Guid? DoktorIhtiyaci { get; set; }
        public Guid? BransIhtiyaci { get; set; }
        public Guid? TeyitliVakaMi { get; set; }
        public int? SistolikKanBasinci { get; set; }
        public int? DiastolikKanBasinci { get; set; }
        public Guid? Solunum { get; set; }
        public int? SolunumSayisi { get; set; }
        public string SolunumIslemi { get; set; }
        public int? GlaskowKomaSkalasi { get; set; }
        public int? Gozler { get; set; }
        public Guid Triaj { get; set; }
        public string Ates { get; set; }
        public int? NabizSayisi { get; set; }
        public Guid? Bilinc { get; set; }
        public int? KanSekeri { get; set; }
        public int? Sozel { get; set; }
        public int? Motor { get; set; }
        public object VitalBulgular { get; set; }
        public object PatolojikMuayeneBilgileri { get; set; }
        public object NakilSirasindaIstenilenMedikalIslemler { get; set; }
        public object TetkikBilgileri { get; set; }
        public object YapilanMedikalIslemler { get; set; }
        public object YapilmasiIstenilenMedikalIslemler { get; set; }
        public object NakilSirasindakiGereksinimler { get; set; }
        public Guid? TransportMalzemesi { get; set; }
        public int? MalzemeSayisi { get; set; }
        public string HastaYakiniAdi { get; set; }
        public string HastaYakiniSoyadi { get; set; }
        public string HastaYakiniTel { get; set; }
        public string HastaYakiniAdres { get; set; }
        public object EpikrizeEkAciklama { get; set; }
        public string HekimAdi { get; set; }
        public string HekimSoyadi { get; set; }
        public string HekimTel { get; set; }
        public string HekimTC { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string PersonelTel { get; set; }

        public string _NabizDurumu { get; set; }
        public List<DiagnosisAndProcedureBaseModel> SevkTaniList { get; set; }
    }

    public class HastaNakilSKRSModel
    {
        public List<TTObjectClasses.SKRSKlinikler> SKRSKlinikList { get; set; }
        public List<TTObjectClasses.SKRSKurumlar> SKRSKurumList { get; set; }
        public List<TTObjectClasses.SKRSNAKILYOLU> SKRSNakilYoluList { get; set; }
        public List<TTObjectClasses.SKRSSEVKNEDENI> SKRSSevkNedeniList { get; set; }
        public List<TTObjectClasses.SKRSILKodlari> SKRSILKodlariList { get; set; }
        public List<TTObjectClasses.SKRSDurum> SKRSDurumList { get; set; }
        public List<TTObjectClasses.SKRSKanGrubu> SKRSKanGrubuList { get; set; }
        public List<TTObjectClasses.SKRSHastaNakilTipi> SKRSHastaNakilTipiList { get; set; }
        public List<TTObjectClasses.SKRSSOLUNUM> SKRSSolunumList { get; set; }
        public List<TTObjectClasses.SKRSTRANSPORTMALZEMESI> SKRSTransportMalzemesiList { get; set; }
        public List<TTObjectClasses.SKRSTRIAJKODU> SKRSTriajKoduList { get; set; }
        public List<TTObjectClasses.SKRSBilinc> SKRSBilincList { get; set; }
        public List<TTObjectClasses.SKRSPersonelBransKodu> SKRSPersonelBransList { get; set; }

        public List<DoctorInfo> DoctorList { get; set; }
    }

    public class SKRSKurumDTO
    {
        public int? KODU { get; set; }
        public Guid? ObjectID { get; set; }
        public string ADI { get; set; }
    }

    public class DoctorInfo
    {
        public Guid ObjectID { get; set; }
        public string NameSurname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string UniqueRefNo { get; set; }
    }
}
