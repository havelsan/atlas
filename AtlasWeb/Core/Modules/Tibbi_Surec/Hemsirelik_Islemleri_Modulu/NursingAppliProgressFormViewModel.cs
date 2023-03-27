//$7A809595
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class NursingAppliProgressServiceController : Controller
    {
        partial void PreScript_NursingAppliProgressForm(NursingAppliProgressFormViewModel viewModel, NursingAppliProgress nursingAppliProgress, TTObjectContext objectContext)
        {
            if (nursingAppliProgress.ApplicationUser == null)
                nursingAppliProgress.ApplicationUser = Common.CurrentResource;

            if (!((ITTObject)nursingAppliProgress).IsNew && !viewModel.ReadOnly)
            {
                using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                {
                    viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingAppliProgress);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class NursingAppliProgressFormViewModel
    {
    //public TTObjectClasses.NursingAppliProgress _NursingAppliProgress { get; set; }
    }
}