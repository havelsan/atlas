using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz248_TutunKullanimiVeriSeti
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
                messageType.code = "248";
                messageType.value = TTUtils.CultureService.GetText("M27132", "Tütün Kullanimi Veri Seti");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public TUTUN_KULLANIMI TUTUN_KULLANIMI = new TUTUN_KULLANIMI();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class TUTUN_KULLANIMI
        {
            public SIGARA_ADEDI SIGARA_ADEDI;
            public SIGARA_KULLANIMI SIGARA_KULLANIMI;
            public TUTUN_DUMANINA_MARUZ_KALMA TUTUN_DUMANINA_MARUZ_KALMA;
            [System.Xml.Serialization.XmlElement("BAGIMLI_OLDUGU_URUN_BILGISI", Type = typeof(BAGIMLI_OLDUGU_URUN_BILGISI))]        // Bağımlı olduğu ürün bilgisi zorunlu
            public List<BAGIMLI_OLDUGU_URUN_BILGISI> BAGIMLI_OLDUGU_URUN_BILGISI = new List<BAGIMLI_OLDUGU_URUN_BILGISI>();
            [System.Xml.Serialization.XmlElement("TEDAVI_SEKLI_BILGISI", Type = typeof(TEDAVI_SEKLI_BILGISI))]
            public List<TEDAVI_SEKLI_BILGISI> TEDAVI_SEKLI_BILGISI;
            [System.Xml.Serialization.XmlElement("TUTUN_TEDAVI_SONUCU_BILGISI", Type = typeof(TUTUN_TEDAVI_SONUCU_BILGISI))]
            public List<TUTUN_TEDAVI_SONUCU_BILGISI> TUTUN_TEDAVI_SONUCU_BILGISI;
        }
        public class BAGIMLI_OLDUGU_URUN_BILGISI
        {
            public BAGIMLI_OLDUGU_URUN BAGIMLI_OLDUGU_URUN;
        }
        
        public class TEDAVI_SEKLI_BILGISI
        {
            public TEDAVI_SEKLI TEDAVI_SEKLI;
        }

        public class TUTUN_TEDAVI_SONUCU_BILGISI
        {
            public TUTUN_TEDAVI_SONUCU TUTUN_TEDAVI_SONUCU;
        }

        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                TutunKullanimiVeriSeti tutunKullanimiVeriSeti = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as TutunKullanimiVeriSeti;
                if (tutunKullanimiVeriSeti == null)
                    throw new Exception("'248' paketini göndermek için " + InternalObjectId + " ObjectId'li TutunKullanimiVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                _recordData.TUTUN_KULLANIMI.SIGARA_ADEDI = new SIGARA_ADEDI();
                _recordData.TUTUN_KULLANIMI.SIGARA_ADEDI.value = tutunKullanimiVeriSeti.SigaraAdedi.ToString();
                _recordData.TUTUN_KULLANIMI.SIGARA_KULLANIMI = new SIGARA_KULLANIMI(tutunKullanimiVeriSeti.SKRSSigaraKullanimi.KODU, tutunKullanimiVeriSeti.SKRSSigaraKullanimi.ADI);
               _recordData.TUTUN_KULLANIMI.TUTUN_DUMANINA_MARUZ_KALMA = new TUTUN_DUMANINA_MARUZ_KALMA(tutunKullanimiVeriSeti.SKRSTutunDumaninaMaruzKalma.KODU, tutunKullanimiVeriSeti.SKRSTutunDumaninaMaruzKalma.ADI);

                if(tutunKullanimiVeriSeti.TutunKullanimiBagimOldUrun != null)
                {
                    _recordData.TUTUN_KULLANIMI.BAGIMLI_OLDUGU_URUN_BILGISI = new List<BAGIMLI_OLDUGU_URUN_BILGISI>();
                    foreach (TutunKullanimiBagimOldUrun bagimliOlduguUrun in tutunKullanimiVeriSeti.TutunKullanimiBagimOldUrun)
                    {
                        BAGIMLI_OLDUGU_URUN_BILGISI urunBilgisi = new BAGIMLI_OLDUGU_URUN_BILGISI();
                        urunBilgisi.BAGIMLI_OLDUGU_URUN = new BAGIMLI_OLDUGU_URUN(bagimliOlduguUrun.SKRSBagimliOlduguUrun.KODU, bagimliOlduguUrun.SKRSBagimliOlduguUrun.ADI);
                        _recordData.TUTUN_KULLANIMI.BAGIMLI_OLDUGU_URUN_BILGISI.Add(urunBilgisi);

                    }
                }

                if (tutunKullanimiVeriSeti.TutunKullanimiTedaviSekli != null)
                {
                    _recordData.TUTUN_KULLANIMI.TEDAVI_SEKLI_BILGISI = new List<TEDAVI_SEKLI_BILGISI>();
                    foreach (TutunKullanimiTedaviSekli tedaviSekli in tutunKullanimiVeriSeti.TutunKullanimiTedaviSekli)
                    {
                        TEDAVI_SEKLI_BILGISI tedaviBilgisi = new TEDAVI_SEKLI_BILGISI();
                        tedaviBilgisi.TEDAVI_SEKLI= new TEDAVI_SEKLI(tedaviSekli.SKRSTedaviSekli.KODU, tedaviSekli.SKRSTedaviSekli.ADI);
                        _recordData.TUTUN_KULLANIMI.TEDAVI_SEKLI_BILGISI.Add(tedaviBilgisi);

                    }
                }

                if (tutunKullanimiVeriSeti.TutunKullanimiTedaviSonucu != null)
                {
                    _recordData.TUTUN_KULLANIMI.TUTUN_TEDAVI_SONUCU_BILGISI = new List<TUTUN_TEDAVI_SONUCU_BILGISI>();
                    foreach (TutunKullanimiTedaviSonucu tedaviSonucu in tutunKullanimiVeriSeti.TutunKullanimiTedaviSonucu)
                    {
                        TUTUN_TEDAVI_SONUCU_BILGISI tedaviSonucBilgisi = new TUTUN_TEDAVI_SONUCU_BILGISI();
                        tedaviSonucBilgisi.TUTUN_TEDAVI_SONUCU= new TUTUN_TEDAVI_SONUCU(tedaviSonucu.SKRSTutunTedaviSonucu.KODU, tedaviSonucu.SKRSTutunTedaviSonucu.ADI);
                        _recordData.TUTUN_KULLANIMI.TUTUN_TEDAVI_SONUCU_BILGISI.Add(tedaviSonucBilgisi);

                    }
                }
                
                 if (tutunKullanimiVeriSeti.SubEpisode.SYSTakipNo == null)
                     throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                 else
                     _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = tutunKullanimiVeriSeti.SubEpisode.SYSTakipNo;
                     
                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }

        public static SYSMessage GetDummy()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                TutunKullanimiVeriSeti tutunKullanimiVeriSeti = objectContext.GetObject(new Guid("bf3f9c7f-481b-4828-b8da-e45507b4290b"), "TUTUNKULLANIMIVERISETI") as TutunKullanimiVeriSeti;
                if (tutunKullanimiVeriSeti == null)
                    throw new Exception("'248' paketini göndermek için " + "c079bb0b-935d-4817-8ddd-75be384f42fe" + " ObjectId'li TutunKullanimiVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                _recordData.TUTUN_KULLANIMI.SIGARA_ADEDI = new SIGARA_ADEDI();
                _recordData.TUTUN_KULLANIMI.SIGARA_ADEDI.value = tutunKullanimiVeriSeti.SigaraAdedi.ToString();
                _recordData.TUTUN_KULLANIMI.SIGARA_KULLANIMI = new SIGARA_KULLANIMI(tutunKullanimiVeriSeti.SKRSSigaraKullanimi.KODU, tutunKullanimiVeriSeti.SKRSSigaraKullanimi.ADI);
                _recordData.TUTUN_KULLANIMI.TUTUN_DUMANINA_MARUZ_KALMA = new TUTUN_DUMANINA_MARUZ_KALMA(tutunKullanimiVeriSeti.SKRSTutunDumaninaMaruzKalma.KODU, tutunKullanimiVeriSeti.SKRSTutunDumaninaMaruzKalma.ADI);

                if (tutunKullanimiVeriSeti.TutunKullanimiBagimOldUrun != null)
                {
                    _recordData.TUTUN_KULLANIMI.BAGIMLI_OLDUGU_URUN_BILGISI = new List<BAGIMLI_OLDUGU_URUN_BILGISI>();
                    foreach (TutunKullanimiBagimOldUrun bagimliOlduguUrun in tutunKullanimiVeriSeti.TutunKullanimiBagimOldUrun)
                    {
                        BAGIMLI_OLDUGU_URUN_BILGISI urunBilgisi = new BAGIMLI_OLDUGU_URUN_BILGISI();
                        urunBilgisi.BAGIMLI_OLDUGU_URUN = new BAGIMLI_OLDUGU_URUN(bagimliOlduguUrun.SKRSBagimliOlduguUrun.KODU, bagimliOlduguUrun.SKRSBagimliOlduguUrun.ADI);
                        _recordData.TUTUN_KULLANIMI.BAGIMLI_OLDUGU_URUN_BILGISI.Add(urunBilgisi);

                    }
                }

                if (tutunKullanimiVeriSeti.TutunKullanimiTedaviSekli != null)
                {
                    _recordData.TUTUN_KULLANIMI.TEDAVI_SEKLI_BILGISI = new List<TEDAVI_SEKLI_BILGISI>();
                    foreach (TutunKullanimiTedaviSekli tedaviSekli in tutunKullanimiVeriSeti.TutunKullanimiTedaviSekli)
                    {
                        TEDAVI_SEKLI_BILGISI tedaviBilgisi = new TEDAVI_SEKLI_BILGISI();
                        tedaviBilgisi.TEDAVI_SEKLI = new TEDAVI_SEKLI(tedaviSekli.SKRSTedaviSekli.KODU, tedaviSekli.SKRSTedaviSekli.ADI);
                        _recordData.TUTUN_KULLANIMI.TEDAVI_SEKLI_BILGISI.Add(tedaviBilgisi);

                    }
                }

                if (tutunKullanimiVeriSeti.TutunKullanimiTedaviSonucu != null)
                {
                    _recordData.TUTUN_KULLANIMI.TUTUN_TEDAVI_SONUCU_BILGISI = new List<TUTUN_TEDAVI_SONUCU_BILGISI>();
                    foreach (TutunKullanimiTedaviSonucu tedaviSonucu in tutunKullanimiVeriSeti.TutunKullanimiTedaviSonucu)
                    {
                        TUTUN_TEDAVI_SONUCU_BILGISI tedaviSonucBilgisi = new TUTUN_TEDAVI_SONUCU_BILGISI();
                        tedaviSonucBilgisi.TUTUN_TEDAVI_SONUCU = new TUTUN_TEDAVI_SONUCU(tedaviSonucu.SKRSTutunTedaviSonucu.KODU, tedaviSonucu.SKRSTutunTedaviSonucu.ADI);
                        _recordData.TUTUN_KULLANIMI.TUTUN_TEDAVI_SONUCU_BILGISI.Add(tedaviSonucBilgisi);

                    }
                }

                
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }
    }
}
