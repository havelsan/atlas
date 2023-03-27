//$39A93688
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Newtonsoft.Json;

namespace Core.Controllers
{
    public partial class PathologyRequestServiceController
    {
        partial void PreScript_PathologyRequestMainForm(PathologyRequestMainFormViewModel viewModel, PathologyRequest pathologyRequest, TTObjectContext objectContext)
        {
            //Patoloji Red Nedenleri
            BindingList<ReasonForPathologyRejection> rList = TTObjectClasses.ReasonForPathologyRejection.GetAll(objectContext);
            viewModel.ReasonForRejectMaterialList = rList.ToArray();
            if (string.IsNullOrEmpty(Convert.ToString(pathologyRequest.AcceptionDate)))
                pathologyRequest.AcceptionDate = DateTime.Now;


            BindingList<ResUser.SpecialistDoctorListNQL_Class> pList = ResUser.SpecialistDoctorListNQL(" AND USERRESOURCES.RESOURCE = '" + pathologyRequest.MasterResource.ObjectID.ToString() + "'");

            viewModel.ProcedureDoctorList = new List<PathologyTest>();
            foreach(ResUser.SpecialistDoctorListNQL_Class pd in pList)
            {
                PathologyTest doctor = new PathologyTest();
                doctor.ObjectID = new Guid(pd.ObjectID.ToString());
                doctor.Name = pd.Name;
                viewModel.ProcedureDoctorList.Add(doctor);
            }

            if (pathologyRequest.ProcedureDoctor != null)
                viewModel.ProcedureDoctorID = pathologyRequest.ProcedureDoctor.ObjectID;

            ContextToViewModel(viewModel, objectContext);
            //Materyal stateleri
            for (int i = 0; i < pathologyRequest.PathologyMaterials.Count; i++)
            {
                if (pathologyRequest.PathologyMaterials[i].CurrentStateDefID == PathologyMaterial.States.Accept)
                {
                    pathologyRequest.PathologyMaterials[i].IsAccepted = true;
                    pathologyRequest.PathologyMaterials[i].IsRejected = false;
                }
                else if (pathologyRequest.PathologyMaterials[i].CurrentStateDefID == PathologyMaterial.States.Reject)
                {
                    pathologyRequest.PathologyMaterials[i].IsAccepted = false;
                    pathologyRequest.PathologyMaterials[i].IsRejected = true;
                }
                else
                {
                    pathologyRequest.PathologyMaterials[i].IsAccepted = false;
                    pathologyRequest.PathologyMaterials[i].IsRejected = false;
                }
            }

            //SelectedPathologyMaterialArray PathologyRequestin Pathologylerini çek
            List<TempPathologyMaterialViewModel> tempList = new List<TempPathologyMaterialViewModel>();
            int count = 0;
            foreach (Pathology p in pathologyRequest.Pathologies)
            {
                count++;
                foreach (PathologyMaterial m in p.PathologyMaterial)
                {
                    TempPathologyMaterialViewModel material = new TempPathologyMaterialViewModel();
                    material.GroupCount = count;
                    material.MaterialObjectID = m.ObjectID;
                    material.DateOfSampleTaken = Convert.ToDateTime(m.DateOfSampleTaken);
                    material.MaterialNumber = m.MaterialNumber;
                    material.YerlesimYeri = m.YerlesimYeri.TOPOGRAFIKODU + "-" + m.YerlesimYeri.KODTANIMI;
                    
                    material.AlindigiDokununTemelOzelligi = m.AlindigiDokununTemelOzelligi == null ? "": m.AlindigiDokununTemelOzelligi.ADI;
                    material.NumuneAlinmaSekli = m.NumuneAlinmaSekli == null ? "" : m.NumuneAlinmaSekli.ADI;
                    material.ClinicalFindings = m.ClinicalFindings;
                    material.Description = m.Description;
                    tempList.Add(material);
                }
            }

            viewModel.SelectedPathologyMaterialArray = tempList.ToArray();
            //PathologyTestProcedures -> İstek aşamasında eklenmiş işlemleri göstermek için
            List<vmRequestedPathologyProcedure> tempProcedure = new List<vmRequestedPathologyProcedure>();
            foreach (PathologyMaterial material in pathologyRequest.PathologyMaterials)
            {
                for (int i = 0; i < material.PathologyTestProcedure.Count; i++)
                {
                    vmRequestedPathologyProcedure procedure = new vmRequestedPathologyProcedure();
                    procedure.MaterialObjectID = material.ObjectID;
                    procedure.SubActionProcedureObjectId = material.PathologyTestProcedure[i].ObjectID;
                    procedure.ProcedureCode = material.PathologyTestProcedure[i].ProcedureObject.Code;
                    procedure.ProcedureName = material.PathologyTestProcedure[i].ProcedureObject.Name;
                    procedure.Amount = Convert.ToInt32(material.PathologyTestProcedure[i].Amount);
                    EpisodeAction ea = (EpisodeAction)objectContext.GetObject(material.PathologyRequest.ObjectID, "EpisodeAction");
                    if (ea.SubEpisode != null)
                    {
                        if (ea.SubEpisode.OpenSubEpisodeProtocol != null)
                        {
                            ProcedureDefinition ttProcedureDefinition = (ProcedureDefinition)objectContext.GetObject(material.PathologyTestProcedure[i].ProcedureObject.ObjectID, "ProcedureDefinition");
                            if (ttProcedureDefinition.GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, DateTime.Now) != null)
                            {
                                procedure.UnitPrice = (double)ttProcedureDefinition.GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, DateTime.Now);
                            }
                        }
                    }

                    procedure.RequestDate = Convert.ToDateTime(material.PathologyTestProcedure[i].CreationDate);
                    procedure.RequestBy = material.PathologyTestProcedure[i].RequestedByUser.Name;
                    procedure.ProcedureUser = "";
                    procedure.ProcedureDefObjectID = material.PathologyTestProcedure[i].ProcedureObject.ObjectID;
                    procedure.MasterResource = pathologyRequest.MasterResource.Name;
                    procedure.CurrentStateDefID = (Guid)material.PathologyTestProcedure[i].CurrentStateDefID;
                    procedure.IsPaid = material.PathologyTestProcedure[i].Paid();
                    tempProcedure.Add(procedure);
                }
            }

            viewModel._ProcedureArray = tempProcedure.ToArray();
          
        }

        partial void AfterContextSaveScript_PathologyRequestMainForm(PathologyRequestMainFormViewModel viewModel, PathologyRequest pathologyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

            

            if (viewModel.SelectedPathologyMaterialArray.Length > 0)
                pathologyRequest.CurrentStateDefID = PathologyRequest.States.Procedure;
            else if(viewModel.SelectedPathologyMaterialArray.Length == 0 && viewModel.RejectedMaterialArray.Length > 0)
                pathologyRequest.CurrentStateDefID = PathologyRequest.States.Cancelled;

            for (int j = 0; j < pathologyRequest.Pathologies.Count; j++)
            {
                Pathology pathology = (Pathology)objectContext.GetObject(pathologyRequest.Pathologies[j].ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof (Pathology)));

                if (TTObjectClasses.SystemParameter.GetParameterValue("PATOLOJICOKLUPROTOKOL", "FALSE").ToUpper() == "TRUE") // True ise Patoloji ve Sitoloji sayaçları ayrı olacak
                {
                    //Biyopsi ve Sitoloji olarak ayrılacak
                    if (pathology.IsBiopsy == true)
                        pathology.MatPrtNoString = pathology.MaterialPrtNoPrefix + pathology.BiopsySeqNo.Value.ToString() + "/" + pathology.MaterialPrtNoPostFix;
                    else if(pathology.IsCytology == true)
                        pathology.MatPrtNoString = pathology.MaterialPrtNoPrefix + pathology.CytologySeqNo.Value.ToString() + "/" + pathology.MaterialPrtNoPostFix;


                }
                else
                    pathology.MatPrtNoString = pathology.SeqNo.Value.ToString() + "/" + pathology.MaterialPrtNoPostFix;
          
            }

            objectContext.Save();
        }

        partial void PostScript_PathologyRequestMainForm(PathologyRequestMainFormViewModel viewModel, PathologyRequest pathologyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //if (transDef != null && transDef.FromStateDefID == PathologyRequest.States.Accept && transDef.ToStateDefID == PathologyRequest.States.Cancelled)
           // {
                //Reddedilen materyaller
            //    foreach (RejectedMaterialsViewModel rejectedMaterial in viewModel.RejectedMaterialArray)
            //    {
            //        PathologyMaterial rejMaterial = (PathologyMaterial)objectContext.GetObject(rejectedMaterial.MaterialObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(PathologyMaterial)));
            //        ReasonForPathologyRejection reason = (ReasonForPathologyRejection)objectContext.GetObject(rejectedMaterial.RejectReasonID, TTObjectDefManager.Instance.GetObjectDef(typeof(ReasonForPathologyRejection)));
            //        rejMaterial.ReasonForPathologyRejection = reason;
            //        rejMaterial.CurrentStateDefID = PathologyMaterial.States.Reject;

            //        //Reddedilen materiallerin üzerinde işlem varsa işlemlerin statüsü cancelled olmalı
            //        foreach (PathologyTestProcedure item in rejMaterial.PathologyTestProcedure)
            //        {
            //            PathologyTestProcedure procedure = (PathologyTestProcedure)objectContext.GetObject(item.ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(PathologyTestProcedure)));
            //            procedure.CurrentStateDefID = PathologyTestProcedure.States.Cancelled;
            //            procedure.ReasonOfCancel = reason.Description;

            //            if (procedure.FromClinic == true)// Eğer işlem klinikten istendi ise doktora bildirim gönderilecek.
            //            {
            //                string messageText = "";
            //                List<string> doctorlist = new List<string>();
            //                doctorlist.Add(pathologyRequest.RequestDoctor.ObjectID.ToString());

            //                messageText += "Sayın Dr. " + pathologyRequest.RequestDoctor.Name + ", ";
            //                messageText += DateTime.Now.ToString("dd MMMM yyyy") + " tarihinde ";
            //                messageText += pathologyRequest.SubEpisode.ProtocolNo + " kabul numaralı ";
            //                messageText += pathologyRequest.SubEpisode.Episode.Patient != null ? ("'" + pathologyRequest.SubEpisode.Episode.Patient.FullName + "' hastası için ") : "";
            //                messageText += "istemiş olduğunuz " + procedure.ProcedureObject.Code + "-" + procedure.ProcedureObject.Name + " işlemi, " + reason.Description + " nedeni ile reddedilmiştir.";

            //                TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
            //                atlasNotification.users = doctorlist;
            //                atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
            //                atlasNotification.contentType = TTUtils.AtlasContentType.Notification;

            //                atlasNotification.content = messageText;
            //                string notificationStr = JsonConvert.SerializeObject(atlasNotification);
            //                try
            //                {
            //                    TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);
            //                }
            //                catch { }
            //            }
            //        }
            //    }

            //}



            //if (transDef != null && transDef.FromStateDefID == PathologyRequest.States.Accept && transDef.ToStateDefID == PathologyRequest.States.Procedure)
            //{

                //Reddedilen materyaller
                foreach (RejectedMaterialsViewModel rejectedMaterial in viewModel.RejectedMaterialArray)
                {
                    PathologyMaterial rejMaterial = (PathologyMaterial)objectContext.GetObject(rejectedMaterial.MaterialObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(PathologyMaterial)));
                    ReasonForPathologyRejection reason = (ReasonForPathologyRejection)objectContext.GetObject(rejectedMaterial.RejectReasonID, TTObjectDefManager.Instance.GetObjectDef(typeof(ReasonForPathologyRejection)));
                    rejMaterial.ReasonForPathologyRejection = reason;
                    rejMaterial.CurrentStateDefID = PathologyMaterial.States.Reject;

                    //Reddedilen materiallerin üzerinde işlem varsa işlemlerin statüsü cancelled olmalı
                    foreach (PathologyTestProcedure item in rejMaterial.PathologyTestProcedure)
                    {
                        PathologyTestProcedure procedure = (PathologyTestProcedure)objectContext.GetObject(item.ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(PathologyTestProcedure)));
                        procedure.CurrentStateDefID = PathologyTestProcedure.States.Cancelled;
                        procedure.ReasonOfCancel = reason.Description;

                        if (procedure.FromClinic == true)// Eğer işlem klinikten istendi ise doktora bildirim gönderilecek.
                        {
                            string messageText = "";
                            List<string> doctorlist = new List<string>();
                            doctorlist.Add(pathologyRequest.RequestDoctor.ObjectID.ToString());

                            messageText += "Sayın Dr. " + pathologyRequest.RequestDoctor.Name + ", ";
                            messageText += DateTime.Now.ToString("dd MMMM yyyy") + " tarihinde ";
                            messageText += pathologyRequest.SubEpisode.ProtocolNo + " kabul numaralı ";
                            messageText += pathologyRequest.SubEpisode.Episode.Patient != null ? ("'" + pathologyRequest.SubEpisode.Episode.Patient.FullName + "' hastası için ") : "";
                            messageText += "istemiş olduğunuz " + procedure.ProcedureObject.Code + "-" + procedure.ProcedureObject.Name + " işlemi, " + reason.Description + " nedeni ile reddedilmiştir.";

                            TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
                            atlasNotification.users = doctorlist;
                            atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
                            atlasNotification.contentType = TTUtils.AtlasContentType.Notification;

                            atlasNotification.content = messageText;
                            string notificationStr = JsonConvert.SerializeObject(atlasNotification);
                            try
                            {
                                TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);
                            }
                            catch { }
                        }
                    }
                }
                //Kabul edilen materyaller
                if (viewModel.SelectedPathologyMaterialArray.Length > 0)
                {
                    int count = viewModel.SelectedPathologyMaterialArray[viewModel.SelectedPathologyMaterialArray.Length - 1].GroupCount;
                    List<PathologyObject> createdPatObj = new List<PathologyObject>(); //Bu objectin countı kadar patoloji objesi oluşturulacak


                    bool biopsyFlag = false;
                    bool cytologyFlag = false;
                    for (int i = 1; i <= count; i++)
                    {
                        biopsyFlag = false;
                        cytologyFlag = false;
                        List<Guid> tempList = new List<Guid>();
                        foreach (TempPathologyMaterialViewModel selectedMaterial in viewModel.SelectedPathologyMaterialArray)
                        {


                            if (i == selectedMaterial.GroupCount)
                            {
                                tempList.Add(selectedMaterial.MaterialObjectID);
                                if (selectedMaterial.BiopsyCheck)
                                    biopsyFlag = true;
                                else if (selectedMaterial.CytologyCheck)
                                    cytologyFlag = true;
                            }
                        }

                        PathologyObject a = new PathologyObject();
                        a.tempList = tempList;//Oluşturulacak patolojinin içindeki materyaller 
                        if (biopsyFlag)
                            a.isBiopsy = true;
                        else if (cytologyFlag)
                            a.isCytology = true;

                        createdPatObj.Add(a);
                    }

                    foreach (PathologyObject patObj in createdPatObj)
                    {
                        var pathology = new Pathology(objectContext);
                        pathology.SetMandatoryEpisodeActionProperties(pathologyRequest, pathologyRequest.MasterResource, false);
                        pathology.PathologyRequest = pathologyRequest;
                        pathology.CurrentStateDefID = Pathology.States.Procedure;
                        pathology.MaterialResponsible = pathologyRequest.MaterialResponsible;
                        pathology.MasterAction = pathologyRequest.MasterAction;
                        if (viewModel.ProcedureDoctorID != Guid.Empty)
                        {
                            ResUser pDoctor = (ResUser)objectContext.GetObject(viewModel.ProcedureDoctorID, TTObjectDefManager.Instance.GetObjectDef(typeof(ResUser)));
                            pathologyRequest.ProcedureDoctor = pDoctor;
                            pathology.ProcedureDoctor = pDoctor;
                        }// objectContext.Save();

                        bool hasFrozen = false;

                        foreach (Guid materialObjectID in patObj.tempList)
                        {
                            PathologyMaterial material = (PathologyMaterial)objectContext.GetObject(materialObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(PathologyMaterial)));
                            material.Pathology = pathology;
                            material.CurrentStateDefID = PathologyMaterial.States.Accept;
                            
                            //İstem tarafından eklenen işlemlerin episodeacttionını pathology olarak set et
                            if (material.NumuneAlinmaSekli.KODU == "4") //Skrsde frozenın kodu değişirse buranın güncellenmesi gerekir
                                hasFrozen = true;

                            for (int j = 0; j < material.PathologyTestProcedure.Count; j++)
                            {
                                var reqProcedure = (PathologyTestProcedure)objectContext.GetObject(material.PathologyTestProcedure[j].ObjectID, "PathologyTestProcedure");
                                reqProcedure.EpisodeAction = pathology;
                                reqProcedure.PathologyMaterial = material;
                                reqProcedure.PathologyRequest = pathology.PathologyRequest;
                                reqProcedure.ProcedureDoctor = pathology.ProcedureDoctor;
                                reqProcedure.CurrentStateDefID = PathologyTestProcedure.States.New;
                                reqProcedure.Pathology = pathology;
                            }

                            foreach (vmRequestedPathologyProcedure procedure in viewModel._ProcedureArray)
                            {
                                if (procedure.MaterialObjectID == materialObjectID)
                                {
                                    if (procedure.SubActionProcedureObjectId == Guid.Empty)
                                    {
                                        var pathologyTest = new PathologyTestProcedure(objectContext);
                                        var pathologyDef = (PathologyTestDefinition)objectContext.GetObject(procedure.ProcedureDefObjectID, "PathologyTestDefinition");
                                        pathologyTest.ProcedureObject = pathologyDef;
                                        pathologyTest.Amount = procedure.Amount;
                                        pathologyTest.EpisodeAction = pathology;
                                        pathologyTest.PathologyMaterial = material;
                                        pathologyTest.PathologyRequest = pathology.PathologyRequest;
                                        pathologyTest.ProcedureDoctor = pathology.ProcedureDoctor;
                                        pathologyTest.ActionDate = DateTime.Now;
                                        pathologyTest.CurrentStateDefID = PathologyTestProcedure.States.New;
                                        pathologyTest.Pathology = pathology;
                                    }
                                    else
                                    {
                                        var importedProcedure = (PathologyTestProcedure)objectContext.GetObject(procedure.SubActionProcedureObjectId, "PathologyTestProcedure");
                                        importedProcedure.Amount = procedure.Amount;
                                        importedProcedure.EpisodeAction = pathology;
                                        importedProcedure.PathologyMaterial = material;
                                        importedProcedure.PathologyRequest = pathology.PathologyRequest;
                                        importedProcedure.ProcedureDoctor = pathology.ProcedureDoctor;
                                        importedProcedure.CurrentStateDefID = PathologyTestProcedure.States.New;
                                        importedProcedure.Pathology = pathology;
                                    }
                                }
                            }

                            pathology.HasFrozen = hasFrozen;

                        }

                        //Protokol Numarası 
                        if (TTObjectClasses.SystemParameter.GetParameterValue("PATOLOJICOKLUPROTOKOL", "FALSE").ToUpper() == "TRUE") // True ise Patoloji ve Sitoloji sayaçları ayrı olacak
                        {
                            //Biyopssi mi Sitoloji mi?
                            if (patObj.isBiopsy)
                            {
                                pathology.IsBiopsy = true;
                                pathology.BiopsySeqNo.GetNextValue(Common.RecTime().Year);
                                pathology.MaterialPrtNoPostFix = Common.RecTime().Year.ToString();
                                pathology.MaterialPrtNoPrefix = "B";

                            }
                            else if (patObj.isCytology)
                            {
                                pathology.IsCytology = true;
                                pathology.CytologySeqNo.GetNextValue(Common.RecTime().Year);
                                pathology.MaterialPrtNoPostFix = Common.RecTime().Year.ToString();
                                pathology.MaterialPrtNoPrefix = "S";
                            }



                        }
                        else
                        {
                            pathology.SeqNo.GetNextValue(Common.RecTime().Year);
                            pathology.MaterialPrtNoPostFix = Common.RecTime().Year.ToString();
                        }

                    }

                   

                }

          
        }

        [HttpGet]
        public vmRequestedPathologyProcedure[] loadRequestedProcedureToPathologyMaterial(Guid PathologyMaterialID)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            List<vmRequestedPathologyProcedure> procedureList = new List<vmRequestedPathologyProcedure>();
            PathologyMaterial material = (PathologyMaterial)objContext.GetObject(PathologyMaterialID, "PathologyMaterial");
            for (int i = 0; i < material.PathologyTestProcedure.Count; i++)
            {
                vmRequestedPathologyProcedure vmRequestedProcedure = new vmRequestedPathologyProcedure();
                vmRequestedProcedure.SubActionProcedureObjectId = material.PathologyTestProcedure[i].ObjectID;
                vmRequestedProcedure.CurrentStateDefID = (Guid)material.PathologyTestProcedure[i].CurrentStateDefID;
                vmRequestedProcedure.MaterialObjectID = material.ObjectID;
                vmRequestedProcedure.ProcedureCode = material.PathologyTestProcedure[i].ProcedureObject.Code;
                vmRequestedProcedure.ProcedureName = material.PathologyTestProcedure[i].ProcedureObject.Name;
                vmRequestedProcedure.RequestDate = Convert.ToDateTime(material.PathologyTestProcedure[i].CreationDate);
                vmRequestedProcedure.RequestBy = material.PathologyTestProcedure[i].RequestedByUser.Name;
                vmRequestedProcedure.Amount = Convert.ToInt32(material.PathologyTestProcedure[i].Amount);
                vmRequestedProcedure.ProcedureUser = ""; // patolojinin işlemi yapan doktoru gelecek
                vmRequestedProcedure.ProcedureDefObjectID = material.PathologyTestProcedure[i].ProcedureObject.ObjectID; //new Guid(ProcedureDefObjectId);
                EpisodeAction ea = (EpisodeAction)objContext.GetObject(material.PathologyRequest.ObjectID, "EpisodeAction");
                vmRequestedProcedure.MasterResource = ea.MasterResource.Name; //patolojinin resourceu olacak
                if (ea.SubEpisode != null)
                {
                    if (ea.SubEpisode.OpenSubEpisodeProtocol != null)
                    {
                        ProcedureDefinition ttProcedureDefinition = (ProcedureDefinition)objContext.GetObject(material.PathologyTestProcedure[i].ProcedureObject.ObjectID, "ProcedureDefinition");
                        if (ttProcedureDefinition.GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, DateTime.Now) != null)
                        {
                            vmRequestedProcedure.UnitPrice = (double)ttProcedureDefinition.GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, DateTime.Now);
                        }
                    }
                }

                procedureList.Add(vmRequestedProcedure);
            }

            return procedureList.ToArray();
        }

        [HttpGet]
        public PathologyTest[] GetPathologyTestDefinitions()
        {
            PathologyTest[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<PathologyTestDefinition>().ToArray();
                var query =
                    from i in ttList
                    orderby i.Code
                    select new PathologyTest{ObjectID = i.ObjectID, Name = i.Code + "-" + i.Name, };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        public MaterialBarcodeInfo[] GetMaterialBarcodeInfo(Guid PathologyRequestID)
        {
            List<MaterialBarcodeInfo> result = new List<MaterialBarcodeInfo>();
            using (var objectContext = new TTObjectContext(true))
            {
                PathologyRequest pathologyRequest = (PathologyRequest)objectContext.GetObject(PathologyRequestID, "PathologyRequest");

                foreach (PathologyMaterial material in pathologyRequest.PathologyMaterials)
                {
                    if (material.CurrentStateDefID == PathologyMaterial.States.Accept)
                    {
                        MaterialBarcodeInfo m = new MaterialBarcodeInfo();
                        m.PatientID = pathologyRequest.Episode.Patient.UniqueRefNo == null ? "":pathologyRequest.Episode.Patient.UniqueRefNo.ToString();
                        m.PatientNameSurname = pathologyRequest.Episode.Patient.Name + " " + pathologyRequest.Episode.Patient.Surname;
                        m.ProtocolNo = material.Pathology.MatPrtNoString;
                        m.RequestDoctorName = pathologyRequest.RequestDoctor.Name;
                        m.RequestUnit = pathologyRequest.FromResource.Name;
                        m.MaterialAcceptionDate = Convert.ToDateTime(pathologyRequest.AcceptionDate).ToString("dd.MM.yy HH:mm");
                        m.DateOfSampleTaken = Convert.ToDateTime(material.DateOfSampleTaken).ToString("dd.MM.yy HH:mm"); 
                        m.Organ = material.YerlesimYeri.TOPOGRAFIKODU + "-" + material.YerlesimYeri.KODTANIMI;
                        m.MaterialArchiveNo = material.MaterialNumber;
                        m.Barcode = material.MaterialNumber;
                        result.Add(m);
                    }
                    
                }
            }
            return result.ToArray();
        }

        [HttpGet]
        public PatientBarcodeInfo GetPatientAdmissionBarcodeInfo(Guid PathologyRequestID)
        {
            PatientBarcodeInfo result = new PatientBarcodeInfo();
            using (var objectContext = new TTObjectContext(true))
            {
                PathologyRequest pathologyRequest = (PathologyRequest)objectContext.GetObject(PathologyRequestID, "PathologyRequest");

                PatientAdmission patientAdmission = pathologyRequest.SubEpisode.PatientAdmission;
                result.BirthDate = pathologyRequest.Episode.Patient.BirthDate == null ? "" : Convert.ToDateTime(pathologyRequest.Episode.Patient.BirthDate).ToString("dd.MM.yyyy");
                result.Age = pathologyRequest.Episode.Patient.CalculatedAge;
                result.DNo = patientAdmission.DocumentNumber;
                result.DoctorName = patientAdmission.ProcedureDoctor.Name;
                result.Gender = pathologyRequest.Episode.Patient.Sex.ADI;
                var sep = pathologyRequest.SubEpisode.FirstSubEpisodeProtocol;
                if (sep == null)
                    sep = pathologyRequest.SubEpisode.AddSubEpisodeProtocol();

                result.GSSNo = sep.MedulaTakipNo == null ? "" : sep.MedulaTakipNo;
                result.TAKIPNO = sep.MedulaTakipNo == null ? "" : sep.MedulaTakipNo;
                result.IslemNo = patientAdmission.FirstSubEpisode?.ProtocolNo;
                result.HospitalName = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "TRUE"));
                result.DNo = patientAdmission.Episode.Patient.ID.ToString();

                PatientAdmission lastPA = PatientAdmission.GetLastPatientAdmission(objectContext, patientAdmission.ObjectID, patientAdmission.Episode.Patient.ObjectID).FirstOrDefault();
                if (lastPA != null)
                {
                    if (patientAdmission.AdmissionStatus == AdmissionStatusEnum.DisaridanGelenKonsultasyon || patientAdmission.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol)
                    {

                        result.Kurum = lastPA.Payer.Name;
                    }
                    else
                        result.Kurum = patientAdmission.Payer.Name;
                }
                else
                    result.Kurum = patientAdmission.Payer.Name;

                if (patientAdmission.Episode.Patient.UniqueRefNo != null)
                    result.PatientIdentifier = patientAdmission.Episode.Patient.UniqueRefNo.ToString();
                else if (patientAdmission.Episode.Patient.PassportNo != null)
                    result.PatientIdentifier = patientAdmission.Episode.Patient.PassportNo.ToString();

                result.PatientName = patientAdmission.Episode.Patient.Name + " " + patientAdmission.Episode.Patient.Surname;
                result.BirthPlace = patientAdmission.Episode.Patient.BirthPlace != null ? patientAdmission.Episode.Patient.BirthPlace : patientAdmission.Episode.Patient.OtherBirthPlace != null ? patientAdmission.Episode.Patient.OtherBirthPlace : "-";

                result.PoliclinicName = patientAdmission.Policlinic.Name;
                result.SiraNo = patientAdmission.AdmissionQueueNumber != null ? patientAdmission.AdmissionQueueNumber.ToString() : "";
                result.KabulTarihi = Convert.ToDateTime(patientAdmission.CreationDate).ToString("dd.MM.yyyy HH:mm");
                result.StartDateWithDateandHour = Convert.ToDateTime(patientAdmission.CreationDate).ToString("dd.MM.yyyy HH:mm");
                result.SureAralik = "30";
                result.RandevuSaati = "30 dk";

            }
            return result;
        }
    }
}

namespace Core.Models
{
    public partial class PathologyRequestMainFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ReasonForPathologyRejection[] ReasonForRejectMaterialList
        {
            get;
            set;
        }

        public TempPathologyMaterialViewModel[] SelectedPathologyMaterialArray
        {
            get;
            set;
        }

        public RejectedMaterialsViewModel[] RejectedMaterialArray
        {
            get;
            set;
        }

        public object _selectedProcedureObject
        {
            get;
            set;
        }

        public vmRequestedPathologyProcedure[] _ProcedureArray
        {
            get;
            set;
        }

        public List<PathologyTest> ProcedureDoctorList //ObjectId ve name olduğu için kullanıldı
        {
            get;
            set;
        }
        public Guid ProcedureDoctorID
        {
            get;
            set;
        }



    }

    public class TempPathologyMaterialViewModel
    {
        public int GroupCount;
        public Guid MaterialObjectID;
        public DateTime DateOfSampleTaken;
        public string MaterialNumber;
        public string YerlesimYeri;
        public string AlindigiDokununTemelOzelligi;
        public string NumuneAlinmaSekli;
        public string ClinicalFindings;
        public string Description;
        public bool BiopsyCheck;
        public bool CytologyCheck;
        public bool BiopsyDisabled;
        public bool CytologyDisabled;
    }

    public class RejectedMaterialsViewModel
    {
        public Guid MaterialObjectID;
        public Guid RejectReasonID;
    }

    public class PathologyObject
    {
        public List<Guid> tempList = new List<Guid>();
        public bool isBiopsy = false; //Hangi sayaçtan protokol alacağının belirtilmesi için eklendiler
        public bool isCytology = false;
    }

    public class PathologyTest
    {
        public Guid ObjectID;
        public string Name;
    }

    public class MaterialBarcodeInfo
    {
        public string PatientID { get; set; }
        public string PatientNameSurname { get; set; }
        public string ProtocolNo { get; set; }
        public string RequestDoctorName { get; set; }
        public string RequestUnit { get; set; }
        public string MaterialAcceptionDate { get; set; } 
        public string DateOfSampleTaken { get; set; }
        public string Organ { get; set; }
        public string MaterialArchiveNo { get; set; }
        public string Barcode { get; set; }

    }

    public class PatientBarcodeInfo
    {
        public string PatientIdentifier = "";
        public string PatientName = "";
        public string GSSNo = "";
        public string Gender = "";
        public string Age = "";
        public string DNo = "";
        public string StartDate = "";
        public string StartDateWithDateandHour  = "";
        public string BirthDate  = "";
        public string BirthPlace  = "";
        public string IslemNo  = "";
        public string Kurum  = "";
        public string DoctorName = "";
        public string PoliclinicName  = "";
        public string SiraNo  = "";
        public string SureAralik  = "";
        public string RandevuSaati = "";
        public string HospitalName  = "";
        public string TAKIPNO  = "";
        public string KabulTarihi = "";
    }
}