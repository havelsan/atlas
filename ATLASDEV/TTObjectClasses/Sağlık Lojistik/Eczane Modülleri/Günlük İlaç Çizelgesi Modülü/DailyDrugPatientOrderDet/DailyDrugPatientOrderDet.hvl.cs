
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DailyDrugPatientOrderDet")] 

    public  partial class DailyDrugPatientOrderDet : TTObject
    {
        public class DailyDrugPatientOrderDetList : TTObjectCollection<DailyDrugPatientOrderDet> { }
                    
        public class ChildDailyDrugPatientOrderDetCollection : TTObject.TTChildObjectCollection<DailyDrugPatientOrderDet>
        {
            public ChildDailyDrugPatientOrderDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDailyDrugPatientOrderDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DailyDrugPatient DailyDrugPatient
        {
            get { return (DailyDrugPatient)((ITTObject)this).GetParent("DAILYDRUGPATIENT"); }
            set { this["DAILYDRUGPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrderDetail DrugOrderDetail
        {
            get { return (DrugOrderDetail)((ITTObject)this).GetParent("DRUGORDERDETAIL"); }
            set { this["DRUGORDERDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DailyDrugPatientOrderDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DailyDrugPatientOrderDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DailyDrugPatientOrderDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DailyDrugPatientOrderDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DailyDrugPatientOrderDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DAILYDRUGPATIENTORDERDET", dataRow) { }
        protected DailyDrugPatientOrderDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DAILYDRUGPATIENTORDERDET", dataRow, isImported) { }
        public DailyDrugPatientOrderDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DailyDrugPatientOrderDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DailyDrugPatientOrderDet() : base() { }

    }
}