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
    public partial class DailyConfirmDrugReportServiceController : Controller
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
        public DataSourcesDailyConfirmDrug FillDataSources()
        {
            DataSourcesDailyConfirmDrug dataSources = new DataSourcesDailyConfirmDrug
            {
                DoctorList = ResUser.ClinicDoctorListNQL(null).ToList(),
                MasterResourceList = ResClinic.GetAllActiveClinics(new TTObjectContext(true)).ToList()
            };

            return dataSources;
        }



        [HttpPost]
        public List<DrugOrderDailyConf> GetDrugOrderDailyConf(GetDailyConfDetail_Input input)
        {
            TTObjectContext context = new TTObjectContext(false);
            string filterExpression = string.Empty;
            if (input.DoctorIDList != null && input.DoctorIDList.Count > 0)
            {
                filterExpression += " AND THIS.RequestedByUser IN ( ";
                foreach (var DoctorID in input.DoctorIDList)
                    filterExpression += "'" + DoctorID + "',";
                filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
            }
            if (input.ServiceIDList != null && input.ServiceIDList.Count > 0)
            {
                filterExpression += " AND THIS.InPatientPhysicianApplication.MasterResource.OBJECTID IN ( ";
                foreach (var ServiceID in input.ServiceIDList)
                    filterExpression += "'" + ServiceID + "',";
                filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
            }
            if (input.DrugIDList != null && input.DrugIDList.Count > 0)
            {
                filterExpression += " AND this.Material IN ( ";
                foreach (var drugID in input.DrugIDList)
                    filterExpression += "'" + drugID + "',";
                filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
            }

            if (input.StatusID > 0)
            {
                switch (input.StatusID)
                {
                    case 1:
                        filterExpression += " AND THIS.DrugOrderDetails.CURRENTSTATEDEFID IN ( STATES.Supply) ";
                        break;
                    case 2:
                        filterExpression += " AND THIS.DrugOrderDetails.CURRENTSTATEDEFID IN ( STATES.Request,STATES.Planned ) ";
                        break;
                    case 3:
                        filterExpression += " AND THIS.DrugOrderDetails.CURRENTSTATEDEFID IN ( STATES.Cancel,STATES.Stop ) ";
                        break;
                    case 4:
                        filterExpression += " AND THIS.DrugOrderDetails.CURRENTSTATEDEFID IN ( STATES.UseRestDose ) ";
                        break;
                    case 5:
                        filterExpression += " AND THIS.DrugOrderDetails.CURRENTSTATEDEFID IN ( STATES.Apply ,STATES.PatientDelivery ,STATES.ReturnPharmacy ) ";
                        break;
                    default:
                        break;
                }
            }

            List<DrugOrder.GetDailyConfirmDrugRQ_Class> drugOrders = DrugOrder.GetDailyConfirmDrugRQ(input.StartDate, input.StartDate.AddHours(23).AddMinutes(59).AddSeconds(59), filterExpression).ToList();
            List<DrugOrderDailyConf> drugOrderDailyConfList = new List<DrugOrderDailyConf>();

            foreach (DrugOrder.GetDailyConfirmDrugRQ_Class drugOrder in drugOrders)
            {
                if (drugOrderDailyConfList.Where(x => x.DrugOrderObjectID == drugOrder.Drugorderobjectid.Value).Any() == true)
                {
                    DrugOrderDailyConfDetail newDetail = new DrugOrderDailyConfDetail();
                    newDetail.DetailNo = drugOrder.DetailNo.ToString();
                    newDetail.DoseAmount = drugOrder.Detaildoseamount.ToString();
                    newDetail.State = drugOrder.Detailstate;
                    newDetail.OrderPlannedDate = drugOrder.Detailplaneddatetime.ToString();
                    drugOrderDailyConfList.FirstOrDefault(x => x.DrugOrderObjectID == drugOrder.Drugorderobjectid.Value).drugOrderDailyConfDetails.Add(newDetail);
                }
                else
                {
                    DrugOrderDailyConf drugOrderDailyConf = new DrugOrderDailyConf();
                    drugOrderDailyConf.drugOrderDailyConfDetails = new List<DrugOrderDailyConfDetail>();
                    drugOrderDailyConf.DrugOrderObjectID = drugOrder.Drugorderobjectid.Value;
                    drugOrderDailyConf.DrugName = drugOrder.Drugname;
                    drugOrderDailyConf.Barcode = drugOrder.Barcode;
                    drugOrderDailyConf.ProtocolNo = drugOrder.ProtocolNo;
                    drugOrderDailyConf.PatientNameSurname = drugOrder.Patientnamesurname.ToString();
                    drugOrderDailyConf.Frequency = drugOrder.Hospitaltimeschedule;
                    drugOrderDailyConf.DoseAmount = drugOrder.DoseAmount.ToString();
                    drugOrderDailyConf.Clinic = drugOrder.Clinic;
                    drugOrderDailyConf.DoctorName = drugOrder.Doctor;
                    drugOrderDailyConf.PlannedStartTime = drugOrder.CreationDate.ToString();
                    drugOrderDailyConf.State = drugOrder.Drugorderstate;
                    DrugOrderDailyConfDetail drugOrderDailyConfDetail = new DrugOrderDailyConfDetail();
                    drugOrderDailyConfDetail.DetailNo = drugOrder.DetailNo.ToString();
                    drugOrderDailyConfDetail.DoseAmount = drugOrder.Detaildoseamount.ToString();
                    drugOrderDailyConfDetail.State = drugOrder.Detailstate;
                    drugOrderDailyConfDetail.OrderPlannedDate = drugOrder.Detailplaneddatetime.ToString();
                    drugOrderDailyConf.drugOrderDailyConfDetails.Add(drugOrderDailyConfDetail);
                    drugOrderDailyConfList.Add(drugOrderDailyConf);
                }
            }
            return drugOrderDailyConfList;
        }
    }
}

namespace Core.Models
{
    public class DrugOrderDailyConf
    {
        public Guid DrugOrderObjectID { get; set; }
        public string DrugName { get; set; }
        public string Barcode { get; set; }
        public string ProtocolNo { get; set; }
        public string PatientNameSurname { get; set; }
        public string Frequency { get; set; }
        public string DoseAmount { get; set; }
        public string Clinic { get; set; }
        public string DoctorName { get; set; }
        public string PlannedStartTime { get; set; }
        public string State { get; set; }
        public List<DrugOrderDailyConfDetail> drugOrderDailyConfDetails { get; set; }
    }

    public class DrugOrderDailyConfDetail
    {
        public string DetailNo { get; set; }
        public string DoseAmount { get; set; }
        public string State { get; set; }
        public string OrderPlannedDate { get; set; }
    }

    public class GetDailyConfDetail_Input
    {
        public DateTime StartDate
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
        public int StatusID { get; set; }

    }

    public class DataSourcesDailyConfirmDrug
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
    }
}
