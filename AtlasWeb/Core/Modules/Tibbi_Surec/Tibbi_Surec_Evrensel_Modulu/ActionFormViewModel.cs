//$EAEAFC09
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
    public partial class BaseActionServiceController : Controller
    {
        [HttpGet]
        public ActionFormViewModel ActionForm(Guid? id)
        {
            var FormDefID = Guid.Parse("7e2e8ad3-e6b1-4032-9001-f824467d7356");
            var ObjectDefID = Guid.Parse("19912241-723c-4f0f-adcf-59482f642cf8");
            var viewModel = new ActionFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._BaseAction = objectContext.GetObject(id.Value, ObjectDefID) as BaseAction;
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void ActionForm(ActionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(viewModel._BaseAction);
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class ActionFormViewModel
    {
        public TTObjectClasses.BaseAction _BaseAction
        {
            get;
            set;
        }
    }
}