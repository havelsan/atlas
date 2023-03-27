using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz105_LaboratuvarSonucKayit
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
                messageType.code = "105";
                messageType.value = "Laboratuvar Sonuç Kayıt";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public TETKIK_SONUC_BILGILERI TETKIK_SONUC_BILGILERI = new TETKIK_SONUC_BILGILERI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();

        }
        public class TETKIK_SONUC_BILGILERI
        {
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI = new PAKETE_AIT_ISLEM_ZAMANI();
            [System.Xml.Serialization.XmlElement("TETKIK_BILGISI", Type = typeof(TETKIK_BILGISI))]
            public List<TETKIK_BILGISI> TETKIK_BILGISI = new List<TETKIK_BILGISI>();
        }
        public class TETKIK_BILGISI
        {
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
            public TETKIK_ORNEK_NUMARASI TETKIK_ORNEK_NUMARASI = new TETKIK_ORNEK_NUMARASI();
            public TETKIK_ORNEGININ_ALINDIGI_ZAMAN TETKIK_ORNEGININ_ALINDIGI_ZAMAN = new TETKIK_ORNEGININ_ALINDIGI_ZAMAN();
            public TETKIK_ORNEGININ_KABUL_ZAMANI TETKIK_ORNEGININ_KABUL_ZAMANI = new TETKIK_ORNEGININ_KABUL_ZAMANI();
            public TETKIK_SONUC_TARIHI TETKIK_SONUC_TARIHI = new TETKIK_SONUC_TARIHI();
            public TETKIK_SONUC_ONAY_TARIHI TETKIK_SONUC_ONAY_TARIHI = new TETKIK_SONUC_ONAY_TARIHI();
            public SONUC_DIS_ERISIM_BILGISI SONUC_DIS_ERISIM_BILGISI = new SONUC_DIS_ERISIM_BILGISI();

            [System.Xml.Serialization.XmlElement("TETKIK_SONUC_BILGISI", Type = typeof(TETKIK_SONUC_BILGISI))]
            public List<TETKIK_SONUC_BILGISI> TETKIK_SONUC_BILGISI = new List<TETKIK_SONUC_BILGISI>();
        }
        public class TETKIK_SONUC_BILGISI
        {
            public LOINC_KODU LOINC_KODU = new LOINC_KODU();
            public TETKIK_SONUC_PARAMETRE_ADI TETKIK_SONUC_PARAMETRE_ADI = new TETKIK_SONUC_PARAMETRE_ADI();
            public TETKIK_SONUCU TETKIK_SONUCU = new TETKIK_SONUCU();
            public TETKIK_SONUCU_BIRIMI TETKIK_SONUCU_BIRIMI = new TETKIK_SONUCU_BIRIMI();
            public TETKIK_SONUCU_REFERANS_DEGERI TETKIK_SONUCU_REFERANS_DEGERI = new TETKIK_SONUCU_REFERANS_DEGERI();
            public TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI = new TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI();
        }
        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName)
        {
            //InternalObjectGuid bu object için SubEpisodeID olacak
            recordData _recordData = new recordData();

            //internalobjectguid e subactionprocedure gelecek, secilerek bilgileri doldurulacak
            TTObjectContext objectContext = new TTObjectContext(false);

            LaboratoryProcedure labProc = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as LaboratoryProcedure;
            //SubActionProcedure sp = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as SubActionProcedure;
            if (labProc != null) {

                if (labProc.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = labProc.SubEpisode.SYSTakipNo;

                _recordData.TETKIK_SONUC_BILGILERI = new TETKIK_SONUC_BILGILERI();

                TETKIK_BILGISI TETKIK_BILGISI = new TETKIK_BILGISI();
                TETKIK_BILGISI.ISLEM_REFERANS_NUMARASI.value = labProc.ObjectID.ToString();
                TETKIK_BILGISI.TETKIK_ORNEK_NUMARASI.value = labProc.BarcodeId.ToString();
                TETKIK_BILGISI.TETKIK_ORNEGININ_ALINDIGI_ZAMAN.value = (labProc.SampleDate != null ? labProc.SampleDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                TETKIK_BILGISI.TETKIK_ORNEGININ_KABUL_ZAMANI.value = (labProc.SampleAcceptionDate != null ? labProc.SampleAcceptionDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                TETKIK_BILGISI.TETKIK_SONUC_TARIHI.value = (labProc.PerformedDate != null ? labProc.PerformedDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                TETKIK_BILGISI.TETKIK_SONUC_ONAY_TARIHI.value = (labProc.PerformedDate != null ? labProc.PerformedDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                TETKIK_BILGISI.SONUC_DIS_ERISIM_BILGISI.value = "";


                //alt testlerı varsa onların sonucları gonderılecek
                if (labProc.LaboratorySubProcedures.Count > 0)
                {
                    TETKIK_BILGISI.TETKIK_SONUC_BILGISI = new List<TETKIK_SONUC_BILGISI>();
                    for (int i = 0; i < labProc.LaboratorySubProcedures.Count; i++)
                    {
                        TETKIK_SONUC_BILGISI TETKIK_SONUC_BILGISI = new TETKIK_SONUC_BILGISI();
                        TETKIK_SONUC_BILGISI.LOINC_KODU.value = (labProc.LaboratorySubProcedures[i].ProcedureObject.SKRSLoincKodu != null ? labProc.LaboratorySubProcedures[i].ProcedureObject.SKRSLoincKodu.LOINCNUMARASI : string.Empty);
                        TETKIK_SONUC_BILGISI.TETKIK_SONUC_PARAMETRE_ADI.value = labProc.LaboratorySubProcedures[i].ProcedureObject.Name.ToString();

                        //TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = (labProc.LaboratorySubProcedures[i].Result != null ? labProc.LaboratorySubProcedures[i].Result : string.Empty);
                        //Kültür testlerinde alt tetkik Result alanı null gelebiliyor, o zaman ResultDescriptionda alanındaki değer gönderilmesi istendi.
                        if (!String.IsNullOrEmpty(labProc.LaboratorySubProcedures[i].Result))
                            TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = labProc.LaboratorySubProcedures[i].Result;
                        else
                        {
                            if (!String.IsNullOrEmpty(labProc.LaboratorySubProcedures[i].ResultDescription))
                                TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = labProc.LaboratorySubProcedures[i].ResultDescription;
                            else
                                TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = string.Empty;
                        }
                        
                        TETKIK_SONUC_BILGISI.TETKIK_SONUCU_BIRIMI.value = (labProc.LaboratorySubProcedures[i].Unit != null ? labProc.LaboratorySubProcedures[i].Unit : string.Empty);
                        TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGERI.value = (labProc.LaboratorySubProcedures[i].Reference != null ? labProc.LaboratorySubProcedures[i].Reference : string.Empty);

                        if (labProc.LaboratorySubProcedures[i].Warning != null)
                            if (labProc.LaboratorySubProcedures[i].Warning.Value == HighLowEnum.Normal)
                                TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI.value = "1";
                            else
                                TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI.value = "0";
                        else
                            TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI.value = "1";

                        TETKIK_BILGISI.TETKIK_SONUC_BILGISI.Add(TETKIK_SONUC_BILGISI);
                    }
                }
                else
                {

                    TETKIK_BILGISI.TETKIK_SONUC_BILGISI = new List<TETKIK_SONUC_BILGISI>();
                    TETKIK_SONUC_BILGISI TETKIK_SONUC_BILGISI = new TETKIK_SONUC_BILGISI();

                    TETKIK_SONUC_BILGISI.LOINC_KODU.value = (labProc.ProcedureObject.SKRSLoincKodu != null ? labProc.ProcedureObject.SKRSLoincKodu.LOINCNUMARASI : string.Empty);
                    TETKIK_SONUC_BILGISI.TETKIK_SONUC_PARAMETRE_ADI.value = labProc.ProcedureObject.Name.ToString();
                    //TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = (labProc.Result != null ? labProc.Result : string.Empty);
                    
                    //Kültür testlerinde Result alanı null gelebiliyor, o zaman ResultDescriptionda alanındaki değer gönderilmesi istendi.
                    if (!String.IsNullOrEmpty(labProc.Result))
                        TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = labProc.Result;
                    else
                    {
                        if (!String.IsNullOrEmpty(labProc.ResultDescription))
                            TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = labProc.ResultDescription;
                        else
                            TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = string.Empty;
                    }

                    TETKIK_SONUC_BILGISI.TETKIK_SONUCU_BIRIMI.value = (labProc.Unit != null ? labProc.Unit : string.Empty);
                    TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGERI.value = (labProc.Reference != null ? labProc.Reference : string.Empty);

                    if (labProc.Warning != null)
                        if (labProc.Warning.Value == HighLowEnum.Normal)
                            TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI.value = "1";
                        else
                            TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI.value = "0";
                    else
                        TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI.value = "1";

                    TETKIK_BILGISI.TETKIK_SONUC_BILGISI.Add(TETKIK_SONUC_BILGISI);
                }

                _recordData.TETKIK_SONUC_BILGILERI.TETKIK_BILGISI = new List<TETKIK_BILGISI>();
                _recordData.TETKIK_SONUC_BILGILERI.TETKIK_BILGISI.Add(TETKIK_BILGISI);
            }
            else
            {
                LaboratorySubProcedure labSubProc = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as LaboratorySubProcedure;
                if (labSubProc != null)
                {
                    if (labSubProc.SubEpisode.SYSTakipNo == null)
                        throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                    else
                        _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = labSubProc.SubEpisode.SYSTakipNo;

                    _recordData.TETKIK_SONUC_BILGILERI = new TETKIK_SONUC_BILGILERI();

                    TETKIK_BILGISI TETKIK_BILGISI = new TETKIK_BILGISI();
                    TETKIK_BILGISI.ISLEM_REFERANS_NUMARASI.value = labSubProc.ObjectID.ToString();
                    TETKIK_BILGISI.TETKIK_ORNEK_NUMARASI.value = labSubProc.LaboratoryProcedure.BarcodeId.ToString();
                    TETKIK_BILGISI.TETKIK_ORNEGININ_ALINDIGI_ZAMAN.value = (labSubProc.LaboratoryProcedure.SampleDate != null ? labSubProc.LaboratoryProcedure.SampleDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                    TETKIK_BILGISI.TETKIK_ORNEGININ_KABUL_ZAMANI.value = (labSubProc.LaboratoryProcedure.SampleAcceptionDate != null ? labSubProc.LaboratoryProcedure.SampleAcceptionDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                    TETKIK_BILGISI.TETKIK_SONUC_TARIHI.value = (labSubProc.LaboratoryProcedure.PerformedDate != null ? labSubProc.LaboratoryProcedure.PerformedDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                    TETKIK_BILGISI.TETKIK_SONUC_ONAY_TARIHI.value = (labSubProc.LaboratoryProcedure.PerformedDate != null ? labSubProc.LaboratoryProcedure.PerformedDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                    TETKIK_BILGISI.SONUC_DIS_ERISIM_BILGISI.value = "";

                    TETKIK_BILGISI.TETKIK_SONUC_BILGISI = new List<TETKIK_SONUC_BILGISI>();
                    TETKIK_SONUC_BILGISI TETKIK_SONUC_BILGISI = new TETKIK_SONUC_BILGISI();

                    TETKIK_SONUC_BILGISI.LOINC_KODU.value = (labSubProc.ProcedureObject.SKRSLoincKodu != null ? labSubProc.ProcedureObject.SKRSLoincKodu.LOINCNUMARASI : string.Empty);
                    TETKIK_SONUC_BILGISI.TETKIK_SONUC_PARAMETRE_ADI.value = labSubProc.ProcedureObject.Name.ToString();
                    
                    //TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = (labSubProc.Result != null ? labSubProc.Result : string.Empty);
                    //Kültür testlerinde alt tetkik Result alanı null gelebiliyor, o zaman ResultDescriptionda alanındaki değer gönderilmesi istendi.
                    if (!String.IsNullOrEmpty(labSubProc.Result))
                        TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = labSubProc.Result;
                    else
                    {
                        if (!String.IsNullOrEmpty(labSubProc.ResultDescription))
                            TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = labSubProc.ResultDescription;
                        else
                            TETKIK_SONUC_BILGISI.TETKIK_SONUCU.value = string.Empty;
                    }

                    TETKIK_SONUC_BILGISI.TETKIK_SONUCU_BIRIMI.value = (labSubProc.Unit != null ? labSubProc.Unit : string.Empty);
                    TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGERI.value = (labSubProc.Reference != null ? labSubProc.Reference : string.Empty);

                    if (labSubProc.Warning != null)
                        if (labSubProc.Warning.Value == HighLowEnum.Normal)
                            TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI.value = "1";
                        else
                            TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI.value = "0";
                    else
                        TETKIK_SONUC_BILGISI.TETKIK_SONUCU_REFERANS_DEGER_ARALIGINDA_MI.value = "1";

                    TETKIK_BILGISI.TETKIK_SONUC_BILGISI.Add(TETKIK_SONUC_BILGISI);
                    _recordData.TETKIK_SONUC_BILGILERI.TETKIK_BILGISI = new List<TETKIK_BILGISI>();
                    _recordData.TETKIK_SONUC_BILGILERI.TETKIK_BILGISI.Add(TETKIK_BILGISI);
                }
            }


            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;

        }

    }
}
