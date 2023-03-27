using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class UserPackageServiceController : Controller
    {
        [HttpGet]
        public UserPackageViewModel LoadUserPackageViewModel()
        {
            UserPackageViewModel model = new UserPackageViewModel();
            model.PackageList = new List<PackageBasicObject>();

            using (var objectContext = new TTObjectContext(false))
            {
                List<PackageTemplateDefinition.GetPackageTemplate_Class> PackageListFromQuery = PackageTemplateDefinition.GetPackageTemplate(Common.CurrentResource.ObjectID).ToList();
                foreach (PackageTemplateDefinition.GetPackageTemplate_Class pack in PackageListFromQuery)
                {
                    PackageBasicObject packModel = new PackageBasicObject();

                    packModel.Name = pack.Name;
                    packModel.ObjectID = pack.ObjectID.ToString();
                    model.PackageList.Add(packModel);
                }
            }

            return model;
        }

        [HttpGet]
        public PackageInfoViewModel LoadPackageInfoViewModelByPackageID(string PackageID)
        {
            PackageInfoViewModel model = new PackageInfoViewModel();
            model.DiagnosisList = new List<DiagnosisModel>();

            using (var objectContext = new TTObjectContext(false))
            {
               
            }

            return model;
        }
    }
}

namespace Core.Models
{
    public class UserPackageViewModel
    {
        public List<PackageBasicObject> PackageList;
    }

    public class PackageInfoViewModel
    {
        public List<DiagnosisModel> DiagnosisList;
    }

    public class PackageBasicObject
    {
        public string ObjectID { get; set; }
        public string Name { get; set; }
    }

    public class DiagnosisModel
    {
        public string ObjectID { get; set; }
        public string Code{ get; set; }
        public string Name{ get; set; }
    }
}


