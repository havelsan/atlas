//$F8289657
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class PhysiotherapyRequestServiceController
    {
        partial void PreScript_OldPhysiotherapyRequestForm(OldPhysiotherapyRequestFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTObjectContext objectContext)
        {
            viewModel.ProcedureDoctorName = physiotherapyRequest.ProcedureDoctor != null ? physiotherapyRequest.ProcedureDoctor.Name : "";

            viewModel.PhysiotherapyOrderList = new List<OrderInfo>();
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

            viewModel.OrderDetailInfoList = new List<OrderDetailInfo>();
            viewModel.AdditionalOrderDetailInfoList = new List<OrderDetailInfo>();

            foreach (var orderDetail in physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).OrderBy(x => x.SessionNumber))
            {

                if (orderDetail.PhysiotherapyOrder == null)// hatalý veri iptal yapýlýyor
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
                }
            }

        }
    }
}

namespace Core.Models
{
    public partial class OldPhysiotherapyRequestFormViewModel
    {
        public string ProcedureDoctorName { get; set; }

        public List<OrderInfo> PhysiotherapyOrderList { get; set; }

        public List<OrderDetailInfo> OrderDetailInfoList { get; set; }
        public List<OrderDetailInfo> AdditionalOrderDetailInfoList { get; set; }//Ek Tedavi
    }

    //public class PhysiotherapyInfo
    //{
    //    public string TreatmentDiagnosisUnit { get; set; }
    //    public string ProcedureObject { get; set; }
    //    public DateTime PhysiotherapyStartDate { get; set; }
    //    public string TreatmentProperties { get; set; }
    //    public int Duration { get; set; }
    //    public string FTRApplicationAreaDef { get; set; }
    //    public string Dose { get; set; }
    //    public string PackageProcedure { get; set; }
    //    public string ApplicationArea { get; set; }
    //    public string DoseDurationInfo { get; set; }
    //    public string ReportNo { get; set; }

    //}
}
