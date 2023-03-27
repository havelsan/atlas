//$743E100B
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.ComponentModel;
using Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class BulasiciHastalikVeriSetiServiceController
    {
        partial void PreScript_BulasiciHastaliklarNewForm(BulasiciHastaliklarNewFormViewModel viewModel, BulasiciHastalikVeriSeti bulasiciHastalikVeriSeti, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._BulasiciHastalikVeriSeti.EpisodeAction = episodeAction;
                viewModel._BulasiciHastalikVeriSeti.SubEpisode = episodeAction.SubEpisode;

                //Doktor Bilgisi Set Edilir

                if (Common.CurrentResource.TakesPerformanceScore == true)
                {
                    viewModel._BulasiciHastalikVeriSeti.ResponsibleDoctor = Common.CurrentResource;
                }
                else
                {
                    viewModel._BulasiciHastalikVeriSeti.ResponsibleDoctor = episodeAction.ProcedureDoctor;
                }

            }

            //Guid? selectedPatientID = Request.Headers.GetSelectedPatientID();
            //if (selectedPatientID.HasValue)
            //{
            //Patient patient = objectContext.GetObject<Patient>(selectedPatientID.Value);

            if (bulasiciHastalikVeriSeti.SubEpisode != null)
            {
                if (bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSILKodlari != null)
                    viewModel._BulasiciHastalikVeriSeti.Ikamet_Il = bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSILKodlari;

                if (bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSIlceKodlari != null)
                    viewModel._BulasiciHastalikVeriSeti.Ikamet_Ilce = bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSIlceKodlari;

                if (bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSBucakKodu != null)
                    viewModel._BulasiciHastalikVeriSeti.Ikamet_Bucak = bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSBucakKodu;

                if (bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSKoyKodlari != null)
                    viewModel._BulasiciHastalikVeriSeti.Ikamet_Koy = bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSKoyKodlari;

                if (bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSMahalleKodlari != null)
                    viewModel._BulasiciHastalikVeriSeti.Ikamet_Mahalle = bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSMahalleKodlari;

                if (bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSCsbmKodu != null)
                    viewModel._BulasiciHastalikVeriSeti.Ikamet_CSBM = bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.SKRSCsbmKodu;

                if (bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.DisKapi != null)
                    viewModel._BulasiciHastalikVeriSeti.DisKapiNoIkamet = bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.DisKapi;

                if (bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.IcKapi != null)
                    viewModel._BulasiciHastalikVeriSeti.IcKapiNoIkamet = bulasiciHastalikVeriSeti.SubEpisode.PatientAdmission.PA_Address.IcKapi;
            }

            //KPS Sorgusu -> ikametgah adresi 

            //KPSV2.KpsServisSonucuBilesikKisiBilgisi response = KPSV2.WebMethods.BilesikKisiveAdresSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(patient.UniqueRefNo));
            //var _adresBilgisi = response.Sonuc.TCVatandasiKisiKutukleri.AdresBilgisi;


            //BindingList<SKRSIl> ilList = SKRSIl.GetSKRSIlByKodu(objectContext, Convert.ToInt32(_adresBilgisi.IlIlceMerkezAdresi.IlKodu));
            // = ilList[0];

            //BindingList<SKRSIlce> ilceList = SKRSIlce.GetSKRSIlceByKodu(objectContext, Convert.ToInt32(_adresBilgisi.IlIlceMerkezAdresi.IlceKodu));
            //viewModel._BulasiciHastalikVeriSeti.Ikamet_Ilce = ilceList[0];

            ////BindingList<SKRSBucakKodlari> bucakList = SKRSBucakKodlari.GetSKRSBucakByKodu(objectContext, Convert.ToInt32(_adresBilgisi.IlIlceMerkezAdresi.));
            //viewModel._BulasiciHastalikVeriSeti.Ikamet_Bucak = null;



            //}

            //Paket Ýþlem zamaný
            viewModel._BulasiciHastalikVeriSeti.PaketeAitIslemZamani = DateTime.Now;

            if (viewModel._BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi == null)
                viewModel._BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi = DateTime.Now;


            ContextToViewModel(viewModel, objectContext);
        }

        public void PostScript_BulasiciHastaliklar(BulasiciHastaliklarNewFormViewModel viewModel, BulasiciHastalikVeriSeti bulasiciHastalikVeriSeti, TTObjectContext objectContext)
        {
            //Tanýyý set et
            var selectedDiagnosis = objectContext.GetObject(viewModel.DiagnosisObjectID, "DiagnosisDefinition") as DiagnosisDefinition;

            if (selectedDiagnosis != null)
            {

                BindingList<SKRSICD> msvsList = SKRSICD.GetByKodu(objectContext, selectedDiagnosis.Code);

                bulasiciHastalikVeriSeti.SKRSICD = msvsList[0];

            }

            #region INFLUENZA
            try
            {
                if (selectedDiagnosis != null && TTObjectClasses.SystemParameter.GetParameterValue("INFLUENZASERVICEACTIVE", "FALSE") == "TRUE")
                {
                    BindingList<DiagnosisDefinition> diagnosis = DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, selectedDiagnosis.Code, "");

                    if (diagnosis != null && diagnosis[0].IsInfluenzaDiagnos == true && bulasiciHastalikVeriSeti.SubEpisode.Episode.Patient.UniqueRefNo != null)
                    {
                        InfluenzaResult irr = new InfluenzaResult();

                        InfluenzaServis.WebMethods.InfluenzaTaniBilgisi i = new InfluenzaServis.WebMethods.InfluenzaTaniBilgisi();
                        i.aileHekimligindeMi = false;
                        i.AntijenTesti = viewModel.InfluenzaResult == 0 ? InfluenzaServis.WebMethods.AntijenTestiSonuclari.Negatif : InfluenzaServis.WebMethods.AntijenTestiSonuclari.Pozitif;
                        i.HastaTC = bulasiciHastalikVeriSeti.SubEpisode.Episode.Patient.UniqueRefNo.ToString();
                        i.HekimTC = bulasiciHastalikVeriSeti.ResponsibleDoctor.UniqueNo;
                        i.ICD10Kodu = selectedDiagnosis.Code;

                        string _siteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");

                        try
                        {
                            InfluenzaServis.WebMethods.ServiceResult sr = InfluenzaServis.WebMethods.SaveInfluenzaTaniTestSync(new Guid(_siteId), i);

                            InfluenzaResult ir = new InfluenzaResult(objectContext);

                            ir.ControlReturnResult(sr.State, sr.Message);

                            if(sr.State != InfluenzaServis.WebMethods.ServisSonucDurumu.BASARILI)
                                sendNotificationToDoctor(bulasiciHastalikVeriSeti.ResponsibleDoctor, bulasiciHastalikVeriSeti.SubEpisode.Episode.Patient);

                            ir.ResponsibleDoctor = bulasiciHastalikVeriSeti.ResponsibleDoctor;
                            ir.ICD10Kodu = selectedDiagnosis.Code;
                            ir.InfluenzaResultProp = (PositiveNegativeEnum)viewModel.InfluenzaResult;
                            ir.ErrorMessage = sr.Message;
                            ir.IslemGuid = sr.Result;

                            bulasiciHastalikVeriSeti.SubEpisode.Episode.Influenza = ir;

                        }
                        catch (Exception ex)
                        {

                            InfluenzaResult ir = new InfluenzaResult(objectContext);

                            ir.ResponsibleDoctor = bulasiciHastalikVeriSeti.ResponsibleDoctor;
                            ir.ICD10Kodu = selectedDiagnosis.Code;
                            ir.InfluenzaResultProp = (PositiveNegativeEnum)viewModel.InfluenzaResult;
                            ir.ErrorMessage = "Influenza Bilgisi Kaydedilemedi. Hata Detayý :" + ex.Message;
                            ir.IslemGuid = null;

                            bulasiciHastalikVeriSeti.SubEpisode.Episode.Influenza = ir;

                            ir.ControlReturnResult(InfluenzaServis.WebMethods.ServisSonucDurumu.HATA, ex.Message);

                            sendNotificationToDoctor(bulasiciHastalikVeriSeti.ResponsibleDoctor, bulasiciHastalikVeriSeti.SubEpisode.Episode.Patient);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                //Servis hata alýrsa devam etsin
                InfoMessageService.Instance.ShowMessage(ex.Message);
                //throw new Exception(ex.Message);
            }
            #endregion

            //Bulaþýcý Hastalýk Episode Action Yarat
            var bulasiciHastaliklarEA = new BulasiciHastaliklarEA(objectContext);
            bulasiciHastaliklarEA.BulasiciHastalikVeriSeti = bulasiciHastalikVeriSeti;
            bulasiciHastaliklarEA.CurrentStateDefID = BulasiciHastaliklarEA.States.New;
            bulasiciHastaliklarEA.MasterAction = bulasiciHastalikVeriSeti.EpisodeAction;
            bulasiciHastaliklarEA.SetMandatoryEpisodeActionProperties(bulasiciHastalikVeriSeti.EpisodeAction, bulasiciHastalikVeriSeti.EpisodeAction.MasterResource, false);
            new SendToENabiz(objectContext, bulasiciHastaliklarEA.SubEpisode, bulasiciHastaliklarEA.ObjectID, bulasiciHastaliklarEA.ObjectDef.Name, "214", Common.RecTime());
            objectContext.Save();
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend214(bulasiciHastaliklarEA.ObjectID.ToString());

        }

        //influenza servisine ulaþýlamadý bilgisi gönderir
        protected void sendNotificationToDoctor(ResUser ResponsibleDoctor,Patient patient)
        {
            TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
            atlasNotification.users = new System.Collections.Generic.List<string>();
            atlasNotification.users.Add(ResponsibleDoctor.ObjectID.ToString());
            atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
            atlasNotification.contentType = TTUtils.AtlasContentType.Notification;

            string messageText = "";
            messageText += ResponsibleDoctor != null ? ("Sayýn " + ResponsibleDoctor.Name + " , ") : "";
            messageText += new DateTime().ToString("dd MMMM yyyy") + " tarihinde ";
            messageText += (patient != null && patient.UniqueRefNo != null) ? "'" + patient.UniqueRefNo + "' Kimlik numaralý" : "";
            messageText += patient != null ? ("'" + patient.FullName + "' hastasý için yapmýs olduðunuz") : "";
            messageText += " Influenza bilgisi kaydetme iþlemi sýrasýnda bir hata oluþtu. Lütfen iþlemi manuel olarak daha sonra tekrar deneyiniz";

            atlasNotification.content = messageText;
            string notificationStr = Newtonsoft.Json.JsonConvert.SerializeObject(atlasNotification);

            TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);
        }

        [HttpGet]
        public SKRSTelefonTipi[] GetSKRSTelefonTipi()
        {
            SKRSTelefonTipi[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                result = objectContext.QueryObjects<SKRSTelefonTipi>().ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

    }
}

namespace Core.Models
{
    public partial class BulasiciHastaliklarNewFormViewModel:BaseViewModel,IENabizViewModel
    {
        public Guid DiagnosisObjectID;
        public int InfluenzaResult { get; set; }
        public bool HasInfluenzaDiagnosis { get; set; }

        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._BulasiciHastalikVeriSeti);


            if (this.BulasiciHastalikTelefonGridList != null)
            {
                foreach (var item in this.BulasiciHastalikTelefonGridList)
                {
                    var bulasiciHastalikTelefonImported = (BulasiciHastalikTelefon)objectContext.AddObject(item);
                    bulasiciHastalikTelefonImported.BulasiciHastalikVeriSeti = this._BulasiciHastalikVeriSeti;
                }
            }


            BulasiciHastalikVeriSetiServiceController controller = new BulasiciHastalikVeriSetiServiceController();
            var bulasiciHastaliklar = (BulasiciHastalikVeriSeti)objectContext.GetLoadedObject(this._BulasiciHastalikVeriSeti.ObjectID);

            controller.PostScript_BulasiciHastaliklar(this, bulasiciHastaliklar, objectContext);
        }

    }
}
