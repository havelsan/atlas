using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using System.ComponentModel;
using TTObjectClasses;
using Infrastructure.Filters;
using Core.Security;
using TTInstanceManagement;
using TTUtils;
using TTDefinitionManagement;
using TTDataDictionary;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ReceivedDrugReportServiceController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LoadResult GetDrugDefinitionList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugListQuery"];
                var paramList = new Dictionary<string, object>();
                paramList.Add("OBJECTDEFID", "65a2337c-bc3c-4c6b-9575-ad47fa7a9a89");
                var injection = "MKYSMALZEMEKODU IS NOT NULL";
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }



        [HttpPost]
        public DataSources FillDataSources()
        {
            DataSources dataSources = new DataSources
            {
                DoctorList = ResUser.ClinicDoctorListNQL(null).ToList(),
                MasterResourceList = ResClinic.GetAllActiveClinics(new TTObjectContext(true)).ToList(),
                ActiveIngredientList = ActiveIngredientDefinition.GetActiveIngredientDefinitions("").ToList()
            };

            return dataSources;
        }



        [HttpPost]
        public List<KSchedule.GetKScheduleReportByParameter_Class> GetDrugList(GetDrugList_Input input)
        {
            TTObjectContext context = new TTObjectContext(false);
            string filterExpression = string.Empty;
            if (input.DoctorIDList != null && input.DoctorIDList.Count > 0)
            {
                filterExpression += " AND THIS.MKYS_TESLIMALANOBJID IN ( ";
                foreach (var DoctorID in input.DoctorIDList)
                    filterExpression += "'" + DoctorID + "',";
                filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
            }
            if (input.ServiceIDList != null && input.ServiceIDList.Count > 0)
            {
                filterExpression += " AND THIS.INPATIENTPHYSICIANAPPLICATION.MASTERRESOURCE.OBJECTID IN ( ";
                foreach (var ServiceID in input.ServiceIDList)
                    filterExpression += "'" + ServiceID + "',";
                filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
            }
            if (input.DrugIDList != null && input.DrugIDList.Count > 0)
            {
                filterExpression += " AND KSCHEDULEMATERIALS.MATERIAL IN ( ";
                foreach (var drugID in input.DrugIDList)
                    filterExpression += "'" + drugID + "',";
                if (input.ActiveIngredientIDList == null || input.ActiveIngredientIDList.Count == 0)
                    filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
            }
            if (input.ActiveIngredientIDList != null && input.ActiveIngredientIDList.Count > 0)
            {
                foreach (var ActiveIngredientID in input.ActiveIngredientIDList)
                {
                    BindingList<DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient_Class> DrugActiveIngredient_List = DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient(context, ActiveIngredientID);
                    if (input.DrugIDList == null && input.DrugIDList.Count == 0)
                        filterExpression += " AND KSCHEDULEMATERIALS.MATERIAL IN( ";
                    foreach (DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient_Class drugActiveIngredient in DrugActiveIngredient_List)
                    {
                        if (drugActiveIngredient.Drugdefinition != null)
                            filterExpression += "'" + drugActiveIngredient.Drugdefinition.ToString() + "',";
                    }
                }
                filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
            }

            List<KSchedule.GetKScheduleReportByParameter_Class> drugList = KSchedule.GetKScheduleReportByParameter(input.StartDate, input.EndDate, filterExpression).ToList();
            return drugList;
        }
    }
}

namespace Core.Models
{
    public class DataSources
    {
        public List<ResUser.ClinicDoctorListNQL_Class> DoctorList
        {
            get;
            set;
        }
        public List<ResClinic> MasterResourceList
        {
            get;
            set;
        }
        public List<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> ActiveIngredientList
        {
            get;
            set;
        }
    }

    public class GetDrugList_Input
    {
        public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }

        public List<Guid> DoctorIDList
        {
            get;
            set;
        }
        public List<Guid> ServiceIDList
        {
            get;
            set;
        }
        public List<Guid> DrugIDList
        {
            get;
            set;
        }
        public List<Guid> ActiveIngredientIDList
        {
            get;
            set;
        }
    }
}
