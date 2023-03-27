
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MAREquipmentReservation")] 

    /// <summary>
    /// DE_Randevu
    /// </summary>
    public  partial class MAREquipmentReservation : TTObject
    {
        public class MAREquipmentReservationList : TTObjectCollection<MAREquipmentReservation> { }
                    
        public class ChildMAREquipmentReservationCollection : TTObject.TTChildObjectCollection<MAREquipmentReservation>
        {
            public ChildMAREquipmentReservationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMAREquipmentReservationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? FinishDate
        {
            get { return (DateTime?)this["FINISHDATE"]; }
            set { this["FINISHDATE"] = value; }
        }

    /// <summary>
    /// Rezervasyonlar
    /// </summary>
        public MARMedicalEquipment Equipment
        {
            get { return (MARMedicalEquipment)((ITTObject)this).GetParent("EQUIPMENT"); }
            set { this["EQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MAREquipmentReservation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MAREquipmentReservation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MAREquipmentReservation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MAREquipmentReservation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MAREquipmentReservation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAREQUIPMENTRESERVATION", dataRow) { }
        protected MAREquipmentReservation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAREQUIPMENTRESERVATION", dataRow, isImported) { }
        public MAREquipmentReservation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MAREquipmentReservation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MAREquipmentReservation() : base() { }

    }
}