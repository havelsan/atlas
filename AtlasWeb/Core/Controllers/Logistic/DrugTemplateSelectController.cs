using System.Collections.Generic;
using System.Linq;
using Core.Models;
using TTInstanceManagement;
using System;
using TTObjectClasses;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Filters;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class DrugTemplateSelectController : Controller
    {
        public class TempInputDVO
        {
            public List<DrugOrderIntroductionDet> details { get; set; }
        }

        [HttpPost]
        public List<GridDetailItem> GetGridDetails(TempInputDVO input)
        {
            List<GridDetailItem> details = new List<GridDetailItem>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                foreach (DrugOrderIntroductionDet det in input.details)
                {
                    DrugOrderIntroductionDet orderDetail = (DrugOrderIntroductionDet)objectContext.GetObject(det.ObjectID, typeof(DrugOrderIntroductionDet));
                    GridDetailItem item = new GridDetailItem();
                    item.Name = orderDetail.Material.Name;
                    item.Frequency = Common.GetDisplayTextOfEnumValue("FrequencyEnum", (int)orderDetail.Frequency);
                    item.DoseAmount = (int)orderDetail.DoseAmount;
                    item.Day = (int)orderDetail.Day;
                    details.Add(item);
                }
                objectContext.FullPartialllyLoadedObjects();
                return details;
            }
        }

        public class GridDetailItem
        {
            public string Name { get; set; }
            public string Frequency { get; set; }
            public int DoseAmount { get; set; }
            public int Day { get; set; }

        }
    }
}
