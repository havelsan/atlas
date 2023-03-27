using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz103_MuayeneBilgisiKayit
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
                messageType.code = "103";
                messageType.value = TTUtils.CultureService.GetText("M26542", "Muayene Bilgisi Kayıt");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI;
            public HASTA_RECETE_BILGILERI HASTA_RECETE_BILGILERI;
            public HASTA_RAPOR_BILGILERI HASTA_RAPOR_BILGILERI;
            public MUAYENE_BILGILERI MUAYENE_BILGILERI;

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();

        }
        public class HASTA_RECETE_BILGILERI
        {
            [System.Xml.Serialization.XmlElement("RECETE_BILGISI", Type = typeof(RECETE_BILGISI))]
            public List<RECETE_BILGISI> RECETE_BILGISI = new List<RECETE_BILGISI>();

        }
        public class RECETE_BILGISI
        {
            public RECETE_TARIHI RECETE_TARIHI = new RECETE_TARIHI();
            public RECETE_NUMARASI RECETE_NUMARASI = new RECETE_NUMARASI();
            public RECETE_TURU RECETE_TURU = new RECETE_TURU();
            public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();

            [System.Xml.Serialization.XmlElement("ILAC_BILGISI", Type = typeof(ILAC_BILGISI))]
            public List<ILAC_BILGISI> ILAC_BILGISI = new List<ILAC_BILGISI>();


        }
        public class ILAC_BILGISI
        {
            public ILAC_BARKODU ILAC_BARKODU = new ILAC_BARKODU();
            public ILAC_ADI ILAC_ADI = new ILAC_ADI();
            public KUTU_ADETI KUTU_ADETI = new KUTU_ADETI();
            public ILAC_KULLANIM_SEKLI ILAC_KULLANIM_SEKLI = new ILAC_KULLANIM_SEKLI();
            public ILAC_KULLANIM_SAYISI ILAC_KULLANIM_SAYISI = new ILAC_KULLANIM_SAYISI();
            public ILAC_KULLANIM_DOZU ILAC_KULLANIM_DOZU = new ILAC_KULLANIM_DOZU();
            public ILAC_KULLANIM_PERIYODU ILAC_KULLANIM_PERIYODU = new ILAC_KULLANIM_PERIYODU();
            public ILAC_KULLANIM_PERIYODU_BIRIMI ILAC_KULLANIM_PERIYODU_BIRIMI = new ILAC_KULLANIM_PERIYODU_BIRIMI();
            public ILAC_ACIKLAMA ILAC_ACIKLAMA = new ILAC_ACIKLAMA();

        }
        public class HASTA_RAPOR_BILGILERI
        {
            [System.Xml.Serialization.XmlElement("RAPOR_BILGISI", Type = typeof(RAPOR_BILGISI))]
            public List<RAPOR_BILGISI> RAPOR_BILGISI = new List<RAPOR_BILGISI>();
        }
        public class RAPOR_BILGISI
        {
            public RAPOR_TARIHI RAPOR_TARIHI = new RAPOR_TARIHI();
            public RAPOR_NUMARASI RAPOR_NUMARASI = new RAPOR_NUMARASI();
            public RAPOR_TURU RAPOR_TURU = new RAPOR_TURU();
            public RAPOR_BASLANGIC_TARIHI RAPOR_BASLANGIC_TARIHI = new RAPOR_BASLANGIC_TARIHI();
            public RAPOR_BITIS_TARIHI RAPOR_BITIS_TARIHI = new RAPOR_BITIS_TARIHI();
            public RAPOR_TAKIP_NUMARASI RAPOR_TAKIP_NUMARASI = new RAPOR_TAKIP_NUMARASI();
            public RAPOR_PDF_BILGISI RAPOR_PDF_BILGISI = new RAPOR_PDF_BILGISI();
            [System.Xml.Serialization.XmlElement("RAPOR_HEKIM_BILGISI", Type = typeof(RAPOR_HEKIM_BILGISI))]
            public List<RAPOR_HEKIM_BILGISI> RAPOR_HEKIM_BILGISI = new List<RAPOR_HEKIM_BILGISI>();
        }
        public class RAPOR_HEKIM_BILGISI
        {
            public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
        }
        public class MUAYENE_BILGILERI
        {
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI = new PAKETE_AIT_ISLEM_ZAMANI() ;
            public MUAYENE_BASLANGIC_TARIHI MUAYENE_BASLANGIC_TARIHI ;
            public MUAYENE_BITIS_TARIHI MUAYENE_BITIS_TARIHI  ;
            [System.Xml.Serialization.XmlElement("EPIKRIZ_BILGISI", Type = typeof(EPIKRIZ_BILGISI))]
            public List<EPIKRIZ_BILGISI> EPIKRIZ_BILGISI = new List<EPIKRIZ_BILGISI>();
            [System.Xml.Serialization.XmlElement("TANI_BILGISI", Type = typeof(TANI_BILGISI))]
            public List<TANI_BILGISI> TANI_BILGISI = new List<TANI_BILGISI>();
            public BOY_KILO_BILGILERI BOY_KILO_BILGILERI ;
        }

        public class BOY_KILO_BILGILERI
        {
            public BOY BOY = new BOY();
            public KILO KILO = new KILO();
        }
        public class EPIKRIZ_BILGISI
        {
            public EPIKRIZ_BILGISI_BASLIK EPIKRIZ_BILGISI_BASLIK = new EPIKRIZ_BILGISI_BASLIK();
            public EPIKRIZ_BILGISI_ACIKLAMA EPIKRIZ_BILGISI_ACIKLAMA = new EPIKRIZ_BILGISI_ACIKLAMA();
        }
        public class TANI_BILGISI
        {
            public TANI_TURU TANI_TURU = new TANI_TURU();
            public ICD10 ICD10 = new ICD10();
        }
        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName)
        {
            //InternalObjectGuid bu paket için SubEpisodedur
            TTObjectContext objectContext = new TTObjectContext(true);
            SubEpisode subEpisode = (SubEpisode)objectContext.GetObject(InternalObjectGuid, InternalObjectDefName);
            if (subEpisode == null)
                throw new Exception("'103' peketini göndermek için '" + InternalObjectGuid + "' ObjectId'li " + InternalObjectDefName + " Objesi bulunamadı");

            recordData _recordData = new recordData();

            //HASTA_TAKIP_BILGISI
            _recordData.HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = subEpisode.SYSTakipNo;

            //HASTA_RECETE_BILGILERI

            BindingList<OutPatientPrescription> OutPatientPrescriptionList = OutPatientPrescription.GetBySubEpisode(objectContext, subEpisode.ObjectID);
            BindingList<InpatientPrescription> InPatientPrescriptionList = InpatientPrescription.GetBySubEpisode(objectContext, subEpisode.ObjectID);
            if(OutPatientPrescriptionList.Count > 0 || InPatientPrescriptionList.Count > 0) //TODO yatan hasta reçetesi eklenince böyle olacak.
            //if (OutPatientPrescriptionList.Count > 0)
            {
                _recordData.HASTA_RECETE_BILGILERI = new HASTA_RECETE_BILGILERI();
                foreach (OutPatientPrescription outPatientPrescription in OutPatientPrescriptionList)
                {
                    RECETE_BILGISI RECETE_BILGISI = new RECETE_BILGISI();

                    RECETE_BILGISI.RECETE_TARIHI.value = outPatientPrescription.ActionDate.Value.ToString("yyyyMMddHHmm");
                    if (!(String.IsNullOrEmpty(outPatientPrescription.EReceteNo)) || outPatientPrescription.PrescriptionNO != null)
                        RECETE_BILGISI.RECETE_NUMARASI.value = (String.IsNullOrEmpty(outPatientPrescription.EReceteNo) ? outPatientPrescription.PrescriptionNO : outPatientPrescription.EReceteNo);
                    else
                        RECETE_BILGISI.RECETE_NUMARASI.value = outPatientPrescription.ID.ToString();

                    BaseSKRSDefinition _SKRSReceteTuru = null;
                    if (outPatientPrescription.PrescriptionType != null)
                        _SKRSReceteTuru = SKRSReceteTuru.GetByEnumValue("SKRSReceteTuru", Convert.ToInt16(outPatientPrescription.PrescriptionType.Value));
                    if (_SKRSReceteTuru != null)
                        RECETE_BILGISI.RECETE_TURU = new RECETE_TURU(((SKRSReceteTuru)_SKRSReceteTuru).KODU, ((SKRSReceteTuru)_SKRSReceteTuru).ADI);
                    else
                        RECETE_BILGISI.RECETE_TURU = new RECETE_TURU("1", "NORMAL");

                    if (outPatientPrescription.ProcedureDoctor != null && outPatientPrescription.ProcedureDoctor.Person != null && outPatientPrescription.ProcedureDoctor.Person.UniqueRefNo != null)
                        RECETE_BILGISI.HEKIM_KIMLIK_NUMARASI.value = outPatientPrescription.ProcedureDoctor.Person.UniqueRefNo.ToString();

                    foreach (OutPatientDrugOrder outPatientDrugOrder in outPatientPrescription.OutPatientDrugOrders)
                    {
                        ILAC_BILGISI ILAC_BILGISI = new ILAC_BILGISI();
                        TerminologyManagerDef _SKRSIlac = outPatientDrugOrder.PhysicianDrug.GetSKRSDefinition();
                        if (_SKRSIlac != null)
                        {
                            ILAC_BILGISI.ILAC_BARKODU.value = ((SKRSIlac)_SKRSIlac).BARKODU;
                            ILAC_BILGISI.ILAC_ADI.value = ((SKRSIlac)_SKRSIlac).ADI;
                        }
                        else
                        {
                            ILAC_BILGISI.ILAC_BARKODU.value = outPatientDrugOrder.PhysicianDrug.Barcode;
                            ILAC_BILGISI.ILAC_ADI.value = outPatientDrugOrder.PhysicianDrug.Name;
                        }
                        ILAC_BILGISI.KUTU_ADETI.value = outPatientDrugOrder.PackageAmount != null ? outPatientDrugOrder.PackageAmount.ToString() : string.Empty;
                        BaseSKRSDefinition _SKRSIlacKullanimSekli = null;
                        if (outPatientDrugOrder.DrugUsageType.HasValue)
                            _SKRSIlacKullanimSekli = SKRSIlacKullanimSekli.GetByEnumValue("SKRSIlacKullanimSekli", Convert.ToInt16(outPatientDrugOrder.DrugUsageType.Value));
                        if (_SKRSIlacKullanimSekli != null)
                            ILAC_BILGISI.ILAC_KULLANIM_SEKLI = new ILAC_KULLANIM_SEKLI(((SKRSIlacKullanimSekli)_SKRSIlacKullanimSekli).KODU, ((SKRSIlacKullanimSekli)_SKRSIlacKullanimSekli).ADI);
                        else
                            ILAC_BILGISI.ILAC_KULLANIM_SEKLI = new ILAC_KULLANIM_SEKLI("1", "AĞIZDAN (ORAL)");

                        ILAC_BILGISI.ILAC_KULLANIM_SAYISI.value = outPatientDrugOrder.PackageAmount != null ? outPatientDrugOrder.PackageAmount.ToString() : string.Empty;//TODO ??
                        ILAC_BILGISI.ILAC_KULLANIM_DOZU.value = outPatientDrugOrder.DoseAmount != null ? outPatientDrugOrder.DoseAmount.ToString() : string.Empty;
                        ILAC_BILGISI.ILAC_KULLANIM_PERIYODU.value = outPatientDrugOrder.Day != null ? outPatientDrugOrder.Day.ToString() : string.Empty;

                        BaseSKRSDefinition _SKRSIlacKullanimPeriyoduBirimi = null;
                        if (outPatientDrugOrder.PeriodUnitType.HasValue)
                            _SKRSIlacKullanimPeriyoduBirimi = SKRSIlacKullanimPeriyoduBirimi.GetByEnumValue("SKRSIlacKullanimPeriyoduBirimi", Convert.ToInt16(outPatientDrugOrder.PeriodUnitType.Value));
                        if (_SKRSIlacKullanimPeriyoduBirimi != null)
                            ILAC_BILGISI.ILAC_KULLANIM_PERIYODU_BIRIMI = new ILAC_KULLANIM_PERIYODU_BIRIMI(((SKRSIlacKullanimPeriyoduBirimi)_SKRSIlacKullanimPeriyoduBirimi).KODU, ((SKRSIlacKullanimPeriyoduBirimi)_SKRSIlacKullanimPeriyoduBirimi).ADI);
                        else
                            ILAC_BILGISI.ILAC_KULLANIM_PERIYODU_BIRIMI = new ILAC_KULLANIM_PERIYODU_BIRIMI("5", "AY");

                        if (outPatientDrugOrder.Description != null)
                            ILAC_BILGISI.ILAC_ACIKLAMA.value = outPatientDrugOrder.Description;
                        RECETE_BILGISI.ILAC_BILGISI.Add(ILAC_BILGISI);
                    }

                    _recordData.HASTA_RECETE_BILGILERI.RECETE_BILGISI.Add(RECETE_BILGISI);
                }

                //Paketten sonra açılacak.Şimdilik kapatıldı.
                foreach (InpatientPrescription inPatientPrescription in InPatientPrescriptionList)
                {
                    RECETE_BILGISI RECETE_BILGISI = new RECETE_BILGISI();

                    RECETE_BILGISI.RECETE_TARIHI.value = inPatientPrescription.ActionDate.Value.ToString("yyyyMMddHHmm");
                    if (!(String.IsNullOrEmpty(inPatientPrescription.EReceteNo)) || inPatientPrescription.PrescriptionNO != null)
                        RECETE_BILGISI.RECETE_NUMARASI.value = (String.IsNullOrEmpty(inPatientPrescription.EReceteNo) ? inPatientPrescription.PrescriptionNO : inPatientPrescription.EReceteNo);
                    else
                        RECETE_BILGISI.RECETE_NUMARASI.value = inPatientPrescription.ID.ToString();

                    BaseSKRSDefinition _SKRSReceteTuru = null;
                    if (inPatientPrescription.PrescriptionType != null)
                        _SKRSReceteTuru = SKRSReceteTuru.GetByEnumValue("SKRSReceteTuru", Convert.ToInt16(inPatientPrescription.PrescriptionType.Value));
                    if (_SKRSReceteTuru != null)
                        RECETE_BILGISI.RECETE_TURU = new RECETE_TURU(((SKRSReceteTuru)_SKRSReceteTuru).KODU, ((SKRSReceteTuru)_SKRSReceteTuru).ADI);
                    else
                        RECETE_BILGISI.RECETE_TURU = new RECETE_TURU("1", "NORMAL");

                    if(inPatientPrescription.ProcedureDoctor != null && inPatientPrescription.ProcedureDoctor.Person != null && inPatientPrescription.ProcedureDoctor.Person.UniqueRefNo != null)
                        RECETE_BILGISI.HEKIM_KIMLIK_NUMARASI.value = inPatientPrescription.ProcedureDoctor.Person.UniqueRefNo.ToString();

                    foreach (InpatientDrugOrder inPatientDrugOrder in inPatientPrescription.InpatientDrugOrders)
                    {
                        ILAC_BILGISI ILAC_BILGISI = new ILAC_BILGISI();
                        TerminologyManagerDef _SKRSIlac = inPatientDrugOrder.Material.GetSKRSDefinition();
                        if (_SKRSIlac != null)
                        {
                            ILAC_BILGISI.ILAC_BARKODU.value = ((SKRSIlac)_SKRSIlac).BARKODU;
                            ILAC_BILGISI.ILAC_ADI.value = ((SKRSIlac)_SKRSIlac).ADI;
                        }
                        else
                        {
                            ILAC_BILGISI.ILAC_BARKODU.value = inPatientDrugOrder.Material.Barcode;
                            ILAC_BILGISI.ILAC_ADI.value = inPatientDrugOrder.Material.Name;
                        }
                        ILAC_BILGISI.KUTU_ADETI.value = inPatientDrugOrder.PackageAmount != null ? inPatientDrugOrder.PackageAmount.ToString() : string.Empty;

                        BaseSKRSDefinition sKRSIlacKullanimSekli = BaseSKRSDefinition.GetMyDefault("SKRSIlacKullanimSekli");
                        if(sKRSIlacKullanimSekli != null)
                            ILAC_BILGISI.ILAC_KULLANIM_SEKLI = new ILAC_KULLANIM_SEKLI(((SKRSIlacKullanimSekli)sKRSIlacKullanimSekli).KODU, ((SKRSIlacKullanimSekli)sKRSIlacKullanimSekli).ADI);
                        else
                            ILAC_BILGISI.ILAC_KULLANIM_SEKLI = new ILAC_KULLANIM_SEKLI("1", "AĞIZDAN (ORAL)");

                        ILAC_BILGISI.ILAC_KULLANIM_SAYISI.value = inPatientDrugOrder.PackageAmount != null ? inPatientDrugOrder.PackageAmount.ToString() : string.Empty;//TODO ??
                        ILAC_BILGISI.ILAC_KULLANIM_DOZU.value = inPatientDrugOrder.DoseAmount != null ? inPatientDrugOrder.DoseAmount.ToString() : string.Empty;
                        ILAC_BILGISI.ILAC_KULLANIM_PERIYODU.value = inPatientDrugOrder.Day != null ? inPatientDrugOrder.Day.ToString() : string.Empty;

                        BaseSKRSDefinition sKRSIlacKullanimPeriyoduBirimi = BaseSKRSDefinition.GetMyDefault("SKRSIlacKullanimPeriyoduBirimi");
                        if (sKRSIlacKullanimPeriyoduBirimi != null)
                            ILAC_BILGISI.ILAC_KULLANIM_PERIYODU_BIRIMI = new ILAC_KULLANIM_PERIYODU_BIRIMI(((SKRSIlacKullanimPeriyoduBirimi)sKRSIlacKullanimPeriyoduBirimi).KODU, ((SKRSIlacKullanimPeriyoduBirimi)sKRSIlacKullanimPeriyoduBirimi).ADI);
                        else
                            ILAC_BILGISI.ILAC_KULLANIM_PERIYODU_BIRIMI = new ILAC_KULLANIM_PERIYODU_BIRIMI("5", "AY");

                        if (inPatientDrugOrder.Description != null)
                            ILAC_BILGISI.ILAC_ACIKLAMA.value = inPatientDrugOrder.Description;
                        RECETE_BILGISI.ILAC_BILGISI.Add(ILAC_BILGISI);
                    }

                    _recordData.HASTA_RECETE_BILGILERI.RECETE_BILGISI.Add(RECETE_BILGISI);
                }
            }

            //HASTA_RAPOR_BILGILERI

            BindingList<ParticipatnFreeDrugReport> ParticipatnFreeDrugReportList = ParticipatnFreeDrugReport.GetCompletedBySubEpisode(objectContext, subEpisode.ObjectID);
            if (ParticipatnFreeDrugReportList.Count > 0)
            {
                foreach (ParticipatnFreeDrugReport participatnFreeDrugReport in ParticipatnFreeDrugReportList)
                {
                    RAPOR_BILGISI RAPOR_BILGISI = new RAPOR_BILGISI();
                    RAPOR_BILGISI.RAPOR_TARIHI.value = participatnFreeDrugReport.ActionDate.HasValue ? participatnFreeDrugReport.ActionDate.Value.ToString("yyyyMMddHHmm") : string.Empty;
                    RAPOR_BILGISI.RAPOR_NUMARASI.value = participatnFreeDrugReport.ID.Value.ToString();

                    BindingList<SKRSRaporTuru> SKRSRaporTuruList = SKRSRaporTuru.GetByKodu(objectContext, "10");
                    if (SKRSRaporTuruList.Count > 0)
                        RAPOR_BILGISI.RAPOR_TURU = new RAPOR_TURU(SKRSRaporTuruList[0].KODU, SKRSRaporTuruList[0].ADI);
                    else
                        RAPOR_BILGISI.RAPOR_TURU = new RAPOR_TURU("10", "İLAÇ KULLANIM");

                    RAPOR_BILGISI.RAPOR_BASLANGIC_TARIHI.value = participatnFreeDrugReport.ReportStartDate.HasValue ? participatnFreeDrugReport.ReportStartDate.Value.ToString("yyyyMMddHHmm") : string.Empty;
                    RAPOR_BILGISI.RAPOR_BITIS_TARIHI.value = participatnFreeDrugReport.ReportEndDate.HasValue ? participatnFreeDrugReport.ReportEndDate.Value.ToString("yyyyMMddHHmm") : string.Empty;
                    BindingList<MedulaReportResult> MedulaReportResultList = MedulaReportResult.GetByParticipatnFreeDrugReport(objectContext, participatnFreeDrugReport.ObjectID);
                    if (MedulaReportResultList.Count > 0)
                        RAPOR_BILGISI.RAPOR_TAKIP_NUMARASI.value = MedulaReportResultList[0].ReportChasingNo;
                    else
                        RAPOR_BILGISI.RAPOR_TAKIP_NUMARASI.value = "";
                    RAPOR_BILGISI.RAPOR_PDF_BILGISI.value = String.Empty;// ilaç raporları için yazılmıyormuş.
                    RAPOR_HEKIM_BILGISI RAPOR_HEKIM_BILGISI = new RAPOR_HEKIM_BILGISI();
                    if (participatnFreeDrugReport.ProcedureDoctor != null && participatnFreeDrugReport.ProcedureDoctor.Person != null && participatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo != null)
                        RAPOR_HEKIM_BILGISI.HEKIM_KIMLIK_NUMARASI.value = participatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.ToString();
                    RAPOR_BILGISI.RAPOR_HEKIM_BILGISI.Add(RAPOR_HEKIM_BILGISI);
                    if (participatnFreeDrugReport.SecondDoctor != null)
                    {
                        RAPOR_HEKIM_BILGISI RAPOR_HEKIM_BILGISI2 = new RAPOR_HEKIM_BILGISI();
                        if (participatnFreeDrugReport.SecondDoctor.Person != null && participatnFreeDrugReport.SecondDoctor.Person.UniqueRefNo != null)
                            RAPOR_HEKIM_BILGISI2.HEKIM_KIMLIK_NUMARASI.value = participatnFreeDrugReport.SecondDoctor.Person.UniqueRefNo.ToString();
                        RAPOR_BILGISI.RAPOR_HEKIM_BILGISI.Add(RAPOR_HEKIM_BILGISI2);
                    }
                    if (participatnFreeDrugReport.ThirdDoctor != null)
                    {
                        RAPOR_HEKIM_BILGISI RAPOR_HEKIM_BILGISI3 = new RAPOR_HEKIM_BILGISI();
                        if (participatnFreeDrugReport.ThirdDoctor.Person != null && participatnFreeDrugReport.ThirdDoctor.Person.UniqueRefNo != null)
                            RAPOR_HEKIM_BILGISI3.HEKIM_KIMLIK_NUMARASI.value = participatnFreeDrugReport.ThirdDoctor.Person.UniqueRefNo.ToString();
                        RAPOR_BILGISI.RAPOR_HEKIM_BILGISI.Add(RAPOR_HEKIM_BILGISI3);
                    }
                    _recordData.HASTA_RAPOR_BILGILERI = new HASTA_RAPOR_BILGILERI();
                    _recordData.HASTA_RAPOR_BILGILERI.RAPOR_BILGISI.Add(RAPOR_BILGISI);
                }

                //TODO BirthReport
                //TODO Unbound MedulaRaporIslemleri formundan yazılan raporlar için MedulaReportResults gibi bir tabloya kayıt atılması sağlanıp bu tablodakilerin gönderilmesi lazım.

            }

            //MUAYENE_BILGILERI
            if (subEpisode.Episode.PatientHistory != null || subEpisode.Episode.Complaint != null || subEpisode.Episode.PhysicalExamination != null || subEpisode.InPatientPhysicianProgresses.Count>0 ||  subEpisode.HasDiagnosis == true)
            {
                _recordData.MUAYENE_BILGILERI = new MUAYENE_BILGILERI();
                _recordData.MUAYENE_BILGILERI.PAKETE_AIT_ISLEM_ZAMANI.value = DateTime.Now.ToString("yyyyMMddHHmm");
                if (subEpisode.Episode.PatientHistory != null)
                {
                    EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
                    EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "HİKAYESİ";
                    EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = Common.GetTextOfRTFString(subEpisode.Episode.PatientHistory.ToString());
                    _recordData.MUAYENE_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
                }
                if (subEpisode.Episode.Complaint != null)
                {
                    EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
                    EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "ŞİKAYETİ";
                    EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = Common.GetTextOfRTFString(subEpisode.Episode.Complaint.ToString());
                    _recordData.MUAYENE_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
                }
                if (subEpisode.Episode.PhysicalExamination != null)
                {
                    EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
                    EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "FİZİK MUAYENESİ";
                    EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = Common.GetTextOfRTFString(subEpisode.Episode.PhysicalExamination.ToString());
                    _recordData.MUAYENE_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
                }

                foreach(var inPatientPhysicianProgress in  subEpisode.InPatientPhysicianProgresses)
                {
                    EPIKRIZ_BILGISI EPIKRIZ_BILGISI = new EPIKRIZ_BILGISI();
                    EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_BASLIK.value = "KLİNİK SEYİR";
                    EPIKRIZ_BILGISI.EPIKRIZ_BILGISI_ACIKLAMA.value = Common.GetTextOfRTFString(inPatientPhysicianProgress.Description.ToString());
                    _recordData.MUAYENE_BILGILERI.EPIKRIZ_BILGISI.Add(EPIKRIZ_BILGISI);
                }

                BindingList<DiagnosisGrid> subEpisodeDiagnosisList = DiagnosisGrid.GetDiagnosisBySubEpisode_OQ(objectContext, subEpisode.ObjectID.ToString());
                if (subEpisodeDiagnosisList.Count > 0)
                {
                    foreach (DiagnosisGrid dg in subEpisodeDiagnosisList)
                    {
                        TANI_BILGISI TANI_BILGISI = new TANI_BILGISI();
                        TerminologyManagerDef skrsDiagnose = dg.Diagnose.GetSKRSDefinition();
                        if (skrsDiagnose != null)
                        {
                     
                            TANI_BILGISI.ICD10 = new ICD10(((SKRSICD)skrsDiagnose).KODU, ((SKRSICD)skrsDiagnose).ADI);
                            if(dg.IsMainDiagnose == true)
                                TANI_BILGISI.TANI_TURU = new TANI_TURU("1", "ANA TANI");
                            else
                                TANI_BILGISI.TANI_TURU = new TANI_TURU("2", "EK TANI");
                            _recordData.MUAYENE_BILGILERI.TANI_BILGISI.Add(TANI_BILGISI);
                        }
                    }
                }
            }
            SYSMessage _SYSMessage = new SYSMessage();
            _SYSMessage.recordData = _recordData;
            return _SYSMessage;

        }
    }
}
