//$C8257014
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class SterilizationRequestServiceController
    {
        partial void PreScript_SterilizationRequestForm(SterilizationRequestFormViewModel viewModel, SterilizationRequest sterilizationRequest, TTObjectContext objectContext)
        {
            if (sterilizationRequest.RequestDate == null)
                sterilizationRequest.RequestDate = Common.RecTime();
            if (sterilizationRequest.RequestUser == null)
                sterilizationRequest.RequestUser = Common.CurrentResource;

            //string requestResourceFilterExpression = "OBJECTID IN(''";
            //ResSection defaultResource = null;
            //if (sterilizationRequest.RequestUser != null)
            //{
            //    foreach (var userResource in sterilizationRequest.RequestUser.UserResources)
            //    {
            //        if (userResource.Resource.IsActive == true)
            //        {
            //            requestResourceFilterExpression += ",'" + userResource.Resource.ObjectID.ToString() + "'";
            //            if (defaultResource == null)
            //                defaultResource = userResource.Resource;
            //        }
            //    }
            //    requestResourceFilterExpression += ")";
            //}

            string requestResourceFilterExpression = "this.ResourceUsers(User = '" + sterilizationRequest.RequestUser.ObjectID.ToString() + "').EXISTS() ";
            ResSection defaultResource = null;
            if (sterilizationRequest.RequestUser != null)
            {
                foreach (var userResource in sterilizationRequest.RequestUser.UserResources)
                {
                    if (userResource.Resource.IsActive == true)
                    {
                        if (defaultResource == null)
                            defaultResource = userResource.Resource;
                    }
                }
            }

            if (defaultResource != null)
            {
                viewModel.RequestResourceFilterExpression = requestResourceFilterExpression;
                viewModel._SterilizationRequest.RequestResource = defaultResource;
            }

            var ResSterilizationUnitList = ResSterilizationUnit.GetAllResSterilizationUnit(objectContext,"");
            if (ResSterilizationUnitList.Count == 1)
                viewModel._SterilizationRequest.SterilizationUnit = ResSterilizationUnitList[0];
            ContextToViewModel(viewModel, objectContext);
        }

    }
}

namespace Core.Models
{
    public partial class SterilizationRequestFormViewModel: BaseViewModel
    {
        public string RequestResourceFilterExpression
        {
            get;
            set;
        }
    }
}
