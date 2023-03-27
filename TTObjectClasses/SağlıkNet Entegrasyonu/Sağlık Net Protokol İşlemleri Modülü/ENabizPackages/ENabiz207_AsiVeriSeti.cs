using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz207_AsiVeriSeti
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
                messageType.code = "207";
                messageType.value = "Asi Veri Seti";
            }

        }

        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public ASI_VERI_SETI ASI_VERI_SETI = new ASI_VERI_SETI();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class ASI_VERI_SETI
        {

            [XmlElement("ASI_BILGISI", Type = typeof(ASI_BILGISI))]
            public List<ASI_BILGISI> ASI_BILGISI;
        }

        public class ASI_BILGISI
        {
            public IZLEMIN_YAPILDIGI_YER IZLEMIN_YAPILDIGI_YER;
            public ASI_OZEL_DURUM_NEDENI ASI_OZEL_DURUM_NEDENI;
            public ASI ASI;
            public ASI_DOZU ASI_DOZU;
            public ASININ_UYGULAMA_SEKLI ASININ_UYGULAMA_SEKLI;
            public ASININ_UYGULAMA_YERI ASININ_UYGULAMA_YERI;
            public ASI_SORGU_NUMARASI ASI_SORGU_NUMARASI = new ASI_SORGU_NUMARASI();
            public ISLEM_YAPAN ISLEM_YAPAN;
            public ASI_ISLEM_TURU ASI_ISLEM_TURU = new ASI_ISLEM_TURU();
            public BILGI_ALINAN_KISI_ADI_SOYADI BILGI_ALINAN_KISI_ADI_SOYADI;
            public BILGI_ALINAN_KISI_TEL BILGI_ALINAN_KISI_TEL;
            public ASI_YAPILMA_ZAMANI ASI_YAPILMA_ZAMANI;
          
       

        }


        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName)
        {
            //InternalObjectGuid bu obje vaccinedetails in IDsi
            TTObjectContext objectContext = new TTObjectContext(true);

            recordData _recordData = new recordData();

            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }


            VaccineDetails vaccine = (VaccineDetails)objectContext.GetObject(InternalObjectGuid, InternalObjectDefName);
            if (vaccine != null)
            {
                if (vaccine.VaccineFollowUp.SubEpisode.SYSTakipNo == null)      //SYSTakipNo
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = vaccine.VaccineFollowUp.SubEpisode.SYSTakipNo;


                _recordData.ASI_VERI_SETI = new ASI_VERI_SETI();


          


                ASI_BILGISI ASI_BILGISI = new ASI_BILGISI();
                
                if (vaccine.SKRSAsiKodu != null)
                    ASI_BILGISI.ASI = new ASI(vaccine.SKRSAsiKodu.KODU.ToString(), vaccine.SKRSAsiKodu.ADI);
                if (vaccine.SKRSAsininDozu != null)
                {
                    ASI_BILGISI.ASI_DOZU = new ASI_DOZU(vaccine.SKRSAsininDozu.KODU, vaccine.SKRSAsininDozu.ADI);
                    if(vaccine.SKRSAsininDozu.KODU == "9")
                    {
                        if (vaccine.SKRSAsiOzelDurumNedeni != null)
                            ASI_BILGISI.ASI_OZEL_DURUM_NEDENI = new ASI_OZEL_DURUM_NEDENI(vaccine.SKRSAsiOzelDurumNedeni.KODU, vaccine.SKRSAsiOzelDurumNedeni.ADI);
                    }
                }
                if (vaccine.SKRSAsininUygulamaSekli != null)
                    ASI_BILGISI.ASININ_UYGULAMA_SEKLI = new ASININ_UYGULAMA_SEKLI(vaccine.SKRSAsininUygulamaSekli.KODU, vaccine.SKRSAsininUygulamaSekli.ADI);
                if (vaccine.SKRSAsiUygulamaYeri != null)
                    ASI_BILGISI.ASININ_UYGULAMA_YERI = new ASININ_UYGULAMA_YERI(vaccine.SKRSAsiUygulamaYeri.KODU, vaccine.SKRSAsiUygulamaYeri.ADI);

                ASI_BILGISI.ASI_SORGU_NUMARASI.value = vaccine.SorguNumarasi;


                ASI_BILGISI.ASI_ISLEM_TURU = new ASI_ISLEM_TURU(vaccine.SKRSASIISLEMTURU.KODU, vaccine.SKRSASIISLEMTURU.ADI);
                if (vaccine.SKRSASIISLEMTURU.KODU == "1")
                    ASI_BILGISI.IZLEMIN_YAPILDIGI_YER = new IZLEMIN_YAPILDIGI_YER(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI); //Kurum
                else
                    ASI_BILGISI.IZLEMIN_YAPILDIGI_YER = new IZLEMIN_YAPILDIGI_YER(vaccine.SKRSKurumlar.KODU.ToString(), vaccine.SKRSKurumlar.ADI);

                if (vaccine.ResponsibleNurse.Person.UniqueRefNo != null)
                {
                    ASI_BILGISI.ISLEM_YAPAN = new ISLEM_YAPAN();
                    ASI_BILGISI.ISLEM_YAPAN.value = vaccine.ResponsibleDoctor.Person.UniqueRefNo.ToString();
                }

                ASI_BILGISI.BILGI_ALINAN_KISI_ADI_SOYADI = new BILGI_ALINAN_KISI_ADI_SOYADI();
                if (vaccine.BilgiAlinanKisiAdiSoyadi != null && vaccine.BilgiAlinanKisiAdiSoyadi != "")
                {
                   
                    ASI_BILGISI.BILGI_ALINAN_KISI_ADI_SOYADI.value = vaccine.BilgiAlinanKisiAdiSoyadi.ToString();
                }else
                {
                    ASI_BILGISI.BILGI_ALINAN_KISI_ADI_SOYADI.value = vaccine.Patient.FullName;
                }

                ASI_BILGISI.BILGI_ALINAN_KISI_TEL = new BILGI_ALINAN_KISI_TEL();
                if (vaccine.BilgiAlinanKisiTel != null && vaccine.BilgiAlinanKisiTel != "")
                {

                    ASI_BILGISI.BILGI_ALINAN_KISI_TEL.value = vaccine.BilgiAlinanKisiTel.ToString();
                }
                else if (vaccine.Patient.PatientAddress != null && vaccine.Patient.PatientAddress.MobilePhone != null)
                    ASI_BILGISI.BILGI_ALINAN_KISI_TEL.value = vaccine.Patient.PatientAddress.MobilePhone;
                else
                    ASI_BILGISI.BILGI_ALINAN_KISI_TEL.value = String.Empty;

                ASI_BILGISI.ASI_YAPILMA_ZAMANI = new ASI_YAPILMA_ZAMANI();
                if (vaccine.ApplicationDate.HasValue)
                    ASI_BILGISI.ASI_YAPILMA_ZAMANI.value = vaccine.ApplicationDate.Value.ToString("yyyyMMddHHmm");
                else if (vaccine.AppointmentDate.HasValue)
                    ASI_BILGISI.ASI_YAPILMA_ZAMANI.value = vaccine.AppointmentDate.Value.ToString("yyyyMMddHHmm");
                else
                    ASI_BILGISI.ASI_YAPILMA_ZAMANI.value = "";

                _recordData.ASI_VERI_SETI.ASI_BILGISI = new List<ASI_BILGISI>();
                _recordData.ASI_VERI_SETI.ASI_BILGISI.Add(ASI_BILGISI);

            }

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;

        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();
            //_recordData.ASI_VERI_SETI.ASI_ISLEM_TURU = new ASI_ISLEM_TURU("1", "GERÇEK ZAMANLI");
            //ASI_BILGISI ASI_BILGISI = new ASI_BILGISI();
            //ASI_BILGISI.ASI_OZEL_DURUM_NEDENI = new ASI_OZEL_DURUM_NEDENI("1", "KRONIK KALP HASTALIĞI");
            //ASI_BILGISI.ASI = new ASI("1", "BİVALAN OPA (ORAL POLİO AŞISI)");
            //ASI_BILGISI.ASI_DOZU = new ASI_DOZU("1", "AŞININ BİRİNCİ DOZU");
            //ASI_BILGISI.ASININ_UYGULAMA_SEKLI = new ASININ_UYGULAMA_SEKLI("3", "ORAL");
            //ASI_BILGISI.ASININ_UYGULAMA_YERI = new ASININ_UYGULAMA_YERI("1", "AĞIZ");
            //ASI_BILGISI.ASI_SORGU_NUMARASI.value = "5488556";

            //_recordData.ASI_VERI_SETI.ASI_BILGISI = new List<ASI_BILGISI>();
            //_recordData.ASI_VERI_SETI.ASI_BILGISI.Add(ASI_BILGISI);

            //_recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
