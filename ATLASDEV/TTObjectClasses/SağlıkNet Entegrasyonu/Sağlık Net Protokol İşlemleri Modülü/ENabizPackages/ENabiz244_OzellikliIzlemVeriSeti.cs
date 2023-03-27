using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz244_OzellikliIzlemVeriSeti
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
                messageType.code = "244";
                messageType.value = "Ozellikli Izlem Veri Seti (XXXXXX)";
            }

        }
        public class recordData
        {
            public OZELLIKLI_IZLEM_XXXXXX_BILGILERI OZELLIKLI_IZLEM_XXXXXX_BILGILERI = new OZELLIKLI_IZLEM_XXXXXX_BILGILERI();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();

        }

        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class OZELLIKLI_IZLEM_XXXXXX_BILGILERI
        {
            [System.Xml.Serialization.XmlElement("OZELLIKLI_IZLEM_BILGISI", Type = typeof(OZELLIKLI_IZLEM_BILGISI))]
            public List<OZELLIKLI_IZLEM_BILGISI> OZELLIKLI_IZLEM_BILGISI = new List<OZELLIKLI_IZLEM_BILGISI>();                       

        }

        public class OZELLIKLI_IZLEM_BILGISI
        {
            public YOGUN_BAKIMDA_MI YOGUN_BAKIMDA_MI;
            public XXXXXXDE_IZOLASYON_AMACLI_YATIS_MI XXXXXXDE_IZOLASYON_AMACLI_YATIS_MI;
            public XXXXXXDE_COVID_DISI_YATIS_MI XXXXXXDE_COVID_DISI_YATIS_MI;
            public KLINIK_BULGU_VAR_MI KLINIK_BULGU_VAR_MI;
            public BT_CEKILDI_MI BT_CEKILDI_MI;
            public IZLEM_NOTU IZLEM_NOTU;
            public PNOMONI_VAR_MI PNOMONI_VAR_MI;
            public PAO2_FIO2_ORANI PAO2_FIO2_ORANI;
            public BT_SONUCU BT_SONUCU;
            public IZLEM_YAPAN_HEKIM_KIMLIK_NUMARASI IZLEM_YAPAN_HEKIM_KIMLIK_NUMARASI;
            public IZLEM_YAPAN_HEKIM_TELEFON IZLEM_YAPAN_HEKIM_TELEFON;
            public IZLEM_TARIHI IZLEM_TARIHI;
            public ENTUBASYON_VAR_MI ENTUBASYON_VAR_MI;
            public IZLEM_REFERANS_NUMARASI IZLEM_REFERANS_NUMARASI;
            public GENEL_DURUM GENEL_DURUM;

            [System.Xml.Serialization.XmlElement("UYGULANAN_TEDAVI_BILGILERI", Type = typeof(UYGULANAN_TEDAVI_BILGILERI))]
            public List<UYGULANAN_TEDAVI_BILGILERI> UYGULANAN_TEDAVI_BILGILERI = new List<UYGULANAN_TEDAVI_BILGILERI>();
        }

        public class UYGULANAN_TEDAVI_BILGILERI
        {
            public YUKSEK_DOZ_C_VITAMINI YUKSEK_DOZ_C_VITAMINI;
            public HIDROKSIKLOROKIN HIDROKSIKLOROKIN;
            public KALETRA KALETRA;
            public OSELTAMIVIR_75GR_TANIFLU OSELTAMIVIR_75GR_TANIFLU;
            public AZITROMISIN AZITROMISIN;
            public FAVIPAVIR_AVIGAN FAVIPAVIR_AVIGAN;
        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            recordData _recordData = new recordData();

            using (var objectContext = new TTObjectContext(false))
            {

                OzellikliIzlemVeriSeti ozellikliIzlem = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as OzellikliIzlemVeriSeti;
                if (ozellikliIzlem != null)
                {
                    if (ozellikliIzlem.IsProgressDeleted != true)
                    {
                        OZELLIKLI_IZLEM_XXXXXX_BILGILERI OZELLIKLI_IZLEM_XXXXXX_BILGILERI = new OZELLIKLI_IZLEM_XXXXXX_BILGILERI();

                        OZELLIKLI_IZLEM_BILGISI OZELLIKLI_IZLEM_BILGISI = new OZELLIKLI_IZLEM_BILGISI();

                        if(ozellikliIzlem.IsIntensiveCare != null)
                        {
                            OZELLIKLI_IZLEM_BILGISI.YOGUN_BAKIMDA_MI = new YOGUN_BAKIMDA_MI(ozellikliIzlem.IsIntensiveCare.KODU, ozellikliIzlem.IsIntensiveCare.ADI);
                        }

                        if (ozellikliIzlem.IsIsolatedInpatient != null)
                        {
                            OZELLIKLI_IZLEM_BILGISI.XXXXXXDE_IZOLASYON_AMACLI_YATIS_MI = new XXXXXXDE_IZOLASYON_AMACLI_YATIS_MI(ozellikliIzlem.IsIsolatedInpatient.KODU, ozellikliIzlem.IsIsolatedInpatient.ADI);
                        }

                        if (ozellikliIzlem.NonCovidInpatient != null)
                        {
                            OZELLIKLI_IZLEM_BILGISI.XXXXXXDE_COVID_DISI_YATIS_MI = new XXXXXXDE_COVID_DISI_YATIS_MI(ozellikliIzlem.NonCovidInpatient.KODU, ozellikliIzlem.NonCovidInpatient.ADI);
                        }

                        if (ozellikliIzlem.HasClinicalFinding != null)
                        {
                            OZELLIKLI_IZLEM_BILGISI.KLINIK_BULGU_VAR_MI = new KLINIK_BULGU_VAR_MI(ozellikliIzlem.HasClinicalFinding.KODU, ozellikliIzlem.HasClinicalFinding.ADI);
                        }

                        if (ozellikliIzlem.HasCT != null)
                        {
                            OZELLIKLI_IZLEM_BILGISI.BT_CEKILDI_MI = new BT_CEKILDI_MI(ozellikliIzlem.HasCT.KODU, ozellikliIzlem.HasCT.ADI);
                        }

                        if (ozellikliIzlem.CTResult != null)
                        {
                            OZELLIKLI_IZLEM_BILGISI.BT_SONUCU = new BT_SONUCU(ozellikliIzlem.CTResult.KODU, ozellikliIzlem.CTResult.ADI);
                        }

                        if (ozellikliIzlem.HasPneumonia != null)
                        {
                            OZELLIKLI_IZLEM_BILGISI.PNOMONI_VAR_MI = new PNOMONI_VAR_MI(ozellikliIzlem.HasPneumonia.KODU, ozellikliIzlem.HasPneumonia.ADI);
                        }

                        if (ozellikliIzlem.HasIntubation != null)
                        {
                            OZELLIKLI_IZLEM_BILGISI.ENTUBASYON_VAR_MI = new ENTUBASYON_VAR_MI(ozellikliIzlem.HasIntubation.KODU, ozellikliIzlem.HasIntubation.ADI);
                        }

                        if (ozellikliIzlem.GeneralStatus != null)
                        {
                            OZELLIKLI_IZLEM_BILGISI.GENEL_DURUM = new GENEL_DURUM(ozellikliIzlem.GeneralStatus.KODU, ozellikliIzlem.GeneralStatus.ADI);
                        }


                        if (ozellikliIzlem.InPatientPhysicianProgresses != null)
                        {
                            OZELLIKLI_IZLEM_BILGISI.IZLEM_NOTU = new IZLEM_NOTU();
                            OZELLIKLI_IZLEM_BILGISI.IZLEM_NOTU.value = TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(ozellikliIzlem.InPatientPhysicianProgresses.Description.ToString());

                            OZELLIKLI_IZLEM_BILGISI.IZLEM_YAPAN_HEKIM_KIMLIK_NUMARASI = new IZLEM_YAPAN_HEKIM_KIMLIK_NUMARASI();
                            OZELLIKLI_IZLEM_BILGISI.IZLEM_YAPAN_HEKIM_KIMLIK_NUMARASI.value = ozellikliIzlem.InPatientPhysicianProgresses.ProcedureDoctor.UniqueNo;

                            OZELLIKLI_IZLEM_BILGISI.IZLEM_YAPAN_HEKIM_TELEFON = new IZLEM_YAPAN_HEKIM_TELEFON();
                            OZELLIKLI_IZLEM_BILGISI.IZLEM_YAPAN_HEKIM_TELEFON.value = ozellikliIzlem.InPatientPhysicianProgresses.ProcedureDoctor.PhoneNumber;

                            OZELLIKLI_IZLEM_BILGISI.IZLEM_TARIHI = new IZLEM_TARIHI();
                            OZELLIKLI_IZLEM_BILGISI.IZLEM_TARIHI.value = ozellikliIzlem.ProgressDate.Value.ToString("yyyyMMddHHmm");

                            OZELLIKLI_IZLEM_BILGISI.IZLEM_REFERANS_NUMARASI = new IZLEM_REFERANS_NUMARASI();
                            OZELLIKLI_IZLEM_BILGISI.IZLEM_REFERANS_NUMARASI.value = ozellikliIzlem.ObjectID.ToString();
                        }

                        OZELLIKLI_IZLEM_BILGISI.UYGULANAN_TEDAVI_BILGILERI = new List<UYGULANAN_TEDAVI_BILGILERI>();
                        UYGULANAN_TEDAVI_BILGILERI UYGULANAN_TEDAVI_BILGILERI = new UYGULANAN_TEDAVI_BILGILERI();

                        if (ozellikliIzlem.HighDoseCvitamin != null)
                        {
                            UYGULANAN_TEDAVI_BILGILERI.YUKSEK_DOZ_C_VITAMINI = new YUKSEK_DOZ_C_VITAMINI(ozellikliIzlem.HighDoseCvitamin.KODU, ozellikliIzlem.HighDoseCvitamin.ADI);
                        }

                        if (ozellikliIzlem.Hydroxychloroquine != null)
                        {
                            UYGULANAN_TEDAVI_BILGILERI.HIDROKSIKLOROKIN = new HIDROKSIKLOROKIN(ozellikliIzlem.Hydroxychloroquine.KODU, ozellikliIzlem.Hydroxychloroquine.ADI);
                        }
                        if (ozellikliIzlem.Kaletra != null)
                        {
                            UYGULANAN_TEDAVI_BILGILERI.KALETRA = new KALETRA(ozellikliIzlem.Kaletra.KODU, ozellikliIzlem.Kaletra.ADI);
                        }
                        if (ozellikliIzlem.Oseltamivir != null)
                        {
                            UYGULANAN_TEDAVI_BILGILERI.OSELTAMIVIR_75GR_TANIFLU = new OSELTAMIVIR_75GR_TANIFLU(ozellikliIzlem.Oseltamivir.KODU, ozellikliIzlem.Oseltamivir.ADI);
                        }
                        if (ozellikliIzlem.Azitromisin != null)
                        {
                            UYGULANAN_TEDAVI_BILGILERI.AZITROMISIN = new AZITROMISIN(ozellikliIzlem.Azitromisin.KODU, ozellikliIzlem.Azitromisin.ADI);
                        }
                        if (ozellikliIzlem.FavipavirAvigan != null)
                        {
                            UYGULANAN_TEDAVI_BILGILERI.FAVIPAVIR_AVIGAN = new FAVIPAVIR_AVIGAN(ozellikliIzlem.FavipavirAvigan.KODU, ozellikliIzlem.FavipavirAvigan.ADI);
                        }

                        OZELLIKLI_IZLEM_BILGISI.UYGULANAN_TEDAVI_BILGILERI.Add(UYGULANAN_TEDAVI_BILGILERI);
                        OZELLIKLI_IZLEM_XXXXXX_BILGILERI.OZELLIKLI_IZLEM_BILGISI.Add(OZELLIKLI_IZLEM_BILGISI);
                        _recordData.OZELLIKLI_IZLEM_XXXXXX_BILGILERI = OZELLIKLI_IZLEM_XXXXXX_BILGILERI;

                        if (ozellikliIzlem.SubEpisode.SYSTakipNo == null)
                            throw new Exception("SubEpisode a ait SYSTakipNo bulunamadı.");
                        else
                            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = ozellikliIzlem.SubEpisode.SYSTakipNo;
                    }
                    else
                        throw new Exception("OzellikliIzlemVeriSeti iptal edilmiş.");

                }
                else
                    throw new Exception("OzellikliIzlemVeriSeti Bulunamadı.");

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }
        }

    }
}
