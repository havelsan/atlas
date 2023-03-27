
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KScheduleInfectionDrug")] 

    public  partial class KScheduleInfectionDrug : TTObject
    {
        public class KScheduleInfectionDrugList : TTObjectCollection<KScheduleInfectionDrug> { }
                    
        public class ChildKScheduleInfectionDrugCollection : TTObject.TTChildObjectCollection<KScheduleInfectionDrug>
        {
            public ChildKScheduleInfectionDrugCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKScheduleInfectionDrugCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Barkodu Doğrulanan Miktar
    /// </summary>
        public double? BarcodeVerifyCounter
        {
            get { return (double?)this["BARCODEVERIFYCOUNTER"]; }
            set { this["BARCODEVERIFYCOUNTER"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? DrugAmount
        {
            get { return (double?)this["DRUGAMOUNT"]; }
            set { this["DRUGAMOUNT"] = value; }
        }

    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpirationDate
        {
            get { return (DateTime?)this["EXPIRATIONDATE"]; }
            set { this["EXPIRATIONDATE"] = value; }
        }

    /// <summary>
    /// Onaylandı
    /// </summary>
        public bool? IsApproved
        {
            get { return (bool?)this["ISAPPROVED"]; }
            set { this["ISAPPROVED"] = value; }
        }

    /// <summary>
    /// Kontravisit
    /// </summary>
        public bool? IsCV
        {
            get { return (bool?)this["ISCV"]; }
            set { this["ISCV"] = value; }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public StockActionDetailStatusEnum? StockActionStatus
        {
            get { return (StockActionDetailStatusEnum?)(int?)this["STOCKACTIONSTATUS"]; }
            set { this["STOCKACTIONSTATUS"] = value; }
        }

    /// <summary>
    /// DrugOrderObjectID
    /// </summary>
        public Guid? DrugOrderObjectID
        {
            get { return (Guid?)this["DRUGORDEROBJECTID"]; }
            set { this["DRUGORDEROBJECTID"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public KSchedule KSchedule
        {
            get { return (KSchedule)((ITTObject)this).GetParent("KSCHEDULE"); }
            set { this["KSCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KScheduleInfectionDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KScheduleInfectionDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KScheduleInfectionDrug(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KScheduleInfectionDrug(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KScheduleInfectionDrug(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KSCHEDULEINFECTIONDRUG", dataRow) { }
        protected KScheduleInfectionDrug(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KSCHEDULEINFECTIONDRUG", dataRow, isImported) { }
        public KScheduleInfectionDrug(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KScheduleInfectionDrug(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KScheduleInfectionDrug() : base() { }

    }
}