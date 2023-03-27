//$42E711F7
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
    public partial class RadiologyTestServiceController : Controller
    {
        [HttpGet]
        public RadiologyTestCokluOzelDurumViewModel RadiologyTestCokluOzelDurum(Guid? id)
        {
            var FormDefID = Guid.Parse("50a0fa10-f20e-4fd4-b337-4b9ed2010855");
            var ObjectDefID = Guid.Parse("2cf639c4-5819-4cf4-b295-2594a294c6a0");
            var viewModel = new RadiologyTestCokluOzelDurumViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._RadiologyTest = objectContext.GetObject(id.Value, ObjectDefID) as RadiologyTest;
                    viewModel.ttgridCokluOzelDurumGridList = viewModel._RadiologyTest.CokluOzelDurum.OfType<CokluOzelDurum>().ToArray();
                    viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void RadiologyTestCokluOzelDurum(RadiologyTestCokluOzelDurumViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var radiologyTest = (RadiologyTest)objectContext.AddObject(viewModel._RadiologyTest);
                if (viewModel.ttgridCokluOzelDurumGridList != null)
                {
                    foreach (var item in viewModel.ttgridCokluOzelDurumGridList)
                    {
                        var cokluOzelDurumImported = (CokluOzelDurum)objectContext.AddObject(item);
                        cokluOzelDurumImported.RadiologyTest = radiologyTest;
                    }
                }

                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class RadiologyTestCokluOzelDurumViewModel
    {
        public TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get;
            set;
        }

        public TTObjectClasses.CokluOzelDurum[] ttgridCokluOzelDurumGridList
        {
            get;
            set;
        }

        public TTObjectClasses.OzelDurum[] OzelDurums
        {
            get;
            set;
        }
    }
}