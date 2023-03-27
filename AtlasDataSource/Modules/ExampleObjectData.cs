using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasDataSource.Modules
{
    public class ExampleObjectData
    { 

        public string SalesPerson { get; set; }
        public int Quantity { get; set; }

        public static List<ExampleObjectData> GetReportData()
        {
            var gg = TTStorageManager.Security.TTUser.CurrentUser;

            List<ExampleObjectData> data = new List<ExampleObjectData>();
            string[] salesPersons = { "Murat Fuller", "Michael Suyama",
                                "Robert King", "Nancy Davolio",
                                "Margaret Peacock", "Laura Callahan",
                                "Steven Buchanan", "Janet Leverling" };
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                ExampleObjectData record = new ExampleObjectData();
                record.SalesPerson = salesPersons[rnd.Next(0, salesPersons.Length)];
                record.Quantity = rnd.Next(0, 100);
                data.Add(record);
            }
            return data;
        }
    }

    public class EmptyDataSource
    {
        public List<object> GetReportData()
        {
            return new List<object>();
        }
    }
}
