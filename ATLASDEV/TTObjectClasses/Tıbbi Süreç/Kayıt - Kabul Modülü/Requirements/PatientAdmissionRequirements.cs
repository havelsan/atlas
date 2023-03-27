using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTUtils.RequirementManager;
using TTInstanceManagement;

namespace TTObjectClasses.Tıbbi_Süreç.Kayıt___Kabul_Modülü.Requirements
{
    public class PatientAdmissionRequirements : TTObject, IRequirement
    {
        PatientAdmission patientAdmission = null;
        Patient patient = null;
        int activeTab = 1;
        public PatientAdmissionRequirements(PatientAdmission patientAdmissionParam, Patient patientParam,int activeTabParam)
        {
            patientAdmission = patientAdmissionParam;
            patient = patientParam;
            activeTab = activeTabParam;
        }

        public RequirementResultCode ExecuteRequirement()
        {
            RequirementResultCode requirementResultCode = new RequirementResultCode();
            requirementResultCode.resultCode = 0;
            requirementResultCode.resultMessage = "Success";

            if (patientAdmission == null)
            {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M26281", "Kayıt için gerekli alanları doldurunuz.");
                return requirementResultCode;

            }

            if ((patient.UnIdentified == false || patient.UnIdentified == null ) && patient.Death != true && (patientAdmission.IsNewBorn == false || patientAdmission.IsNewBorn == null) && patient.Privacy != true)
            {
                if (patientAdmission.Payer == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M26355", "Kurum alanı boş bırakılamaz.");
                    return requirementResultCode;
                }

                if (patient.UniqueRefNo == null && patient.Nationality.Kodu == "TR" && patient.PassportNo != null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = "TC Kimlik No alanı boş bırakılamaz.";
                    return requirementResultCode;
                }
                if (patient.PassportNo == null && patient.Nationality.Kodu != "TR" && patient.UniqueRefNo == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M26684", "Pasaport No alanı boş bırakılamaz.");
                    return requirementResultCode;
                }
                if (patient.Nationality.Kodu != "TR" && patient.SKRSYabanciHasta == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M27201", "Yabancı Hasta Türü alanı boş bırakılamaz.");
                    return requirementResultCode;
                }
            }
            else
            {
                #region ücretsiz parametresi
                /*string unpaidPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("UNPAIDPAYERDEFINITION ", "c012e0e5-d8ed-4692-8e74-d1155d3a4f8e");

                PayerDefinition unpaidPayer = this.patientAdmission.ObjectContext.GetObject(new Guid(unpaidPayerObjectID), typeof(PayerDefinition)) as PayerDefinition;

                if (unpaidPayer == null)
                    throw new Exception("Ücretsiz hastalar kurumu bulunamadı.Sistem parametrelerini kontrol ediniz.(Bknz: UNPAIDPAYERDEFINITION )");

                ProtocolDefinition unpaidProtocol = unpaidPayer.GetProtocol(this.patient, SigortaliTuru.GetSigortaliTuru("4"));

                if (unpaidProtocol == null)
                    throw new Exception("Ücretsiz hastalar kurumuna ait bir anlaşma bulunamadı.Anlaşma tanımlarını kontrol ediniz.");
                */
                #endregion 

                #region sgk parametresi
                //string sgkPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("SGKPAYERDEFINITION", "ef3e2dc7-2ae8-4603-b199-ec4600267856");

                //PayerDefinition sgkPayer = patientAdmission.ObjectContext.GetObject(new Guid(sgkPayerObjectID), typeof(PayerDefinition)) as PayerDefinition;

                //if (sgkPayer == null)
                //    throw new Exception(TTUtils.CultureService.GetText("M26866", "SGK hastalar kurumu bulunamadı.Sistem parametrelerini kontrol ediniz.(Bknz: SGKPAYERDEFINITION )"));

                //ProtocolDefinition sgkProtocol = sgkPayer.GetProtocol(patient, SigortaliTuru.GetSigortaliTuru("1"));

                //if (sgkProtocol == null)
                //    throw new Exception(TTUtils.CultureService.GetText("M26867", "SGK hastalar kurumuna ait bir anlaşma bulunamadı.Anlaşma tanımlarını kontrol ediniz."));

                //patientAdmission.Payer = sgkPayer;
                //patientAdmission.Protocol = sgkProtocol;
                #endregion
            }


            if (patientAdmission.AdmissionType == null)
            {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25697", "Geliş sebebi alanı boş bırakılamaz.");
                return requirementResultCode;
            }

            if (patientAdmission.SEP != null)
            {
                if (patient.UnIdentified == false && patientAdmission.IsNewBorn == false && patientAdmission.IsNewBorn == false && patient.Death != true)
                {
                    if (patientAdmission.MedulaSigortaliTuru == null)
                    {
                        requirementResultCode.resultCode = 1;
                        requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25376", "Çalışma durumu alanı boş bırakılamaz.");
                        return requirementResultCode;
                    }

                }
                else
                {
                    patientAdmission.SEP.MedulaSigortaliTuru = SigortaliTuru.GetSigortaliTuru("4");
                    patientAdmission.MedulaSigortaliTuru = SigortaliTuru.GetSigortaliTuru("4");
                }

                if (patientAdmission.AdmissionType.provizyonTipiKodu == "T" && patientAdmission.SEP.MedulaPlakaNo == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25700", "Geliş sebebi 'Trafik Kazası' olan kabullerin Plaka No alanı boş bırakılamaz.");
                    return requirementResultCode;
                }
                else if (patientAdmission.AdmissionType.provizyonTipiKodu == "S" && patientAdmission.MedulaIstisnaiHal == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25698", "Geliş sebebi 'İstisnai Hal' olan kabullerin İstisnai Hal alanı boş bırakılamaz.");
                    return requirementResultCode;
                }
                else if (patientAdmission.AdmissionType.provizyonTipiKodu == "V" && patientAdmission.SKRSAdliVaka == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25696", "Geliş sebebi 'Adli Vaka' olan kabullerin Adli Vaka Geliş Şekli alanı boş bırakılamaz.");
                    return requirementResultCode;
                }
                if (patientAdmission.AdmissionType.provizyonTipiKodu == "T" && patientAdmission.MedulaVakaTarihi == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25701", "Geliş sebebi 'Trafik Kazası' olan kabullerin Vaka Tarihi alanı boş bırakılamaz.");
                    return requirementResultCode;
                }
                if (patientAdmission.AdmissionType.provizyonTipiKodu == "I" && patientAdmission.MedulaVakaTarihi == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25699", "Geliş sebebi 'iş Kazası' olan kabullerin Vaka Tarihi alanı boş bırakılamaz.");
                    return requirementResultCode;
                }
                if (patientAdmission.AdmissionType.provizyonTipiKodu == "V" && patientAdmission.MedulaVakaTarihi == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = "Geliş sebebi 'Adli Vaka' olan kabullerin Vaka Tarihi alanı boş bırakılamaz.";
                    return requirementResultCode;
                }

                if (patient.BirthDate > Common.RecTime())
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25516", "Doğum tarihi alanı bugünün tarihinden büyük olamaz.");
                    return requirementResultCode;
                }

            }

            if (patientAdmission.EmergencyIntervention != null)
            {
                if (patientAdmission.Sevkli112 == true && patientAdmission.Emergency112RefNo == null)
                {
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25078", "112 Sağlık Hizmetleri ile getirilen hastaların '112 Protokol numaraları' dolu olmalıdır.");
                    requirementResultCode.resultCode = 1;
                    return requirementResultCode;
                }

            }

            if (activeTab == 2)//sevk tabı
            {
                if(patientAdmission.Payer == null)
                {
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M26857", "Sevkli geldiği 'XXXXXX' bilgisini giriniz.");
                    requirementResultCode.resultCode = 1;
                    return requirementResultCode;
                }
                if (patientAdmission.Payer != null && patientAdmission.Payer.Type != null && patientAdmission.Payer.Type.PayerType != null && patientAdmission.Payer.Type.PayerType != PayerTypeEnum.Hospital)
                {
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M26857", "Sevkli geldiği 'XXXXXX' bilgisini giriniz.");
                    requirementResultCode.resultCode = 1;
                    return requirementResultCode;
                }
                if (patientAdmission.DispatchType == null)
                {
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M26856", "Sevk türünü seçiniz.");
                    requirementResultCode.resultCode = 1;
                    return requirementResultCode;
                }
                else
                {
                    if (patientAdmission.DispatchType == DispatchTypeEnum.Consultation && patientAdmission.DispatchedConsultationDef == null)
                    {
                        requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M26330", "Konsültasyon açıklamasını giriniz.");
                        requirementResultCode.resultCode = 1;
                        return requirementResultCode;
                    }
                }
            }

            if (patientAdmission.BeneficiaryName != null && (patientAdmission.BeneficiaryUniqueRefNo == null || patientAdmission.BeneficiaryUniqueRefNo == 0))
            {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25765", "Hak sahibi kimlik numarası bilgisi giriniz.");
                return requirementResultCode;
            }
            else if (patientAdmission.BeneficiaryName == null && patientAdmission.BeneficiaryUniqueRefNo != null && patientAdmission.BeneficiaryUniqueRefNo != 0)
            {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25764", "Hak sahibi ad bilgisi giriniz.");
                return requirementResultCode;
            }

            if (patientAdmission.IsNewBorn == true)
            {
                if(patient.BirthOrder == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M27234", "Yeni doğan kayıtlarında 'Doğum sırası' bilgisi giriniz.");
                    return requirementResultCode;
                }
                else if (patient.Mother == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M27233", "Yeni doğan kayıtlarında 'Anne' bilgisi giriniz.");
                    return requirementResultCode;
                }
                
            }

            if (patientAdmission.Payer != null && patient.Nationality != null &&
                (patient.Nationality.Kodu == "DE") ||(patient.Nationality.Kodu == "AT") || (patient.Nationality.Kodu == "BE") || (patient.Nationality.Kodu == "NL") || (patient.Nationality.Kodu == "FR"))//AT BE  NL FR
            {
                if (patientAdmission.Payer.ID == 99 && (patient.YUPASSNO == null || patient.YUPASSNO == 0))//SGK (Yurtdışı sigortalılar)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M00000", "Yurtdışı Sigortalı hastalarda 'Yupass No' alanı boş olamaz.");
                    return requirementResultCode;
                }
            }
            return requirementResultCode;
        }

    }
}
