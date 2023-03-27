
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HospitalTimeScheduleDetail")] 

    /// <summary>
    /// Zaman Çizelgesi Detayları
    /// </summary>
    public  partial class HospitalTimeScheduleDetail : TTObject
    {
        public class HospitalTimeScheduleDetailList : TTObjectCollection<HospitalTimeScheduleDetail> { }
                    
        public class ChildHospitalTimeScheduleDetailCollection : TTObject.TTChildObjectCollection<HospitalTimeScheduleDetail>
        {
            public ChildHospitalTimeScheduleDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHospitalTimeScheduleDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Saat
    /// </summary>
        public DateTime? Time
        {
            get { return (DateTime?)this["TIME"]; }
            set { this["TIME"] = value; }
        }

    /// <summary>
    /// Order Zaman No
    /// </summary>
        public int? TimeNumber
        {
            get { return (int?)this["TIMENUMBER"]; }
            set { this["TIMENUMBER"] = value; }
        }

        public HospitalTimeSchedule HospitalTimeSchedule
        {
            get { return (HospitalTimeSchedule)((ITTObject)this).GetParent("HOSPITALTIMESCHEDULE"); }
            set { this["HOSPITALTIMESCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HospitalTimeScheduleDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HospitalTimeScheduleDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HospitalTimeScheduleDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HospitalTimeScheduleDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HospitalTimeScheduleDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HOSPITALTIMESCHEDULEDETAIL", dataRow) { }
        protected HospitalTimeScheduleDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HOSPITALTIMESCHEDULEDETAIL", dataRow, isImported) { }
        public HospitalTimeScheduleDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HospitalTimeScheduleDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HospitalTimeScheduleDetail() : base() { }

    }
}