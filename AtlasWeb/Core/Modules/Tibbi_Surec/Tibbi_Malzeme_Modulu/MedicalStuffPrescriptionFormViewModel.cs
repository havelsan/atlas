//$EE8E1133
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Infrastructure.Helpers;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using Infrastructure.Models;


namespace Core.Controllers
{
    public partial class MedicalStuffPrescriptionServiceController
    {
        partial void PreScript_MedicalStuffPrescriptionForm(MedicalStuffPrescriptionFormViewModel viewModel, MedicalStuffPrescription medicalStuffPrescription, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();

            if (selectedEpisodeActionObjectID.HasValue && viewModel._MedicalStuffPrescription.MasterAction == null)
            {
                EpisodeAction episodeAction = medicalStuffPrescription.ObjectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                viewModel._MedicalStuffPrescription.MasterAction = episodeAction;
                viewModel._MedicalStuffPrescription.MasterResource = episodeAction.MasterResource;
                viewModel._MedicalStuffPrescription.FromResource = episodeAction.MasterResource;
                viewModel._MedicalStuffPrescription.Episode = episodeAction.Episode;
                var P = viewModel._MedicalStuffPrescription.Episode.Patient;
                viewModel._MedicalStuffPrescription.ProcedureDoctor = episodeAction.ProcedureDoctor;
                viewModel._MedicalStuffPrescription.SubEpisode = episodeAction.SubEpisode;
                viewModel._MedicalStuffPrescription.ActionDate = System.DateTime.Now;
                if (episodeAction is MedicalStuffReport)
                    viewModel._MedicalStuffPrescription.MedicalStuffReport = (MedicalStuffReport)episodeAction;
            }
            //tan� kontrol�
            medicalStuffPrescription.CheckForDiagnosis();

            FillPrescriptionList(objectContext, viewModel);

            if (viewModel._MedicalStuffPrescription.PrescriptionDate == null)
                viewModel._MedicalStuffPrescription.PrescriptionDate = DateTime.Now;
            if (Common.CurrentUser.IsSuperUser != true)
            {
                viewModel.IsSuperUser = false;
                if (Common.CurrentResource.UserType == UserTypeEnum.Doctor || Common.CurrentResource.UserType == UserTypeEnum.Dentist)
                {
                    if (viewModel._MedicalStuffPrescription.ProcedureDoctor == null)
                    {
                        viewModel._MedicalStuffPrescription.ProcedureDoctor = Common.CurrentResource;
                    }
                }
            }
            else
                viewModel.IsSuperUser = true;

            if (medicalStuffPrescription.CurrentStateDefID == null)
                medicalStuffPrescription.CurrentStateDefID = MedicalStuffPrescription.States.New;

            if (medicalStuffPrescription.CurrentStateDefID == MedicalStuffPrescription.States.New)
            {
                viewModel.ToState = MedicalStuffPrescription.States.New;
            }

            if (medicalStuffPrescription.MedicalStuffReport != null)
            {
                viewModel.oldMedicalStuffPrescriptions = new List<OldMedicalStuffPrescriptionModel>();
                var oldPrescriptions = MedicalStuffPrescription.GetMedicalStuffPrescriptionsByReport(medicalStuffPrescription.MedicalStuffReport.ObjectID);

                foreach (MedicalStuffPrescription.GetMedicalStuffPrescriptionsByReport_Class oldPrescription in oldPrescriptions)
                {
                    OldMedicalStuffPrescriptionModel model = new OldMedicalStuffPrescriptionModel();
                    model.ObjectID = (Guid)oldPrescription.ObjectID;
                    model.ActionDate = (DateTime)oldPrescription.ActionDate;
                    model.PrescriptionNo = oldPrescription.ReceteTakipNo;
                    model.ProcedureDoctor = oldPrescription.Proceduredoctor;
                    model.RaporTakipNo = oldPrescription.RaporTakipNo;
                    model.ReportNo = oldPrescription.ReportNo.ToString();
                    viewModel.oldMedicalStuffPrescriptions.Add(model);
                }
            }

            if (medicalStuffPrescription.MedicalStuff.Count == 0)
            {
                viewModel.MedicalStuffGridGridList = GetMedicalStuffReportMaterials(objectContext, viewModel._MedicalStuffPrescription.MedicalStuffReport, medicalStuffPrescription);
            }
            /*if (medicalStuffPrescription.MedicalStuffReport != null)
            {
                if (medicalStuffPrescription.MedicalStuffReport.MedicalStuff != null && medicalStuffPrescription.MedicalStuffReport.MedicalStuff.Count > 0)
                {
                    List<MedicalStuffDefinitionObject> medicalStuffDefinitionObjects = new List<MedicalStuffDefinitionObject>();
                    foreach (MedicalStuff medicalStuff in medicalStuffPrescription.MedicalStuffReport.MedicalStuff)
                    {
                        MedicalStuffDefinitionObject item = new MedicalStuffDefinitionObject();
                        item.MedicalStuffDefId = medicalStuff.ObjectID;
                        item.MedicalStuffDefName = medicalStuff.MedicalStuffDef.Name;
                        item.MedicalStuffDefCode = medicalStuff.MedicalStuffDef.Code;
                        item.MedicalStuffAmount = medicalStuff.StuffAmount;
                        item.PeriodUnit = medicalStuff.PeriodUnit;
                        item.PeriodUnitType = medicalStuff.PeriodUnitType;
                        item.MedicalStuffPlaceOfUsage = medicalStuff.MedicalStuffPlaceOfUsage.Code + "-" + medicalStuff.MedicalStuffPlaceOfUsage.Name;
                        medicalStuffDefinitionObjects.Add(item);
                    }
                    viewModel.medicalStuffs = medicalStuffDefinitionObjects.ToArray();
                }
            }*/


            ContextToViewModel(viewModel, objectContext);
        }

        partial void PostScript_MedicalStuffPrescriptionForm(MedicalStuffPrescriptionFormViewModel viewModel, MedicalStuffPrescription medicalStuffPrescription, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            /*objectContext.AddToRawObjectList(viewModel.SubEpisodeProtocol);
            objectContext.ProcessRawObjects();
*/
            /*ReportDiagnosisServiceController diagnosis = new ReportDiagnosisServiceController();
            diagnosis.SaveDiagnosis(viewModel.reportDiagnosisFormViewModel, medicalStuffPrescription);*/

            if (medicalStuffPrescription.CurrentStateDefID == null)
                medicalStuffPrescription.CurrentStateDefID = MedicalStuffPrescription.States.New;

            /*medicalStuffPrescription.ActionDate = Common.RecTime();
            if (medicalStuffPrescription.Cancelled == null)
                medicalStuffPrescription.Cancelled = false;
            if (medicalStuffPrescription.Active == null)
                medicalStuffPrescription.Active = true;*/
            /*  BindingList<MedicalStuffDefinition> medicalStuffDefinitionList = MedicalStuffDefinition.GetMedicalStuffDefByCode(objectContext, viewModel._medicalStuffPrescription.StuffCode);
              medicalStuffPrescription.MedicalStuffDef = medicalStuffDefinitionList[0];*/
            /*foreach (MedicalStuff medicalStuff in viewModel.MedicalStuffGridGridList)
                        {
                            if (medicalStuff.MedicalStuffPrescription == null)
                                medicalStuff.MedicalStuffPrescription = medicalStuffPrescription;
                        }
                        */

            objectContext.Save();

            if (medicalStuffPrescription.CurrentStateDefID == MedicalStuffPrescription.States.New)
                medicalStuffPrescription.CurrentStateDefID = MedicalStuffPrescription.States.PrescriptionCompleted;

            if (viewModel.ToState == MedicalStuffPrescription.States.PrescriptionCompleted)
                medicalStuffPrescription.CurrentStateDefID = MedicalStuffPrescription.States.PrescriptionCompleted;

            if (viewModel.ToState == MedicalStuffPrescription.States.Completed)
            {
                medicalStuffPrescription.CurrentStateDefID = MedicalStuffPrescription.States.Completed;

            }


        }

        
        public MedicalStuff[] GetMedicalStuffReportMaterials(TTObjectContext objectContext, MedicalStuffReport medicalStuffReport,MedicalStuffPrescription medicalStuffPrescription)
        {
            List<MedicalStuff> medicalStuffDefinitionObjects = new List<MedicalStuff>();
            try
            {
                if (medicalStuffReport != null)
                {
                    foreach (MedicalStuff medicalStuff in medicalStuffReport.MedicalStuff)
                    {
                        MedicalStuff newMedicalStuff = new MedicalStuff(objectContext);
                        newMedicalStuff.MedicalStuffDef = medicalStuff.MedicalStuffDef;
                        newMedicalStuff.MedicalStuffGroup = medicalStuff.MedicalStuffGroup;
                        newMedicalStuff.MedicalStuffPlaceOfUsage = medicalStuff.MedicalStuffPlaceOfUsage;
                        newMedicalStuff.MedicalStuffUsageType = medicalStuff.MedicalStuffUsageType;
                        newMedicalStuff.StuffAmount = medicalStuff.StuffAmount;
                        newMedicalStuff.StuffDescription = medicalStuff.StuffDescription;
                        newMedicalStuff.PeriodUnit = medicalStuff.PeriodUnit;
                        newMedicalStuff.PeriodUnitType = medicalStuff.PeriodUnitType;
                        newMedicalStuff.MedicalStuffPrescription = medicalStuffPrescription;
                        /*MedicalStuffDefinitionObject item = new MedicalStuffDefinitionObject();
                        item.MedicalStuffDefId = medicalStuff.ObjectID;
                        item.MedicalStuffDefName = medicalStuff.MedicalStuffDef.Name;
                        item.MedicalStuffDefCode = medicalStuff.MedicalStuffDef.Code;
                        item.MedicalStuffAmount = medicalStuff.StuffAmount;
                        item.PeriodUnit = medicalStuff.PeriodUnit;
                        item.PeriodUnitType = medicalStuff.PeriodUnitType;
                        item.MedicalStuffPlaceOfUsage = medicalStuff.MedicalStuffPlaceOfUsage.Code + "-" + medicalStuff.MedicalStuffPlaceOfUsage.Name;*/
                        medicalStuffDefinitionObjects.Add(medicalStuff);
                    }
                    return medicalStuffDefinitionObjects.ToArray();
                }

                return null;

            }
            catch (Exception e)
            {
                if (e != null)
                    TTUtils.InfoMessageService.Instance.ShowMessage(e.ToString());
                return null;
            }
        }


        [HttpPost]
        public MedulaResult eReceteSil(MedicalStuffPrescriptionFormViewModel viewModel)
        {
            MedulaResult model = new MedulaResult();

            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var medicalStuffPrescription = (MedicalStuffPrescription)objectContext.GetObject<MedicalStuffPrescription>(viewModel._MedicalStuffPrescription.ObjectID);


                    if (String.IsNullOrEmpty(medicalStuffPrescription.ReceteTakipNo))
                    {
                        throw new TTUtils.TTException("Medula Re�ete takip numaras� bulunama��t�r.");
                    }

                    TibbiMalzemeEReceteIslemleri.eReceteSorguIstekDVO eReceteSilDVO = new TibbiMalzemeEReceteIslemleri.eReceteSorguIstekDVO();
                    ResUser tabip = medicalStuffPrescription.ProcedureDoctor;
                    ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;

                    long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                    eReceteSilDVO.tesisKodu = Convert.ToInt32(saglikTesisKodu.ToString());
                    eReceteSilDVO.doktorTcKimlikNo = Convert.ToInt64(currentUser.UniqueNo);
                    eReceteSilDVO.ereceteNo = medicalStuffPrescription.ReceteTakipNo;

                    string username = "";
                    string password = "";
                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((viewModel.medulaUsername != null && viewModel.medulaUsername != "") || (viewModel.medulaPassword != null && viewModel.medulaPassword != ""))
                        {
                            username = viewModel.medulaUsername;
                            password = viewModel.medulaPassword;
                            eReceteSilDVO.doktorTcKimlikNo = Convert.ToInt32(viewModel.medulaUsername);
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullan�c� ad� veya �ifre bo� olamaz!");
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(medicalStuffPrescription.ProcedureDoctor.ErecetePassword))
                        {
                            throw new TTUtils.TTException("E-Re�ete �ifreniz Bo� Olamaz");

                        }
                        username = medicalStuffPrescription.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        eReceteSilDVO.doktorTcKimlikNo = Convert.ToInt64(username);
                        if (!string.IsNullOrEmpty(medicalStuffPrescription.ProcedureDoctor.ErecetePassword))
                            password = medicalStuffPrescription.ProcedureDoctor.ErecetePassword;
                    }

                    TibbiMalzemeEReceteIslemleri.eReceteSilCevapDVO response = TibbiMalzemeEReceteIslemleri.WebMethods.eReceteSilSync(TTObjectClasses.Sites.SiteLocalHost, username, password, eReceteSilDVO);

                    if (response != null)
                    {
                        if (response.sonucKodu == "0000")
                        {
                            medicalStuffPrescription.ReceteGelenXML = TTUtils.SerializationHelper.XmlSerializeObject(response);
                            medicalStuffPrescription.ReceteGidenXML = TTUtils.SerializationHelper.XmlSerializeObject(eReceteSilDVO);
                            medicalStuffPrescription.IsSendedMedula = false;


                            objectContext.Update();
                            medicalStuffPrescription.CurrentStateDefID = MedicalStuffPrescription.States.Completed;
                            medicalStuffPrescription.ReceteTakipNo = "";
                            objectContext.Update();
                        }
                        model.SonucKodu = response.sonucKodu;
                        model.SonucMesaji = response.sonucMesaji;
                    }
                    viewModel._MedicalStuffPrescription = medicalStuffPrescription;

                    objectContext.Save();

                    return model;
                }
            }
            catch (Exception e)
            {
                if (e != null)
                    TTUtils.InfoMessageService.Instance.ShowMessage(e.ToString());
                return null;
            }
        }

        [HttpPost]
        public TibbiMalzemeEReceteIslemleri.eReceteTaniEkleCevapDVO ReceteTaniEkle(AddDiagnosisToPrescriptionClass input)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                var diagnosisDefinition = (DiagnosisDefinition)objectContext.AddObject(input.Diagnose);
                var medicalStuffPrescription = (MedicalStuffPrescription)objectContext.AddObject(input.PrescriptionObject);
                objectContext.FullPartialllyLoadedObjects();
                TibbiMalzemeEReceteIslemleri.eReceteTaniEkleIstekDVO eReceteTaniEkleIstekDvo = new TibbiMalzemeEReceteIslemleri.eReceteTaniEkleIstekDVO();

                eReceteTaniEkleIstekDvo.ereceteNo = medicalStuffPrescription.ReceteTakipNo;
                eReceteTaniEkleIstekDvo.doktorTcKimlikNo = Convert.ToInt64(input.medulaUsername);

                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eReceteTaniEkleIstekDvo.tesisKodu = (int)saglikTesisKodu;

                var taniListesi = new List<TibbiMalzemeEReceteIslemleri.eTaniDVO>();

                TibbiMalzemeEReceteIslemleri.eTaniDVO eTaniDVO = new TibbiMalzemeEReceteIslemleri.eTaniDVO();
                eTaniDVO.taniKodu = diagnosisDefinition.Code;
                eTaniDVO.taniAdi = diagnosisDefinition.Name;

                taniListesi.Add(eTaniDVO);
                eReceteTaniEkleIstekDvo.taniListesi = taniListesi.ToArray();

                string uniqueRefNo = "", password = "";
                var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                if (MedulaPasswordCheck == "TRUE")
                {
                    if ((input.medulaUsername != null && input.medulaUsername != "") || (input.medulaPassword != null && input.medulaPassword != ""))
                    {
                        eReceteTaniEkleIstekDvo.doktorTcKimlikNo = Convert.ToInt64(input.medulaUsername);
                        uniqueRefNo = input.medulaUsername;
                        password = input.medulaPassword;
                    }
                    else
                    {
                        throw new TTUtils.TTException("Kullan�c� ad� veya �ifre bo� olamaz!");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(medicalStuffPrescription.ProcedureDoctor.ErecetePassword))
                    {
                        throw new TTUtils.TTException("E-Re�ete �ifreniz Bo� Olamaz");

                    }
                    uniqueRefNo = medicalStuffPrescription.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    eReceteTaniEkleIstekDvo.doktorTcKimlikNo = Convert.ToInt64(uniqueRefNo);
                    if (!string.IsNullOrEmpty(medicalStuffPrescription.ProcedureDoctor.ErecetePassword))
                        password = medicalStuffPrescription.ProcedureDoctor.ErecetePassword;
                }

                TibbiMalzemeEReceteIslemleri.eReceteTaniEkleCevapDVO response = TibbiMalzemeEReceteIslemleri.WebMethods.eReceteTaniEkleSync(Sites.SiteLocalHost, uniqueRefNo, password, eReceteTaniEkleIstekDvo);
                return response;

            }
        }

        public TibbiMalzemeEReceteIslemleri.eReceteListeSorguCevapDVO ReceteListeSorgula(eReceteListeSorgulaClass input)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                var medicalStuffPrescription = (MedicalStuffPrescription)objectContext.AddObject(input.PrescriptionObject);
                objectContext.FullPartialllyLoadedObjects();
                TibbiMalzemeEReceteIslemleri.eReceteListeSorguIstekDVO eReceteListeSorgulaIstekDvo = new TibbiMalzemeEReceteIslemleri.eReceteListeSorguIstekDVO();
                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eReceteListeSorgulaIstekDvo.tesisKodu = (int)saglikTesisKodu;
                eReceteListeSorgulaIstekDvo.hastaTcKimlikNo = Convert.ToInt64(medicalStuffPrescription.Episode.Patient.UniqueRefNo);

                string uniqueRefNo = "", password = "";
                var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                if (MedulaPasswordCheck == "TRUE")
                {
                    if ((input.medulaUsername != null && input.medulaUsername != "") || (input.medulaPassword != null && input.medulaPassword != ""))
                    {
                        eReceteListeSorgulaIstekDvo.doktorTcKimlikNo = Convert.ToInt64(input.medulaUsername);
                        uniqueRefNo = input.medulaUsername;
                        password = input.medulaPassword;
                    }
                    else
                    {
                        throw new TTUtils.TTException("Kullan�c� ad� veya �ifre bo� olamaz!");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(medicalStuffPrescription.ProcedureDoctor.ErecetePassword))
                    {
                        throw new TTUtils.TTException("E-Re�ete �ifreniz Bo� Olamaz");

                    }
                    uniqueRefNo = medicalStuffPrescription.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    eReceteListeSorgulaIstekDvo.doktorTcKimlikNo = Convert.ToInt64(uniqueRefNo);
                    if (!string.IsNullOrEmpty(medicalStuffPrescription.ProcedureDoctor.ErecetePassword))
                        password = medicalStuffPrescription.ProcedureDoctor.ErecetePassword;
                }

                TibbiMalzemeEReceteIslemleri.eReceteListeSorguCevapDVO response = TibbiMalzemeEReceteIslemleri.WebMethods.eReceteListeSorgulaSync(Sites.SiteLocalHost, uniqueRefNo, password, eReceteListeSorgulaIstekDvo);
                return response;

            }
        }


        void FillPrescriptionList(TTObjectContext objectContext, MedicalStuffPrescriptionFormViewModel viewModel)
        {
            //viewModel.MedicalStuffPrescriptionList = MedicalStuffPrescription.GetMedicalStuffPrescriptionListByID(viewModel._MedicalStuffPrescription.SubEpisode.ObjectID);//viewModel._medicalStuffPrescription.SubEpisode.ObjectID
        }
        [HttpPost]
        public string PrepareSignedDeletePrescriptionContent(PrepareSignedDeletePrescriptionContent_Input input)
        {
            string output = string.Empty;

            var signDeleteContent = MedicalStuffPrescription.GetERaporSignedDeleteRequestEReceteTakipNo(input.eReceteNo);
            output = signDeleteContent;
            return output;
        }

        [HttpPost]
        public bool SendSignedDeletePrescriptionContent(SendSignedDeletePrescriptionContent_Input input)
        {
            var signedData = Convert.FromBase64String(input.singContent);
            bool output = SendSignedDeleteEReceteWithEReceteTakipNo(signedData);
            return output;
        }

        public bool SendSignedDeleteEReceteWithEReceteTakipNo(byte[] signedContent)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;

            TibbiMalzemeEReceteIslemleri.imzaliEReceteSilIstekDVO ePrescriptionSignedDeleteRequest = new TibbiMalzemeEReceteIslemleri.imzaliEReceteSilIstekDVO();
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            ePrescriptionSignedDeleteRequest.tesisKodu = Convert.ToString(saglikTesisKodu);
            ePrescriptionSignedDeleteRequest.doktorTcKimlikNo = currentUser.UniqueNo;
            ePrescriptionSignedDeleteRequest.surumNumarasi = "1";
            ePrescriptionSignedDeleteRequest.imzaliErecete = signedContent;
            ePrescriptionSignedDeleteRequest.surumNumarasi = "1";

            TibbiMalzemeEReceteIslemleri.imzaliEReceteSilCevapDVO resOnay = TibbiMalzemeEReceteIslemleri.WebMethods.imzaliEReceteSilSync(Sites.SiteLocalHost, currentUser.UniqueNo, currentUser.ErecetePassword, ePrescriptionSignedDeleteRequest);
            if (resOnay != null)
            {
                if (resOnay.sonucKodu.Equals("0000"))
                    error = true;
            }

            return error;
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<OldMedicalStuffPrescriptionModel> GetOldMedicalStuffPrescriptions(string reportObjectId)
        {
            List<OldMedicalStuffPrescriptionModel> oldMedicalStuffPrescriptionModels = new List<OldMedicalStuffPrescriptionModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var oldPrescriptions = MedicalStuffPrescription.GetMedicalStuffPrescriptionsByReport(new Guid(reportObjectId));

                    foreach (MedicalStuffPrescription.GetMedicalStuffPrescriptionsByReport_Class oldPrescription in oldPrescriptions)
                    {
                        OldMedicalStuffPrescriptionModel model = new OldMedicalStuffPrescriptionModel();
                        model.ObjectID = (Guid)oldPrescription.ObjectID;
                        model.ActionDate = (DateTime)oldPrescription.ActionDate;
                        model.PrescriptionNo = oldPrescription.ReceteTakipNo;
                        model.ProcedureDoctor = oldPrescription.Proceduredoctor;
                        model.RaporTakipNo = oldPrescription.RaporTakipNo;
                        model.ReportNo = oldPrescription.ReportNo.ToString();
                        oldMedicalStuffPrescriptionModels.Add(model);
                    }
                    return oldMedicalStuffPrescriptionModels;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public bool SendSignedPrescriptionContent(SendSignedPrescriptionContent_Input input)
        {
            var signedData = Convert.FromBase64String(input.signContent);
            bool output = SendSignedERecete(signedData);
            return output;
        }

        public bool SendSignedERecete(byte[] signedContent)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                bool error = false;

                TibbiMalzemeEReceteIslemleri.imzaliEReceteGirisIstekDVO eReportSignedRequest = new TibbiMalzemeEReceteIslemleri.imzaliEReceteGirisIstekDVO();
                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eReportSignedRequest.tesisKodu = Convert.ToString(saglikTesisKodu);
                eReportSignedRequest.doktorTcKimlikNo = currentUser.UniqueNo;
                eReportSignedRequest.surumNumarasi = "1";
                eReportSignedRequest.imzaliErecete = signedContent;


                var b = TTUtils.SerializationHelper.XmlSerializeObject(eReportSignedRequest);

                TibbiMalzemeEReceteIslemleri.imzaliEReceteGirisCevapDVO resSorgu = TibbiMalzemeEReceteIslemleri.WebMethods.imzaliEReceteGirisSync(Sites.SiteLocalHost, currentUser.UniqueNo, currentUser.ErecetePassword, eReportSignedRequest);
                if (resSorgu != null)
                {
                    var a = TTUtils.SerializationHelper.XmlSerializeObject(resSorgu);
                    if (resSorgu.sonucKodu.Equals("0000"))
                    {
                        if (resSorgu.eReceteDVO != null)
                        {

                        }
                        error = true;
                    }
                }

                return error;
            }
        }

        /* [HttpPost]
         public string PrepareSignedPrescriptionContent(PrepareSignedPrescriptionContent_Input input)
         {
             string output = string.Empty;

             Guid? selectedEpisodeActionObjectID = Request.Headers.GetSelectedEpisodeActionID();

             var signSearchContent = MedicalStuffPrescription.GetEReceteRequestEReceteTakipNo(input.eReceteObjectID, selectedEpisodeActionObjectID);
             output = signSearchContent;
             return output;
         }*/

        [HttpPost]
        public string PrepareSignedSearchPrescriptionContent(PrepareSignedSearchPrescriptionContent_Input input)
        {
            string output = string.Empty;

            var signDeleteContent = MedicalStuffPrescription.GetERaporSignedSearchRequestEReceteTakipNo(input.eReceteTakipNo);
            output = signDeleteContent;
            return output;
        }

        [HttpPost]
        public bool SendSignedSearchPrescriptionContent(SendSignedSearchPrescriptionContent_Input input)
        {
            var signedData = Convert.FromBase64String(input.singContent);
            bool output = SendSignedSearchEReceteWithEReceteTakipNo(signedData);
            return output;
        }

        public bool SendSignedSearchEReceteWithEReceteTakipNo(byte[] signedContent)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;

            TibbiMalzemeEReceteIslemleri.imzaliEReceteSorguIstekDVO ePrescriptionSignedsearchRequest = new TibbiMalzemeEReceteIslemleri.imzaliEReceteSorguIstekDVO();
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            ePrescriptionSignedsearchRequest.tesisKodu = Convert.ToString(saglikTesisKodu);
            ePrescriptionSignedsearchRequest.doktorTcKimlikNo = currentUser.UniqueNo;
            ePrescriptionSignedsearchRequest.surumNumarasi = "1";
            ePrescriptionSignedsearchRequest.imzaliEreceteSorgula = signedContent;
            ePrescriptionSignedsearchRequest.surumNumarasi = "1";

            TibbiMalzemeEReceteIslemleri.imzaliEReceteSorguCevapDVO resOnay = TibbiMalzemeEReceteIslemleri.WebMethods.imzaliEReceteSorguSync(Sites.SiteLocalHost, currentUser.UniqueNo, currentUser.ErecetePassword, ePrescriptionSignedsearchRequest);
            if (resOnay != null)
            {
                if (resOnay.sonucKodu.Equals("0000"))
                    error = true;
            }

            return error;
        }

        [HttpPost]
        public MedulaResult eReceteGiris(MedicalStuffPrescriptionFormViewModel viewModel)
        {
            MedulaResult model = new MedulaResult();
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    TibbiMalzemeEReceteIslemleri.eReceteGirisIstekDVO _receteIstekDVO = new TibbiMalzemeEReceteIslemleri.eReceteGirisIstekDVO();
                    TibbiMalzemeEReceteIslemleri.eReceteDVO _eReceteDVO = new TibbiMalzemeEReceteIslemleri.eReceteDVO();
                    var medicalStuffPrescription = (MedicalStuffPrescription)objectContext.GetObject<MedicalStuffPrescription>(viewModel._MedicalStuffPrescription.ObjectID);

                    ResUser tabip = medicalStuffPrescription.ProcedureDoctor;
                    ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                    MedicalStuffReport medicalStuffReport = objectContext.GetObject<MedicalStuffReport>(medicalStuffPrescription.MedicalStuffReport.ObjectID);
                    SubEpisode subEpisode = medicalStuffPrescription.SubEpisode;
                    Episode episode = medicalStuffPrescription.Episode;
                    SubEpisodeProtocol subEpisodeProtocol = subEpisode.LastActiveSubEpisodeProtocolByCloneType;


                    _receteIstekDVO.tesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                    _receteIstekDVO.doktorTcKimlikNo = tabip.Person.UniqueRefNo.ToString();
                    _eReceteDVO.tesisKodu = _receteIstekDVO.tesisKodu;
                    if (subEpisodeProtocol != null && (subEpisodeProtocol.MedulaTakipNo == null || subEpisodeProtocol.MedulaTakipNo == ""))
                    {
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25844", "Hastan�n medula provizyon numaras� bulunmamaktad�r.Hastaya provizyon al�n�z."));
                    }

                    _eReceteDVO.protokolNo = medicalStuffPrescription.SubEpisode.ProtocolNo;
                    string provizyonTipi = subEpisodeProtocol.MedulaProvizyonTipi.provizyonTipiKodu;
                    if (provizyonTipi == "N")
                    {
                        _eReceteDVO.provizyonTipi = "1";
                    }
                    else if (provizyonTipi == "V")
                    {
                        _eReceteDVO.provizyonTipi = "2";
                    }
                    else if (provizyonTipi == "M")
                    {
                        _eReceteDVO.provizyonTipi = "3";
                    }
                    else if (provizyonTipi == "I")
                    {
                        _eReceteDVO.provizyonTipi = "4";
                    }
                    else if (provizyonTipi == "T")
                    {
                        _eReceteDVO.provizyonTipi = "5";
                    }
                    else if (provizyonTipi == "E")
                    {
                        _eReceteDVO.provizyonTipi = "6";
                    }
                    else if (subEpisodeProtocol.Payer.ID == 99)
                    {
                        _eReceteDVO.provizyonTipi = "7";
                    }
                    else if (subEpisode.Episode.Patient.YUPASSNO != null)
                    {
                        _eReceteDVO.provizyonTipi = "8";
                    }
                    else
                    {
                        _eReceteDVO.provizyonTipi = "1";
                    }

                    if (medicalStuffPrescription.Description != null && medicalStuffPrescription.DescriptionType != null)
                    {
                        TibbiMalzemeEReceteIslemleri.eReceteAciklamaDVO _aciklamaDVO = new TibbiMalzemeEReceteIslemleri.eReceteAciklamaDVO();
                        _aciklamaDVO.aciklamaTuru = (int)medicalStuffPrescription.DescriptionType;
                        _aciklamaDVO.aciklama = Common.GetTextOfRTFString(medicalStuffPrescription.Description.ToString());
                        _eReceteDVO.receteAciklama = _aciklamaDVO;
                    }
                    _eReceteDVO.receteTarihi = ((DateTime)medicalStuffPrescription.PrescriptionDate).ToString("dd.MM.yyyy");

                    TibbiMalzemeEReceteIslemleri.doktorDVO _doktorBilgisiDVO = new TibbiMalzemeEReceteIslemleri.doktorDVO();
                    _doktorBilgisiDVO.adi = tabip.Person != null ? tabip.Person.Name : "";
                    _doktorBilgisiDVO.bransAdi = tabip.GetSpeciality() != null ? tabip.GetSpeciality().Name : "";
                    _doktorBilgisiDVO.bransKodu = tabip.GetSpeciality() != null ? tabip.GetSpeciality().Code : "";
                    _doktorBilgisiDVO.soyadi = tabip.Person != null ? tabip.Person.Surname : "";
                    _doktorBilgisiDVO.tcKimlikNo = tabip.Person.UniqueRefNo.ToString();
                    _eReceteDVO.receteYazanDoktorBilgisi = _doktorBilgisiDVO;


                    if (subEpisodeProtocol.MedulaTedaviTuru.tedaviTuruKodu == "A")
                    {
                        _eReceteDVO.receteTuru = 1;
                    }
                    else if (subEpisodeProtocol.MedulaTedaviTuru.tedaviTuruKodu == "Y")
                    {
                        _eReceteDVO.receteTuru = 2;
                    }
                    else if (subEpisodeProtocol.MedulaTedaviTuru.tedaviTuruKodu == "G")
                    {
                        _eReceteDVO.receteTuru = 4;
                    }
                    _eReceteDVO.takipNo = subEpisodeProtocol.MedulaTakipNo;

                    List<TibbiMalzemeEReceteIslemleri.eTaniDVO> diagnosisList = new List<TibbiMalzemeEReceteIslemleri.eTaniDVO>();

                    if (medicalStuffPrescription.ReportDiagnosis.Count > 0)
                    {
                        foreach (ReportDiagnosis diagnosis in medicalStuffPrescription.ReportDiagnosis)
                        {
                            TibbiMalzemeEReceteIslemleri.eTaniDVO _taniDVO = new TibbiMalzemeEReceteIslemleri.eTaniDVO();
                            _taniDVO.taniKodu = diagnosis.Diagnose.Code;
                            _taniDVO.taniAdi = diagnosis.Diagnose.Name;
                            diagnosisList.Add(_taniDVO);
                        }
                        _eReceteDVO.taniListesi = diagnosisList.ToArray();
                    }
                    else
                    {
                        foreach (ReportDiagnosis diagnosis in medicalStuffPrescription.MedicalStuffReport.ReportDiagnosis)
                        {
                            TibbiMalzemeEReceteIslemleri.eTaniDVO _taniDVO = new TibbiMalzemeEReceteIslemleri.eTaniDVO();
                            _taniDVO.taniKodu = diagnosis.Diagnose.Code;
                            _taniDVO.taniAdi = diagnosis.Diagnose.Name;
                            diagnosisList.Add(_taniDVO);
                        }
                        _eReceteDVO.taniListesi = diagnosisList.ToArray();
                    }

                    if (medicalStuffPrescription.MedicalStuff.Count > 0)
                    {
                        List<TibbiMalzemeEReceteIslemleri.eReceteMalzemeGirisDVO> medicalStuffList = new List<TibbiMalzemeEReceteIslemleri.eReceteMalzemeGirisDVO>();
                        foreach (MedicalStuff medicalStuff in medicalStuffPrescription.MedicalStuff)
                        {
                            TibbiMalzemeEReceteIslemleri.eReceteMalzemeGirisDVO _malzemeGirisDVO = new TibbiMalzemeEReceteIslemleri.eReceteMalzemeGirisDVO();
                            TibbiMalzemeEReceteIslemleri.eMalzemeGirisDVO _malzemeDVO = new TibbiMalzemeEReceteIslemleri.eMalzemeGirisDVO();
                            _malzemeDVO.sutKodu = medicalStuff.MedicalStuffDef.Code;
                            _malzemeDVO.adet = (int)medicalStuff.StuffAmount;
                            _malzemeDVO.kullanimYeri = medicalStuff.MedicalStuffPlaceOfUsage != null ? medicalStuff.MedicalStuffPlaceOfUsage.Code : "F";
                            _malzemeDVO.kullanimPeriyodu = medicalStuff.PeriodUnit;
                            if (medicalStuff.PeriodUnitType == PeriodUnitTypeEnum.DayPeriod)
                            {
                                _malzemeDVO.kullanimPeriyodBirim = 1;
                            }
                            else if (medicalStuff.PeriodUnitType == PeriodUnitTypeEnum.WeekPeriod)
                            {
                                _malzemeDVO.kullanimPeriyodBirim = 2;
                            }
                            else if (medicalStuff.PeriodUnitType == PeriodUnitTypeEnum.MonthPeriod)
                            {
                                _malzemeDVO.kullanimPeriyodBirim = 3;
                            }
                            else if (medicalStuff.PeriodUnitType == PeriodUnitTypeEnum.YearPeriod)
                            {
                                _malzemeDVO.kullanimPeriyodBirim = 4;
                            }
                            else
                            {
                                _malzemeDVO.kullanimPeriyodBirim = 0;
                            }
                            _malzemeDVO.degistirmeRaporu = "H";
                            if (medicalStuff.MedicalStuffUsageType != null)
                                _malzemeDVO.kullanimSekli = medicalStuff.MedicalStuffUsageType.Code;
                            _malzemeGirisDVO.receteMalzeme = _malzemeDVO;
                            _malzemeGirisDVO.raporId = Convert.ToInt32(medicalStuffPrescription.MedicalStuffReport.RaporTakipNo);
                            medicalStuffList.Add(_malzemeGirisDVO);
                        }
                        _eReceteDVO.malzemeListesi = medicalStuffList.ToArray();
                    }

                    _eReceteDVO.tcKimlikNo = Convert.ToInt64(medicalStuffPrescription.Episode.Patient.UniqueRefNo);
                    _receteIstekDVO.eReceteDVO = _eReceteDVO;


                    string username = "";
                    string password = "";
                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((viewModel.medulaUsername != null && viewModel.medulaUsername != "") || (viewModel.medulaPassword != null && viewModel.medulaPassword != ""))
                        {
                            username = viewModel.medulaUsername;
                            password = viewModel.medulaPassword;
                            _receteIstekDVO.doktorTcKimlikNo = viewModel.medulaUsername;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullan�c� ad� veya �ifre bo� olamaz!");
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(medicalStuffPrescription.ProcedureDoctor.ErecetePassword))
                        {
                            throw new TTUtils.TTException("E-Re�ete �ifreniz Bo� Olamaz");

                        }
                        username = medicalStuffPrescription.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        if (!string.IsNullOrEmpty(medicalStuffPrescription.ProcedureDoctor.ErecetePassword))
                            password = medicalStuffPrescription.ProcedureDoctor.ErecetePassword;
                    }


                    TibbiMalzemeEReceteIslemleri.eReceteGirisCevapDVO response = TibbiMalzemeEReceteIslemleri.WebMethods.eReceteGirisSync(TTObjectClasses.Sites.SiteLocalHost, username, password, _receteIstekDVO);

                    if (response != null)
                    {
                        medicalStuffPrescription.ReceteGelenXML = TTUtils.SerializationHelper.XmlSerializeObject(response);
                        medicalStuffPrescription.ReceteGidenXML = TTUtils.SerializationHelper.XmlSerializeObject(_receteIstekDVO);


                        //medicalStuffPrescription.CurrentStateDefID = MedicalStuffPrescription.States.New;
                        if (response.sonucKodu == "0000")
                        {
                            ReportDiagnosisServiceController a = new ReportDiagnosisServiceController();
                            a.SaveDiagnosis(viewModel.reportDiagnosisFormViewModel, medicalStuffPrescription);
                            objectContext.Update();
                            medicalStuffPrescription.ReceteTakipNo = response.eReceteDVO.eReceteNo;
                            medicalStuffPrescription.CurrentStateDefID = MedicalStuffPrescription.States.Completed;
                            objectContext.Save();
                        }
                        model.SonucKodu = response.sonucKodu;
                        model.SonucMesaji = response.sonucMesaji;
                        if (response.eReceteDVO != null)
                            model.TakipNo = response.eReceteDVO.eReceteNo;
                    }
                    viewModel._MedicalStuffPrescription = medicalStuffPrescription;


                    return model;
                }
            }
            catch (Exception e)
            {
                if (e != null)
                    TTUtils.InfoMessageService.Instance.ShowMessage(e.ToString());
                return null;
            }
        }
        public class MedulaResult
        {
            private bool _succes;
            private string _basvuruNo;
            private string _takipNo;
            private string _sonucMesaji;
            private string _sonucKodu;
            private string _bagliTakipNo;
            private Guid _SEPObjectID;

            public Guid SEPObjectID
            {
                get
                {
                    return this._SEPObjectID;
                }
                set
                {
                    this._SEPObjectID = value;
                }
            }

            public bool Succes
            {
                get
                {
                    return this._succes;
                }
                set
                {
                    this._succes = value;
                }
            }
            public string BasvuruNo
            {
                get
                {
                    return this._basvuruNo;
                }
                set
                {
                    this._basvuruNo = value;
                }
            }
            public string TakipNo
            {
                get
                {
                    return this._takipNo;
                }
                set
                {
                    this._takipNo = value;
                }
            }
            public string SonucMesaji
            {
                get
                {
                    return this._sonucMesaji;
                }
                set
                {
                    this._sonucMesaji = value;
                }
            }
            public string SonucKodu
            {
                get
                {
                    return this._sonucKodu;
                }
                set
                {
                    this._sonucKodu = value;
                }
            }
            public string BagliTakipNo
            {
                get
                {
                    return this._bagliTakipNo;
                }
                set
                {
                    this._bagliTakipNo = value;
                }
            }
            public MedulaResult()
            {
                this.SonucKodu = "";
                this.SonucMesaji = "";
                this.Succes = false;
                this.TakipNo = "";
                this.BasvuruNo = "";
            }
        }
    }
}

namespace Core.Models
{
    public partial class MedicalStuffPrescriptionFormViewModel
    {
        public bool IsSuperUser
        {
            get;
            set;
        }

        public Guid ToState
        {
            get;
            set;
        }
        public ReportDiagnosisFormViewModel reportDiagnosisFormViewModel = new ReportDiagnosisFormViewModel();

        /*public BindingList<MedicalStuffPrescription.GetMedicalStuffPrescriptionListByID_Class> MedicalStuffPrescriptionList
        {
            get;
            set;
        }*/
        public Guid episode
        {
            get;
            set;
        }
        public Guid reportEpisodeAction
        {
            get;
            set;
        }
        public List<OldMedicalStuffPrescriptionModel> oldMedicalStuffPrescriptions { get; set; }
        public MedicalStuffDefinitionObject[] medicalStuffs { get; set; }

        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }

    }

    public class AddDiagnosisToPrescriptionClass
    {
        public DiagnosisDefinition Diagnose { get; set; }
        public MedicalStuffPrescription PrescriptionObject { get; set; }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
    }

    public class eReceteListeSorgulaClass
    {        
        public MedicalStuffPrescription PrescriptionObject { get; set; }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
    }

    public class MedicalStuffDefinitionObject
    {
        public Guid MedicalStuffDefId { get; set; }
        public string MedicalStuffDefName { get; set; }
        public string MedicalStuffDefCode { get; set; }
        public int? MedicalStuffAmount { get; set; }
        public string PeriodUnit { get; set; }
        public PeriodUnitTypeEnum? PeriodUnitType { get; set; }
        public string MedicalStuffPlaceOfUsage { get; set; }

    }

    public class SendSignedPrescriptionContent_Input
    {
        public string signContent { get; set; }
    }

    public class PrepareSignedSearchPrescriptionContent_Input
    {
        public string eReceteTakipNo
        {
            get;
            set;
        }

    }
    public class SendSignedSearchPrescriptionContent_Input
    {
        public string singContent
        {
            get;
            set;
        }
    }
    public class PrepareSignedDescriptionPrescriptionContent_Input
    {
        public string eReceteNo
        {
            get;
            set;
        }
        public int drugDescriptionType
        {
            get;
            set;
        }
        public string desciption
        {
            get;
            set;
        }

    }
    public class SendSignedDescriptionPrescriptionContent_Input
    {
        public string singContent
        {
            get;
            set;
        }

    }
    public class PrepareSignedPrescriptionContent_Input
    {
        public Guid eReceteObjectID { get; set; }
    }
    public class OldMedicalStuffPrescriptionModel
    {
        public Guid ObjectID { get; set; }
        public string PrescriptionNo { get; set; }
        public string ReportNo { get; set; }
        public string RaporTakipNo { get; set; }
        public string ProcedureDoctor { get; set; }
        public DateTime ActionDate { get; set; }
        public bool? IsSendedMedula { get; set; }
    }
}
