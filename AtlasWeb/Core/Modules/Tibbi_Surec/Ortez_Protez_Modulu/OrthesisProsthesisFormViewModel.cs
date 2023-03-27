//$88F8170C
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
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class OrthesisProsthesisRequestServiceController
    {
        private object _OrthesisProsthesisRequest;

        partial void PreScript_OrthesisProsthesisForm(OrthesisProsthesisFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTObjectContext objectContext)
        {
            if (orthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.States.Procedure && orthesisProsthesisRequest.ProcessDate == null)
                orthesisProsthesisRequest.ProcessDate = Common.RecTime();

            viewModel.RequesterUnit = orthesisProsthesisRequest.FromResource.Name;
            if (orthesisProsthesisRequest.RequesterUsr == null)
            {
                var usr = ((TTObject)orthesisProsthesisRequest).GetState("Request", false);
                if (usr != null)
                {
                    orthesisProsthesisRequest.RequesterUsr = usr.UserID;
                    viewModel.RequesterUserName = usr.User.FullName;
                }
            }
            else
            {
                TTStorageManager.Security.TTUser usr = TTStorageManager.Security.TTUser.GetUser(orthesisProsthesisRequest.RequesterUsr.Value);
                viewModel.RequesterUserName = usr.FullName;
            }

            if (!((ITTObject)orthesisProsthesisRequest).IsNew)
            {
                viewModel.RequesterUnit = viewModel._OrthesisProsthesisRequest.FromResource.Name;

                foreach (OrthesisProsthesisProcedure opp in orthesisProsthesisRequest.OrthesisProsthesisProcedures)
                {
                    SubActionProcedure sp = (SubActionProcedure)objectContext.GetObject((Guid)opp.ObjectID, "SubActionProcedure");
                    if (sp != null)
                    {
                        if (sp.GetProcedurePrice() != null)
                        {
                            opp.Price = (double)sp.GetProcedurePrice();
                        }
                    }
                }
            }
            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalýþmamalý
            viewModel.TreatmentMaterialsGridList = viewModel.TreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
        }

        partial void PostScript_OrthesisProsthesisForm(OrthesisProsthesisFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            #region client Kodlarý


            if (orthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids.Count > 0)
            {
                List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
                foreach (SurgeryDirectPurchaseGrid sdg in orthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids)
                {
                    if (materials.Contains(sdg.DPADetailFirmPriceOffer))
                        throw new TTException("Ayný Malzemeyi Birden Fazla Giremezsiniz ! ");
                    else
                        materials.Add(sdg.DPADetailFirmPriceOffer);
                }
            }
            if (orthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids.Count > 0)
            {
                List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
                foreach (CodelessMaterialDirectPurchaseGrid cdg in orthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids)
                {
                    if (materials.Contains(cdg.DPADetailFirmPriceOffer))
                        throw new TTException("Ayný Malzemeyi Birden Fazla Giremezsiniz ! ");
                    else
                        materials.Add(cdg.DPADetailFirmPriceOffer);
                }
            }

            Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            foreach (SurgeryDirectPurchaseGrid sdg in orthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids)
            {
                sdg.Material = (Material)orthesisProsthesisRequest.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            }

            foreach (CodelessMaterialDirectPurchaseGrid cdg in orthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids)
            {
                cdg.Material = (Material)orthesisProsthesisRequest.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                //cdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                cdg.Amount = cdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            }

            if (transDef != null)
            {
                /*if(transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.RequestAcception) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.RequestReturn) ||
                   transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.Procedure) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.RequestAcception))
                {
                    this.ReturnDescriptionInput();
                }
                
                if(transDef.FromStateDefID.Value.Equals(OrthesisProsthesisRequest.States.RequestAcception) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.States.Procedure))
                {
                    if(this._OrthesisProsthesisRequest.AuthorizedUsers.Count == 0)
                        this.SetAuthorizedUserBySelecting(this._OrthesisProsthesisRequest.MasterResource, UserTypeEnum.Technician, false);
                }*/

                OrthesisProsthesisRequest.MakingDirectPurchaseHasUsed(orthesisProsthesisRequest);

                if (transDef.ToStateDefID == OrthesisProsthesisRequest.States.ControlApproval || transDef.ToStateDefID == OrthesisProsthesisRequest.States.DoctorApproval || transDef.ToStateDefID == OrthesisProsthesisRequest.States.Completed)
                {
                    if (transDef.ToStateDefID == OrthesisProsthesisRequest.States.Completed)
                    {
                        Guid savePointGuid = orthesisProsthesisRequest.ObjectContext.BeginSavePoint();
                        try
                        {
                            OrthesisProsthesisRequest.CreateSubActionMatPricingDet(orthesisProsthesisRequest);
                            orthesisProsthesisRequest.ObjectContext.Update();
                        }
                        catch (Exception ex)
                        {
                            if (orthesisProsthesisRequest.ObjectContext.HasSavePoint(savePointGuid))
                                orthesisProsthesisRequest.ObjectContext.RollbackSavePoint(savePointGuid);
                            throw;
                        }
                    }
                    else
                        OrthesisProsthesisRequest.CreateSubActionMatPricingDet(orthesisProsthesisRequest);
                }

            }

            #endregion
        }

    }
}

namespace Core.Models
{
    public partial class OrthesisProsthesisFormViewModel
    {
        public string RequesterUnit { get; set; }//istem yapan birim
        public string RequesterUserName { get; set; }
    }
}
