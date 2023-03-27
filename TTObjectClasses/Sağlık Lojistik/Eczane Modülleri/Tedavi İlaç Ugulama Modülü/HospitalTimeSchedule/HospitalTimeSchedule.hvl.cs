
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HospitalTimeSchedule")] 

    /// <summary>
    /// Order Zaman Çizelgesi
    /// </summary>
    public  partial class HospitalTimeSchedule : TTObject
    {
        public class HospitalTimeScheduleList : TTObjectCollection<HospitalTimeSchedule> { }
                    
        public class ChildHospitalTimeScheduleCollection : TTObject.TTChildObjectCollection<HospitalTimeSchedule>
        {
            public ChildHospitalTimeScheduleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHospitalTimeScheduleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Çizelge Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public bool? IsTomorrow
        {
            get { return (bool?)this["ISTOMORROW"]; }
            set { this["ISTOMORROW"] = value; }
        }

        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Doz Aralığı
    /// </summary>
        public RefactoredFrequencyEnum? Frequency
        {
            get { return (RefactoredFrequencyEnum?)(int?)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

        virtual protected void CreateHospitalTimeScheduleDetailsCollection()
        {
            _HospitalTimeScheduleDetails = new HospitalTimeScheduleDetail.ChildHospitalTimeScheduleDetailCollection(this, new Guid("95805655-eaa0-421a-b3a8-142a06f47db1"));
            ((ITTChildObjectCollection)_HospitalTimeScheduleDetails).GetChildren();
        }

        protected HospitalTimeScheduleDetail.ChildHospitalTimeScheduleDetailCollection _HospitalTimeScheduleDetails = null;
        public HospitalTimeScheduleDetail.ChildHospitalTimeScheduleDetailCollection HospitalTimeScheduleDetails
        {
            get
            {
                if (_HospitalTimeScheduleDetails == null)
                    CreateHospitalTimeScheduleDetailsCollection();
                return _HospitalTimeScheduleDetails;
            }
        }

        protected HospitalTimeSchedule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HospitalTimeSchedule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HospitalTimeSchedule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HospitalTimeSchedule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HospitalTimeSchedule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HOSPITALTIMESCHEDULE", dataRow) { }
        protected HospitalTimeSchedule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HOSPITALTIMESCHEDULE", dataRow, isImported) { }
        public HospitalTimeSchedule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HospitalTimeSchedule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HospitalTimeSchedule() : base() { }

    }
}