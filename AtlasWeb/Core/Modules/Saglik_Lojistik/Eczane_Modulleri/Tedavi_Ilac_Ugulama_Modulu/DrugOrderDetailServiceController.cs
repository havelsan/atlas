//$05FCF28E
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DrugOrderDetailServiceController : Controller
    {
        public class GetDrugOrderDetails_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public Guid RESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DrugOrderDetail> GetDrugOrderDetails(GetDrugOrderDetails_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DrugOrderDetail.GetDrugOrderDetails(objectContext, input.STARTDATE, input.ENDDATE, input.RESOURCE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetDrugType_Input
        {

            public Guid Material
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool GetDrugType(GetDrugType_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                DrugDefinition drug = (DrugDefinition)objectContext.GetObject(input.Material, typeof(DrugDefinition));
                bool output = DrugOrder.GetDrugUsedType(drug);
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class GetSequenceOrderPlanedDates_Input
        {
            public string DRUGORDER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DrugOrderDetail> GetSequenceOrderPlanedDates(GetSequenceOrderPlanedDates_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DrugOrderDetail.GetSequenceOrderPlanedDates(objectContext, input.DRUGORDER);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetDrugOrderDetailsByDrug_Input
        {
            public Guid DRUGID
            {
                get;
                set;
            }

            public Guid EPISODEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DrugOrderDetail> GetDrugOrderDetailsByDrug(GetDrugOrderDetailsByDrug_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DrugOrderDetail.GetDrugOrderDetailsByDrug(objectContext, input.DRUGID, input.EPISODEID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOrderPlannedDates_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DrugOrderDetail> GetOrderPlannedDates(GetOrderPlannedDates_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DrugOrderDetail.GetOrderPlannedDates(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class DrugOrderDetailListNQL_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DrugOrderDetail> DrugOrderDetailListNQL(DrugOrderDetailListNQL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DrugOrderDetail.DrugOrderDetailListNQL(objectContext, input.STARTDATE, input.ENDDATE, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetDrugOrderDetailsForDaily_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public Guid RESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DrugOrderDetail> GetDrugOrderDetailsForDaily(GetDrugOrderDetailsForDaily_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DrugOrderDetail.GetDrugOrderDetailsForDaily(objectContext, input.STARTDATE, input.ENDDATE, input.RESOURCE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class DrugOrderDetailListReportNQL_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DrugOrderDetail.DrugOrderDetailListReportNQL_Class> DrugOrderDetailListReportNQL(DrugOrderDetailListReportNQL_Input input)
        {
            var ret = DrugOrderDetail.DrugOrderDetailListReportNQL(input.STARTDATE, input.ENDDATE, input.injectionSQL);
            return ret;
        }

        public class GetDrugOrderDetailsByDrugOrder_Input
        {
            public Guid DRUGORDER
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class> GetDrugOrderDetailsByDrugOrder(GetDrugOrderDetailsByDrugOrder_Input input)
        {
            var ret = DrugOrderDetail.GetDrugOrderDetailsByDrugOrder(input.DRUGORDER, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ilac_Direktif_Detaylari_Durduruldu, TTRoleNames.Ilac_Direktif_Detaylari_Iptal, TTRoleNames.Ilac_Direktif_Detaylari_Istek, TTRoleNames.Ilac_Direktif_Detaylari_Uygulandi, TTRoleNames.Ilac_Direktif_Detaylari_Hastanin_Uzerinde, TTRoleNames.Ilac_Direktif_Detaylari_Plan, TTRoleNames.Ilac_Direktif_Detaylari_Hastaya_Teslim_Edildi, TTRoleNames.Ilac_Direktif_Detaylari_Karsilandi, TTRoleNames.Ilac_Direktif_Detaylari_Dis_Eczane_Tarafindan_Karsilandi, TTRoleNames.Ilac_Direktif_Detaylari_Eczaneye_Iade)]
        public PatientFullNameInfo_Output GetPatientFullNameByEpisode(PatientFullNameInfo_Input input)
        {
            TTObjectContext context = new TTObjectContext(false);
            PatientFullNameInfo_Output output = null;
            var existingEpisode = context.QueryObjects("EPISODE", "OBJECTID='" + input.Episode + "'");
            if (existingEpisode.Count > 0)
            {
                output = new PatientFullNameInfo_Output();
                output.FullName = ((Episode)existingEpisode[0]).Patient.FullName;
            }

            return output;
        }

        public class PatientFullNameInfo_Output
        {
            public string FullName
            {
                get;
                set;
            }
        }

        public class PatientFullNameInfo_Input
        {
            public string Episode
            {
                get;
                set;
            }
        }

        public class GetExecutionUser_Output
        {
            public bool IsCompleted
            {
                get;
                set;
            }
            public string FullName
            {
                get;
                set;
            }

            public DateTime ExecutionDate
            {
                get;
                set;
            }
        }

        public class GetExecutionUser_Input
        {
            public string ObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetExecutionUser_Output GetExecutionUser(GetExecutionUser_Input input)
        {
            GetExecutionUser_Output output = new GetExecutionUser_Output();
            output.IsCompleted = false;
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                DrugOrderDetail drugOrderDetail = objectContext.GetObject<DrugOrderDetail>(new Guid(input.ObjectID));
                if (drugOrderDetail.CurrentStateDef.Status == TTDefinitionManagement.StateStatusEnum.CompletedSuccessfully || drugOrderDetail.CurrentStateDef.Status == TTDefinitionManagement.StateStatusEnum.Cancelled)
                {
                    List<TTObjectState> states = drugOrderDetail.GetStateHistory().ToList();
                    output.IsCompleted = true;
                    output.FullName = states[states.Count - 1].User.FullName;
                    output.ExecutionDate = states[states.Count - 1].BranchDate;
                }
                objectContext.FullPartialllyLoadedObjects();
            }
            return output;
        }

        [HttpGet]
        public string ControlOfDrugSpecificationDrugOrderDetail(Guid drugObjectID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                string message = string.Empty;
                DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject(drugObjectID, typeof(DrugDefinition));
                List<DrugSpecificationEnum?> drugSpecifications = drugDefinition.DrugSpecifications.Select("").Select(x => x.DrugSpecification).ToList();

                foreach (DrugSpecificationEnum drugSpec in drugSpecifications)
                {
                    switch (drugSpec)
                    {
                        case DrugSpecificationEnum.Psychotrophic:
                            message += Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",";
                            break;
                        case DrugSpecificationEnum.HighRisk:
                            message += Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",";
                            break;
                        case DrugSpecificationEnum.ColdChain:
                            message += Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",";
                            break;
                        case DrugSpecificationEnum.Trombotic:
                            break;
                        case DrugSpecificationEnum.Vaccine:
                            break;
                        case DrugSpecificationEnum.Penicillin:
                            break;
                        case DrugSpecificationEnum.Antibiotics:
                            break;
                        case DrugSpecificationEnum.HumanAlbumin:
                            break;
                        case DrugSpecificationEnum.Epidermolysis:
                            break;
                        case DrugSpecificationEnum.AntiTrombotic:
                            break;
                        case DrugSpecificationEnum.PregnancyContraindicate:
                            break;
                        case DrugSpecificationEnum.NarrowTherapeuticInterval:
                            break;
                        case DrugSpecificationEnum.ProtectFromLight:
                            //message += Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)drugSpec) + ",";
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(message))
                {
                    message = message.Remove(message.LastIndexOf(','), 1);
                    message += " özelliği bulunan bir ilaç uyguluyorsunuz. Bilginize!";
                }
                if (drugSpecifications.Count(x => x.Value == DrugSpecificationEnum.ProtectFromLight) > 0)
                    message += " Işıktan Koruyunuz!";

                return message;
            }
        }
    }
}