using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz237_KuduzRiskliTemasBildirimVeriSeti
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
                messageType.code = "237";
                messageType.value = TTUtils.CultureService.GetText("M26347", "Kuduz Riskli Temas Bildirim Veri Seti");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public KUDUZ_RISKLI_TEMAS_BILDIRIM KUDUZ_RISKLI_TEMAS_BILDIRIM = new KUDUZ_RISKLI_TEMAS_BILDIRIM();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class KUDUZ_RISKLI_TEMAS_BILDIRIM
        {
            public RISKLI_TEMAS_TARIHI RISKLI_TEMAS_TARIHI = new RISKLI_TEMAS_TARIHI(); //Zorunlu
            public RISKLI_TEMAS_TIPI RISKLI_TEMAS_TIPI = new RISKLI_TEMAS_TIPI();//Zorunlu 
            [System.Xml.Serialization.XmlElement("RISKLI_TEMASA_SEBEP_OLAN_HAYVAN", Type = typeof(RISKLI_TEMASA_SEBEP_OLAN_HAYVAN))]
            public List<RISKLI_TEMASA_SEBEP_OLAN_HAYVAN> RISKLI_TEMASA_SEBEP_OLAN_HAYVAN = new List<RISKLI_TEMASA_SEBEP_OLAN_HAYVAN>();   //Zorunlu 

            [System.Xml.Serialization.XmlElement("KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI", Type = typeof(KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI))]
            public List<KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI> KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI = new List<KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI>();         // koşullu
            [System.Xml.Serialization.XmlElement("TELEFON_BILGISI", Type = typeof(TELEFON_BILGISI))]
            public List<TELEFON_BILGISI> TELEFON_BILGISI = new List<TELEFON_BILGISI>();         // zorunlu

            public OLAYIN_GERCEKLESTIGI_ADRES OLAYIN_GERCEKLESTIGI_ADRES; //Seçimli
            public BEYAN_ADRES_BILGISI BEYAN_ADRES_BILGISI;

        }

        public class BEYAN_ADRES_BILGISI
        {
            public BUCAK_KODU BUCAK_KODU = new BUCAK_KODU();
            public CSBM_KODU CSBM_KODU = new CSBM_KODU();
            public DIS_KAPI DIS_KAPI = new DIS_KAPI();
            public IC_KAPI IC_KAPI = new IC_KAPI();
            public ILCE_KODU ILCE_KODU = new ILCE_KODU(); //skrs
            public IL_KODU IL_KODU = new IL_KODU();//skrs
            public KOY_KODU KOY_KODU = new KOY_KODU();
            public MAHALLE_KODU MAHALLE_KODU = new MAHALLE_KODU();
           
           
         
        }
        public class RISKLI_TEMAS_TIPI_BILGISI
        {
            public RISKLI_TEMAS_TIPI RISKLI_TEMAS_TIPI;
        }

        public class KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI
        {
            public KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI;
        }

        public class BILDIRIM_ADRES_BILGISI
        {
            public ADRES_TIPI ADRES_TIPI;
            public BUCAK_KODU BUCAK_KODU;
            public CSBM_KODU CSBM_KODU;
            public DIS_KAPI DIS_KAPI;
            public IC_KAPI IC_KAPI;
            public ILCE_KODU ILCE_KODU;
            public IL_KODU IL_KODU;
            public KOY_KODU KOY_KODU;
            public MAHALLE_KODU MAHALLE_KODU;
        }

        public class TELEFON_BILGISI
        {
            public TELEFON_TIPI TELEFON_TIPI;
            public TELEFON_NUMARASI TELEFON_NUMARASI;
        }

        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                KuduzRiskliTemasVeriSeti kuduzRiskliTemasVeriSeti = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as KuduzRiskliTemasVeriSeti;
                if (kuduzRiskliTemasVeriSeti == null)
                    throw new Exception("'237' paketini göndermek için " + InternalObjectId + " ObjectId'li KuduzRiskliTemasVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                if (kuduzRiskliTemasVeriSeti.RiskliTemasTarihi != null)
                {
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.RISKLI_TEMAS_TARIHI = new RISKLI_TEMAS_TARIHI();
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.RISKLI_TEMAS_TARIHI.value = ((DateTime)kuduzRiskliTemasVeriSeti.RiskliTemasTarihi).ToString("yyyyMMddHHmm");
                }

                //Olayın gerçekleştiği adres

                if (kuduzRiskliTemasVeriSeti.KuduzRiskliTemasRiskTemTip != null)
                {
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.RISKLI_TEMAS_TIPI = new RISKLI_TEMAS_TIPI(kuduzRiskliTemasVeriSeti.KuduzRiskliTemasRiskTemTip[0].SKRSRiskliTemasTipi.KODU, kuduzRiskliTemasVeriSeti.KuduzRiskliTemasRiskTemTip[0].SKRSRiskliTemasTipi.ADI);
                }

                //Beyan adresi

                if (kuduzRiskliTemasVeriSeti.KuduzRiskliTemasPlanProfBi != null)
                {
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI = new List<KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI>();
                    foreach (KuduzRiskliTemasPlanProfBi planlananProfilaksi in kuduzRiskliTemasVeriSeti.KuduzRiskliTemasPlanProfBi)
                    {
                        KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI planlananProfilaksiBilgisi = new KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI();
                        planlananProfilaksiBilgisi.KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI = new KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI(planlananProfilaksi.SKRSKisiyePlanKuduzProfilaksi.KODU, planlananProfilaksi.SKRSKisiyePlanKuduzProfilaksi.ADI);
                        _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI.Add(planlananProfilaksiBilgisi);
                    }
                }


                if (kuduzRiskliTemasVeriSeti.SKRSRiskliTemasSebepOlHayvan != null)
                {
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.RISKLI_TEMASA_SEBEP_OLAN_HAYVAN = new List<RISKLI_TEMASA_SEBEP_OLAN_HAYVAN>();
                    RISKLI_TEMASA_SEBEP_OLAN_HAYVAN sebepOlanHayvan = new RISKLI_TEMASA_SEBEP_OLAN_HAYVAN(kuduzRiskliTemasVeriSeti.SKRSRiskliTemasSebepOlHayvan.KODU, kuduzRiskliTemasVeriSeti.SKRSRiskliTemasSebepOlHayvan.ADI);
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.RISKLI_TEMASA_SEBEP_OLAN_HAYVAN.Add(sebepOlanHayvan);
                }

                if (kuduzRiskliTemasVeriSeti.KuduzRiskliTemasTelefon != null)
                {
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.TELEFON_BILGISI = new List<TELEFON_BILGISI>();
                    foreach (KuduzRiskliTemasTelefon riskliTemasTelefon in kuduzRiskliTemasVeriSeti.KuduzRiskliTemasTelefon)
                    {
                        TELEFON_BILGISI telefonBilgisi = new TELEFON_BILGISI();
                        telefonBilgisi.TELEFON_TIPI = new TELEFON_TIPI(riskliTemasTelefon.SKRSTelefonTipi.KODU, riskliTemasTelefon.SKRSTelefonTipi.ADI);
                        telefonBilgisi.TELEFON_NUMARASI = new TELEFON_NUMARASI();
                        telefonBilgisi.TELEFON_NUMARASI.value = riskliTemasTelefon.TelefonNumarasi;
                        _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.TELEFON_BILGISI.Add(telefonBilgisi);
                    }
                }

        

                if (kuduzRiskliTemasVeriSeti.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = kuduzRiskliTemasVeriSeti.SubEpisode.SYSTakipNo;

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }

        public static SYSMessage GetDummy()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                KuduzRiskliTemasVeriSeti kuduzRiskliTemasVeriSeti = objectContext.GetObject(new Guid("165f4805-d236-4cd6-b5b2-388aea45008c"), "KUDUZRISKLITEMASVERISETI") as KuduzRiskliTemasVeriSeti;
                if (kuduzRiskliTemasVeriSeti == null)
                    throw new Exception("'237' paketini göndermek için " + "b74dce0a-36ca-4f29-b2d1-efce79446672" + " ObjectId'li KuduzRiskliTemasVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                if (kuduzRiskliTemasVeriSeti.RiskliTemasTarihi != null)
                {
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.RISKLI_TEMAS_TARIHI = new RISKLI_TEMAS_TARIHI();
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.RISKLI_TEMAS_TARIHI.value = ((DateTime)kuduzRiskliTemasVeriSeti.RiskliTemasTarihi).ToString("yyyyMMddHHmm");
                }

                //Olayın gerçekleştiği adres

                if (kuduzRiskliTemasVeriSeti.KuduzRiskliTemasRiskTemTip != null)
                {
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.RISKLI_TEMAS_TIPI = new RISKLI_TEMAS_TIPI(kuduzRiskliTemasVeriSeti.KuduzRiskliTemasRiskTemTip[0].SKRSRiskliTemasTipi.KODU, kuduzRiskliTemasVeriSeti.KuduzRiskliTemasRiskTemTip[0].SKRSRiskliTemasTipi.ADI);
                }

                //Beyan adresi

                if (kuduzRiskliTemasVeriSeti.KuduzRiskliTemasPlanProfBi != null)
                {
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI = new List<KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI>();
                    foreach (KuduzRiskliTemasPlanProfBi planlananProfilaksi in kuduzRiskliTemasVeriSeti.KuduzRiskliTemasPlanProfBi)
                    {
                        KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI planlananProfilaksiBilgisi = new KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI();
                        planlananProfilaksiBilgisi.KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI = new KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI(planlananProfilaksi.SKRSKisiyePlanKuduzProfilaksi.KODU, planlananProfilaksi.SKRSKisiyePlanKuduzProfilaksi.ADI);
                        _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI_BILGISI.Add(planlananProfilaksiBilgisi);
                    }
                }


                if (kuduzRiskliTemasVeriSeti.SKRSRiskliTemasSebepOlHayvan != null)
                {
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.RISKLI_TEMASA_SEBEP_OLAN_HAYVAN = new List<RISKLI_TEMASA_SEBEP_OLAN_HAYVAN>();
                    RISKLI_TEMASA_SEBEP_OLAN_HAYVAN sebepOlanHayvan = new RISKLI_TEMASA_SEBEP_OLAN_HAYVAN(kuduzRiskliTemasVeriSeti.SKRSRiskliTemasSebepOlHayvan.KODU, kuduzRiskliTemasVeriSeti.SKRSRiskliTemasSebepOlHayvan.ADI);
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.RISKLI_TEMASA_SEBEP_OLAN_HAYVAN.Add(sebepOlanHayvan);
                }

                if (kuduzRiskliTemasVeriSeti.KuduzRiskliTemasTelefon != null)
                {
                    _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.TELEFON_BILGISI = new List<TELEFON_BILGISI>();
                    foreach (KuduzRiskliTemasTelefon riskliTemasTelefon in kuduzRiskliTemasVeriSeti.KuduzRiskliTemasTelefon)
                    {
                        TELEFON_BILGISI telefonBilgisi = new TELEFON_BILGISI();
                        telefonBilgisi.TELEFON_TIPI = new TELEFON_TIPI(riskliTemasTelefon.SKRSTelefonTipi.KODU, riskliTemasTelefon.SKRSTelefonTipi.ADI);
                        telefonBilgisi.TELEFON_NUMARASI = new TELEFON_NUMARASI();
                        telefonBilgisi.TELEFON_NUMARASI.value = riskliTemasTelefon.TelefonNumarasi;
                        _recordData.KUDUZ_RISKLI_TEMAS_BILDIRIM.TELEFON_BILGISI.Add(telefonBilgisi);
                    }
                }



                if (kuduzRiskliTemasVeriSeti.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = kuduzRiskliTemasVeriSeti.SubEpisode.SYSTakipNo;

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }
    }
}
