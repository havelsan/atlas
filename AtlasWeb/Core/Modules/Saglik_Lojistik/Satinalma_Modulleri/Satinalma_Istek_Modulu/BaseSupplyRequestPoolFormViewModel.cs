//$A833C968
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class SupplyRequestPoolServiceController
    {
        partial void AfterContextSaveScript_BaseSupplyRequestPoolForm(BaseSupplyRequestPoolFormViewModel viewModel, SupplyRequestPool supplyRequestPool, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID == SupplyRequestPool.States.Approval)
                {
                    foreach (SupplyRequestPoolDetail poolDet in supplyRequestPool.SupplyRequestPoolDetails)
                    {
                        foreach (SupplyRequestDetail det in poolDet.SupplyRequestDetails)
                        {
                            det.SupplyRequestStatus = SupplyRequestStatusEnum.AccountingApproval;
                        }
                    }
                }

                if (transDef.ToStateDefID == SupplyRequestPool.States.Completed)
                {
                    foreach (SupplyRequestPoolDetail poolDet in supplyRequestPool.SupplyRequestPoolDetails)
                    {
                        if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.ToBeSent)
                            poolDet.SupplyRqstPlDetStatus = SupplyRqstPlDetStatusEnum.Sent;
                        foreach (SupplyRequestDetail det in poolDet.SupplyRequestDetails)
                        {
                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.Cancelled)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.RequestCancelled;
                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.SupplyWithExcess)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.SupplyWithExcess;
                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.Sent)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.RequestCompleted;
                        }
                    }
                }

                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public partial class BaseSupplyRequestPoolFormViewModel
    {
    }
}