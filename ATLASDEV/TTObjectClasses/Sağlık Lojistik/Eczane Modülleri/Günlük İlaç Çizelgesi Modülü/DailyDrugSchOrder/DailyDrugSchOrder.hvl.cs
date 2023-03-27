
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DailyDrugSchOrder")] 

    public  partial class DailyDrugSchOrder : TTObject
    {
        public class DailyDrugSchOrderList : TTObjectCollection<DailyDrugSchOrder> { }
                    
        public class ChildDailyDrugSchOrderCollection : TTObject.TTChildObjectCollection<DailyDrugSchOrder>
        {
            public ChildDailyDrugSchOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDailyDrugSchOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Guid? KSchMaterial
        {
            get { return (Guid?)this["KSCHMATERIAL"]; }
            set { this["KSCHMATERIAL"] = value; }
        }

    /// <summary>
    /// Doz Miktarı
    /// </summary>
        public double? DoseAmount
        {
            get { return (double?)this["DOSEAMOUNT"]; }
            set { this["DOSEAMOUNT"] = value; }
        }

        public DailyDrugSchedule DailyDrugSchedule
        {
            get { return (DailyDrugSchedule)((ITTObject)this).GetParent("DAILYDRUGSCHEDULE"); }
            set { this["DAILYDRUGSCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DailyDrugPatient DailyDrugPatient
        {
            get { return (DailyDrugPatient)((ITTObject)this).GetParent("DAILYDRUGPATIENT"); }
            set { this["DAILYDRUGPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDailyDrugSchOrderDetailsCollection()
        {
            _DailyDrugSchOrderDetails = new DailyDrugSchOrderDetail.ChildDailyDrugSchOrderDetailCollection(this, new Guid("1aaae161-e72b-42a5-9d70-02b0a2d17b60"));
            ((ITTChildObjectCollection)_DailyDrugSchOrderDetails).GetChildren();
        }

        protected DailyDrugSchOrderDetail.ChildDailyDrugSchOrderDetailCollection _DailyDrugSchOrderDetails = null;
        public DailyDrugSchOrderDetail.ChildDailyDrugSchOrderDetailCollection DailyDrugSchOrderDetails
        {
            get
            {
                if (_DailyDrugSchOrderDetails == null)
                    CreateDailyDrugSchOrderDetailsCollection();
                return _DailyDrugSchOrderDetails;
            }
        }

        protected DailyDrugSchOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DailyDrugSchOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DailyDrugSchOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DailyDrugSchOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DailyDrugSchOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DAILYDRUGSCHORDER", dataRow) { }
        protected DailyDrugSchOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DAILYDRUGSCHORDER", dataRow, isImported) { }
        public DailyDrugSchOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DailyDrugSchOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DailyDrugSchOrder() : base() { }

    }
}