
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KSchedulePatienOwnDrug")] 

    public  partial class KSchedulePatienOwnDrug : TTObject
    {
        public class KSchedulePatienOwnDrugList : TTObjectCollection<KSchedulePatienOwnDrug> { }
                    
        public class ChildKSchedulePatienOwnDrugCollection : TTObject.TTChildObjectCollection<KSchedulePatienOwnDrug>
        {
            public ChildKSchedulePatienOwnDrugCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKSchedulePatienOwnDrugCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Barkodu Doğrulanan Miktar
    /// </summary>
        public double? BarcodeVerifyCounter
        {
            get { return (double?)this["BARCODEVERIFYCOUNTER"]; }
            set { this["BARCODEVERIFYCOUNTER"] = value; }
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
    /// Miktar
    /// </summary>
        public double? DrugAmount
        {
            get { return (double?)this["DRUGAMOUNT"]; }
            set { this["DRUGAMOUNT"] = value; }
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

        virtual protected void CreateDrugOrderDetailsCollection()
        {
            _DrugOrderDetails = new DrugOrderDetail.ChildDrugOrderDetailCollection(this, new Guid("8ea9bf4e-e847-4b48-a71c-261652b9fc59"));
            ((ITTChildObjectCollection)_DrugOrderDetails).GetChildren();
        }

        protected DrugOrderDetail.ChildDrugOrderDetailCollection _DrugOrderDetails = null;
        public DrugOrderDetail.ChildDrugOrderDetailCollection DrugOrderDetails
        {
            get
            {
                if (_DrugOrderDetails == null)
                    CreateDrugOrderDetailsCollection();
                return _DrugOrderDetails;
            }
        }

        protected KSchedulePatienOwnDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KSchedulePatienOwnDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KSchedulePatienOwnDrug(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KSchedulePatienOwnDrug(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KSchedulePatienOwnDrug(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KSCHEDULEPATIENOWNDRUG", dataRow) { }
        protected KSchedulePatienOwnDrug(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KSCHEDULEPATIENOWNDRUG", dataRow, isImported) { }
        public KSchedulePatienOwnDrug(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KSchedulePatienOwnDrug(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KSchedulePatienOwnDrug() : base() { }

    }
}