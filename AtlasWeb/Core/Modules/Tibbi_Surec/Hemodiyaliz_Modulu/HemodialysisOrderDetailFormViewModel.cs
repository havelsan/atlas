//$FD74F936
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class HemodialysisOrderDetailServiceController
    {
        partial void PreScript_HemodialysisOrderDetailForm(HemodialysisOrderDetailFormViewModel viewModel, HemodialysisOrderDetail hemodialysisOrderDetail, TTObjectContext objectContext)
        {
            viewModel.IsCatheterCareDone = false;//Katater bakýmý yapýlmadý
            viewModel.IsAVFCareCareDone = false;//Avf bakýmý yapýlmadý
            var previousOrderDetail = hemodialysisOrderDetail.HemodialysisOrder.HemodialysisOrderDetails.Where(x => x.SessionDate < hemodialysisOrderDetail.SessionDate).OrderByDescending(c => c.SessionDate).FirstOrDefault();//Þu anda açýlan orderDetail'den bir önceki order detail bulunuyor.
            if (previousOrderDetail != null && previousOrderDetail.CatheterCare == true)
            {
                viewModel.IsCatheterCareDone = true;//Katater bakýmý yapýldý
            }
            if (previousOrderDetail != null && previousOrderDetail.AVFCare == true)
            {
                viewModel.IsAVFCareCareDone = true;//AVF bakýmý yapýldý
            }
        }


        public HemodialysisOrderDetail getPreviousOrderDetail(HemodialysisOrderDetailFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                HemodialysisOrderDetail hemodialysisOrderDetail = objectContext.GetObject(viewModel._HemodialysisOrderDetail.ObjectID, viewModel._HemodialysisOrderDetail.ObjectDef) as HemodialysisOrderDetail;
                BindingList<HemodialysisOrderDetail> previousDetailList = HemodialysisOrderDetail.GetPreviousOrderDetailByRequest(objectContext, hemodialysisOrderDetail.HemodialysisRequest.ObjectID.ToString(), hemodialysisOrderDetail.SessionDate.Value);
                if (previousDetailList.Count() > 0)
                {
                    return previousDetailList.FirstOrDefault();
                }
                else
                {
                    throw new Exception("Seans bilgisi bulunamadý!");
                }
            }
        }

        //public HemodialysisOrderDetail getPreviousOrderDetail(string requestObjectId, DateTime sessionDate)
        //{
        //    using (var objectContext = new TTObjectContext(false))
        //    {
        //        BindingList<HemodialysisOrderDetail> previousDetailList = HemodialysisOrderDetail.GetPreviousOrderDetailByRequest(objectContext, requestObjectId, sessionDate);
        //        if (previousDetailList.Count() > 0)
        //        {
        //            return previousDetailList.FirstOrDefault();
        //        }
        //        else
        //        {
        //            throw new Exception("Seans bilgisi bulunamadý!");
        //        }
        //    }
        //}
    }
}

namespace Core.Models
{
    public partial class HemodialysisOrderDetailFormViewModel : BaseViewModel
    {
        public bool IsCatheterCareDone { get; set; }//Bir önceki seansta Katater bakýmý yapýldý ise true
        public bool IsAVFCareCareDone { get; set; }//Bir önceki seansta AVF bakýmý yapýldý ise true
    }
}
