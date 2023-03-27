using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TTDataDictionary;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace AtlasDataSource.Modules.Logistic
{
    public class MaterialStokLevelReport
    {
        public static List<MaterialStockLevelDataModel> GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<List<MaterialStockLevelDataModel>>(parameters, "GetMaterialStockLevelReport");
        }

        public static List<MaterialStockLevelDataModel> GetMaterialStockLevelReport(string parameters)
        {
            var param = Newtonsoft.Json.JsonConvert.DeserializeObject<MaterialStockLevelParameters>(parameters.ToString());

            List<MaterialStockLevelDataModel> list = new List<MaterialStockLevelDataModel>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                if (param != null && param.StoreObjectID != Guid.Empty)
                {
                   list = Stock.GetCriticalStockLevelsNQL(param.StoreObjectID).Select(p => new MaterialStockLevelDataModel { 
                        CriticalLevel = p.CriticalLevel,
                        DistributionType = p.DistributionType,
                        Inheld = p.Inheld,
                        MaximumLevel = p.MaximumLevel,
                        MinimumLevel = p.MinimumLevel,
                        Name = p.Name,
                        ObjectID = p.ObjectID
                   }).ToList();
                }
                else
                {
                    throw new TTException("Depo seçilmedi!");
                }   
            }

            return list;
        }

    }

    public class MaterialStockLevelParameters
    {
        public Guid StoreObjectID { get; set; }
    }

    public class MaterialStockLevelDataModel
    {
        public Guid? ObjectID { get;set; }

        public string Name { get;set; }

        public string DistributionType { get;set; }

        public Currency? Inheld { get;set; }

        public Currency? MinimumLevel { get;set; }

        public Currency? CriticalLevel { get;set; }
        [DataMember]
        public Currency? MaximumLevel { get;set; }
    }
}
