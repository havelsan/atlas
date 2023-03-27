using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;
using TTObjectClasses;

namespace TTObjectClasses
{
    public class ENabiz203_AgizVeDisSagligiVeriSeti
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
                messageType.code = "203";
                messageType.value = "Agiz ve Dis Sagligi Veri Seti";
            }

        }

        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public AGIZ_DIS_SAGLISI AGIZ_DIS_SAGLISI = new AGIZ_DIS_SAGLISI();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class AGIZ_DIS_SAGLISI
        {
            [System.Xml.Serialization.XmlElement("DIS_MUDAHALE_BILGISI", Type = typeof(DIS_MUDAHALE_BILGISI))]
            public List<DIS_MUDAHALE_BILGISI> DIS_MUDAHALE_BILGISI;
            [System.Xml.Serialization.XmlElement("MEVCUT_DIS_BILGISI", Type = typeof(MEVCUT_DIS_BILGISI))]
            public List<MEVCUT_DIS_BILGISI> MEVCUT_DIS_BILGISI;
        }

        public class DIS_MUDAHALE_BILGISI
        {
            public MUDAHALE MUDAHALE = new MUDAHALE(); //Skrs sut tablosundan
            public MUDAHALE_BASLANGIC_ZAMANI MUDAHALE_BASLANGIC_ZAMANI = new MUDAHALE_BASLANGIC_ZAMANI();
            public MUDAHALE_BITIS_ZAMANI MUDAHALE_BITIS_ZAMANI = new MUDAHALE_BITIS_ZAMANI();
            public TEDAVI_EDILEN_DISIN_KODU TEDAVI_EDILEN_DISIN_KODU = new TEDAVI_EDILEN_DISIN_KODU();
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
        }

        public class MEVCUT_DIS_BILGISI
        {
            public MEVCUT_DIS_DURUMU MEVCUT_DIS_DURUMU = new MEVCUT_DIS_DURUMU();
            public MEVCUT_DIS_KODU MEVCUT_DIS_KODU = new MEVCUT_DIS_KODU();

        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName)
        {
            recordData _recordData = new recordData();
            using (var objectContext = new TTObjectContext(false))
            {
                DentalExamination dentalExamination = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as DentalExamination;
                if (dentalExamination == null)
                    throw new Exception("'203' paketini göndermek için " + InternalObjectId + " ObjectId'li DentalExamination Objesi bulunamadı.");

                _recordData.AGIZ_DIS_SAGLISI = new AGIZ_DIS_SAGLISI();

                if (dentalExamination.DentalProcedures.Count > 0)
                {
                    _recordData.AGIZ_DIS_SAGLISI.DIS_MUDAHALE_BILGISI = new List<DIS_MUDAHALE_BILGISI>();

                    foreach (DentalProcedure dentalProcedure in dentalExamination.DentalProcedures)
                    {
                        if (dentalProcedure.CurrentStateDefID != DentalProcedure.States.Cancelled)
                        {
                            SKRSSUT mudahaleObj = (SKRSSUT)dentalProcedure.ProcedureObject.GetSKRSDefinition();
                            ToothNumberEnum toothNumber = (ToothNumberEnum)dentalProcedure.ToothNumber;
                            if (mudahaleObj != null && toothNumber != ToothNumberEnum.wholeJaw1 && toothNumber != ToothNumberEnum.anomalyTooth91
                                && toothNumber != ToothNumberEnum.anomalyTooth92 && toothNumber != ToothNumberEnum.anomalyTooth93 && toothNumber != ToothNumberEnum.anomalyTooth94)
                            {
                                DIS_MUDAHALE_BILGISI disMudahale = new DIS_MUDAHALE_BILGISI();
                                disMudahale.MUDAHALE = new MUDAHALE(mudahaleObj.KODU, mudahaleObj.ADI);
                                SKRSDisKodlari disKodu = (SKRSDisKodlari)BaseSKRSDefinition.GetByEnumValue("SKRSDisKodlari", ((int)dentalProcedure.ToothNumber));
                                disMudahale.TEDAVI_EDILEN_DISIN_KODU = new TEDAVI_EDILEN_DISIN_KODU(disKodu.KODU, disKodu.ADI);
                                disMudahale.ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
                                disMudahale.ISLEM_REFERANS_NUMARASI.value = dentalProcedure.ObjectID.ToString();
                                disMudahale.MUDAHALE_BASLANGIC_ZAMANI = new MUDAHALE_BASLANGIC_ZAMANI();
                                disMudahale.MUDAHALE_BASLANGIC_ZAMANI.value = ((DateTime)dentalProcedure.CreationDate).ToString("yyyyMMddHHmm");
                                disMudahale.MUDAHALE_BITIS_ZAMANI = new MUDAHALE_BITIS_ZAMANI();
                                disMudahale.MUDAHALE_BITIS_ZAMANI.value = ((DateTime)dentalProcedure.CreationDate).ToString("yyyyMMddHHmm");

                                _recordData.AGIZ_DIS_SAGLISI.DIS_MUDAHALE_BILGISI.Add(disMudahale);
                            }
                        }

                    }
                }

                if (dentalExamination.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = dentalExamination.SubEpisode.SYSTakipNo;

            }

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
