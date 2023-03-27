using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz229_IntiharGirisimiVeKrizIzlemVeriSeti
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
                messageType.code = "229";
                messageType.value = "Intihar Girisimi ve Kriz Izlem Veri Seti";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public INTIHAR_GIRISIMI_VE_KRIZ_IZLEM INTIHAR_GIRISIMI_VE_KRIZ_IZLEM = new INTIHAR_GIRISIMI_VE_KRIZ_IZLEM();

        }

        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class INTIHAR_GIRISIMI_VE_KRIZ_IZLEM
        {
            public INTIHAR_KRIZ_VAKA_TURU INTIHAR_KRIZ_VAKA_TURU = new INTIHAR_KRIZ_VAKA_TURU();

            [System.Xml.Serialization.XmlElement("INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI", Type = typeof(INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI))]
            public List<INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI> INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI;

            [System.Xml.Serialization.XmlElement("INTIHAR_GIRISIMI_YONTEMI_BILGISI", Type = typeof(INTIHAR_GIRISIMI_YONTEMI_BILGISI))]
            public List<INTIHAR_GIRISIMI_YONTEMI_BILGISI> INTIHAR_GIRISIMI_YONTEMI_BILGISI;

            [System.Xml.Serialization.XmlElement("INTIHAR_KRIZ_VAKA_SONUCU_BILGISI", Type = typeof(INTIHAR_KRIZ_VAKA_SONUCU_BILGISI))]
            public List<INTIHAR_KRIZ_VAKA_SONUCU_BILGISI> INTIHAR_KRIZ_VAKA_SONUCU_BILGISI;
        }

        public class INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI
        {
            public INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI;
        }

        public class INTIHAR_GIRISIMI_YONTEMI_BILGISI
        {
            public INTIHAR_GIRISIMI_YONTEMI INTIHAR_GIRISIMI_YONTEMI;
        }

        public class INTIHAR_KRIZ_VAKA_SONUCU_BILGISI
        {
            public INTIHAR_KRIZ_VAKA_SONUCU INTIHAR_KRIZ_VAKA_SONUCU;
        }
        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            IntiharIzlemVeriSeti intiharIzlem = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as IntiharIzlemVeriSeti;
            if (intiharIzlem == null)
                throw new Exception("'229' paketini göndermek için " + InternalObjectId + " ObjectId'li IntiharIzlemVeriSeti Objesi bulunamadı.");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            recordData _recordData = new recordData();

            if (intiharIzlem.SubEpisode.SYSTakipNo == null)
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = intiharIzlem.SubEpisode.SYSTakipNo;

            if (intiharIzlem.SKRSIntiharKrizVakaTuru != null)
                _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_KRIZ_VAKA_TURU = new INTIHAR_KRIZ_VAKA_TURU(intiharIzlem.SKRSIntiharKrizVakaTuru.KODU, intiharIzlem.SKRSIntiharKrizVakaTuru.ADI);

            if (intiharIzlem.IntiharIzlemNedeni != null)
            {
                _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI = new List<INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI>();
                foreach (IntiharIzlemNedeni neden in intiharIzlem.IntiharIzlemNedeni)
                {
                    INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI nedenBilgisi = new INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI();
                    nedenBilgisi.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI = new INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI(neden.SKRSIntiharGirisimiNedenleri.KODU, neden.SKRSIntiharGirisimiNedenleri.ADI);
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI.Add(nedenBilgisi);

                }
            }

            if (intiharIzlem.IntiharIzlemYontemi != null)
            {
                _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_GIRISIMI_YONTEMI_BILGISI = new List<INTIHAR_GIRISIMI_YONTEMI_BILGISI>();
                foreach (IntiharIzlemYontemi yontem in intiharIzlem.IntiharIzlemYontemi)
                {
                    INTIHAR_GIRISIMI_YONTEMI_BILGISI yontemBilgisi = new INTIHAR_GIRISIMI_YONTEMI_BILGISI();
                    yontemBilgisi.INTIHAR_GIRISIMI_YONTEMI = new INTIHAR_GIRISIMI_YONTEMI(yontem.SKRSICD.KODU, yontem.SKRSICD.ADI);
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_GIRISIMI_YONTEMI_BILGISI.Add(yontemBilgisi);

                }
            }

            if (intiharIzlem.IntiharIzlemVakaSonucu != null)
            {
                _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_KRIZ_VAKA_SONUCU_BILGISI = new List<INTIHAR_KRIZ_VAKA_SONUCU_BILGISI>();
                foreach (IntiharIzlemVakaSonucu sonuc in intiharIzlem.IntiharIzlemVakaSonucu)
                {
                    INTIHAR_KRIZ_VAKA_SONUCU_BILGISI sonucBilgisi = new INTIHAR_KRIZ_VAKA_SONUCU_BILGISI();
                    sonucBilgisi.INTIHAR_KRIZ_VAKA_SONUCU = new INTIHAR_KRIZ_VAKA_SONUCU(sonuc.SKRSIntiharKrizVakaSonucu.KODU, sonuc.SKRSIntiharKrizVakaSonucu.ADI);
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_KRIZ_VAKA_SONUCU_BILGISI.Add(sonucBilgisi);

                }
            }


            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }


        public static SYSMessage GetDummy()
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            IntiharIzlemVeriSeti intiharIzlem = objectContext.GetObject(new Guid("4d0e80a1-0051-4787-8639-ca522f3e4fd2"), "INTIHARIZLEMVERISETI") as IntiharIzlemVeriSeti;
            if (intiharIzlem == null)
                throw new Exception("'229' paketini göndermek için " + "4d0e80a1-0051-4787-8639-ca522f3e4fd2" + " ObjectId'li IntiharIzlemVeriSeti Objesi bulunamadı.");

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            recordData _recordData = new recordData();

            
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            if (intiharIzlem.SKRSIntiharKrizVakaTuru != null)
                _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_KRIZ_VAKA_TURU = new INTIHAR_KRIZ_VAKA_TURU(intiharIzlem.SKRSIntiharKrizVakaTuru.KODU, intiharIzlem.SKRSIntiharKrizVakaTuru.ADI);

            if (intiharIzlem.IntiharIzlemNedeni != null)
            {
                _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI = new List<INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI>();
                foreach (IntiharIzlemNedeni neden in intiharIzlem.IntiharIzlemNedeni)
                {
                    INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI nedenBilgisi = new INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI();
                    nedenBilgisi.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI = new INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI(neden.SKRSIntiharGirisimiNedenleri.KODU, neden.SKRSIntiharGirisimiNedenleri.ADI);
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENI_BILGISI.Add(nedenBilgisi);

                }
            }

            if (intiharIzlem.IntiharIzlemYontemi != null)
            {
                _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_GIRISIMI_YONTEMI_BILGISI = new List<INTIHAR_GIRISIMI_YONTEMI_BILGISI>();
                foreach (IntiharIzlemYontemi yontem in intiharIzlem.IntiharIzlemYontemi)
                {
                    INTIHAR_GIRISIMI_YONTEMI_BILGISI yontemBilgisi = new INTIHAR_GIRISIMI_YONTEMI_BILGISI();
                    yontemBilgisi.INTIHAR_GIRISIMI_YONTEMI = new INTIHAR_GIRISIMI_YONTEMI(yontem.SKRSICD.KODU, yontem.SKRSICD.ADI);
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_GIRISIMI_YONTEMI_BILGISI.Add(yontemBilgisi);

                }
            }

            if (intiharIzlem.IntiharIzlemVakaSonucu != null)
            {
                _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_KRIZ_VAKA_SONUCU_BILGISI = new List<INTIHAR_KRIZ_VAKA_SONUCU_BILGISI>();
                foreach (IntiharIzlemVakaSonucu sonuc in intiharIzlem.IntiharIzlemVakaSonucu)
                {
                    INTIHAR_KRIZ_VAKA_SONUCU_BILGISI sonucBilgisi = new INTIHAR_KRIZ_VAKA_SONUCU_BILGISI();
                    sonucBilgisi.INTIHAR_KRIZ_VAKA_SONUCU = new INTIHAR_KRIZ_VAKA_SONUCU(sonuc.SKRSIntiharKrizVakaSonucu.KODU, sonuc.SKRSIntiharKrizVakaSonucu.ADI);
                    _recordData.INTIHAR_GIRISIMI_VE_KRIZ_IZLEM.INTIHAR_KRIZ_VAKA_SONUCU_BILGISI.Add(sonucBilgisi);

                }
            }


            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
