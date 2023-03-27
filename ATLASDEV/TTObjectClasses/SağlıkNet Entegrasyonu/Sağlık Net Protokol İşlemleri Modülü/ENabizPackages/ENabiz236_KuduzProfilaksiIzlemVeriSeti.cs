using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz236_KuduzProfilaksiIzlemVeriSeti
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
                messageType.code = "236";
                messageType.value = TTUtils.CultureService.GetText("M26346", "Kuduz Profilaksi Izlem Veri Seti");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public KUDUZ_PROFILAKSI_IZLEM KUDUZ_PROFILAKSI_IZLEM = new KUDUZ_PROFILAKSI_IZLEM();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class KUDUZ_PROFILAKSI_IZLEM
        {
            [System.Xml.Serialization.XmlElement("UYGULANAN_KUDUZ_PROFILAKSISI", Type = typeof(UYGULANAN_KUDUZ_PROFILAKSISI))]
            public List<UYGULANAN_KUDUZ_PROFILAKSISI> UYGULANAN_KUDUZ_PROFILAKSISI = new List<UYGULANAN_KUDUZ_PROFILAKSISI>();      // zorunlu

            public KUDUZ_PROFILAKSISI_SONLANMA_DURUMU KUDUZ_PROFILAKSISI_SONLANMA_DURUMU = new KUDUZ_PROFILAKSISI_SONLANMA_DURUMU(); // zorunlu 
            public IMMUNGLOBULIN_TURU IMMUNGLOBULIN_TURU ;// koşullu 
            public KILO KILO;
            public IMMUNGLOBULIN_MIKTARI IMMUNGLOBULIN_MIKTARI;
           

        }
      
        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                KuduzProfilaksiVeriSeti kuduzProfilaksiVeriSeti = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as KuduzProfilaksiVeriSeti;
                if (kuduzProfilaksiVeriSeti == null)
                    throw new Exception("'236' paketini göndermek için " + InternalObjectId + " ObjectId'li KuduzProfilaksiVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                if (kuduzProfilaksiVeriSeti.KuduzProfilaksiUygProfilak != null)
                {
                    _recordData.KUDUZ_PROFILAKSI_IZLEM.UYGULANAN_KUDUZ_PROFILAKSISI = new List<UYGULANAN_KUDUZ_PROFILAKSISI>();
                    foreach (KuduzProfilaksiUygProfilak uygulananProfilaksi in kuduzProfilaksiVeriSeti.KuduzProfilaksiUygProfilak)
                    {
                        UYGULANAN_KUDUZ_PROFILAKSISI item = new UYGULANAN_KUDUZ_PROFILAKSISI(uygulananProfilaksi.SKRSUygulananKuduzProfilaksi.KODU, uygulananProfilaksi.SKRSUygulananKuduzProfilaksi.ADI);
                        _recordData.KUDUZ_PROFILAKSI_IZLEM.UYGULANAN_KUDUZ_PROFILAKSISI.Add(item);
                    }
                }


                _recordData.KUDUZ_PROFILAKSI_IZLEM.KUDUZ_PROFILAKSISI_SONLANMA_DURUMU = new KUDUZ_PROFILAKSISI_SONLANMA_DURUMU(kuduzProfilaksiVeriSeti.SKRSKuduzProfilaksiTamamlanma.KODU, kuduzProfilaksiVeriSeti.SKRSKuduzProfilaksiTamamlanma.ADI);
                

                if(kuduzProfilaksiVeriSeti.Kilo != null)
                {
                    _recordData.KUDUZ_PROFILAKSI_IZLEM.KILO = new KILO();
                    _recordData.KUDUZ_PROFILAKSI_IZLEM.KILO.value = kuduzProfilaksiVeriSeti.Kilo.ToString();
                }

                if (kuduzProfilaksiVeriSeti.ImmunglobulinMiktari!= null)
                {
                    _recordData.KUDUZ_PROFILAKSI_IZLEM.IMMUNGLOBULIN_MIKTARI = new IMMUNGLOBULIN_MIKTARI();
                    _recordData.KUDUZ_PROFILAKSI_IZLEM.IMMUNGLOBULIN_MIKTARI.value = kuduzProfilaksiVeriSeti.ImmunglobulinMiktari.ToString();
                }

                // İmunuglobin türü
                if (kuduzProfilaksiVeriSeti.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = kuduzProfilaksiVeriSeti.SubEpisode.SYSTakipNo;

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }

        public static SYSMessage GetDummy()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                KuduzProfilaksiVeriSeti kuduzProfilaksiVeriSeti = objectContext.GetObject(new Guid("fbf422d1-c002-4fde-973e-aa30544166dd"), "KUDUZPROFILAKSIVERISETI") as KuduzProfilaksiVeriSeti;
                if (kuduzProfilaksiVeriSeti == null)
                    throw new Exception("'236' paketini göndermek için " + "fbf422d1-c002-4fde-973e-aa30544166dd" + " ObjectId'li KuduzProfilaksiVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                if (kuduzProfilaksiVeriSeti.KuduzProfilaksiUygProfilak != null)
                {
                    _recordData.KUDUZ_PROFILAKSI_IZLEM.UYGULANAN_KUDUZ_PROFILAKSISI = new List<UYGULANAN_KUDUZ_PROFILAKSISI>();
                    foreach (KuduzProfilaksiUygProfilak uygulananProfilaksi in kuduzProfilaksiVeriSeti.KuduzProfilaksiUygProfilak)
                    {
                        UYGULANAN_KUDUZ_PROFILAKSISI item = new UYGULANAN_KUDUZ_PROFILAKSISI(uygulananProfilaksi.SKRSUygulananKuduzProfilaksi.KODU, uygulananProfilaksi.SKRSUygulananKuduzProfilaksi.ADI);
                        _recordData.KUDUZ_PROFILAKSI_IZLEM.UYGULANAN_KUDUZ_PROFILAKSISI.Add(item);
                    }
                }


                _recordData.KUDUZ_PROFILAKSI_IZLEM.KUDUZ_PROFILAKSISI_SONLANMA_DURUMU = new KUDUZ_PROFILAKSISI_SONLANMA_DURUMU(kuduzProfilaksiVeriSeti.SKRSKuduzProfilaksiTamamlanma.KODU, kuduzProfilaksiVeriSeti.SKRSKuduzProfilaksiTamamlanma.ADI);


                if (kuduzProfilaksiVeriSeti.Kilo != null)
                {
                    _recordData.KUDUZ_PROFILAKSI_IZLEM.KILO = new KILO();
                    _recordData.KUDUZ_PROFILAKSI_IZLEM.KILO.value = kuduzProfilaksiVeriSeti.Kilo.ToString();
                }

                if (kuduzProfilaksiVeriSeti.ImmunglobulinMiktari != null)
                {
                    _recordData.KUDUZ_PROFILAKSI_IZLEM.IMMUNGLOBULIN_MIKTARI = new IMMUNGLOBULIN_MIKTARI();
                    _recordData.KUDUZ_PROFILAKSI_IZLEM.IMMUNGLOBULIN_MIKTARI.value = kuduzProfilaksiVeriSeti.ImmunglobulinMiktari.ToString();
                }

                // İmunuglobin türü
                if (kuduzProfilaksiVeriSeti.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = kuduzProfilaksiVeriSeti.SubEpisode.SYSTakipNo;

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }

    }
}
