using Core.Models;
using DevExpress.Utils.Extensions;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using TTReportClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class OrderTemplateDefintionController : Controller
    {
        public class GetOrderTemlplateDefinition
        {
            public List<HospitalTimeSch> HospitalTimeScheduleList { get; set; }
            public List<OrderTemplateDefinitionDataSource> OrderTemplateDefinitionDataSourceList { get; set; }

            public List<OrderTempleateUserResurce> UserResources { get; set; }
            public List<OrderTemplateSpecialityDefinition> UserSpecialityDefinitions { get; set; }
        }

        public class OrderTempleateUserResurce
        {
            public string ResourceName { get; set; }
            public Guid? ResourceObjectID { get; set; }
        }

        public class OrderTemplateSpecialityDefinition
        {
            public string SpecialityDefName { get; set; }
            public Guid? SpecialityDefObjectID { get; set; }
        }

        public class HospitalTimeSch
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
        }


        public class OrderTemplateDefinitionDataSource
        {
            public Guid? ObjectID { get; set; }
            public string Name { get; set; }
            public OrderTemplateStatusEnum? OrderTemplateStatus { get; set; }
            public bool? IsActive { get; set; }
        }

        public class OrderTemplateDefinitionInputDTO
        {
            public bool isNew { get; set; }
            public Guid ObjectID { get; set; }
            public OrderTemplateStatusEnum OrderTemplateStatus { get; set; }
            public string Name { get; set; }
            public bool IsActive { get; set; }
            public List<OrderTemplateDetailDTO> OrderTemplateDetails { get; set; }

            public Guid Resource { get; set; }
            public Guid SpecialityDefinition { get; set; }
        }
        public class OrderTemplateDetailDTO
        {
            public Guid ObjectID { get; set; }
            public string Description { get; set; }
            public double DoseAmount { get; set; }
            public DrugOrderTypeEnum DrugOrderType { get; set; }
            public DrugUsageTypeEnum DrugUsageType { get; set; }
            public HospitalTimeSchedule HospitalTimeSchedule { get; set; }
            public Guid MaterialObjectID { get; set; }
            public string MaterialName { get; set; }
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetOrderTemlplateDefinition getAllOrderTemplateDefinition()
        {
            using (var objectContext = new TTObjectContext(true))
            {

                GetOrderTemlplateDefinition returnOTD = new GetOrderTemlplateDefinition();
                BindingList<OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class> getAllCommisions =
                    OrderTemplateDefinition.GetOrderTemplateDefinitionList(" WHERE CREATEDBY = " + TTConnectionManager.ConnectionManager.GuidToString(new Guid(Common.CurrentUser.TTObjectID.ToString())));
                List<OrderTemplateDefinitionDataSource> orderTemplateDefinitionDataSource = getAllCommisions.Select(x => new OrderTemplateDefinitionDataSource()
                {
                    IsActive = x.IsActive,
                    Name = x.Name,
                    ObjectID = x.ObjectID,
                    OrderTemplateStatus = x.OrderTemplateStatus
                }).ToList();

                returnOTD.OrderTemplateDefinitionDataSourceList = orderTemplateDefinitionDataSource;
                var hosptList = objectContext.QueryObjects<HospitalTimeSchedule>("ACTIVE = 1");
                returnOTD.HospitalTimeScheduleList = hosptList.Select(x => new HospitalTimeSch()
                {
                    Name = x.Name,
                    ObjectID = x.ObjectID
                }).ToList();

                BindingList<UserResource.GetUserReourcesByUserDist_Class> userReource = UserResource.GetUserReourcesByUserDist(new Guid(Common.CurrentUser.TTObjectID.ToString()));
                returnOTD.UserResources = userReource.Select(x => new OrderTempleateUserResurce()
                {
                    ResourceName = x.Name,
                    ResourceObjectID = x.Resourceid
                }).ToList();


                BindingList<ResUser.GetSpecialitiesForDP_Class> userSpeciality = ResUser.GetSpecialitiesForDP(string.Empty);
                returnOTD.UserSpecialityDefinitions = userSpeciality.Select(x => new OrderTemplateSpecialityDefinition()
                {
                    SpecialityDefName = x.Name,
                    SpecialityDefObjectID = x.ObjectID
                }).ToList();



                objectContext.FullPartialllyLoadedObjects();
                return returnOTD;
            }
        }

        public class GetOrderTemplateDefinition_Input
        {
            public Guid ObjectID { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public OrderTemplateDefinitionInputDTO getOrderTemplateDefinition(GetOrderTemplateDefinition_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                OrderTemplateDefinition orderTemplateDefinition = (OrderTemplateDefinition)objectContext.GetObject(input.ObjectID, typeof(OrderTemplateDefinition));
                OrderTemplateDefinitionInputDTO output = new OrderTemplateDefinitionInputDTO();
                output.isNew = false;
                output.IsActive = orderTemplateDefinition.IsActive.Value;
                output.ObjectID = orderTemplateDefinition.ObjectID;
                output.OrderTemplateStatus = orderTemplateDefinition.OrderTemplateStatus.Value;
                output.Name = orderTemplateDefinition.Name;
                output.Resource = orderTemplateDefinition.Resource == null ? Guid.Empty : orderTemplateDefinition.Resource.ObjectID;
                output.SpecialityDefinition = orderTemplateDefinition.SpecialityDefinition == null ? Guid.Empty : orderTemplateDefinition.SpecialityDefinition.ObjectID;
                output.OrderTemplateDetails = new List<OrderTemplateDetailDTO>();
                foreach (OrderTemplateDetail x in orderTemplateDefinition.OrderTemplateDetails.Select(string.Empty))
                {
                    OrderTemplateDetailDTO detailDTO = new OrderTemplateDetailDTO();
                    detailDTO.MaterialName = x.Material.Name;
                    detailDTO.MaterialObjectID = x.Material.ObjectID;
                    detailDTO.Description = x.Description;
                    detailDTO.DoseAmount = x.DoseAmount.Value;
                    detailDTO.DrugOrderType = x.DrugOrderType.Value;
                    detailDTO.DrugUsageType = x.DrugUsageType.Value;
                    detailDTO.HospitalTimeSchedule = x.HospitalTimeSchedule;
                    detailDTO.ObjectID = x.ObjectID;
                    output.OrderTemplateDetails.Add(detailDTO);
                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }


        [HttpPost]
        public string saveObject(OrderTemplateDefinitionInputDTO input)
        {

            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                OrderTemplateDefinition orderTemplateDefinition = null;
                if (input.isNew == true)
                {
                    orderTemplateDefinition = new OrderTemplateDefinition(objectContext);

                    foreach (OrderTemplateDetailDTO x in input.OrderTemplateDetails)
                    {
                        OrderTemplateDetail orderTemplateDetail = new OrderTemplateDetail(objectContext);
                        orderTemplateDetail.DoseAmount = x.DoseAmount;
                        orderTemplateDetail.Material = objectContext.GetObject<Material>(x.MaterialObjectID);
                        orderTemplateDetail.DrugOrderType = x.DrugOrderType;
                        orderTemplateDetail.DrugUsageType = x.DrugUsageType;
                        orderTemplateDetail.Description = x.Description;
                        orderTemplateDetail.HospitalTimeSchedule = x.HospitalTimeSchedule;
                        orderTemplateDefinition.OrderTemplateDetails.Add(orderTemplateDetail);
                    }
                }
                else
                {
                    orderTemplateDefinition = objectContext.GetObject<OrderTemplateDefinition>(input.ObjectID);
                    foreach (OrderTemplateDetail item in orderTemplateDefinition.OrderTemplateDetails.Select(string.Empty))
                    {
                        ((ITTObject)item).Delete();
                    }
                    foreach (OrderTemplateDetailDTO x in input.OrderTemplateDetails)
                    {
                        OrderTemplateDetail orderTemplateDetail = new OrderTemplateDetail(objectContext);
                        orderTemplateDetail.DoseAmount = x.DoseAmount;
                        orderTemplateDetail.Material = objectContext.GetObject<Material>(x.MaterialObjectID);
                        orderTemplateDetail.DrugOrderType = x.DrugOrderType;
                        orderTemplateDetail.DrugUsageType = x.DrugUsageType;
                        orderTemplateDetail.Description = x.Description;
                        orderTemplateDetail.HospitalTimeSchedule = x.HospitalTimeSchedule;
                        orderTemplateDefinition.OrderTemplateDetails.Add(orderTemplateDetail);
                    }
                }

                orderTemplateDefinition.Name = input.Name;
                orderTemplateDefinition.CreatedBy = Common.CurrentUser.TTObjectID;
                orderTemplateDefinition.OrderTemplateStatus = input.OrderTemplateStatus;
                orderTemplateDefinition.IsActive = input.IsActive;

                if (input.OrderTemplateStatus == OrderTemplateStatusEnum.OnlyMyClinic)
                {
                    orderTemplateDefinition.Resource = objectContext.GetObject<Resource>(input.Resource);
                    orderTemplateDefinition.SpecialityDefinition = null;
                }
                    
                else if (input.OrderTemplateStatus == OrderTemplateStatusEnum.JustMyBranch)
                {
                    orderTemplateDefinition.SpecialityDefinition = objectContext.GetObject<SpecialityDefinition>(input.SpecialityDefinition);
                    orderTemplateDefinition.Resource = null;
                }
                else
                {
                    orderTemplateDefinition.Resource = null;
                    orderTemplateDefinition.SpecialityDefinition = null;
                }
                    

                objectContext.Save();
                objectContext.Dispose();
                return "Şablon Kayıt İşlemi Yapılmıştır";
            }
            catch
            {
                return " Şablon Kayıt İşlemi Sırasında Hata Alınmıştır..";
            }
        }
    }
}
