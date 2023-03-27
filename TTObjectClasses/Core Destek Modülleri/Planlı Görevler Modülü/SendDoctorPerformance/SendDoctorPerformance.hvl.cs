
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
namespace TTObjectClasses
{
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendDoctorPerformance")] 

    /// <summary>
    /// Doktor Performans Gönder
    /// </summary>
    public  partial class SendDoctorPerformance : BaseScheduledTask
    {
        public class SendDoctorPerformanceList : TTObjectCollection<SendDoctorPerformance> { }
                    
        public class ChildSendDoctorPerformanceCollection : TTObject.TTChildObjectCollection<SendDoctorPerformance>
        {
            public ChildSendDoctorPerformanceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendDoctorPerformanceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Gönderilecek DP Başlangıç Tarihi
    /// </summary>
        public DateTime? DpStartDate
        {
            get { return (DateTime?)this["DPSTARTDATE"]; }
            set { this["DPSTARTDATE"] = value; }
        }

    /// <summary>
    /// Gönderilecek DP Bitiş Tarihi
    /// </summary>
        public DateTime? DpEndDate
        {
            get { return (DateTime?)this["DPENDDATE"]; }
            set { this["DPENDDATE"] = value; }
        }

        protected SendDoctorPerformance(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendDoctorPerformance(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendDoctorPerformance(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendDoctorPerformance(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendDoctorPerformance(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDDOCTORPERFORMANCE", dataRow) { }
        protected SendDoctorPerformance(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDDOCTORPERFORMANCE", dataRow, isImported) { }
        public SendDoctorPerformance(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendDoctorPerformance(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendDoctorPerformance() : base() { }

    }
}