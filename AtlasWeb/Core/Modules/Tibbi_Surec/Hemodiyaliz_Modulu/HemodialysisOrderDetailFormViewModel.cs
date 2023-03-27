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
            viewModel.IsCatheterCareDone = false;//Katater bak�m� yap�lmad�
            viewModel.IsAVFCareCareDone = false;//Avf bak�m� yap�lmad�
            var previousOrderDetail = hemodialysisOrderDetail.HemodialysisOrder.HemodialysisOrderDetails.Where(x => x.SessionDate < hemodialysisOrderDetail.SessionDate).OrderByDescending(c => c.SessionDate).FirstOrDefault();//�u anda a��lan orderDetail'den bir �nceki order detail bulunuyor.
            if (previousOrderDetail != null && previousOrderDetail.CatheterCare == true)
            {
                viewModel.IsCatheterCareDone = true;//Katater bak�m� yap�ld�
            }
            if (previousOrderDetail != null && previousOrderDetail.AVFCare == true)
            {
                viewModel.IsAVFCareCareDone = true;//AVF bak�m� yap�ld�
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
                    throw new Exception("Seans bilgisi bulunamad�!");
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
        //            throw new Exception("Seans bilgisi bulunamad�!");
        //        }
        //    }
        //}
    }
}

namespace Core.Models
{
    public partial class HemodialysisOrderDetailFormViewModel : BaseViewModel
    {
        public bool IsCatheterCareDone { get; set; }//Bir �nceki seansta Katater bak�m� yap�ld� ise true
        public bool IsAVFCareCareDone { get; set; }//Bir �nceki seansta AVF bak�m� yap�ld� ise true
    }
}
