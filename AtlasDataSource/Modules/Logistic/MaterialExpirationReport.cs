using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TTInstanceManagement;
using TTObjectClasses;

namespace AtlasDataSource.Modules.Logistic
{
    public class MaterialExpirationReport
    {
        public static List<MaterialExpirationDataModel> GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<List<MaterialExpirationDataModel>>(parameters, "GetMaterialExpirationReport");
        }

        public static List<MaterialExpirationDataModel> GetMaterialExpirationReport(string parameters)
        {
            var param = Newtonsoft.Json.JsonConvert.DeserializeObject<MaterialExpirationParameters>(parameters.ToString());

            using (var context = new TTObjectContext(false))
            {
                try
                {
                    int queryDay = param.DayQueryNumber;
                    DateTime start = DateTime.Now;
                    DateTime end = start.AddDays(queryDay);
                    List<StockTransaction.GetMaterialInHeldStoreByExpirationDate_Class> list = StockTransaction.GetMaterialInHeldStoreByExpirationDate(context, new Guid(param.StoreObjectId), end).ToList();
                    List<MaterialExpirationDataModel> resultList = new List<MaterialExpirationDataModel>();

                    foreach (var obj in list)
                    {
                        MaterialExpirationDataModel addedObj = new MaterialExpirationDataModel();
                        addedObj.Name = obj.Name;
                        addedObj.NATOStockNO = obj.NATOStockNO;
                        addedObj.Restamount = obj.Restamount.ToString();
                        addedObj.ExpirationDate = obj.ExpirationDate;
                        addedObj.Stock = obj.Stock;
                        addedObj.MaterialTree = obj.MaterialTree;
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


    }

    public class MaterialExpirationParameters
    {
        public string StoreObjectId { get; set; }

        public int DayQueryNumber { get; set; }
    }

    [Serializable]
    public class MaterialExpirationDataModel
    {
        [DataMember]
        public string Name
        {
            get;
            set;
        }
        [DataMember]
        public string NATOStockNO
        {
            get;
            set;
        }
        [DataMember]
        public string Restamount
        {
            get;
            set;
        }
        [DataMember]
        public DateTime? ExpirationDate
        {
            get;
            set;
        }
        [DataMember]
        public int DayLife
        {
            get;
            set;
        }

        [DataMember]
        public Guid? Stock
        {
            get;
            set;
        }
        [DataMember]
        public Guid? MaterialTree
        {
            get;
            set;
        }
    }

}
