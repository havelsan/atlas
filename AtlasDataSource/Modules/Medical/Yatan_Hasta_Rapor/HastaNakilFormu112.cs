using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;
using System.Collections.Generic;

namespace AtlasDataSource.Controllers
{
    public class HastaNakilFormu112
    {
        public static HastaNakilFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<HastaNakilFormuData>(parameters, "GetHastaNakilFormuData");
        }
        public static HastaNakilFormuData GetHastaNakilFormuData(string parameters)
        {
            HastaNakilFormuData data = new HastaNakilFormuData();
            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<HastaNakilFormuParameters>(parameters.ToString());
                    HastaNakilFormu form = objectContext.GetObject<HastaNakilFormu>(new Guid(param.ObjectID));
                    SubEpisode subepisode = form.SubEpisode;
                    Patient patient = subepisode.Episode.Patient;

                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.TCKimlikNo = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                    data.AdSoyad = patient.Name == null ? "" : patient.Name.ToString() + ' ' + patient.Surname.ToString();
                    data.Cinsiyet = patient.Sex.ADI;
                    data.DogumTarihi = patient.BirthDate;
                    data.Uyruk = patient.Nationality.Adi;
                    data.KabulNo = subepisode.ProtocolNo;
                    data.SosyalGuvence = subepisode.PatientAdmission.SEP.Payer.Name;

                    data.TalepEdildigiZaman = form.TalepEdildigiZaman;
                    data.NakilTalepEdenKlinik = form.TalepEdenKlinik != null ? form.TalepEdenKlinik.ADI : ""; 
                    data.NakilEdilmekIstenilenKlinik = form.NakilEdilmekIstenilenKlinik != null ? form.NakilEdilmekIstenilenKlinik.ADI : "" ;
                    data.HastaninBulunduguKlinik = form.HastaninBulunduguKlinik != null? form.HastaninBulunduguKlinik.ADI:"";
                    data.KomutaKontrolMerkezi = form.KomutaKontrolMerkezi != null? form.KomutaKontrolMerkezi.ADI:"";
                    data.NakilGerceklestirmeYolu = form.NakilGerceklestirmeYolu != null? form.NakilGerceklestirmeYolu.ADI:"";
                    data.SevkNedeni = form.SevkNedeni != null ?form.SevkNedeni.ADI:"";
                    data.SevkNedeniAciklama = form.SevkNedeniAciklama!= null? form.SevkNedeniAciklama:"";
                    data.KabulEdenKurumIli = form.KabulEdenKurumIli != null? form.KabulEdenKurumIli.ADI:"";
                    data.KabulEdenKurum = form.KabulEdenKurum != null ? form.KabulEdenKurum.ADI:"";
                    data.NakilKabulEdenKlinik = form.NakilKabulEdenKlinik != null ? form.NakilKabulEdenKlinik.ADI:"";
                    data.HastaHukumluMu = form.HastaHukumDurum != null? form.HastaHukumDurum.ADI:"";
                    data.AdliVakaMi = form.AdliVakaDurum != null? form.AdliVakaDurum.ADI:"";
                    data.KanGrubu = form.KabnGrubu != null ? form.KabnGrubu.ADI:"";
                    data.NakilTipi = form.HastaNakilTipi != null?form.HastaNakilTipi.ADI:"";
                    data.DoktorIhtiyaci = form.DoktorIhtiyacDurumu != null? form.DoktorIhtiyacDurumu.ADI:"";
                    data.BransIhtiyaci = form.BransIhtiyaci != null?form.BransIhtiyaci.ADI:"";
                    data.TeyitliVakaMi = form.TeyitliVakaDurumu != null ? form.TeyitliVakaDurumu.ADI:"";
                    data.SistolikKanBasinci = form.SistolikKanBasinci != null ? form.SistolikKanBasinci:"";
                    data.DiastolikKanBasinci = form.DiastolikKanBasinci != null ? form.DiastolikKanBasinci : "" ;
                    data.Solunum = form.Solunum != null ? form.Solunum.ADI:"";
                    data.SolunumSayisi = form.SolunumSayisi != null ? form.SolunumSayisi : "";

                    if (form.SolunumIslemi == "1")
                    {
                        data.SolunumIslemi = "ENTÜBE";
                    }
                    else if (form.SolunumIslemi == "2")
                        data.SolunumIslemi = "NON-INVASIVE";
                    else if (form.SolunumIslemi == "3")
                        data.SolunumIslemi = "SPONTAN";
                    else
                        data.SolunumIslemi = "";

         
                    data.GlaskowKomaSkalasi = form.GlaskowKomaSkalasi != null ? form.GlaskowKomaSkalasi : "";
                    data.Gozler = form.Gozler != null ? form.Gozler:"";
                    data.Triaj = form.TriajKodu !=null ? form.TriajKodu.ADI:"";
                    data.Ates = form.Ates != null ? form.Ates:"";
                    data.NabizSayisi = form.NabizSayisi != null ? form.NabizSayisi :"";
                    data.Bilinc = form.Bilinc != null ? form.Bilinc.ADI:"";
                    data.KanSekeri = form.KanSekeri != null ? form.KanSekeri:"";
                    data.Sozel = form.Sozel != null ? form.Sozel : "";
                    data.Motor = form.Motor != null ? form.Motor:"";
                    data.VitalBulgular = form.VitalBulgular != null ? form.VitalBulgular.ToString().ToString() : "";
                    data.PatolojikMuayeneBilgileri = form.PatolojikMuayeneBilgileri != null ? form.PatolojikMuayeneBilgileri.ToString():"";
                    data.NakilSirasindaIstenilenMedikalIslemler = form.IstenilenMedikalIslemler != null ? form.IstenilenMedikalIslemler.ToString() : "";
                    data.TetkikBilgileri = form.TetkikBilgileri != null ? form.TetkikBilgileri.ToString() : "";
                    data.YapilanMedikalIslemler = form.YapilanMedikalIslemler != null ? form.YapilanMedikalIslemler.ToString() : "";
                    data.YapilmasiIstenilenMedikalIslemler = form.YapilacakMedikalIslemler != null ? form.YapilacakMedikalIslemler.ToString() : "";
                    data.NakilSirasindakiGereksinimler = form.Gereksinimler != null ? form.Gereksinimler.ToString() : "";
                    data.TransportMalzemesi = form.TransportMalzemesi != null ? form.TransportMalzemesi.ADI:"";
                    data.MalzemeSayisi = form.MalzemeSayisi != null ? form.MalzemeSayisi :"";
                    data.HastaYakiniAdi = form.HastaYakiniAdi != null ? form.HastaYakiniAdi  : "";
                    data.HastaYakiniSoyadi = form.HastaYakiniSoyadi != null ? form.HastaYakiniSoyadi : "";
                    data.HastaYakiniTel = form.HastaYakiniTel != null ? form.HastaYakiniTel : "";
                    data.HastaYakiniAdres = form.HastaYakiniAdresi != null ? form.HastaYakiniAdresi : "";
                    data.EpikrizeEkAciklama = form.EkAciklama != null ? form.EkAciklama.ToString() : "";
                    data.HekimAdi = form.HekimAdi != null ? form.HekimAdi:"" ;
                    data.HekimSoyadi = form.HekimSoyadi != null ? form.HekimSoyadi : "";
                    data.HekimTel = form.HekimTel != null ? form.HekimTel : "";
                    data.HekimTC = form.HekimTC != null ? form.HekimTC : "";
                    data.PersonelAdi = form.PersonelAdi != null ? form.PersonelAdi : "";
                    data.PersonelSoyadi = form.PersonelSoyad != null ? form.PersonelSoyad : "";
                    data.PersonelTel = form.PersonelTel != null ? form.PersonelTel : "";


                    var diagnosisList = form.HastaNakilTanilar;
                    data.Tanilar = new List<SevkTani>();
                    foreach (HastaNakilTanilar d in diagnosisList)
                    {
                        SevkTani tani = new SevkTani();
                        tani.TaniKodu = d.SKRSICD.KODU;
                        tani.TaniAdi = d.SKRSICD.ADI;
                        data.Tanilar.Add(tani);
                    }

                }
            }

            return data;
        }
    }

    [Serializable]
    public class HastaNakilFormuParameters
    { 

        [DataMember]
        public string ObjectID { get; set; }

    }
    [Serializable]
    public class HastaNakilFormuData
    {
        [DataMember]
        public string HastahaneAdi { get; set; }

        #region Hasta Bilgileri
        [DataMember]
        public string TCKimlikNo { get; set; }
        [DataMember]
        public string AdSoyad { get; set; }
        [DataMember]
        public string Cinsiyet { get; set; }
        [DataMember]
        public DateTime? DogumTarihi { get; set; }
        [DataMember]
        public string Uyruk { get; set; }
        [DataMember]
        public string SosyalGuvence { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        #endregion
        [DataMember]
        public DateTime? TalepEdildigiZaman { get; set; }
        [DataMember]
        public string NakilTalepEdenKlinik { get; set; }
        [DataMember]
        public string NakilEdilmekIstenilenKlinik { get; set; }
        [DataMember]
        public string HastaninBulunduguKlinik { get; set; }
        [DataMember]
        public string KomutaKontrolMerkezi { get; set; }
        [DataMember]
        public string NakilGerceklestirmeYolu { get; set; }
        [DataMember]
        public string SevkNedeni { get; set; }
        [DataMember]
        public string SevkNedeniAciklama { get; set; }
        [DataMember]
        public string KabulEdenKurumIli { get; set; }
        [DataMember]
        public string KabulEdenKurum { get; set; }
        [DataMember]
        public string NakilKabulEdenKlinik { get; set; }
        [DataMember]
        public string HastaHukumluMu { get; set; }
        [DataMember]
        public string AdliVakaMi { get; set; }
        [DataMember]
        public string KanGrubu { get; set; }
        [DataMember]
        public string NakilTipi { get; set; }
        [DataMember]
        public string DoktorIhtiyaci { get; set; }
        [DataMember]
        public string BransIhtiyaci { get; set; }
        [DataMember]
        public string TeyitliVakaMi { get; set; }
        [DataMember]
        public string SistolikKanBasinci { get; set; }
        [DataMember]
        public string DiastolikKanBasinci { get; set; }
        [DataMember]
        public string Solunum { get; set; }
        [DataMember]
        public string SolunumSayisi { get; set; }
        [DataMember]
        public string SolunumIslemi { get; set; }
        [DataMember]
        public string GlaskowKomaSkalasi { get; set; }
        [DataMember]
        public string Gozler { get; set; }
        [DataMember]
        public string Triaj { get; set; }
        [DataMember]
        public string Ates { get; set; }
        [DataMember]
        public string NabizSayisi { get; set; }
        [DataMember]
        public string Bilinc { get; set; }
        [DataMember]
        public string KanSekeri { get; set; }
        [DataMember]
        public string Sozel { get; set; }
        [DataMember]
        public string Motor { get; set; }
        [DataMember]
        public string VitalBulgular { get; set; }
        [DataMember]
        public string PatolojikMuayeneBilgileri { get; set; }
        [DataMember]
        public string NakilSirasindaIstenilenMedikalIslemler { get; set; }
        [DataMember]
        public string TetkikBilgileri { get; set; }
        [DataMember]
        public string YapilanMedikalIslemler { get; set; }
        [DataMember]
        public string YapilmasiIstenilenMedikalIslemler { get; set; }
        [DataMember]
        public string NakilSirasindakiGereksinimler { get; set; }
        [DataMember]
        public string TransportMalzemesi { get; set; }
        [DataMember]
        public string MalzemeSayisi { get; set; }
        [DataMember]
        public string HastaYakiniAdi { get; set; }
        [DataMember]
        public string HastaYakiniSoyadi { get; set; }
        [DataMember]
        public string HastaYakiniTel { get; set; }
        [DataMember]
        public string HastaYakiniAdres { get; set; }
        [DataMember]
        public string EpikrizeEkAciklama { get; set; }
        [DataMember]
        public string HekimAdi { get; set; }
        [DataMember]
        public string HekimSoyadi { get; set; }
        [DataMember]
        public string HekimTel { get; set; }
        [DataMember]
        public string HekimTC { get; set; }
        [DataMember]
        public string PersonelAdi { get; set; }
        [DataMember]
        public string PersonelSoyadi { get; set; }
        [DataMember]
        public string PersonelTel { get; set; }

        //Tanılar
        [DataMember]
        public List<SevkTani> Tanilar { get; set; }

    }

    [Serializable]
    public class SevkTani
    {
        [DataMember]
        public string TaniKodu { get; set; }
        [DataMember]
        public string TaniAdi { get; set; }
    }
}
