using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz201_PatolojiKayit
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
                messageType.code = "201";
                messageType.value = "Patoloji Kayıt";
            }

        }
        public class recordData
        {

            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public HASTA_PATOLOJI_BILGILERI HASTA_PATOLOJI_BILGILERI = new HASTA_PATOLOJI_BILGILERI();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();

        }
        public class HASTA_PATOLOJI_BILGILERI
        {
            [System.Xml.Serialization.XmlElement("PATOLOJI_BILGISI", Type = typeof(PATOLOJI_BILGISI))]
            public List<PATOLOJI_BILGISI> PATOLOJI_BILGISI = new List<PATOLOJI_BILGISI>();
        }
        public class PATOLOJI_BILGISI
        {
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
            public ISTEM_ZAMANI ISTEM_ZAMANI = new ISTEM_ZAMANI();
            public ISTEM_YAPILAN_KLINIK ISTEM_YAPILAN_KLINIK = new ISTEM_YAPILAN_KLINIK();
            public ISTEM_YAPAN_HEKIM_KIMLIK_NUMARASI ISTEM_YAPAN_HEKIM_KIMLIK_NUMARASI = new ISTEM_YAPAN_HEKIM_KIMLIK_NUMARASI();
            public RAPORLAMA_ZAMANI RAPORLAMA_ZAMANI = new RAPORLAMA_ZAMANI();
            public RAPORLAYAN_HEKIM_KIMLIK_NUMARASI RAPORLAYAN_HEKIM_KIMLIK_NUMARASI = new RAPORLAYAN_HEKIM_KIMLIK_NUMARASI();
            public NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI = new NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI();
            public NUMUNE_ALINMA_SEKLI NUMUNE_ALINMA_SEKLI = new NUMUNE_ALINMA_SEKLI();
            public PREPARAT_DURUMU PREPARAT_DURUMU = new PREPARAT_DURUMU();
            public YERLESIM_YERI YERLESIM_YERI = new YERLESIM_YERI();
            public MORFOLOJI_KODU MORFOLOJI_KODU = new MORFOLOJI_KODU();
            public TETKIK_SONUCU TETKIK_SONUCU = new TETKIK_SONUCU();

        }
        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName)
        {
            //InternalObjectGuid Patoloji objesinin objecti
            recordData _recordData = new recordData();

            TTObjectContext objectContext = new TTObjectContext(true);

            Pathology pathologyObject = (Pathology)objectContext.GetObject(InternalObjectGuid, InternalObjectDefName);

            _recordData.HASTA_PATOLOJI_BILGILERI.PATOLOJI_BILGISI = new List<PATOLOJI_BILGISI>();

            if (pathologyObject.SubEpisode.SYSTakipNo == null)
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = pathologyObject.SubEpisode.SYSTakipNo;

            if (pathologyObject != null)
            {
                foreach (PathologyTestProcedure testProcedure in pathologyObject.PathologyTestProcedures)
                {
                    if (testProcedure.CurrentStateDefID != PathologyTestProcedure.States.Cancelled)
                    {
                        PATOLOJI_BILGISI PATOLOJI_BILGISI = new PATOLOJI_BILGISI();
                        PATOLOJI_BILGISI.ISLEM_REFERANS_NUMARASI.value = testProcedure.ObjectID.ToString();
                        PATOLOJI_BILGISI.ISTEM_ZAMANI.value = testProcedure.CreationDate.Value.ToString("yyyyMMddHHmm");

                        TTObjectClasses.SpecialityDefinition Speciality;
                        string resBrans = testProcedure.EpisodeAction.GetBranchCodeForMedula();
                        if (resBrans != null)
                        {
                            IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
                            if (specialtyList.Count > 0)
                                Speciality = (SpecialityDefinition)specialtyList[0];
                            else
                                throw new Exception(TTUtils.CultureService.GetText("M25977", "Hizmetin verildiği uzmanlık dalı kodu bulunamadı."));

                            if (Speciality.SKRSKlinik != null)
                                PATOLOJI_BILGISI.ISTEM_YAPILAN_KLINIK = new ISTEM_YAPILAN_KLINIK(Speciality.SKRSKlinik.KODU, Speciality.SKRSKlinik.ADI);
                            else
                                throw new Exception("Hizmetin verildiği uzmanlık dalının SKRS Klinik kodu eşleşmesi bulunamadı.");
                        }


                        if (testProcedure.PathologyRequest != null)
                        {
                            if (testProcedure.PathologyRequest.RequestDoctor != null)
                            {
                                PATOLOJI_BILGISI.ISTEM_YAPAN_HEKIM_KIMLIK_NUMARASI.value = testProcedure.PathologyRequest.RequestDoctor.Person.UniqueRefNo.ToString();
                            }
                        }

                        if (testProcedure.Pathology.ReportDate != null)
                        {
                            PATOLOJI_BILGISI.RAPORLAMA_ZAMANI.value = testProcedure.Pathology.ReportDate.Value.ToString("yyyyMMddHHmm");
                        }


                        if (testProcedure.Pathology.ProcedureDoctor != null)
                        {
                            if (testProcedure.Pathology.ProcedureDoctor.Person != null)
                                PATOLOJI_BILGISI.RAPORLAYAN_HEKIM_KIMLIK_NUMARASI.value = (testProcedure.Pathology.ProcedureDoctor.Person.UniqueRefNo != null ?
                                                                                           testProcedure.Pathology.ProcedureDoctor.Person.UniqueRefNo.ToString() : string.Empty);
                            else
                                PATOLOJI_BILGISI.RAPORLAYAN_HEKIM_KIMLIK_NUMARASI.value = "";
                        }
                        else
                            PATOLOJI_BILGISI.RAPORLAYAN_HEKIM_KIMLIK_NUMARASI.value = "";

                        if (testProcedure.PathologyMaterial.AlindigiDokununTemelOzelligi != null)
                            PATOLOJI_BILGISI.NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI = new NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI(testProcedure.PathologyMaterial.AlindigiDokununTemelOzelligi.KODU,
                                                                                                                                       testProcedure.PathologyMaterial.AlindigiDokununTemelOzelligi.ADI);
                        if (testProcedure.PathologyMaterial.NumuneAlinmaSekli != null)
                            PATOLOJI_BILGISI.NUMUNE_ALINMA_SEKLI = new NUMUNE_ALINMA_SEKLI(testProcedure.PathologyMaterial.NumuneAlinmaSekli.KODU, testProcedure.PathologyMaterial.NumuneAlinmaSekli.ADI);
                        if (testProcedure.PathologyMaterial.PatolojiPreparatiDurumu != null)
                            PATOLOJI_BILGISI.PREPARAT_DURUMU = new PREPARAT_DURUMU(testProcedure.PathologyMaterial.PatolojiPreparatiDurumu.KODU, testProcedure.PathologyMaterial.PatolojiPreparatiDurumu.ADI);
                        if (testProcedure.PathologyMaterial.YerlesimYeri != null)
                            PATOLOJI_BILGISI.YERLESIM_YERI = new YERLESIM_YERI(testProcedure.PathologyMaterial.YerlesimYeri.SKRSKODU.Value.ToString(), testProcedure.PathologyMaterial.YerlesimYeri.KODTANIMI);
                        if (testProcedure.PathologyMaterial.MorfolojiKodu != null)
                            PATOLOJI_BILGISI.MORFOLOJI_KODU = new MORFOLOJI_KODU(testProcedure.PathologyMaterial.MorfolojiKodu.MORFOLOJIKOD, testProcedure.PathologyMaterial.MorfolojiKodu.MORFOLOJIKODTANIM);
                        if (testProcedure.PathologyMaterial.Macroscopy != null)
                            PATOLOJI_BILGISI.TETKIK_SONUCU.value = TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(testProcedure.PathologyMaterial.Macroscopy.ToString());//Common.CUCase(Common.GetTextOfRTFString(testProcedure.PathologyMaterial.Macroscopy.ToString()), false, false);
                        else if (testProcedure.PathologyMaterial.Microscopy != null)
                            PATOLOJI_BILGISI.TETKIK_SONUCU.value = TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(testProcedure.PathologyMaterial.Microscopy.ToString());//Common.CUCase(Common.GetTextOfRTFString(testProcedure.PathologyMaterial.Microscopy.ToString()), false, false);
                        else
                            PATOLOJI_BILGISI.TETKIK_SONUCU.value = "";

                        _recordData.HASTA_PATOLOJI_BILGILERI.PATOLOJI_BILGISI.Add(PATOLOJI_BILGISI);
                    }
                }
            }
            
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }


    }
}
