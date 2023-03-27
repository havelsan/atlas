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

namespace Core.Controllers
{
    public class MaterialExprationDateFilter_Input
    {
        public string StoreObjectId
        {
            get;
            set;
        }

        public int DayQueryNumber
        {
            get;
            set;
        }
    }

    public class MaterialExprationDateFilter_Output
    {
        public string Name
        {
            get;
            set;
        }

        public string NATOStockNO
        {
            get;
            set;
        }
        public string Restamount
        {
            get;
            set;
        }
        public DateTime? ExpirationDate
        {
            get;
            set;
        }
        public int DayLife
        {
            get;
            set;
        }

        public Guid? Stock
        {
            get;
            set;
        }
        public Guid? MaterialTree
        {
            get;
            set;
        }
        public string Barcode { get; set; } 
    }
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class MaterialExpirationDateInfoServiceController : Controller
    {

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public BindingList<MaterialExprationDateFilter_Output> getMaterialsInfoByExprationDate(MaterialExprationDateFilter_Input input)
        {

            using (var context = new TTObjectContext(false))
            {
                try
                {
                    int queryDay = input.DayQueryNumber;
                    DateTime start = DateTime.Now;
                    DateTime end = start.AddDays(queryDay);
                    BindingList<StockTransaction.GetMaterialInHeldStoreByExpirationDate_Class> list = StockTransaction.GetMaterialInHeldStoreByExpirationDate(context, new Guid(input.StoreObjectId), end);
                    BindingList<MaterialExprationDateFilter_Output> resultList = new BindingList<MaterialExprationDateFilter_Output>();

                    foreach (StockTransaction.GetMaterialInHeldStoreByExpirationDate_Class obj in list)
                    {
                        MaterialExprationDateFilter_Output addedObj = new MaterialExprationDateFilter_Output();
                        addedObj.Name = obj.Name;
                        addedObj.NATOStockNO = obj.NATOStockNO;
                        addedObj.Restamount = obj.Restamount.ToString();
                        addedObj.ExpirationDate = obj.ExpirationDate;
                        addedObj.Stock = obj.Stock;
                        addedObj.MaterialTree = obj.MaterialTree;
                        addedObj.Barcode = obj.Barcode;
                        if (obj.ExpirationDate != null)
                        {
                            DateTime now = DateTime.Now;
                            
                            if (now < obj.ExpirationDate)
                            {
                                TimeSpan time = obj.ExpirationDate.Value.Subtract(now);
                                addedObj.DayLife = (int)time.TotalDays;
                            }
                            else
                            {
                                TimeSpan time = now.Subtract(obj.ExpirationDate.Value);
                                addedObj.DayLife = -(int)time.TotalDays;
                            }
                        }
                        resultList.Add(addedObj);
                    }


                    return resultList;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool getMaterialExpirationShownOnTab()
        {
            using (var context = new TTObjectContext(false))
            {
                try
                {
                    string materialExpirationShownOnTab = TTObjectClasses.SystemParameter.GetParameterValue("MaterialExpirationShownOnTab", "false");
                    bool isOnTab = Boolean.Parse(materialExpirationShownOnTab);
                    return isOnTab;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }

}

namespace Core.Models
{
    public class MaterialExpirationDateInfoFormViewModel
    {

    }

}
