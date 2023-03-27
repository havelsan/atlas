using Core.Models;
using Core.Modules.Saglik_Lojistik.Eczane_Modulleri.Ilac_Direktifi_Giris_Modulu;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
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
using static Core.Controllers.DrugOrderIntroductionServiceController;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class OrderTemplateController : Controller
    {
        public class OrderTemplateItem
        {
            public int? ID { get; set; }
            public Guid ObjectID { get; set; }
            public string text { get; set; }
            public int? ParentID { get; set; }
            public bool expanded { get; set; }
            public bool clickable { get; set; }
            public List<OrderTemplateItem> items { get; set; }
            public List<OrderTemplateDetailItem> OrderTemplateDetails { get; set; }
        }

        public class OrderTemplateDetailItem
        {
            public string Description { get; set; }
            public double DoseAmount { get; set; }
            public DrugOrderTypeEnum DrugOrderType { get; set; }
            public DrugUsageTypeEnum DrugUsageType { get; set; }
            public Guid HospitalTimeSchedule { get; set; }
            public Guid MaterialObjectID { get; set; }
            public string MaterialName { get; set; }
            public DrugInfo drugInfo { get; set; }
        }




        public class AllOrderTemplateInput
        {
            public Guid? spcialityDefID { get; set; }
            public Guid? resourceID { get; set; }
        }

        public class GetDataSource
        {
            public List<OrderTemplateItem> OrderTemplateItemList { get; set; }
            public List<HospitalTimeSch> HospitalTimeScheduleList { get; set; }
        }
        public class HospitalTimeSch
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetDataSource getAllOrderTemplate(AllOrderTemplateInput input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                GetDataSource dataSource = new GetDataSource();
                dataSource.OrderTemplateItemList = new List<OrderTemplateItem>();
                dataSource.HospitalTimeScheduleList = new List<HospitalTimeSch>();

                var hosptList = objectContext.QueryObjects<HospitalTimeSchedule>("ACTIVE = 1");
                dataSource.HospitalTimeScheduleList = hosptList.Select(x => new HospitalTimeSch()
                {
                    Name = x.Name,
                    ObjectID = x.ObjectID
                }).ToList();

                List<OrderTemplateItem> orderTemplateItems = new List<OrderTemplateItem>();
                int IDCount = 100;
                // Buranın değişmesi lazım sadece benim yarattıklarım gelir diğer branş ve kullanıcılar için olanlar gelmez.!!"
                input.spcialityDefID = new Guid();
                input.resourceID = new Guid();

                BindingList<OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class> createdByList =
                 OrderTemplateDefinition.GetOrderTemplateDefinitionList(" WHERE  ORDERTEMPLATESTATUS = 0 AND CREATEDBY = " + TTConnectionManager.ConnectionManager.GuidToString(new Guid(Common.CurrentUser.TTObjectID.ToString())));


                BindingList<OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class> specialityList =
                 OrderTemplateDefinition.GetOrderTemplateDefinitionList(" WHERE ORDERTEMPLATESTATUS = 1 OR SPECIALITYDEFINITION = " + TTConnectionManager.ConnectionManager.GuidToString(new Guid(input.spcialityDefID.ToString())));

                BindingList<OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class> resourceList =
                 OrderTemplateDefinition.GetOrderTemplateDefinitionList(" WHERE  ORDERTEMPLATESTATUS = 2 OR RESOURCE = " + TTConnectionManager.ConnectionManager.GuidToString(new Guid(input.resourceID.ToString())));

                BindingList<OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class> allUserList =
                 OrderTemplateDefinition.GetOrderTemplateDefinitionList(" WHERE ORDERTEMPLATESTATUS = 3");

                OrderTemplateItem OnlyMeTree = new OrderTemplateItem();
                OnlyMeTree.expanded = true;
                OnlyMeTree.ID = 1;
                OnlyMeTree.ParentID = null;
                OnlyMeTree.clickable = false;
                OnlyMeTree.text = "Sadece Benim";
                OnlyMeTree.ObjectID = new Guid();
                OnlyMeTree.OrderTemplateDetails = null;
                OnlyMeTree.items = new List<OrderTemplateItem>();
                foreach (OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class tempOrder in createdByList)
                {
                    OrderTemplateItem orderTemplateItem = new OrderTemplateItem();
                    orderTemplateItem.text = tempOrder.Name;
                    orderTemplateItem.ObjectID = tempOrder.ObjectID.Value;
                    orderTemplateItem.ParentID = 1;
                    orderTemplateItem.ID = IDCount;
                    orderTemplateItem.clickable = true;
                    orderTemplateItem.expanded = true;

                    BindingList<OrderTemplateDefinition.GetOrderTemplateByParameters_Class> getDetails = OrderTemplateDefinition.GetOrderTemplateByParameters(orderTemplateItem.ObjectID);
                    orderTemplateItem.OrderTemplateDetails = getDetails.Select(x => new OrderTemplateDetailItem()
                    {
                        Description = x.Description,
                        DoseAmount = x.DoseAmount.Value,
                        DrugOrderType = x.DrugOrderType.Value,
                        DrugUsageType = x.DrugUsageType.Value,
                        HospitalTimeSchedule = x.Hospitaltimescheduleobjectid.Value,
                        MaterialName = x.Materialname,
                        MaterialObjectID = x.Materialobjectid.Value,
                        drugInfo = CreateDrugOrderInfo(x.Materialobjectid.Value),
                    }).ToList();

                    OnlyMeTree.items.Add(orderTemplateItem);
                }

                OrderTemplateItem JustMyBranchyMeTree = new OrderTemplateItem();
                JustMyBranchyMeTree.ID = 2;
                JustMyBranchyMeTree.expanded = true;
                JustMyBranchyMeTree.ParentID = null;
                JustMyBranchyMeTree.clickable = false;
                JustMyBranchyMeTree.text = "Sadece Benim Branşım";
                JustMyBranchyMeTree.ObjectID = new Guid();
                JustMyBranchyMeTree.OrderTemplateDetails = null;
                JustMyBranchyMeTree.items = new List<OrderTemplateItem>();

                foreach (OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class tempOrder in specialityList)
                {
                    OrderTemplateItem orderTemplateItem = new OrderTemplateItem();
                    orderTemplateItem.text = tempOrder.Name;
                    orderTemplateItem.ObjectID = tempOrder.ObjectID.Value;
                    orderTemplateItem.ParentID = 2;
                    orderTemplateItem.ID = IDCount;
                    orderTemplateItem.clickable = true;
                    orderTemplateItem.expanded = true;

                    BindingList<OrderTemplateDefinition.GetOrderTemplateByParameters_Class> getDetails = OrderTemplateDefinition.GetOrderTemplateByParameters(orderTemplateItem.ObjectID);
                    orderTemplateItem.OrderTemplateDetails = getDetails.Select(x => new OrderTemplateDetailItem()
                    {
                        Description = x.Description,
                        DoseAmount = x.DoseAmount.Value,
                        DrugOrderType = x.DrugOrderType.Value,
                        DrugUsageType = x.DrugUsageType.Value,
                        HospitalTimeSchedule = x.Hospitaltimescheduleobjectid.Value,
                        MaterialName = x.Materialname,
                        MaterialObjectID = x.Materialobjectid.Value,
                        drugInfo = CreateDrugOrderInfo(x.Materialobjectid.Value),
                    }).ToList();

                    JustMyBranchyMeTree.items.Add(orderTemplateItem);
                }


                OrderTemplateItem OnlyMyClinicTree = new OrderTemplateItem();
                OnlyMyClinicTree.ID = 3;
                OnlyMyClinicTree.expanded = true;
                OnlyMyClinicTree.ParentID = null;
                OnlyMyClinicTree.clickable = false;
                OnlyMyClinicTree.text = "Sadece Benim Kliniğim";
                OnlyMyClinicTree.ObjectID = new Guid();
                OnlyMyClinicTree.OrderTemplateDetails = null;
                OnlyMyClinicTree.items = new List<OrderTemplateItem>();

                foreach (OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class tempOrder in resourceList)
                {
                    OrderTemplateItem orderTemplateItem = new OrderTemplateItem();
                    orderTemplateItem.text = tempOrder.Name;
                    orderTemplateItem.ObjectID = tempOrder.ObjectID.Value;
                    orderTemplateItem.ParentID = 3;
                    orderTemplateItem.ID = IDCount;
                    orderTemplateItem.clickable = true;
                    orderTemplateItem.expanded = true;

                    BindingList<OrderTemplateDefinition.GetOrderTemplateByParameters_Class> getDetails = OrderTemplateDefinition.GetOrderTemplateByParameters(orderTemplateItem.ObjectID);
                    orderTemplateItem.OrderTemplateDetails = getDetails.Select(x => new OrderTemplateDetailItem()
                    {
                        Description = x.Description,
                        DoseAmount = x.DoseAmount.Value,
                        DrugOrderType = x.DrugOrderType.Value,
                        DrugUsageType = x.DrugUsageType.Value,
                        HospitalTimeSchedule = x.Hospitaltimescheduleobjectid.Value,
                        MaterialName = x.Materialname,
                        MaterialObjectID = x.Materialobjectid.Value,
                        drugInfo = CreateDrugOrderInfo(x.Materialobjectid.Value),
                    }).ToList();

                    OnlyMyClinicTree.items.Add(orderTemplateItem);
                }


                OrderTemplateItem AllUsersTree = new OrderTemplateItem();
                AllUsersTree.ID = 4;
                AllUsersTree.expanded = true;
                AllUsersTree.ParentID = null;
                AllUsersTree.clickable = false;
                AllUsersTree.text = "Tüm Kullanıcılar";
                AllUsersTree.ObjectID = new Guid();
                AllUsersTree.OrderTemplateDetails = null;
                AllUsersTree.items = new List<OrderTemplateItem>();

                foreach (OrderTemplateDefinition.GetOrderTemplateDefinitionList_Class tempOrder in resourceList)
                {
                    OrderTemplateItem orderTemplateItem = new OrderTemplateItem();
                    orderTemplateItem.text = tempOrder.Name;
                    orderTemplateItem.ObjectID = tempOrder.ObjectID.Value;
                    orderTemplateItem.ParentID = 4;
                    orderTemplateItem.ID = IDCount;
                    orderTemplateItem.clickable = true;
                    orderTemplateItem.expanded = true;

                    BindingList<OrderTemplateDefinition.GetOrderTemplateByParameters_Class> getDetails = OrderTemplateDefinition.GetOrderTemplateByParameters(orderTemplateItem.ObjectID);
                    orderTemplateItem.OrderTemplateDetails = getDetails.Select(x => new OrderTemplateDetailItem()
                    {
                        Description = x.Description,
                        DoseAmount = x.DoseAmount.Value,
                        DrugOrderType = x.DrugOrderType.Value,
                        DrugUsageType = x.DrugUsageType.Value,
                        HospitalTimeSchedule = x.Hospitaltimescheduleobjectid.Value,
                        MaterialName = x.Materialname,
                        MaterialObjectID = x.Materialobjectid.Value,
                        drugInfo = CreateDrugOrderInfo(x.Materialobjectid.Value),
                    }).ToList();

                    AllUsersTree.items.Add(orderTemplateItem);
                }

                orderTemplateItems.Add(OnlyMeTree);
                orderTemplateItems.Add(JustMyBranchyMeTree);
                orderTemplateItems.Add(OnlyMyClinicTree);
                orderTemplateItems.Add(AllUsersTree);
                IDCount++;

                objectContext.FullPartialllyLoadedObjects();
                dataSource.OrderTemplateItemList = orderTemplateItems;

                return dataSource;
            }
        }

        public DrugInfo CreateDrugOrderInfo(Guid drugObjectId)
        {
            TTObjectContext context = new TTObjectContext(true);
            DrugDefinition drug = (DrugDefinition)context.GetObject(drugObjectId, typeof(DrugDefinition));
            DrugInfo drugInfo = new DrugInfo();
            drugInfo.drugObjectId = drug.ObjectID.ToString();
            drugInfo.name = drug.Name;
            drugInfo.inheldStatus = drug.PharmacyInheldStatus;
            drugInfo.drugShapeTypeEnum = drug.DrugShapeType;
            drugInfo.Color = ColorHelper.GetFontColor(drug.Color);
            drugInfo.SgkReturnPay = DrugDefinition.GetSgkReturnPayText(drug.SgkReturnPay);
            drugInfo.barcode = drug.Barcode;
            drugInfo.isPatientOwnDrug = false;
            drugInfo.drugType = DrugOrder.GetDrugUsedType(drug);

            if (string.IsNullOrEmpty(drug.Description))
            {
                if (drug.MaterialDescriptionShowType != null)
                {
                    if (drug.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.Order || drug.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.All)
                        drugInfo.DrugDescription = drug.Description;
                    else
                        drugInfo.DrugDescription = string.Empty;
                }
                else
                    drugInfo.DrugDescription = drug.Description;
            }
            else
                drugInfo.DrugDescription = string.Empty;

            if (drug.DivisibleDrug.HasValue)
                drugInfo.isDivisibleDrug = drug.DivisibleDrug.Value;
            else
                drugInfo.isDivisibleDrug = false;

            if (drug.MinPatientAge.HasValue)
                drugInfo.minAge = drug.MinPatientAge.Value;
            if (drug.MaxPatientAge.HasValue)
                drugInfo.maxAge = drug.MaxPatientAge.Value;
            if (drug.RouteOfAdmin != null)
                drugInfo.drugUsageTypeEnum = drug.RouteOfAdmin.DrugUsageType;
            if (drug.PrescriptionType != null)
                drugInfo.prescriptionTypeEnum = drug.PrescriptionType;
            if (drug.PatientSafetyFrom.HasValue)
                drugInfo.PatientSafetyFrom = drug.PatientSafetyFrom;
            else
                drugInfo.PatientSafetyFrom = false;
            if (drug.InpatientReportType != null)
                drugInfo.DrugReportType = drug.InpatientReportType.Value;
            else
                drugInfo.DrugReportType = DrugReportType.Odenir;

            if (drug.InfectionApproval != null)
                drugInfo.InfectionApproval = drug.InfectionApproval.Value;
            else
                drugInfo.InfectionApproval = false;

            drugInfo.ActiveIngeridents = new List<DrugIngredient>();
            if (drug.DrugActiveIngredients.Count > 0)
            {
                foreach (DrugActiveIngredient dactiveIngredient in drug.DrugActiveIngredients)
                {
                    DrugIngredient drugIngredient = new DrugIngredient();
                    drugIngredient.Objectid = dactiveIngredient.ActiveIngredient.ObjectID;
                    drugIngredient.Name = dactiveIngredient.ActiveIngredient.Name;
                    drugInfo.ActiveIngeridents.Add(drugIngredient);
                }
            }

            if (drug.DrugSpecifications.Count > 0)
                drugInfo.DrugSpecifications = drug.DrugSpecifications.Where(x => x.DrugSpecification.HasValue).Select(x => x.DrugSpecification.Value).ToList();
            context.Dispose();
            return drugInfo;
        }
    }
}
