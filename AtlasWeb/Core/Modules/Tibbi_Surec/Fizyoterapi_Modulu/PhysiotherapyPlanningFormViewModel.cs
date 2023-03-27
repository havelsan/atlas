
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

namespace Core.Controllers
{
    public partial class PhysiotherapyRequestServiceController
    {
        partial void PreScript_PhysiotherapyPlanningForm(PhysiotherapyPlanningFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTObjectContext objectContext)
        {
            viewModel.IsPhysiotherapyRequestFormUsing = TTObjectClasses.SystemParameter.GetParameterValue("USEPHYSIOTHERAPYREQUESTFORM", "") == "TRUE" ? true : false;

            #region Tıbbi bilgiler
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

            #region requesti olmayan orderDetailler bağlanıyor
            foreach (var item in physiotherapyRequest.PhysiotherapyOrders)
            {
                foreach (var detailItem in item.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyRequest == null))
                {
                    //if (detailItem.PhysiotherapyRequest == null && detailItem.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled)
                    //{
                    detailItem.PhysiotherapyRequest = physiotherapyRequest;
                    //}
                }
            }
            #endregion

            #region hatalı veriler düzeltiliyor
            foreach (var detailItem in physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder == null))
            {
                //if (detailItem.PhysiotherapyOrder == null && detailItem.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled)
                //{
                detailItem.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;
                //}
            }
            #endregion

            List<PhysiotherapyOrderDetail> _PhysiotherapyOrderDetailList = new List<PhysiotherapyOrderDetail>();
            List<PhysiotherapyOrderDetail> _AdditionalPhysiotherapyOrderDetailList = new List<PhysiotherapyOrderDetail>();
            viewModel.OrderDetailInfoList = new List<OrderDetailInfo>();
            viewModel.AdditionalOrderDetailInfoList = new List<OrderDetailInfo>();

            int appliedSessionCount = 0;
            int totalSessionCount = 0;
            int lastSessionNumber = 0;
            int lastExecutedSession = 0;

            viewModel.CanComplatePhysiotherapyRequest = true;

            PhysiotherapyOrderDetail lastCompletedOrderDetail = null;


            #region Seans Numaraları tekrar düzenleniyor.
            //Ek tedavi olmayan OrderDetail
            var groupedOrderDetailList = physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder != null && c.PhysiotherapyOrder.IsAdditionalTreatment != true);
            int count = 1;
            foreach (var item in groupedOrderDetailList.OrderBy(c => c.PlannedDate).GroupBy(c => c.PlannedDate.Value.Date))
            {
                var selectedOrderDetailList = groupedOrderDetailList.Where(x => x.PlannedDate.Value.Date == item.Key.Date);
                foreach (var selectedOrderDetail in selectedOrderDetailList)
                {
                    selectedOrderDetail.SessionNumber = count;
                }

                count++;
            }

            //Ek tedavi olan OrderDetail
            var groupedAdditionalOrderDetailList = physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder != null && c.PhysiotherapyOrder.IsAdditionalTreatment == true);
            int countAdditional = 1;
            foreach (var item in groupedAdditionalOrderDetailList.OrderBy(c => c.PlannedDate).GroupBy(c => c.PlannedDate.Value.Date))
            {
                var selectedOrderDetailList = groupedAdditionalOrderDetailList.Where(x => x.PlannedDate.Value.Date == item.Key.Date);
                foreach (var selectedOrderDetail in selectedOrderDetailList)
                {
                    selectedOrderDetail.SessionNumber = countAdditional;
                }

                countAdditional++;
            }
            #endregion


            foreach (var orderDetail in physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).OrderBy(x => x.SessionNumber))
            {

                if (orderDetail.PhysiotherapyOrder == null)// hatalı veri iptal yapılıyor
                {
                    orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;
                }
                else
                {
                    if (orderDetail.PhysiotherapyRequest == null)
                        orderDetail.PhysiotherapyRequest = orderDetail.PhysiotherapyOrder.PhysiotherapyRequest;

                    OrderDetailInfo _detailInfo = new OrderDetailInfo
                    {
                        ApplicationAreaDef = orderDetail.PhysiotherapyOrder?.FTRApplicationAreaDef?.ftrVucutBolgesiAdi,
                        ApplicationAreaInfo = orderDetail.PhysiotherapyOrder.ApplicationArea != null ? orderDetail.PhysiotherapyOrder.ApplicationArea : "",
                        Dose = orderDetail.PhysiotherapyOrder.Dose,
                        Duration = orderDetail.PhysiotherapyOrder.Duration.ToString(),
                        IsAdditionalProcess = orderDetail.IsAdditionalProcess != null ? orderDetail.IsAdditionalProcess.Value : false,
                        OrderDetailItem = orderDetail,
                        Physiotherapist = orderDetail.StarterResUser != null ? orderDetail.StarterResUser.Name : "",
                        PhysiotherapyState = Common.GetDescriptionOfDataTypeEnum(orderDetail.PhysiotherapyState),
                        PlannedDate = orderDetail.PlannedDate != null ? Convert.ToDateTime(orderDetail.PlannedDate.Value.ToShortDateString()) : DateTime.Now,
                        SessionNumber = orderDetail.SessionNumber != null ? orderDetail.SessionNumber.Value : 0,
                        TreatmentDiagnosisUnit = orderDetail.PhysiotherapyOrder.TreatmentDiagnosisUnit.Name,
                        ProcedureObject = orderDetail.PhysiotherapyOrder.ProcedureObject != null ? orderDetail.PhysiotherapyOrder.ProcedureObject.Name : "",
                        Package = orderDetail.PhysiotherapyOrder.PackageProcedure != null ? orderDetail.PhysiotherapyOrder.PackageProcedure.Name : "",
                        TreatmentProperties = orderDetail.PhysiotherapyOrder.TreatmentProperties != null ? orderDetail.PhysiotherapyOrder.TreatmentProperties : "",
                        DoseDurationInfo = orderDetail.PhysiotherapyOrder?.DoseDurationInfo,
                        StartTime = orderDetail.StartDate != null ? orderDetail.StartDate.Value.ToString("HH:mm") : "",
                        FinishTime = orderDetail.FinishDate != null ? orderDetail.FinishDate.Value.ToString("HH:mm") : "",
                        IsAdditionalTreatment = orderDetail.PhysiotherapyOrder.IsAdditionalTreatment != null ? orderDetail.PhysiotherapyOrder.IsAdditionalTreatment.Value : false
                    };

                    if (orderDetail.PhysiotherapyOrder.IsAdditionalTreatment == true)
                    {
                        viewModel.AdditionalOrderDetailInfoList.Add(_detailInfo);
                    }
                    else
                    {
                        viewModel.OrderDetailInfoList.Add(_detailInfo);
                    }

                    if (lastSessionNumber != orderDetail.SessionNumber && orderDetail.SessionNumber != null)//seansın ilki tamamlandıysa sayılıyor değilse tamamlanmamış sayılıyor
                    {
                        totalSessionCount++;
                        lastSessionNumber = orderDetail.SessionNumber.Value;
                    }
                    if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed)
                    {
                        if (lastExecutedSession == orderDetail.SessionNumber)
                        {
                            appliedSessionCount++;
                            lastExecutedSession = orderDetail.SessionNumber.Value;
                        }
                        if (orderDetail.StartDate != null && orderDetail.FinishDate != null)
                        {
                            lastCompletedOrderDetail = orderDetail;
                        }

                    }

                    if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution)//State geçiş tamamlama butonu görüntülenmesi için en az biri bile tamamlanmamışsa buton görünmeyecek
                    {
                        viewModel.CanComplatePhysiotherapyRequest = false;
                    }
                }
            }

            viewModel.LastOrderDetailStartDate = Common.RecTime();
            viewModel.LastOrderDetailFinishDate = Common.RecTime();
            if (lastCompletedOrderDetail != null)//son seans tamamlama bilgileri tamamlama popup'ına set ediliyor
            {
                TimeSpan startTs = lastCompletedOrderDetail.StartDate.Value.TimeOfDay;
                viewModel.LastOrderDetailStartDate = viewModel.LastOrderDetailStartDate.Date + startTs;

                TimeSpan finishTs = lastCompletedOrderDetail.FinishDate.Value.TimeOfDay;
                viewModel.LastOrderDetailFinishDate = viewModel.LastOrderDetailFinishDate.Date + finishTs;

                viewModel.LastOrderDetailResponsiblePhysiotherapist = lastCompletedOrderDetail.StarterResUser;

            }

            viewModel.PhysiotherapySessionRate = TTUtils.CultureService.GetText("M27137", "Uygulanan seans:") + appliedSessionCount.ToString() + " / Toplam seans:" + totalSessionCount.ToString();

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

            viewModel.HasRole_Fizyoterapi_Uygulamasi_Uygulama = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Uygulamasi_Uygulama);
            viewModel.HasRole_Fizyoterapi_Uygulamasi_Durdurma = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Uygulamasi_Durdurma);
            viewModel.HasRole_Fizyoterapi_Uygulamasi_Hasta_Gelmedi = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Uygulamasi_Hasta_Gelmedi);
            viewModel.HasRole_Fizyoterapi_Uygulamasi_Iptal_Et = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Uygulamasi_Iptal_Et);
            viewModel.HasRole_Fizyoterapi_Tarih_Guncelleme = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Tarih_Guncelleme);
            viewModel.HasRole_Fizyoterapi_Ek_Islem = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Ek_Islem);
            viewModel.HasRole_Fizyoterapi_Uygulamasi_Geri_Alma = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Uygulamasi_Geri_Alma);

            //State geçiş tamamlama butonu görüntülenmesi için değişken
            //if (physiotherapyRequest.PhysiotherapyOrders.Select(c => c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception).Count() > 0)
            //{
            //    viewModel.CanComplatePhysiotherapyRequest = false;
            //}
            //else
            //{
            //    viewModel.CanComplatePhysiotherapyRequest = true;
            //}

            // NOT: alltaki viewmodel için kullanılacak
            viewModel.ProcedureObjectDataSource = PhysiotherapyDefinition.GetAllPhysiotherapyDefinitions(new TTObjectContext(true)).ToArray();


            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalışmamalı
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

            viewModel.TreatmentDiagnosisUnitInfos = new List<TreatmentDiagnosisUnitInfo>();
            if (userUnitIDs.Count > 0)
            {

                foreach (var item in PhysiotherapyOrder.GetDistinctTreatmentDiagnosisUnitsByRequest(physiotherapyRequest.ObjectID, userUnitIDs, null))
                {
                    if (item.TreatmentDiagnosisUnit != null)
                    {
                        var info = new TreatmentDiagnosisUnitInfo();
                        var unit = new ResTreatmentDiagnosisUnit();
                        unit = (ResTreatmentDiagnosisUnit)objectContext.GetObject<ResTreatmentDiagnosisUnit>(new Guid(item.TreatmentDiagnosisUnit?.ToString()), false);
                        info.TreatmentDiagnosisUnitID = unit.ObjectID;
                        info.TreatmentDiagnosisUnitName = unit.Name;
                        if (item.CurrentStateDefID == PhysiotherapyOrder.States.Completed)
                            info.State = "Sonlandırıldı";
                        else if (item.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception)
                            info.State = "Yeni";
                        viewModel.TreatmentDiagnosisUnitInfos.Add(info);
                    }

                }
            }

        }

        partial void PostScript_PhysiotherapyPlanningForm(PhysiotherapyPlanningFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel.selectedPhysiotherapyPlannedOrdersFormViewModel != null)
            {
                PhysiotherapyOrderServiceController.SavePhysiotherapyPlannedOrdersFormViewModelObject(objectContext, viewModel.selectedPhysiotherapyPlannedOrdersFormViewModel);
            }
            if (transDef != null && transDef.ToStateDefID == PhysiotherapyRequest.States.Completed)
            {
                var executedPhysiotherapyOrderDetails = physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution);
                if (executedPhysiotherapyOrderDetails.Count() > 0)
                {
                    foreach (var detail in executedPhysiotherapyOrderDetails)
                    {
                        detail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Aborted;//Yeni Durumunda olan İşlemler durduruldu durumuna çekiliyor!
                        detail.PhysiotherapyState = PhysiotherapyStateEnum.Aborted;
                        detail.IsChangedAutomatically = true;
                    }
                }
                if (physiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.Aborted || c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception || c.CurrentStateDefID == PhysiotherapyOrder.States.Rejected).Count() > 0)//Tamamlanmamış işlemler tamamlanıyor!
                {
                    foreach (var order in physiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.Aborted || c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception || c.CurrentStateDefID == PhysiotherapyOrder.States.Rejected))
                    {
                        order.CurrentStateDefID = PhysiotherapyOrder.States.Completed;
                        order.IsChangedAutomatically = true;
                    }
                }

            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Uygulamasi_Uygulama)]
        public void CompleteSelectedRecordsByID(PhysiotherapyPlanningFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyRequest request = objectContext.GetObject(viewModel._PhysiotherapyRequest.ObjectID, viewModel._PhysiotherapyRequest.ObjectDef) as PhysiotherapyRequest;
                IsSessionCompleted(request);
                if (request.SubEpisode.InpatientStatus == InpatientStatusEnum.Discharged)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25799", "Hasta taburcu edildiği için seçilileri tamamla işlemi yapamazsınız!"));
                }
                else
                {
                    List<OrderDetailInfo> model = viewModel.selectedRowKeysResultList;
                    List<PhysiotherapyOrderDetail> podList = new List<PhysiotherapyOrderDetail>();

                    for (int i = 0; i < model.Count; i++)
                    {
                        PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailItem.ObjectID, model[i].OrderDetailItem.ObjectDef) as PhysiotherapyOrderDetail;
                        podList.Add(orderDetail);


                        if (model[i].StartDate != null)
                        {
                            orderDetail.StartDate = model[i].StartDate;
                            if (orderDetail.PlannedDate != null)
                            {   //Planlama tarihinin saati işlem tamamlanırken işlemin tamamlandı dediği saati set ediyor.
                                DateTime plannedDateAndTime = orderDetail.PlannedDate.Value.Date + orderDetail.StartDate.Value.TimeOfDay;
                                orderDetail.PlannedDate = plannedDateAndTime;
                            }
                        }
                        if (model[i].FinishDate != null)
                        {
                            orderDetail.FinishDate = model[i].FinishDate;
                        }

                        if (orderDetail.PlannedDate != null)
                        {
                            orderDetail.PricingDate = orderDetail.PlannedDate;
                        }

                        if (orderDetail.PhysiotherapyOrder.PhysiotherapyReports == null && viewModel.Report != null)//raporu yoksa set et
                        {
                            orderDetail.PhysiotherapyOrder.PhysiotherapyReports = viewModel.Report;
                        }
                        if (orderDetail.PhysiotherapyOrder.PackageProcedure == null && viewModel.PackageProcedure != null)//paket yoksa set et
                        {
                            orderDetail.PhysiotherapyOrder.PackageProcedure = viewModel.PackageProcedure;
                        }
                        if (orderDetail.PhysiotherapyOrder.PackageProcedure == null && viewModel.PackageProcedure == null)//paket yoksa var olan order'ın paketini set et
                        {
                            orderDetail.PhysiotherapyOrder.PackageProcedure = GetPackageProcedureDefinition(model, orderDetail);
                        }


                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Complated;
                        orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Completed;
                        if (model[i].ResponsiblePhysiotherapist != null)
                        {
                            orderDetail.StarterResUser = model[i].ResponsiblePhysiotherapist;
                            orderDetail.FinisherResUser = model[i].ResponsiblePhysiotherapist;
                            orderDetail.ProcedureByUser = model[i].ResponsiblePhysiotherapist;
                        }
                        else
                        {
                            ResUser currentResUser = (ResUser)(TTUser.CurrentUser.UserObject);

                            if (orderDetail.StarterResUser == null)
                            {
                                orderDetail.StarterResUser = currentResUser;
                            }
                            if (orderDetail.FinisherResUser == null)
                            {
                                orderDetail.FinisherResUser = currentResUser;
                            }
                            if (orderDetail.ProcedureByUser == null)
                            {
                                orderDetail.ProcedureByUser = model[i].ResponsiblePhysiotherapist;
                            }
                        }

                        ////Order Detaillerin Hepsi Tamamlandı İse Order da tamamlanmalı
                        //orderDetail.PhysiotherapyOrder = CompletePhysiotherapyOrder(orderDetail.PhysiotherapyOrder );
                    }

                    ////Order'ların Hepsi Tamamlandı ise Tüm Seans/Tedavi Tamamlansın
                    //request = CompletePhysiotherapyRequest(request);

                    objectContext.Save();

                    // FTR Paketlerinin medulaya hizmet kaydı yapılması için 
                    PhysiotherapyOrderDetail.MedulaProcedureEntry(podList);
                }
            }
        }

        public PackageProcedureDefinition GetPackageProcedureDefinition(List<OrderDetailInfo> model, PhysiotherapyOrderDetail orderDetail)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PackageProcedureDefinition defaultPackageProcedure = null;

                foreach (var item in model.Where(t => t.TreatmentDiagnosisUnit == orderDetail.PhysiotherapyOrder.TreatmentDiagnosisUnit.Name))
                {
                    PhysiotherapyOrderDetail _orderDetail = objectContext.GetObject(item.OrderDetailItem.ObjectID, item.OrderDetailItem.ObjectDef) as PhysiotherapyOrderDetail;
                    if (_orderDetail != null && _orderDetail.PhysiotherapyOrder != null && _orderDetail.PhysiotherapyOrder.PackageProcedure != null)
                    {
                        defaultPackageProcedure = _orderDetail.PhysiotherapyOrder.PackageProcedure;
                        break;
                    }
                }
                if (defaultPackageProcedure == null)
                {
                    foreach (var item in model)
                    {
                        PhysiotherapyOrderDetail _orderDetail = objectContext.GetObject(item.OrderDetailItem.ObjectID, item.OrderDetailItem.ObjectDef) as PhysiotherapyOrderDetail;
                        if (_orderDetail != null && _orderDetail.PhysiotherapyOrder != null && _orderDetail.PhysiotherapyOrder.PackageProcedure != null)
                        {
                            defaultPackageProcedure = _orderDetail.PhysiotherapyOrder.PackageProcedure;
                            break;
                        }
                    }
                }
                return defaultPackageProcedure;
            }
        }

        [HttpPost]
        public void ChangeSessionsRecords(PhysiotherapyPlanningFormViewModel viewModel)//seansları yeniden hesapla
        {
            using (var objectContext = new TTObjectContext(false))
            {
                int changedSessionNumber = viewModel.ChangedOrderDetail.SessionNumber;

                List<PhysiotherapyOrderDetail> newOrderDetail = new List<PhysiotherapyOrderDetail>();

                foreach (var item in viewModel.OrderDetailInfoList.Where(c => c.SessionNumber == changedSessionNumber))
                {
                    if (item.OrderDetailItem.PhysiotherapyState != PhysiotherapyStateEnum.Complated)
                    {
                        newOrderDetail.Add(item.OrderDetailItem);
                    }
                }

                //List<PhysiotherapyOrderDetail> newOrderDetailList = ReCal(newOrderDetail, viewModel.ChangedOrderDetail.OrderDetailItem.PhysiotherapyOrder, changedSessionNumber, lastSessionNumber);

                //foreach (var item in newOrderDetailList)
                //{
                //    var selected = viewModel._PhysiotherapyRequest.PhysiotherapyOrderDetails.Where(x => x.ObjectID == item.ObjectID);
                //    if (selected != null && selected.Count() > 0)
                //    {
                //        viewModel._PhysiotherapyRequest.PhysiotherapyOrderDetails.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault().PlannedDate = item.PlannedDate;
                //    }
                //}


                //int sessionCount = 1;
                //foreach (var item in viewModel._PhysiotherapyRequest.PhysiotherapyOrderDetails.OrderBy(x => x.PlannedDate).GroupBy(c => c.SessionNumber))
                //{
                //    foreach (var orderDetailItem in item)
                //    {
                //        orderDetailItem.SessionNumber = sessionCount;
                //    }
                //    sessionCount++;
                //}

                objectContext.Save();
            }

        }

        public List<PhysiotherapyOrderDetail> ReCal(List<PhysiotherapyOrderDetail> newOrderDetail, PhysiotherapyOrder physiotherapyOrder, int changedSessionNumber)
        {
            DateTime _plannedDate = newOrderDetail.OrderBy(c => c.PlannedDate).FirstOrDefault().PlannedDate.Value;

            bool daySelectionActive = false;
            if (physiotherapyOrder.SeansGunSayisi != null)
            {
                daySelectionActive = false;
            }
            else if (physiotherapyOrder.IncludeSaturday != true || physiotherapyOrder.IncludeSunday != true)
            {
                daySelectionActive = false;
            }
            else
            {
                daySelectionActive = true;
            }


            for (int _sessionNumber = changedSessionNumber; _sessionNumber <= physiotherapyOrder.FinishSession; _sessionNumber++)
            {
                if (daySelectionActive == false)//Gün seçimi olmadan seans gün aralığı kullanarak planlama
                {
                    if (physiotherapyOrder.IncludeSaturday != true && physiotherapyOrder.IncludeSunday != true)//Haftasonu (Cts-Pazar) Dahil Değil 
                    {

                        if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan gün cts ise
                        {
                            _plannedDate.AddDays(1);
                        }
                        if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan gün pazar ise
                        {
                            _plannedDate.AddDays(1);
                        }
                        newOrderDetail[_sessionNumber].SessionNumber = _sessionNumber;
                        newOrderDetail[_sessionNumber].PlannedDate = _plannedDate;
                        _plannedDate = _plannedDate.AddDays(physiotherapyOrder.SeansGunSayisi.Value);
                    }
                    else
                    {
                        if (physiotherapyOrder.IncludeSaturday != true)//Cumartesi Dahil Değil
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan gün cts ise
                            {
                                _plannedDate.AddDays(1);
                            }
                            newOrderDetail[_sessionNumber].SessionNumber = _sessionNumber;
                            newOrderDetail[_sessionNumber].PlannedDate = _plannedDate;
                            _plannedDate = _plannedDate.AddDays(physiotherapyOrder.SeansGunSayisi.Value);
                        }
                        else if (physiotherapyOrder.IncludeSunday != true)//Pazar Dahil Değil
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan gün pazar ise
                            {
                                _plannedDate.AddDays(1);
                            }
                            newOrderDetail[_sessionNumber].SessionNumber = _sessionNumber;
                            newOrderDetail[_sessionNumber].PlannedDate = _plannedDate;
                            _plannedDate = _plannedDate.AddDays(physiotherapyOrder.SeansGunSayisi.Value);
                        }
                        else//Haftasonu Dahil
                        {
                            newOrderDetail[_sessionNumber].SessionNumber = _sessionNumber;
                            newOrderDetail[_sessionNumber].PlannedDate = _plannedDate;
                            _plannedDate = _plannedDate.AddDays(physiotherapyOrder.SeansGunSayisi.Value);
                        }
                    }
                }
                else
                {
                    bool isDateConflict = false;
                    while (isDateConflict)
                    {
                        if (physiotherapyOrder.IncludeMonday == true)//Pazartesi
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Monday)
                            {
                                newOrderDetail[_sessionNumber].SessionNumber = _sessionNumber;
                                newOrderDetail[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeTuesday == true)//Salı
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Tuesday)
                            {
                                newOrderDetail[_sessionNumber].SessionNumber = _sessionNumber;
                                newOrderDetail[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeWednesday == true)//Çarşamba
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Wednesday)
                            {
                                newOrderDetail[_sessionNumber].SessionNumber = _sessionNumber;
                                newOrderDetail[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeThursday == true)//Perşembe
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Thursday)
                            {
                                newOrderDetail[_sessionNumber].SessionNumber = _sessionNumber;
                                newOrderDetail[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeFriday == true)//Cuma
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Friday)
                            {
                                newOrderDetail[_sessionNumber].SessionNumber = _sessionNumber;
                                newOrderDetail[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeSaturday == true)//Cumartesi
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)
                            {
                                newOrderDetail[_sessionNumber].SessionNumber = _sessionNumber;
                                newOrderDetail[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeSunday == true)//Cumartesi
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)
                            {
                                newOrderDetail[_sessionNumber].SessionNumber = _sessionNumber;
                                newOrderDetail[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        _plannedDate = _plannedDate.AddDays(1);
                    }

                }

                newOrderDetail[_sessionNumber].PhysiotherapyState = PhysiotherapyStateEnum.New;

                newOrderDetail[_sessionNumber].PhysiotherapyOrder = physiotherapyOrder;
                newOrderDetail[_sessionNumber].PhysiotherapyRequest = physiotherapyOrder.PhysiotherapyRequest;
                newOrderDetail[_sessionNumber].ProcedureObject = physiotherapyOrder.ProcedureObject;
                newOrderDetail[_sessionNumber].CurrentStateDefID = PhysiotherapyOrderDetail.States.Execution;

                newOrderDetail[_sessionNumber].MasterResource = physiotherapyOrder.TreatmentDiagnosisUnit;
                newOrderDetail[_sessionNumber].Amount = 1;

                newOrderDetail[_sessionNumber].MedulaReportNo = physiotherapyOrder.PhysiotherapyReports.ReportNo;
                newOrderDetail[_sessionNumber].TreatmentRoom = physiotherapyOrder.TreatmentRoom;

                newOrderDetail[_sessionNumber].PricingDate = newOrderDetail[_sessionNumber].PlannedDate;

                //if (physiotherapyOrder.PhysiotherapyRequest.CurrentStateDefID == PhysiotherapyRequest.States.Planned)
                //{
                //    newOrderDetail[_sessionNumber].IsAdditionalTreatment = true;//Planlama Adımından sonra yapılan işlemler ek tedavi olarak görüntülenecek
                //}

                //if (transDef != null && transDef.ToStateDefID == PhysiotherapyRequest.States.Planned && transDef.FromStateDefID == PhysiotherapyRequest.States.RequestAcception)
                //{
                //    newOrderDetail[_sessionNumber].IsAdditionalTreatment = true;//Planlama Adımından sonra yapılan işlemler ek tedavi olarak görüntülenecek
                //}

                ////////////Prescripte yazılabilir!!!!
                //if (physiotherapyOrder.PhysiotherapyReports != null && physiotherapyOrder.PhysiotherapyReports.PackageProcedureInfo != null)
                //{
                //    var packageInfo = physiotherapyOrder.PhysiotherapyReports.PackageProcedureInfo;//Meduladan elde edilen paket numarası
                //    ProcedureDefinition definition = ProcedureDefinition.GetActiveByCode(objectContext, packageInfo);
                //    if (definition == null)
                //    {
                //        //exception
                //    }
                //    else if (definition is PackageProcedureDefinition)
                //    {
                //        if (((PackageProcedureDefinition)definition).PackageDefinition != null)
                //        {
                //            if (((PackageProcedureDefinition)definition).PackageDefinition.Count > 1)
                //            {
                //                //Çoklu
                //            }
                //            else
                //            {
                //                newOrderDetail[_sessionNumber].PackageDefinition = ((PackageProcedureDefinition)definition).PackageDefinition.FirstOrDefault();
                //            }
                //        }
                //        else
                //        {
                //            //Paket yok
                //        }

                //    }
                //    else
                //    {
                //        //exception
                //    }
                //}

                //if (physiotherapyOrder.StartSession.Value >= _sessionNumber)
                //{
                //    physiotherapyOrder.PhysiotherapyOrderDetails.Add(newOrderDetail[_sessionNumber]);
                //}


            }

            return newOrderDetail;
        }

        public void Recalculate(PhysiotherapyPlanningFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTObjectContext objectContext)
        {
            List<PhysiotherapyOrderDetail> _orderedList = physiotherapyOrder.PhysiotherapyOrderDetails.OrderBy(c => c.PlannedDate).ToList();
            int lastCompletedSession = 1;
            int changedSession = 1;

            for (int i = 0; i < _orderedList.Count; i++)
            {
                _orderedList[i].SessionNumber = (i + 1);

                if (_orderedList[i].PlannedDate == viewModel.OrderDetailInfoList.Where(c => c.OrderDetailItem.ObjectID == _orderedList[i].ObjectID).FirstOrDefault().PlannedDate)
                {
                    changedSession++;
                }
                if (_orderedList[i].PhysiotherapyState != PhysiotherapyStateEnum.New)
                {
                    lastCompletedSession = _orderedList[i].SessionNumber.Value;
                }
            }

            DateTime _plannedDate = _orderedList[lastCompletedSession].PlannedDate.Value;

            int _sessionStartNumber = changedSession > lastCompletedSession ? changedSession : lastCompletedSession;
            for (int _sessionNumber = _sessionStartNumber; _sessionNumber < viewModel.OrderDetailInfoList.FirstOrDefault().OrderDetailItem.PhysiotherapyOrder.FinishSession.Value; _sessionNumber++)
            {
                //PhysiotherapyOrderDetail _orderedList[_sessionNumber] = new PhysiotherapyOrderDetail(objectContext);
                bool daySelectionActive = false;
                if (physiotherapyOrder.SeansGunSayisi != null)
                {
                    daySelectionActive = false;
                }
                else if (physiotherapyOrder.IncludeSaturday != true || physiotherapyOrder.IncludeSunday != true)
                {
                    daySelectionActive = false;
                }
                else
                {
                    daySelectionActive = true;
                }

                if (daySelectionActive == false)//Gün seçimi olmadan seans gün aralığı kullanarak planlama
                {
                    if (physiotherapyOrder.IncludeSaturday != true && physiotherapyOrder.IncludeSunday != true)//Haftasonu (Cts-Pazar) Dahil Değil 
                    {

                        if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan gün cts ise
                        {
                            _plannedDate.AddDays(1);
                        }
                        if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan gün pazar ise
                        {
                            _plannedDate.AddDays(1);
                        }
                        _orderedList[_sessionNumber].SessionNumber = _sessionNumber;
                        _orderedList[_sessionNumber].PlannedDate = _plannedDate;
                        _plannedDate = _plannedDate.AddDays(physiotherapyOrder.SeansGunSayisi.Value);
                    }
                    else
                    {
                        if (physiotherapyOrder.IncludeSaturday != true)//Cumartesi Dahil Değil
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan gün cts ise
                            {
                                _plannedDate.AddDays(1);
                            }
                            _orderedList[_sessionNumber].SessionNumber = _sessionNumber;
                            _orderedList[_sessionNumber].PlannedDate = _plannedDate;
                            _plannedDate = _plannedDate.AddDays(physiotherapyOrder.SeansGunSayisi.Value);
                        }
                        else if (physiotherapyOrder.IncludeSunday != true)//Pazar Dahil Değil
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan gün pazar ise
                            {
                                _plannedDate.AddDays(1);
                            }
                            _orderedList[_sessionNumber].SessionNumber = _sessionNumber;
                            _orderedList[_sessionNumber].PlannedDate = _plannedDate;
                            _plannedDate = _plannedDate.AddDays(physiotherapyOrder.SeansGunSayisi.Value);
                        }
                        else//Haftasonu Dahil
                        {
                            _orderedList[_sessionNumber].SessionNumber = _sessionNumber;
                            _orderedList[_sessionNumber].PlannedDate = _plannedDate;
                            _plannedDate = _plannedDate.AddDays(physiotherapyOrder.SeansGunSayisi.Value);
                        }
                    }
                }
                else
                {
                    bool isDateConflict = false;
                    while (isDateConflict)
                    {
                        if (physiotherapyOrder.IncludeMonday == true)//Pazartesi
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Monday)
                            {
                                _orderedList[_sessionNumber].SessionNumber = _sessionNumber;
                                _orderedList[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeTuesday == true)//Salı
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Tuesday)
                            {
                                _orderedList[_sessionNumber].SessionNumber = _sessionNumber;
                                _orderedList[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeWednesday == true)//Çarşamba
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Wednesday)
                            {
                                _orderedList[_sessionNumber].SessionNumber = _sessionNumber;
                                _orderedList[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeThursday == true)//Perşembe
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Thursday)
                            {
                                _orderedList[_sessionNumber].SessionNumber = _sessionNumber;
                                _orderedList[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeFriday == true)//Cuma
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Friday)
                            {
                                _orderedList[_sessionNumber].SessionNumber = _sessionNumber;
                                _orderedList[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeSaturday == true)//Cumartesi
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)
                            {
                                _orderedList[_sessionNumber].SessionNumber = _sessionNumber;
                                _orderedList[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        if (physiotherapyOrder.IncludeSunday == true)//Cumartesi
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)
                            {
                                _orderedList[_sessionNumber].SessionNumber = _sessionNumber;
                                _orderedList[_sessionNumber].PlannedDate = _plannedDate;
                                isDateConflict = true;
                            }
                        }
                        _plannedDate = _plannedDate.AddDays(1);
                    }

                }

                _orderedList[_sessionNumber].PhysiotherapyState = PhysiotherapyStateEnum.New;

                _orderedList[_sessionNumber].PhysiotherapyOrder = physiotherapyOrder;
                _orderedList[_sessionNumber].PhysiotherapyRequest = physiotherapyOrder.PhysiotherapyRequest;
                _orderedList[_sessionNumber].ProcedureObject = physiotherapyOrder.ProcedureObject;
                _orderedList[_sessionNumber].CurrentStateDefID = PhysiotherapyOrderDetail.States.Execution;

                _orderedList[_sessionNumber].MasterResource = physiotherapyOrder.TreatmentDiagnosisUnit;
                _orderedList[_sessionNumber].Amount = 1;

                _orderedList[_sessionNumber].MedulaReportNo = physiotherapyOrder.PhysiotherapyReports.ReportNo;
                _orderedList[_sessionNumber].TreatmentRoom = physiotherapyOrder.TreatmentRoom;

                _orderedList[_sessionNumber].PricingDate = _orderedList[_sessionNumber].PlannedDate;

                //if (physiotherapyOrder.PhysiotherapyRequest.CurrentStateDefID == PhysiotherapyRequest.States.Planned)
                //{
                //    _orderedList[_sessionNumber].IsAdditionalTreatment = true;//Planlama Adımından sonra yapılan işlemler ek tedavi olarak görüntülenecek
                //}

                //if (transDef != null && transDef.ToStateDefID == PhysiotherapyRequest.States.Planned && transDef.FromStateDefID == PhysiotherapyRequest.States.RequestAcception)
                //{
                //    _orderedList[_sessionNumber].IsAdditionalTreatment = true;//Planlama Adımından sonra yapılan işlemler ek tedavi olarak görüntülenecek
                //}

                ////////////Prescripte yazılabilir!!!!
                if (physiotherapyOrder.PhysiotherapyReports != null && physiotherapyOrder.PhysiotherapyReports.PackageProcedureInfo != null)
                {
                    var packageInfo = physiotherapyOrder.PhysiotherapyReports.PackageProcedureInfo;//Meduladan elde edilen paket numarası
                    ProcedureDefinition definition = ProcedureDefinition.GetActiveByCode(objectContext, packageInfo);
                    if (definition == null)
                    {
                        //exception
                    }
                    else if (definition is PackageProcedureDefinition)
                    {
                        if (((PackageProcedureDefinition)definition).PackageDefinition != null)
                        {
                            if (((PackageProcedureDefinition)definition).PackageDefinition.Count > 1)
                            {
                                //Çoklu
                            }
                            else
                            {
                                _orderedList[_sessionNumber].PackageDefinition = ((PackageProcedureDefinition)definition).PackageDefinition.FirstOrDefault();
                            }
                        }
                        else
                        {
                            //Paket yok
                        }

                    }
                    else
                    {
                        //exception
                    }
                }

                //physiotherapyOrder.PhysiotherapyOrderDetails.Add(_physiotherapyOrderDetail);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Uygulamasi_Iptal_Et)]
        public void DeleteSelectedRecordsByID(List<OrderDetailInfo> model)
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

                    ////Order Detaillerin Hepsi Tamamlandı İse Order da tamamlanmalı
                    //orderDetail.PhysiotherapyOrder = CompletePhysiotherapyOrder(orderDetail.PhysiotherapyOrder);

                    ////Order'ların Hepsi Tamamlandı ise Tüm Seans/Tedavi Tamamlansın
                    //request = CompletePhysiotherapyRequest(request);
                }

                objectContext.Save();
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Tarih_Guncelleme)]
        public void SaveDateRecords(List<OrderDetailInfo> model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                //Max5DaysControlByInfoList(model);

                for (int i = 0; i < model.Count; i++)
                {
                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailItem.ObjectID, model[i].OrderDetailItem.ObjectDef) as PhysiotherapyOrderDetail;
                    IsSessionCompleted(orderDetail.PhysiotherapyRequest != null ? orderDetail.PhysiotherapyRequest : orderDetail.PhysiotherapyOrder.PhysiotherapyRequest);

                    if (orderDetail.PlannedDate == null || orderDetail.PlannedDate.Value.Date != model[i].PlannedDate.Date)
                    {
                        orderDetail.PlannedDate = model[i].PlannedDate;
                        orderDetail.PricingDate = orderDetail.PlannedDate;
                    }
                }
                objectContext.Save();
            }

        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Uygulamasi_Durdurma)]
        public void AbortSelectedRecordsByID(List<OrderDetailInfo> model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                for (int i = 0; i < model.Count; i++)
                {
                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailItem.ObjectID, model[i].OrderDetailItem.ObjectDef) as PhysiotherapyOrderDetail;
                    PhysiotherapyRequest request = orderDetail.PhysiotherapyRequest != null ? orderDetail.PhysiotherapyRequest : orderDetail.PhysiotherapyOrder.PhysiotherapyRequest;
                    IsSessionCompleted(request);

                    orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Aborted;
                    orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Aborted;

                    ResUser currentResUser = (ResUser)(TTUser.CurrentUser.UserObject);

                    if (orderDetail.StarterResUser == null)
                    {
                        orderDetail.StarterResUser = currentResUser;
                    }
                    orderDetail.FinisherResUser = currentResUser;

                    ////Order Detaillerin Hepsi Tamamlandı İse Order da tamamlanmalı
                    //orderDetail.PhysiotherapyOrder = CompletePhysiotherapyOrder(orderDetail.PhysiotherapyOrder);


                    ////Order'ların Hepsi Tamamlandı ise Tüm Seans/Tedavi Tamamlansın
                    //request = CompletePhysiotherapyRequest(request);
                }


                objectContext.Save();
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Uygulamasi_Hasta_Gelmedi)]
        public void NotComeSelectedRecordsByID(List<OrderDetailInfo> model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                for (int i = 0; i < model.Count; i++)
                {
                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailItem.ObjectID, model[i].OrderDetailItem.ObjectDef) as PhysiotherapyOrderDetail;
                    IsSessionCompleted(orderDetail.PhysiotherapyRequest != null ? orderDetail.PhysiotherapyRequest : orderDetail.PhysiotherapyOrder.PhysiotherapyRequest);

                    orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.NotCome;
                    //orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Aborted;

                    ResUser currentResUser = (ResUser)(TTUser.CurrentUser.UserObject);

                    if (orderDetail.StarterResUser == null)
                    {
                        orderDetail.StarterResUser = currentResUser;
                    }
                    orderDetail.FinisherResUser = currentResUser;
                }

                objectContext.Save();
            }
        }


        public void Max5DaysControl(List<PhysiotherapyOrderDetail> orderDetailList)
        {
            List<PhysiotherapyOrderDetail> _orderDetailList = orderDetailList.OrderBy(c => c.PlannedDate).ToList();

            for (int i = 1; i < orderDetailList.Count(); i++)
            {
                var dayDifference = ((_orderDetailList[i].PlannedDate.Value.Date) - (_orderDetailList[i - 1].PlannedDate.Value.Date)).TotalDays;
                int weekendCount = 0;
                if (dayDifference > 5)
                {
                    if (dayDifference > 7)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26035", "İki seans arasındaki fark 5 iş gününden fazla olamaz!"));
                    }
                    else
                    {
                        var previousPlannedDate = _orderDetailList[i].PlannedDate;
                        while (previousPlannedDate != _orderDetailList[i].PlannedDate)
                        {
                            if (previousPlannedDate.Value.DayOfWeek == DayOfWeek.Saturday)//Planlanan gün cts ise
                            {
                                weekendCount++;
                            }
                            else if (previousPlannedDate.Value.DayOfWeek == DayOfWeek.Saturday)//Planlanan gün pazar ise
                            {
                                weekendCount++;
                            }
                        }

                        if ((dayDifference + weekendCount) > 7)
                        {
                            throw new Exception(TTUtils.CultureService.GetText("M26035", "İki seans arasındaki fark 5 iş gününden fazla olamaz!"));
                        }
                    }
                }
            }
        }


        public void Max5DaysControlByInfoList(List<OrderDetailInfo> orderDetailList)
        {
            List<OrderDetailInfo> _orderDetailList = orderDetailList.OrderBy(c => c.PlannedDate).ToList();

            for (int i = 1; i < orderDetailList.Count(); i++)
            {
                var dayDifference = ((_orderDetailList[i].OrderDetailItem.PlannedDate.Value.Date) - (_orderDetailList[i - 1].OrderDetailItem.PlannedDate.Value.Date)).TotalDays;
                int weekendCount = 0;
                if (dayDifference > 5)
                {
                    if (dayDifference > 7)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26035", "İki seans arasındaki fark 5 iş gününden fazla olamaz!"));
                    }
                    else
                    {
                        var previousPlannedDate = _orderDetailList[i].OrderDetailItem.PlannedDate;
                        while (previousPlannedDate != _orderDetailList[i].OrderDetailItem.PlannedDate)
                        {
                            if (previousPlannedDate.Value.DayOfWeek == DayOfWeek.Saturday)//Planlanan gün cts ise
                            {
                                weekendCount++;
                            }
                            else if (previousPlannedDate.Value.DayOfWeek == DayOfWeek.Saturday)//Planlanan gün pazar ise
                            {
                                weekendCount++;
                            }
                        }

                        if ((dayDifference + weekendCount) > 7)
                        {
                            throw new Exception(TTUtils.CultureService.GetText("M26035", "İki seans arasındaki fark 5 iş gününden fazla olamaz!"));
                        }
                    }
                }
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Uygulamasi_Geri_Alma)]
        public void UndoRecords(List<OrderDetailInfo> model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<PhysiotherapyOrderDetail> podList = new List<PhysiotherapyOrderDetail>();
                for (int i = 0; i < model.Count; i++)
                {
                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailItem.ObjectID, model[i].OrderDetailItem.ObjectDef) as PhysiotherapyOrderDetail;
                    //IsSessionCompleted(orderDetail.PhysiotherapyRequest != null ? orderDetail.PhysiotherapyRequest : orderDetail.PhysiotherapyOrder.PhysiotherapyRequest);

                    // Completed dan Execution a geri dönülüyorsa
                    if (orderDetail.PrevState != null && orderDetail.PrevState.StateDefID == PhysiotherapyOrderDetail.States.Execution && orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed)
                        podList.Add(orderDetail);
                }
                // FTR Paket ve hizmetlerinin medula hizmet kayıtlarını iptal eder 
                PhysiotherapyOrderDetail.MedulaProcedureEntryCancel(podList);
                objectContext.Save();

                for (int i = 0; i < model.Count; i++)
                {
                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailItem.ObjectID, model[i].OrderDetailItem.ObjectDef) as PhysiotherapyOrderDetail;
                    PhysiotherapyRequest request = orderDetail.PhysiotherapyRequest != null ? orderDetail.PhysiotherapyRequest : orderDetail.PhysiotherapyOrder.PhysiotherapyRequest;
                    IsSessionCompleted(request);

                    if (orderDetail.PrevState != null)
                    {
                        if (orderDetail.PrevState.StateDefID == PhysiotherapyOrderDetail.States.Execution)
                        {
                            orderDetail.StarterResUser = null;
                            orderDetail.StartDate = null;
                            orderDetail.FinishDate = null;
                        }

                        //Tamamlanmış orderdetail geri alınmışsa order da tamamlandı durumundan geri alınmalı
                        if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed && orderDetail.PrevState.StateDefID != PhysiotherapyOrderDetail.States.Completed)
                        {
                            orderDetail.PhysiotherapyOrder.CurrentStateDefID = PhysiotherapyOrder.States.RequestAcception;
                            //Request tamamlandı durumunda ise geri alınmalı
                            if (request.CurrentStateDefID == PhysiotherapyRequest.States.Completed)
                            {
                                request.CurrentStateDefID = request.PrevState.StateDefID;
                            }
                        }

                        orderDetail.CurrentStateDefID = orderDetail.PrevState.StateDefID;
                    }

                    if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Aborted)
                    {
                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Aborted;
                    }
                    if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Cancelled)
                    {
                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Cancel;
                    }
                    if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed)
                    {
                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Complated;
                    }
                    if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution)
                    {
                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.New;
                    }


                    ////Order Detaillerin Hepsi Tamamlandı İse Order da tamamlanmalı
                    //if (orderDetail.PhysiotherapyOrder.PhysiotherapyOrderDetails.Select(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution).Count() == 0)
                    //{
                    //    orderDetail.PhysiotherapyOrder = CompletePhysiotherapyOrder(orderDetail.PhysiotherapyOrder);
                    //}
                    //else //Tamamlanmış orderdetail geri alınmışsa order da tamamlandı durumundan geri alınmalı
                    //{
                    //    orderDetail.PhysiotherapyOrder.CurrentStateDefID = PhysiotherapyOrder.States.RequestAcception;
                    //}

                    ////Order'ların Hepsi Tamamlandı ise Tüm Seans/Tedavi Tamamlansın
                    //request = CompletePhysiotherapyRequest(request);
                }

                objectContext.Save();
            }
        }

        public void CancelPhysiotherapyRequest(PhysiotherapyPlanningFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyRequest request = objectContext.GetObject(viewModel._PhysiotherapyRequest.ObjectID, viewModel._PhysiotherapyRequest.ObjectDef) as PhysiotherapyRequest;
                IsSessionCompleted(request);
                if (request.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed).Count() > 0)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M27031", "Tamamlanmış işlemleri olan tedavi isteğini iptal edemezsiniz!"));
                }
                request.CurrentStateDefID = PhysiotherapyRequest.States.Cancelled;

                objectContext.Save();

                #region Seans Sonlandırma
                EpisodeActionServiceController easc = new EpisodeActionServiceController();
                string _message = request.Episode.Patient.Name + " " + request.Episode.Patient.Surname + " isimli takipli hastanın " + request.SubEpisode.ProtocolNo + " 'lu kabulüne ait F.T.R seans sonlandırma işlemi yapılmıştır";
                easc.FindTrackingFollowers(request.Episode.Patient.ObjectID, request.SubEpisode.ObjectID, true, true, _message, _message, SMSTypeEnum.FTRSessionCompleted);
                easc.Dispose();
                #endregion
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Emri_Tamamlandi)]
        public void CompleteSessionsByUnit(Guid PhysiotherapyRequestObjectID, Guid PhysiotherapyRequestObjectDefID, Guid TreatmentDiagnosisUnitID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class> PhysiotherapyOrders = PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest(PhysiotherapyRequestObjectID, TreatmentDiagnosisUnitID).ToList();
                OrderInfo orderInfo = new OrderInfo();
                foreach (var physiotherapyOrder in PhysiotherapyOrders)
                {
                    if (physiotherapyOrder.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception)
                    {
                        orderInfo.OrderObjectId = (Guid)physiotherapyOrder?.ObjectID;
                        orderInfo.OrderObjectDefId = (Guid)physiotherapyOrder?.ObjectDefID;
                        CompleteSession(orderInfo);
                    }
                    //else
                    //{
                    //    PhysiotherapyOrder order = objectContext.GetObject(physiotherapyOrder.ObjectID.Value, physiotherapyOrder.ObjectDefID.Value) as PhysiotherapyOrder;
                    //    //Order'ların Hepsi Tamamlandı ise Tüm Seans Tamamlansın
                    //    if (order.PhysiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception).Count() == 0)
                    //    {
                    //        order.PhysiotherapyRequest.CurrentStateDefID = PhysiotherapyRequest.States.Completed;
                    //    }

                    //    objectContext.Save();
                    //}
                }


                PhysiotherapyRequest _request = objectContext.GetObject(PhysiotherapyRequestObjectID, PhysiotherapyRequestObjectDefID) as PhysiotherapyRequest;
                //Order'ların Hepsi Tamamlandı ise Tüm Seans Tamamlansın
                if (_request.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception).Count() == 0)
                {
                    _request.CurrentStateDefID = PhysiotherapyRequest.States.Completed;
                }

                objectContext.Save();
            }
        }

        [HttpGet]
        public void UndoCompleteSessionsByUnit(Guid PhysiotherapyRequestObjectID, Guid TreatmentDiagnosisUnitID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class> PhysiotherapyOrders = PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest(PhysiotherapyRequestObjectID, TreatmentDiagnosisUnitID, " AND this.CURRENTSTATEDEFID <> STATES.Cancelled").ToList();
                OrderInfo orderInfo = new OrderInfo();
                foreach (var physiotherapyOrder in PhysiotherapyOrders)
                {
                    if (physiotherapyOrder.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception)
                    {
                        throw new TTException("Yeni eklenmiş seanslar üzerinde geri alma işlemi yapılamamaktadır!");
                    }
                    else
                    {
                        orderInfo.OrderObjectId = (Guid)physiotherapyOrder?.ObjectID;
                        orderInfo.OrderObjectDefId = (Guid)physiotherapyOrder?.ObjectDefID;
                        UndoCompleteSession(orderInfo);
                    }
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Emri_Tamamlandi)]
        public void CompleteSession(OrderInfo physiotherapyOrder)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyOrder order = objectContext.GetObject(physiotherapyOrder.OrderObjectId, physiotherapyOrder.OrderObjectDefId) as PhysiotherapyOrder;
                IsSessionCompleted(order.PhysiotherapyRequest);

                var executionOrderDetail = order.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution);
                if (executionOrderDetail.Count() > 0)//Tamamlanmış,Durdurulmuş,Silinmiş durumunda olmayan/Yeni durumunda olan işlemler durduruluyor.
                {
                    foreach (var orderDetail in executionOrderDetail)
                    {
                        orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Aborted;
                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Aborted;
                        orderDetail.IsChangedAutomatically = true;
                    }
                }

                order.CurrentStateDefID = PhysiotherapyOrder.States.Completed;

                ////Order'ların Hepsi Tamamlandı ise Tüm Seans Tamamlansın
                //if (order.PhysiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception).Count() == 0)
                //{
                //    order.PhysiotherapyRequest.CurrentStateDefID = PhysiotherapyRequest.States.Completed;
                //}

                objectContext.Save();


            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Emri_Tamamlandi)]
        public void UndoCompleteSession(OrderInfo physiotherapyOrder)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyOrder order = objectContext.GetObject(physiotherapyOrder.OrderObjectId, physiotherapyOrder.OrderObjectDefId) as PhysiotherapyOrder;
                //IsSessionCompleted(order.PhysiotherapyRequest);

                var changedAutomaticallyOrderDetail = order.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Aborted && c.IsChangedAutomatically == true);
                if (changedAutomaticallyOrderDetail.Count() > 0)//İşlemler geri alınıyor.
                {
                    foreach (var orderDetail in changedAutomaticallyOrderDetail)
                    {
                        orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Execution;
                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.New;
                        orderDetail.IsChangedAutomatically = false;
                    }
                }

                order.CurrentStateDefID = PhysiotherapyOrder.States.RequestAcception;

                //Order'lar geri alınırken tüm tedavi sonlandırıldı ise sonlandırma geri alınmalı
                if (order.PhysiotherapyRequest.CurrentStateDefID == PhysiotherapyRequest.States.Completed)
                {
                    order.PhysiotherapyRequest.CurrentStateDefID = order.PhysiotherapyRequest.PrevState.StateDefID;
                }

                objectContext.Save();
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Emri_Tamamlandi)]
        public void DeleteSession(OrderInfo physiotherapyOrder)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyOrder order = objectContext.GetObject(physiotherapyOrder.OrderObjectId, physiotherapyOrder.OrderObjectDefId) as PhysiotherapyOrder;
                IsSessionCompleted(order.PhysiotherapyRequest);

                var notCancelledOrderDetail = order.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled);
                if (notCancelledOrderDetail.Count() > 0)//İşlemler iptal ediliyor.
                {
                    foreach (var orderDetail in notCancelledOrderDetail)
                    {
                        orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;
                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Cancel;
                        orderDetail.IsChangedAutomatically = true;
                    }
                }

                order.CurrentStateDefID = PhysiotherapyOrder.States.Cancelled;

                objectContext.Save();
            }
        }


        private void IsSessionCompleted(PhysiotherapyRequest request)
        {
            if (request.CurrentStateDefID == PhysiotherapyRequest.States.Completed)
            {
                throw new Exception(TTUtils.CultureService.GetText("M27031", "Tamamlanmış tedavi üzerinde işlem yapamazsınız!"));
            }
        }


        //private PhysiotherapyOrder CompletePhysiotherapyOrder(PhysiotherapyOrder order)//Order Detaillerin Hepsi Tamamlandı İse Order da tamamlanmalı
        //{
        //    //Order Detaillerin Hepsi Tamamlandı İse Order da tamamlanmalı
        //    if (order.PhysiotherapyOrderDetails.Select(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution).Count() == 0)
        //    {
        //        order.CurrentStateDefID = PhysiotherapyOrder.States.Completed;
        //    }

        //    return order;
        //}

        //private PhysiotherapyRequest CompletePhysiotherapyRequest(PhysiotherapyRequest request)//Order'ların Hepsi Tamamlandı ise Tüm Seans/Tedavi Tamamlansın
        //{
        //    //Order'ların Hepsi Tamamlandı ise Tüm Seans/Tedavi Tamamlansın
        //    if (request.PhysiotherapyOrders.Select(c => c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception).Count() == 0)
        //    {
        //        request.CurrentStateDefID = PhysiotherapyRequest.States.Completed;
        //    }

        //    return request;
        //}


        protected void removeOutgoingTransitions(PhysiotherapyPlanningFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest)
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
    }
}


namespace Core.Models
{
    public partial class PhysiotherapyPlanningFormViewModel
    {
        public List<OrderDetailInfo> selectedRowKeysResultList { get; set; }

        public string Message { get; set; }

        public List<ReportItem> ReportItemList { get; set; }

        public PackageProcedureDefinition PackageProcedure { get; set; }
        public PhysiotherapyReports Report { get; set; }
        public TreatmentQueryReportTypeEnum TreatmentType { get; set; }

        public bool CanComplatePhysiotherapyRequest { get; set; }

        //Yetki Kontrolü
        public bool HasRole_Fizyoterapi_Uygulamasi_Uygulama;
        public bool HasRole_Fizyoterapi_Uygulamasi_Durdurma;
        public bool HasRole_Fizyoterapi_Uygulamasi_Hasta_Gelmedi;
        public bool HasRole_Fizyoterapi_Uygulamasi_Iptal_Et;
        public bool HasRole_Fizyoterapi_Tarih_Guncelleme;
        public bool HasRole_Fizyoterapi_Ek_Islem;
        public bool HasRole_Fizyoterapi_Uygulamasi_Geri_Alma;

        public bool IsPhysiotherapyRequestFormUsing { get; set; }//Sistem parametresi kontrol

        public string MedicalInfo { get; set; }
        public string AnamnesisComplaintInfo { get; set; }
        public string AnamnesisPatientHistoryInfo { get; set; }
        public string AnamnesisPhysicalExaminationInfo { get; set; }
        public string AnamnesisMTSConclusionInfo { get; set; }
        public bool HideAnamnesisInfoButton = true;

        public List<TreatmentDiagnosisUnitInfo> TreatmentDiagnosisUnitInfos { get; set; }

        public string PatientObjectId { get; set; }

        public OrderDetailInfo ChangedOrderDetail { get; set; }

        public List<OrderDetailInfo> OrderDetailInfoList { get; set; }
        public List<OrderDetailInfo> AdditionalOrderDetailInfoList { get; set; }//Ek Tedavi

        public string PhysiotherapySessionRate { get; set; }

        public List<OrderInfo> PhysiotherapyOrderList { get; set; }
        public PhysiotherapyPlannedOrdersFormViewModel selectedPhysiotherapyPlannedOrdersFormViewModel { get; set; }

        public DateTime LastOrderDetailStartDate { get; set; }
        public DateTime LastOrderDetailFinishDate { get; set; }
        public ResUser LastOrderDetailResponsiblePhysiotherapist { get; set; }

        public ProcedureDefinition[] ProcedureObjectDataSource { get; set; }


    }
    public class TreatmentDiagnosisUnitInfo
    {
        public Guid TreatmentDiagnosisUnitID;
        public string State;
        public string TreatmentDiagnosisUnitName;
        public string TreatmentNote;
        public string TreatmentNoteId;
    }


    public class OrderDetailInfo
    {
        public int SessionNumber { get; set; }
        public DateTime PlannedDate { get; set; }
        public string PhysiotherapyState { get; set; }
        public string ApplicationAreaDef { get; set; }
        public string ApplicationAreaInfo { get; set; }
        public string TreatmentDiagnosisUnit { get; set; }
        public string Duration { get; set; }
        public string Dose { get; set; }
        public string DoseDurationInfo { get; set; }
        public string Physiotherapist { get; set; }
        public Boolean IsAdditionalProcess { get; set; }//order detail ek işlem
        public Boolean IsAdditionalTreatment { get; set; }//order detail ek tedavi
        public Guid CurrentUserObjectId { get; set; }//İşlemi Yapan
        public string ProcedureObject { get; set; }//Fizyoterapi işlemi
        public string Package { get; set; }

        public string TreatmentProperties { get; set; }//Açıklama

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ResUser ResponsiblePhysiotherapist { get; set; }

        public PhysiotherapyOrderDetail OrderDetailItem { get; set; }
        public string StartTime { get; set; }//Tedavi Başlangıç Saati
        public string FinishTime { get; set; }//Tedavi Başlangıç Saati
    }



    public class OrderInfo
    {
        public string TreatmentDiagnosisUnit { get; set; }
        public string ApplicationArea { get; set; }
        public string ApplicationAreaInfo { get; set; }
        public string ProcedureObject { get; set; }//Fizyoterapi işlemi
        public int SessionCount { get; set; }
        public string Duration { get; set; }
        public string Dose { get; set; }
        public string TreatmentProperties { get; set; }

        public bool IsPlannedBefore { get; set; }//Planlanmış tedavi mi kontrolü

        public Guid CurrentStateDefID { get; set; }
        public Guid OrderObjectId { get; set; }
        public Guid OrderObjectDefId { get; set; }
    }

}
