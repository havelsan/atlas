using DevExpress.XtraReports.Web.ClientControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportClasses.ReportUtils
{
    public class AtlasSecureDataConverter : ISecureDataConverter
    {
        public string Protect(string entity)
        {
            var buffer = UTF8Encoding.UTF8.GetBytes(entity);
            return Convert.ToBase64String(buffer);
        }

        public string Unprotect(string protectedEntity)
        {
            var buffer = Convert.FromBase64String(protectedEntity);
            return UTF8Encoding.UTF8.GetString(buffer);
        }
    }
}
