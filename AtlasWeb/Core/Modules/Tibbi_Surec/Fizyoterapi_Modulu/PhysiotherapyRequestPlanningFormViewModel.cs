
//$A0262BC5
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TTStorageManager.Security;
using Core.Security;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class PhysiotherapyRequestServiceController
    {
        partial void PreScript_PhysiotherapyRequestPlanningForm(PhysiotherapyRequestPlanningFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTObjectContext objectContext)
        {
            viewModel.IsPhysiotherapyRequestFormUsing = TTObjectClasses.SystemParameter.GetParameterValue("USEPHYSIOTHERAPYREQUESTFORM", "") == "TRUE" ? true : false;

            viewModel.IsAppointmentActive = TTObjectClasses.SystemParameter.GetParameterValue("IsAppointmentActive", "FALSE") == "FALSE" ? false : true;

            #region Týbbi bilgiler
            MedicalInformation MedicalInfo = physiotherapyRequest.Episode.Patient.MedicalInformation;
            if (MedicalInfo != null)
            {
                StringBuilder medicalInfoStr = new StringBuilder();
                if (MedicalInfo.HeartFailure == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "HeartFailure").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Broken == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Broken").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Pregnancy == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Pregnancy").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Diabetes == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Diabetes").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Malignancy == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Malignancy").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.MetalImplant == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "MetalImplant").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.VascularDisorder == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "VascularDisorder").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Infection == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Infection").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Stent == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Stent").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Other == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Other").FirstOrDefault().Caption);
                }
                viewModel.MedicalInfo = medicalInfoStr.ToString();
            }
            #endregion

            #region Anamnez Bilgileri

            if (physiotherapyRequest.Episode.Complaint != null)
            {
                viewModel.AnamnesisComplaintInfo = physiotherapyRequest.Episode.Complaint.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            if (physiotherapyRequest.Episode.PatientHistory != null)
            {
                viewModel.AnamnesisPatientHistoryInfo = physiotherapyRequest.Episode.PatientHistory.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            if (physiotherapyRequest.Episode.PhysicalExamination != null)
            {
                viewModel.AnamnesisPhysicalExaminationInfo = physiotherapyRequest.Episode.PhysicalExamination.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            if (physiotherapyRequest.Episode.MTSConclusion != null)
            {
                viewModel.AnamnesisMTSConclusionInfo = physiotherapyRequest.Episode.MTSConclusion.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            #endregion


            this.removeOutgoingTransitions(viewModel, physiotherapyRequest);

            viewModel.PatientObjectId = physiotherapyRequest.Episode.Patient.ObjectID.ToString();

            #region requesti olmayan orderDetailler baðlanýyor
            foreach (var item in physiotherapyRequest.PhysiotherapyOrders)
            {
                foreach (var detailItem in item.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyRequest == null))
                {
                    detailItem.PhysiotherapyRequest = physiotherapyRequest;
                }
            }
            #endregion

            #region hatalý veriler düzeltiliyor
            foreach (var detailItem in physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder == null))
            {
                detailItem.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;
            }
            #endregion

            //List<PhysiotherapyOrderDetail> _PhysiotherapyOrderDetailList = new List<PhysiotherapyOrderDetail>();
            //List<PhysiotherapyOrderDetail> _AdditionalPhysiotherapyOrderDetailList = new List<PhysiotherapyOrderDetail>();
            viewModel.OrderDetailInfoList = new List<OrderDetailSessionInfo>();
            //viewModel.AdditionalOrderDetailInfoList = new List<OrderDetailInfo>();

            PhysiotherapyOrderDetail lastCompletedOrderDetail = null;


            //#region Seans Numaralarý tekrar düzenleniyor.
            ////Ek tedavi olmayan OrderDetail
            //var groupedOrderDetailList = physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder != null && c.PhysiotherapyOrder.IsAdditionalTreatment != true);
            //int count = 1;
            //foreach (var item in groupedOrderDetailList.OrderBy(c => c.PlannedDate).GroupBy(c => c.PlannedDate.Value.Date))
            //{
            //    var selectedOrderDetailList = groupedOrderDetailList.Where(x => x.PlannedDate.Value.Date == item.Key.Date);
            //    foreach (var selectedOrderDetail in selectedOrderDetailList)
            //    {
            //        selectedOrderDetail.SessionNumber = count;
            //    }

            //    count++;
            //}

            ////Ek tedavi olan OrderDetail
            //var groupedAdditionalOrderDetailList = physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder != null && c.PhysiotherapyOrder.IsAdditionalTreatment == true);
            //int countAdditional = 1;
            //foreach (var item in groupedAdditionalOrderDetailList.OrderBy(c => c.PlannedDate).GroupBy(c => c.PlannedDate.Value.Date))
            //{
            //    var selectedOrderDetailList = groupedAdditionalOrderDetailList.Where(x => x.PlannedDate.Value.Date == item.Key.Date);
            //    foreach (var selectedOrderDetail in selectedOrderDetailList)
            //    {
            //        selectedOrderDetail.SessionNumber = countAdditional;
            //    }

            //    countAdditional++;
            //}
            //#endregion

            var detailList = physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).OrderBy(x => x.PlannedDate);
            int sessionCount = 1;
            int keycount = 1;
            foreach (var plannedItem in detailList.GroupBy(x => x.PlannedDate.Value.Date))
            {
                int keycountForDetail = keycount;
                List<PhyOrderDetailInfo> OrderDetailList = new List<PhyOrderDetailInfo>();
                foreach (var orderDetail in plannedItem)
                {
                    if (orderDetail.PhysiotherapyOrder != null)
                    {
                        keycountForDetail++;
                        if (orderDetail.PhysiotherapyRequest == null)
                            orderDetail.PhysiotherapyRequest = orderDetail.PhysiotherapyOrder.PhysiotherapyRequest;

                        PhyOrderDetailInfo _detailInfo = new PhyOrderDetailInfo
                        {
                            ApplicationAreaDef = orderDetail.PhysiotherapyOrder?.FTRApplicationAreaDef?.ftrVucutBolgesiAdi,
                            ApplicationAreaInfo = orderDetail.PhysiotherapyOrder.ApplicationArea != null ? orderDetail.PhysiotherapyOrder.ApplicationArea : "",
                            Dose = orderDetail.PhysiotherapyOrder.Dose,
                            Duration = orderDetail.PhysiotherapyOrder.Duration.ToString(),
                            IsAdditionalProcess = orderDetail.IsAdditionalProcess != null ? orderDetail.IsAdditionalProcess.Value : false,
                            OrderDetailItem = orderDetail,
                            Physiotherapist = orderDetail.StarterResUser != null ? orderDetail.StarterResUser.Name : "",
                            PhysiotherapyState = Common.GetDescriptionOfDataTypeEnum(orderDetail.PhysiotherapyState),
                            PlannedDate = "",
                            SessionNumber = orderDetail.SessionNumber.ToString() != null ? orderDetail.SessionNumber.Value.ToString() : "",
                            TreatmentDiagnosisUnit = orderDetail.PhysiotherapyOrder.TreatmentDiagnosisUnit.Name,
                            ProcedureObject = orderDetail.PhysiotherapyOrder.ProcedureObject != null ? orderDetail.PhysiotherapyOrder.ProcedureObject.Name : "",
                            Package = orderDetail.PhysiotherapyOrder.PackageProcedure != null ? orderDetail.PhysiotherapyOrder.PackageProcedure.Name : "",
                            TreatmentProperties = orderDetail.PhysiotherapyOrder.TreatmentProperties != null ? orderDetail.PhysiotherapyOrder.TreatmentProperties : "",
                            DoseDurationInfo = orderDetail.PhysiotherapyOrder?.DoseDurationInfo,
                            IsAdditionalTreatment = orderDetail.PhysiotherapyOrder.IsAdditionalTreatment != null ? orderDetail.PhysiotherapyOrder.IsAdditionalTreatment.Value : false,
                            KeyNumber = keycountForDetail.ToString()
                        };

                        OrderDetailList.Add(_detailInfo);
                    }
                    else// hatalý veri iptal yapýlýyor
                    {
                        orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;
                    }
                }

                OrderDetailSessionInfo OrderDetailInfo = new OrderDetailSessionInfo
                {
                    OrderDetailList = OrderDetailList,
                    ApplicationAreaDef = "",
                    ApplicationAreaInfo = "",
                    Dose = "",
                    Duration = "",
                    IsAdditionalProcess = false,
                    OrderDetailItem = null,
                    Physiotherapist = "",
                    PhysiotherapyState = null,
                    PlannedDate = "Seans : " + sessionCount.ToString() + " - " + plannedItem.FirstOrDefault().PlannedDate.Value.ToShortDateString(),
                    SessionNumber = "Seans : " + sessionCount.ToString(),
                    TreatmentDiagnosisUnit = "",
                    ProcedureObject = "",
                    Package = "",
                    TreatmentProperties = "",
                    DoseDurationInfo = "",
                    IsAdditionalTreatment = false,
                    KeyNumber = keycount.ToString()
                };
                viewModel.OrderDetailInfoList.Add(OrderDetailInfo);
                sessionCount++;
                keycountForDetail++;
                keycount = keycountForDetail;
            }


            if (viewModel.IsPhysiotherapyRequestFormUsing == true)
            {
                viewModel.PhysiotherapyOrderList = new List<OrderInfo>();/*&& c.CurrentStateDefID != PhysiotherapyOrder.States.Completed*/
                foreach (var order in physiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID != PhysiotherapyOrder.States.Cancelled))
                {
                    OrderInfo _orderInfo = new OrderInfo
                    {
                        ApplicationArea = order?.FTRApplicationAreaDef?.ftrVucutBolgesiAdi,
                        ApplicationAreaInfo = order.ApplicationArea != null ? order.ApplicationArea : "",
                        Dose = order.Dose,
                        Duration = order.Duration.ToString(),
                        CurrentStateDefID = order.CurrentStateDefID.Value,
                        ProcedureObject = order.ProcedureObject.Name,
                        SessionCount = order.SessionCount.Value,
                        TreatmentDiagnosisUnit = order.TreatmentDiagnosisUnit.Name,
                        TreatmentProperties = order.TreatmentProperties,
                        IsPlannedBefore = order.PhysiotherapyOrderDetails.Count() > 0 ? true : false,
                        OrderObjectId = order.ObjectID,
                        OrderObjectDefId = order.ObjectDef.ID
                    };
                    viewModel.PhysiotherapyOrderList.Add(_orderInfo);
                }
            }

            viewModel.HasRole_Fizyoterapi_Uygulamasi_Iptal_Et = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Uygulamasi_Iptal_Et);
            viewModel.HasRole_Fizyoterapi_Ek_Islem = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Ek_Islem);

            //State geçiþ tamamlama butonu görüntülenmesi için deðiþken
            //if (physiotherapyRequest.PhysiotherapyOrders.Select(c => c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception).Count() > 0)
            //{
            //    viewModel.CanComplatePhysiotherapyRequest = false;
            //}
            //else
            //{
            //    viewModel.CanComplatePhysiotherapyRequest = true;
            //}

            // NOT: alltaki viewmodel için kullanýlacak
            viewModel.ProcedureObjectDataSource = PhysiotherapyDefinition.GetAllPhysiotherapyDefinitions(new TTObjectContext(true)).ToArray();


            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalýþmamalý
            viewModel.GridTreatmentMaterialsGridList = viewModel.GridTreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();

            ResUser user = (ResUser)Common.CurrentUser.UserObject;
            var usersUnits = user.UserResources.Where(c => c.Resource.ObjectDef.Name.ToUpper().ToString() == "RESTREATMENTDIAGNOSISUNIT");
            List<Guid> userUnitIDs = new List<Guid>();
            if (usersUnits != null)
            {
                foreach (var unit in usersUnits)
                {
                    userUnitIDs.Add(unit.Resource.ObjectID);
                }
            }

            #region Raporlar

            //viewModel.GridDiagnosisGridList = ((InPatientPhysicianApplication)physiotherapyRequest.MasterAction).DiagnosisGrid_PreScript();

            //BindingList<EpisodeAction> reportList = EpisodeAction.GetAllReportsOfPatient(objectContext, physiotherapyRequest.Episode.Patient.ObjectID.ToString());
            //if (reportList.Count > 0)
            //{
            //    List<PatientReportInfo> patientReportInfoList = new List<PatientReportInfo>();
            //    foreach (EpisodeAction report in reportList)
            //    {
            //        PatientReportInfo patientReportInfo = new PatientReportInfo();
            //        patientReportInfo.ObjectID = report.ObjectID;
            //        patientReportInfo.ObjectDefName = report.ObjectDef.Name;
            //        patientReportInfo.ID = report.ID.ToString();
            //        patientReportInfo.MasterResource = report.MasterResource.Name;
            //        patientReportInfo.ProcedureByUser = report.ProcedureByUser == null ? "" : report.ProcedureByUser.Name;

            //        if (report.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
            //        {
            //            if (report.SubEpisode.InpatientAdmission != null)
            //                patientReportInfo.AdmissionDate = report.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToShortDateString();
            //            else
            //                patientReportInfo.AdmissionDate = report.SubEpisode.OpeningDate.Value.ToShortDateString();
            //        }
            //        else if (report.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Outpatient)
            //        {
            //            patientReportInfo.AdmissionDate = report.SubEpisode.PatientAdmission.ActionDate.Value.ToShortDateString();
            //        }

            //        if (report is ParticipatnFreeDrugReport)
            //        {
            //            if (((ParticipatnFreeDrugReport)report).ReportStartDate.HasValue)
            //                patientReportInfo.StartDate = ((ParticipatnFreeDrugReport)report).ReportStartDate.Value.ToShortDateString();
            //            else
            //                patientReportInfo.StartDate = null;
            //            if (((ParticipatnFreeDrugReport)report).ReportEndDate.HasValue)
            //                patientReportInfo.EndDate = ((ParticipatnFreeDrugReport)report).ReportEndDate.Value.ToShortDateString();
            //            else
            //                patientReportInfo.EndDate = null;
            //            patientReportInfo.ReportName = ((ParticipatnFreeDrugReport)report).ObjectDef.ApplicationName;
            //            patientReportInfo.CancelledReport = (((ParticipatnFreeDrugReport)report).CurrentStateDefID == ParticipatnFreeDrugReport.States.Cancelled) ? true : false;
            //            patientReportInfo.RequestReason = "Ýlaç Raporu";
            //        }

            //        if (report is StatusNotificationReport)
            //        {
            //            if (((StatusNotificationReport)report).StartDate.HasValue)
            //                patientReportInfo.StartDate = ((StatusNotificationReport)report).StartDate.Value.ToShortDateString();
            //            else
            //                patientReportInfo.StartDate = ((StatusNotificationReport)report).StartDate.Value.ToShortDateString();
            //            if (((StatusNotificationReport)report).EndDate.HasValue)
            //                patientReportInfo.EndDate = ((StatusNotificationReport)report).EndDate.Value.ToShortDateString();
            //            else
            //                patientReportInfo.EndDate = null;
            //            patientReportInfo.ReportName = ((StatusNotificationReport)report).ObjectDef.ApplicationName;
            //            patientReportInfo.CancelledReport = (((StatusNotificationReport)report).CurrentStateDefID == StatusNotificationReport.States.Cancelled) ? true : false;
            //            patientReportInfo.RequestReason = ((StatusNotificationReport)report).HCRequestReason.ReasonName;
            //        }
            //        if (report is MedulaTreatmentReport)
            //        {
            //            if (((MedulaTreatmentReport)report).StartDate.HasValue)
            //                patientReportInfo.StartDate = ((MedulaTreatmentReport)report).StartDate.Value.ToShortDateString();
            //            else
            //                patientReportInfo.StartDate = null;
            //            if (((MedulaTreatmentReport)report).EndDate.HasValue)
            //                patientReportInfo.EndDate = ((MedulaTreatmentReport)report).EndDate.Value.ToShortDateString();
            //            else
            //                patientReportInfo.EndDate = null;
            //            patientReportInfo.ReportName = ((MedulaTreatmentReport)report).ObjectDef.ApplicationName;
            //            patientReportInfo.CancelledReport = (((MedulaTreatmentReport)report).CurrentStateDefID == MedulaTreatmentReport.States.Cancelled) ? true : false;
            //            patientReportInfo.RequestReason = Common.GetDisplayTextOfDataTypeEnum(((MedulaTreatmentReport)report).TedaviRaporTuru);
            //        }
            //        if (report is MedicalStuffReport)
            //        {
            //            if (((MedicalStuffReport)report).StartDate.HasValue)
            //                patientReportInfo.StartDate = ((MedicalStuffReport)report).StartDate.Value.ToShortDateString();
            //            else
            //                patientReportInfo.StartDate = null;
            //            if (((MedicalStuffReport)report).EndDate.HasValue)
            //                patientReportInfo.EndDate = ((MedicalStuffReport)report).EndDate.Value.ToShortDateString();
            //            else
            //                patientReportInfo.EndDate = null;
            //            patientReportInfo.ReportName = ((MedicalStuffReport)report).ObjectDef.ApplicationName;
            //            patientReportInfo.CancelledReport = (((MedicalStuffReport)report).CurrentStateDefID == MedulaTreatmentReport.States.Cancelled) ? true : false;
            //            patientReportInfo.RequestReason = "Týbbi Malzeme Raporu";
            //        }

            //        if (patientReportInfo.CancelledReport)
            //            patientReportInfo.ReportName += patientReportInfo.ReportName + " ( ÝPTAL EDÝLDÝ )";

            //        patientReportInfoList.Add(patientReportInfo);
            //    }

            //    viewModel.PatientReportInfoList = patientReportInfoList;

            //}
            #endregion
            PhysiotherapyOrder tempOrder = new PhysiotherapyOrder(objectContext);
            var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, tempOrder.ObjectDef.ID, "PhysiotherapyOrderTemplate").ToList();
            viewModel.userTemplateList = new List<UserTemplateModel>();
            foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList)
            {
                UserTemplateModel templateModel = new UserTemplateModel();
                templateModel.ObjectID = item.ObjectID;
                templateModel.TAObjectID = item.TAObjectID;
                templateModel.TAObjectDefID = item.TAObjectDefID;
                templateModel.Description = item.Description;
                viewModel.userTemplateList.Add(templateModel);
            }
        }

        partial void PostScript_PhysiotherapyRequestPlanningForm(PhysiotherapyRequestPlanningFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef == null)//state geçiþi yok ise; sadece kaydet butonuna bastý ise iþlem kayýt edilecek
            {
                if (viewModel.selectedPhysiotherapyPlannedOrdersFormViewModel != null)
                {
                    PhysiotherapyOrderServiceController.SavePhysiotherapyOrderPlanningFormViewModelObject(objectContext, viewModel.selectedPhysiotherapyPlannedOrdersFormViewModel);
                }
            }
            if (transDef != null && transDef.ToStateDefID == PhysiotherapyRequest.States.Completed)
            {
                var executedPhysiotherapyOrderDetails = physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution);
                if (executedPhysiotherapyOrderDetails.Count() > 0)
                {
                    foreach (var detail in executedPhysiotherapyOrderDetails)
                    {
                        detail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Aborted;//Yeni Durumunda olan Ýþlemler durduruldu durumuna çekiliyor!
                        detail.PhysiotherapyState = PhysiotherapyStateEnum.Aborted;
                        detail.IsChangedAutomatically = true;
                    }
                }
                if (physiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.Aborted || c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception || c.CurrentStateDefID == PhysiotherapyOrder.States.Rejected).Count() > 0)//Tamamlanmamýþ iþlemler tamamlanýyor!
                {
                    foreach (var order in physiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.Aborted || c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception || c.CurrentStateDefID == PhysiotherapyOrder.States.Rejected))
                    {
                        order.CurrentStateDefID = PhysiotherapyOrder.States.Completed;
                        order.IsChangedAutomatically = true;
                    }
                }

            }
        }

        protected void removeOutgoingTransitions(PhysiotherapyRequestPlanningFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest)
        {
            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();

            foreach (var trans in viewModel.OutgoingTransitions)
            {
                if (trans.ToStateDefID == PhysiotherapyRequest.States.Cancelled || trans.ToStateDefID == PhysiotherapyRequest.States.Completed)
                {
                    removedOutgoingTransitions.Add(trans);
                }

            }

            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Uygulamasi_Iptal_Et)]
        public void DeleteSelectedPhyOrderDetailsByID(List<PhyOrderDetailInfo> model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                for (int i = 0; i < model.Count; i++)
                {
                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailItem.ObjectID, model[i].OrderDetailItem.ObjectDef) as PhysiotherapyOrderDetail;
                    PhysiotherapyRequest request = orderDetail.PhysiotherapyRequest != null ? orderDetail.PhysiotherapyRequest : orderDetail.PhysiotherapyOrder.PhysiotherapyRequest;
                    IsSessionCompleted(request);

                    orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Cancel;
                    orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;

                    ResUser currentResUser = (ResUser)(TTUser.CurrentUser.UserObject);

                    if (orderDetail.StarterResUser == null)
                    {
                        orderDetail.StarterResUser = currentResUser;
                    }
                    orderDetail.FinisherResUser = currentResUser;

                    ////Order Detaillerin Hepsi Tamamlandý Ýse Order da tamamlanmalý
                    //orderDetail.PhysiotherapyOrder = CompletePhysiotherapyOrder(orderDetail.PhysiotherapyOrder);

                    ////Order'larýn Hepsi Tamamlandý ise Tüm Seans/Tedavi Tamamlansýn
                    //request = CompletePhysiotherapyRequest(request);
                }

                objectContext.Save();
            }
        }

        public void CancelPhysiotherapyPlanningRequest(PhysiotherapyRequestPlanningFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyRequest request = objectContext.GetObject(viewModel._PhysiotherapyRequest.ObjectID, viewModel._PhysiotherapyRequest.ObjectDef) as PhysiotherapyRequest;
                IsSessionCompleted(request);
                if (request.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed).Count() > 0)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M27031", "Tamamlanmýþ iþlemleri olan tedavi isteðini iptal edemezsiniz!"));
                }
                request.CurrentStateDefID = PhysiotherapyRequest.States.Cancelled;

                objectContext.Save();
            }
        }

    }
}


namespace Core.Models
{
    public partial class PhysiotherapyRequestPlanningFormViewModel
    {
        public List<OrderDetailInfo> selectedRowKeysResultList { get; set; }
        
        public bool IsAppointmentActive { get; set; }

        //public string Message { get; set; }

        //public List<ReportItem> ReportItemList { get; set; }

        //public PackageProcedureDefinition PackageProcedure { get; set; }
        //public PhysiotherapyReports Report { get; set; }
        //public TreatmentQueryReportTypeEnum TreatmentType { get; set; }


        //Yetki Kontrolü
        public bool HasRole_Fizyoterapi_Uygulamasi_Iptal_Et;
        public bool HasRole_Fizyoterapi_Ek_Islem;

        public bool IsPhysiotherapyRequestFormUsing { get; set; }//Sistem parametresi kontrol

        public string MedicalInfo { get; set; }
        public string AnamnesisComplaintInfo { get; set; }
        public string AnamnesisPatientHistoryInfo { get; set; }
        public string AnamnesisPhysicalExaminationInfo { get; set; }
        public string AnamnesisMTSConclusionInfo { get; set; }
        public bool HideAnamnesisInfoButton = true;


        public string PatientObjectId { get; set; }

        public List<OrderDetailSessionInfo> OrderDetailInfoList { get; set; }
        //public List<OrderDetailInfo> AdditionalOrderDetailInfoList { get; set; }//Ek Tedavi

        //public string PhysiotherapySessionRate { get; set; }

        public List<OrderInfo> PhysiotherapyOrderList { get; set; }
        public PhysiotherapyOrderPlanningFormViewModel selectedPhysiotherapyPlannedOrdersFormViewModel { get; set; }

        //public DateTime LastOrderDetailStartDate { get; set; }
        //public DateTime LastOrderDetailFinishDate { get; set; }
        //public ResUser LastOrderDetailResponsiblePhysiotherapist { get; set; }

        public ProcedureDefinition[] ProcedureObjectDataSource { get; set; }
        public List<PatientReportInfo> PatientReportInfoList = new List<PatientReportInfo>();
        public TTObjectClasses.DiagnosisGrid[] GridDiagnosisGridList { get; set; }
        public List<UserTemplateModel> userTemplateList { get; set; }
        public UserTemplateModel selectedUserTemplate { get; set; }



    }


    public class OrderDetailSessionInfo
    {
        public List<PhyOrderDetailInfo> OrderDetailList { get; set; }

        public string KeyNumber { get; set; }

        public string SessionNumber { get; set; }
        public string PlannedDate { get; set; }
        public string PhysiotherapyState { get; set; }
        public string ApplicationAreaDef { get; set; }
        public string ApplicationAreaInfo { get; set; }
        public string TreatmentDiagnosisUnit { get; set; }
        public string Duration { get; set; }
        public string Dose { get; set; }
        public string DoseDurationInfo { get; set; }
        public string Physiotherapist { get; set; }
        public Boolean IsAdditionalProcess { get; set; }//order detail ek iþlem
        public Boolean IsAdditionalTreatment { get; set; }//order detail ek tedavi
        public Guid CurrentUserObjectId { get; set; }//Ýþlemi Yapan
        public string ProcedureObject { get; set; }//Fizyoterapi iþlemi
        public string Package { get; set; }

        public string TreatmentProperties { get; set; }//Açýklama

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ResUser ResponsiblePhysiotherapist { get; set; }

        public PhysiotherapyOrderDetail OrderDetailItem { get; set; }
        public string PhysiotherapySessionId { get; set; }
        public string PhysiotherapySessionDef { get; set; }
    }

    public class PhyOrderDetailInfo
    {
        public string KeyNumber { get; set; }

        public string SessionNumber { get; set; }
        public string PlannedDate { get; set; }
        public string PhysiotherapyState { get; set; }
        public string ApplicationAreaDef { get; set; }
        public string ApplicationAreaInfo { get; set; }
        public string TreatmentDiagnosisUnit { get; set; }
        public string Duration { get; set; }
        public string Dose { get; set; }
        public string DoseDurationInfo { get; set; }
        public string Physiotherapist { get; set; }
        public Boolean IsAdditionalProcess { get; set; }//order detail ek iþlem
        public Boolean IsAdditionalTreatment { get; set; }//order detail ek tedavi
        public Guid CurrentUserObjectId { get; set; }//Ýþlemi Yapan
        public string ProcedureObject { get; set; }//Fizyoterapi iþlemi
        public string Package { get; set; }

        public string TreatmentProperties { get; set; }//Açýklama

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ResUser ResponsiblePhysiotherapist { get; set; }

        public PhysiotherapyOrderDetail OrderDetailItem { get; set; }
        public string PhysiotherapySessionId { get; set; }
        public string PhysiotherapySessionDef { get; set; }
    }


}
