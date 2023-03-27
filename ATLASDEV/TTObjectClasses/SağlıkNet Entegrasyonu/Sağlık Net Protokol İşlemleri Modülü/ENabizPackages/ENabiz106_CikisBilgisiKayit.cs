using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTDefinitionManagement;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz106_CikisBilgisiKayit
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
                messageType.code = "106";
                messageType.value = "Çıkış Bilgisi Kayıt";
            }

        }
        public class recordData
        {
            public HASTA_CIKIS_BILGILERI HASTA_CIKIS_BILGILERI = new HASTA_CIKIS_BILGILERI();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }
        public class HASTA_CIKIS_BILGILERI
        {
            public CIKIS_ZAMANI CIKIS_ZAMANI = new CIKIS_ZAMANI();
            public CIKIS_SEKLI CIKIS_SEKLI = new CIKIS_SEKLI();
            public SEVK_NEDENI SEVK_NEDENI;
            public SEVK_TANISI SEVK_TANISI;
            public SEVK_EDILEN_POLI_KLINIK SEVK_EDILEN_POLI_KLINIK;
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI = new PAKETE_AIT_ISLEM_ZAMANI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName, DateTime? dischargeDate = null)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            SubEpisode subEpisode = (SubEpisode)objectContext.GetObject(InternalObjectId, InternalObjectDefName);
            if (subEpisode == null)
                throw new Exception("'106' paketini göndermek için " + InternalObjectId + " ObjectId'li SubEpisode Objesi bulunamadı");

            SYSMessage _SYSMessage = new SYSMessage();
            recordData _recordData = new recordData();

            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = subEpisode.SYSTakipNo;
            _recordData.HASTA_CIKIS_BILGILERI = new HASTA_CIKIS_BILGILERI();
            _recordData.HASTA_CIKIS_BILGILERI.PAKETE_AIT_ISLEM_ZAMANI.value = DateTime.Now.ToString("yyyyMMddHHmm"); 
            BindingList<TTObjectClasses.TreatmentDischarge> treatmentDischargeList = TTObjectClasses.TreatmentDischarge.GetTreatmentDischargeBySubEpisode(objectContext, subEpisode.ObjectID);

            if (dischargeDate != null)
            {
                var defaultCikisSekli = SKRSCikisSekli.GetByKodu(objectContext, "9")[0];//"YATİS DEVAM EDİYOR"
                _recordData.HASTA_CIKIS_BILGILERI.CIKIS_SEKLI = new CIKIS_SEKLI(defaultCikisSekli.KODU, defaultCikisSekli.ADI);
                _recordData.HASTA_CIKIS_BILGILERI.CIKIS_ZAMANI.value = dischargeDate.Value.ToString("yyyyMMddHHmm");

            }
            else
            {


                bool hasdischarge = false;
                if (treatmentDischargeList.Count > 0)// Yatan Hasta Taburcu
                {
                    foreach (TTObjectClasses.TreatmentDischarge trDis in treatmentDischargeList)
                    {
                        if ((!trDis.IsCancelled) && trDis.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                        {
                            hasdischarge = true;
                            _recordData.HASTA_CIKIS_BILGILERI.CIKIS_ZAMANI.value = subEpisode.ClosingDate != null ? subEpisode.ClosingDate.Value.ToString("yyyyMMddHHmm") : string.Empty;

                            if (trDis.DischargeType != null)
                            {
                                //var skrsCikisSekli = BaseSKRSDefinition.GetByEnumValue("SKRSCikisSekli", Convert.ToInt32(trDis.DischargeType));
                                //if (skrsCikisSekli != null)

                                _recordData.HASTA_CIKIS_BILGILERI.CIKIS_SEKLI = new CIKIS_SEKLI(trDis.DischargeType.SKRSCikisSekli.KODU, trDis.DischargeType.SKRSCikisSekli.ADI);
                            }
                            break;
                        }
                    }
                }

                if (!hasdischarge)
                {
                    var PatientExaminationList = subEpisode.PatientExaminations.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled && dr.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully && dr.ProcessEndDate != null).OrderByDescending(dr => dr.ProcessEndDate);
                    foreach (var pe in PatientExaminationList)
                    {
                        hasdischarge = true;
                        _recordData.HASTA_CIKIS_BILGILERI.CIKIS_ZAMANI.value = pe.ProcessEndDate.Value.ToString("yyyyMMddHHmm");
                        if (pe.TreatmentResult != null)
                            _recordData.HASTA_CIKIS_BILGILERI.CIKIS_SEKLI = new CIKIS_SEKLI(pe.TreatmentResult.KODU, pe.TreatmentResult.ADI);
                        else
                        {
                            var defaultCikisSekli = SKRSCikisSekli.GetByKodu(objectContext, "8")[0];//HALİYLE ÇIKIŞ/TABURCU
                            _recordData.HASTA_CIKIS_BILGILERI.CIKIS_SEKLI = new CIKIS_SEKLI(defaultCikisSekli.KODU, defaultCikisSekli.ADI);
                        }


                        break;
                    }
                }
                if (!hasdischarge)
                {
                    return null;


                }
            }

            _SYSMessage.recordData = _recordData;

            return _SYSMessage;
        }
    }
}
