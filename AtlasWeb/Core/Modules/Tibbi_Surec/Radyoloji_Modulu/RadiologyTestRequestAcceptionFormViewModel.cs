//$8487D455
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager;
using TTUtils;

namespace Core.Controllers
{
    public partial class RadiologyTestServiceController
    {
        partial void AfterContextSaveScript_RadiologyTestRequestAcceptionForm(RadiologyTestRequestAcceptionFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

            if (transDef != null)
            {
                if (transDef.ToStateDefID == RadiologyTest.States.Procedure)
                {


                    if (TTObjectClasses.SystemParameter.GetParameterValue("PACSENTEGRATION", "FALSE") == "TRUE")
                    {
                        if (((RadiologyTestDefinition)(radiologyTest.ProcedureObject)).IsRISEntegratedTest == true)
                        {
                                this.SendTestToPACSAndTELETIP(radiologyTest);

                            //Site ID ye göre değil sisem parametresine göre kontrol yapılmalı.
                            //64031 nolu task için ris entegre testlerin hepsi toplu olarak (o episodeaction altındaki diğer istekler de) İşlemde adımına geçiyor.
                            if (TTObjectClasses.SystemParameter.GetParameterValue("SENDRELATEDTESTSTOPACS", "FALSE") == "TRUE") 
                            {
                                TTObjectContext objectContextLocal = new TTObjectContext(false);
                                List<RadiologyTest> myRadiologyTests = radiologyTest.Radiology.RadiologyTests.ToList();
                                if (myRadiologyTests != null)
                                {
                                    foreach (RadiologyTest myRadTest in myRadiologyTests)
                                    {
                                        if (myRadTest.ObjectID.ToString() != radiologyTest.ObjectID.ToString())
                                        {
                                            if (myRadTest.CurrentStateDefID.ToString() == RadiologyTest.States.RequestAcception.ToString())
                                            {
                                                if (((RadiologyTestDefinition)(myRadTest.ProcedureObject)).IsRISEntegratedTest == true)
                                                {
                                                    RadiologyTest updatedRadTest = (RadiologyTest)objectContextLocal.GetObject(myRadTest.ObjectID, "RADIOLOGYTEST");
                                                    updatedRadTest.CurrentStateDefID = RadiologyTest.States.Procedure;
                                                    objectContextLocal.Save();

                                                    this.SendTestToPACSAndTELETIP(myRadTest);
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
        }


        [HttpPost]
        public List<AllRadiologyList> GetAllRadiologyTest(RadiologyTest radiologyTest)
        {
            List<AllRadiologyList> list = new List<AllRadiologyList>();
            TTObjectContext objectContextLocal = new TTObjectContext(false);
            //RadiologyTest radiologyTest = objectContextLocal.GetObject<RadiologyTest>(rdt.ObjectID);

            //Pursaklar için Grafilerde çoklu test gönderimi istendi. Site parametresine göre 1 istek gönderildiğinde, o episodeaction altındaki diğer istekler de İşlemde aşamasına alınacak.
            if (TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", "") == "40d3a1a8-198d-4c5a-bfa4-4487136e4cb8") //PURSAKLAR
            {

                if (((RadiologyTestDefinition)(radiologyTest.ProcedureObject)).TestType.Name == "CR")
                {
                    List<RadiologyTest> myRadiologyTests = radiologyTest.Radiology.RadiologyTests.ToList();
                    foreach (var item in myRadiologyTests)
                    {
                        AllRadiologyList arr = new AllRadiologyList();
                        arr.AccessionNumber = item.AccessionNo?.ToString();
                        arr.ProcudureCode = item.ProcedureObject.Code.ToString();
                        arr.ProcudureName = item.ProcedureObject.Name.ToString();
                        list.Add(arr);
                    }
                    return list;
                }
            }


            return null;
        }

        public class AllRadiologyList
        {
            public string AccessionNumber { get; set; }
            public string ProcudureName { get; set; }
            public string ProcudureCode { get; set; }
        }

        public void SendTestToPACSAndTELETIP(RadiologyTest radiologyTest)
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
                    using (TTObjectContext objectContextLocal = new TTObjectContext(false))
                    {
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
                                    TTMessage messageTeletip = null;

                                    TTMessage messagePacs = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, radSubactionList, "O01XO", "PACS");
                                    if (radiologyTest.ExternalServiceRequests.Count <= 0)
                                        messageTeletip = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, radSubactionList, "O01XO", "TELETIP");
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
                                                if (radiologyTest.ExternalServiceRequests.Count <= 0)
                                                {
                                                    var resultTeletip = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(radSubactionList, "O01XO", HL7ServerNames.TeleTIP);
                                                    radTest.IsMessageInTELETIP = resultTeletip.Item1;
                                                    radTest.ACKMessageTELETIP = resultTeletip.Item2;
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
                                    TTMessage messageTeletip = null;
                                    TTMessage messagePacs = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, radSubactionList, "O01", "PACS");

                                    if (radiologyTest.ExternalServiceRequests.Count <= 0)
                                        messageTeletip = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, radSubactionList, "O01", "TELETIP");
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
                                                //Tuple<bool, string> resultTeletip;

                                                if (radiologyTest.ExternalServiceRequests.Count <= 0)
                                                {
                                                    var resultTeletip = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(radSubactionList, "O01", HL7ServerNames.TeleTIP);
                                                    radTest.IsMessageInTELETIP = resultTeletip.Item1;
                                                    radTest.ACKMessageTELETIP = resultTeletip.Item2;
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

        partial void PostScript_RadiologyTestRequestAcceptionForm(RadiologyTestRequestAcceptionFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

            if (radiologyTest != null)
            {
                TTObjectContext objectContextLocal = new TTObjectContext(false);

                //İstek kabul aşamasında test değişikliği yapılmışsa önceki radiologyTest iptal edilmeli, TODO: geliştirme tamamlanacak
                /*if (viewModel.ProcedureDefinitions[0].ObjectID.ToString() != radiologyTest.ProcedureObject.ObjectID.ToString())
                {
                    RadiologyTest oldRadTest = (RadiologyTest)objectContextLocal.GetObject(viewModel._RadiologyTest.ObjectID, "RadiologyTest");
                    if (oldRadTest != null)
                        oldRadTest.Cancel();

                }*/
                if (radiologyTest.Radiology.MasterAction is PhysicianApplication)
                {
                    radiologyTest.PhysicalExamination = TTReportTool.TTReport.HTMLtoText(((PhysicianApplication)radiologyTest.Radiology.MasterAction).PhysicalExamination?.ToString());
                    radiologyTest.PatientHistory = TTReportTool.TTReport.HTMLtoText(((PhysicianApplication)radiologyTest.Radiology.MasterAction).PatientHistory?.ToString());
                    radiologyTest.Complaint = TTReportTool.TTReport.HTMLtoText(((PhysicianApplication)radiologyTest.Radiology.MasterAction).Complaint?.ToString());
                    radiologyTest.MTSConclusion = TTReportTool.TTReport.HTMLtoText(((PhysicianApplication)radiologyTest.Radiology.MasterAction).MTSConclusion?.ToString());
                }
                
                objectContextLocal.Save();

                if (transDef != null)
                {
                    if (transDef.ToStateDefID == RadiologyTest.States.Procedure)
                    {
                        if (((ResObservationUnit)radiologyTest.MasterResource).IsExternalObservationUnit != true)
                        {
                            if (radiologyTest.Equipment is null)
                            {
                                throw new TTException(CultureService.GetText("M349", "'{0}' is required.", "Cihaz"));
                            }
                        }
                    }
                }
            }
        }

        public ExaminationQueueItem CreateExaminationQueueItem(RadiologyTest radiologyTest, ExaminationQueueDefinition appQueueDef, bool isEmergency, ResUser currentUser, TTObjectContext objectContext)
        {

            ExaminationQueueItem examinationQueueItem = null;

            if (TTObjectClasses.SystemParameter.GetParameterValue("CloseExaminationQueueItem", "FALSE") != "TRUE")
            {
                Radiology radiology = radiologyTest.Radiology;
                if (radiology.MasterResource != null && radiology.MasterResource is ResObservationUnit)
                {
                    if (radiology.Episode.Patient.HasActiveQueueItemInQueue(appQueueDef, currentUser) == null)
                    {
                        examinationQueueItem = new ExaminationQueueItem(objectContext);
                        examinationQueueItem.EpisodeAction = radiology;
                        examinationQueueItem.SubactionProcedureFlowable = radiologyTest;
                        examinationQueueItem.Appointment = null;
                        examinationQueueItem.CurrentStateDefID = TTObjectClasses.ExaminationQueueItem.States.New;
                        examinationQueueItem.Patient = radiology.Episode.Patient;
                        if (radiology.RadiologyTests != null && radiology.RadiologyTests.Count > 0 && radiology.RadiologyTests[0] != null)
                        {
                            examinationQueueItem.Priority = (radiology.RadiologyTests[0].SubEpisode.PatientAdmission.PriorityStatus == null) ? 5000 : radiology.RadiologyTests[0].SubEpisode.PatientAdmission.PriorityStatus.Order;
                            examinationQueueItem.PriorityReason = (radiology.RadiologyTests[0].SubEpisode.PatientAdmission.PriorityStatus == null) ? "" : radiology.RadiologyTests[0].SubEpisode.PatientAdmission.PriorityStatus.Name;
                        }
                        examinationQueueItem.QueueDate = Common.RecTime().Date;
                        examinationQueueItem.CallTime = Common.RecTime();
                        examinationQueueItem.ExaminationQueueDefinition = appQueueDef;
                        examinationQueueItem.DivertedTime = Common.RecTime();
                        examinationQueueItem.Doctor = currentUser;
                        examinationQueueItem.CallCount = 0;
                    }
                }
            }

            return examinationQueueItem;
        }

        partial void PreScript_RadiologyTestRequestAcceptionForm(RadiologyTestRequestAcceptionFormViewModel viewModel, RadiologyTest radiologyTest, TTObjectContext objectContext)
        {

            viewModel.NewRadiologyBarcode = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("NEWRADIOLOGYBARCODE", "FALSE"));


                if (radiologyTest != null)
            {
                string alertMsg = ((RadiologyTestDefinition)radiologyTest.ProcedureObject).GetMyAlertMessage(radiologyTest.EpisodeAction.ObjectID);
                viewModel.AlertMessage = alertMsg;
            }

            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalışmamalı
            viewModel.MaterialsGridList = viewModel.MaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
        }

    }
}

namespace Core.Models
{
    public partial class RadiologyTestRequestAcceptionFormViewModel
    {
        public string AlertMessage;
        public bool NewRadiologyBarcode;
    }
}