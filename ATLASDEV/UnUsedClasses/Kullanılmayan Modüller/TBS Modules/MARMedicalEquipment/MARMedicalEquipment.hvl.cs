
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MARMedicalEquipment")] 

    /// <summary>
    /// DE_Tıbbi Cihaz
    /// </summary>
    public  partial class MARMedicalEquipment : TTObject
    {
        public class MARMedicalEquipmentList : TTObjectCollection<MARMedicalEquipment> { }
                    
        public class ChildMARMedicalEquipmentCollection : TTObject.TTChildObjectCollection<MARMedicalEquipment>
        {
            public ChildMARMedicalEquipmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMARMedicalEquipmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

        virtual protected void CreateReservationsCollection()
        {
            _Reservations = new MAREquipmentReservation.ChildMAREquipmentReservationCollection(this, new Guid("93da6cda-217a-43ec-8174-f4245e8faef5"));
            ((ITTChildObjectCollection)_Reservations).GetChildren();
        }

        protected MAREquipmentReservation.ChildMAREquipmentReservationCollection _Reservations = null;
    /// <summary>
    /// Child collection for Rezervasyonlar
    /// </summary>
        public MAREquipmentReservation.ChildMAREquipmentReservationCollection Reservations
        {
            get
            {
                if (_Reservations == null)
                    CreateReservationsCollection();
                return _Reservations;
            }
        }

        protected MARMedicalEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MARMedicalEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MARMedicalEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MARMedicalEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MARMedicalEquipment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MARMEDICALEQUIPMENT", dataRow) { }
        protected MARMedicalEquipment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MARMEDICALEQUIPMENT", dataRow, isImported) { }
        public MARMedicalEquipment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MARMedicalEquipment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MARMedicalEquipment() : base() { }

    }
}