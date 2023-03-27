//$55CD363A
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
    public partial class SubEpisodeProtocolServiceController : Controller
    {
        [HttpGet]
        public SEPFormViewModel SEPForm(Guid? id)
        {
            var FormDefID = Guid.Parse("1760ff58-57a6-4aef-9bb4-45c8071ad715");
            var ObjectDefID = Guid.Parse("185376b2-446a-4e81-8fd7-f215e5aa034f");
            var viewModel = new SEPFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._SubEpisodeProtocol = objectContext.GetObject(id.Value, ObjectDefID) as SubEpisodeProtocol;
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void SEPForm(SEPFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var subEpisodeProtocol = (SubEpisodeProtocol)objectContext.AddObject(viewModel._SubEpisodeProtocol);
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class SEPFormViewModel
    {
        public TTObjectClasses.SubEpisodeProtocol _SubEpisodeProtocol
        {
            get;
            set;
        }
    }
}