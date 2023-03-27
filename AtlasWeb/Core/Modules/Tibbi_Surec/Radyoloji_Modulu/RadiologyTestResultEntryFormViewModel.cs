//$3A32A4D1
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using TTStorageManager;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class RadiologyTestServiceController
    {
        partial void PostScript_RadiologyTestResultEntryForm(RadiologyTestResultEntryFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID == RadiologyTest.States.Reported || transDef.ToStateDefID == RadiologyTest.States.Approve)
                {
                    if (radiologyTest.Report == null)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26756", "Rapor yazılmadan süreç 'Raporlandı' veya 'Onay' aşamasına alınamaz!"));
                    }
                }
            }
        }

        partial void PreScript_RadiologyTestResultEntryForm(RadiologyTestResultEntryFormViewModel viewModel, RadiologyTest radiologyTest, TTObjectContext objectContext)
        {


            if (radiologyTest.ProcedureDoctor == null && Common.CurrentResource.TakesPerformanceScore == true && (Common.CurrentUser.HasRole(new Guid("8876d00f-f5ff-4477-8848-7c176f2eb061")) || Common.CurrentUser.HasRole(new Guid("c318a87a-c781-4024-b4b1-d6c3bffe9bc6"))))
            {
                radiologyTest.ProcedureDoctor = Common.CurrentResource;
               
            }

            if (radiologyTest.ReportedBy == null)

                radiologyTest.ReportedBy = Common.CurrentResource;

            ContextToViewModel(viewModel, objectContext);

            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalışmamalı
            viewModel.MaterialsGridList = viewModel.MaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();

            if (viewModel._RadiologyTest.Episode != null)
            {
                viewModel.EpisodeID = viewModel._RadiologyTest.Episode.ID.ToString();
                if (viewModel._RadiologyTest.Episode.Patient.UniqueRefNo != null)
                {
                    viewModel.PatientTCNo = viewModel._RadiologyTest.Episode.Patient.UniqueRefNo.ToString();
                }
            }

            viewModel.PatientID = viewModel._RadiologyTest.Episode.Patient.ObjectID;
            viewModel.EpisodeActionID = viewModel._RadiologyTest.Radiology.ObjectID;

            var radTestDefinition = radiologyTest.ProcedureObject as RadiologyTestDefinition;
            var radTestType = radTestDefinition.TestType as RadiologyTestTypeDefinition;
            if (radTestType != null)
            {
                viewModel.TestType = radTestType.Name;
            }
            else
                viewModel.TestType = "";

            //if (Common.CurrentUser.HasRole(new Guid("8876d00f-f5ff-4477-8848-7c176f2eb061")) || Common.CurrentUser.HasRole(new Guid("c318a87a-c781-4024-b4b1-d6c3bffe9bc6")))
            //{
            //    viewModel.hasDoctorRole = true;
            //}
            //else
            //    viewModel.hasDoctorRole = false;

            //Radyoloji şablon kontrolü
            if (Common.CurrentResource.TakesPerformanceScore == true)
            {
                BindingList<RadiologyTemplate> radiologyTemplateList = RadiologyTemplate.CheckRadiologyTemplates(objectContext, Common.CurrentResource.ObjectID, radiologyTest.RadiologyTestDefinition.ObjectID);
                viewModel.RadiologyTemplates = radiologyTemplateList.ToList();
            }
            else
                viewModel.RadiologyTemplates = new List<RadiologyTemplate>();



        }

        partial void AfterContextSaveScript_RadiologyTestResultEntryForm(RadiologyTestResultEntryFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID == RadiologyTest.States.Procedure)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("PACSENTEGRATION", "FALSE") == "TRUE")
                    {
                        if (((RadiologyTestDefinition)(radiologyTest.ProcedureObject)).IsRISEntegratedTest == true)
                        {
                            bool addRadiologyQueue = false;
                            //Dıs XXXXXXden ıstenen tetkıkler de Islemde asamasına gecırılıyor ancak PACS a gonderımı yapılmayacak. TFS 53540
                            //Ancak MR ve BT turundeki dis tetkiklerin PACS a gonderilmesine karar verildi. TFS 54242
                            bool sendToPACS = false;
                            if (((ResObservationUnit)radiologyTest.MasterResource).IsExternalObservationUnit == true)
                            {
                                if (radiologyTest.ProcedureObject.IsMR || radiologyTest.ProcedureObject.IsBT)
                                {
                                    sendToPACS = true;
                                }
                                else
                                {
                                    sendToPACS = false;
                                }
                            }
                            else
                            {
                                sendToPACS = true;
                            }

                            if (sendToPACS == true)
                            {
                                string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
                                if (sysparam == "TRUE")
                                {
                                    List<Guid> radSubactionList = new List<Guid>();
                                    TTObjectContext objectContextLocal = new TTObjectContext(false);
                                    RadiologyTest radTest = (RadiologyTest)objectContextLocal.GetObject(radiologyTest.ObjectID, "RADIOLOGYTEST");
                                    if (radTest.IsMessageInPACS == true)
                                    {
                                        try
                                        {
                                            radTest.IsMessageInPACS = false;
                                            radTest.IsMessageInTELETIP = false;
                                            radSubactionList.Add(radTest.ObjectID);

                                            /* USEASYNCSERVER parametresi değeri true olduğunda asenkron mesaj oluşturulması sağlanıyor.Diğer durumda senkron mesaj oluşturuluyor. */
                                            if (TTObjectClasses.SystemParameter.GetParameterValue("USEASYNCSERVER", "FALSE") == "TRUE")
                                            {
                                                TTMessage messagePacs = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, radSubactionList, "O01XO", "PACS");
                                                TTMessage messageTeletip = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, radSubactionList, "O01XO", "TELETIP");
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    var resultPacs = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(radSubactionList, "O01XO", HL7ServerNames.PACS);
                                                    radTest.IsMessageInPACS = resultPacs.Item1;
                                                    radTest.ACKMessagePACS = resultPacs.Item2;

                                                    //Mesaj PACS a başarılı gönderildi ise TELETIP a gönderim yapılacak ve LCD kuyruğuna eklenecek.
                                                    if (radTest.IsMessageInPACS == true)
                                                    {
                                                        try
                                                        {
                                                            var resultTeletip = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(radSubactionList, "O01XO", HL7ServerNames.TeleTIP);
                                                            radTest.IsMessageInTELETIP = resultTeletip.Item1;
                                                            radTest.ACKMessageTELETIP = resultTeletip.Item2;
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                        catch
                                        {
                                        }
                                        finally
                                        {
                                            objectContextLocal.Save();
                                        }
                                    }
                                    else
                                    {

                                        try
                                        {
                                            radTest.IsMessageInPACS = false;
                                            radTest.IsMessageInTELETIP = false;
                                            radSubactionList.Add(radTest.ObjectID);

                                            /* USEASYNCSERVER parametresi değeri true olduğunda asenkron mesaj oluşturulması sağlanıyor.Diğer durumda senkron mesaj oluşturuluyor. */
                                            if (TTObjectClasses.SystemParameter.GetParameterValue("USEASYNCSERVER", "FALSE") == "TRUE")
                                            {
                                                TTMessage messagePacs = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, radSubactionList, "O01", "PACS");
                                                TTMessage messageTeletip = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, radSubactionList, "O01", "TELETIP");

                                            }
                                            else
                                            {
                                                try
                                                {
                                                    var resultPacs = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(radSubactionList, "O01", HL7ServerNames.PACS);
                                                    radTest.IsMessageInPACS = resultPacs.Item1;
                                                    radTest.ACKMessagePACS = resultPacs.Item2;

                                                    //Mesaj PACS a başarılı gönderildi ise TELETIP a gönderim yapılacak ve LCD kuyruğuna eklenecek.
                                                    if (radTest.IsMessageInPACS == true)
                                                    {
                                                        addRadiologyQueue = true;
                                                        try
                                                        {
                                                            var resultTeletip = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(radSubactionList, "O01", HL7ServerNames.TeleTIP);
                                                            radTest.IsMessageInTELETIP = resultTeletip.Item1;
                                                            radTest.ACKMessageTELETIP = resultTeletip.Item2;
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                        catch
                                        {
                                        }
                                        finally
                                        {
                                            objectContextLocal.Save();
                                        }
                                    }
                                }

                                //Cekim icin isleme alindiginda (Islemde asamasında) kuyruga ekleniyor.
                                if (TTObjectClasses.SystemParameter.GetParameterValue("RADIOLOGYLCDOPEN", "FALSE") == "TRUE")
                                {
                                    //RIS entegre olmayan testlerden US türünde olan varsa da kuyruğa eklenmesi istendi.
                                    if (addRadiologyQueue == false)
                                    {
                                        //Tetkik US tetkik ise İşleme Al aşamasına geçerken, Ultrason kuyruğuna istem eklenmeli, TFS 58193
                                        RadiologyTestDefinition rTestDef = (RadiologyTestDefinition)radiologyTest.ProcedureObject;
                                        if (rTestDef.TestType != null && rTestDef.TestType.Name == "US")
                                        {
                                            addRadiologyQueue = true;
                                        }
                                    }

                                    if (addRadiologyQueue == true)
                                    {
                                        if (radiologyTest.Radiology != null)
                                        {
                                            TTObjectContext objectContextLocal = new TTObjectContext(false);
                                            string resource = radiologyTest.Radiology.MasterResource.ObjectID.ToString();
                                            IList<ExaminationQueueDefinition> myQueue = ExaminationQueueDefinition.GetQueueByResource(objectContextLocal, resource);
                                            if (myQueue.Count > 0)
                                            {
                                                this.CreateExaminationQueueItem(radiologyTest, myQueue[0], false, Common.CurrentResource, objectContextLocal);
                                                objectContextLocal.Save();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        [HttpGet]
        public AddRadiologyProcedureViewModel LoadAddRadiologyProcedureViewModel()
        { 
            AddRadiologyProcedureViewModel model = new AddRadiologyProcedureViewModel();
            model.RadiologyProcedureList = new List<RadiologyProcedureObject>();

            using (var objectContext = new TTObjectContext(false))
            {
                List<RadiologyTestDefinition.GetRadiologyTestDefinitionNQL_Class> RadiologyTestListFromQuery = RadiologyTestDefinition.GetRadiologyTestDefinitionNQL(" WHERE ISACTIVE = 1 ORDER BY NAME ASC ").ToList();
                foreach (RadiologyTestDefinition.GetRadiologyTestDefinitionNQL_Class radiologyTest in RadiologyTestListFromQuery)
                {
                    RadiologyTestDefinition radiologyTestDefinition = objectContext.GetObject<RadiologyTestDefinition>(new Guid(radiologyTest.ObjectID.ToString()));

                    RadiologyProcedureObject r = new RadiologyProcedureObject();

                    r.Name = radiologyTest.Name;
                    r.Code = radiologyTest.Code;
                    r.ObjectID = radiologyTest.ObjectID.ToString();
                    if (radiologyTestDefinition.Departments.Count > 0)
                    {
                        r.ObservationUnitID = radiologyTestDefinition.Departments[0].Department != null ? radiologyTestDefinition.Departments[0].Department.ObjectID.ToString() : "";
                    }
                    else
                        r.ObservationUnitID = "";

                    if (radiologyTestDefinition.Equipments.Count > 0)
                    {

                        r.EquipmentID = radiologyTestDefinition.Equipments[0].Equipment != null ? radiologyTestDefinition.Equipments[0].Equipment.ObjectID.ToString() : "";
                    }
                    else
                        r.EquipmentID = "";


                    model.RadiologyProcedureList.Add(r);
                }
            }

            return model;
        }
        [HttpPost]
        public void SaveSelectedRadiologyTests(AddRadiologyProcedureInput input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Dictionary<string, EpisodeAction> EAList = new Dictionary<string, EpisodeAction>();

                RadiologyTest currentRadiologyTest = objectContext.GetObject<RadiologyTest>(new Guid(input.RadiologyTestObjectID));


                foreach (RadiologyProcedureObject radiologyTest in input.SelectedRadiologyProcedureList )
                {
                    RadiologyTestDefinition radiologyTestDefinition = objectContext.GetObject<RadiologyTestDefinition>(new Guid(radiologyTest.ObjectID.ToString()));

                    IProcedureRequestDefinition procReq = (IProcedureRequestDefinition)radiologyTestDefinition;
                    EpisodeAction ea = null;

                    ResObservationUnit observationUnit = objectContext.GetObject<ResObservationUnit>(new Guid(radiologyTest.ObservationUnitID.ToString()));

                    Guid ProcedureUserID = currentRadiologyTest.ProcedureDoctor == null ? Guid.Empty : currentRadiologyTest.ProcedureDoctor.ObjectID;
                    ea = procReq.CreateMyEpisodeAction(currentRadiologyTest.Radiology, observationUnit, currentRadiologyTest.FromResource, false, false,DateTime.Now, ProcedureUserID, false); //this hangi episodeactionsa o master olan fromresourceu 
                    EAList.Add(ea.ObjectID.ToString(), ea);

                    SubActionProcedure sp = procReq.CreateMySubactionProcedure(ea, observationUnit, currentRadiologyTest.FromResource);

                   
                }

                ForwardNextStepMyActionOfProcedureRequestsRadiology(EAList);
                objectContext.Save();
            }
        }

        public void ForwardNextStepMyActionOfProcedureRequestsRadiology(Dictionary<string, EpisodeAction> eaList)
        {
            Guid? startedStateDefID = null;
            foreach (KeyValuePair<string, EpisodeAction> myEA in eaList)
            {
                startedStateDefID = myEA.Value.ProcedureRequestStartedStateDefID();

                if (startedStateDefID != null && startedStateDefID != Guid.Empty)
                {
                    EpisodeAction myFiredAction = myEA.Value;
                    myFiredAction.CurrentStateDefID = startedStateDefID;
                    myFiredAction.Update();
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class RadiologyTestResultEntryFormViewModel
    {
        public bool hasDoctorRole { get; set; }

        public string PatientTCNo;
        public string EpisodeID;
        public Guid PatientID { get; set; }
        public Guid EpisodeActionID { get; set; }
        public string TestType { get; set; }
        public List<RadiologyTemplate> RadiologyTemplates { get; set; } 
    }

    public class vmPatientRadiologyTest
    {
        public Guid SubActionProcedureObjectId { get; set; }
        public string AccessionNo { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureName { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestedByResUser { get; set; }
        public string ProcedureResUser { get; set; }
        public string ActionStatus { get; set; }
        public string ProcedureResultLink { get; set; }
        public string ProcedureReportLink { get; set; }
        public bool isResultShown { get; set; }
        public bool isReportShown { get; set; }
        public string FromResourceName { get; set; }

    }

    public class AddRadiologyProcedureViewModel
    {
        public List<RadiologyProcedureObject> RadiologyProcedureList;
    }

    public class RadiologyProcedureObject
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ObjectID { get; set; }
        public string ObservationUnitID { get; set; }
        public string ObservationName { get; set; }
        public string EquipmentID { get; set; }
        public string EquipmentName { get; set; }
    }

    public class AddRadiologyProcedureInput
    {
        public List<RadiologyProcedureObject> SelectedRadiologyProcedureList;
        public string RadiologyTestObjectID { get; set; }
    }
}
