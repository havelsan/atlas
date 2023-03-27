
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KScheduleUnListMaterial")] 

    public  partial class KScheduleUnListMaterial : TTObject
    {
        public class KScheduleUnListMaterialList : TTObjectCollection<KScheduleUnListMaterial> { }
                    
        public class ChildKScheduleUnListMaterialCollection : TTObject.TTChildObjectCollection<KScheduleUnListMaterial>
        {
            public ChildKScheduleUnListMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKScheduleUnListMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Doz
    /// </summary>
        public double? UnlistVolume
        {
            get { return (double?)this["UNLISTVOLUME"]; }
            set { this["UNLISTVOLUME"] = value; }
        }

    /// <summary>
    /// İlaç
    /// </summary>
        public string UnlistDrug
        {
            get { return (string)this["UNLISTDRUG"]; }
            set { this["UNLISTDRUG"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? UnlistAmount
        {
            get { return (double?)this["UNLISTAMOUNT"]; }
            set { this["UNLISTAMOUNT"] = value; }
        }

    /// <summary>
    /// Hasta
    /// </summary>
        public string UnlistPatient
        {
            get { return (string)this["UNLISTPATIENT"]; }
            set { this["UNLISTPATIENT"] = value; }
        }

    /// <summary>
    /// Sebebi
    /// </summary>
        public string UnlistReason
        {
            get { return (string)this["UNLISTREASON"]; }
            set { this["UNLISTREASON"] = value; }
        }

        public KSchedule KSchedule
        {
            get { return (KSchedule)((ITTObject)this).GetParent("KSCHEDULE"); }
            set { this["KSCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDrugOrderDetailsCollection()
        {
            _DrugOrderDetails = new DrugOrderDetail.ChildDrugOrderDetailCollection(this, new Guid("1d375df8-4277-4854-aa00-2f287e4a40fb"));
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

        protected KScheduleUnListMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KScheduleUnListMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KScheduleUnListMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KScheduleUnListMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KScheduleUnListMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KSCHEDULEUNLISTMATERIAL", dataRow) { }
        protected KScheduleUnListMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KSCHEDULEUNLISTMATERIAL", dataRow, isImported) { }
        public KScheduleUnListMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KScheduleUnListMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KScheduleUnListMaterial() : base() { }

    }
}