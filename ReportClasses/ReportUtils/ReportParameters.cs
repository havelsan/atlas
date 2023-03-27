using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ReportClasses.Controllers.DynamicReporting
{
    [Serializable]
    public class ReportParameters 
    {
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public string DynamicReportID { get; set; }
        [DataMember]
        public string Code{ get; set; }
        [DataMember]
        public string DynamicReportRevisionID { get; set; }
        [DataMember]
        public string ReportClassName { get; set; }
        [DataMember]
        public string ReportMethodName { get; set; }
        [DataMember]
        public object ReportParams { get; set; }

        [DataMember]
        public string Params
        {
            get
            {
                if(ReportParams != null)
                {
                    return ReportParams.ToString();
                }
                return null;
            }
        }
    }
}
