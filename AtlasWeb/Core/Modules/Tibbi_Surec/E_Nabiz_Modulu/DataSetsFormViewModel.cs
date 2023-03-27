using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Core.Security;
using TTObjectClasses;
using Core.Models;
using System.ComponentModel;
using TTInstanceManagement;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DataSetsServiceController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ENabizDataSets[] GetDataSets()
        {
            List<ENabizDataSets> nabizList = new List<ENabizDataSets>();
            bool isENabizActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("ISNABIZACTIVE", "TRUE"));
            if (isENabizActive)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    BindingList<ENabizDataSetDefinition.GetENabizDataSetDefinition_Class> nList = ENabizDataSetDefinition.GetENabizDataSetDefinition("");
                    for (int j = 0; j < nList.Count; j++)
                    {
                        ENabizDataSets dataset = new ENabizDataSets();
                        dataset.PackageID = Convert.ToInt32(nList[j].PackageID);
                        dataset.PackageName = nList[j].PackageName.ToString();
                        dataset.DiagnosisObjectID = Guid.Empty;
                        nabizList.Add(dataset);
                    }

                }
            }

            return nabizList.ToArray();
        }
    }
}

namespace Core.Models
{
    public class DataSetsFormViewModel : BaseViewModel
    {
        public ENabizDataSets[] _DatasetList { get; set; }
    }
    
}
