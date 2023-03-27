//$E47E06B5
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using TTDefinitionManagement;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class MedicalResarchPatientAdServiceController : Controller
    {
        public string saveMedicalResarchPatientAd(PatientAdInput_DTO inputDTO)
        {
            using (var context = new TTObjectContext(false))
            {
                MedicalResarch medicalResarch = context.GetObject<MedicalResarch>(new Guid(inputDTO.medicalResarchObjectID));

                string injectionSQL = "WHERE CURRENTSTATEDEFID <> '6d5d7f5a-19ac-4514-a085-d39f879fc13a' AND MEDICALRESARCH.OBJECTID ='" + inputDTO.medicalResarchObjectID + "'";
                BindingList<MedicalResarchPatientEx.MedicalResarchPatientExRQ_Class> medicalResarchPatientes = MedicalResarchPatientEx.MedicalResarchPatientExRQ(injectionSQL);
                if (medicalResarchPatientes.Count >= medicalResarch.PatientCount)
                    throw new Exception("Max hasta sayýsýna ulaþýlmýþtýr.Ekleme Yapýlamaz.");


                MedicalResarchPatientAd medicalResarchPatientAd = new MedicalResarchPatientAd(context);
                MedicalResarchPatientEx medicalResarchEpisodeAction = new MedicalResarchPatientEx(context);
                medicalResarchEpisodeAction.MedicalResarch = medicalResarch;

                SubEpisode se = new SubEpisode(context);
                se.PatientAdmission = medicalResarchPatientAd;
                se.AddSubEpisodeProtocol();
                se.PatientStatus = SubEpisodeStatusEnum.Outpatient;

                medicalResarchPatientAd.MedicalResarch = medicalResarch;
                medicalResarchPatientAd.Episode = new Episode(context);
                medicalResarchPatientAd.Episode.Patient = inputDTO.medicalResarchPatient;
                medicalResarchPatientAd.Episode.OpeningDate = Common.RecTime();
                medicalResarchPatientAd.Episode.PatientStatus = PatientStatusEnum.Outpatient;
                medicalResarchPatientAd.MedulaSigortaliTuru = SigortaliTuru.GetSigortaliTuru("4");
                medicalResarchPatientAd.AdmissionType = ProvizyonTipi.GetProvizyonTipi("N");
                medicalResarchPatientAd.Episode.Patient.Nationality = Patient.SetDefaultNationality().FirstOrDefault();
                medicalResarchPatientAd.ProcedureDoctor = Common.CurrentDoctor;
                medicalResarchPatientAd.ActionDate = Common.RecTime();
                medicalResarchPatientAd.CreationDate = Common.RecTime();

                ResPoliclinic medicalResarchResPoliclinic = context.QueryObjects<ResPoliclinic>(" POLICLINICTYPE = 2").FirstOrDefault();//Týbbý Araþtýrma Polikilik
                medicalResarchPatientAd.Policlinic = medicalResarchResPoliclinic;

                PatientAdmissionStartedActions oaStartedAct = null;
                oaStartedAct = PatientAdmissionStartedActions.GetFiredActionsandProcedures(medicalResarchResPoliclinic, AdmissionStatusEnum.Normal);//AdmissionStatusEnum týbbý araþtýrma eklenecek ve sadece o gelecek.

                medicalResarchEpisodeAction.CurrentStateDefID = MedicalResarchPatientEx.States.New;
                medicalResarchEpisodeAction.ActionDate = Common.RecTime();
                medicalResarchEpisodeAction.MasterResource = medicalResarchResPoliclinic;
                medicalResarchEpisodeAction.FromResource = medicalResarchResPoliclinic;

                string sgkOPPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("MEDICALRESARCHISPAYERDEFINITION", "4592d438-3b00-421a-beb1-fe010dafca29");//Týbbý araþtýrma kurumu için parametre
                PayerDefinition sgkOPPayer = context.GetObject<PayerDefinition>(new Guid(sgkOPPayerObjectID), false);
                medicalResarchPatientAd.Payer = sgkOPPayer;

                SavePatientAdmission(medicalResarchPatientAd, 0);
                medicalResarchEpisodeAction.Episode = medicalResarchPatientAd.Episode;

                se.ProtocolNo = se.GetAndSetNextProtocolNo();
                se.SubEpisodeProtocols.FirstOrDefault().Brans = SpecialityDefinition.GetBrans("9999");//9999 Diðer eðer ilerde týbbý araþtýrma branþý tanýmlanacaksa o getilmesi gerekiyor.
                se.Sent101Package = false;//nabýza veri göndermemesi için
                context.Save();
                return "Hasta Kaydý Tamamlandý..";
            }
        }


        public static void SavePatientAdmission(PatientAdmission pa, int activeTab)
        {
            var e = pa.Episode;
            var p = pa.Episode.Patient;

            pa.CreationDate = Common.RecTime();
            pa.ActionDate = pa.CreationDate;


            string canFirePatientAdmission = PatientAdmission.CanFirePatientAdmission(pa, p, pa.ObjectContext);
            if (canFirePatientAdmission != "")
                throw new TTUtils.TTException(canFirePatientAdmission);

            //True döner ise Pa-SEP-SE ve prosedürler iptal edilir yenileri oluþturulur
            bool checkMemberChanged = PatientAdmission.CheckMemberChanged(pa);

            bool isNewPatientAdmission = (((ITTObject)pa).IsNew);

            PatientAdmission.PreparePatientAdmission(pa);

            if (pa?.Payer?.IsActive == false)
                throw new Exception("Kabul alýnmaya çalýþýlan kurumun durumu 'Pasif' tir. Lütfen kontrol ediniz.");


            if (pa.AdmissionType != null && pa.AdmissionType.provizyonTipiKodu != null)
            {
                if (pa.AdmissionType.provizyonTipiKodu != "S")
                {
                    pa.SEP.MedulaIstisnaiHal = null;
                    pa.MedulaIstisnaiHal = null;
                }
                if (pa.AdmissionType.provizyonTipiKodu != "T")
                {
                    pa.SEP.MedulaPlakaNo = null;
                    if (pa.AdmissionType.provizyonTipiKodu != "V" && pa.AdmissionType.provizyonTipiKodu != "I")
                    {
                        pa.MedulaVakaTarihi = null;
                        pa.SEP.MedulaVakaTarihi = null;
                    }
                }
                if (pa.AdmissionType.provizyonTipiKodu != "V")
                {
                    pa.SKRSAdliVaka = null;
                    if (pa.AdmissionType.provizyonTipiKodu != "T" && pa.AdmissionType.provizyonTipiKodu != "I")
                    {
                        pa.MedulaVakaTarihi = null;
                        pa.SEP.MedulaVakaTarihi = null;
                    }
                }
                if (pa.AdmissionType.provizyonTipiKodu != "I" && pa.AdmissionType.provizyonTipiKodu != "T" && pa.AdmissionType.provizyonTipiKodu != "V")
                {
                    pa.MedulaVakaTarihi = null;
                    pa.SEP.MedulaVakaTarihi = null;

                }
            }

            if (pa.MedulaIstisnaiHal != null && pa.MedulaIstisnaiHal.Kodu.Equals("B"))
                pa.SEP.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi("21");
            else
                pa.SEP.MedulaTedaviTipi = (pa.Policlinic == null || pa.Policlinic.TedaviTipi == null) ? TedaviTipi.GetTedaviTipi("0") : pa.Policlinic.TedaviTipi;

            if (isNewPatientAdmission)
            {
                PatientAdmission.FillSEPProperties(pa);

                var se = pa.FirstSubEpisode;
                se.ArrangeMeOrCreateNewSubEpisode(pa, false, true);
                if (pa.SEP != null)
                    pa.SEP.SetSEPMaster();
            }

            if (pa.HasMemberChanged("AdmissionType") && !String.IsNullOrEmpty(pa.SEP.MedulaTakipNo))
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25853", "Hastanýn takip numarasý bulunmaktadýr.Geliþ sebebini deðiþtirmek için önce Takip siliniz."));
        }

        [HttpGet]
        public MRProcedureGridsDTO getMRProcedurGridList(string MedicalResarchEpisodeObjectID)
        {
            using (var context = new TTObjectContext(false))
            {

                MRProcedureGridsDTO mRProcedureGridsDTO = new MRProcedureGridsDTO();
                mRProcedureGridsDTO.mRProcedurGridDTOs = new List<MRProcedurGridDTO>();

                MedicalResarchPatientEx patientEx = context.GetObject<MedicalResarchPatientEx>(new Guid(MedicalResarchEpisodeObjectID));
                foreach (var item in patientEx.MedicalResarch.MedicalResarchProcedurs.Select(string.Empty))
                {
                    MRProcedurGridDTO mRProcedur = new MRProcedurGridDTO();
                    mRProcedur.procedureObjectID = item.ProcedureDefinition.ObjectID;
                    mRProcedur.procedureName = item.ProcedureDefinition.Name;
                    mRProcedur.Code = item.ProcedureDefinition.Code;
                    mRProcedur.MedicalResarchPatientExObjectID = item.ObjectID.ToString();
                    foreach (var procedurePrice in item.ProcedureDefinition.ProcedurePrice)
                    {
                        if (procedurePrice.PricingDetail.PricingList.ObjectID == new Guid("47466669-d190-4d13-af74-21a23d8a5ddb"))
                        {
                            mRProcedur.Price = procedurePrice.PricingDetail.Price.ToString();
                        }
                    }
                    //Doðru fiyat için kontrol edeilmelidir.
                    //mRProcedur.Price = item.ProcedureDefinition.ProcedurePrice[item.ProcedureDefinition.ProcedurePrice.Count - 1].PricingDetail.Price.ToString();
                    mRProcedureGridsDTO.mRProcedurGridDTOs.Add(mRProcedur);
                }

                mRProcedureGridsDTO.mRCreateProcedurGridGridListDTOs = new List<MRCreateProcedurGridGridListDTO>();



                BindingList<MedicalResarchPatientExPro> medicalResarchPatientExPros = context.QueryObjects<MedicalResarchPatientExPro>("MEDICALRESARCHPATIENTEX = '" + MedicalResarchEpisodeObjectID + "'");
                foreach (var item in medicalResarchPatientExPros)
                {
                    MRCreateProcedurGridGridListDTO mRProcedurPatient = new MRCreateProcedurGridGridListDTO();
                    mRProcedurPatient.Amount = item.Amount.ToString();
                    mRProcedurPatient.Code = item.ProcedureObject.Code;
                    mRProcedurPatient.Name = item.ProcedureObject.Name;
                    mRProcedurPatient.ObjectID = item.ObjectID.ToString();
                    foreach (var procedurePrice in item.ProcedureObject.ProcedurePrice)
                    {
                        if (procedurePrice.PricingDetail.PricingList.ObjectID == new Guid("47466669-d190-4d13-af74-21a23d8a5ddb"))
                        {
                            mRProcedurPatient.Price = procedurePrice.PricingDetail.Price.ToString();
                        }
                    }
                    mRProcedurPatient.RequestDate = item.ActionDate.ToString();
                    mRProcedurPatient.Resault = "";
                    mRProcedurPatient.ResaultValue = "";
                    mRProcedurPatient.Status = item.CurrentStateDef.DisplayText;
                    mRProcedurPatient.ProcedureObjectID = item.ProcedureObject.ObjectID.ToString();
                    mRProcedureGridsDTO.mRCreateProcedurGridGridListDTOs.Add(mRProcedurPatient);
                }
                return mRProcedureGridsDTO;
            }
        }

        [HttpGet]
        public Guid getProcedureRequestFormDetailDefinitionID(string ProcedureObjectID)
        {
            using (var context = new TTObjectContext(false))
            {
                if (string.IsNullOrEmpty(ProcedureObjectID) == false)
                    return context.QueryObjects<ProcedureRequestFormDetailDefinition>(" PROCEDUREDEFINITION ='" + ProcedureObjectID + "'").FirstOrDefault().ObjectID;
                else
                    return Guid.Empty;
            }
        }


        [HttpPost]
        public void saveMRProcedurePatient(List<MedicalResarchProcedurInputDTO> inputDTO)
        {
            using (var context = new TTObjectContext(false))
            {
                foreach (MedicalResarchProcedurInputDTO input in inputDTO)
                {
                    if (input.objectID != null)
                    {
                        var medicalResarchExPros = context.QueryObjects<MedicalResarchPatientExPro>("OBJECTID ='" + input.medicalResarchPatientExObjectID + "'");
                        if (medicalResarchExPros.Count == 0)
                        {
                            ProcedureDefinition procedureDefinition = context.GetObject<ProcedureDefinition>(new Guid(input.procedureDefinitionObjectID));
                            EpisodeAction episodeAction = context.GetObject<EpisodeAction>(new Guid(input.episodeActionObjectID));
                            MedicalResarchPatientEx medicalResarchPatientEx = context.GetObject<MedicalResarchPatientEx>(new Guid(input.episodeActionObjectID));

                            MedicalResarchPatientExPro medicalResarchProcedurExPro = new MedicalResarchPatientExPro(context);
                            medicalResarchProcedurExPro.Amount = input.Amount;
                            medicalResarchProcedurExPro.EpisodeAction = episodeAction;
                            medicalResarchProcedurExPro.Episode = episodeAction.Episode;
                            medicalResarchProcedurExPro.ProcedureDoctor = Common.CurrentDoctor;
                            medicalResarchProcedurExPro.SubEpisode = episodeAction.SubEpisode;
                            medicalResarchProcedurExPro.MedicalResarchPatientEx = medicalResarchPatientEx;
                            medicalResarchProcedurExPro.ProcedureObject = procedureDefinition;
                            medicalResarchProcedurExPro.CurrentStateDefID = MedicalResarchPatientExPro.States.Completed;
                            context.Save();
                        }
                    }
                }
            }
        }
    }
}

namespace Core.Models
{

    public class MedicalResarchProcedurInputDTO
    {
        public string objectID { get; set; }
        public string procedureDefinitionObjectID { get; set; }
        public long Amount { get; set; }
        public string episodeActionObjectID { get; set; }
        public string medicalResarchPatientExObjectID { get; set; }
        public string MedicalResarchEpisodeObjectID { get; set; }
    }


    public class PatientAdInput_DTO
    {
        public Patient medicalResarchPatient { get; set; }
        public string medicalResarchObjectID { get; set; }
    }

    public class MRProcedureGridsDTO
    {
        public List<MRProcedurGridDTO> mRProcedurGridDTOs { get; set; }
        public List<MRCreateProcedurGridGridListDTO> mRCreateProcedurGridGridListDTOs { get; set; }
    }

    public class MRProcedurGridDTO
    {
        public Guid procedureObjectID { get; set; }
        public string procedureName { get; set; }

        public string Price { get; set; }
        public string Code { get; set; }
        public string MedicalResarchPatientExObjectID { get; set; }
    }

    public class MRCreateProcedurGridGridListDTO
    {
        public string RequestDate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string ResaultValue { get; set; }
        public string Resault { get; set; }
        public string Price { get; set; }
        public string ObjectID { get; set; }
        public string ProcedureObjectID { get; set; }
        public string MedicalResarchPatientExObjectID { get; set; }
    }

}

