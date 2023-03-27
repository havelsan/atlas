using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz241_OlumBildirimVeriSeti
    {
        public class SYSSendMessage
        {
            public input input = new input();
        }
        public class input
        {
            public SYSMessage SYSMessage = new SYSMessage();
        }
        public class SYSMessage
        {
            public messageGuid messageGuid = new messageGuid();
            public messageType messageType = new messageType();
            public documentGenerationTime documentGenerationTime = new documentGenerationTime();
            public author author = new author();
            public firmaKodu firmaKodu = new firmaKodu();

            public recordData recordData = new recordData();

            public SYSMessage()
            {
                messageType.code = "241";
                messageType.value = "Ölüm Bildirim Veri Seti";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public OLUM_BILDIRIM OLUM_BILDIRIM = new OLUM_BILDIRIM();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class OLUM_BILDIRIM
        {
            public ACIK_ADRES ACIK_ADRES;
            public ADRES_KODU ADRES_KODU = new ADRES_KODU();
            public ADRES_KODU_SEVIYESI ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI();
            public ADRES_TIPI ADRES_TIPI = new ADRES_TIPI();
            public DEFIN_IZNINI_VEREN_KISININ_KIMLIK_NUMARASI DEFIN_IZNINI_VEREN_KISININ_KIMLIK_NUMARASI = new DEFIN_IZNINI_VEREN_KISININ_KIMLIK_NUMARASI(); // Ölüm belgesini dolduran doktorun tcsi
            public OLUM_NEDENI_DEGERLENDIRME OLUM_NEDENI_DEGERLENDIRME = new OLUM_NEDENI_DEGERLENDIRME();
            public OLUM_TARIHI OLUM_TARIHI = new OLUM_TARIHI();
            public OLUM_YERI OLUM_YERI = new OLUM_YERI();
            public OTOPSI_DURUMU OTOPSI_DURUMU;
            public YARALANMANIN_YERI YARALANMANIN_YERI;
            public YARALANMA_TARIHI YARALANMA_TARIHI;
            [System.Xml.Serialization.XmlElement("OLUM_NEDENI_BILGISI", Type = typeof(OLUM_NEDENI_BILGISI))]
            public List<OLUM_NEDENI_BILGISI> OLUM_NEDENI_BILGISI = new List<OLUM_NEDENI_BILGISI>();
            [System.Xml.Serialization.XmlElement("OLUM_SEKLI_BILGISI", Type = typeof(OLUM_SEKLI_BILGISI))]
            public List<OLUM_SEKLI_BILGISI> OLUM_SEKLI_BILGISI = new List<OLUM_SEKLI_BILGISI>();
        }
        public class OLUM_NEDENI_BILGISI
        {
            public OLUM_NEDENI_TANI_KODU OLUM_NEDENI_TANI_KODU = new OLUM_NEDENI_TANI_KODU();
            public OLUM_NEDENI_TURU OLUM_NEDENI_TURU = new OLUM_NEDENI_TURU();
        }

        public class OLUM_SEKLI_BILGISI
        {
            public OLUM_SEKLI OLUM_SEKLI = new OLUM_SEKLI();
        }
        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            //InternalObjectGuid bu object için Morgue
            TTObjectContext objectContext = new TTObjectContext(true);
            Morgue morgue = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as Morgue;
            if (morgue == null)
                throw new Exception("'241' paketini göndermek için " + InternalObjectId + " ObjectId'li Morgue Objesi bulunamadı.");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            recordData _recordData = new recordData();

            if (morgue.SubEpisode.SYSTakipNo == null)
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = morgue.SubEpisode.SYSTakipNo;
           
            //Adres eklenebilir zorunlu değil.Adres tipi ve kodu seviyesi diğer paketlerden kaldırıldığı için buradan da kaldırılabilir diye eklenmedi.

            _recordData.OLUM_BILDIRIM.DEFIN_IZNINI_VEREN_KISININ_KIMLIK_NUMARASI.value = morgue.DoctorFixed.Person.UniqueRefNo.ToString();
            _recordData.OLUM_BILDIRIM.OLUM_NEDENI_DEGERLENDIRME.value = morgue.DeathReasonEvaluation.ToString();
            _recordData.OLUM_BILDIRIM.OLUM_TARIHI.value = morgue.DateTimeOfDeath.HasValue ? morgue.DateTimeOfDeath.Value.ToString("yyyyMMddHHmm") : string.Empty;
            _recordData.OLUM_BILDIRIM.OLUM_YERI = new OLUM_YERI(morgue.SKRSDeathPlace.KODU, morgue.SKRSDeathPlace.ADI);
            //forma  combosu eklenince burayada eklenecek

            if (morgue.SKRSInjuryPlace != null)
                _recordData.OLUM_BILDIRIM.YARALANMANIN_YERI = new YARALANMANIN_YERI(morgue.SKRSInjuryPlace.KODU, morgue.SKRSInjuryPlace.ADI);
            if (morgue.InjuryDate != null)
                _recordData.OLUM_BILDIRIM.YARALANMA_TARIHI.value = morgue.InjuryDate.Value.ToString("yyyyMMddHHmm");

            OLUM_NEDENI_BILGISI olumNedeniBilgisi = new OLUM_NEDENI_BILGISI();
            foreach (DeathReasonDiagnosis olumNedeni in morgue.DeathReasonDiagnosis)
            {
                olumNedeniBilgisi = new OLUM_NEDENI_BILGISI();
                olumNedeniBilgisi.OLUM_NEDENI_TANI_KODU = new OLUM_NEDENI_TANI_KODU(olumNedeni.SKRSICD.KODU, olumNedeni.SKRSICD.ADI);
                olumNedeniBilgisi.OLUM_NEDENI_TURU = new OLUM_NEDENI_TURU(olumNedeni.SKRSOlumNedeniTuru.KODU, olumNedeni.SKRSOlumNedeniTuru.ADI);

                _recordData.OLUM_BILDIRIM.OLUM_NEDENI_BILGISI.Add(olumNedeniBilgisi);
            }

            OLUM_SEKLI_BILGISI olumSekliBilgisi = new OLUM_SEKLI_BILGISI();
            foreach (MorgueDeathType olumSekli in morgue.MorgueDeathType)
            {
                olumSekliBilgisi = new OLUM_SEKLI_BILGISI();
                olumSekliBilgisi.OLUM_SEKLI = new OLUM_SEKLI(olumSekli.SKRSOlumSekli.KODU, olumSekli.SKRSOlumSekli.ADI);
                
                _recordData.OLUM_BILDIRIM.OLUM_SEKLI_BILGISI.Add(olumSekliBilgisi);
            }


            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }


        public static SYSMessage GetDummy()
        {

            recordData _recordData = new recordData();

            _recordData.OLUM_BILDIRIM.ADRES_KODU.value = "1";
            _recordData.OLUM_BILDIRIM.ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI("4", "KÖY");
            _recordData.OLUM_BILDIRIM.ADRES_TIPI = new ADRES_TIPI("3", "İŞ ADRESİ");
            _recordData.OLUM_BILDIRIM.DEFIN_IZNINI_VEREN_KISININ_KIMLIK_NUMARASI.value = "10000000000";
            _recordData.OLUM_BILDIRIM.OLUM_NEDENI_DEGERLENDIRME.value = "test";
            _recordData.OLUM_BILDIRIM.OLUM_TARIHI.value = "201801010000";
            _recordData.OLUM_BILDIRIM.OLUM_YERI = new OLUM_YERI("1", "EV");
            OLUM_NEDENI_BILGISI olumNedeni = new OLUM_NEDENI_BILGISI();
            olumNedeni.OLUM_NEDENI_TANI_KODU = new OLUM_NEDENI_TANI_KODU("J98.9", "SOLUNUM BOZUKLUKLARI, TANIMLANMAMIŞ");
            olumNedeni.OLUM_NEDENI_TURU = new OLUM_NEDENI_TURU("1", "SON NEDEN");
            _recordData.OLUM_BILDIRIM.OLUM_NEDENI_BILGISI.Add(olumNedeni);
            OLUM_SEKLI_BILGISI olumSekli = new OLUM_SEKLI_BILGISI();
            olumSekli.OLUM_SEKLI = new OLUM_SEKLI("98", "DİĞER");
            _recordData.OLUM_BILDIRIM.OLUM_SEKLI_BILGISI.Add(olumSekli);

            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
