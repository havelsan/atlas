
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DailyDrugPatient")] 

    public  partial class DailyDrugPatient : TTObject
    {
        public class DailyDrugPatientList : TTObjectCollection<DailyDrugPatient> { }
                    
        public class ChildDailyDrugPatientCollection : TTObject.TTChildObjectCollection<DailyDrugPatient>
        {
            public ChildDailyDrugPatientCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDailyDrugPatientCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? IsCheck
        {
            get { return (bool?)this["ISCHECK"]; }
            set { this["ISCHECK"] = value; }
        }

        public InPatientPhysicianApplication InPatientPhysicianApplication
        {
            get { return (InPatientPhysicianApplication)((ITTObject)this).GetParent("INPATIENTPHYSICIANAPPLICATION"); }
            set { this["INPATIENTPHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DailyDrugSchedule DailyDrugSchedule
        {
            get { return (DailyDrugSchedule)((ITTObject)this).GetParent("DAILYDRUGSCHEDULE"); }
            set { this["DAILYDRUGSCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDailyDrugUnDrugsCollection()
        {
            _DailyDrugUnDrugs = new DailyDrugUnDrug.ChildDailyDrugUnDrugCollection(this, new Guid("3bce8211-9033-4c20-ace2-e6c02ad07732"));
            ((ITTChildObjectCollection)_DailyDrugUnDrugs).GetChildren();
        }

        protected DailyDrugUnDrug.ChildDailyDrugUnDrugCollection _DailyDrugUnDrugs = null;
        public DailyDrugUnDrug.ChildDailyDrugUnDrugCollection DailyDrugUnDrugs
        {
            get
            {
                if (_DailyDrugUnDrugs == null)
                    CreateDailyDrugUnDrugsCollection();
                return _DailyDrugUnDrugs;
            }
        }

        virtual protected void CreateDailyDrugPatientOrderDetsCollection()
        {
            _DailyDrugPatientOrderDets = new DailyDrugPatientOrderDet.ChildDailyDrugPatientOrderDetCollection(this, new Guid("e994d075-74c8-40de-8416-2ceea00e8f11"));
            ((ITTChildObjectCollection)_DailyDrugPatientOrderDets).GetChildren();
        }

        protected DailyDrugPatientOrderDet.ChildDailyDrugPatientOrderDetCollection _DailyDrugPatientOrderDets = null;
        public DailyDrugPatientOrderDet.ChildDailyDrugPatientOrderDetCollection DailyDrugPatientOrderDets
        {
            get
            {
                if (_DailyDrugPatientOrderDets == null)
                    CreateDailyDrugPatientOrderDetsCollection();
                return _DailyDrugPatientOrderDets;
            }
        }

        virtual protected void CreateDailyDrugSchOrdersCollection()
        {
            _DailyDrugSchOrders = new DailyDrugSchOrder.ChildDailyDrugSchOrderCollection(this, new Guid("88efad4f-3431-4ad2-a46e-a7ea3e9fc630"));
            ((ITTChildObjectCollection)_DailyDrugSchOrders).GetChildren();
        }

        protected DailyDrugSchOrder.ChildDailyDrugSchOrderCollection _DailyDrugSchOrders = null;
        public DailyDrugSchOrder.ChildDailyDrugSchOrderCollection DailyDrugSchOrders
        {
            get
            {
                if (_DailyDrugSchOrders == null)
                    CreateDailyDrugSchOrdersCollection();
                return _DailyDrugSchOrders;
            }
        }

        protected DailyDrugPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DailyDrugPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DailyDrugPatient(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DailyDrugPatient(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DailyDrugPatient(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DAILYDRUGPATIENT", dataRow) { }
        protected DailyDrugPatient(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DAILYDRUGPATIENT", dataRow, isImported) { }
        public DailyDrugPatient(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DailyDrugPatient(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DailyDrugPatient() : base() { }

    }
}