using Core.Models;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using TTConnectionManager;
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
    public class OrderRestDayDefinitionController : Controller
    {

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetOrderRestDayDefinition getAllorderRestDayDefinition()
        {
            GetOrderRestDayDefinition orderRestDayDefinition = new GetOrderRestDayDefinition();
            orderRestDayDefinition.orderRestDayDefinitionListDTOs = new List<OrderRestDayDefinitionListDTO>();

            orderRestDayDefinition.orderRestDayDefinitionListDTOs = OrderRestDayDef.GetOrderRestDayDefList(string.Empty).Select(x => new OrderRestDayDefinitionListDTO()
            {
                RestDayDescription = x.RestDayDescription,
                OrderDay = x.OrderDay,
                ObjectID = x.ObjectID.Value,
            }).ToList();
          
            return orderRestDayDefinition;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public OrderRestDayDefinitionOutputItem getOrderRestDayDefinitionItem(GetOrderRestDayDefinition_Input input)
        {
            using (var objectContect = new TTObjectContext(false))
            {
                OrderRestDayDefinitionOutputItem outputItem = new OrderRestDayDefinitionOutputItem();

                OrderRestDayDef orderRestDayDefinition = objectContect.GetObject<OrderRestDayDef>(input.ObjectID);
                outputItem.ObjectID = orderRestDayDefinition.ObjectID;
                outputItem.OrderDay = orderRestDayDefinition.OrderDay;
                outputItem.isNew = false;
                outputItem.RestDayCount = orderRestDayDefinition.RestDayCount;
                outputItem.RestDayDescription = orderRestDayDefinition.RestDayDescription;
                outputItem.IsActive = orderRestDayDefinition.IsActive;
                return outputItem;
            }
        }

        [HttpPost]
        public string saveObject(OrderRestDayDefinitionOutputItem input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                OrderRestDayDef orderRestDayDefinition = null;
                if (input.isNew == true)
                {
                    orderRestDayDefinition = new OrderRestDayDef(objectContext);
                }
                else
                {
                    orderRestDayDefinition = objectContext.GetObject<OrderRestDayDef>(input.ObjectID);
                }

                orderRestDayDefinition.OrderDay = input.OrderDay;
                orderRestDayDefinition.RestDayCount = input.RestDayCount;
                orderRestDayDefinition.RestDayDescription = input.RestDayDescription;
                orderRestDayDefinition.IsActive = input.IsActive;
                orderRestDayDefinition.IsActive = input.IsActive;
                
                objectContext.Save();
                objectContext.Dispose();
                return "Order Tatil Kayıt İşlemi Yapılmıştır";
            }
            catch (Exception ex)
            {
                return ex.Message + "-- Order Tatil Kayıt İşlemi Sırasında Hata Alınmıştır..";
            }
        }


        public class OrderRestDayDefinitionListDTO
        {
            public Guid ObjectID { get; set; }
            public string RestDayDescription { get; set; }
            public DateTime? OrderDay { get; set; }
        }

        public class GetOrderRestDayDefinition
        {
            public List<OrderRestDayDefinitionListDTO> orderRestDayDefinitionListDTOs { get; set; }
        }

        public class GetOrderRestDayDefinition_Input
        {
            public Guid ObjectID { get; set; }
        }


        public class OrderRestDayDefinitionOutputItem
        {
            public bool isNew { get; set; }
            public Guid ObjectID { get; set; }
            public string RestDayDescription { get; set; }
            public DateTime? OrderDay { get; set; }
            public int? RestDayCount { get; set; }
            public bool? IsActive { get; set; }
        }


    }
}
