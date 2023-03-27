
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DailyDrugUnDrug")] 

    /// <summary>
    /// çıkmayan ilaçları tutar
    /// </summary>
    public  partial class DailyDrugUnDrug : TTObject
    {
        public class DailyDrugUnDrugList : TTObjectCollection<DailyDrugUnDrug> { }
                    
        public class ChildDailyDrugUnDrugCollection : TTObject.TTChildObjectCollection<DailyDrugUnDrug>
        {
            public ChildDailyDrugUnDrugCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDailyDrugUnDrugCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Doz
    /// </summary>
        public double? UnlistVolume
        {
            get { return (double?)this["UNLISTVOLUME"]; }
            set { this["UNLISTVOLUME"] = value; }
        }

        public Guid? KSchUnMaterial
        {
            get { return (Guid?)this["KSCHUNMATERIAL"]; }
            set { this["KSCHUNMATERIAL"] = value; }
        }

    /// <summary>
    /// Doz Miktarı
    /// </summary>
        public double? DoseAmount
        {
            get { return (double?)this["DOSEAMOUNT"]; }
            set { this["DOSEAMOUNT"] = value; }
        }

        public DailyDrugPatient DailyDrugPatient
        {
            get { return (DailyDrugPatient)((ITTObject)this).GetParent("DAILYDRUGPATIENT"); }
            set { this["DAILYDRUGPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DailyDrugSchedule DailyDrugSchedule
        {
            get { return (DailyDrugSchedule)((ITTObject)this).GetParent("DAILYDRUGSCHEDULE"); }
            set { this["DAILYDRUGSCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDailyDrugUnDrugDetsCollection()
        {
            _DailyDrugUnDrugDets = new DailyDrugUnDrugDet.ChildDailyDrugUnDrugDetCollection(this, new Guid("1afe4293-52e1-4dc2-80ae-cab83cfe06af"));
            ((ITTChildObjectCollection)_DailyDrugUnDrugDets).GetChildren();
        }

        protected DailyDrugUnDrugDet.ChildDailyDrugUnDrugDetCollection _DailyDrugUnDrugDets = null;
        public DailyDrugUnDrugDet.ChildDailyDrugUnDrugDetCollection DailyDrugUnDrugDets
        {
            get
            {
                if (_DailyDrugUnDrugDets == null)
                    CreateDailyDrugUnDrugDetsCollection();
                return _DailyDrugUnDrugDets;
            }
        }

        protected DailyDrugUnDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DailyDrugUnDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DailyDrugUnDrug(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DailyDrugUnDrug(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DailyDrugUnDrug(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DAILYDRUGUNDRUG", dataRow) { }
        protected DailyDrugUnDrug(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DAILYDRUGUNDRUG", dataRow, isImported) { }
        public DailyDrugUnDrug(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DailyDrugUnDrug(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DailyDrugUnDrug() : base() { }

    }
}